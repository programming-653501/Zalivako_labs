﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4._1._9_Zalivako
{
    class RPN
    {
        static public double Calculate(string input)
        {
            double result=0;
           
                string output = GetExpression(input); 
                result = Counting(output); 
                
            
            return result; 
        }



        static private string GetExpression(string input)
        {
            string output = string.Empty;
            Stack<char> operStack = new Stack<char>(); 

            for (int i = 0; i < input.Length; i++) 
            {
                
                if (IsDelimeter(input[i]))
                    continue; 

               
                if (Char.IsDigit(input[i])) 
                {
                   
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i]; 
                        i++;

                        if (i == input.Length) break; 
                    }

                    output += " "; 
                    i--; 
                }

                
                if (IsOperator(input[i])) 
                {
                    {
                        if (operStack.Count > 0) 
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek()))

                        operStack.Push(char.Parse(input[i].ToString())); 

                    }
                }
            }

            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return output; 
        }

     
        static private double Counting(string input)
        {
            double result = 0; 
            Stack<double> temp = new Stack<double>();

            for (int i = 0; i < input.Length; i++) 
            {
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i])) 
                    {
                        a += input[i]; 
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a)); 
                    i--;
                }
                else if (IsOperator(input[i])) 
                {
                    
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (input[i]) 
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                    }
                    temp.Push(result); 
                }
            }
            return temp.Peek(); 
        }

        static private bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }
        static private bool IsOperator(char с)
        {
            if (("+-/*".IndexOf(с) != -1))
                return true;
            return false;
        }
        static private byte GetPriority(char s)
        {
            switch (s)
            {
                case '+': return 0;
                case '-': return 1;
                case '*': return 2;
                case '/': return 3;
                default: return 4;
            }
        }
    }
}
