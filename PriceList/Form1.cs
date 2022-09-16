using PriceList.Classes;
using Sharpen.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            var monufacturer = new Monufacturer("monudacturer" + random.Next(1, 1000), "Россия", "mon.com");
            var product = new Product(monufacturer, model, "product" + random.Next(1, 1000));
            var saler = new Saler("saler" + random.Next(1, 1000), "Lenin str", "8(800)555-35-35", "saler.com");
            var price = new Price(saler, product, 1000);
            dataBase.addModel(model);
            dataBase.addMonufacturer(monufacturer);
            dataBase.addPrice(price);
            dataBase.addProduct(product);
            dataBase.addSaler(saler);
            foreach (var mon in dataBase.GetMonufacturers())
            {
                monufacturerBindingSource.Add(mon);
            }
            dgvPriceList.DataSource = dataBase.getPrice();
            dgvProducts.DataSource = dataBase.GetProducts();
            dgvSalers.DataSource = dataBase.GetSaler();
            foreach (var m in dataBase.getModels(""))
            {
                modelBindingSource1.Add(m);
            }
            dgvSetting();
            cmbSetting();
        }
        public void dgvSetting()
        {
            dgvModels.Columns[0].ReadOnly = true;
            dgvMonufacturers.Columns[0].ReadOnly = true;
            dgvPriceList.Columns[0].ReadOnly = true;
            dgvProducts.Columns[0].ReadOnly = true;
            dgvSalers.Columns[0].ReadOnly = true;
        }

        public void cmbSetting()
        {
            cmbMonufacturerCountry.SelectedIndex = 0;
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

        //Отменение изменений
        private void tableValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                ((DataGridView)sender).CancelEdit();
                ((DataGridView)sender).EndEdit();
            }

        }
        #endregion
        #region Работа с моделями
        Model selectedModel;
        //Удаление строки через встроенную кнопку
        private void dgvModels_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
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
            if (selectedModel.title.Equals(dgvModels[1, e.RowIndex].Value.ToString()))
            {
                return;
            }
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
            if (e.RowIndex < 0)
            {
                return;
            }
            selectedModel = new Model(dgvModels.Rows[e.RowIndex].Cells[1].Value.ToString());
        }

        private void txtModelfound_TextChanged(object sender, EventArgs e)
        {
            modelBindingSource1.Clear();
            foreach (var m in dataBase.getModels(txtModelfound.Text))
            {
                modelBindingSource1.Add(m);
            }
        }
        private void cbModelIsEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModelIsEdit.Checked)
            {
                dgvModels.Columns[1].ReadOnly = false;
                dgvModels.Columns[2].Visible = true;
            }
            else
            {
                dgvModels.Columns[1].ReadOnly = true;
                dgvModels.Columns[2].Visible = false;
            }
        }
        #endregion
        #region Работа с производителем
        private void dgvMonufacturers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (dgvMonufacturers.Columns[e.ColumnIndex].Index == dgvMonufacturers.Columns.Count - 1)
            {
                if (messageBoxClickResult("Удалить эту запись?") == DialogResult.Yes)
                {
                    var id = dgvMonufacturers.Rows[e.RowIndex].Cells[0].Value.ToString();
                    monufacturerBindingSource.RemoveAt(e.RowIndex);
                    dataBase.deleteMonufacturer(id);
                }
            }
        }

        Monufacturer selectedMonufacturer;

        private void dgvMonufacturers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Monufacturer monufacturer = new Monufacturer();
            monufacturer.id = dgvMonufacturers.Rows[e.RowIndex].Cells[0].Value.ToString();
            monufacturer.title = dgvMonufacturers.Rows[e.RowIndex].Cells[1].Value.ToString();
            monufacturer.country = dgvMonufacturers.Rows[e.RowIndex].Cells[2].Value.ToString();
            monufacturer.site = dgvMonufacturers.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (selectedMonufacturer.Equals(monufacturer))
            {
                return;
            }
            if(selectedMonufacturer.site != monufacturer.site)
            {
                Regex regex = new Regex(@"\w+[.]\w+");
                MatchCollection matches = regex.Matches(monufacturer.site);
                if (matches.Count == 0)
                {
                    messageBoxError("Не верный формат сайта");
                    dgvMonufacturers[3, e.RowIndex].Value = selectedMonufacturer.site;
                    return;
                }

            }
            var dialogResult = messageBoxClickResult("Изменить эту запись?");
            if (dialogResult == DialogResult.No)
            {
                dgvMonufacturers[1, e.RowIndex].Value = selectedMonufacturer.title;
                dgvMonufacturers[2, e.RowIndex].Value = selectedMonufacturer.country;
                dgvMonufacturers[3, e.RowIndex].Value = selectedMonufacturer.site;
                return;
            }
            if (dialogResult == DialogResult.Yes)
            {
                
                dataBase.updateMonufacturer(dgvMonufacturers.CurrentRow.DataBoundItem as Monufacturer);
            }
        }

        private void dgvMonufacturers_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            selectedMonufacturer = new Monufacturer();
            selectedMonufacturer.id = dgvMonufacturers.Rows[e.RowIndex].Cells[0].Value.ToString();
            selectedMonufacturer.title = dgvMonufacturers.Rows[e.RowIndex].Cells[1].Value.ToString();
            selectedMonufacturer.country = dgvMonufacturers.Rows[e.RowIndex].Cells[2].Value.ToString();
            selectedMonufacturer.site = dgvMonufacturers.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void cbMonufacturerIsEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMonufacturerIsEdit.Checked)
            {
                dgvMonufacturers.Columns[1].ReadOnly = false;
                dgvMonufacturers.Columns[2].ReadOnly = false;
                dgvMonufacturers.Columns[3].ReadOnly = false;
                dgvMonufacturers.Columns[4].Visible = true;
            }
            else
            {
                dgvMonufacturers.Columns[1].ReadOnly = true;
                dgvMonufacturers.Columns[2].ReadOnly = true;
                dgvMonufacturers.Columns[3].ReadOnly = true;
                dgvMonufacturers.Columns[4].Visible = false;
            }
        }

        private void btnMonufacturerAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMonufacturerTitle.Text))
            {
                messageBoxError("Вы не ввели название");
                return;
            }
            Regex regex = new Regex(@"\w+[.]\w+");
            MatchCollection matches = regex.Matches(txtMonufacturerSite.Text);
            if(matches.Count > 0)
            {
                var monufacturer = new Monufacturer(txtMonufacturerTitle.Text,
                    cmbMonufacturerCountry.Text,
                    txtMonufacturerSite.Text);
                dataBase.addMonufacturer(monufacturer);
                monufacturerBindingSource.Add(monufacturer);
                txtMonufacturerTitle.Clear();
                txtMonufacturerSite.Clear();
                messageBoxSuccessAdd();
            }
            else
            {
                messageBoxError("Не верный формат сайта");
            }
        }

        #endregion
    }
}
