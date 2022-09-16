namespace PriceList
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbModelIsEdit = new System.Windows.Forms.CheckBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnModelAdd = new System.Windows.Forms.Button();
            this.txtModelTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnModelGenerate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudModelCount = new System.Windows.Forms.NumericUpDown();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModelfound = new System.Windows.Forms.TextBox();
            this.dgvModels = new System.Windows.Forms.DataGridView();
            this.btnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnMonufacturerGenerate = new System.Windows.Forms.Button();
            this.nudMonufacturerCount = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMonufacturerSite = new System.Windows.Forms.TextBox();
            this.btnMonufacturerAdd = new System.Windows.Forms.Button();
            this.cmbMonufacturerCountry = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMonufacturerTitle = new System.Windows.Forms.TextBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.cbMonufacturerIsEdit = new System.Windows.Forms.CheckBox();
            this.dgvMonufacturers = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvSalers = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvPriceList = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.monufacturerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.siteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudModelCount)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModels)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonufacturerCount)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonufacturers)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalers)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monufacturerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1024, 523);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbModelIsEdit);
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Controls.Add(this.dgvModels);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1016, 497);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Модели";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbModelIsEdit
            // 
            this.cbModelIsEdit.AutoSize = true;
            this.cbModelIsEdit.Location = new System.Drawing.Point(760, 18);
            this.cbModelIsEdit.Name = "cbModelIsEdit";
            this.cbModelIsEdit.Size = new System.Drawing.Size(155, 17);
            this.cbModelIsEdit.TabIndex = 10;
            this.cbModelIsEdit.Text = "Включить редатирование";
            this.cbModelIsEdit.UseVisualStyleBackColor = true;
            this.cbModelIsEdit.CheckedChanged += new System.EventHandler(this.cbModelIsEdit_CheckedChanged);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Location = new System.Drawing.Point(683, 51);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(308, 440);
            this.tabControl2.TabIndex = 9;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox1);
            this.tabPage6.Controls.Add(this.groupBox2);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(300, 414);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "Добавление";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModelAdd);
            this.groupBox1.Controls.Add(this.txtModelTitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(27, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 167);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление модели";
            // 
            // btnModelAdd
            // 
            this.btnModelAdd.Location = new System.Drawing.Point(69, 96);
            this.btnModelAdd.Name = "btnModelAdd";
            this.btnModelAdd.Size = new System.Drawing.Size(96, 40);
            this.btnModelAdd.TabIndex = 4;
            this.btnModelAdd.Text = "Добавить";
            this.btnModelAdd.UseVisualStyleBackColor = true;
            this.btnModelAdd.Click += new System.EventHandler(this.btnModelAdd_Click);
            // 
            // txtModelTitle
            // 
            this.txtModelTitle.Location = new System.Drawing.Point(20, 61);
            this.txtModelTitle.Name = "txtModelTitle";
            this.txtModelTitle.Size = new System.Drawing.Size(195, 20);
            this.txtModelTitle.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnModelGenerate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nudModelCount);
            this.groupBox2.Location = new System.Drawing.Point(27, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 167);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Генерация моделей";
            // 
            // btnModelGenerate
            // 
            this.btnModelGenerate.Location = new System.Drawing.Point(69, 96);
            this.btnModelGenerate.Name = "btnModelGenerate";
            this.btnModelGenerate.Size = new System.Drawing.Size(96, 40);
            this.btnModelGenerate.TabIndex = 8;
            this.btnModelGenerate.Text = "Сгенерировать";
            this.btnModelGenerate.UseVisualStyleBackColor = true;
            this.btnModelGenerate.Click += new System.EventHandler(this.btnModelGenerate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Количество";
            // 
            // nudModelCount
            // 
            this.nudModelCount.Location = new System.Drawing.Point(20, 62);
            this.nudModelCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudModelCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudModelCount.Name = "nudModelCount";
            this.nudModelCount.Size = new System.Drawing.Size(195, 20);
            this.nudModelCount.TabIndex = 6;
            this.nudModelCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label3);
            this.tabPage7.Controls.Add(this.txtModelfound);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(300, 414);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Поиск";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Название";
            // 
            // txtModelfound
            // 
            this.txtModelfound.Location = new System.Drawing.Point(50, 50);
            this.txtModelfound.Name = "txtModelfound";
            this.txtModelfound.Size = new System.Drawing.Size(213, 20);
            this.txtModelfound.TabIndex = 0;
            this.txtModelfound.TextChanged += new System.EventHandler(this.txtModelfound_TextChanged);
            // 
            // dgvModels
            // 
            this.dgvModels.AllowUserToAddRows = false;
            this.dgvModels.AutoGenerateColumns = false;
            this.dgvModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.btnDel});
            this.dgvModels.DataSource = this.modelBindingSource1;
            this.dgvModels.Location = new System.Drawing.Point(6, 18);
            this.dgvModels.Name = "dgvModels";
            this.dgvModels.Size = new System.Drawing.Size(651, 473);
            this.dgvModels.TabIndex = 1;
            this.dgvModels.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModels_CellClick);
            this.dgvModels.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModels_CellContentClick);
            this.dgvModels.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModels_CellEndEdit);
            this.dgvModels.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.tableValidating);
            // 
            // btnDel
            // 
            this.btnDel.HeaderText = "Удаление";
            this.btnDel.Name = "btnDel";
            this.btnDel.Text = "Удалить";
            this.btnDel.UseColumnTextForButtonValue = true;
            this.btnDel.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl3);
            this.tabPage1.Controls.Add(this.cbMonufacturerIsEdit);
            this.tabPage1.Controls.Add(this.dgvMonufacturers);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1016, 497);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Производители";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Controls.Add(this.tabPage9);
            this.tabControl3.Location = new System.Drawing.Point(698, 39);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(316, 452);
            this.tabControl3.TabIndex = 2;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.groupBox4);
            this.tabPage8.Controls.Add(this.groupBox3);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(308, 426);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "Добавление";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnMonufacturerGenerate);
            this.groupBox4.Controls.Add(this.nudMonufacturerCount);
            this.groupBox4.Location = new System.Drawing.Point(18, 278);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(272, 119);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Генерация";
            // 
            // btnMonufacturerGenerate
            // 
            this.btnMonufacturerGenerate.Location = new System.Drawing.Point(84, 58);
            this.btnMonufacturerGenerate.Name = "btnMonufacturerGenerate";
            this.btnMonufacturerGenerate.Size = new System.Drawing.Size(95, 41);
            this.btnMonufacturerGenerate.TabIndex = 1;
            this.btnMonufacturerGenerate.Text = "Сгенерировать";
            this.btnMonufacturerGenerate.UseVisualStyleBackColor = true;
            this.btnMonufacturerGenerate.Click += new System.EventHandler(this.btnMonufacturerGenerate_Click);
            // 
            // nudMonufacturerCount
            // 
            this.nudMonufacturerCount.Location = new System.Drawing.Point(49, 32);
            this.nudMonufacturerCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMonufacturerCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMonufacturerCount.Name = "nudMonufacturerCount";
            this.nudMonufacturerCount.Size = new System.Drawing.Size(165, 20);
            this.nudMonufacturerCount.TabIndex = 0;
            this.nudMonufacturerCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtMonufacturerSite);
            this.groupBox3.Controls.Add(this.btnMonufacturerAdd);
            this.groupBox3.Controls.Add(this.cmbMonufacturerCountry);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtMonufacturerTitle);
            this.groupBox3.Location = new System.Drawing.Point(18, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 256);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Добавление";
            // 
            // txtMonufacturerSite
            // 
            this.txtMonufacturerSite.Location = new System.Drawing.Point(49, 163);
            this.txtMonufacturerSite.Name = "txtMonufacturerSite";
            this.txtMonufacturerSite.Size = new System.Drawing.Size(165, 20);
            this.txtMonufacturerSite.TabIndex = 7;
            // 
            // btnMonufacturerAdd
            // 
            this.btnMonufacturerAdd.Location = new System.Drawing.Point(84, 196);
            this.btnMonufacturerAdd.Name = "btnMonufacturerAdd";
            this.btnMonufacturerAdd.Size = new System.Drawing.Size(95, 41);
            this.btnMonufacturerAdd.TabIndex = 6;
            this.btnMonufacturerAdd.Text = "Добавить";
            this.btnMonufacturerAdd.UseVisualStyleBackColor = true;
            this.btnMonufacturerAdd.Click += new System.EventHandler(this.btnMonufacturerAdd_Click);
            // 
            // cmbMonufacturerCountry
            // 
            this.cmbMonufacturerCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonufacturerCountry.FormattingEnabled = true;
            this.cmbMonufacturerCountry.Items.AddRange(new object[] {
            "Россия",
            "США",
            "Великобритания",
            "Китай",
            "Япония",
            "Нидерланды",
            "Германия",
            "Франция"});
            this.cmbMonufacturerCountry.Location = new System.Drawing.Point(49, 103);
            this.cmbMonufacturerCountry.Name = "cmbMonufacturerCountry";
            this.cmbMonufacturerCountry.Size = new System.Drawing.Size(165, 21);
            this.cmbMonufacturerCountry.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Сайт";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Страна";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Название";
            // 
            // txtMonufacturerTitle
            // 
            this.txtMonufacturerTitle.Location = new System.Drawing.Point(49, 44);
            this.txtMonufacturerTitle.Name = "txtMonufacturerTitle";
            this.txtMonufacturerTitle.Size = new System.Drawing.Size(165, 20);
            this.txtMonufacturerTitle.TabIndex = 0;
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(308, 426);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "Поиск";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // cbMonufacturerIsEdit
            // 
            this.cbMonufacturerIsEdit.AutoSize = true;
            this.cbMonufacturerIsEdit.Location = new System.Drawing.Point(779, 16);
            this.cbMonufacturerIsEdit.Name = "cbMonufacturerIsEdit";
            this.cbMonufacturerIsEdit.Size = new System.Drawing.Size(155, 17);
            this.cbMonufacturerIsEdit.TabIndex = 1;
            this.cbMonufacturerIsEdit.Text = "Включить редатирование";
            this.cbMonufacturerIsEdit.UseVisualStyleBackColor = true;
            this.cbMonufacturerIsEdit.CheckedChanged += new System.EventHandler(this.cbMonufacturerIsEdit_CheckedChanged);
            // 
            // dgvMonufacturers
            // 
            this.dgvMonufacturers.AllowUserToAddRows = false;
            this.dgvMonufacturers.AutoGenerateColumns = false;
            this.dgvMonufacturers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonufacturers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.titleDataGridViewTextBoxColumn1,
            this.countryDataGridViewTextBoxColumn,
            this.siteDataGridViewTextBoxColumn,
            this.Delete});
            this.dgvMonufacturers.DataSource = this.monufacturerBindingSource;
            this.dgvMonufacturers.Location = new System.Drawing.Point(17, 16);
            this.dgvMonufacturers.Name = "dgvMonufacturers";
            this.dgvMonufacturers.Size = new System.Drawing.Size(641, 475);
            this.dgvMonufacturers.TabIndex = 0;
            this.dgvMonufacturers.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMonufacturers_CellBeginEdit);
            this.dgvMonufacturers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMonufacturers_CellContentClick);
            this.dgvMonufacturers.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMonufacturers_CellEndEdit);
            this.dgvMonufacturers.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.tableValidating);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvSalers);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1016, 497);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Продавцы";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvSalers
            // 
            this.dgvSalers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalers.Location = new System.Drawing.Point(20, 15);
            this.dgvSalers.Name = "dgvSalers";
            this.dgvSalers.Size = new System.Drawing.Size(541, 414);
            this.dgvSalers.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvProducts);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1016, 497);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Продукты";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(25, 19);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(541, 414);
            this.dgvProducts.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgvPriceList);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1016, 497);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Список цен";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgvPriceList
            // 
            this.dgvPriceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceList.Location = new System.Drawing.Point(23, 19);
            this.dgvPriceList.Name = "dgvPriceList";
            this.dgvPriceList.Size = new System.Drawing.Size(541, 414);
            this.dgvPriceList.TabIndex = 1;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Название";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // modelBindingSource1
            // 
            this.modelBindingSource1.DataSource = typeof(PriceList.Classes.Model);
            // 
            // monufacturerBindingSource
            // 
            this.monufacturerBindingSource.DataSource = typeof(PriceList.Classes.Monufacturer);
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            // 
            // titleDataGridViewTextBoxColumn1
            // 
            this.titleDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.titleDataGridViewTextBoxColumn1.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn1.HeaderText = "Название";
            this.titleDataGridViewTextBoxColumn1.Name = "titleDataGridViewTextBoxColumn1";
            this.titleDataGridViewTextBoxColumn1.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "country";
            this.countryDataGridViewTextBoxColumn.HeaderText = "Страна";
            this.countryDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "Россия",
            "США",
            "Великобритания",
            "Китай",
            "Япония",
            "Нидерланды",
            "Германия",
            "Франция"});
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            this.countryDataGridViewTextBoxColumn.ReadOnly = true;
            this.countryDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.countryDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.countryDataGridViewTextBoxColumn.Width = 120;
            // 
            // siteDataGridViewTextBoxColumn
            // 
            this.siteDataGridViewTextBoxColumn.DataPropertyName = "site";
            this.siteDataGridViewTextBoxColumn.HeaderText = "Сайт";
            this.siteDataGridViewTextBoxColumn.Name = "siteDataGridViewTextBoxColumn";
            this.siteDataGridViewTextBoxColumn.ReadOnly = true;
            this.siteDataGridViewTextBoxColumn.Width = 150;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Удаление";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Удалить";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 557);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudModelCount)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModels)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMonufacturerCount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonufacturers)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalers)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monufacturerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dgvMonufacturers;
        private System.Windows.Forms.DataGridView dgvModels;
        private System.Windows.Forms.DataGridView dgvSalers;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridView dgvPriceList;
        private System.Windows.Forms.BindingSource modelBindingSource1;
        private System.Windows.Forms.Button btnModelAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModelTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudModelCount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnModelGenerate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtModelfound;
        private System.Windows.Forms.BindingSource monufacturerBindingSource;
        private System.Windows.Forms.CheckBox cbModelIsEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnDel;
        private System.Windows.Forms.CheckBox cbMonufacturerIsEdit;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbMonufacturerCountry;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMonufacturerTitle;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Button btnMonufacturerAdd;
        private System.Windows.Forms.TextBox txtMonufacturerSite;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnMonufacturerGenerate;
        private System.Windows.Forms.NumericUpDown nudMonufacturerCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}

