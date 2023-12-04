using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApp6
{
    public partial class Phone : Form
    {
        public Phone()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string model = textBox1.Text;
                string color = textBox2.Text;
                string price = textBox3.Text;

                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\amir\\source\\repos\\WindowsFormsApp6\\WindowsFormsApp6\\Database1.mdf;Integrated Security=True";
                string query = $"INSERT INTO Phone (Model, Color, Price) VALUES ('{model}', '{color}', {price})";
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
