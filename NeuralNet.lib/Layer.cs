using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public interface ILayer
    {
        double GetAxonInNeuron(int x);
        double GetCoreInNeuron(int x);
        void SetCoreInNeuron(int x);
        double GetSynapseInNeuron(int x, int y);
        void SetSynapseInNeuron(int x, int y, double value);
        double GetSensorInNeuron(int x, int y);
        void SetSensorInNeuron(int x, int y, double value);
        double GetAmountSynapsesInNeuron(int x);
        int GetAmountNeurons();
    }

    public class Layer : ILayer
    {
        private Neuron[] _neurons;

        public Layer(int indexLayer)
        {
            this._neurons = new Neuron[Store.GetAmountNeuronsInLayer(indexLayer)];

            for (int i = 0; i < this._neurons.GetLength(0); i++)
            {
                if (indexLayer == 0)
                {
                    this._neurons[i] = new Neuron(Store.GetAmountSignals());
                }
                else
                {
                    this._neurons[i] = new Neuron(Store.GetAmountNeuronsInLayer(indexLayer - 1));
                }
                
            }
        }
        public int GetAmountNeurons()
        {
            return _neurons.GetLength(0);
        }
        public double GetAxonInNeuron(int x)
        {
            return _neurons[x].GetAxon();
        }
        public double GetCoreInNeuron(int x)
        {
            return _neurons[x].GetCore();
        }
        public void SetCoreInNeuron(int x)
        {
            _neurons[x].SetCore();
        }
        public double GetSynapseInNeuron(int x, int y)
        {
            return _neurons[x].GetSynapse(y);
        }
        public void SetSynapseInNeuron(int x, int y, double value)
        {
            _neurons[x].SetSynapse(y, value);
        }
        public double GetSensorInNeuron(int x, int y)
        {
            return _neurons[x].GetSensor(y);
        }
        public void SetSensorInNeuron(int x, int y, double value)
        {
            _neurons[x].SetSensor(y, value);
        }
        public double GetAmountSynapsesInNeuron(int x)
        {
            return _neurons[x].GetAmountSynapses();
        }
    }
}
