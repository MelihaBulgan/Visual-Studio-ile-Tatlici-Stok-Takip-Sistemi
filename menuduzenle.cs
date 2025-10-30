using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TatlıcıStokTakip
{
    public partial class menuduzenle : Form
    {
        public menuduzenle()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\DELL\\Desktop\\StokTakip.mdb");

        private void menuduzenle_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from menu where barkodno='" + textBox1.Text + "'", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Text = oku["kategori"].ToString();
                comboBox2.Text = oku["urunturu"].ToString();
                comboBox3.Text = oku["urun"].ToString();
                textBox2.Text = oku["menuadi"].ToString();
                textBox3.Text = oku["rafno"].ToString();
                textBox4.Text = oku["adet"].ToString();
                dateTimePicker1.Text = oku["gtarihi"].ToString();
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand guncellemeKomutu = new OleDbCommand("update menu set barkodno='" + textBox1.Text + "',kategori='" + comboBox1.Text + "',urunturu='" + comboBox2.Text + "',urun='" + comboBox3.Text + "',menuadi='" + textBox2.Text + "',rafno='" + textBox3.Text + "',adet='" + textBox4.Text + "',gtarihi='" + dateTimePicker1.Text + "' where barkodno='"+textBox1.Text+"'", baglanti);
            guncellemeKomutu.ExecuteNonQuery();
            baglanti.Close();

            label9.Text = textBox1.Text + " barkod nolu ürününüz güncellendi";
        }
    }
}
