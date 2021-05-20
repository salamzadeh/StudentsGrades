using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory+"students.txt");
            string[][] studens = new string[100][];
            for (int i = 0; i < 100; i++)
            {
                studens[i] = new string[4];
            }
            int st_count = 0;
            foreach (string line in lines)
            {
                int last_index,current = 0;
                studens[st_count][0] = line.Substring(0,7);
                current = 8;
                last_index = line.IndexOf(",", current);
                studens[st_count][1] = line.Substring(current, last_index-current);
                current = last_index + 1;
                last_index = line.IndexOf(",", last_index+1);
                studens[st_count][2] = line.Substring(current, last_index - current);
                current = last_index + 1;
                studens[st_count][3] = line.Substring(current);
                st_count++;
            }
            int page_numbers =0,current_page= 0;
            if (st_count > 25)
                page_numbers = st_count / 25;
            studens = show(studens,st_count);
            while(true)
            {
                Console.WriteLine("#row\tStudent Code\tFirst Name\t\tLastName\t\tGrade");
                Console.WriteLine("----------------------------------------------------------------------------------------");
                int z = 0;
                for (int j = (current_page*25); j <st_count; j++)
                {
                    Console.WriteLine("#"+(z+1) + "\t"+studens[j][0] + "\t\t" + studens[j][1] + "\t\t\t" + studens[j][2] + "\t\t\t" + studens[j][3]);
                    z++;
                    if (z== 25)
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Press q key to exit. n key to next page and p key to previous page");

                ConsoleKeyInfo x = System.Console.ReadKey();
                if(x.KeyChar == 'q')
                {
                    break;
                }
                else if(x.KeyChar == 'n')
                {
                    if (current_page < page_numbers)
                        current_page++;
                }
                else if(x.KeyChar == 'p')
                {
                    if (current_page >0)
                        current_page--;

                }
                Console.Clear();
            }


            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
        }
        private static void Sort<T>(T[][] data, int col)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            Array.Sort<T[]>(data, (x, y) => comparer.Compare(x[col], y[col]));
        } 


        public static string[][] show(string[][] x,int count)
        {
            Sort<string>(x, 1);
            Sort<string>(x, 2);
            string[][] y = new string[100][];
            for (int i = 0; i < count; i++)
            {
                y[i] = x[100 + i - count];
            }
            return y;
        }
    }
}
