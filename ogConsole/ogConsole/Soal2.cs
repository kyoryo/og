using System;
using System.Collections.Generic;
using System.Text;

namespace ogConsole
{
    internal class Soal2
    {
        public static void Do(int input)
        {
            Console.WriteLine("Soal 2");
            if (input < 0)
                return;
            var integerList = new List<int>();
            for (int i = 1; i <= input; i++)
                integerList.Add(i);

            var answer = CombSum(integerList, input);
            foreach (var part in answer)
            {
                foreach (var item in part)
                {
                    Console.Write((int) item);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        private static List<List<int>> CombSum(List<int> integerList, int sum)
        {
            var answer = new List<List<int>>();
            var temp = new List<int>();
            FindNumber(answer, integerList, sum, 0, temp);
            return answer;
        }

        private static void FindNumber(List<List<int>> answer, List<int> integerList, int targetSum, int index, List<int> temp)
        {
            if (targetSum == 0)
            {
                answer.Add(new List<int>(temp));
                return;
            }
            for (int i = index; i < integerList.Count; i++)
            {
                if ((targetSum - integerList[i] >= 0))
                {
                    temp.Add(integerList[i]);
                    FindNumber(answer, integerList, targetSum - integerList[i], i, temp);

                    temp.Remove(integerList[i]);
                }
            }
        }
    }
}
