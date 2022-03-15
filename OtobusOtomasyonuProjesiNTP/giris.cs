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
using System.Configuration;

namespace OtobusOtomasyonuProjesiNTP
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        private void girisbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "select * from hesaplar where kulad = '" + kuladtxt.Text + "' and sifre='" + sifretxt.Text + "'";
            komut.Connection = con;
            SqlDataReader dr;
            dr = komut.ExecuteReader();

            if (dr.HasRows)
            {
                bool adminmi;
                if (kuladtxt.Text == "admin")
                {
                    adminmi = true;
                }
                else
                {
                    adminmi = false;
                }
                islemler form = new islemler(adminmi);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("hatalı kullanıcı adı veya şifre");
            }
            con.Close();
            this.Hide();
        }

        private void cikisbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
