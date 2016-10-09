using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Trainer
    {
        private Layer[] _layer;
        private Outer _outer;
        private double[,] _patterns;
        private double[,] _answers;

        public Trainer(Layer[] layer, Outer outer, double[,] patterns, double[,] answers)
        {
            this._layer = layer;
            this._outer = outer;
            this._patterns = patterns;
            this._answers = answers;
        }

        public void StartLearning()
        {

        }
       
    }
}
