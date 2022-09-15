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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvMonufacturers = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnModelDelete = new System.Windows.Forms.Button();
            this.dgvModels = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvSalers = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvPriceList = new System.Windows.Forms.DataGridView();
            this.btnModelUpdate = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonufacturers)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModels)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalers)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(970, 523);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvMonufacturers);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(962, 497);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Производители";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvMonufacturers
            // 
            this.dgvMonufacturers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonufacturers.Location = new System.Drawing.Point(17, 16);
            this.dgvMonufacturers.Name = "dgvMonufacturers";
            this.dgvMonufacturers.Size = new System.Drawing.Size(541, 414);
            this.dgvMonufacturers.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnModelUpdate);
            this.tabPage2.Controls.Add(this.btnModelDelete);
            this.tabPage2.Controls.Add(this.dgvModels);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(962, 497);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Модели";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnModelDelete
            // 
            this.btnModelDelete.Enabled = false;
            this.btnModelDelete.Location = new System.Drawing.Point(6, 448);
            this.btnModelDelete.Name = "btnModelDelete";
            this.btnModelDelete.Size = new System.Drawing.Size(96, 33);
            this.btnModelDelete.TabIndex = 2;
            this.btnModelDelete.Text = "Удалить";
            this.btnModelDelete.UseVisualStyleBackColor = true;
            this.btnModelDelete.Click += new System.EventHandler(this.btnModelDelete_Click);
            // 
            // dgvModels
            // 
            this.dgvModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModels.Location = new System.Drawing.Point(6, 18);
            this.dgvModels.Name = "dgvModels";
            this.dgvModels.Size = new System.Drawing.Size(541, 414);
            this.dgvModels.TabIndex = 1;
            this.dgvModels.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModels_CellClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvSalers);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(962, 497);
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
            this.tabPage4.Size = new System.Drawing.Size(962, 497);
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
            this.tabPage5.Size = new System.Drawing.Size(962, 497);
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
            // btnModelUpdate
            // 
            this.btnModelUpdate.Enabled = false;
            this.btnModelUpdate.Location = new System.Drawing.Point(126, 448);
            this.btnModelUpdate.Name = "btnModelUpdate";
            this.btnModelUpdate.Size = new System.Drawing.Size(84, 33);
            this.btnModelUpdate.TabIndex = 3;
            this.btnModelUpdate.Text = "Изменить";
            this.btnModelUpdate.UseVisualStyleBackColor = true;
            this.btnModelUpdate.Click += new System.EventHandler(this.btnModelUpdate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 557);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonufacturers)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModels)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalers)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceList)).EndInit();
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
        private System.Windows.Forms.Button btnModelDelete;
        private System.Windows.Forms.Button btnModelUpdate;
    }
}

