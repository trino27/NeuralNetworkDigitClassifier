
using System.Xml.Serialization;

namespace NeuroTest1
{
    public class NeuroNetwork
    {
        Random random = new Random();

        

        public Layer[] layers;

        private void NetworkConfig()
        {
            const short inputLayerSize = 2048;
            const short hide1LayerSize = 4096;
            const short hide2LayerSize = 1024;
            const short hide3LayerSize = 1024;
            const short outputLayerSize = 10;

            

            layers = new Layer[5];
            layers[0] = new Layer(inputLayerSize, hide1LayerSize);
            layers[1] = new Layer(hide1LayerSize, hide2LayerSize);
            layers[2] = new Layer(hide2LayerSize, hide3LayerSize);
            layers[3] = new Layer(hide3LayerSize, outputLayerSize);
            layers[4] = new Layer(outputLayerSize, 0);

            Console.WriteLine(">Layers Created!");
        }

        public NeuroNetwork()
        {
            NetworkConfig();
            RandomFillWeights();
        }

        public double[] FeedForward(Bitmap bitmap)
        {
            if (bitmap.Width == 64 || bitmap.Height == 32)
            {
                layers[0].neurons = BitmapToDouble(bitmap);
            }
            else throw new Exception("Uncorrect bitmap size! Should be - (64; 32)");

            for (int i = 1; i < layers.Length; i++)
            {
                Layer l = layers[i - 1];
                Layer l1 = layers[i];

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

        public void SaveWeights()
        {
            string xmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "layers.xml");
            File.Delete(xmlFilePath);
            File.Create(xmlFilePath).Close();
            foreach(var l in layers)
            {
                l.ConvertWeightsToXMLWeights();
            }
            XmlSerializer xmlSerializer = new XmlSerializer(layers.GetType());
            using (TextWriter writer = new StreamWriter(xmlFilePath))
            {
                xmlSerializer.Serialize(writer, layers);
            }


            Console.WriteLine(">>>Weights Saved!");
        }
        public bool LoadWeightsIfExists()
        {
            string xmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "layers.xml");
            if (File.Exists(xmlFilePath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Layer[]));
                using (TextReader reader = new StreamReader(xmlFilePath))
                {
                    layers = (Layer[])xmlSerializer.Deserialize(reader);
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
            string xmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "layers.xml");
            if (File.Exists(xmlFilePath))
            {
                File.Delete(xmlFilePath);
                Console.WriteLine(">>>Weights Cleaned!");
                RandomFillWeights();
            }
            else
            {
                Console.WriteLine(">>>Weights Empty!");
            }

        }

        private void RandomFillWeights()
        {
            Console.WriteLine(">Fill Layers Random Weights!");
            /// заполняем рандомніми весами слои если запускаем в первій раз
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

        private double[] BitmapToDouble(Bitmap bitmap)
        {
            double[] res = new double[bitmap.Width * bitmap.Height];
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    res[x * bitmap.Height + y] = (pixel.ToArgb() == Color.Black.ToArgb()) ? 1 : 0;
                }
            }
            return res;
        }

        private double SigmoidFunc(double x) => 1.0 / (1.0 + Math.Exp(-x));
    }
}
