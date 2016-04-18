using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileWorker;
using NeuralNetwork;

namespace CyberCortex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = 10000;
            string root = Environment.CurrentDirectory.Substring(0, 19);

            string path = root + @"samples\samples.csv";
            int amountLayers = 2;
            int amountNeurons = 3;

            double[,] patterns = null;
            double[,] answers = null;
            Samples samples = new Samples();

            if (samples.GetData(path))
            {
                patterns = samples.ConvertToDouble(samples.GetPatterns());
                answers = samples.ConvertToDouble(samples.GetAnswers());

                Store.SetAmountLayers(amountLayers);
                Store.SetAmountNeurons(amountNeurons);
                Store.SetAmountSignals(patterns.GetLength(1));

                Network network = new Network(patterns, answers);

                network.Init();
            }
            Console.ReadKey();
        }
    }
}
