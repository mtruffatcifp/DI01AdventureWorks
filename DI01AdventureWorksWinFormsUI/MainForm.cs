using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DI01AdventureWorksWinFormsUI
{
    public partial class MainForm : Form
    {
        private string language;
        private Query lastQuery;
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

            infoToolTip.UseFading = true;
            infoToolTip.UseAnimation = true;
            infoToolTip.IsBalloon = true;
            infoToolTip.ShowAlways = true;
            infoToolTip.AutoPopDelay = 2000;
            infoToolTip.InitialDelay = 0;
            infoToolTip.ReshowDelay = 2000;

            LoadMaxPriceRange();
        }

        private void ShowResults(string lastSql)
        {
            //this.lastSql = lastSql;
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
                    sizeComboBox.Enabled = true;
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
            classComboBox.Items.Clear();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnVal("AdventureWorksDB")))
            {
                var classes = connection.Query<string>($"EXEC spClass_GetAll @Subcategory = '{subcategoryComboBox.SelectedItem.ToString()}';").ToList();
                //MessageBox.Show(classes.Count().ToString());
                if (classes.Count() > 1)
                {
                    classComboBox.Enabled = true;
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
            styleComboBox.Items.Clear();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnVal("AdventureWorksDB")))
            {
                var styles = connection.Query<string>($"EXEC spStyle_GetAll @Subcategory = '{subcategoryComboBox.SelectedItem.ToString()}';").ToList();
                if (styles.Count() > 1)
                {
                    styleComboBox.Enabled = true;
                    foreach (var style in styles) styleComboBox.Items.Add(style);
                }
                else
                {
                    styleComboBox.Enabled = false;
                }
            }
        }

        private void LoadProductLineCombo()
        {
            productLineComboBox.Items.Clear();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnVal("AdventureWorksDB")))
            {
                var plines = connection.Query<string>($"EXEC spProductLine_GetAll @Subcategory = '{subcategoryComboBox.SelectedItem.ToString()}';").ToList();
                if (plines.Count() > 1)
                {
                    productLineComboBox.Enabled = true;
                    foreach (var pline in plines) productLineComboBox.Items.Add(pline);
                }
                else
                {
                    productLineComboBox.Enabled = false;
                }
            }
        }

        private void LoadMaxPriceRange()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnVal("AdventureWorksDB")))
            {
                var maxprice = connection.Query<int>("EXEC spMaxPrice_GetAll;").ToList();
                maxPriceTextBox.Text = maxprice.First().ToString() + "€";
                priceRange.MaximumRange = maxprice.First() + 20;
                priceRange.RangeMin = -20;
            }
        }

        private void LoadAllFilters()
        {
            LoadSizeCombo();
            LoadClassCombo();
            LoadStyleCombo();
            LoadProductLineCombo();
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            lastQuery = new Query(language, categoryComboBox.SelectedItem.ToString(), null, null, null, null, null, onlyavailableProducts);
            ShowResults(lastQuery.ToQuery());
            //ShowResults($"EXEC spGeneric_ShowResult @Idioma = '{language}', @Category = '{categoryComboBox.SelectedItem}', @Availability = {(onlyavailableProducts ? 0 : 1)};");
            subcategoryComboBox.Enabled = true;
            subcategoryComboBox.Text = "";
            LoadSubcategoryCombo();
            firstTime = false;
        }

        private void subcategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            lastQuery = new Query(language, categoryComboBox.SelectedItem.ToString(), subcategoryComboBox.SelectedItem.ToString(), null, null, null, null, onlyavailableProducts);
            ShowResults(lastQuery.ToQuery());
            //ShowResults($"EXEC spGeneric_ShowResult @Idioma = '{language}', @Category = '{categoryComboBox.SelectedItem}', @Subcategory = '{subcategoryComboBox.SelectedItem}', @Availability = {(onlyavailableProducts ? 0 : 1)};");
            LoadAllFilters();
        }

        private void sizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sizeComboBox.SelectedItem != null)
            {
                lastQuery = new Query(language, categoryComboBox.SelectedItem.ToString(), subcategoryComboBox.SelectedItem.ToString(), sizeComboBox.SelectedItem.ToString(), null, null, null, onlyavailableProducts);
                ShowResults(lastQuery.ToQuery());
                //ShowResults($"EXEC spGeneric_ShowResult @Idioma = '{language}', @Category = '{categoryComboBox.SelectedItem}', @Subcategory = '{subcategoryComboBox.SelectedItem}', @Size = '{sizeComboBox.SelectedItem}', @Availability = {(onlyavailableProducts ? 0 : 1)};");
                classComboBox.Enabled = false;
                styleComboBox.Enabled = false;
                productLineComboBox.Enabled = false;
            }
        }

        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (classComboBox.SelectedItem != null)
            {
                lastQuery = new Query(language, categoryComboBox.SelectedItem.ToString(), subcategoryComboBox.SelectedItem.ToString(), null, classComboBox.SelectedItem.ToString(), null, null, onlyavailableProducts);
                ShowResults(lastQuery.ToQuery());
                sizeComboBox.Enabled = false;
                styleComboBox.Enabled = false;
                productLineComboBox.Enabled = false;
            }
        }

        private void styleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (styleComboBox.SelectedItem != null)
            {
                lastQuery = new Query(language, categoryComboBox.SelectedItem.ToString(), subcategoryComboBox.SelectedItem.ToString(), null, null, styleComboBox.SelectedItem.ToString(), null, onlyavailableProducts);
                ShowResults(lastQuery.ToQuery());
                sizeComboBox.Enabled = false;
                classComboBox.Enabled = false;
                productLineComboBox.Enabled = false;
            }
        }

        private void productLineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productLineComboBox.SelectedItem != null)
            {
                lastQuery = new Query(language, categoryComboBox.SelectedItem.ToString(), subcategoryComboBox.SelectedItem.ToString(), null, null, null, productLineComboBox.SelectedItem.ToString(), onlyavailableProducts);
                ShowResults(lastQuery.ToQuery());
                sizeComboBox.Enabled = false;
                classComboBox.Enabled = false;
                styleComboBox.Enabled = false;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAllFilters();
            searchTextBox.Clear();
            LoadCategoryCombo();
            DisableFilters();
        }

        private void ClearAllFilters()
        {
            resultListView.Items.Clear();
            categoryComboBox.Items.Clear();
            subcategoryComboBox.Items.Clear();
            sizeComboBox.Items.Clear();
            classComboBox.Items.Clear();
            styleComboBox.Items.Clear();
            productLineComboBox.Items.Clear();
        }
        private void DisableFilters()
        {
            sizeComboBox.Enabled = false;
            classComboBox.Enabled = false;
            styleComboBox.Enabled = false;
            productLineComboBox.Enabled = false;
        }
        private void EnableFilters()
        {
            sizeComboBox.Enabled = true;
            classComboBox.Enabled = true;
            styleComboBox.Enabled = true;
            productLineComboBox.Enabled = true;
        }

        private void sizeComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                sizeComboBox.SelectedItem = null;
                EnableFilters();
                subcategoryComboBox_SelectedIndexChanged(sender, e);
            }
        }

        private void classComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                classComboBox.SelectedItem = null;
                EnableFilters();
                subcategoryComboBox_SelectedIndexChanged(sender, e);
            }
        }

        private void styleComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                styleComboBox.SelectedItem = null;
                EnableFilters();
                subcategoryComboBox_SelectedIndexChanged(sender, e);
            }
        }

        private void productLineComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                productLineComboBox.SelectedItem = null;
                EnableFilters();
                subcategoryComboBox_SelectedIndexChanged(sender, e);
            }
        }

        private void availabilityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (onlyavailableProducts)
            {
                onlyavailableProducts = false;
                if (!firstTime)
                {
                    lastQuery.Availability = false;
                    ShowResults(lastQuery.ToQuery());
                }
            }
            else
            {
                onlyavailableProducts = true;
                if (!firstTime)
                {
                    lastQuery.Availability = true;
                    ShowResults(lastQuery.ToQuery());
                }
            }
        }

        private void priceRange_RangeChanged(object sender, EventArgs e)
        {
            maxPriceTextBox.Text = priceRange.RangeMax.ToString() + "€";
            minPriceTextBox.Text = priceRange.RangeMin.ToString() + "€";
        }

        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (languageComboBox.SelectedItem.ToString() == "French")
            {
                language = "fr";
            }
            else
            {
                language = "en";
            }
            if (!firstTime)
            {
                lastQuery.Language = language;
                ShowResults(lastQuery.ToQuery());
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            ClearAllFilters();
            LoadCategoryCombo();
            DisableFilters();
        }

        private void resultListView_DoubleClick(object sender, EventArgs e)
        {
            string selectedProduct = resultListView.SelectedItems[0].Text;
            DetailProduct dproduct = new DetailProduct(lastQuery);
            dproduct.ShowDialog();
        }

    }
}
