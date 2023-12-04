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

namespace WindowsFormsApp6
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string family = textBox2.Text;
                string phoneNumber = textBox3.Text;

                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\amir\\source\\repos\\WindowsFormsApp6\\WindowsFormsApp6\\Database1.mdf;Integrated Security=True";
                string query = $"INSERT INTO Customer (name, family, phonenumber) VALUES ('{name}', '{family}', {phoneNumber})";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    MessageBox.Show("عملیات با موفقیت انجام شد");
                else
                    MessageBox.Show("بروز خطا در انجام عملیات");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
