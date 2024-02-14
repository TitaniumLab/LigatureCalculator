namespace LigatureCalculator
{
    partial class SelectLigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectLigForm));
            this.selectGridView = new System.Windows.Forms.DataGridView();
            this.ligatureNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zrCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nbCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.createLig = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.cencelButton = new System.Windows.Forms.Button();
            this.chooseLigFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.selectGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chooseLigFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // selectGridView
            // 
            this.selectGridView.AllowUserToAddRows = false;
            this.selectGridView.AllowUserToDeleteRows = false;
            this.selectGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ligatureNameCol,
            this.tiCol,
            this.AlCol,
            this.moCol,
            this.zrCol,
            this.nbCol,
            this.wCol,
            this.snCol,
            this.siCol,
            this.feCol,
            this.vCol,
            this.cCol,
            this.crCol,
            this.oCol,
            this.nCol,
            this.checkCol});
            this.selectGridView.Location = new System.Drawing.Point(12, 12);
            this.selectGridView.Name = "selectGridView";
            this.selectGridView.Size = new System.Drawing.Size(731, 342);
            this.selectGridView.TabIndex = 1;
            // 
            // ligatureNameCol
            // 
            this.ligatureNameCol.HeaderText = "Лигатура";
            this.ligatureNameCol.Name = "ligatureNameCol";
            this.ligatureNameCol.ReadOnly = true;
            this.ligatureNameCol.Width = 70;
            // 
            // tiCol
            // 
            this.tiCol.HeaderText = "Ti";
            this.tiCol.Name = "tiCol";
            this.tiCol.ReadOnly = true;
            this.tiCol.Width = 40;
            // 
            // AlCol
            // 
            this.AlCol.HeaderText = "Al";
            this.AlCol.Name = "AlCol";
            this.AlCol.ReadOnly = true;
            this.AlCol.Width = 40;
            // 
            // moCol
            // 
            this.moCol.HeaderText = "Mo";
            this.moCol.Name = "moCol";
            this.moCol.ReadOnly = true;
            this.moCol.Width = 40;
            // 
            // zrCol
            // 
            this.zrCol.HeaderText = "Zr";
            this.zrCol.Name = "zrCol";
            this.zrCol.ReadOnly = true;
            this.zrCol.Width = 40;
            // 
            // nbCol
            // 
            this.nbCol.HeaderText = "Nb";
            this.nbCol.Name = "nbCol";
            this.nbCol.ReadOnly = true;
            this.nbCol.Width = 40;
            // 
            // wCol
            // 
            this.wCol.HeaderText = "W";
            this.wCol.Name = "wCol";
            this.wCol.ReadOnly = true;
            this.wCol.Width = 40;
            // 
            // snCol
            // 
            this.snCol.HeaderText = "Sn";
            this.snCol.Name = "snCol";
            this.snCol.ReadOnly = true;
            this.snCol.Width = 40;
            // 
            // siCol
            // 
            this.siCol.HeaderText = "Si";
            this.siCol.Name = "siCol";
            this.siCol.ReadOnly = true;
            this.siCol.Width = 40;
            // 
            // feCol
            // 
            this.feCol.HeaderText = "Fe";
            this.feCol.Name = "feCol";
            this.feCol.ReadOnly = true;
            this.feCol.Width = 40;
            // 
            // vCol
            // 
            this.vCol.HeaderText = "V";
            this.vCol.Name = "vCol";
            this.vCol.ReadOnly = true;
            this.vCol.Width = 40;
            // 
            // cCol
            // 
            this.cCol.HeaderText = "C";
            this.cCol.Name = "cCol";
            this.cCol.ReadOnly = true;
            this.cCol.Width = 40;
            // 
            // crCol
            // 
            this.crCol.HeaderText = "Cr";
            this.crCol.Name = "crCol";
            this.crCol.ReadOnly = true;
            this.crCol.Width = 40;
            // 
            // oCol
            // 
            this.oCol.HeaderText = "O";
            this.oCol.Name = "oCol";
            this.oCol.ReadOnly = true;
            this.oCol.Width = 40;
            // 
            // nCol
            // 
            this.nCol.HeaderText = "N";
            this.nCol.Name = "nCol";
            this.nCol.ReadOnly = true;
            this.nCol.Width = 40;
            // 
            // checkCol
            // 
            this.checkCol.HeaderText = "";
            this.checkCol.Name = "checkCol";
            this.checkCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.checkCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.checkCol.Width = 40;
            // 
            // createLig
            // 
            this.createLig.AutoSize = true;
            this.createLig.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createLig.Location = new System.Drawing.Point(749, 12);
            this.createLig.Name = "createLig";
            this.createLig.Size = new System.Drawing.Size(85, 30);
            this.createLig.TabIndex = 2;
            this.createLig.Text = "Создать";
            this.createLig.UseVisualStyleBackColor = true;
            this.createLig.MouseClick += new System.Windows.Forms.MouseEventHandler(this.createLig_MouseClick);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteButton.Location = new System.Drawing.Point(749, 48);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(85, 30);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteLigature);
            // 
            // selectButton
            // 
            this.selectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectButton.Location = new System.Drawing.Point(749, 288);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(85, 30);
            this.selectButton.TabIndex = 4;
            this.selectButton.Text = "Выбрать";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // cencelButton
            // 
            this.cencelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cencelButton.Location = new System.Drawing.Point(749, 324);
            this.cencelButton.Name = "cencelButton";
            this.cencelButton.Size = new System.Drawing.Size(85, 30);
            this.cencelButton.TabIndex = 5;
            this.cencelButton.Text = "Отмена";
            this.cencelButton.UseVisualStyleBackColor = true;
            this.cencelButton.Click += new System.EventHandler(this.cencelButton_Click);
            // 
            // chooseLigFormBindingSource
            // 
            this.chooseLigFormBindingSource.DataSource = typeof(LigatureCalculator.SelectLigForm);
            // 
            // SelectLigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 366);
            this.Controls.Add(this.cencelButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.createLig);
            this.Controls.Add(this.selectGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SelectLigForm";
            this.Text = "ChooseLigForm";
            this.Load += new System.EventHandler(this.ChooseLigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.selectGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chooseLigFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button createLig;
        private System.Windows.Forms.BindingSource chooseLigFormBindingSource;
        public System.Windows.Forms.DataGridView selectGridView;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ligatureNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn moCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn zrCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nbCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn wCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn snCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn siCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn feCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn vCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn crCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn oCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkCol;
        private System.Windows.Forms.Button cencelButton;
    }
}