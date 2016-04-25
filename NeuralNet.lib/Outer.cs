using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public interface IOuter
    {

    }
    public class Outer: IOuter
    {
        private Neuron[] _neurons;

        public Outer()
        { 
            this._neurons = new Neuron[Store.GetAmountClasses()];

            for (int i = 0; i < this._neurons.GetLength(0); i++)
            {
              this._neurons[i] = new Neuron(Store.GetAmountNeuronsInLastLayer());
            }
        }
    }
}
