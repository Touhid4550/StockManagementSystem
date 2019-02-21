using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class CompanySetupUi : Form
    {
        public CompanySetupUi()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name;

            if (!string.IsNullOrEmpty(nameTextBox.Text))
            {
                name = nameTextBox.Text;
            }
            else
            {
                MessageBox.Show("Please Give a Company Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTextBox.Focus();
                return;
            }

            if (Exists(name))
            {
                MessageBox.Show("Company Already Exists.");
                nameTextBox.Focus();
                return;
            }

            try
            {
                // Save Data
                string connectionStrint =@"Server=TOUHID;Database=StockManagementSystemDb;Integrated Security=true";
                SqlConnection sqlConnection=new SqlConnection(connectionStrint);
                string query = @"INSERT INTO Companies(CompanyName)VALUES('" + name + "')";
                SqlCommand sqlCommane = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                int isExecuted = sqlCommane.ExecuteNonQuery();
                MessageBox.Show(isExecuted > 0 ? "Company Saved." : "Not Saved.");
                sqlConnection.Close();

                ShowData();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private bool Exists(string name)
        {
            bool isExists = false;

            try
            {
                string connectionString = @"Server=TOUHID; Database=StockManagementSystemDb; Integrated Security = true";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string query = @"SELECT * FROM Companies WHERE CompanyName = '" + name + "'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                string data = "";
                if (sqlDataReader.Read())
                {
                    data = sqlDataReader["CompanyName"].ToString();
                }

                if (!String.IsNullOrEmpty(data))
                {
                    isExists = true;
                }
                else
                {
                    isExists = false;
                }

                sqlConnection.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return isExists;
        }

        private void ShowData()
        {
            try
            {
                string connectionStrint = @"Server=TOUHID;Database=StockManagementSystemDb;Integrated Security=true";
                SqlConnection sqlConnection = new SqlConnection(connectionStrint);
                string queryShowData = @"SELECT *FROM Companies";
                SqlCommand sqlCommandShowData = new SqlCommand(queryShowData, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommandShowData);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                displayDataGridView.DataSource = dataTable;
                displayDataGridView.Columns[0].Width = 50;
                displayDataGridView.Columns[1].Width = 310;

                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                SaveButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void CompanySetupUi_Load(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
