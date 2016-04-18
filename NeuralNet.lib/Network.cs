using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public interface INetwork
    {
        void Init();
    }
    public class Network : INetwork
    {
        private Layer[] _layer;
        private double[,] _patterns;
        private double[,] _answers;
        private Random _rand;


        public Network(double[,] patterns, double[,] answers)
        {
            this._layer = new Layer[Store.GetAmountLayers()];
            this._patterns = patterns;
            this._answers = answers;
            this._rand = new Random();
        }


        public void Init()
        {
            CreateNetwork();
            LearningNetwork();
            TestingNetwork();
        }

        private void CreateNetwork()
        {
            Console.WriteLine("1. Create Network...");
            Console.WriteLine(new string('-', 30));

            Initializer.NormalizeData(_patterns);

            for (int k = 0; k < _layer.GetLength(0); k++)
            {
                _layer[k] = new Layer();

                Initializer.RandomizeSynapses(_layer[k], k, _rand);

                Console.WriteLine("Initialization layer #{0}", k + 1);
            }
        }

        private void LearningNetwork()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("2. Learning Network...");
        }

        private void TestingNetwork()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("3. Testing Network...");
        }
    }
}
