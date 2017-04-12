using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4._1._9_Zalivako
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the arithmetic expression: ");
            string expression = Console.ReadLine();

            int strLen = expression.Length;
            int[] mas = new int[strLen];
            int counter=0,i,k = 0;
            bool flag=true;

            for (i = 0; i < strLen; i++)
            {
                if (expression[i] >= '0' && expression[i] <= '9')
                    counter++;
                switch (expression[i])
                {
                    case '+': counter++; break;
                    case '-': counter++; break;
                    case '/': counter++; break;
                    case '*': counter++; break;
                }
            }
            if (counter != strLen) flag = false;

            for (i = 0; i < strLen; i++)
            {
                if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/')
                {
                    mas[k] = i;
                    k++;
                   // int number = Convert.ToInt32(expression[i]);

                }
            }

            for (i = 0; i < k-1; i++)
            {
                if (mas[i + 1] - mas[i] == 1 || expression[mas[i]+1]=='0') flag = false;
            }

            if ( mas[0] == 0 || mas[k - 1] == strLen - 1 || expression[mas[0] + 1] == '0') flag = false;

            if (flag)
            {
                Console.WriteLine("Correct expression");
                Console.WriteLine(RPN.Calculate(expression));
            }

            else
            {
                Console.WriteLine("Wrong expression");
            }


            Console.ReadKey();
        }
    }
}
