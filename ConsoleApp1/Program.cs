using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        //*프로그램 실행이 시작되는 곳
        static void Main(string[] args)
        {
            /* Console.WriteLine("숫자를 입력하세요:");

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
                 */

            string folderpath = "C:/Users/daehwan/Desktop/lsm개새";

            DirectoryInfo di = new DirectoryInfo(folderpath);

            if (di.Exists)
            {
                Console.WriteLine("폴더가 이미 존재합니다.");

            }
            else
            {
                di.Create();
               
            }

            string filepath = "C:/Users/daehwan/Desktop/lsm개새/정경창개새.txt";
            Console.WriteLine("입력할 내용 :");

            string textValue = Console.ReadLine();
            System.IO.File.WriteAllText(filepath, textValue, Encoding.Default);


            StreamWriter ndi = new StreamWriter("C:/Users/daehwan/Desktop/lsm개새/정경창개새.txt");
            ndi.Write("오홍석_개새");
            ndi.Close();

            string con = File.ReadAllText(@"C:/Users/daehwan/Desktop/lsm개새/정경창개새.txt");
            Console.Write("변경후:");
            Console.WriteLine(con);



            string[] lsmtask = con.Split('_');
            Console.WriteLine(lsmtask[0]);
            Console.WriteLine(lsmtask[1]);

           
        }
    }
   
}
