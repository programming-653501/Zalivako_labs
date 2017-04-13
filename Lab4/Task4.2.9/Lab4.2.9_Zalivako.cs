using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab4._2._9_Zalivako
{
    class Program
    {
        static void Main(string[] args)
        {

            Fileskan fs = new Fileskan(@"C: \Users\andrew\Documents\Visual Studio 2015\Projects\Lab4.1.9_Zalivako\Lab4.2.9_Zalivako\Voc.txt");
            Console.WriteLine(fs.Search());
            Console.ReadKey();
        }
    }
}
