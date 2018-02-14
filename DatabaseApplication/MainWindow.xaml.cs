using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;

namespace DatabaseApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;

        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\TestDB.accdb");
        }

        private void assetDisplayButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a query string
            string query = "select * from Assets";

            // Create a Command
            OleDbCommand cmd = new OleDbCommand(query, cn);

            // Connect to the DB
            cn.Open();

            // Create a reader to read the result
            OleDbDataReader read = cmd.ExecuteReader();

            // Create a holder string
            string data = "";

            while (read.Read())
            {
                data += read[0].ToString() + " " + read[1].ToString() + " " + read[2].ToString() + "\n";
            }

            assetText.Text = data;

            cn.Close();
        }

        private void employeeDisplayButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a query string
            string query = "SELECT * from Employees";

            // Create a Command
            OleDbCommand cmd = new OleDbCommand(query, cn);

            // Connect to the DB
            cn.Open();

            // Create a reader to read the result
            OleDbDataReader read = cmd.ExecuteReader();

            // Create a holder string
            string data = "";

            while (read.Read())
            {
                data += read[0].ToString() + " " + read[1].ToString() + " " + read[2].ToString() + "\n";
            }

            employeeDisplay.Text = data;

            cn.Close();
        }
    }
}
