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
        decimal valorprato = 0, valorbebida = 0, valorsobremesa = 0, total = 0;
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
                new Alimento("Cerveja", "Verão", "Bebida"),
                new Alimento("Sprite", "Verão", "Bebida"),
                new Alimento("Coca-Cola", "Verão", "Bebida"),
                new Alimento("Pepsi", "Verão", "Bebida"),
                new Alimento("Guaraná", "Verão", "Bebida"),
                new Alimento("Sorvete", "Verão", "Sobremesa"),
                new Alimento("Salada de Frutas", "Verão", "Sobremesa"),
                new Alimento("Açaí", "Verão", "Sobremesa"),
                new Alimento("Pavê", "Verão", "Sobremesa"),
                new Alimento("Bolo de coco Gelado", "Verão", "Sobremesa"),

        //INVERNO
                new Alimento("Sopa de Carne", "Inverno", "Prato Principal"),
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
                new Alimento("Mousse de Morango", "Primavera", "Sobremesa"),
                new Alimento("Mousse de Maracujá", "Primavera", "Sobremesa"),
                new Alimento("Pavlova", "Primavera", "Sobremesa"),
                new Alimento("Pannacotta", "Primavera", "Sobremesa")
        };

        private List<ItemPedido> pedido = new List<ItemPedido>();
        private List<CheckBox> checkboxes = new List<CheckBox>();
        private bool atualizandoFiltro = false;
        bool pedidoFinalizado = false;


        public class ItemPedido
        {
            public string Nome { get; set; }
            public string Categoria { get; set; }
            public int Quantidade { get; set; }
            public decimal PrecoUnitario { get; set; }

            public override string ToString()
            {
                decimal subtotal = PrecoUnitario * Quantidade;

                return $"{Nome} - {Quantidade}x - {subtotal:C2}";
            }
        }

        private void AdicionarItem(
                string nome,
                string categoria,
                int quantidade,
                decimal precoUnitario)
        {
            if (pedidoFinalizado)
            {
                MessageBox.Show(
                    "Este pedido já foi finalizado!\n" +
                    "Não é possível adicionar novos itens.",
                    "Pedido finalizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
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
                item.PrecoUnitario = precoUnitario;
            }
            else
            {
                pedido.Add(new ItemPedido
                {
                    Nome = nome,
                    Categoria = categoria,
                    Quantidade = quantidade,
                    PrecoUnitario = precoUnitario
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
                    valorprato = 38.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.ceviche;
                    break;

                case "Tacos":
                    valorprato = 32.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.tacos; 
                    break;

                case "Wrap de Frango":
                    valorprato = 29.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.wrap;
                    break;

                case "Camarão":
                    valorprato = 46.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.camarao;
                    break;

                case "Massa Fria":
                    valorprato = 30.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.massafria;
                    break;

                case "Limonada":
                    valorbebida = 10.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.limonada;
                    break;

                case "Água de Coco":
                    valorbebida = 9.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.aguadecoco;
                    break;

                case "Cerveja":
                    valorbebida = 14.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.cerveja;
                    break;
                   

                case "Sprite":
                    valorbebida = 7.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.sprite;
                    break;

                case "Coca-Cola":
                    valorbebida = 7.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.cocacola;
                    break;

                case "Pepsi":
                    valorbebida = 7.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.pepsi;
                    break;

                case "Guaraná":
                    valorbebida = 7.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.guarana;
                    break;
                case "Sorvete":
                    valorsobremesa = 12.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.sorvete;
                    break;

                case "Salada de Frutas":
                    valorsobremesa = 14.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.saladadefrutas;
                    break;

                case "Bolo de Coco Gelado":
                    valorsobremesa = 10.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.bologelado;
                    break;

                case "Açaí":
                    valorsobremesa = 18.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.acai;
                    break;

                case "Pavê":
                    valorsobremesa = 13.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.pave;
                    break;
                    
                    //INVERNO
                case "Sopa de Carne":
                    valorprato = 22.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.sopacarne;
                    break;

                case "Fondue de Queijo":
                    valorprato = 42.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.fonduequeijo;
                    break;

                case "Batata Gratinada":
                    valorprato = 28.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.batatagratinada;
                    break;

                case "Escondidinho":
                    valorprato = 34.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.escondidinhocarne;
                    break;

                case "Lasanha":
                    valorprato = 36.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.lasanha;
                    break;

                case "Chá Mançela":
                    valorbebida = 10.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.chamacacanela;
                    break;  

                case "Chocolate Quente":
                    valorbebida = 14.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.chocolatequente;
                    break;

                case "Cappuccino":
                    valorbebida = 12.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.cappuccino;
                    break;

                case "Café com Canela":
                    valorbebida = 9.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.cafecanela;
                    break;

                 case "Vinho Quente":
                    valorbebida = 16.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.vinhoquente;
                    break;

                case "Fondue de Chocolate":
                    valorsobremesa = 38.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.fonduechocolate;
                    break;

                case "S'mores":
                    valorsobremesa = 16.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.smores;
                    break;

                case "Cookies":
                    valorsobremesa = 9.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.cookies;
                    break;

                case "Torta de Maçã":
                    valorsobremesa = 15.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.tortamaca;
                    break;

                case "Canjica":
                    valorsobremesa = 12.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.canjica;
                    break;

                //OUTONO
                case "Risoto de Cogumelos":
                    valorprato = 39.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.risotocogumelo;
                    break;

                case "Sopa de Legumes":
                    valorprato = 23.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.sopalegumes;
                    break;

                case "Torta Salgada":
                    valorprato = 29.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.tortasalgada;
                    break;

                case "Nhoque":
                    valorprato = 32.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.nhoque;
                    break;

                case "Carne de Panela":
                    valorprato = 40.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.carnedepanela;
                    break;

                case "Suco de Maçã":
                    valorbebida = 12.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.sucomaca;
                    break;

                case "Chai Latte":
                    valorbebida = 14.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.chailatte;
                    break;

                case "Café com Caramelo":
                    valorbebida = 12.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.cafecaramelo;
                    break;

                case "Chá de Gengibre":
                    valorbebida  = 10.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.chagengibre;
                    break;

                case "Cerveja Amanteigada":
                    valorbebida = 15.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.cervejaamanteigada;
                    break;

                case "Crumble de Maçã":
                    valorsobremesa = 16.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.crumblemaca;
                    break;

                case "Pudim":
                    valorsobremesa = 10.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.pudim;
                    break;

                case "Brownie":
                    valorsobremesa = 12.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.brownie;
                    break;

                case "Bolo de Cenoura":
                    valorsobremesa = 10.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.bolocenoura;
                    break;

                case "Pera com Canela":
                    valorsobremesa = 12.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.peracanela;
                    break;

                    //PRIMAVERA
                case "Salada Tropical":
                    valorprato = 28.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.saladatropical;
                   
                    break;
                 
                case "Massa com Pesto":
                    valorprato = 32.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.massapesto;
                    break;

                case "Frango com Ervilha":
                    valorprato = 33.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.frangoevrilha;
                    break;

                case "Peixe Primavera":
                    valorprato = 39.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.peixeprima;
                    break;

                case "Sanduíche Natural":
                    valorprato = 22.00m;
                    label1.Text = valorprato.ToString("C2");
                    pictureBox1.Image = Properties.Resources.sanduiche;
                    break;

                case "Suco Tropical":
                    valorbebida = 13.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.sucotropical;
                    break;

                case "Limonada Rosa":
                    valorbebida = 12.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.limonadarosa;
                    break;

                case "Smoothie":
                    valorbebida = 16.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.smoothie;
                    break;

                case "Chá de Pêssego":
                    valorbebida = 10.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.chapessego;
                    break;

                case "Vitamina":
                    valorbebida = 13.00m;
                    label3.Text = valorbebida.ToString("C2");
                    pictureBox2.Image = Properties.Resources.vitamina;
                    break;

                case "Torta de Limão":
                    valorsobremesa = 14.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.tortalimao;
                    break;

                case "Gelatina Colorida":
                    valorsobremesa = 9.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.gelatinacolorida;
                    break;

                case "Mousse de Morango":
                    valorsobremesa = 12.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.moussemorango;
                    break;

                case "Mousse de Maracujá":
                    valorsobremesa = 12.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.moussemaracuja;
                    break;

                case "Pavlova":
                    valorsobremesa = 18.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.pavlova;
                    break;

                case "Pannacotta":
                    valorsobremesa = 15.00m;
                    label5.Text = valorsobremesa.ToString("C2");
                    pictureBox3.Image = Properties.Resources.pannacotta;
                    break;

                default:
                    valorprato = 0;
                    valorbebida = 0;
                    valorsobremesa = 0;
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    pictureBox3.Image = null;
                    break;

                decimal subtotalPrato = valorprato*(decimal)numericUpDown1.Value;
                 //label6.Text = subtotalPrato.ToString("C2");
                    decimal subtotalBebida = valorbebida*(decimal)numericUpDown2.Value;
                decimal subtotalSobremesa = valorsobremesa * pedido.Where(i => i.Categoria == "Sobremesa").Sum(i => i.Quantidade);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (pedidoFinalizado)
            {
                MessageBox.Show(
                    "O pedido já foi finalizado. " +
                    "Não é possível modificá-lo.",
                    "Pedido finalizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            LimparSelecoes();

            richTextBox1.Clear();

            total = 0;
            lista = "";
            descricao = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    
        private void button2_Click(object sender, EventArgs e)
        {
            if (pedido.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um item ao pedido!");
                return;
            }

            total = 0;

            foreach (ItemPedido item in pedido)
            {
                total += item.PrecoUnitario * item.Quantidade;
            }

            decimal desconto = 0;
            decimal valorFinal = total;

            if (total > 150)
            {
                desconto = total * 0.10m;
                valorFinal = total - desconto;
            }

            richTextBox1.Clear();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.AppendText("SOLSTÍCIO & EQUINÓCIO\n");
            richTextBox1.AppendText(comboBox1.Text +"\n\n");

            foreach (ItemPedido item in pedido)
            {
                decimal subtotal = item.PrecoUnitario * item.Quantidade;
                richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                richTextBox1.AppendText(
                   item.Quantidade+"x " + item.Nome + " - " + subtotal.ToString("C2") + "\n\n"
                );
            }
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.AppendText("===========================\n");
            richTextBox1.AppendText(
                "Valor do pedido: " + total.ToString("C2") + "\n");

            richTextBox1.AppendText(
                "Desconto (10%): " + desconto.ToString("C2") + "\n\n");

            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.AppendText(
                "VALOR FINAL: " + valorFinal.ToString("C2") + "\n");
          
            pedidoFinalizado = true;

            foreach (Control linha in flowLayoutPanel1.Controls)
            {
                if (linha is FlowLayoutPanel painel)
                {
                    foreach (Control controle in painel.Controls)
                    {
                        controle.Enabled = false;
                    }
                }
            }
            MessageBox.Show(
                "Pedido finalizado com sucesso!",
                "Pedido finalizado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        

        private void cbEstacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrar();
            if (cbEstacao.Text == "Inverno")
            {
               // BackColor = Color.LightBlue;
               //BackgroundImage = Properties.Resources.invernobk;
                BackgroundImage = Properties.Resources.invernobkesc;
            }
            else if (cbEstacao.Text == "Verão")
            {
                // BackColor = Color.FromArgb(255, 231, 89);
                // BackgroundImage = Properties.Resources.veraobk;
                BackgroundImage = Properties.Resources.veraobkesc;
            }
            else if (cbEstacao.Text == "Outono")
            {
              //  BackColor = Color.SandyBrown;
             // BackgroundImage = Properties.Resources.outubrobk;
                BackgroundImage = Properties.Resources.outonobkesc;
            }
            else if (cbEstacao.Text == "Primavera")
            {
               // BackColor = Color.FromArgb(229, 150, 190);
               //BackgroundImage = Properties.Resources.primaverabk;
                BackgroundImage = Properties.Resources.primaverabkesc;
            }
            else if(cbEstacao.Text == "Completo")
            {
               // BackColor = Color.LightSalmon;
               // BackgroundImage = Properties.Resources.geralbk;
               BackgroundImage = Properties.Resources.geralbkesc;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cbEstacao.Items.Add("Completo");
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

            foreach (Alimento item in alimento)
            {
                if (estacao == "Completo" || estacao == "" || item.Estacao == estacao)
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
                (int)numericUpDown1.Value,
                valorprato
            );
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdicionarItem(
                cbBebida.Text,
                "Bebida",
                (int)numericUpDown2.Value,
                valorbebida
            );
        }

        private void cbPrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarItem(cbPrato.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pedidoFinalizado = false;
            LimparSelecoes();
            comboBox1.SelectedIndex = -1;

        }

        private void cbBebida_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            BuscarItem(cbBebida.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                flowLayoutPanel1.Visible = true;
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                cbEstacao.Visible = true;
                cbBebida.Visible = true;
                cbPrato.Visible = true;
                listBox1.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                richTextBox1.Visible = true;
            }
            else
            {
                flowLayoutPanel1.Visible = false;
                numericUpDown1.Visible = false;
                numericUpDown2.Visible = false;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                cbEstacao.Visible = false;
                cbBebida.Visible = false;
                cbPrato.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                listBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                richTextBox1.Visible = false;
            }
           
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void MostrarSobremesas(string estacao)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (Alimento alimentoAtual in alimento)
            {
                if (alimentoAtual.Categoria == "Sobremesa" &&
                    (estacao == "Completo" || alimentoAtual.Estacao == estacao))
                {
                    FlowLayoutPanel linha = new FlowLayoutPanel();
                    linha.AutoSize = true;
                    linha.WrapContents = false;

                    CheckBox checkBox = new CheckBox();
                    checkBox.Text = alimentoAtual.Nome;
                    checkBox.AutoSize = false;
                    checkBox.Width = 220;
                    checkBox.Margin = new Padding(5);
                    checkBox.Font = new Font(
                        "Trebuchet MS", 12, FontStyle.Bold);

                    ItemPedido itemExistente = pedido.Find(i =>
                        i.Nome == alimentoAtual.Nome &&
                        i.Categoria == "Sobremesa");

                    NumericUpDown quantidade = new NumericUpDown();
                    quantidade.Minimum = 1;
                    quantidade.Maximum = 5;
                    quantidade.Width = 50;
                    quantidade.ReadOnly = true;
                    quantidade.Font = new Font(
                        "Trebuchet MS", 18, FontStyle.Bold);

                    if (itemExistente != null)
                    {
                        checkBox.Checked = true;
                        quantidade.Value = itemExistente.Quantidade;
                        quantidade.Visible = true;
                    }
                    else
                    {
                        quantidade.Value = 1;
                        quantidade.Visible = false;
                    }

                    linha.Controls.Add(checkBox);
                    linha.Controls.Add(quantidade);

                    checkBox.CheckedChanged += CheckBoxSobremesa_CheckedChanged;
                    quantidade.ValueChanged += QuantidadeSobremesa_ValueChanged;

                    flowLayoutPanel1.Controls.Add(linha);
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

            if (pedidoFinalizado && !atualizandoFiltro)
            {
                atualizandoFiltro = true;

                checkBoxAtual.Checked = pedido.Any(i =>
                    i.Nome == checkBoxAtual.Text &&
                    i.Categoria == "Sobremesa");

                
            }
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
                    (int)quantidade.Value,
                     valorsobremesa);

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
                i.Categoria == "Sobremesa");

            if (pedidoFinalizado)
            {
                if (item != null)
                {
                    quantidade.Value = item.Quantidade;
                }


            }

            if (item != null)
            {
                item.Quantidade = (int)quantidade.Value;
                AtualizarPedido();
            }
        }
        private void LimparSelecoes()
        {
            cbEstacao.SelectedIndex = -1;
            cbPrato.Text = "";
            cbBebida.Text = "";

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;

            foreach (Control linha in flowLayoutPanel1.Controls)
            {
                if (linha is FlowLayoutPanel painel)
                {
                    CheckBox checkBox = painel.Controls[0] as CheckBox;
                    NumericUpDown quantidade =
                        painel.Controls[1] as NumericUpDown;

                    if (checkBox != null)
                    {
                        checkBox.Checked = false;
                    }

                    if (quantidade != null)
                    {
                        quantidade.Value = 1;
                        quantidade.Visible = false;
                    }
                }
            }

            pedido.Clear();
            AtualizarPedido();

            valorprato = 0;
            valorbebida = 0;
            valorsobremesa = 0;

            label1.Text = "";
            label3.Text = "";
            label5.Text = "";

            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
        }
    }

    }