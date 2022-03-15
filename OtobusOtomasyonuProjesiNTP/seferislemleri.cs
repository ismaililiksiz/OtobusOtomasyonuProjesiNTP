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
    public partial class seferislemleri : Form
    {
        public seferislemleri()
        {
            InitializeComponent();
        }

        private void seferislemleri_Load(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            rotatxt.Items.Add("ankara-istanbul");
            rotatxt.Items.Add("izmir-ankara"); 
            rotatxt.Items.Add("istanbul-izmir");
            sofortxt.Items.Add("mehmet kara");
            sofortxt.Items.Add("ali ak");
            sofortxt.Items.Add("ayse arı");
        }

        SqlConnection con = new SqlConnection();

        List<otobus> liste = new List<otobus>();
        public void temizle()
        {
            otobustxt.Clear();
            rotatxt.Text = "";
            sofortxt.Text = "";
        }
        public bool kontrol()
        {
            bool durum;
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "select * from seferler where otobusno=" + otobustxt.Text;
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
            komut.CommandText = "select * from seferler";
            komut.Connection = con;
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                otobus oto = new otobus();
                oto.otobusno = dr["otobusno"].ToString();
                oto.sofor = dr["soforid"].ToString();
                oto.rota = dr["rotaid"].ToString();
                liste.Add(oto);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = liste;
            con.Close();
        }

        private void sefereklebtn_Click(object sender, EventArgs e)
        {
            bool durum = kontrol();
            if (durum == false)
            {


                if (otobustxt.Text != "" && sofortxt.Text != "" && rotatxt.Text != "")
                {
                    con.Open();

                    otobus oto = new otobus();
                    oto.otobusno = otobustxt.Text;
       
                    if (sofortxt.Text == "mehmet kara")
                    {
                        oto.sofor = "1";
                    }
                    else if (rotatxt.Text == "ali ak")
                    {
                        oto.sofor = "2";
                    }
                    else
                    {
                        oto.sofor = "3";
                    }

                    if (rotatxt.Text == "ankara-istanbul")
                    {
                        oto.rota = "1";
                    }
                    else if (rotatxt.Text == "izmir-ankara")
                    {
                        oto.rota = "2";
                    }
                    else
                    {
                        oto.rota = "3";
                    }
                    liste.Add(oto);

                    SqlCommand komut = new SqlCommand();
                    komut.CommandText = "insert into seferler values(@p1,@p2,@p3)";
                    komut.Parameters.AddWithValue("@p1", oto.otobusno);
                    komut.Parameters.AddWithValue("@p2", oto.sofor);
                    komut.Parameters.AddWithValue("@p3", oto.rota);
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

        private void sefersilbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                otobus oto = (otobus)dataGridView1.SelectedRows[0].DataBoundItem;

                con.Open();
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "delete from seferler where otobusno=" + oto.otobusno;

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

        private void listelebtn_Click(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                otobus oto = (otobus)dataGridView1.SelectedRows[0].DataBoundItem;

                otobustxt.Text = oto.otobusno.ToString();
                sofortxt.Text = oto.sofor;
                rotatxt.Text = oto.rota;

            }
        }

        private void guncellebtn_Click(object sender, EventArgs e)
        {
            if (otobustxt.Text != "" && sofortxt.Text != "" && rotatxt.Text != "")

            {
                otobus oto = new otobus();
                oto.otobusno = otobustxt.Text;

                if (sofortxt.Text == "mehmet kara")
                {
                    oto.sofor = "1";
                }
                else if (rotatxt.Text == "ali ak")
                {
                    oto.sofor = "2";
                }
                else
                {
                    oto.sofor = "3";
                }

                if (rotatxt.Text == "ankara-istanbul")
                {
                    oto.rota = "1";
                }
                else if (rotatxt.Text == "izmir-ankara")
                {
                    oto.rota = "2";
                }
                else
                {
                    oto.rota = "3";
                }

                con.Open();

                SqlCommand komut = new SqlCommand();

                komut.CommandText = "update seferler set soforid=@p1, rotaid=@p2 where otobusno=@p3";
                komut.Parameters.AddWithValue("@p1", oto.sofor);
                komut.Parameters.AddWithValue("@p2", oto.rota);
                komut.Parameters.AddWithValue("@p3", oto.otobusno);

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
                komut.CommandText = "select * from seferler where otobusno='" + aratxt.Text + "'";
                komut.Connection = con;
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {

                    otobus oto = new otobus();
                    oto.otobusno = dr["otobusno"].ToString();
                    oto.sofor = dr["soforid"].ToString();
                    oto.rota = dr["rotaid"].ToString();
                    liste.Add(oto);
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
    }
}
