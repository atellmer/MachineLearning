using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Trainer
    {
        private Layer[] _layers;
        private Outer _outer;
        private double[,] _patterns;
        private double[,] _answers;

        public Trainer(Layer[] layers, Outer outer, double[,] patterns, double[,] answers)
        {
            this._layers = layers;
            this._outer = outer;
            this._patterns = patterns;
            this._answers = answers;
        }

        public void StartLearning()
        {
           for (int i = 0; i < _patterns.GetLength(0); i++)
            {
                for (int layerIdx = 0; layerIdx < _layers.GetLength(0); layerIdx++)
                {
                    for (int neuronIdx = 0; neuronIdx < _layers[layerIdx].GetAmountNeurons(); neuronIdx++)
                    {
                        for (int synapseIdx = 0; synapseIdx < _layers[layerIdx].GetAmountSynapsesInNeuron(neuronIdx); synapseIdx++)
                        {
                            if (layerIdx == 0)
                            {
                                _layers[layerIdx].SetSensorInNeuron(neuronIdx, synapseIdx, _patterns[i, synapseIdx]);
                            }
                            else
                            {
                                _layers[layerIdx].SetSensorInNeuron(neuronIdx, synapseIdx, _layers[layerIdx - 1].GetAxonInNeuron(synapseIdx));
                            }
                        }
                        _layers[layerIdx].SetCoreInNeuron(neuronIdx);
                    }
                }
            }      
        }   
    }
}
