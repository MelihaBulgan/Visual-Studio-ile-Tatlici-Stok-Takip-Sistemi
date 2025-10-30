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
    public partial class menusil : Form
    {
        public menusil()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\DELL\\Desktop\\StokTakip.mdb");

        private void menusil_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from menu where barkodno='" + textBox1.Text + "'", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBox2.Text = oku["menuadi"].ToString();
                textBox3.Text = oku["adet"].ToString();
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand silmeKomutu = new OleDbCommand("delete from menu where barkodno='" + textBox1.Text + "'", baglanti);
            silmeKomutu.ExecuteNonQuery();
            baglanti.Close();
            label4.Text = textBox1.Text + " nolu menü silindi..";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
