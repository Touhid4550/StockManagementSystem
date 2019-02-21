using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StockManagementSystem
{
    public partial class ItemSetupUi : Form
    {
        public ItemSetupUi()
        {
            InitializeComponent();
        }

        private void ItemSetupUi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stockManagementSystemDbDataSet4.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter2.Fill(this.stockManagementSystemDbDataSet4.Categories);
            // TODO: This line of code loads data into the 'stockManagementSystemDbDataSet3.Companies' table. You can move, or remove it, as needed.
            this.companiesTableAdapter1.Fill(this.stockManagementSystemDbDataSet3.Companies);
            
           
           
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            
          try
                {
           
            string itemName = itemnameTextBox.Text;
            if (itemnameTextBox.Text == "")
            {
                itemValiditionLabel.Text = "Invalid Item Name !!";
            }
            else if (reorderLevelTextBox.Text == "")
            {

                reorderValidationLabel.Text = "Invalid Reorder Level !!";
            }
            else
            {
                int reorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);

                    string connectionString = @"Server=TOUHID; Database=StockManagementSystemDb; Integrated Security=true";
                    SqlConnection sqlCon = new SqlConnection(connectionString);

                    string query = @"INSERT INTO Items  ([ItemName]
           ,[CompanyId]
           ,[CatagoryId]
           ,[ReorderLevel])
      
     VALUES ('" + itemName + "'," + companyComboBox.SelectedValue + "," + categoryComboBox.SelectedValue + "," + reorderLevel + ")";


                    SqlCommand com = new SqlCommand(query, sqlCon);
                    sqlCon.Open();
                    com.ExecuteNonQuery();
                    MessageBox.Show("success");
                    clear();

                }}
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            

        }

        public void clear()
        {
            itemnameTextBox.Text = "";
            reorderLevelTextBox.Text = "";
            categoryComboBox.SelectedIndex =0;
            companyComboBox.SelectedIndex = 0;
            itemValiditionLabel.Text = "";
            reorderValidationLabel.Text = "";

        }
    }
}
