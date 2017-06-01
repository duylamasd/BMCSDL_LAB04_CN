using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSVLog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;

            if (usernameBox.Text == "")
            {
                MessageBox.Show("Please enter your username!");
                return;
            }

            if (passwordBox.Text == "")
            {
                MessageBox.Show("Please enter your password!");
                return;
            }

            SqlConnection conn = new SqlConnection("Initial Catalog=QLSV;Data Source=REALHUNTER;Persist Security Info = True;User ID = sa;Password = duylamasd1995");
            SqlCommand NVcommand = new SqlCommand("select TENDN from NHANVIEN");
            SqlCommand SVcommand = new SqlCommand("select TENDN from SINHVIEN");
            NVcommand.Connection = conn;
            SVcommand.Connection = conn;
            conn.Open();

            var NVUserTable = new DataTable();
            var SVUserTable = new DataTable();

            using (var adapter = new SqlDataAdapter(NVcommand))
            {
                adapter.Fill(NVUserTable);
            }

            using (var adapter = new SqlDataAdapter(SVcommand))
            {
                adapter.Fill(SVUserTable);
            }

            DataColumn[] NVColumns = NVUserTable.Columns.Cast<DataColumn>().ToArray();
            DataColumn[] SVColumns = SVUserTable.Columns.Cast<DataColumn>().ToArray();

            if (NVUserTable.AsEnumerable().Any(row => NVColumns.Any(col => row[col].ToString() == usernameBox.Text)))
            {
                SHA1 hashFunc = SHA1Managed.Create();
                var hashValue = hashFunc.ComputeHash(Encoding.Unicode.GetBytes(passwordBox.Text));
                SqlCommand realPassword = new SqlCommand("select MATKHAU from NHANVIEN where TENDN = @username", conn);
                realPassword.Parameters.Add("@username", SqlDbType.NVarChar);
                realPassword.Parameters["@username"].Value = usernameBox.Text;

                using (SqlDataReader reader = realPassword.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var realPasswordBytes = reader[0] as byte[];
                        if (hashValue.SequenceEqual(realPasswordBytes))
                            isSuccess = true;
                    }
                }
            }
            else if (SVUserTable.AsEnumerable().Any(row => SVColumns.Any(col => row[col].ToString() == usernameBox.Text)))
            {
                MD5 hashFunc = MD5.Create();
                var hashValue = hashFunc.ComputeHash(Encoding.Unicode.GetBytes(passwordBox.Text));
                SqlCommand realPassword = new SqlCommand("select MATKHAU from SINHVIEN where TENDN = @username", conn);
                realPassword.Parameters.Add("@username", SqlDbType.NVarChar);
                realPassword.Parameters["@username"].Value = usernameBox.Text;

                using (SqlDataReader reader = realPassword.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var realPasswordBytes = reader[0] as byte[];
                        if (hashValue.SequenceEqual(realPasswordBytes))
                            isSuccess = true;

                    }
                }
            }

            if (isSuccess)
            {
                EmployeesList employeesList = new EmployeesList(conn);
                employeesList.Show();
            }
            else
                MessageBox.Show("This user or password is incorrect!");
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
