using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public static class Function
    {
        public static double Sigmoid(double value)
        {
            return 1 / (1 + Math.Exp(-1 * Store.GetAlfaFactor() * value));
        }

        public static double SigmoidDerivative(double value)
        {
            return Store.GetAlfaFactor() * value * (1 - (Store.GetAlfaFactor() * value));
        }
    }
}
