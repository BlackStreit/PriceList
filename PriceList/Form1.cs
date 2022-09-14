using PriceList.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceList
{
    public partial class Form1 : Form
    {
        DataBase dataBase;
        public Form1()
        {
            InitializeComponent();
            dataBase = new DataBase();
            dataBase.dbConnect();
            var model = new Model("model"+new Random().Next(1, 1000));
            var monufacturer = new Monufacturer("monudacturer" + new Random().Next(1, 1000), "Russia", "mon.com");
            var product = new Product(monufacturer, model, "product" + new Random().Next(1, 1000));
            var saler = new Saler("saler" + new Random().Next(1, 1000), "Lenin str", "8(800)555-35-35", "saler.com");
            var price = new Price(saler, product, 1000);
            dataBase.addModel(model);
            dataBase.addMonufacturer(monufacturer);
            dataBase.addPrice(price);
            dataBase.addProduct(product);
            dataBase.addSaler(saler);
            dgvMonufacturers.DataSource = dataBase.GetMonufacturers();
            dgvPriceList.DataSource = dataBase.getPrice();
            dgvProducts.DataSource = dataBase.GetProducts();
            dgvSalers.DataSource = dataBase.GetSaler();
            dgvModels.DataSource = dataBase.getModels();
            dataBase.dbClose();
        }
    }
}
