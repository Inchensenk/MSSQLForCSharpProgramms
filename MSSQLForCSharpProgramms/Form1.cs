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
            /*new SqlConnection() �������� ����������� � ���� ������.
             * ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString: ��������� �� App.config ������ ����������� � ������ TestDB*/
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            sqlConnection.Open();
             
            if (sqlConnection.State==ConnectionState.Open)
            {
                MessageBox.Show("����������� �����������");
            }
        }

        private void OnInsertButtonClick(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [Students] (Name, Surname, Birthday, Mesto_rozhdeniya, Phone, Email) VALUES(@Name, @Surname, @Birthday, @Mesto_rozhdeniya, @Phone, @Email)", 
                sqlConnection);
            
            DateTime date = DateTime.Parse(textBox3.Text);

            //���������� ������� � ����� �������
            command.Parameters.AddWithValue("Name", textBox1.Text);
            command.Parameters.AddWithValue("Surname", textBox2.Text);
            command.Parameters.AddWithValue("Birthday", $"{date.Month}/{date.Day}/{date.Year}");
            command.Parameters.AddWithValue("Mesto_rozhdeniya", textBox4.Text);
            command.Parameters.AddWithValue("Phone", textBox5.Text);
            command.Parameters.AddWithValue("Email", textBox6.Text);

            /*command.ExecuteNonQuery();
            ExecuteNonQuery() ���������� ����������� ������������ �����.
            � ������ ������, �������� 0*/
            MessageBox.Show(command.ExecuteNonQuery().ToString());
        }
    }
}