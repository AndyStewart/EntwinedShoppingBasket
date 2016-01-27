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

        private class ShoppingCart
        {
            private readonly Form1 _form1;
            private readonly List<IProduct> _products = new List<IProduct>();

            public ShoppingCart(Form1 form1)
            {
                this._form1 = form1;
                this._form1.button1.Click += (sender, args) => CalculateTotal();
                this._form1.button2.Click += (sender, args) => AddCheese();
                this._form1.button3.Click += (sender, args) => AddScrewdriver();
            }

            private void CalculateTotal()
            {
                this._form1.textBox3.Text = _products.Sum(q => q.PriceDecimal).ToString();
            }

            private void AddCheese()
            {
                this._products.Add(new Cheese(decimal.Parse(_form1.textBox1.Text), _form1.textBox4.Text));
            }

            private void AddScrewdriver()
            {
                this._products.Add(new Screwdriver(decimal.Parse(_form1.textBox2.Text)));
            }
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
