using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NeuroDigits.NeuralNetwork
{
    [Serializable]
    [XmlRoot("Layer")]
    public class NeuralNetworkLayers
    {
        [XmlElement("Size")]
        public int size { get; set; }
        [XmlElement("NextSize")]
        public int nextSize { get; set; }
        [XmlElement("Neurons")]
        public double[] neurons { get; set; }
        [XmlElement("Biases")]
        public double[] biases { get; set; }
        [XmlIgnore]
        public double[,] weights { get; set; }
        [XmlElement("Weights")]
        public double[] xmlWeights { get; set; }

        [Obsolete("This method only for serialization")]
        public NeuralNetworkLayers()
        {
            size = 0;
            nextSize = 0;
            neurons = new double[size];
            biases = new double[size];
            weights = new double[size, nextSize];
            xmlWeights = new double[size * nextSize];
        }
        public NeuralNetworkLayers(int size, int nextSize)
        {
            this.size = size;
            this.nextSize = nextSize;
            neurons = new double[size];
            biases = new double[size];
            weights = new double[size, nextSize];
            xmlWeights = new double[size * nextSize];
        }

        public void ConvertWeightsToXMLWeights()
        {
            if (nextSize != 0) xmlWeights = new double[size * nextSize];
            else xmlWeights = new double[size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < nextSize; j++)
                {
                    xmlWeights[i * nextSize + j] = weights[i, j];
                }
            }
        }
        public void ConvertXMLWeightsToWeights()
        {
            weights = new double[size, nextSize];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < nextSize; j++)
                {
                    weights[i, j] = xmlWeights[i * nextSize + j];
                }
            }
        }


    }
}
