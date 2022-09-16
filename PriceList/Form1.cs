using PriceList.Classes;
using Sharpen.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Random = System.Random;

namespace PriceList
{
    public partial class Form1 : Form
    {
        #region Загрузка и настройка формы
        DataBase dataBase;
        private static Random random = new Random();
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" + "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower();
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataBase = new DataBase();
            dataBase.dbConnect();
            var model = new Model("model" + random.Next(1, 1000));
            var monufacturer = new Monufacturer("monudacturer" + random.Next(1, 1000), "Russia", "mon.com");
            var product = new Product(monufacturer, model, "product" + random.Next(1, 1000));
            var saler = new Saler("saler" + random.Next(1, 1000), "Lenin str", "8(800)555-35-35", "saler.com");
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
            foreach (var m in dataBase.getModels())
            {
                modelBindingSource1.Add(m);
            }
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
        #endregion
        #region Утилиты
        void messageBoxSuccessAdd()
        {
            MessageBox.Show("Запись успешно добавлена",
                    "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
        void messageBoxError(string message)
        {
            MessageBox.Show(message,
                    "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
        DialogResult messageBoxClickResult(string message)
        {
            var dialogResult = MessageBox.Show(message,
                "Предупреждение",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question);
            return dialogResult;
        }
        string generateString(int from, int to)
        {
            return new string(Enumerable.Repeat(chars, random.Next(from, to))
        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        #endregion
        #region Работа с моделями
        Model selectedModel;
        //Удаление строки через встроенную кнопку
        private void dgvModels_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex <= 0)
            {
                return;
            }
            if (dgvModels.Columns[e.ColumnIndex].Index == dgvModels.Columns.Count - 1)
            {
                if(messageBoxClickResult("Удалить эту запись?") == DialogResult.Yes)
                {
                    var id = dgvModels.Rows[e.RowIndex].Cells[0].Value.ToString();
                    modelBindingSource1.RemoveAt(e.RowIndex);
                    dataBase.deleteModel(id);
                }
            }
            
        }
        //Отменение изменений
        private void dgvModels_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                ((DataGridView)sender).CancelEdit();
                ((DataGridView)sender).EndEdit();
            }
            
        }

        //Добавление записи
        private void btnModelAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtModelTitle.Text))
            {
                messageBoxError("Вы не ввели название");
                return;
            }
            Model model = new Model(txtModelTitle.Text);
            dataBase.addModel(model);
            modelBindingSource1.Add(model);
            txtModelTitle.Clear();
            messageBoxSuccessAdd();
        }
        
        //генерация моделей
        private void btnModelGenerate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= nudModelCount.Value; i++)
            {
                Model randomModel = new Model();
                randomModel.title = generateString(5, 15);
                modelBindingSource1.Add(randomModel);
                dataBase.addModel(randomModel);
            }

        }

        //Конец редатикрования ячейки и изменение данных
        private void dgvModels_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dialogResult = messageBoxClickResult("Изменить эту запись?");
            if (dialogResult == DialogResult.No)
            {
                dgvModels[1, e.RowIndex].Value = selectedModel.title;
                return;
            }
            if (dialogResult == DialogResult.Yes)
            {
                var model = new Model();
                model.id = dgvModels.Rows[e.RowIndex].Cells[0].Value.ToString();
                model.title = dgvModels.Rows[e.RowIndex].Cells[1].Value.ToString();
                dataBase.updateModel(model);
            }
        }

        private void dgvModels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= 0)
            {
                return;
            }
            selectedModel = new Model(dgvModels.Rows[e.RowIndex].Cells[1].Value.ToString());
        }
        #endregion
    }
}
