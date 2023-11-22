using System.Diagnostics;

namespace NeuroDigits.NeuralNetwork.Teachers
{
    public class NeuroTeacherArtist : NeuroTeacher
    {
        private Random random = new Random();

        NeuralNetworkModel networkClassifier;
        List<List<int>> DataSetDigitIndexes = new List<List<int>>();

        public NeuroTeacherArtist(double learningRate, NeuralNetworkModel network, NeuralNetworkModel networkClassifier, string dataSetDirectoryPath)
            : base(learningRate, network, dataSetDirectoryPath)
        {
            this.networkClassifier = networkClassifier;



            for (int j = 0; j <= 10; j++)
            {
                DataSetDigitIndexes.Add(new List<int>());
            }
            Parallel.For(0, DataSet.Length, i =>
            {
                switch (DataSet[i][^1])
                {
                    case '1': DataSetDigitIndexes[1].Add(i); break;
                    case '2': DataSetDigitIndexes[2].Add(i); break;
                    case '3': DataSetDigitIndexes[3].Add(i); break;
                    case '4': DataSetDigitIndexes[4].Add(i); break;
                    case '5': DataSetDigitIndexes[5].Add(i); break;
                    case '6': DataSetDigitIndexes[6].Add(i); break;
                    case '7': DataSetDigitIndexes[7].Add(i); break;
                    case '8': DataSetDigitIndexes[8].Add(i); break;
                    case '9': DataSetDigitIndexes[9].Add(i); break;
                    case '0': DataSetDigitIndexes[0].Add(i); break;
                }
            });

            Console.WriteLine(">>Teacher Artist Created!");
        }

        public override void Teach(int epochs)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine(">>Inside Teach Func:");

            for (int i = 0; i < epochs; i++)
            {
                stopwatch.Restart();
                int numOfCorrectAnswer = 0;
                double errorSum = 0;

                int batchSize = 100;

                for (int j = 0; j < batchSize; j++)
                {
                    int randDigit = random.Next(0, 10);

                    double[] inputs = new double[10];
                    for (int k = 0; k < inputs.Length; k++)
                    {
                        inputs[k] = 0;
                    }
                    inputs[randDigit] = randDigit;

                    int correctAnswer = randDigit;

                    double[] neuroOutputs = NeuroStudent.FeedForward(inputs);
                    double[] optionTargets = BitmapToDouble(GetBitmapFromDataSet(DataSetDigitIndexes[randDigit][random.Next(0, DataSetDigitIndexes[randDigit].Count)]));

                    int maxDigit = 0;


                    //double maxDigitWeight = -1;
                    //double[] outputs = networkClassifier.FeedForward(neuroOutputs);

                    //for (int k = 0; k < 10; k++)
                    //{
                    //    if (outputs[k] > maxDigitWeight)
                    //    {
                    //        maxDigitWeight = outputs[k];
                    //        maxDigit = k;
                    //    }
                    //}

                    BackPropagation(optionTargets);

                    for (int k = 0; k < 2048; k++)
                    {
                        errorSum += (optionTargets[k] - neuroOutputs[k]) * (optionTargets[k] - neuroOutputs[k]);
                    }


                    //if (correctAnswer == maxDigit)
                    //{
                    //    numOfCorrectAnswer++;
                    //}
                    Console.Write(">");

                }
                Console.WriteLine();
                stopwatch.Stop();
                Console.WriteLine("> epoch: " + i + ". correct: " + numOfCorrectAnswer + "% error: " + errorSum + " time: " + stopwatch.ElapsedMilliseconds / 1000.0);
            }
            Console.WriteLine(">>>Saving..");
            NeuroStudent.SaveWeights();
        }


    }
}
