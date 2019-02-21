using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class HomeUi : Form
    {
        public HomeUi()
        {
            InitializeComponent();
        }

        private void CompanySetupButton_Click(object sender, EventArgs e)
        {
            CompanySetupUi companySetup = new CompanySetupUi();
            companySetup.ShowDialog();
        }

        private void ViewSalesButton_Click(object sender, EventArgs e)
        {
            ViewSalesBetweenTwoDatesUi viewSales = new ViewSalesBetweenTwoDatesUi();
            viewSales.ShowDialog();
        }

        private void ItemSetupButton_Click(object sender, EventArgs e)
        {
            ItemSetupUi itemSetup = new ItemSetupUi();
            itemSetup.ShowDialog();
        }
    }
}
