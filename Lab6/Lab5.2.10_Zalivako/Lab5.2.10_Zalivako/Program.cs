using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5._2._10_Zalivako
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            for(;;)
            {
                string word = Console.ReadLine();
                if (word == "end")
                    break;
                try
                {
                    tree.Insert(word);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }

            Console.WriteLine("\n\n\n");

            try
            {
                tree.Display(tree);
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("Пустое дерево");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}
