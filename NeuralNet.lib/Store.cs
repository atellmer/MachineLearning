using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Store
    {
        private static int _amountLayers;
        private static int _amountSignals;
        private static int _amountNeurons;
        private static double _alfaFactor = 1;

        public static int GetAmountLayers()
        {
            return _amountLayers;
        }
        public static void SetAmountLayers(int value)
        {
            _amountLayers = value;
        }
        public static int GetAmountSignals()
        {
            return _amountSignals;
        }
        public static void SetAmountSignals(int value)
        {
            _amountSignals = value;
        }
        public static int GetAmountNeurons()
        {
            return _amountNeurons;
        }
        public static void SetAmountNeurons(int value)
        {
            _amountNeurons = value;
        }
        public static double GetAlfaFactor()
        {
            return _alfaFactor;
        }
        public static void SetAlfaFactor(double value)
        {
            _alfaFactor = value;
        }
    }
}
