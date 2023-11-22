using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroDigits.NeuralNetwork.Teachers
{
    public abstract class NeuroTeacher
    {
        public readonly NeuralNetworkModel NeuroStudent;

        protected double learningRate;
        protected string[] DataSet;

        private readonly string directoryPath;

        protected NeuroTeacher(double learningRate, NeuralNetworkModel network, string dataSetDirectoryPath)
        {
            directoryPath = dataSetDirectoryPath;
            InitDataSet();
            NeuroStudent = network;
            this.learningRate = learningRate;
        }

        protected void InitDataSet()
        {
            DataSet = Directory.GetFiles(directoryPath);
        }

        protected double[] BitmapToDouble(Bitmap bitmap)
        {
            double[] res = new double[bitmap.Width * bitmap.Height];
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    res[x * bitmap.Height + y] = pixel.ToArgb() == Color.Black.ToArgb() ? 1 : 0;
                }
            }
            if (bitmap.Width != 64 || bitmap.Height != 32)
            {
                throw new Exception("Uncorrect bitmap size! Should be - (64; 32)");
            }
            return res;
        }
        protected Bitmap GetBitmapFromDataSet(int number)
        {
            Image img = Image.FromFile(DataSet[number]);
            return new Bitmap(img);
        }

        protected void BackPropagation(double[] targets)
        {
            int outputErrorSize = NeuroStudent.layers[NeuroStudent.layers.Length - 1].size;

            double[] outputErrors = new double[outputErrorSize];

            Parallel.For(0, outputErrorSize, i =>
            {
                outputErrors[i] = targets[i] - NeuroStudent.layers[NeuroStudent.layers.Length - 1].neurons[i];
            });

            for (int k = NeuroStudent.layers.Length - 2; k >= 0; k--)
            {
                NeuralNetworkLayers l = NeuroStudent.layers[k];
                NeuralNetworkLayers l1 = NeuroStudent.layers[k + 1];

                double[] errorsNext = new double[l.size];
                Task taskError = Task.Run(() =>
                { // Обновим веса текущего слоя
                    Parallel.For(0, l.size, i =>
                    {
                        double errorSum = 0;
                        for (int j = 0; j < l1.size; j++)
                        {
                            errorSum += l.weights[i, j] * outputErrors[j];
                        }
                        errorsNext[i] = errorSum;
                    });
                });

                double[] gradients = new double[l1.size];
                for (int i = 0; i < l1.size; i++)
                {
                    gradients[i] = outputErrors[i] * DsigmoidFunc(NeuroStudent.layers[k + 1].neurons[i]);
                    gradients[i] *= learningRate;
                }

                double[,] deltas = new double[l1.size, l.size];
                Task taskDeltas = Task.Run(() =>
                { // Обновим веса текущего слоя
                    Parallel.For(0, l1.size, i =>
                    {
                        for (int j = 0; j < l.size; j++)
                        {
                            deltas[i, j] = gradients[i] * l.neurons[j];
                        }
                    });
                });

                // Обновим смещения (biases) следующего слоя
                for (int i = 0; i < l1.size; i++)
                {
                    l1.biases[i] += gradients[i];
                }


                taskError.Wait();
                // Обновим ошибку для следующей итерации
                outputErrors = errorsNext;

                taskDeltas.Wait();
                Task taskUpdate = Task.Run(() =>
                { // Обновим веса текущего слоя
                    Parallel.For(0, l1.size, i =>
                    {
                        for (int j = 0; j < l.size; j++)
                        {
                            l.weights[j, i] += deltas[i, j];
                        }
                    });
                });

                taskUpdate.Wait();
            }
        }

        public abstract void Teach(int epochs);
        
        private double DsigmoidFunc(double x) => x * (1.0 - x);
    }
}
