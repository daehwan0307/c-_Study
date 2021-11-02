using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        //프로그램 실행이 시작되는 곳
        static void Main(string[] args)
        {
            Console.WriteLine("숫자를 입력하세요:");

            string input = Console.ReadLine();

            int number = Int32.Parse(input);

            if (number < 0)
                Console.WriteLine("음수이며,");
            else if (number > 0)
                Console.WriteLine("양수이며,");
            else
                Console.WriteLine("0");

            if (number % 2 == 0)
                Console.WriteLine("짝수이다.");
            else
                Console.WriteLine("홀수이다.");
        }
    }
}
