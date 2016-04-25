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
        private static double _alfaFactor = 1;

        public static int[] GetArchitecture()
        {
            return _architecture;
        }
        public static void SetArchitecture(int[] value)
        {
            _architecture = value;
        }
        public static int GetAmountSignals()
        {
            return _amountSignals;
        }
        public static void SetAmountSignals(int value)
        {
            _amountSignals = value;
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
