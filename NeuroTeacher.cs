using System;
using System.Diagnostics;

namespace NeuroTest1
{
    public class NeuroTeacher
    {
        public NeuroNetwork NeuroStudent;

        Random random = new Random();

        private double learningRate;

        private string[] DataSet;
        private string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataSet");

        public NeuroTeacher(double learningRate, NeuroNetwork network)
        {
            InitDataSet();
            this.learningRate = learningRate;
            NeuroStudent = network;
            Console.WriteLine(">>Teacher Created!");
        }
        public NeuroTeacher(double learningRate, NeuroNetwork network, string dataSetDirectoryPath)
        {
            directoryPath = dataSetDirectoryPath;
            InitDataSet();
            this.learningRate = learningRate;
            NeuroStudent = network;
            Console.WriteLine(">>eacher Created!");
        }

        public void Teach(int epochs)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine(">>Inside Teach Func:");

            for (int i = 0; i < epochs; i++)
            {
                stopwatch.Restart();
                int numOfCorrectAnswer = 0;
                double errorSum = 0;

                int batchSize = 100; // в епохе 100 картинок

                for (int j = 0; j < batchSize; j++)
                {
                    int imgIndex = random.Next(0, DataSet.Length);

                    int correctAnswer = DataSet[imgIndex][^1] - 48;
                    double[] neuroOutputs = NeuroStudent.FeedForward(GetBitmapFromDataSet(imgIndex));
                    int neuroResultOutput = 0;

                    double maxNeuroOutputWeight = -1;
                    double[] optionTargets = new double[10];

                    optionTargets[correctAnswer] = 1;
                    BackPropagation(optionTargets);

                    for (int k = 0; k < 10; k++)
                    {
                        if (neuroOutputs[k] > maxNeuroOutputWeight)
                        {
                            maxNeuroOutputWeight = neuroOutputs[k];
                            neuroResultOutput = k;
                        }
                        errorSum += (optionTargets[k] - neuroOutputs[k]) * (optionTargets[k] - neuroOutputs[k]);
                    }
                    if (correctAnswer == neuroResultOutput)
                    {
                        numOfCorrectAnswer++;
                    }
                    Console.Write(">");
                }
                Console.WriteLine();
                stopwatch.Stop();
                Console.WriteLine("> epoch: " + i + ". correct: " + numOfCorrectAnswer + "% error: " + errorSum + " time: " + (double)stopwatch.ElapsedMilliseconds / 1000.0);
            }
            Console.WriteLine(">>>Saving..");
            NeuroStudent.SaveWeights();
        }
       
        private void BackPropagation(double[] targets)
        {
            int outputErrorSize = NeuroStudent.layers[NeuroStudent.layers.Length - 1].size;

            double[] outputErrors = new double[outputErrorSize];

            Parallel.For(0, outputErrorSize, i =>
            {
                outputErrors[i] = targets[i] - NeuroStudent.layers[NeuroStudent.layers.Length - 1].neurons[i];
            });

            for (int k = NeuroStudent.layers.Length - 2; k >= 0; k--)
            {
                Layer l = NeuroStudent.layers[k];
                Layer l1 = NeuroStudent.layers[k + 1];

                double[] errorsNext = new double[l.size];
                Task taskError = Task.Run(() => { // Обновим веса текущего слоя
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
                Task taskDeltas = Task.Run(() => { // Обновим веса текущего слоя
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
                Task taskUpdate = Task.Run(() => { // Обновим веса текущего слоя
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

        private void InitDataSet()
        {
            DataSet = Directory.GetFiles(directoryPath);
        }
        private Bitmap GetBitmapFromDataSet(int number)
        {
            Image img = Bitmap.FromFile(DataSet[number]);
            return new Bitmap(img);
        }

        private double DsigmoidFunc(double x) => x * (1.0 - x);
    }
}
