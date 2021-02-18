using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Text.RegularExpressions;

namespace ogConsole
{
    class Soal1
    {
        public static void Do(string input)
        {
            //input = "akucintakamu1";
            if (input.Length < 1 || input.Length > 1000 || !Regex.IsMatch(input, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine("Tidak Sesuai kriteria");
                return;
            }

            var length = input.Length;
            var leastMaxLength = DetermineLML(length);
            var rootLeastMaxLength = Convert.ToInt32(Math.Sqrt(leastMaxLength));
            if (length < leastMaxLength)
                for (int i = 0; i < leastMaxLength-length; i++)
                    input += "*";
            char[,] mDimArr = CreateArrayTable(rootLeastMaxLength, input);
            char[,] convertedMDimArr = ConvertArrayTable(mDimArr, rootLeastMaxLength);
            string result = CreateResult(convertedMDimArr, rootLeastMaxLength, length);

            Console.Write("Soal1 result: ");
            Console.WriteLine(result);
        }

        private static int DetermineLML(int length)
        {
            var root = Math.Sqrt(length);
            if (root % 1 != 0)
                root = Math.Floor(root) + 1;
            int newRoot = Convert.ToInt32(root);
            var newLength = Convert.ToInt32(Math.Pow(newRoot, 2));
            return newLength;
        }

        private static char[,] CreateArrayTable(int dim, string input)
        {
            char[,] mDimArr = new char[dim,dim];
            char[] charArr = input.ToCharArray();
            var count = 0;
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    mDimArr[i, j] = charArr[count];
                    count++;
                }
            }
            return mDimArr;
        }

        private static char[,] ConvertArrayTable(char[,] mDimCharArr, int dim)
        {
            char[,] convertedMDimCharArr = new char[dim, dim];
            var width = mDimCharArr.GetUpperBound(0) + 1;
            var height = mDimCharArr.GetUpperBound(1) + 1;
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    int newRow, newCol;
                    newRow = col;
                    newCol = height - (row + 1);
                    convertedMDimCharArr[newRow, newCol] = mDimCharArr[row, col];
                }
            }
            return convertedMDimCharArr;
        }

        private static string CreateResult(char[,] mDimCharArr, int dim, int length)
        {
            char[] resultArr = new char[length];
            var count = 0;
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    if (mDimCharArr[i, j] != '*')
                    {
                        resultArr[count] = mDimCharArr[i, j];
                        count++;
                    }
                }
            }
            var result = new string(resultArr);
            return result;
        }
    }
}
