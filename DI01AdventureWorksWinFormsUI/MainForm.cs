using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI01AdventureWorksWinFormsUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadCategoryCombo();
            //categoryComboBox.Items.AddRange();
        }

        private void LoadCategoryCombo()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnVal("AdventureWorksDB")))
            {
                var categories = connection.Query<string>("EXEC spCategory_GetAll").ToList();
                foreach (var category in categories) categoryComboBox.Items.Add(category);
            }
        }

        private void LoadSubcategoryCombo()
        {
            subcategoryComboBox.Items.Clear();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnVal("AdventureWorksDB")))
            {
                var subcategories = connection.Query<string>($"EXEC spSubcategory_GetAll '{categoryComboBox.SelectedItem.ToString()}'").ToList();
                foreach (var subcategory in subcategories) subcategoryComboBox.Items.Add(subcategory);
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultListView.Items.Clear();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnVal("AdventureWorksDB")))
            {
                List<ProductModel> results = new List<ProductModel>();
                results = connection.Query<ProductModel>($"EXEC spCategory_ShowResult 'en', '{categoryComboBox.SelectedItem}'").ToList();
                foreach (var result in results)
                {
                    resultListView.Items.Add(result.Name + " | " + result.Description);
                }
            }
            LoadSubcategoryCombo();
        }

        private void subcategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultListView.Items.Clear();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnVal("AdventureWorksDB")))
            {
                List<ProductModel> results = new List<ProductModel>();
                results = connection.Query<ProductModel>($"EXEC spSubcategory_ShowResult 'en', '{categoryComboBox.SelectedItem}', '{subcategoryComboBox.SelectedItem}';").ToList();
                foreach (var result in results)
                {
                    resultListView.Items.Add(result.Name + " | " + result.Description);
                }
            }
        }
    }
}
