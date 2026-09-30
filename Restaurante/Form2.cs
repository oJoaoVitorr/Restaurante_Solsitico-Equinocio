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

        List<Alimento> alimento = new List<Alimento>() {  
        //VERÃO
                new Alimento("Ceviche", "Verão", "Prato Principal"),
                new Alimento("Tacos", "Verão", "Prato Principal"),
                new Alimento("Wrap de Frango", "Verão", "Prato Principal"),
                new Alimento("Camarão", "Verão", "Prato Principal"),
                new Alimento("Massa Fria", "Verão", "Prato Principal"),
                new Alimento("Limonada", "Verão", "Bebida"),
                new Alimento("Água de Coco", "Verão", "Bebida"),
                new Alimento("Suco Natural", "Verão", "Bebida"),
                new Alimento("Cerveja", "Verão", "Bebida"),
                new Alimento("Refrigerante", "Verão", "Bebida"),
                new Alimento("Sorvete", "Verão", "Sobremesa"),
                new Alimento("Salada de Frutas", "Verão", "Sobremesa"),
                new Alimento("Gelatina", "Verão", "Sobremesa"),
                new Alimento("Açaí", "Verão", "Sobremesa"),
                new Alimento("Frozen Yogurt", "Verão", "Sobremesa"),

        //INVERNO
                new Alimento("Sopa", "Inverno", "Prato Principal"),
                new Alimento("Fondue de Queijo", "Inverno", "Prato Principal"),
                new Alimento("Batata Gratinada", "Inverno", "Prato Principal"),
                new Alimento("Escondidinho", "Inverno", "Prato Principal"),
                new Alimento("Lasanha", "Inverno", "Prato Principal"),
                new Alimento("Chá Mançela", "Inverno", "Bebida"),
                new Alimento("Chocolate Quente", "Inverno", "Bebida"),
                new Alimento("Cappuccino", "Inverno", "Bebida"),
                new Alimento("Café com Canela", "Inverno", "Bebida"),
                new Alimento("Vinho Quente", "Inverno", "Bebida"),
                new Alimento("Fondue de Chocolate", "Inverno", "Sobremesa"),
                new Alimento("Torta Smor's", "Inverno", "Sobremesa"),
                new Alimento("Cookies", "Inverno", "Sobremesa"), 
                new Alimento("Torta de Maçã", "Inverno", "Sobremesa"),
                new Alimento("Canjica", "Inverno", "Sobremesa"),

        //OUTONO
                new Alimento("Risoto de Cogumelos", "Outono", "Prato Principal"),
                new Alimento("Sopa de Legumes", "Outono", "Prato Principal"),
                new Alimento("Torta Salgada", "Outono", "Prato Principal"),
                new Alimento("Nhoque", "Outono", "Prato Principal"),
                new Alimento("Carne de Panela", "Outono", "Prato Principal"),
                new Alimento("", "Outono", "Bebida"),

        //PRIMAVERA

                new Alimento("Salada Tropical", "Primavera", "Prato Principal"),
        };

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
