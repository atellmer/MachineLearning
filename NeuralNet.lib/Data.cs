﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NeuralNetwork
{
    public class Data
    {
        public static void Normalize(double[,] data)
        {
            double[] stdDev = new double[data.GetLength(0)];
            double[] average = new double[data.GetLength(0)];
            int n = data.GetLength(1);

            for (int i = 0; i < data.GetLength(0); i++)
            {
                average[i] = 0;
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    average[i] += data[i, j];
                }
                average[i] = average[i] / n;

                stdDev[i] = 0;
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    stdDev[i] += (data[i, j] - average[i]) * (data[i, j] - average[i]);
                }
                stdDev[i] = Math.Sqrt(stdDev[i] / (n - 1));

                for (int j = 0; j < data.GetLength(1); j++)
                {
                   data[i, j] = (data[i, j] - average[i]) / stdDev[i];
                   data[i, j] = (Math.Exp(data[i, j]) - Math.Exp(-1 * data[i, j])) / (Math.Exp(data[i, j]) + Math.Exp(-1 * data[i, j]));
                }
            }
        }
    }
}
