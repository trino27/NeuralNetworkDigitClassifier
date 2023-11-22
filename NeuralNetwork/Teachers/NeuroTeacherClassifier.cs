using System.Diagnostics;

namespace NeuroDigits.NeuralNetwork.Teachers
{
    public class NeuroTeacherClassifier : NeuroTeacher
    {
        private Random random = new Random();

        public NeuroTeacherClassifier(double learningRate, NeuralNetworkModel network, string dataSetDirectoryPath)
            : base(learningRate, network, dataSetDirectoryPath)
        {
            Console.WriteLine(">>Teacher Classifier Created!");
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
                    int imgIndex = random.Next(0, DataSet.Length);

                    int correctAnswer = DataSet[imgIndex][^1] - 48;
                    double[] neuroOutputs = NeuroStudent.FeedForward(BitmapToDouble(GetBitmapFromDataSet(imgIndex)));
                    int neuroResultOutput = 0;

                    double maxNeuroOutputWeight = -1;
                    double[] optionTargets = new double[10];

                    optionTargets[correctAnswer] = 1;

                    for (int k = 0; k < optionTargets.Length; k++)
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

                    BackPropagation(optionTargets);

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
