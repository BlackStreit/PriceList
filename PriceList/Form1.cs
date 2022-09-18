using Db4objects.Db4o.Internal.Mapping;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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
            setBindingSource();
            dgvSetting();
            cmbSetting();
            txtProductMonufacturerInfo.Text = (cmbProductMonufacturer.SelectedItem as Monufacturer)?.getInfo();
            txtProductModelInfo.Text = (cmbProductModel.SelectedItem as Model)?.getInfo();
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

        public void setBindingSource()
        {
            foreach (var mon in dataBase.GetMonufacturers())
            {
                monufacturerBindingSource.Add(mon);
            }
            foreach (var m in dataBase.getModels(""))
            {
                modelBindingSource1.Add(m);
            }
            foreach(var saler in dataBase.GetSaler())
            {
                salerBindingSource.Add(saler);
            }
            foreach(var product in dataBase.GetProducts())
            {
                productBindingSource.Add(product);
            }
            foreach(var price in dataBase.getPrice())
            {
                priceBindingSource.Add(price);
            }
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
        string[] countries = new string[]
        {
            "Россия",
            "США",
            "Великобритания",
            "Китай",
            "Япония",
            "Нидерланды",
            "Германия",
            "Франция"
        };
        private void btnMonufacturerGenerate_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < nudMonufacturerCount.Value; i++)
            {
                Monufacturer monufacturer = new Monufacturer();
                monufacturer.title = generateString(5, 15);
                monufacturer.country = countries[random.Next(0, countries.Length)];
                monufacturer.site = generateString(10, 20) + "." + generateString(2, 5);
                dataBase.addMonufacturer(monufacturer);
                monufacturerBindingSource.Add(monufacturer);
            }
        }
        #endregion
        #region Работа с продавцами
        private void cbSalerIsEdit_CheckedChanged(object sender, EventArgs e)
        {
            if(cbSalerIsEdit.Checked == true)
            {
                dgvSalers.Columns[1].ReadOnly = false;
                dgvSalers.Columns[2].ReadOnly = false;
                dgvSalers.Columns[3].ReadOnly = false;
                dgvSalers.Columns[4].ReadOnly = false;
                dgvSalers.Columns[5].Visible = true;
            }
            else
            {
                dgvSalers.Columns[1].ReadOnly = true;
                dgvSalers.Columns[2].ReadOnly = true;
                dgvSalers.Columns[3].ReadOnly = true;
                dgvSalers.Columns[4].ReadOnly = true;
                dgvSalers.Columns[5].Visible = false;
            }
        }

        private void dgvSalers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (dgvSalers.Columns[e.ColumnIndex].Index == dgvSalers.Columns.Count - 1)
            {
                if (messageBoxClickResult("Удалить эту запись?") == DialogResult.Yes)
                {
                    var id = dgvSalers.Rows[e.RowIndex].Cells[0].Value.ToString();
                    salerBindingSource.RemoveAt(e.RowIndex);
                    dataBase.deleteSaler(id);
                }
            }
        }
        Saler selectedSaler;
        private void dgvSalers_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            selectedSaler = new Saler();
            selectedSaler.id = dgvSalers.Rows[e.RowIndex].Cells[0].Value.ToString();
            selectedSaler.title = dgvSalers.Rows[e.RowIndex].Cells[1].Value.ToString();
            selectedSaler.address = dgvSalers.Rows[e.RowIndex].Cells[2].Value.ToString();
            selectedSaler.phone = dgvSalers.Rows[e.RowIndex].Cells[3].Value.ToString();
            selectedSaler.site = dgvSalers.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void dgvSalers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Saler saler = new Saler();
            saler.id = dgvSalers.Rows[e.RowIndex].Cells[0].Value.ToString();
            saler.title = dgvSalers.Rows[e.RowIndex].Cells[1].Value.ToString();
            saler.address = dgvSalers.Rows[e.RowIndex].Cells[2].Value.ToString();
            saler.phone = dgvSalers.Rows[e.RowIndex].Cells[3].Value.ToString();
            saler.site = dgvSalers.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (selectedSaler.Equals(saler))
            {
                return;
            }
            if (selectedSaler.site != saler.site)
            {
                Regex regex = new Regex(@"\w+[.]\w+");
                MatchCollection matches = regex.Matches(saler.site);
                if (matches.Count == 0)
                {
                    messageBoxError("Не верный формат сайта");
                    dgvSalers[4, e.RowIndex].Value = selectedSaler.site;
                    return;
                }
            }
            if(selectedSaler.phone != saler.phone)
            {
                Regex phoneRegex = new Regex(@"^[+]{0,1}[7-8]{1}[(]9{1}\d{2}[)]\d{3}[-]\d{2}[-]\d{2}$");
                MatchCollection matches = phoneRegex.Matches(saler.phone);
                if (matches.Count == 0)
                {
                    messageBoxError("Не верный формат телефона");
                    dgvSalers[3, e.RowIndex].Value = selectedSaler.phone;
                    return;
                }
            }
            var dialogResult = messageBoxClickResult("Изменить эту запись?");
            if (dialogResult == DialogResult.No)
            {
                dgvSalers[1, e.RowIndex].Value = selectedSaler.title;
                dgvSalers[2, e.RowIndex].Value = selectedSaler.address;
                dgvSalers[3, e.RowIndex].Value = selectedSaler.phone;
                dgvSalers[4, e.RowIndex].Value = selectedSaler.site;
                return;
            }
            if (dialogResult == DialogResult.Yes)
            {
                dataBase.updateSaler(dgvSalers.CurrentRow.DataBoundItem as Saler);
            }
        }

        private void btnSalerAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSalerTitle.Text))
            {
                messageBoxError("Вы не ввели название");
                return;
            }
            if (string.IsNullOrEmpty(txtSalerAddress.Text))
            {
                messageBoxError("Вы не ввели адрес");
                return;
            }
            Regex siteRegex = new Regex(@"\w+[.]\w+");
            Regex phoneRegex = new Regex(@"^[+]{0,1}[7-8]{1}[(]9{1}\d{2}[)]\d{3}[-]\d{2}[-]\d{2}$");
            MatchCollection matches = phoneRegex.Matches(txtSalerPhone.Text);
            if (matches.Count == 0)
            {
                messageBoxError("Не верный формат телефона");
                return;
            }
            matches = siteRegex.Matches(txtSalerSite.Text);
            if (matches.Count == 0)
            {
                messageBoxError("Не верный формат сайта");
                return;
            }
            Saler saler = new Saler();
            saler.phone = txtSalerPhone.Text;
            saler.address = txtSalerAddress.Text;
            saler.title = txtSalerTitle.Text;
            saler.site = txtSalerSite.Text;
            dataBase.addSaler(saler);
            salerBindingSource.Add(saler);
            messageBoxSuccessAdd();
            txtSalerPhone.Clear();
            txtSalerAddress.Clear();
            txtSalerTitle.Clear();
            txtSalerSite.Clear();
        }

        private void txtSalerPhone_TextChanged(object sender, EventArgs e)
        {
            //Добавление первой скобки
            if (txtSalerPhone.Text.Length == 1 && (txtSalerPhone.Text[0] != '+'))
            {
                txtSalerPhone.Text += "(9";
                txtSalerPhone.SelectionStart = 3;
            }
            else if (txtSalerPhone.Text.Length == 2 && txtSalerPhone.Text[1] == '7')
            {
                txtSalerPhone.Text += "(9";
                txtSalerPhone.SelectionStart = 4;
            }
            //Добавление второй скобки
            if (txtSalerPhone.Text.Length == 5 && (txtSalerPhone.Text[0] != '+'))
            {
                txtSalerPhone.Text += ")";
                txtSalerPhone.SelectionStart = 6;
            }
            else if (txtSalerPhone.Text.Length == 6 && txtSalerPhone.Text[0] == '+')
            {
                txtSalerPhone.Text += ")";
                txtSalerPhone.SelectionStart = 7;
            }
            //Добавление -
            if(txtSalerPhone.Text.Length == 9 && (txtSalerPhone.Text[0] != '+'))
            {
                txtSalerPhone.Text += "-";
                txtSalerPhone.SelectionStart = 10;
            }
            else if(txtSalerPhone.Text.Length == 10 && txtSalerPhone.Text[0] == '+')
            {
                txtSalerPhone.Text += "-";
                txtSalerPhone.SelectionStart = 11;
            }
            //Добавление -
            if(txtSalerPhone.Text.Length == 12 && (txtSalerPhone.Text[0] != '+'))
            {
                txtSalerPhone.Text += "-";
                txtSalerPhone.SelectionStart = 13;
            }
            else if (txtSalerPhone.Text.Length == 13 && txtSalerPhone.Text[0] == '+')
            {
                txtSalerPhone.Text += "-";
                txtSalerPhone.SelectionStart = 14;
            }
        }

        private void btnSalerGenerate_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < nudSalerCount.Value; i++)
            {
                Saler saler = new Saler();
                saler.title = generateString(5, 15);
                saler.site = generateString(10, 20) + "." + generateString(2, 5);
                saler.address = generateString(7, 16) + " srt";
                saler.phone = "7(9" + random.Next(0, 9) + random.Next(0, 9) +")" +
                    random.Next(0, 9) + random.Next(0, 9) +random.Next(0, 9) + "-" +
                    random.Next(0, 9) + random.Next(0, 9) + "-" + random.Next(0, 9) + random.Next(0, 9);
                salerBindingSource.Add(saler);
                dataBase.addSaler(saler);

            }
        }
        #endregion
        #region Работа с продуктами
        private void cbProductIsEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProductIsEdit.Checked)
            {
                dgvProducts.Columns[1].ReadOnly = false;
                dgvProducts.Columns[4].Visible = true;
            }
            else
            {
                dgvProducts.Columns[1].ReadOnly = true;
                dgvProducts.Columns[4].Visible = false;
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (dgvProducts.Columns[e.ColumnIndex].Index == dgvProducts.Columns.Count - 1)
            {
                if (messageBoxClickResult("Удалить эту запись?") == DialogResult.Yes)
                {
                    var id = dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString();
                    productBindingSource.RemoveAt(e.RowIndex);
                    dataBase.deleteProduct(id);
                }
            }
        }

        private void cmbProductMonufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtProductMonufacturerInfo.Text = (cmbProductMonufacturer.SelectedItem as Monufacturer)?.getInfo();
            } 
            catch (NullReferenceException) { }
        }

        private void cmbProductModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtProductModelInfo.Text = (cmbProductModel.SelectedItem as Model)?.getInfo();
            }
            catch(NullReferenceException) { }
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductTitle.Text))
            {
                messageBoxError("Вы не ввели название");
                return;
            }
            var model = cmbProductModel.SelectedItem as Model;
            var monufacturer = cmbProductMonufacturer.SelectedItem as Monufacturer;
            if (dataBase.isProductClone(model, monufacturer))
            {
                messageBoxError("Такой продукт уже существует");
                return;
            }
            var product = new Product();
            product.title = txtProductTitle.Text;
            product.model = model;
            product.monufacturer = monufacturer;
            productBindingSource.Add(product);
            dataBase.addProduct(product);
            txtProductTitle.Clear();
            messageBoxSuccessAdd();
        }
        Product selectedProduct;
        private void dgvProducts_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            selectedProduct = new Product();
            selectedProduct.id = dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString();
            selectedProduct.title = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
            selectedProduct.monufacturer = dgvProducts.Rows[e.RowIndex].Cells[2].Value as Monufacturer;
            selectedProduct.model = dgvProducts.Rows[e.RowIndex].Cells[3].Value as Model;            
        }

        private void dgvProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var monufacturer = dgvProducts.Rows[e.RowIndex].Cells[2].Value;
            var model = dgvProducts.Rows[e.RowIndex].Cells[3].Value;
            Product product = new Product();
            product.id = dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString();
            product.title = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
            product.monufacturer = monufacturer as Monufacturer;
            product.model = model as Model;
            if (selectedProduct.Equals(product))
            {
                return;
            }
            var dialogResult = messageBoxClickResult("Изменить эту запись?");
            if (dialogResult == DialogResult.No)
            {
                dgvProducts[1, e.RowIndex].Value = selectedProduct.title;
                return;
            }
            if (dialogResult == DialogResult.Yes)
            {
                dataBase.updateProduct(dgvProducts.CurrentRow.DataBoundItem as Product);
            }
        }
        #endregion

        private void cbPriceIsEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPriceIsEdit.Checked)
            {
                dgvPriceList.Columns[3].ReadOnly = false;
                dgvPriceList.Columns[4].Visible = true;
            }
            else
            {
                dgvPriceList.Columns[3].ReadOnly = true;
                dgvPriceList.Columns[4].Visible = false;
            }
        }

        private void dgvPriceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (dgvPriceList.Columns[e.ColumnIndex].Index == dgvPriceList.Columns.Count - 1)
            {
                if (messageBoxClickResult("Удалить эту запись?") == DialogResult.Yes)
                {
                    var id = dgvPriceList.Rows[e.RowIndex].Cells[0].Value.ToString();
                    priceBindingSource.RemoveAt(e.RowIndex);
                    dataBase.deletePrice(id);
                }
            }
        }
        Price selectedPrice;
        private void dgvPriceList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            selectedPrice = new Price();
            selectedPrice.id = dgvPriceList.Rows[e.RowIndex].Cells[0].Value.ToString();
            selectedPrice.saler = dgvPriceList.Rows[e.RowIndex].Cells[1].Value as Saler;
            selectedPrice.product = dgvPriceList.Rows[e.RowIndex].Cells[2].Value as Product;
            selectedPrice.price = Convert.ToInt32(dgvPriceList.Rows[e.RowIndex].Cells[3].Value);
        }

        private void dgvPriceList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var price = new Price();
            price.id = dgvPriceList.Rows[e.RowIndex].Cells[0].Value.ToString();
            price.saler = dgvPriceList.Rows[e.RowIndex].Cells[1].Value as Saler;
            price.product = dgvPriceList.Rows[e.RowIndex].Cells[2].Value as Product;
            price.price = Convert.ToInt32(dgvPriceList.Rows[e.RowIndex].Cells[3].Value);
            if (selectedPrice.Equals(price))
            {
                return;
            }
            var dialogResult = messageBoxClickResult("Изменить эту запись?");
            if (dialogResult == DialogResult.No)
            {
                dgvPriceList[3, e.RowIndex].Value = selectedPrice.price;
                return;
            }
            if (dialogResult == DialogResult.Yes)
            {
                dataBase.updatePrice(dgvPriceList.CurrentRow.DataBoundItem as Price);
            }
        }
    }
}
