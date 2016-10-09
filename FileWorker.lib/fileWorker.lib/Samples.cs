using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileWorker
{
    public interface ISamples
    {
        bool GetData(string path);
        bool SaveData(string path, string[,] data);
        string[,] GetPatterns();
        string[,] GetAnswers();
    }

    public class Samples : ISamples
    {
        private string[,] _patterns = null;
        private string[,] _answers = null;
        private int _length = 0;
        private int _quantity = 0;


        public bool GetData(string path)
        {
            bool success = true;

            if (IsExist(path))
            {
                try
                {
                    char[] delimetr = ";".ToCharArray();
                    string[] content = File.ReadAllLines(path);
                    string[] split = content[0].Split(delimetr);

                    _patterns = new string[content.GetLength(0), split.GetLength(0) - 1];
                    _answers = new string[content.GetLength(0), 1];
                    _length = split.GetLength(0) - 1;
                    _quantity = content.GetLength(0);

                    for (int i = 0; i < content.GetLength(0); i++)
                    {
                        split = content[i].Split(delimetr);
                        for (int j = 0; j < split.GetLength(0); j++)
                        {
                            if (j != split.GetLength(0) - 1)
                            {
                                _patterns[i, j] = split[j];
                            }
                            else
                            {
                                _answers[i, 0] = split[j];
                            }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Error! Can not read file!");
                    Console.WriteLine("-----------------------------");
                    success = false;
                }
            }
            return success;
        }

        public bool SaveData(string path, string[,] data)
        {
            bool success = true;
            string[] buffer = new string[data.GetLength(0)];

            try
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        buffer[i] += data[i, j];
                        if (j != data.GetLength(1) - 1)
                        {
                            buffer[i] += ";";
                        }
                    }
                }

                File.WriteAllLines(path, buffer);
            }
            catch
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Error! Can not write file!");
                Console.WriteLine("-----------------------------");
                success = false;
            }
            return success;
        }

        public static double[,] ConvertToDouble(string[,] dataToConvert)
        {
            double[,] data = new double[dataToConvert.GetLength(0), dataToConvert.GetLength(1)];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    data[i, j] = Convert.ToDouble(dataToConvert[i, j]);
                }
            }

            return data;
        }

        public static string[,] ConvertToString(double[,] dataToConvert)
        {
            string[,] data = new string[dataToConvert.GetLength(0), dataToConvert.GetLength(1)];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    data[i, j] = Convert.ToString(dataToConvert[i, j]);
                }
            }

            return data;
        }

        public string[,] GetPatterns()
        {
            return _patterns;
        }

        public string[,] GetAnswers()
        {
            return _answers;
        }

        private bool IsExist(string path)
        {
            return File.Exists(path);
        }
    }
}
