﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DI01AdventureWorksWinFormsUI
{
    public partial class MainForm : Form
    {
        private string lastSql, language;
        private bool onlyavailableProducts = true;
        private bool firstTime = true;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadCategoryCombo();
            languageComboBox.Text = "English";
            language = "en";

            sizeComboBox.Enabled = false;
            classComboBox.Enabled = false;
            styleComboBox.Enabled = false;
            productLineComboBox.Enabled = false;
        }

        private void ShowResults(string lastSql)
        {
            this.lastSql = lastSql;
            resultListView.Items.Clear();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnVal("AdventureWorksDB")))
            {
                List<ProductModel> results = new List<ProductModel>();
                results = connection.Query<ProductModel>(lastSql).ToList();
                foreach (var result in results)
                {
                    ListViewItem item = new ListViewItem(result.Name);
                    item.SubItems.Add(result.Description);
                    resultListView.Items.Add(item);
                }
            }
        }

        private void LoadCategoryCombo()
        {
            subcategoryComboBox.Enabled = false;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnVal("AdventureWorksDB")))
            {
                var categories = connection.Query<string>("EXEC spCategory_GetAll").ToList();
                foreach (var category in categories) categoryComboBox.Items.Add(category);
            }
        }

        private void LoadSubcategoryCombo()
        {
            subcategoryComboBox.Items.Clear();
            sizeComboBox.Items.Clear();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnVal("AdventureWorksDB")))
            {
                var subcategories = connection.Query<string>($"EXEC spSubcategory_GetAll '{categoryComboBox.SelectedItem.ToString()}'").ToList();
                foreach (var subcategory in subcategories) subcategoryComboBox.Items.Add(subcategory);
            }
        }

        private void LoadSizeCombo()
        {
            sizeComboBox.Items.Clear();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnVal("AdventureWorksDB")))
            {
                var sizes = connection.Query<string>($"EXEC spSize_GetAll '{categoryComboBox.SelectedItem.ToString()}', '{subcategoryComboBox.SelectedItem.ToString()}'").ToList();
                if (sizes.Count() > 1)
                {
                    foreach (var size in sizes) sizeComboBox.Items.Add(size);
                }
                else
                {
                    sizeComboBox.Enabled = false;
                }
            }
        }

        private void LoadClassCombo()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnVal("AdventureWorksDB")))
            {
                var classes = connection.Query<string>($"EXEC spClass_GetAll @Subcategory = '{subcategoryComboBox.SelectedItem.ToString()}';").ToList();
                if (classes.Count() > 1)
                {
                    foreach (var clas in classes) classComboBox.Items.Add(clas);
                }
                else
                {
                    classComboBox.Enabled = false;
                }
            }
        }

        private void LoadStyleCombo()
        {

        }

        private void LoadProductLineCombo()
        {

        }

        private void LoadAllFilters()
        {
            sizeComboBox.Enabled = true;
            classComboBox.Enabled = true;
            styleComboBox.Enabled = true;
            productLineComboBox.Enabled = true;
            LoadSizeCombo();
            LoadClassCombo();
            LoadSizeCombo();
            LoadProductLineCombo();
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowResults($"EXEC spGeneric_ShowResult @Idioma = '{language}', @Category = '{categoryComboBox.SelectedItem}', @Availability = {(onlyavailableProducts ? 0 : 1)};");
            subcategoryComboBox.Enabled = true;
            subcategoryComboBox.Text = "";
            LoadSubcategoryCombo();
            firstTime = false;
        }

        private void subcategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowResults($"EXEC spGeneric_ShowResult @Idioma = '{language}', @Category = '{categoryComboBox.SelectedItem}', @Subcategory = '{subcategoryComboBox.SelectedItem}', @Availability = {(onlyavailableProducts ? 0 : 1)};");
            LoadAllFilters();
            searchTextBox.Text = new Query(language, categoryComboBox.SelectedItem.ToString(), subcategoryComboBox.SelectedItem.ToString(), null, null, null, null, true).ToQuery();
        }

        private void sizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sizeComboBox.SelectedItem != null)
            {
                ShowResults($"EXEC spGeneric_ShowResult @Idioma = '{language}', @Category = '{categoryComboBox.SelectedItem}', @Subcategory = '{subcategoryComboBox.SelectedItem}', @Size = '{sizeComboBox.SelectedItem}', @Availability = {(onlyavailableProducts ? 0 : 1)};");
                classComboBox.Enabled = false;
                styleComboBox.Enabled = false;
                productLineComboBox.Enabled = false;
            }
        }

        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (classComboBox.SelectedItem != null)
            {
                ShowResults($"EXEC spGeneric_ShowResult @Idioma = {language}, @Category = '{categoryComboBox.SelectedItem}', @Subcategory = '{subcategoryComboBox.SelectedItem}', @Class = '{classComboBox.SelectedItem}', @Availability = {(onlyavailableProducts ? 0 : 1)};");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            resultListView.Items.Clear();
            categoryComboBox.Items.Clear();
            subcategoryComboBox.Items.Clear();
            sizeComboBox.Items.Clear();
            LoadCategoryCombo();
            sizeComboBox.Enabled = false;
            classComboBox.Enabled = false;
            styleComboBox.Enabled = false;
            productLineComboBox.Enabled = false;
        }

        private void languageChange()
        {
        }
        private void productLineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sizeComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                sizeComboBox.SelectedItem = null;
            }
        }

        private void classComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                classComboBox.SelectedItem = null;
            }
        }

        private void availabilityCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (onlyavailableProducts)
            {
                onlyavailableProducts = false;
                if (!firstTime)
                {
                    ShowResults(lastSql.Replace("0", "1"));
                }
            }
            else
            {
                onlyavailableProducts = true;
                if (!firstTime)
                {
                    ShowResults(lastSql.Replace("1", "0"));
                }
            }
        }



        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!firstTime)
            {
                if (languageComboBox.SelectedItem.ToString() == "French")
                {
                    language = "fr";
                    //ShowResults(lastSql.Replace("'en'", "'fr'"));
                }
                else
                {
                    language = "en";
                    //ShowResults(lastSql.Replace("'fr'", "'en'"));
                }
            }
        }
    }
}
