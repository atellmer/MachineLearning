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
            int[] architecture = new int[] { 3 };
            int amountClasses = 2;
            double alfaFactor = 1;

            Console.BufferHeight = 10000;
            string rootDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            string fullPathToSamples = new Uri(Path.Combine(rootDir, fileNameOfTrainingSamples)).LocalPath;
            double[,] patterns = null;
            double[,] answers = null;
            Samples samples = new Samples();

            if (samples.GetData(fullPathToSamples))
            {
                patterns = Samples.ConvertToDouble(samples.GetPatterns());
                answers = Samples.ConvertToDouble(samples.GetAnswers());

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
