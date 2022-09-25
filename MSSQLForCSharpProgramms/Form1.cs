using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MSSQLForCSharpProgramms
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null!;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*new SqlConnection() создание подключения к базе данных.
             * ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString: Вытягивае из App.config строки подключения с именем TestDB*/
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            sqlConnection.Open();
             
            if (sqlConnection.State==ConnectionState.Open)
            {
                MessageBox.Show("Подключение установлено");
            }
        }
    }
}