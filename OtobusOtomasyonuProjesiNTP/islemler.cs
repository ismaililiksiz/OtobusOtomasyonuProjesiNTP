using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtobusOtomasyonuProjesiNTP
{
    public partial class islemler : Form
    {
        public islemler(bool adminmi)
        {
            InitializeComponent();
            if (adminmi == false) 
            {
                seferbtn.Enabled = false;
            }
        }

        private void cikisbtn_Click(object sender, EventArgs e)
        {
            giris form = new giris();
            this.Hide();
            form.Show();
        }

        private void seferbtn_Click(object sender, EventArgs e)
        {
            seferislemleri form2 = new seferislemleri();
            this.Hide();
            form2.Show();

        }

        private void uyebtn_Click(object sender, EventArgs e)
        {
            uyeislemleri form3 = new uyeislemleri();
            this.Hide();
            form3.Show();
        }

        private void biletbtn_Click(object sender, EventArgs e)
        {
            biletislemleri form4 = new biletislemleri();
            this.Hide();
            form4.Show();
        }
    }
}
