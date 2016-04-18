using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public interface INeuron
    {
        double GetCore();
        void SetCore(double value);
        double GetSynapse(int x);
        void SetSynapse(int x, double value);
    }

    public class Neuron : INeuron
    {
        private double _core;
        private double[] _synapses;


        public Neuron(int amountSignals)
        {
            this._core = 0;
            this._synapses = new double[amountSignals];
        }


        public double GetCore()
        {
            return _core;
        }
        public void SetCore(double value)
        {
            _core = value;
        }
        public double GetSynapse(int x)
        {
            return _synapses[x];
        }
        public void SetSynapse(int x, double value)
        {
            _synapses[x] = value;
        }
    }
}
