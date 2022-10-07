
using PriceList.Classes;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;
using ComboBox = System.Windows.Forms.ComboBox;
using Random = System.Random;

namespace PriceList
{
    public partial class Form1 : Form
    {
        #region Загрузка и настройка формы
        DataBase dataBase;
        System.Windows.Forms.ComboBox cmbPriceSalerfound;
        System.Windows.Forms.ComboBox cmbPriceProductfound;
        private static Random random = new Random();
        Chart priceHistory = new Chart();
        Series seriesOfprice = new Series("Цена");
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" + "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataBase = new DataBase();
            dataBase.dbConnect();
            setBindingSource();
            dgvSetting();
            cmbSetting();
            Soda soda;
            for (var i = 0; i < 100; i++)
            {
                soda = new Soda();
                soda.Name = generateString(4, 10);
                soda.Age = random.Next(1, 100);
                soda.LastName = generateString(5, 20);
                soda.MoneyCount = random.Next(5000, 100000);
                dataBase.AddSoda(soda);
            }
            var result = dataBase.SodaQuery();
            txtProductMonufacturerInfo.Text = (cmbProductMonufacturer.SelectedItem as Monufacturer)?.getInfo();
            txtProductModelInfo.Text = (cmbProductModel.SelectedItem as Model)?.getInfo();
            txtPriceSalerInfo.Text = (cmbPriceSaler.SelectedItem as Saler)?.getInfo();
            txtPticeProductInfo.Text = (cmbPriceProduct.SelectedItem as Product)?.getInfo();
            ChartSetting();
            labelSerring();
        }

        public void ChartSetting()
        {
            priceHistory.Parent = panelChart;
            priceHistory.Location = new Point(0, 100);
            priceHistory.Width = priceHistory.Parent.Width;
            priceHistory.Height = 200;
            priceHistory.ChartAreas.Add(new ChartArea("Цена товара"));
            seriesOfprice.ChartType = SeriesChartType.FastLine;
            seriesOfprice.ChartArea = "Цена товара";
            priceHistory.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            priceHistory.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            priceHistory.ChartAreas[0].AxisX2.MajorGrid.Enabled = false;
            priceHistory.Legends.Clear();


        }

        public void dgvSetting()
        {
            dgvModels.Columns[0].ReadOnly = true;
            dgvMonufacturers.Columns[0].ReadOnly = true;
            dgvPriceList.Columns[0].ReadOnly = true;
            dgvProducts.Columns[0].ReadOnly = true;
            dgvSalers.Columns[0].ReadOnly = true;

        }

        public void labelSerring()
        {
            Label lblPriceSaler = new Label();
            lblPriceSaler.Parent = panelChart;
            lblPriceSaler.Text = "Продавец";
            lblPriceSaler.Location = new Point(40, 20);

            Label lblPriceProduct = new Label();
            lblPriceProduct.Parent = panelChart;
            lblPriceProduct.Text = "Продукт";
            lblPriceProduct.Location = new Point(255, 20);
        }

        public void cmbSetting()
        {
            cmbMonufacturerCountry.SelectedIndex = 0;
            try
            {
                cmbPriceSalerfound = new System.Windows.Forms.ComboBox();
                cmbPriceSalerfound.Parent = panelChart;
                cmbPriceSalerfound.Location = new Point(10, 40);
                cmbPriceSalerfound.DataSource = dataBase.getPriceSaler();
                cmbPriceSalerfound.SelectedIndexChanged += PriceFoundChanged;
                cmbPriceSalerfound.SelectedIndex = 0;
                cmbPriceSalerfound.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbPriceSalerfound.Name = "cmbPriceSalerfound";

                cmbPriceProductfound = new System.Windows.Forms.ComboBox();
                cmbPriceProductfound.Parent = panelChart;
                cmbPriceProductfound.Location = new Point(220, 40);
                cmbPriceProductfound.DataSource = dataBase.getPriceProduct();
                cmbPriceProductfound.SelectedIndexChanged += PriceFoundChanged;
                cmbPriceProductfound.SelectedIndex = 0;
                cmbPriceProductfound.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbPriceProductfound.Name = "cmbPriceProductfound";
            }
            catch(Exception ex)
            {

            }
        }

        public void setBindingSource()
        {
            foreach (var mon in dataBase.GetMonufacturers())
            {
                monufacturerBindingSource.Add(mon);
            }
            foreach (var m in dataBase.getModels())
            {
                modelBindingSource1.Add(m);
            }
            foreach (var saler in dataBase.GetSaler())
            {
                salerBindingSource.Add(saler);
            }
            foreach (var product in dataBase.GetProducts())
            {
                productBindingSource.Add(product);
            }
            foreach (var price in dataBase.getPrice())
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
            if (e.RowIndex < 0)
            {
                return;
            }
            if (dgvModels.Columns[e.ColumnIndex].Index == dgvModels.Columns.Count - 1)
            {
                if (messageBoxClickResult("Удалить эту запись?") == DialogResult.Yes)
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
            if (selectedMonufacturer.site != monufacturer.site)
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
            if (matches.Count > 0)
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
            for (int i = 0; i < nudMonufacturerCount.Value; i++)
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
            if (cbSalerIsEdit.Checked == true)
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
            if (selectedSaler.phone != saler.phone)
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
            if (txtSalerPhone.Text.Length == 9 && (txtSalerPhone.Text[0] != '+'))
            {
                txtSalerPhone.Text += "-";
                txtSalerPhone.SelectionStart = 10;
            }
            else if (txtSalerPhone.Text.Length == 10 && txtSalerPhone.Text[0] == '+')
            {
                txtSalerPhone.Text += "-";
                txtSalerPhone.SelectionStart = 11;
            }
            //Добавление -
            if (txtSalerPhone.Text.Length == 12 && (txtSalerPhone.Text[0] != '+'))
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
            for (int i = 0; i < nudSalerCount.Value; i++)
            {
                Saler saler = new Saler();
                saler.title = generateString(5, 15);
                saler.site = generateString(10, 20) + "." + generateString(2, 5);
                saler.address = generateString(7, 16) + " srt";
                saler.phone = "7(9" + random.Next(0, 9) + random.Next(0, 9) + ")" +
                    random.Next(0, 9) + random.Next(0, 9) + random.Next(0, 9) + "-" +
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
            catch (NullReferenceException) { }
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
        #region Работа с ценами
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


        private void cmbPriceSaler_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtPriceSalerInfo.Text = (cmbPriceSaler.SelectedItem as Saler)?.getInfo();
            }
            catch (Exception) { }

        }

        private void cmbSalerProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtPticeProductInfo.Text = (cmbPriceProduct.SelectedItem as Product)?.getInfo();
            }
            catch (Exception) { }

        }

        private void btnPriceAdd_Click(object sender, EventArgs e)
        {
            var product = cmbPriceProduct.SelectedItem as Product;
            var saler = cmbPriceSaler.SelectedItem as Saler;
            var price = new Price();
            price.price = (int)nudPriceCost.Value;
            price.saler = saler;
            price.product = product;
            priceBindingSource.Add(price);
            dataBase.addPrice(price);
            txtProductTitle.Clear();
            messageBoxSuccessAdd();
        }

        private void cbPriceIsDelelte_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPriceIsDelelte.Checked)
            {
                dgvPriceList.Columns[5].Visible = true;
            }
            else
            {
                dgvPriceList.Columns[5].Visible = false;
            }
        }
        private void PriceFoundChanged(object sender, EventArgs e)
        {
            if (!isClear && isSecondClear >= 2)
            {
                if ((sender as ComboBox).Name == "cmbPriceProductfound")
                {
                    cmbPriceSalerfound.DataSource = dataBase.getPriceSaler((cmbPriceProductfound.SelectedItem as Product)?.id);
                    seriesOfprice.Points.Clear();
                    priceHistory.Series.Clear();
                    var product = cmbPriceProductfound.SelectedItem as Product;
                    var saler = cmbPriceSalerfound.SelectedItem as Saler;
                    var price = new Price();
                    price.price = 0;
                    price.saler = saler;
                    price.product = product;
                    var priceList = dataBase.getPrice(price);
                    var count = priceList.Count;
                    foreach (var p in priceList)
                    {
                        seriesOfprice.Points.AddXY(p.dateTime, p.price);
                    }
                    priceHistory.Series.Add(seriesOfprice);
                    txtAvarangePrice.Text = $@"Средняя цена: {dataBase.getAvarangePrice(saler,product)}";
                }
                else if ((sender as ComboBox).Name == "cmbPriceSalerfound")
                {
                    cmbPriceProductfound.DataSource = dataBase.getPriceProduct((cmbPriceSalerfound.SelectedItem as Saler)?.id);
                    seriesOfprice.Points.Clear();
                    priceHistory.Series.Clear();
                    var product = cmbPriceProductfound.SelectedItem as Product;
                    var saler = cmbPriceSalerfound.SelectedItem as Saler;
                    var price = new Price();
                    price.price = 0;
                    price.saler = saler;
                    price.product = product;
                    var priceList = dataBase.getPrice(price);
                    foreach (var p in priceList)
                    {
                        seriesOfprice.Points.AddXY(p.dateTime, p.price);
                    }
                    priceHistory.Series.Add(seriesOfprice);
                    txtAvarangePrice.Text = $@"Средняя цена: {dataBase.getAvarangePrice(saler, product)}";
                }
            }
            isClear = false;
            isSecondClear++;
        }

        bool isClear = false;
        int isSecondClear = 2;
        private void btnPriceClear_Click(object sender, EventArgs e)
        {
            isClear = true;
            isSecondClear = 0; 
            cmbPriceSalerfound.DataSource = dataBase.getPriceSaler();
            cmbPriceProductfound.DataSource = dataBase.getPriceProduct();
            seriesOfprice.Points.Clear();
            priceHistory.Series.Clear();
        }

        #endregion
    }
}
