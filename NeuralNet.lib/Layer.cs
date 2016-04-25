using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public interface ILayer
    {
        double GetCore(int x);
        void SetCore(int x, double value);
        double GetSynapse(int x, int y);
        void SetSynapse(int x, int y, double value);
    }

    public class Layer : ILayer
    {
        private Neuron[] _neurons;

        public Layer(int indexLayer)
        {
            this._neurons = new Neuron[Store.GetArchitecture()[indexLayer]];

            for (int i = 0; i < this._neurons.GetLength(0); i++)
            {
                this._neurons[i] = new Neuron(Store.GetAmountSignals());
            }
        }

        public double GetCore(int x)
        {
            return _neurons[x].GetCore();
        }
        public void SetCore(int x, double value)
        {
            _neurons[x].SetCore(value);
        }
        public double GetSynapse(int x, int y)
        {
            return _neurons[x].GetSynapse(y);
        }
        public void SetSynapse(int x, int y, double value)
        {
            _neurons[x].SetSynapse(y, value);
        }
    }
}
