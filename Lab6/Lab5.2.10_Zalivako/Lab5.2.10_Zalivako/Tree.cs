using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5._2._10_Zalivako
{
    class Tree
    {
        private string value;
        private Tree left;
        private Tree right;

        // вставка
        public void Insert(string value)
        {
            if (this.value == null)
                this.value = value;
            else
            {
                if (this.value.CompareTo(value) == 1)
                {
                    if (left == null)
                        this.left = new Tree();
                    left.Insert(value);
                }
                else if (this.value.CompareTo(value) == -1)
                {
                    if (right == null)
                        this.right = new Tree();
                    right.Insert(value);
                }
                else
                    throw new Exception("Узел уже существует");
            }

        }

        public void Display(Tree tree)
        {
            if (tree != null)
            {
                Display(tree.left); //Инфиксный обход.

                string RevVal = "";
                for(int i = tree.value.Length - 1; i >= 0; i--)
                {
                    RevVal += tree.value[i];
                }
                if (tree.value == RevVal)
                {
                    Console.WriteLine(tree.value);
                }

                Display(tree.right);
            }
        }
    }
    }
