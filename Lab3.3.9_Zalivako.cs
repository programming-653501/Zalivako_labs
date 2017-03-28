using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Zalivako_3_2_9
{
    class Program
    {
       
        static void Main(string[] args)
        {

            int m1, n1, m2, n2, i, j, q, w, c=0;
            bool flag = false;

            for (;;)
            {
                Console.WriteLine("Enter the first matrix(k)");

                Console.WriteLine("Enter m1: ");
                m1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter n1: ");
                n1 = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine("Enter the second matrix(l) (m1>m2)(n1>n2)");

                Console.WriteLine("Enter m2: ");
                m2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter n2: ");
                n2 = Convert.ToInt32(Console.ReadLine());

                if ((m2 < m1) && (n2 < n1)) { break; }
                else Console.WriteLine("Wrong matrix");
            }

            int[,] k = new int[m1, n1];
            int[,] l = new int[m2, n2];
            int[,] l180 = new int[m2, n2];
            int[,] l90right = new int[n2, m2];
            int[,] l90left = new int[n2, m2];

            

            Console.WriteLine("Enter numbers (0,1) of the first matrix(k) " + m1 + " x " + n1 );

            for ( i = 0 ; i < m1; i++)
            {
                for (j = 0; j < n1; j++)
                {
                    Console.Write("k[" + i + "][" + j + "]= ");
                    k[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("Enter numbers (0,1) of the second matrix(l) " + m2 + " x " + n2);

            for (i = 0; i < m2; i++)
            {
                for (j = 0; j < n2; j++)
                {
                    Console.Write("l[" + i + "][" + j + "]= ");
                    l[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            //l180
            i = m2 - 1;
            j = n2 - 1;
            q = 0;
            while (i >= 0)
            {
                w = 0;
                j = n2 - 1;
                while (j >= 0)
                {
                    l180[q, w] = l[i, j];
                    w++;
                    j--;
                }
                q++;
                i--;
            }

            if ((n2 <= m1) && (n1 >= m2))
            {
                //l90right
                j = 0;
                i = 0;
                while (j < n2)
                {
                    w = 0;
                    i = m2 - 1;
                    while (i >= 0)
                    {
                        l90right[j, w] = l[i, j];
                        w++;
                        i--;
                    }
                    j++;
                }
                //
            }

            if ((n2 <= m1) && (n1 >= m2))
            {
                //l90left
                i = n2 - 1;
                q = 0;
                while (i >= 0)
                {
                    w = 0;
                    j = m2 - 1;
                    while (j >= 0)
                    {

                        l90left[q, w] = l90right[i, j];
                        w++;
                        j--;
                    }
                    q++;
                    i--;
                }
                //
            }    

            //ordinary matrix
                for (q = 0; q <= m1-m2; q++)
                {
                    for (w = 0; w <= n1-n2; w++)
                    {
                        c = 0;

                        for (i = 0; i < m2; i++)
                        {
                            for (j = 0; j < n2; j++)
                            {
                                if (k[i+q,j+w] + l[i,j] == 1) { c++; }

                                if (c == m2 * n2) { c = 0; flag = true; }
                            } 
                        }
                    }              
               }

            //l180 matrix
            for (q = 0; q <= m1 - m2; q++)
            {
                for (w = 0; w <= n1 - n2; w++)
                {
                    c = 0;

                    for (i = 0; i < m2; i++)
                    {
                        for (j = 0; j < n2; j++)
                        {
                            if (k[i + q, j + w] + l180[i, j] == 1) { c++; }

                            if (c == m2 * n2) { c = 0; flag = true; }
                        }
                    }
                }
            }

            if ((n2 <= m1) && (n1 >= m2))
            {
                //l90right matrix
                for (q = 0; q <= m1 - n2; q++)
                {
                    for (w = 0; w <= n1 - m2; w++)
                    {
                        c = 0;

                        for (i = 0; i < n2; i++)
                        {
                            for (j = 0; j < m2; j++)
                            {
                                if (k[i + q, j + w] + l90right[i, j] == 1) { c++; }

                                if (c == m2 * n2) { c = 0; flag = true; }
                            }
                        }
                    }
                }
                //
            }
            
            if ((n2 <= m1) && (n1 >= m2))
            {
                //90left matrix
                for (q = 0; q <= m1 - n2; q++)
                {
                    for (w = 0; w <= n1 - m2; w++)
                    {
                        c = 0;

                        for (i = 0; i < n2; i++)
                        {
                            for (j = 0; j < m2; j++)
                            {
                                if (k[i + q, j + w] + l90left[i, j] == 1) { c++; }

                                if (c == m2 * n2) { c = 0; flag = true; }
                            }
                        }
                    }
                }
                //
            }

            Console.WriteLine();

            if (flag)
            {
                Console.WriteLine("You can open the lock");
            }
            else Console.WriteLine("You can't open the lock");

            Console.WriteLine();

            Console.WriteLine("Matrix(k) " + m1 + " x " + n1);

            for (i = 0; i < m1; i++)
            {
                for (j = 0; j < n1; j++)
                {
                    Console.Write(k[i, j] + " ");
                }

                Console.WriteLine();

            }

            Console.WriteLine("Matrix(l) " + m2 + " x " + n2);

            for (i = 0; i < m2; i++)
            {
                for (j = 0; j < n2; j++)
                {
                    Console.Write(l[i, j] + " ");
                }

                Console.WriteLine();

            }

            Console.ReadKey();
        }
    }
}
