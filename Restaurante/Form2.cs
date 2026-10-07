using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Restaurante
{
    public partial class Form2 : Form
    {
        int valorbebida = 0, valorprato = 0, valorsobre = 0, total = 0;
        string lista = "";

        List<Alimento> alimento = new List<Alimento> {  
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
                new Alimento("Suco de Maçã", "Outono", "Bebida"),
                new Alimento("Chai Latte", "Outono", "Bebida"),
                new Alimento("Café com Caramelo", "Outono", "Bebida"),
                new Alimento("Chá de Gengibre", "Outono", "Bebida"),
                new Alimento("Cerveja Amanteigada", "Outono", "Bebida"),
                new Alimento("Torta de Abóbora", "Outono", "Sobremesa"),
                new Alimento("Pudim", "Outono", "Sobremesa"),
                new Alimento("Brownie", "Outono", "Sobremesa"),
                new Alimento("Pêra com Canela", "Outono", "Sobremesa"),
                new Alimento("Bolo de Cenoura", "Outono", "Sobremesa"),

        //PRIMAVERA

                new Alimento("Salada Tropical", "Primavera", "Prato Principal"),
                new Alimento("Massa com Pesto", "Primavera", "Prato Principal"),
                new Alimento("Frango com Ervas", "Primavera", "Prato Principal"),
                new Alimento("Peixe Primavera", "Primavera", "Prato Principal"),
                new Alimento("Sanduíche Natural", "Primavera", "Prato Principal"),
                new Alimento("Suco Tropical", "Primavera", "Bebida"),
                new Alimento("Limonada Rosa", "Primavera", "Bebida"),
                new Alimento("Smoothie", "Primavera", "Bebida"),
                new Alimento("Chá de Pêssego", "Primavera", "Bebida"),
                new Alimento("Vitamina", "Primavera", "Bebida"),
                new Alimento("Torta de Limão", "Primavera", "Sobremesa"),
                new Alimento("Gelatina", "Primavera", "Sobremesa"),
                new Alimento("Mousse", "Primavera", "Sobremesa"),
                new Alimento("Pavlova", "Primavera", "Sobremesa"),
                new Alimento("Pannacotta", "Primavera", "Sobremesa")
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
           
        }

        private void cbEstacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cbEstacao.Items.Add("Primavera");
            cbEstacao.Items.Add("Verão");
            cbEstacao.Items.Add("Outono");
            cbEstacao.Items.Add("Inverno");
            Filtrar();
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
        private void Filtrar()
        {
            string estacao = cbEstacao.Text;
            cbPrato.Items.Clear();
            cbBebida.Items.Clear();
            MostrarSobremesas(cbEstacao.Text);

            foreach (Alimento alimento in alimento)
            {
                if (estacao == "")
                {
                    if (alimento.Categoria == "Prato Principal")
                    {
                        cbPrato.Items.Add(alimento.Nome);
                    }
                    else if (alimento.Categoria == "Bebida")
                    {
                        cbBebida.Items.Add(alimento.Nome);
                    }
                }
                else if (alimento.Estacao == estacao)
                {
                    if (alimento.Categoria == "Prato Principal")
                    {
                        cbPrato.Items.Add(alimento.Nome);
                    }
                    else if (alimento.Categoria == "Bebida")
                    {
                        cbBebida.Items.Add(alimento.Nome);
                    }
                }
            }
        }
        private void MostrarSobremesas(string estacao)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (Alimento alimento in alimento)
            {
                if (alimento.Categoria == "Sobremesa")
                {
                    if (estacao == "" || alimento.Estacao == estacao)
                    {
                        CheckBox checkBox = new CheckBox();
                        FlowLayoutPanel linha = new FlowLayoutPanel();

                        linha.AutoSize = true;
                        linha.WrapContents = false;

                        checkBox.Text = alimento.Nome;
                        checkBox.AutoSize = false;
                        checkBox.Width = 220;
                        checkBox.Margin = new Padding(5);
                        checkBox.CheckedChanged += CheckBoxSobremesa_CheckedChanged;

                        NumericUpDown quantidade = new NumericUpDown();
                        quantidade.Minimum = 1;
                        quantidade.Maximum = 5;
                        quantidade.Value = 1;
                        quantidade.Width = 50;
                        quantidade.Visible = false;

                        linha.Controls.Add(checkBox);
                        linha.Controls.Add(quantidade);


                        flowLayoutPanel1.Controls.Add(linha);
                    }
                }
            }
        
        }
        private void CheckBoxSobremesa_CheckedChanged(object sender, EventArgs e)
        {
            int quantidadeSelecionada = 0;

            foreach (Control controle in flowLayoutPanel1.Controls)
            {
                if (controle is FlowLayoutPanel painel)
                {
                    CheckBox checkBox = painel.Controls[0] as CheckBox;
                    NumericUpDown quantidade = painel.Controls[1] as NumericUpDown;

                    if (checkBox.Checked)
                    {
                        quantidadeSelecionada++;
                        quantidade.Visible = true;
                    }
                    else
                    {
                        quantidade.Visible = false;

                        quantidade.Value = 1;
                    }
                }
            }

            if (quantidadeSelecionada > 5)
            {
                CheckBox checkBoxAtual = (CheckBox)sender;

                checkBoxAtual.Checked = false;

                MessageBox.Show(
                    "Você pode escolher no máximo 5 sobremesas diferentes.",
                    "Limite de sobremesas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}