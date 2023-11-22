
using System.Xml.Serialization;

namespace NeuroDigits.NeuralNetwork
{
    public class NeuralNetworkModel
    {
        private Random random = new Random();

        string xmlWeightsFilePath;

        public readonly int[] layersSizes;
        public NeuralNetworkLayers[] layers;

        public NeuralNetworkModel(string xmlWeightsFileName, int[] layersSizes)
        {
            xmlWeightsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, xmlWeightsFileName);
            this.layersSizes = layersSizes;
            NetworkInit();
            RandomFillWeights();
        }

        private void NetworkInit()
        {
            layers = new NeuralNetworkLayers[layersSizes.Length];
            for (int i = 0; i < layersSizes.Length; i++)
            {
                if (i != layersSizes.Length - 1)
                {
                    layers[i] = new NeuralNetworkLayers(layersSizes[i], layersSizes[i + 1]);
                    Console.WriteLine($"> {i + 1} Layer Created!");
                }
                else
                {
                    layers[i] = new NeuralNetworkLayers(layersSizes[i], 0);
                    Console.WriteLine($"> {i + 1} Layer Created!");
                }
            }
            Console.WriteLine(">>> Layers Created!");
        }

        public double[] FeedForward(double[] input)
        {
            layers[0].neurons = input;

            for (int i = 1; i < layers.Length; i++)
            {
                NeuralNetworkLayers l = layers[i - 1];
                NeuralNetworkLayers l1 = layers[i];

                Parallel.For(0, l1.size, j =>
                {
                    l1.neurons[j] = 0;
                    for (int k = 0; k < l.size; k++)
                    {
                        l1.neurons[j] += l.neurons[k] * l.weights[k, j];
                    }
                    l1.neurons[j] += l1.biases[j];
                    l1.neurons[j] = SigmoidFunc(l1.neurons[j]);
                });
            }
            return layers[layers.Length - 1].neurons;
        }

        private void RandomFillWeights()
        {
            Console.WriteLine(">Fill Layers Random Weights!");
            for (int i = 0; i < layers.Length; i++)
            {
                for (int j = 0; j < layers[i].size; j++)
                {
                    layers[i].biases[j] = random.NextDouble() * 2.0 - 1.0;
                    if (i != layers.Length - 1)
                    {
                        for (int k = 0; k < layers[i + 1].size; k++)
                        {
                            layers[i].weights[j, k] = random.NextDouble() * 2.0 - 1.0;
                        }
                    }
                }
            }
        }

        private double SigmoidFunc(double x) => 1.0 / (1.0 + Math.Exp(-x));

        public void SaveWeights()
        {
            File.Delete(xmlWeightsFilePath);
            File.Create(xmlWeightsFilePath).Close();
            foreach (var l in layers)
            {
                l.ConvertWeightsToXMLWeights();
            }
            XmlSerializer xmlSerializer = new XmlSerializer(layers.GetType());
            using (TextWriter writer = new StreamWriter(xmlWeightsFilePath))
            {
                xmlSerializer.Serialize(writer, layers);
            }
            Console.WriteLine(">>>Weights Saved!");
        }
        public bool LoadWeightsIfExists()
        {
            if (File.Exists(xmlWeightsFilePath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(NeuralNetworkLayers[]));
                using (TextReader reader = new StreamReader(xmlWeightsFilePath))
                {
                    layers = (NeuralNetworkLayers[])xmlSerializer.Deserialize(reader);
                }
                foreach (var l in layers)
                {
                    l.ConvertXMLWeightsToWeights();
                }
                return true;
            }
            else return false;
        }
        public void CleanWeights()
        {
            if (File.Exists(xmlWeightsFilePath))
            {
                File.Delete(xmlWeightsFilePath);
                Console.WriteLine(">>>Weights Cleaned!");
                RandomFillWeights();
            }
            else
            {
                Console.WriteLine(">>>Weights Empty!");
            }

        }
    }
}
