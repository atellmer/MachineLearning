using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Store
    {
        private static int[] _architecture;
        private static int _amountSignals;
        private static int _amountClasses;
        private static double _alfaFactor = 1;
        private static Random _random = new Random();

        public static int[] GetArchitecture()
        {
            return _architecture;
        }
        public static void SetArchitecture(int[] value)
        {
            _architecture = value;
        }
        public static int GetAmountLayers()
        {
            return _architecture.GetLength(0);
        }
        public static int GetAmountNeuronsInLayer(int indexLayer)
        {
            return _architecture[indexLayer];
        }
        public static int GetAmountNeuronsInLastLayer()
        {
            return _architecture[_architecture.GetLength(0) - 1];
        }
        public static int GetAmountSignals()
        {
            return _amountSignals;
        }
        public static void SetAmountSignals(int value)
        {
            _amountSignals = value;
        }
        public static int GetAmountClasses()
        {
            return _amountClasses;
        }
        public static void SetAmountClasses(int value)
        {
            _amountClasses = value;
        }
        public static double GetAlfaFactor()
        {
            return _alfaFactor;
        }
        public static void SetAlfaFactor(double value)
        {
            _alfaFactor = value;
        }
        public static Random GetRandom()
        {
            return _random;
        }
    }
}
