namespace DI01AdventureWorksWinFormsUI
{
    partial class MainForm
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
            this.resultListView = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descriptionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.subcategoryComboBox = new System.Windows.Forms.ComboBox();
            this.subcategoryLabel = new System.Windows.Forms.Label();
            this.sizeComboBox = new System.Windows.Forms.ComboBox();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.styleComboBox = new System.Windows.Forms.ComboBox();
            this.styleLabel = new System.Windows.Forms.Label();
            this.classComboBox = new System.Windows.Forms.ComboBox();
            this.classLabel = new System.Windows.Forms.Label();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.filtersPanel = new System.Windows.Forms.Panel();
            this.priceRange = new Bunifu.Framework.UI.BunifuRange();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.productLineLabel = new System.Windows.Forms.Label();
            this.productLineComboBox = new System.Windows.Forms.ComboBox();
            this.maxPriceTextBox = new System.Windows.Forms.TextBox();
            this.minPriceTextBox = new System.Windows.Forms.TextBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.availabilityCheckBox = new System.Windows.Forms.CheckBox();
            this.euroLabel2 = new System.Windows.Forms.Label();
            this.euroLabel1 = new System.Windows.Forms.Label();
            this.priceRangeLabel = new System.Windows.Forms.Label();
            this.searchLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.infoToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.filtersPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // resultListView
            // 
            this.resultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.descriptionColumnHeader});
            this.resultListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultListView.HideSelection = false;
            this.resultListView.Location = new System.Drawing.Point(0, 0);
            this.resultListView.MultiSelect = false;
            this.resultListView.Name = "resultListView";
            this.resultListView.Size = new System.Drawing.Size(1066, 439);
            this.resultListView.TabIndex = 0;
            this.resultListView.UseCompatibleStateImageBehavior = false;
            this.resultListView.View = System.Windows.Forms.View.Details;
            this.resultListView.DoubleClick += new System.EventHandler(this.resultListView_DoubleClick);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 150;
            // 
            // descriptionColumnHeader
            // 
            this.descriptionColumnHeader.Text = "Description";
            this.descriptionColumnHeader.Width = 690;
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLabel.ForeColor = System.Drawing.Color.Black;
            this.categoryLabel.Location = new System.Drawing.Point(6, 7);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(64, 17);
            this.categoryLabel.TabIndex = 1;
            this.categoryLabel.Text = "Category:";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.BackColor = System.Drawing.Color.White;
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryComboBox.ForeColor = System.Drawing.Color.Black;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(9, 32);
            this.categoryComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(109, 25);
            this.categoryComboBox.TabIndex = 2;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // subcategoryComboBox
            // 
            this.subcategoryComboBox.BackColor = System.Drawing.Color.White;
            this.subcategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subcategoryComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subcategoryComboBox.ForeColor = System.Drawing.Color.Black;
            this.subcategoryComboBox.FormattingEnabled = true;
            this.subcategoryComboBox.Location = new System.Drawing.Point(137, 32);
            this.subcategoryComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.subcategoryComboBox.Name = "subcategoryComboBox";
            this.subcategoryComboBox.Size = new System.Drawing.Size(106, 25);
            this.subcategoryComboBox.TabIndex = 4;
            this.subcategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.subcategoryComboBox_SelectedIndexChanged);
            // 
            // subcategoryLabel
            // 
            this.subcategoryLabel.AutoSize = true;
            this.subcategoryLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subcategoryLabel.ForeColor = System.Drawing.Color.Black;
            this.subcategoryLabel.Location = new System.Drawing.Point(131, 7);
            this.subcategoryLabel.Name = "subcategoryLabel";
            this.subcategoryLabel.Size = new System.Drawing.Size(84, 17);
            this.subcategoryLabel.TabIndex = 3;
            this.subcategoryLabel.Text = "Subcategory:";
            // 
            // sizeComboBox
            // 
            this.sizeComboBox.BackColor = System.Drawing.Color.White;
            this.sizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeComboBox.ForeColor = System.Drawing.Color.Black;
            this.sizeComboBox.FormattingEnabled = true;
            this.sizeComboBox.Items.AddRange(new object[] {
            "None"});
            this.sizeComboBox.Location = new System.Drawing.Point(10, 35);
            this.sizeComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.sizeComboBox.Name = "sizeComboBox";
            this.sizeComboBox.Size = new System.Drawing.Size(50, 25);
            this.sizeComboBox.TabIndex = 6;
            this.sizeComboBox.SelectedIndexChanged += new System.EventHandler(this.sizeComboBox_SelectedIndexChanged);
            this.sizeComboBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sizeComboBox_MouseDown);
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.sizeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeLabel.ForeColor = System.Drawing.Color.Black;
            this.sizeLabel.Location = new System.Drawing.Point(7, 10);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(34, 17);
            this.sizeLabel.TabIndex = 5;
            this.sizeLabel.Text = "Size:";
            // 
            // styleComboBox
            // 
            this.styleComboBox.BackColor = System.Drawing.Color.White;
            this.styleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.styleComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleComboBox.ForeColor = System.Drawing.Color.Black;
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Location = new System.Drawing.Point(146, 35);
            this.styleComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(50, 25);
            this.styleComboBox.TabIndex = 8;
            this.styleComboBox.SelectedIndexChanged += new System.EventHandler(this.styleComboBox_SelectedIndexChanged);
            this.styleComboBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.styleComboBox_MouseDown);
            // 
            // styleLabel
            // 
            this.styleLabel.AutoSize = true;
            this.styleLabel.BackColor = System.Drawing.Color.Transparent;
            this.styleLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleLabel.ForeColor = System.Drawing.Color.Black;
            this.styleLabel.Location = new System.Drawing.Point(143, 10);
            this.styleLabel.Name = "styleLabel";
            this.styleLabel.Size = new System.Drawing.Size(38, 17);
            this.styleLabel.TabIndex = 7;
            this.styleLabel.Text = "Style:";
            // 
            // classComboBox
            // 
            this.classComboBox.BackColor = System.Drawing.Color.White;
            this.classComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classComboBox.ForeColor = System.Drawing.Color.Black;
            this.classComboBox.FormattingEnabled = true;
            this.classComboBox.Location = new System.Drawing.Point(78, 35);
            this.classComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.classComboBox.Name = "classComboBox";
            this.classComboBox.Size = new System.Drawing.Size(50, 25);
            this.classComboBox.TabIndex = 10;
            this.classComboBox.SelectedIndexChanged += new System.EventHandler(this.classComboBox_SelectedIndexChanged);
            this.classComboBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.classComboBox_MouseDown);
            // 
            // classLabel
            // 
            this.classLabel.AutoSize = true;
            this.classLabel.BackColor = System.Drawing.Color.Transparent;
            this.classLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classLabel.ForeColor = System.Drawing.Color.Black;
            this.classLabel.Location = new System.Drawing.Point(75, 10);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(41, 17);
            this.classLabel.TabIndex = 9;
            this.classLabel.Text = "Class:";
            // 
            // languageComboBox
            // 
            this.languageComboBox.BackColor = System.Drawing.Color.White;
            this.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.languageComboBox.ForeColor = System.Drawing.Color.Black;
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Items.AddRange(new object[] {
            "English",
            "French"});
            this.languageComboBox.Location = new System.Drawing.Point(984, 72);
            this.languageComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(65, 25);
            this.languageComboBox.TabIndex = 12;
            this.languageComboBox.SelectedIndexChanged += new System.EventHandler(this.languageComboBox_SelectedIndexChanged);
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.languageLabel.ForeColor = System.Drawing.Color.Black;
            this.languageLabel.Location = new System.Drawing.Point(904, 76);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(68, 17);
            this.languageLabel.TabIndex = 9;
            this.languageLabel.Text = "Language:";
            // 
            // filtersPanel
            // 
            this.filtersPanel.BackColor = System.Drawing.Color.White;
            this.filtersPanel.Controls.Add(this.priceRange);
            this.filtersPanel.Controls.Add(this.groupBox1);
            this.filtersPanel.Controls.Add(this.maxPriceTextBox);
            this.filtersPanel.Controls.Add(this.minPriceTextBox);
            this.filtersPanel.Controls.Add(this.searchTextBox);
            this.filtersPanel.Controls.Add(this.clearButton);
            this.filtersPanel.Controls.Add(this.availabilityCheckBox);
            this.filtersPanel.Controls.Add(this.categoryComboBox);
            this.filtersPanel.Controls.Add(this.euroLabel2);
            this.filtersPanel.Controls.Add(this.euroLabel1);
            this.filtersPanel.Controls.Add(this.priceRangeLabel);
            this.filtersPanel.Controls.Add(this.categoryLabel);
            this.filtersPanel.Controls.Add(this.languageComboBox);
            this.filtersPanel.Controls.Add(this.subcategoryLabel);
            this.filtersPanel.Controls.Add(this.searchLabel);
            this.filtersPanel.Controls.Add(this.subcategoryComboBox);
            this.filtersPanel.Controls.Add(this.languageLabel);
            this.filtersPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filtersPanel.Location = new System.Drawing.Point(0, 0);
            this.filtersPanel.Name = "filtersPanel";
            this.filtersPanel.Size = new System.Drawing.Size(1066, 111);
            this.filtersPanel.TabIndex = 13;
            // 
            // priceRange
            // 
            this.priceRange.BackColor = System.Drawing.Color.Transparent;
            this.priceRange.BackgroudColor = System.Drawing.Color.DarkGray;
            this.priceRange.BorderRadius = 0;
            this.priceRange.IndicatorColor = System.Drawing.Color.RoyalBlue;
            this.priceRange.Location = new System.Drawing.Point(651, 32);
            this.priceRange.MaximumRange = 100;
            this.priceRange.Name = "priceRange";
            this.priceRange.RangeMax = 49;
            this.priceRange.RangeMin = 0;
            this.priceRange.Size = new System.Drawing.Size(242, 30);
            this.priceRange.TabIndex = 21;
            this.priceRange.RangeChanged += new System.EventHandler(this.priceRange_RangeChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.sizeComboBox);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.styleLabel);
            this.groupBox1.Controls.Add(this.styleComboBox);
            this.groupBox1.Controls.Add(this.classLabel);
            this.groupBox1.Controls.Add(this.sizeLabel);
            this.groupBox1.Controls.Add(this.productLineLabel);
            this.groupBox1.Controls.Add(this.classComboBox);
            this.groupBox1.Controls.Add(this.productLineComboBox);
            this.groupBox1.Location = new System.Drawing.Point(259, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(300, 66);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // productLineLabel
            // 
            this.productLineLabel.AutoSize = true;
            this.productLineLabel.BackColor = System.Drawing.Color.Transparent;
            this.productLineLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productLineLabel.ForeColor = System.Drawing.Color.Black;
            this.productLineLabel.Location = new System.Drawing.Point(212, 10);
            this.productLineLabel.Name = "productLineLabel";
            this.productLineLabel.Size = new System.Drawing.Size(83, 17);
            this.productLineLabel.TabIndex = 9;
            this.productLineLabel.Text = "Product Line:";
            // 
            // productLineComboBox
            // 
            this.productLineComboBox.BackColor = System.Drawing.Color.White;
            this.productLineComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productLineComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productLineComboBox.ForeColor = System.Drawing.Color.Black;
            this.productLineComboBox.FormattingEnabled = true;
            this.productLineComboBox.Location = new System.Drawing.Point(215, 35);
            this.productLineComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.productLineComboBox.Name = "productLineComboBox";
            this.productLineComboBox.Size = new System.Drawing.Size(50, 25);
            this.productLineComboBox.TabIndex = 12;
            this.productLineComboBox.SelectedIndexChanged += new System.EventHandler(this.productLineComboBox_SelectedIndexChanged);
            this.productLineComboBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.productLineComboBox_MouseDown);
            // 
            // maxPriceTextBox
            // 
            this.maxPriceTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.maxPriceTextBox.Location = new System.Drawing.Point(906, 32);
            this.maxPriceTextBox.Name = "maxPriceTextBox";
            this.maxPriceTextBox.Size = new System.Drawing.Size(44, 25);
            this.maxPriceTextBox.TabIndex = 15;
            // 
            // minPriceTextBox
            // 
            this.minPriceTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.minPriceTextBox.Location = new System.Drawing.Point(589, 32);
            this.minPriceTextBox.Name = "minPriceTextBox";
            this.minPriceTextBox.Size = new System.Drawing.Size(44, 25);
            this.minPriceTextBox.TabIndex = 15;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.searchTextBox.Location = new System.Drawing.Point(72, 68);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(204, 25);
            this.searchTextBox.TabIndex = 15;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Gainsboro;
            this.clearButton.FlatAppearance.BorderSize = 0;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Location = new System.Drawing.Point(984, 9);
            this.clearButton.Margin = new System.Windows.Forms.Padding(0);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(65, 46);
            this.clearButton.TabIndex = 14;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // availabilityCheckBox
            // 
            this.availabilityCheckBox.AutoSize = true;
            this.availabilityCheckBox.Checked = true;
            this.availabilityCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.availabilityCheckBox.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.availabilityCheckBox.Location = new System.Drawing.Point(306, 72);
            this.availabilityCheckBox.Name = "availabilityCheckBox";
            this.availabilityCheckBox.Size = new System.Drawing.Size(141, 21);
            this.availabilityCheckBox.TabIndex = 13;
            this.availabilityCheckBox.Text = "Show only available";
            this.availabilityCheckBox.UseVisualStyleBackColor = true;
            this.availabilityCheckBox.CheckedChanged += new System.EventHandler(this.availabilityCheckBox_CheckedChanged);
            // 
            // euroLabel2
            // 
            this.euroLabel2.AutoSize = true;
            this.euroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.euroLabel2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.euroLabel2.ForeColor = System.Drawing.Color.Black;
            this.euroLabel2.Location = new System.Drawing.Point(950, 34);
            this.euroLabel2.Name = "euroLabel2";
            this.euroLabel2.Size = new System.Drawing.Size(19, 21);
            this.euroLabel2.TabIndex = 9;
            this.euroLabel2.Text = "€";
            // 
            // euroLabel1
            // 
            this.euroLabel1.AutoSize = true;
            this.euroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.euroLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.euroLabel1.ForeColor = System.Drawing.Color.Black;
            this.euroLabel1.Location = new System.Drawing.Point(631, 34);
            this.euroLabel1.Name = "euroLabel1";
            this.euroLabel1.Size = new System.Drawing.Size(19, 21);
            this.euroLabel1.TabIndex = 9;
            this.euroLabel1.Text = "€";
            // 
            // priceRangeLabel
            // 
            this.priceRangeLabel.AutoSize = true;
            this.priceRangeLabel.BackColor = System.Drawing.Color.Transparent;
            this.priceRangeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceRangeLabel.ForeColor = System.Drawing.Color.Black;
            this.priceRangeLabel.Location = new System.Drawing.Point(586, 7);
            this.priceRangeLabel.Name = "priceRangeLabel";
            this.priceRangeLabel.Size = new System.Drawing.Size(80, 17);
            this.priceRangeLabel.TabIndex = 9;
            this.priceRangeLabel.Text = "Price Range:";
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLabel.ForeColor = System.Drawing.Color.Black;
            this.searchLabel.Location = new System.Drawing.Point(6, 71);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(50, 17);
            this.searchLabel.TabIndex = 9;
            this.searchLabel.Text = "Search:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.resultListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1066, 439);
            this.panel2.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DI01AdventureWorksWinFormsUI.Properties.Resources.info1;
            this.pictureBox1.Location = new System.Drawing.Point(280, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(13, 13);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.infoToolTip.SetToolTip(this.pictureBox1, "Right click on the filter to remove it.");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1066, 550);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.filtersPanel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdventureWorks";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.filtersPanel.ResumeLayout(false);
            this.filtersPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView resultListView;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.ComboBox subcategoryComboBox;
        private System.Windows.Forms.Label subcategoryLabel;
        private System.Windows.Forms.ComboBox sizeComboBox;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.ComboBox styleComboBox;
        private System.Windows.Forms.Label styleLabel;
        private System.Windows.Forms.ComboBox classComboBox;
        private System.Windows.Forms.Label classLabel;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.Panel filtersPanel;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader descriptionColumnHeader;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox availabilityCheckBox;
        private System.Windows.Forms.ComboBox productLineComboBox;
        private System.Windows.Forms.Label productLineLabel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip infoToolTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label priceRangeLabel;
        private Bunifu.Framework.UI.BunifuRange priceRange;
        private System.Windows.Forms.TextBox maxPriceTextBox;
        private System.Windows.Forms.TextBox minPriceTextBox;
        private System.Windows.Forms.Label euroLabel2;
        private System.Windows.Forms.Label euroLabel1;
    }
}

