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

namespace Personel_kayit
{



    public partial class Form2 : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-UCP4SB3\\SQLEXPRESS; Initial Catalog = Personel_veri_tabani; Integrated Security = True");

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count (*) From Tbl_personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                toplam_personel.Text = dr1[0].ToString();

            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count (*) From Tbl_personel where Perdurum= 1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                evli_personel.Text = dr2[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count (*) From Tbl_personel Where Perdurum= 0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                bekar_personel.Text = dr3[0].ToString();
            }

            baglanti.Close();
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select Count (distinct(persehir)) From Tbl_personel ", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                sehir_sayisi.Text = dr4[0].ToString();
            }

            baglanti.Close();
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum (permaas) From Tbl_personel", baglanti);
            SqlDataReader d5 = komut5.ExecuteReader();
            while (d5.Read())
            {
                toplam_maas.Text = d5[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(permaas) From Tbl_personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                ortalama_maas.Text = dr6[0].ToString();
            }
            baglanti.Close();










        }
    }
}
