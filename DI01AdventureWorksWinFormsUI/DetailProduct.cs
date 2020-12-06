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
    public partial class DetailProduct : Form
    {
        private Query query;
        public DetailProduct(Query query)
        {
            InitializeComponent();
            this.query = query;
        }

        private void DetailProduct_Load(object sender, EventArgs e)
        {
            //using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnVal("AdventureWorksDB")))
            //{
            //    var details = connection.Query<string>("SELECT DISTINCT Production.Product.Color FROM Production.Product WHERE Production.Product.Name").FirstOrDefault();
            //    colorDetailTextBox.Text = details;
            //}
            categoryDetailTextBox.Text = query.Category;
            subcategoryDetailTextBox.Text = query.Subcategory;
            sizeDetailTextBox.Text = query.Size;
            classDetailTextBox.Text = query.Class;
            styleDetailTextBox.Text = query.Style;
            productLineDetailTextBox.Text = query.ProductLine;
            availabilityDestailTextBox.Text = (query.Availability ? "Yes" : "No");
            
        }
    }
}
