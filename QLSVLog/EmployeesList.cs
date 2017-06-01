using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSVLog
{
    public partial class EmployeesList : Form
    {
        bool isAddingActivated { get; set; }
        SqlConnection connection { get; set; }
        byte[] IV { get; set; }
        public EmployeesList(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            isAddingActivated = false;

            loadData();            
        }

        private void loadData()
        {
            SqlCommand loadCommand = new SqlCommand("exec SP_SEL_ENCRYPT_NHANVIEN", connection);
            DataTable data = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(loadCommand))
                adapter.Fill(data);

            data.Columns["LUONG"].ReadOnly = false;

            List<UInt64> salaryList = new List<UInt64>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                AesCryptoServiceProvider cryptoService = new AesCryptoServiceProvider();
                cryptoService.KeySize = 256;
                cryptoService.BlockSize = 128;
                IV = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
                cryptoService.IV = IV;
                byte[] key = Encoding.ASCII.GetBytes("1312310");
                byte[] salt = new byte[25] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
                var fullKey = new Rfc2898DeriveBytes(key, salt, 256);
                cryptoService.Key = fullKey.GetBytes(32);
                cryptoService.Padding = PaddingMode.PKCS7;
                cryptoService.Mode = CipherMode.CBC;

                ICryptoTransform decryptor = cryptoService.CreateDecryptor(cryptoService.Key, cryptoService.IV);

                DataRow row = data.Rows[i];
                byte[] decryptedBytes;
                byte[] cipher = row["LUONG"] as byte[];
                using (MemoryStream msDecrypt = new MemoryStream())
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor,
                                                                    CryptoStreamMode.Write))
                    {
                        csDecrypt.Write(cipher, 0, cipher.Length);
                    }

                    decryptedBytes = msDecrypt.ToArray();
                }
                UInt64 salaryValue = BitConverter.ToUInt64(decryptedBytes, 0);
                salaryList.Add(salaryValue);
            }

            data.Columns.Remove("LUONG");
            data.Columns.Add("LUONG", typeof(UInt64));
            for (int i = 0; i < data.Rows.Count; i++)
                data.Rows[i]["LUONG"] = salaryList[i];

            employeesView.DataSource = data;

            data.Columns["LUONG"].ReadOnly = true;
            employeesView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void add_Click(object sender, EventArgs e)
        {
            isAddingActivated = true;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            SqlCommand deleteCommand = new SqlCommand("delete from NHANVIEN where MANV = @employeeID", connection);
            deleteCommand.Parameters.Add("@employeeID", SqlDbType.NVarChar);
            deleteCommand.Parameters["@employeeID"].Value = employeeIDBox.Text;
            deleteCommand.ExecuteNonQuery();

            loadData();
        }

        private void update_Click(object sender, EventArgs e)
        {
            SHA1 hashFunc = SHA1Managed.Create();
            byte[] hashValue = hashFunc.ComputeHash(Encoding.Unicode.GetBytes(passwordBox.Text));

            UInt64 salaryValue = UInt64.Parse(salaryBox.Text);
            byte[] salaryBytes = BitConverter.GetBytes(salaryValue);

            AesCryptoServiceProvider cryptoService = new AesCryptoServiceProvider();
            cryptoService.KeySize = 256;
            cryptoService.BlockSize = 128;
            IV = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            cryptoService.IV = IV;
            byte[] key = Encoding.ASCII.GetBytes("1312310");
            byte[] salt = new byte[25] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
            var fullKey = new Rfc2898DeriveBytes(key, salt, 256);
            cryptoService.Key = fullKey.GetBytes(32);
            cryptoService.Padding = PaddingMode.PKCS7;
            cryptoService.Mode = CipherMode.CBC;

            ICryptoTransform encryptor = cryptoService.CreateEncryptor(cryptoService.Key, cryptoService.IV);
            byte[] encryptedBytes;
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor,
                                                                CryptoStreamMode.Write))
                {
                    csEncrypt.Write(salaryBytes, 0, salaryBytes.Length);
                }

                encryptedBytes = msEncrypt.ToArray();
            }

            SqlCommand addCommand = new SqlCommand("update NHANVIEN set HOTEN = @fullName, EMAIL = @email, LUONG = @salary, TENDN = @username, MATKHAU = @password where MANV = @employeeID", connection);
            addCommand.Parameters.Add("@employeeID", SqlDbType.VarChar);
            addCommand.Parameters.Add("@fullName", SqlDbType.NVarChar);
            addCommand.Parameters.Add("@email", SqlDbType.VarChar);
            addCommand.Parameters.Add("@salary", SqlDbType.VarBinary);
            addCommand.Parameters.Add("@username", SqlDbType.NVarChar);
            addCommand.Parameters.Add("@password", SqlDbType.VarBinary);
            addCommand.Parameters["@employeeID"].Value = employeeIDBox.Text;
            addCommand.Parameters["@fullName"].Value = fullnameBox.Text;
            addCommand.Parameters["@email"].Value = emailBox.Text;
            addCommand.Parameters["@salary"].Value = encryptedBytes;
            addCommand.Parameters["@username"].Value = usernameBox.Text;
            addCommand.Parameters["@password"].Value = hashValue;
            addCommand.ExecuteNonQuery();

            loadData();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (isAddingActivated)
            {
                SHA1 hashFunc = SHA1Managed.Create();
                byte[] hashValue = hashFunc.ComputeHash(Encoding.Unicode.GetBytes(passwordBox.Text));

                UInt64 salaryValue = UInt64.Parse(salaryBox.Text);
                byte[] salaryBytes = BitConverter.GetBytes(salaryValue);

                AesCryptoServiceProvider cryptoService = new AesCryptoServiceProvider();
                cryptoService.KeySize = 256;
                cryptoService.BlockSize = 128;
                IV = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
                cryptoService.IV = IV;
                byte[] key = Encoding.ASCII.GetBytes("1312310");
                byte[] salt = new byte[25] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
                var fullKey = new Rfc2898DeriveBytes(key, salt, 256);
                cryptoService.Key = fullKey.GetBytes(32);
                cryptoService.Padding = PaddingMode.PKCS7;
                cryptoService.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = cryptoService.CreateEncryptor(cryptoService.Key, cryptoService.IV);
                byte[] encryptedBytes;
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor,
                                                                    CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(salaryBytes, 0, salaryBytes.Length);
                    }

                    encryptedBytes = msEncrypt.ToArray();
                }

                SqlCommand addCommand = new SqlCommand("exec SP_INS_ENCRYPT_NHANVIEN @employeeID, @fullName, @email, @salary, @username, @password", connection);
                addCommand.Parameters.Add("@employeeID", SqlDbType.VarChar);
                addCommand.Parameters.Add("@fullName", SqlDbType.NVarChar);
                addCommand.Parameters.Add("@email", SqlDbType.VarChar);
                addCommand.Parameters.Add("@salary", SqlDbType.VarBinary);
                addCommand.Parameters.Add("@username", SqlDbType.NVarChar);
                addCommand.Parameters.Add("@password", SqlDbType.VarBinary);
                addCommand.Parameters["@employeeID"].Value = employeeIDBox.Text;
                addCommand.Parameters["@fullName"].Value = fullnameBox.Text;
                addCommand.Parameters["@email"].Value = emailBox.Text;
                addCommand.Parameters["@salary"].Value = encryptedBytes;
                addCommand.Parameters["@username"].Value = usernameBox.Text;
                addCommand.Parameters["@password"].Value = hashValue;
                addCommand.ExecuteNonQuery();

                loadData();
            }

            isAddingActivated = false;
        }

        private void none_Click(object sender, EventArgs e)
        {
            // do nothing.
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
