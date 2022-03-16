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
    public partial class uyeislemleri : Form
    {
        public uyeislemleri()
        {
            InitializeComponent();

        }

        private void uyeislemleri_Load(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString; 
            durumtxt.Items.Add("öğrenci");
            durumtxt.Items.Add("tam");
        }

        SqlConnection con = new SqlConnection(); 

        List<Uye> liste = new List<Uye>(); 

        public void temizle() 
        {
            adtxt.Clear();
            soyadtxt.Clear();
            durumtxt.Text = "";
            tctxt.Clear();
            teltxt.Clear();
        }
        public bool kontrol() 
        {
            bool durum;
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "select * from uyeler where tc=" + tctxt.Text; 
            komut.Connection = con;
            SqlDataReader dr = komut.ExecuteReader(); 

            durum = dr.HasRows; 
            con.Close();

            return durum;


        }
        public void listele() 
        { 

            liste.Clear(); 

            con.Open();

            SqlCommand komut = new SqlCommand();
            komut.CommandText = "select * from uyeler"; 
            komut.Connection = con;
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read()) 
            {
                Uye yeniuye = new Uye();
                yeniuye.tc = dr["tc"].ToString();
                yeniuye.ad = dr["ad"].ToString();
                yeniuye.soyad = dr["soyad"].ToString();
                yeniuye.tel = dr["tel"].ToString();
                yeniuye.durum = dr["durumid"].ToString();

                liste.Add(yeniuye); 
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = liste; 
            con.Close();
        }

        private void uyeeklebtn_Click(object sender, EventArgs e)
        {
            bool durum = kontrol(); 
            if (durum == false) 
            {


                if (tctxt.Text != "" && adtxt.Text != "" && soyadtxt.Text != "") 
                {
                    con.Open();

                    Uye uye = new Uye();
                    uye.tc = tctxt.Text; 
                    uye.ad = adtxt.Text;
                    uye.soyad = soyadtxt.Text;
                    uye.tel = teltxt.Text;
                    if (durumtxt.Text=="tam")
                    {
                        uye.durum = "2";
                    }
                    else
                    {
                        uye.durum = "1";
                    }
                    liste.Add(uye);

                    SqlCommand komut = new SqlCommand();
                    komut.CommandText = "insert into uyeler values(@p1,@p2,@p3,@p4,@p5)";
                    komut.Parameters.AddWithValue("@p1", uye.ad);
                    komut.Parameters.AddWithValue("@p2", uye.soyad);
                    komut.Parameters.AddWithValue("@p3", uye.tel);
                    komut.Parameters.AddWithValue("@p4", uye.tc);
                    komut.Parameters.AddWithValue("@p5", uye.durum);
                    komut.Connection = con;

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarıyla eklendi");

                }
                else
                {
                    MessageBox.Show("Boş alan bırakmayınız");
                }

            }
            else
            {
                MessageBox.Show("Bu kayıt zaten mevcut"); 
            }
            con.Close();
            listele();
            temizle();
        }

        private void silbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1) 
            {
                Uye yeniuye = (Uye)dataGridView1.SelectedRows[0].DataBoundItem;

                con.Open();
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "delete from uyeler where tc=" + yeniuye.tc; 

                komut.Connection = con;

                komut.ExecuteNonQuery();

            }
            else
            {
                MessageBox.Show("bir adet kayıt seçmelisiniz");
            }

            con.Close();

            listele(); 

            temizle(); 
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1) 
            {
                Uye yeniuye = (Uye)dataGridView1.SelectedRows[0].DataBoundItem;

                tctxt.Text = yeniuye.tc.ToString(); 
                durumtxt.Text = yeniuye.durum;
                teltxt.Text = yeniuye.tel;
                adtxt.Text = yeniuye.ad;
                soyadtxt.Text = yeniuye.soyad;

            }
        }

        private void listelebtn_Click(object sender, EventArgs e)
        {
            listele(); 
            temizle(); 
        }

        private void guncellebtn_Click(object sender, EventArgs e)
        {
            if (tctxt.Text != "" && teltxt.Text != "" && adtxt.Text != "" && soyadtxt.Text != "")  
                                                                                                 
            {
                Uye yeniuye = new Uye();
                yeniuye.tc = tctxt.Text; 
                yeniuye.tel = teltxt.Text;
                yeniuye.ad = adtxt.Text;
                yeniuye.soyad = soyadtxt.Text;
                if (durumtxt.Text == "tam")
                {
                    yeniuye.durum = "2";
                }
                else
                {
                    yeniuye.durum = "1";
                }

                con.Open();

                SqlCommand komut = new SqlCommand();

                komut.CommandText = "update uyeler set ad=@p1, soyad=@p2, tel=@p3, durumid=@p4 where tc=@p5"; 
                komut.Parameters.AddWithValue("@p1", yeniuye.ad);
                komut.Parameters.AddWithValue("@p2", yeniuye.soyad);
                komut.Parameters.AddWithValue("@p3", yeniuye.tel);
                komut.Parameters.AddWithValue("@p4", yeniuye.durum);
                komut.Parameters.AddWithValue("@p5", yeniuye.tc);

                komut.Connection = con;
                komut.ExecuteNonQuery();
                MessageBox.Show("kayıt güncellendi");

            }
            else
            {
                MessageBox.Show("Güncellemek için kayıt seçmelisiniz");
            }
            con.Close();
            listele(); 
            temizle(); 
        }

        private void arabtn_Click(object sender, EventArgs e)
        {
            if (aratxt.Text != "") 
            {
                liste.Clear(); 
                con.Open();
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "select * from uyeler where tc='" + aratxt.Text+"'"; 
                komut.Connection = con;
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {

                    Uye yeniuye = new Uye();
                    yeniuye.ad = dr["ad"].ToString();
                    yeniuye.soyad = dr["soyad"].ToString();
                    yeniuye.tel = dr["tel"].ToString();
                    yeniuye.tc = dr["tc"].ToString(); 
                    yeniuye.durum = dr["durumid"].ToString();
                    liste.Add(yeniuye); 
                }
                else
                {
                    MessageBox.Show("aradığınız tc bulunamadı");
                }
                con.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = liste; 

            }
            else
            {
                MessageBox.Show("lütfen bir tc değeri giriniz");
            }
        }

        bool adminmi;

        private void geribtn_Click(object sender, EventArgs e)
        {
            islemler form = new islemler(adminmi);
            form.Show();
            this.Hide();
        }
    }
}
