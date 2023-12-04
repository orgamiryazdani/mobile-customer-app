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
    public partial class ShowPhone : Form
    {
        public ShowPhone()
        {
            InitializeComponent();
        }

        string model = "";
        private void GetData()
        {
            try
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\amir\\source\\repos\\WindowsFormsApp6\\WindowsFormsApp6\\Database1.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "SELECT * FROM Phone";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                listBox1.Items.Clear();
                while (reader.Read())
                {
                    string model = reader["Model"].ToString();
                    string color = reader["Color"].ToString();
                    string price = reader["Price"].ToString();

                    listBox1.Items.Add($"Model : {model}, Color : {color}, Price : {price}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowPhone_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedModel = listBox1.SelectedItem.ToString().Split(',')[0].Split(':')[1].Trim();
                model = selectedModel;
            }
            else
            {
                MessageBox.Show("لطفا یک آیتم را انتخاب کنید");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(model))
            {
                MessageBox.Show("لطفا یک آیتم را انتخاب کنید");
            }
            else
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\amir\\source\\repos\\WindowsFormsApp6\\WindowsFormsApp6\\Database1.mdf;Integrated Security=True";
                string deleteQuery = $"DELETE FROM Phone WHERE Model = '{model}'";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(deleteQuery, connection);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    GetData();
                    MessageBox.Show($"گوشی با مدل {model} با موفقیت حذف شد.");
                    model = "";
                }
                else
                {
                    MessageBox.Show($"گوشی با مدل {model} یافت نشد یا حذف نشد.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string newModel = textBox1.Text;
                if (string.IsNullOrEmpty(model))
                {
                    MessageBox.Show("لطفا یک آیتم را انتخاب کنید");
                }
                else
                {
                    if (newModel == "")
                    {
                        MessageBox.Show("لطفا مقداری وارد کنید");
                    }
                    else
                    {
                        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\amir\\source\\repos\\WindowsFormsApp6\\WindowsFormsApp6\\Database1.mdf;Integrated Security=True";
                        string query = $"UPDATE Phone SET Model = '{newModel}' WHERE Model = '{model}'";
                        SqlConnection connection = new SqlConnection(connectionString);
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            GetData();
                            MessageBox.Show("تغیبرات اعمال شد ");
                            textBox1.Text = "";
                            model = "";
                        }
                        else
                        {
                            MessageBox.Show("عملیات با خطا مواجه شد");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string newColor = textBox1.Text;
                if (string.IsNullOrEmpty(model))
                {
                    MessageBox.Show("لطفا یک آیتم را انتخاب کنید");
                }
                else
                {
                    if (newColor == "")
                    {
                        MessageBox.Show("لطفا مقداری وارد کنید");
                    }
                    else
                    {
                        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\amir\\source\\repos\\WindowsFormsApp6\\WindowsFormsApp6\\Database1.mdf;Integrated Security=True";
                        string query = $"UPDATE Phone SET Color = '{newColor}' WHERE Model = '{model}'";
                        SqlConnection connection = new SqlConnection(connectionString);
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            GetData();
                            MessageBox.Show("تغیبرات اعمال شد ");
                            textBox1.Text = "";
                            model = "";
                        }
                        else
                        {
                            MessageBox.Show("عملیات با خطا مواجه شد");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string newPrice = textBox1.Text;
                if (string.IsNullOrEmpty(model))
                {
                    MessageBox.Show("لطفا یک آیتم را انتخاب کنید");
                }
                else
                {
                    if (newPrice == "")
                    {
                        MessageBox.Show("لطفا مقداری وارد کنید");
                    }
                    else
                    {
                        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\amir\\source\\repos\\WindowsFormsApp6\\WindowsFormsApp6\\Database1.mdf;Integrated Security=True";
                        string query = $"UPDATE Phone SET Price = '{newPrice}' WHERE Model = '{model}'";
                        SqlConnection connection = new SqlConnection(connectionString);
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            GetData();
                            MessageBox.Show("تغیبرات اعمال شد ");
                            textBox1.Text = "";
                            model = "";
                        }
                        else
                        {
                            MessageBox.Show("عملیات با خطا مواجه شد");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}