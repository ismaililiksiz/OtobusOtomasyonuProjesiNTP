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
    public partial class soforislemleri : Form
    {
        public soforislemleri()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();

        List<sofor> liste = new List<sofor>();

        private void soforekle_Click(object sender, EventArgs e)
        {
            bool durum = kontrol();
            if (durum == false)
            {


                if (tctxt.Text != "" && adtxt.Text != "" && soyadtxt.Text != "")
                {
                    con.Open();

                    sofor sfr = new sofor();
                    sfr.sfrad = adtxt.Text;
                    sfr.sfrsoyad = soyadtxt.Text;
                    sfr.sfrtel = teltxt.Text;
                    sfr.sfrtc = tctxt.Text;                 
                    liste.Add(sfr);

                    SqlCommand komut = new SqlCommand();
                    komut.CommandText = "insert into soforler values(@p1,@p2,@p3,@p4)";
                    komut.Parameters.AddWithValue("@p1", sfr.sfrad);
                    komut.Parameters.AddWithValue("@p2", sfr.sfrsoyad);
                    komut.Parameters.AddWithValue("@p3", sfr.sfrtel);
                    komut.Parameters.AddWithValue("@p4", sfr.sfrtc);
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
        public void temizle()
        {
            adtxt.Clear();
            soyadtxt.Clear();
            tctxt.Clear();
            teltxt.Clear();
        }
        public bool kontrol()
        {
            bool durum;
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "select * from soforler where sofortc=" + tctxt.Text;
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
            komut.CommandText = "select * from soforler";
            komut.Connection = con;
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                sofor sfr = new sofor();
                sfr.sfrad = dr["soforad"].ToString();
                sfr.sfrsoyad = dr["soforsoyad"].ToString();
                sfr.sfrtel = dr["sofortel"].ToString();
                sfr.sfrtc = dr["sofortc"].ToString();
                liste.Add(sfr);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = liste;
            con.Close();
        }



        private void soforislemleri_Load(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        }


        bool adminmi;

        private void cikis_Click(object sender, EventArgs e)
        {
            islemler form = new islemler(adminmi);
            form.Show();
            this.Hide();
        }

        private void soforsil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                sofor sfr = (sofor)dataGridView1.SelectedRows[0].DataBoundItem;

                con.Open();
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "delete from soforler where sofortc=" + sfr.sfrtc;

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
                sofor sfr = (sofor)dataGridView1.SelectedRows[0].DataBoundItem;

                adtxt.Text = sfr.sfrad;
                soyadtxt.Text = sfr.sfrsoyad;
                teltxt.Text = sfr.sfrtel;
                tctxt.Text = sfr.sfrtc;

            }
        }

        private void guncellebtn_Click(object sender, EventArgs e)
        {
            if (tctxt.Text != "" && teltxt.Text != "" && adtxt.Text != "" && soyadtxt.Text != "")

            {
                sofor sfr = new sofor();
                sfr.sfrad = adtxt.Text;
                sfr.sfrsoyad = soyadtxt.Text;
                sfr.sfrtel = teltxt.Text;
                sfr.sfrtc = tctxt.Text;

                con.Open();

                SqlCommand komut = new SqlCommand();

                komut.CommandText = "update soforler set soforad=@p1, soforsoyad=@p2, sofortel=@p3 where sofortc=@p4";
                komut.Parameters.AddWithValue("@p1", sfr.sfrad);
                komut.Parameters.AddWithValue("@p2", sfr.sfrsoyad);
                komut.Parameters.AddWithValue("@p3", sfr.sfrtel);
                komut.Parameters.AddWithValue("@p4", sfr.sfrtc);

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
    }
}
