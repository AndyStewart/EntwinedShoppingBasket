using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheeseAndScrewdriverForm
{
    public partial class Form1 : Form
    {
        private readonly ShoppingCart shoppingCart;

        public Form1()
        {
            InitializeComponent();
            shoppingCart = new ShoppingCart(this);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = shoppingCart.CalculateTotal().ToString();
        }

        private class ShoppingCart
        {
            private readonly Form1 form1;
            private readonly List<IProduct> _products = new List<IProduct>();

            public ShoppingCart(Form1 form1)
            {
                this.form1 = form1;
            }

            public decimal CalculateTotal()
            {
                return _products.Sum(q => q.PriceDecimal);
            }

            public void AddCheese()
            {
                this._products.Add(new Cheese(decimal.Parse(form1.textBox1.Text), form1.textBox4.Text));
            }

            public void AddScrewdriver()
            {
                this._products.Add(new Screwdriver(decimal.Parse(form1.textBox2.Text)));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            shoppingCart.AddCheese();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            shoppingCart.AddScrewdriver();
        }
    }

    internal class Screwdriver : IProduct
    {
        public Screwdriver(decimal parse)
        {
            this.PriceDecimal = parse;
        }

        public decimal PriceDecimal { get; set; }
    }

    internal class Cheese : IProduct 
    {
        public decimal PriceDecimal { get; set; }

        public Cheese(decimal priceDecimal, string text)
        {
            PriceDecimal = priceDecimal;
        }
    }

    internal interface IProduct
    {
        decimal PriceDecimal { get; set; }
    }
}
