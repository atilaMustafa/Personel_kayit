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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-UCP4SB3\\SQLEXPRESS; Initial Catalog = Personel_veri_tabani; Integrated Security = True");

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personel_veri_tabaniDataSet.tbl_personel' table. You can move, or remove it, as needed.
            this.tbl_personelTableAdapter.Fill(this.personel_veri_tabaniDataSet.tbl_personel);

        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            this.tbl_personelTableAdapter.Fill(this.personel_veri_tabaniDataSet.tbl_personel);
        }

        void temizle()
        {
            txt_id.Text = "";
            txt_ad.Text = "";
            txt_soyad.Text = "";
            txt_meslek.Text = "";
            lst_sehir.Text = "";
            mtb_maas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txt_ad.Focus();
        }



        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_personel (PerAd,PerSoyad,Persehir,Permaas,Permeslek,Perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txt_ad.Text);
            komut.Parameters.AddWithValue("@p2", txt_soyad.Text);
            komut.Parameters.AddWithValue("@p3", lst_sehir.Text);
            komut.Parameters.AddWithValue("@p4", mtb_maas.Text);
            komut.Parameters.AddWithValue("@p5", txt_meslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();



            baglanti.Close();
            MessageBox.Show("personel eklendi");

        }

        private void lst_sehir_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "true";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {

                label8.Text = "false";
            }
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txt_id.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txt_ad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txt_soyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            lst_sehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mtb_maas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txt_meslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            label8.Text=dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "False")

            {
                radioButton2.Checked = true;
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();    
            SqlCommand komutsil= new SqlCommand("Delete From Tbl_personel Where Perid=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1",txt_id.Text);
            komutsil.ExecuteNonQuery(); 
            baglanti.Close();
            MessageBox.Show("kayit silindi");

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_personel Set Perad= @a1,persoyad=@a2,persehir=@a3,permaas=@a4,perdurum=@a5,permeslek=@a6 where perid=@a7", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1",txt_ad.Text);
            komutguncelle.Parameters.AddWithValue("@a2",txt_soyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3",lst_sehir.Text); 
            komutguncelle.Parameters.AddWithValue("@a4",mtb_maas.Text);  
            komutguncelle.Parameters.AddWithValue("@a5",label8.Text);    
            komutguncelle.Parameters.AddWithValue("@a6",txt_meslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", txt_id.Text);

            komutguncelle.ExecuteNonQuery();



            baglanti.Close();
            MessageBox.Show("bilgi guncellendi");

        }

        private void btn_istatistik_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
        }
    }
}
