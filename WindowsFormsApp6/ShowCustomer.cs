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
using System.Reflection;

namespace WindowsFormsApp6
{
    public partial class ShowCustomer : Form
    {
        public ShowCustomer()
        {
            InitializeComponent();
        }

        string customer = "";
        private void GetData()
        {
            try
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\amir\\source\\repos\\WindowsFormsApp6\\WindowsFormsApp6\\Database1.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "SELECT * FROM Customer";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                listBox1.Items.Clear();
                while (reader.Read())
                {
                    string name = reader["name"].ToString();
                    string family = reader["family"].ToString();
                    string phonenumber = reader["phonenumber"].ToString();

                    listBox1.Items.Add($"Name : {name}, Family : {family}, PhoneNumber : {phonenumber}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowCustomer_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(customer))
            {
                MessageBox.Show("لطفا یک آیتم را انتخاب کنید");
            }
            else
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\amir\\source\\repos\\WindowsFormsApp6\\WindowsFormsApp6\\Database1.mdf;Integrated Security=True";
                string deleteQuery = $"DELETE FROM Customer WHERE name = '{customer}'";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(deleteQuery, connection);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    GetData();
                    MessageBox.Show($"مشتری {customer} با موفقیت حذف شد.");
                    customer = "";
                }
                else
                {
                    MessageBox.Show($"مشتری {customer} یافت نشد یا حذف نشد.");
                }
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedCustomer = listBox1.SelectedItem.ToString().Split(',')[0].Split(':')[1].Trim();
                customer = selectedCustomer;
            }
            else
            {
                MessageBox.Show("لطفا یک آیتم را انتخاب کنید");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string newCustomer = textBox1.Text;
                if (string.IsNullOrEmpty(customer))
                {
                    MessageBox.Show("لطفا یک آیتم را انتخاب کنید");
                }
                else
                {
                    if (newCustomer == "")
                    {
                        MessageBox.Show("لطفا مقداری وارد کنید");
                    }
                    else
                    {
                        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\amir\\source\\repos\\WindowsFormsApp6\\WindowsFormsApp6\\Database1.mdf;Integrated Security=True";
                        string query = $"UPDATE Customer SET name = '{newCustomer}' WHERE name = '{customer}'";
                        SqlConnection connection = new SqlConnection(connectionString);
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            GetData();
                            MessageBox.Show("تغیبرات اعمال شد ");
                            textBox1.Text = "";
                            customer = "";
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
                string newFamily = textBox1.Text;
                if (string.IsNullOrEmpty(customer))
                {
                    MessageBox.Show("لطفا یک آیتم را انتخاب کنید");
                }
                else
                {
                    if (newFamily == "")
                    {
                        MessageBox.Show("لطفا مقداری وارد کنید");
                    }
                    else
                    {
                        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\amir\\source\\repos\\WindowsFormsApp6\\WindowsFormsApp6\\Database1.mdf;Integrated Security=True";
                        string query = $"UPDATE Customer SET family = '{newFamily}' WHERE name = '{customer}'";
                        SqlConnection connection = new SqlConnection(connectionString);
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            GetData();
                            MessageBox.Show("تغیبرات اعمال شد ");
                            textBox1.Text = "";
                            customer = "";
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
                string newPhoneNumber = textBox1.Text;
                if (string.IsNullOrEmpty(customer))
                {
                    MessageBox.Show("لطفا یک آیتم را انتخاب کنید");
                }
                else
                {
                    if (newPhoneNumber == "")
                    {
                        MessageBox.Show("لطفا مقداری وارد کنید");
                    }
                    else
                    {
                        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\amir\\source\\repos\\WindowsFormsApp6\\WindowsFormsApp6\\Database1.mdf;Integrated Security=True";
                        string query = $"UPDATE Customer SET phonenumber = '{newPhoneNumber}' WHERE name = '{customer}'";
                        SqlConnection connection = new SqlConnection(connectionString);
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            GetData();
                            MessageBox.Show("تغیبرات اعمال شد ");
                            textBox1.Text = "";
                            customer = "";
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