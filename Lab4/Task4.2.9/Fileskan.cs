using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab4._2._9_Zalivako

{

    class Fileskan
    {
        private System.IO.StreamReader file;
        public List<string> Slovar = new List<string>();
        string lite = "";
        public Fileskan(string path)
        {

            file = new System.IO.StreamReader(path);
            while ((lite = file.ReadLine()) != null)
            {
                Slovar.Add(lite);
            }
        }


        public string Search()
        {
            string str = "";
            for (int i = 0; i < Slovar.Count; i++)
            {
                char[] a = Slovar[i].ToCharArray();
                str += "( ";
                for (int j = 0; j < Slovar.Count; j++)
                {

                    char[] b = Slovar[j].ToCharArray();
                    if (Ravno(a, b) == true)
                    {

                        str += Slovar[j] + " ";
                        Slovar.RemoveAt(j);

                    }

                }
                str += ")\n\r";

            }
            return str;
        }


        private bool Ravno(char[] a, char[] b)
        {
            List<char> a_list = new List<char>();
            List<char> b_list = new List<char>();
            if (a.Length == b.Length)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    string ra = (a[i] + "").ToUpper();
                    a_list.Add(Convert.ToChar(ra));
                    string rb = (b[i] + "").ToUpper();
                    b_list.Add(Convert.ToChar(rb));
                }
                a_list.Sort();
                b_list.Sort();

                for (int i = 0; i < a_list.Count; i++)
                {
                    if (a_list[i] != b_list[i])
                    {
                        return false;
                        break;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
