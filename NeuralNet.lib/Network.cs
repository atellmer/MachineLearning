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
        private Layer[] _layers;
        private Outer _outer;
        private double[,] _patterns;
        private double[,] _answers;


        public Network(double[,] patterns, double[,] answers)
        {
            this._layers = new Layer[Store.GetAmountLayers()];
            this._outer = new Outer();
            this._patterns = patterns;
            this._answers = answers;
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

            Data.Normalize(_patterns);

            for (int k = 0; k < _layers.GetLength(0); k++)
            {
                _layers[k] = new Layer(k);

                Console.WriteLine("Initialization layer #{0}", k + 1);
            }
        }

        private void LearningNetwork()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("2. Learning Network...");

            Trainer _trainer = new Trainer(this._layers, this._outer, this._patterns, this._answers);
            _trainer.StartLearning();
        }

        private void TestingNetwork()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("3. Testing Network...");
        }
    }
}
