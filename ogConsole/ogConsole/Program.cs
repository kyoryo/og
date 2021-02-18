using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ogConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Soal from https://github.com/Opsigo/ops-test-banks/blob/main/common/programming.md");

            Console.Write("Pilih soal (1 or 2): ");
            int soalChoice = Convert.ToInt32(Console.ReadLine());
            if (soalChoice == 1)
            {
                Console.Write("Enter value for soal 1: ");
                string soal1Input = Console.ReadLine();
                Soal1.Do(soal1Input);
            }
            else if (soalChoice == 2)
            {
                Console.Write("Enter value for soal 2: ");
                int soal2Input = Convert.ToInt32(Console.ReadLine());
                Soal2.Do(soal2Input);
            }
            else
                return;

            
        }
    }
}
