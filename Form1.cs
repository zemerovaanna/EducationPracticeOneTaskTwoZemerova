using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyasShop
{
    public partial class Form1 :Form
    {
        Shop pyaterochka;
        int price;
        int CountCola;
        int CountJuice;
        public Form1 ()
        {
            CountCola = 200;
            CountJuice = 50;
            InitializeComponent( );
            price = 0;
            Product cola = new Product("Кола", 85);
            Product juice = new Product("Сок \"Добрый\"", 100);
            label2.Text = cola.GetInfo( );
            label5.Text = juice.GetInfo( );

            pyaterochka = new Shop( );
            pyaterochka.CreateProduct("Кола", 85, CountCola);
            pyaterochka.CreateProduct("Сок \"Добрый\"", 100, CountJuice);
            pyaterochka.WriteAllProducts(listBox1);
        }

        static bool CheckText(string txt)
        {
            bool IsThisGoodTxt = true;
            foreach(char t in txt)
            {
                if(!char.IsDigit(t))
                {
                    IsThisGoodTxt = false;
                    break;
                }
            }
            return IsThisGoodTxt;
        }

        private void button1_Click (object sender, EventArgs e)
        {
            if (numericUpDown1.Value > CountCola || numericUpDown2.Value > CountJuice)
            {
                MessageBox.Show("Превышено количество товара!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (checkBox1.Checked == true && numericUpDown1.Value != 0)
                {
                    pyaterochka.Sell("Кола", Convert.ToInt32(numericUpDown1.Value));
                    CountCola = CountCola - Convert.ToInt32(numericUpDown1.Value);
                    pyaterochka.WriteAllProducts(listBox1);
                    price = price + 85;
                    label6.Text = Convert.ToString(price);
                }

                if (checkBox2.Checked == true && numericUpDown2.Value != 0)
                {
                    pyaterochka.Sell("Сок \"Добрый\"", Convert.ToInt32(numericUpDown2.Value));
                    CountJuice = CountJuice - Convert.ToInt32(numericUpDown2.Value);
                    pyaterochka.WriteAllProducts(listBox1);
                    price = price + 100;
                    label6.Text = Convert.ToString(price);
                }
            }
        }
    }
}
