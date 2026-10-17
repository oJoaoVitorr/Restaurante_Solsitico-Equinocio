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
                new Alimento("Pavê", "Verão", "Sobremesa"),

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
                new Alimento("S'mores", "Inverno", "Sobremesa"),
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
                new Alimento("Crumble de Maçã", "Outono", "Sobremesa"),
                new Alimento("Pudim", "Outono", "Sobremesa"),
                new Alimento("Brownie", "Outono", "Sobremesa"),
                new Alimento("Pêra com Canela", "Outono", "Sobremesa"),
                new Alimento("Bolo de Cenoura", "Outono", "Sobremesa"),

        //PRIMAVERA

                new Alimento("Salada Tropical", "Primavera", "Prato Principal"),
                new Alimento("Massa com Pesto", "Primavera", "Prato Principal"),
                new Alimento("Frango com Ervilha", "Primavera", "Prato Principal"),
                new Alimento("Peixe Primavera", "Primavera", "Prato Principal"),
                new Alimento("Sanduíche Natural", "Primavera", "Prato Principal"),
                new Alimento("Suco Tropical", "Primavera", "Bebida"),
                new Alimento("Limonada Rosa", "Primavera", "Bebida"),
                new Alimento("Smoothie", "Primavera", "Bebida"),
                new Alimento("Chá de Pêssego", "Primavera", "Bebida"),
                new Alimento("Vitamina", "Primavera", "Bebida"),
                new Alimento("Torta de Limão", "Primavera", "Sobremesa"),
                new Alimento("Gelatina Colorida", "Primavera", "Sobremesa"),
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
            { //VERAO
                case "Ceviche":
                    pictureBox1.Image = Properties.Resources.ceviche;
                    richTextBox2.Text = "Descrição do ceviche.";
                    break;

                case "Tacos":
                    pictureBox1.Image = Properties.Resources.tacos; 
                    richTextBox2.Text = "Descrição dos tacos.";

                    break;

                case "Wrap de Frango":
                    pictureBox1.Image = Properties.Resources.wrap;
                    richTextBox2.Text = "Descrição do wrap de frango.";
                    break;

                case "Camarão":
                    pictureBox1.Image = Properties.Resources.camarao;
                    richTextBox2.Text = "Descrição do camarão.";
                    break;

                case "Massa Fria":
                    pictureBox1.Image = Properties.Resources.massafria;
                    richTextBox2.Text = "Descrição da massa fria.";
                    break;

                case "Limonada":
                    pictureBox2.Image = Properties.Resources.limonada;
                    richTextBox3.Text = "Descrição da limonada.";
                    break;

                case "Água de Coco":
                     pictureBox2.Image = Properties.Resources.aguadecoco;
                    richTextBox3.Text = "Descrição da água de coco.";
                    break;

                case "Suco Natural":
                    pictureBox2.Image = Properties.Resources.suco;
                    richTextBox3.Text = "Descrição do suco natural.";
                    break;

                case "Cerveja":
                    pictureBox2.Image = Properties.Resources.cerveja;
                    richTextBox3.Text = "Descrição da cerveja.";
                    break;

                case "Refrigerante":
                    pictureBox2.Image = Properties.Resources.refrigerante;
                    richTextBox3.Text = "Descrição do refrigerante.";
                    break;

                case "Sorvete":
                    pictureBox3.Image = Properties.Resources.sorvete;
                    richTextBox4.Text = "Descrição do sorvete.";
                    break;

                case "Salada de Frutas":
                    pictureBox3.Image = Properties.Resources.saladadefrutas;
                    richTextBox4.Text = "Descrição da salada de frutas.";
                    break;

                case "Gelatina":
                    pictureBox3.Image = Properties.Resources.gelatina;
                    richTextBox4.Text = "Descrição da gelatina.";
                    break;

                case "Açaí":
                    pictureBox3.Image = Properties.Resources.acai;
                    richTextBox4.Text = "Descrição do açaí.";
                    break;

                case "Pavê":
                    pictureBox3.Image = Properties.Resources.pave;
                    richTextBox4.Text = "Descrição do pavê.";
                    break;
                    
                    //INVERNO
                case "Sopa":
                    pictureBox1.Image = Properties.Resources.sopalegumes;
                    richTextBox2.Text = "Sopa da escolha do cliente.";
                    break;

                case "Fondue de Queijo":
                    pictureBox1.Image = Properties.Resources.fonduequeijo;
                    richTextBox2.Text = "Fondue de queijo com pão e vegetais.";
                    break;

                case "Batata Gratinada":
                    pictureBox1.Image = Properties.Resources.batatagratinada;
                    richTextBox2.Text = "Batata gratinada com queijo e creme.";
                    break;

                case "Escondidinho":
                    pictureBox1.Image = Properties.Resources.escondidinhocarne;
                    richTextBox2.Text = "Escondidinho de carne seca com purê de mandioca.";
                    break;

                case "Lasanha":
                    pictureBox1.Image = Properties.Resources.lasanha;
                    richTextBox2.Text = "Lasanha de carne com molho de tomate e queijo.";
                    break;

                case "Chá Mançela":
                    pictureBox2.Image = Properties.Resources.chamacacanela;
                    richTextBox3.Text = "Chá de maça com canela.";
                    break;  

                case "Chocolate Quente":
                    pictureBox2.Image = Properties.Resources.chocolatequente;
                    richTextBox3.Text = "Chocolate quente com marshmallow.";
                    break;

                case "Cappuccino":
                    pictureBox2.Image = Properties.Resources.cappuccino;
                    richTextBox3.Text = "Cappuccino com espuma de leite.";
                    break;

                case "Café com Canela":
                    pictureBox2.Image = Properties.Resources.cafecanela;
                    richTextBox3.Text = "Café com canela e leite.";
                    break;

                 case "Vinho Quente":
                    pictureBox2.Image = Properties.Resources.vinhoquente;
                    richTextBox3.Text = "Vinho quente com especiarias.";
                    break;

                case "Fondue de Chocolate":
                    pictureBox3.Image = Properties.Resources.fonduechocolate;
                    richTextBox4.Text = "Fondue de chocolate com frutas.";
                    break;
                case "S'mores":
                    pictureBox3.Image = Properties.Resources.smores;
                    richTextBox4.Text = "S'mores com chocolate e marshmallow.";
                    break;

                case "Cookies":
                    pictureBox3.Image = Properties.Resources.cookies;
                    richTextBox4.Text = "Cookies de chocolate.";
                    break;

                case "Torta de Maçã":
                    pictureBox3.Image = Properties.Resources.tortamaca;
                    richTextBox4.Text = "Torta de maçã com canela.";
                    break;

                case "Canjica":
                    pictureBox3.Image = Properties.Resources.canjica;
                    richTextBox4.Text = "Canjica doce com leite e coco.";
                    break;

                //OUTONO
                case "Risoto de Cogumelos":
                    pictureBox1.Image = Properties.Resources.risotocogumelo;
                    richTextBox2.Text = "Risoto de cogumelos com parmesão.";
                    break;

                case "Sopa de Legumes":
                    pictureBox1.Image = Properties.Resources.sopalegumes;
                    richTextBox2.Text = "Sopa de legumes com ervas.";
                    break;

                case "Torta Salgada":
                    pictureBox1.Image = Properties.Resources.tortasalgada;
                    richTextBox2.Text = "Torta salgada de frango com legumes.";
                    break;

                case "Nhoque":
                    pictureBox1.Image = Properties.Resources.nhoque;
                    richTextBox2.Text = "Nhoque de batata com molho de tomate.";
                    break;

                case "Carne de Panela":
                    pictureBox1.Image = Properties.Resources.carnedepanela;
                    richTextBox2.Text = "Carne de panela com legumes.";
                    break;

                case "Suco de Maçã":
                    pictureBox2.Image = Properties.Resources.sucomaca;
                    richTextBox3.Text = "Suco de maçã natural.";
                    break;

                case "Chai Latte":
                    pictureBox2.Image = Properties.Resources.chailatte;
                    richTextBox3.Text = "Chai latte com especiarias.";
                    break;

                case "Café com Caramelo":
                    pictureBox2.Image = Properties.Resources.cafecaramelo;
                    richTextBox3.Text = "Café com caramelo e leite.";
                    break;

                case "Chá de Gengibre":
                    pictureBox2.Image = Properties.Resources.chagengibre;
                    richTextBox3.Text = "Chá de gengibre com limão.";
                    break;

                case "Cerveja Amanteigada":
                    pictureBox2.Image = Properties.Resources.cervejaamanteigada;
                    richTextBox3.Text = "Cerveja amanteigada com especiarias.";
                    break;

                case "Crumble de Maçã":
                    pictureBox3.Image = Properties.Resources.crumblemaca;
                    richTextBox4.Text = "Crumble de maçã com canela.";
                    break;

                case "Pudim":
                    pictureBox3.Image = Properties.Resources.pudim;
                    richTextBox4.Text = "Pudim de leite condensado.";
                    break;

                case "Brownie":
                    pictureBox3.Image = Properties.Resources.brownie;
                    richTextBox4.Text = "Brownie de chocolate com nozes.";
                    break;

                case "Bolo de Cenoura":
                    pictureBox3.Image = Properties.Resources.bolocenoura;
                    richTextBox4.Text = "Bolo de cenoura com cobertura de chocolate.";
                    break;

                case "Pera com Canela":
                    pictureBox3.Image = Properties.Resources.peracanela;
                    richTextBox4.Text = "Pêra assada com canela e mel.";
                    break;

                    //PRIMAVERA
                case "Salada Tropical":
                    pictureBox1.Image = Properties.Resources.saladatropical;
                    richTextBox2.Text = "Salada tropical com frutas e folhas verdes.";
                    break;
                 
                case "Massa com Pesto":
                    pictureBox1.Image = Properties.Resources.massapesto;
                    richTextBox2.Text = "Massa com molho pesto e queijo parmesão.";
                    break;

                case "Frango com Ervilha":
                    pictureBox1.Image = Properties.Resources.frangoevrilha;
                    richTextBox2.Text = "Frango com ervilhas e molho cremoso.";
                    break;

                case "Peixe Primavera":
                    pictureBox1.Image = Properties.Resources.peixeprima;
                    richTextBox2.Text = "Peixe primavera com legumes frescos.";
                    break;

                case "Sanduíche Natural":
                    pictureBox1.Image = Properties.Resources.sanduiche;
                    richTextBox2.Text = "Sanduíche natural com pão integral e vegetais.";
                    break;

                case "Suco Tropical":
                    pictureBox2.Image = Properties.Resources.sucotropical;
                    richTextBox3.Text = "Suco tropical com frutas da estação.";
                    break;

                case "Limonada Rosa":
                    pictureBox2.Image = Properties.Resources.limonadarosa;
                    richTextBox3.Text = "Limonada rosa com frutas vermelhas.";
                    break;

                case "Smoothie":
                    pictureBox1.Image = Properties.Resources.smoothie;
                    richTextBox3.Text = "Smoothie de frutas variadas.";
                    break;

                case "Chá de Pêssego":
                    pictureBox2.Image = Properties.Resources.chapessego;
                    richTextBox3.Text = "Chá de pêssego com hortelã.";
                    break;

                case "Vitamina":
                    pictureBox2.Image = Properties.Resources.vitamina;
                    richTextBox3.Text = "Vitamina de frutas com leite.";
                    break;

                case "Torta de Limão":
                    pictureBox3.Image = Properties.Resources.tortalimao;
                    richTextBox4.Text = "Torta de limão com merengue.";
                    break;

                case "Gelatina Colorida":
                    pictureBox3.Image = Properties.Resources.gelatinacolorida;
                    richTextBox4.Text = "Gelatina colorida com frutas.";
                    break;

                case "Mousse":
                    pictureBox3.Image = Properties.Resources.mousse;
                    richTextBox4.Text = "Mousse de chocolate com chantilly.";
                    break;

                case "Pavlova":
                    pictureBox3.Image = Properties.Resources.pavlova;
                    richTextBox4.Text = "Pavlova com frutas frescas e merengue.";
                    break;

                case "Pannacotta":
                    pictureBox3.Image = Properties.Resources.pannacotta;
                    richTextBox4.Text = "Pannacotta com calda de frutas vermelhas.";
                    break;

                default:
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    pictureBox3.Image = null;
                    richTextBox2.Clear();
                    richTextBox3.Clear();
                    richTextBox4.Clear();
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

        private void cbPrato_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            BuscarItem(cbPrato.Text);
        }

        private void cbBebida_SelectedIndexChanged(object sender, EventArgs e)
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
                BuscarItem(checkBoxAtual.Text);
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
                pictureBox1.Image = null;
                richTextBox4.Clear();
                pictureBox3.Image = null;
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