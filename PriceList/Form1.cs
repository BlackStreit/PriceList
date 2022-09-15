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
            dgvSetting();
        }
        public void dgvSetting()
        {
            dgvModels.Columns[0].ReadOnly = true;
            dgvMonufacturers.Columns[0].ReadOnly = true;
            dgvPriceList.Columns[0].ReadOnly = true;
            dgvProducts.Columns[0].ReadOnly = true;
            dgvSalers.Columns[0].ReadOnly = true;
        }
        Model selectedModel;
        private void btnModelDelete_Click(object sender, EventArgs e)
        {
            dataBase.deleteModel(selectedModel.id);
            btnModelDelete.Enabled = false;
            btnModelUpdate.Enabled = false;
            dgvModels.DataSource = dataBase.getModels();
        }

        private void dgvModels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
            {
                return;
            }
            if (dgvModels.Rows[e.RowIndex].Cells[0].Value != null )
            {
                selectedModel = new Model();
                btnModelDelete.Enabled = true;
                btnModelUpdate.Enabled = true;
                selectedModel.id = dgvModels.Rows[e.RowIndex].Cells[0].Value.ToString();
                selectedModel.title = dgvModels.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnModelUpdate_Click(object sender, EventArgs e)
        {
            var rowIndex = dgvModels.CurrentCell.RowIndex;
            if (rowIndex < 0)
            {
                return;
            }
            if (dgvModels.Rows[rowIndex].Cells[0].Value != null)
            {
                var model = new Model();
                model.id = dgvModels.Rows[rowIndex].Cells[0].Value.ToString();
                model.title = dgvModels.Rows[rowIndex].Cells[1].Value.ToString();
                dataBase.updateModel(model);
                btnModelDelete.Enabled = false;
                btnModelUpdate.Enabled = false;
            }
        }
    }
}
