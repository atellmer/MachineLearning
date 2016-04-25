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
            int[] architecture = new int[] { 3, 2, 5};
            int amountClasses = 2;
            double alfaFactor = 1;
           

            double[,] patterns = null;
            double[,] answers = null;
            Samples samples = new Samples();

            if (samples.GetData(path))
            {
                patterns = samples.ConvertToDouble(samples.GetPatterns());
                answers = samples.ConvertToDouble(samples.GetAnswers());

                Store.SetArchitecture(architecture);
                Store.SetAmountSignals(patterns.GetLength(1));
                Store.SetAmountClasses(amountClasses);
                Store.SetAlfaFactor(alfaFactor);

                Network network = new Network(patterns, answers);

                network.Init();
            }
            Console.ReadKey();
        }
    }
}
