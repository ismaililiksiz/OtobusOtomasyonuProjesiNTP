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
    public partial class biletislemleri : Form
    {
        public biletislemleri()
        {
            InitializeComponent();
        }

        private void biletislemleri_Load(object sender, EventArgs e)
        {
            rotacb.Items.Add("ankara-istanbul");
            rotacb.Items.Add("izmir-ankara");
            rotacb.Items.Add("istanbul-izmir");
            durumcb.Items.Add("üye");
            durumcb.Items.Add("öğrenci");
            con.ConnectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            biletiadebtn.Enabled = false;
        }
       

        SqlConnection con = new SqlConnection();

        List<otobus> liste = new List<otobus>();

        int ödeme,indirim;
        kasa k = new kasa();


        private void biletsatbtn_Click(object sender, EventArgs e)
        {
            ödeme = 0;
            indirim = 0;
            if (rotacb.Text == "ankara-istanbul")
            {
                ödeme = ödeme + 80;
            }
            else if (rotacb.Text == "izmir-ankara")
            {
                ödeme = ödeme + 90;
            }
            else if (rotacb.Text == "istanbul-izmir")
            {
                ödeme = ödeme + 100;

            }
            else
            {
                MessageBox.Show("lütfen geçerli bir sefer seçiniz");
            }

            if (durumcb.Text == "üye")
            {
                indirim = ödeme * 25 / 100;              
            }
            else if (durumcb.Text == "öğrenci")
            {
                indirim = ödeme * 40/ 100;
            }
            ödeme = ödeme - indirim;
            MessageBox.Show(ödeme.ToString());
            
            k.kasa1 = ödeme + k.kasa1;

            SqlCommand komut = new SqlCommand();

            komut.CommandText = "insert into kasa values(@p1)";
            komut.Parameters.AddWithValue("@p1", k.kasa1);
            biletiadebtn.Enabled = true;

        }
        bool adminmi;

        private void geribtn_Click(object sender, EventArgs e)
        {
            islemler form = new islemler(adminmi);
            form.Show();
            this.Hide();
        }

        private void kasasorgubtn_Click(object sender, EventArgs e)
        {
          
            MessageBox.Show("Kasadiki toplam para " + k.kasa1.ToString());
        }

        private void biletiadebtn_Click(object sender, EventArgs e)
        {
           

            k.kasa1 = k.kasa1 - ödeme;

            SqlCommand komut = new SqlCommand();

            komut.CommandText = "insert into kasa values(@p1)";
            komut.Parameters.AddWithValue("@p1", k.kasa1);
            MessageBox.Show("Bilet başarıyla iade edildi");
            biletiadebtn.Enabled = false;
        }
    }
}
