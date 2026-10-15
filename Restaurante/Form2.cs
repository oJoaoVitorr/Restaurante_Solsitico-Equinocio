using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        decimal valor = 0, total = 0;
        string lista = "", descricao = "";

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

        private List<ItemPedido> pedido = new List<ItemPedido>();
        private List<CheckBox> checkboxes = new List<CheckBox>();
        private bool atualizandoFiltro = false;


        public class ItemPedido
        {
            public string Nome { get; set; }
            public string Categoria { get; set; }
            public int Quantidade { get; set; }
            public override string ToString()
            {
                return $"{Nome} - {Quantidade}x";
            }
        }

        private void AdicionarItem(
     string nome, string categoria, int quantidade)
        {
            if (string.IsNullOrWhiteSpace(nome) || quantidade < 1)
                return;

            bool existe = alimento.Any(a =>
                a.Nome == nome && a.Categoria == categoria);

            if (!existe)
            {
                MessageBox.Show("Alimento não encontrado.");
                return;
            }
            ItemPedido item = pedido.Find(i =>
                i.Nome == nome && i.Categoria == categoria);

            if (item != null)
            {

                item.Quantidade = quantidade;
            }
            else
            {
                pedido.Add(new ItemPedido
                {
                    Nome = nome,
                    Categoria = categoria,
                    Quantidade = quantidade
                });
            }

            AtualizarPedido();
        }
        private void AtualizarPedido()
        {
            listBox1.Items.Clear();

            foreach (ItemPedido item in pedido)
            {
                listBox1.Items.Add(item);
            }
        }

        private void BuscarItem(string nome)
        {
            switch (nome)
            {
                case "Ceviche":
                    // pictureBox1.Image = Properties.Resources.ceviche;
                    richTextBox2.Text = "Descrição do ceviche.";
                    break;

                case "Tacos":
                    // pictureBox1.Image = Properties.Resources.tacos;
                    richTextBox2.Text = "Descrição dos tacos.";

                    break;

                case "Wrap de Frango":
                    // pictureBox1.Image = Properties.Resources.wrap;
                    richTextBox2.Text = "Descrição do wrap de frango.";
                    break;

                default:
                    pictureBox1.Image = null;
                    richTextBox2.Clear();
                    break;
            }
        }
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

            pedido.RemoveAll(item =>
                item.Categoria == "Sobremesa" &&
                estacao != "" &&
                !alimento.Any(a =>
                    a.Nome == item.Nome &&
                    a.Categoria == "Sobremesa" &&
                    a.Estacao == estacao));

            cbPrato.Items.Clear();
            cbBebida.Items.Clear();

            foreach (Alimento item in alimento)
            {
                if (estacao == "" || item.Estacao == estacao)
                {
                    if (item.Categoria == "Prato Principal")
                        cbPrato.Items.Add(item.Nome);

                    else if (item.Categoria == "Bebida")
                        cbBebida.Items.Add(item.Nome);
                }
            }

            MostrarSobremesas(estacao);
            AtualizarPedido();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdicionarItem(
                cbPrato.Text,
                "Prato Principal",
                (int)numericUpDown1.Value
            );
        }

        private void button5_Click(object sender, EventArgs e)
        {

            {
                AdicionarItem(
                    cbBebida.Text,
                    "Bebida",
                    (int)numericUpDown2.Value
                );
            }
        }

        private void cbPrato_SelectedIndexChanged(
        object sender, EventArgs e)
        {
            BuscarItem(cbPrato.Text);
        }

        private void cbBebida_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            BuscarItem(cbBebida.Text);
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
                        quantidade.ValueChanged += QuantidadeSobremesa_ValueChanged;
                        linha.Controls.Add(checkBox);
                        linha.Controls.Add(quantidade);


                        flowLayoutPanel1.Controls.Add(linha);
                    }
                }
            }

        }

        private void CheckBoxSobremesa_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBoxAtual = sender as CheckBox;

            if (checkBoxAtual == null)
                return;

            FlowLayoutPanel linha = checkBoxAtual.Parent as FlowLayoutPanel;

            if (linha == null)
                return;

            NumericUpDown quantidade =
                linha.Controls[1] as NumericUpDown;

            if (quantidade == null)
                return;

            if (checkBoxAtual.Checked)
            {
                int selecionadas = 0;

                foreach (Control controle in flowLayoutPanel1.Controls)
                {
                    if (controle is FlowLayoutPanel painel)
                    {
                        CheckBox cb = painel.Controls[0] as CheckBox;

                        if (cb != null && cb.Checked)
                            selecionadas++;
                    }
                }

                if (selecionadas > 5)
                {
                    checkBoxAtual.Checked = false;

                    MessageBox.Show(
                        "Você pode escolher no máximo 5 sobremesas diferentes."
                    );

                    return;
                }

                AdicionarItem(
                    checkBoxAtual.Text,
                    "Sobremesa",
                    (int)quantidade.Value
                );

                quantidade.Visible = true;
            }
            else
            {
                pedido.RemoveAll(item =>
                    item.Nome == checkBoxAtual.Text &&
                    item.Categoria == "Sobremesa"
                );

                quantidade.Visible = false;
                quantidade.Value = 1;

                AtualizarPedido();
            }
        }
        private void QuantidadeSobremesa_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown quantidade = sender as NumericUpDown;

            if (quantidade == null)
                return;

            FlowLayoutPanel linha = quantidade.Parent as FlowLayoutPanel;

            if (linha == null)
                return;

            CheckBox checkBox = linha.Controls[0] as CheckBox;

            if (checkBox == null || !checkBox.Checked)
                return;

            ItemPedido item = pedido.Find(i =>
                i.Nome == checkBox.Text &&
                i.Categoria == "Sobremesa"
            );

            if (item != null)
            {
                item.Quantidade = (int)quantidade.Value;
                AtualizarPedido();
            }
        }
    }

    }