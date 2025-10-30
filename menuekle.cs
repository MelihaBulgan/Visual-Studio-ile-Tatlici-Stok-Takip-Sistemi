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
    public partial class menuekle : Form
    {
        public menuekle()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\DELL\\Desktop\\StokTakip.mdb");


        private void menuekle_Load(object sender, EventArgs e)
        {
            //comboboxa kategori alma
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select kategori from kategori", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                comboBox1.Items.Add(oku["kategori"].ToString());
            }
            baglanti.Close();

            //comboboxa urun turu alma
            baglanti.Open();
            OleDbCommand komutUrunTuru = new OleDbCommand("select urunturu from urunekle", baglanti);
            OleDbDataReader okuUrunTuru = komutUrunTuru.ExecuteReader();
            while (okuUrunTuru.Read())
            {
                comboBox2.Items.Add(okuUrunTuru["urunturu"].ToString());
            }
            baglanti.Close();

            //comboboxa urun alma
            baglanti.Open();
            OleDbCommand komutUrun = new OleDbCommand("select urun from urunler", baglanti);
            OleDbDataReader okuUrun = komutUrun.ExecuteReader();
            while (okuUrun.Read())
            {
                comboBox3.Items.Add(okuUrun["urun"].ToString());
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komutMenuEkle = new OleDbCommand("insert into menu (barkodno,kategori,urunturu,urun,menuadi,rafno,adet,gtarihi) values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "')", baglanti);
            komutMenuEkle.ExecuteNonQuery();
            label9.Text = "Menü başarıyla eklendi";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            baglanti.Close();
            menuekle_Load(sender, e);
        }
    }
}
