using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AND.Class;
namespace AND
{
    public partial class Form1 : Form
    {
        List<Local> Locals = new List<Local>();
        List<Local> Nodes = new List<Local>();

        public Form1()
        {
            InitializeComponent();
            List<Local> tmp = new List<Local>();
            tmp.Add(new Local
            {
                Type = "Отель",
                Address = "Долгобродского 21",
                Name = "Гранада",
                Close = new DateTime(1999, 1, 1, 22, 0, 0),
                Open = new DateTime(1999, 1, 1, 8, 0, 0),
                Description = "Отель",
               
            });
            tmp.Add(new Local
            {
                Type = "Кино",
                Address = "Независимости 12",
                Name = "Октябрь",
                Close = new DateTime(1999, 1, 1, 22, 0, 0),
                Open = new DateTime(1999, 1, 1, 8, 0, 0),
                Description = "Кинотеатр",

            });
            Cities.Dictionary_Cities.Add("Минск",tmp);
            Cities.Keys.Add("Минск");
            list_City.Items.Add("Минск");
            Cities.Node.Add("Минск",new List<Local>());
            ////////////////////////////////////////////////
            tmp.Add(new Local
            {
                Type = "Отель",
                Address = "Центральная 76",
                Name = "Элеон",
                Close = new DateTime(1999, 1, 1, 0, 0, 0),
                Open = new DateTime(1999, 1, 1, 0, 0, 0),
                Description = "Отель 5 звезд",

            });
            tmp.Add(new Local
            {
                Type = "Кино",
                Address = "Лазурная 6",
                Name = "Эйфель",
                Close = new DateTime(1999, 1, 1, 23, 0, 0),
                Open = new DateTime(1999, 1, 1, 10, 0, 0),
                Description = "Кинотеатр с просмотром 3D",

            });
            Cities.Dictionary_Cities.Add("Париж", tmp);
            Cities.Keys.Add("Париж");
            list_City.Items.Add("Париж");
            Cities.Node.Add("Париж", new List<Local>());
        }


        private void Filtered (string type)
        {
            
            list_local.Items.Clear();
            List<Local> result = new List<Local>();
            List<Local> local_temp = Cities.Dictionary_Cities[list_City.SelectedItem.ToString()];
            
            for (int index = 0; index < local_temp.Count; index++)
            {
                if (type != "все")
                {
                    if (type == local_temp[index].Type)
                    {
                        list_local.Items.Add(local_temp[index].Name);
                        Locals.Add(local_temp[index]);
                    }
                }else
                {
                    list_local.Items.Add(local_temp[index].Name);
                    Locals.Add(local_temp[index]);
                }
            }
           
        }

        private void Filtered_node(string type)
        {

            list_node_local.Items.Clear();
           
            List<Local> local_temp = Cities.Node[list_City.SelectedItem.ToString()];

            for (int index = 0; index < local_temp.Count; index++)
            {
                if (type != "все")
                {
                    if (type == local_temp[index].Type)
                    {
                        list_node_local.Items.Add(local_temp[index].Name);
                        Nodes.Add(local_temp[index]);
                    }
                }
                else
                {
                    list_node_local.Items.Add(local_temp[index].Name);
                    Nodes.Add(local_temp[index]);
                }
            }

        }


        private void list_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtered("все");
            Filtered_node("все");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Filtered("Отель");
            Filtered_node("Отель");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Filtered("Кино");
            Filtered_node("Кино");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Filtered("Еда");
            Filtered_node("Еда");
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Filtered("все");
            Filtered_node("все");
        }

        private void list_local_SelectedIndexChanged(object sender, EventArgs e)
        {
            tx_Type.Text = Locals[list_local.SelectedIndex].Type;
            tb_Name.Text = Locals[list_local.SelectedIndex].Name;
            tb_Address.Text = Locals[list_local.SelectedIndex].Address;
            tb_Open.Text = Locals[list_local.SelectedIndex].Open.Hour.ToString();
            tb_Close.Text = Locals[list_local.SelectedIndex].Close.Hour.ToString();
            tb_Description.Text = Locals[list_local.SelectedIndex].Description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (list_City.SelectedItem != null)
            {
                List<Local> temp = Cities.Dictionary_Cities[list_City.SelectedItem.ToString()];
                Cities.Node[list_City.SelectedItem.ToString()].Add(temp[list_local.SelectedIndex]);
            }
        }

        private void list_node_local_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Type_2.Text = Nodes[list_node_local.SelectedIndex].Type;
            tb_Name_2.Text = Nodes[list_node_local.SelectedIndex].Name;
            tb_Address_2.Text = Nodes[list_node_local.SelectedIndex].Address;
            tb_Open_2.Text = Nodes[list_node_local.SelectedIndex].Open.Hour.ToString();
            tb_Close_2.Text = Nodes[list_node_local.SelectedIndex].Close.Hour.ToString();
            tb_description_2.Text = Nodes[list_node_local.SelectedIndex].Description;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Local> tmp = new List<Local>();
            Local local_hot = new Local();
            int min = 0;
            for(int i = 0; Cities.Keys.Count > i; i++)
            {
                for(int j= 0; j < Cities.Dictionary_Cities[Cities.Keys[i]].Count; j++)
                {
                    
                    tmp = Cities.Dictionary_Cities[Cities.Keys[i]];
                    if (tmp[i].Type == "Отель")
                    {
                        int a = Convert.ToInt32(tmp[i].Close.Hour) - Convert.ToInt32(tmp[i].Open.Hour);
                        if (a > min || a==0)
                        {
                            min = Convert.ToInt32(tmp[i].Close.Hour) - Convert.ToInt32(tmp[i].Open.Hour);
                            local_hot = tmp[i];
                        }
                    }
                }
            }
            MessageBox.Show(local_hot.Address);
        }
    }
}
