﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public interface ILayer
    {
        double GetCoreInNeuron(int x);
        void SetCoreInNeuron(int x);
        double GetSynapseInNeuron(int x, int y);
        void SetSynapseInNeuron(int x, int y, double value);
        double GetAmountSynapsesInNeuron(int x);
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
        public double GetAmountSynapsesInNeuron(int x)
        {
            return _neurons[x].GetAmountSynapses();
        }
    }
}
