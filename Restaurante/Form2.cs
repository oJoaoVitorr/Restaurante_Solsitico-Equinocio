using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class Form2 : Form
    {
        int valorbebida = 0, valorprato = 0, valorsobre = 0, total = 0;
        string  lista = "";

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = (richTextBox5.Text) + " - " + (comboBox1.Text) + "\n\n" +lista+ "Total a pagar: " + total;/* acha um jeito de botar a quantidade de cada item ao lado na lista*/
        }

        public Form2()
        {
            InitializeComponent();
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in listBox1.Items)
            {

                lista += item.ToString() + "\n";

            }
        }
    }
}
