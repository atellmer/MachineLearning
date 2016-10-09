using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileWorker
{
    public static class Samples
    {
        public static string[,] GetPatterns(string path)
        {
            string[,] patterns = null;

            if (IsExist(path))
            {
                try
                {
                    char[] delimetr = ";".ToCharArray();
                    string[] content = File.ReadAllLines(path);
                    int lengthPattern = content[0].Split(delimetr).GetLength(0) - 1;
                    string[] split = null;

                    patterns = new string[content.GetLength(0), lengthPattern];

                    for (int i = 0; i < content.GetLength(0); i++)
                    {
                        split = content[i].Split(delimetr);
                        for (int j = 0; j < split.GetLength(0) - 1; j++)
                        {
                          patterns[i, j] = split[j];    
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Error! Can not read file!");
                    Console.WriteLine(e);
                    Console.WriteLine("-----------------------------");
                }

            }

            return patterns;
        }

        public static string[,] GetAnswers(string path)
        {
            string[,] answers = null;

            if (IsExist(path))
            {
                try
                {
                    char[] delimetr = ";".ToCharArray();
                    string[] content = File.ReadAllLines(path);
                    string[] split = null;

                    answers = new string[content.GetLength(0), 1];

                    for (int i = 0; i < content.GetLength(0); i++)
                    {
                        split = content[i].Split(delimetr);
                        answers[i, 0] = split[split.GetLength(0) - 1];
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Error! Can not read file!");
                    Console.WriteLine(e);
                    Console.WriteLine("-----------------------------");
                }

            }

            return answers;
        }

        public static bool SaveData(string path, string[,] data)
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
            catch (Exception e)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Error! Can not write file!");
                Console.WriteLine(e);
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


        public static bool IsExist(string path)
        {
            return File.Exists(path);
        }
    }
}
