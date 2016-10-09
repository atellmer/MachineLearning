using System;
using System.IO;
using System.Reflection;
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
            string fileNameOfTrainingSamples = @"samples\training_samples.csv";
            int[] architecture = new int[] { 4, 3, 2 };
            int amountClasses = 2;
            double alfaFactor = 1;

            Console.BufferHeight = 10000;
            string rootDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            string fullPathToSamples = new Uri(Path.Combine(rootDir, fileNameOfTrainingSamples)).LocalPath;

            if (Samples.IsExist(fullPathToSamples))
            {
                if (Samples.GetPatterns(fullPathToSamples) != null && Samples.GetAnswers(fullPathToSamples) != null)
                {
                    double[,] patterns = Samples.ConvertToDouble(Samples.GetPatterns(fullPathToSamples));
                    double[,] answers = Samples.ConvertToDouble(Samples.GetAnswers(fullPathToSamples));

                    Store.SetArchitecture(architecture);
                    Store.SetAmountSignals(patterns.GetLength(1));
                    Store.SetAmountClasses(amountClasses);
                    Store.SetAlfaFactor(alfaFactor);

                    Network network = new Network(patterns, answers);
                    network.Init();
                }
            } else {
                Console.WriteLine("Check your path to file!");
            }


            Console.ReadKey();
        }
    }
}
