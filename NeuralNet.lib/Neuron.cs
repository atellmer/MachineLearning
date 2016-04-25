using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public interface INeuron
    {
        double GetSensor(int x);
        void SetSensor(int x, double value);

        double GetSynapse(int x);
        void SetSynapse(int x, double value);

        double GetCore();
        void SetCore();
       
        double GetAxon();

        double GetAmountSynapses();
    }

    public class Neuron : INeuron
    {
        private double[] _sensors;
        private double[] _synapses;
        private double _core;
        private double _axon;  


        public Neuron(int amountSignals)
        {
            this._sensors = new double[amountSignals];
            this._synapses = new double[amountSignals];
            this._core = 0; 
            this._axon = 0;
            
            for (int i = 0; i < this._synapses.GetLength(0); i++)
            {
                this._synapses[i] = getRandom(Store.GetRandom());
            }
        }

        public double GetSensor(int x)
        {
            return _sensors[x];
        }
        public void SetSensor(int x, double value)
        {
            _sensors[x] = value;
        }

        public double GetSynapse(int x)
        {
            return _synapses[x];
        }
        public void SetSynapse(int x, double value)
        {
            _synapses[x] = value;
        }

        public double GetCore()
        {
            return _core;
        }
        public void SetCore()
        {
            for (int i = 0; i < _synapses.GetLength(0); i++)
            {
                _core += _sensors[i] * _synapses[i];
            }
            _axon = ActivationFunction.Sigmoid(_core);
        }

        public double GetAxon()
        {
            return _axon;
        }

        public double GetAmountSynapses()
        {
            return _synapses.GetLength(0);
        }

        private double getRandom(Random random)
        {
            return random.Next(-50, 50) * 0.01 + random.NextDouble() * 0.01;
        }
    }
}
