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

namespace OkulProjesi
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-BOV3B8B\SQLEXPRESS;Initial Catalog=OkulSistemi;Integrated Security=True");
        public string numara;

        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select dersAd,sinav1,sinav2,sinav3,proje,ortalama,durum from Tbl_Notlar \r\ninner join Tbl_Dersler on Tbl_Notlar.dersID=Tbl_Dersler.dersID where ogrID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            /*baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select ogrAd,ogrSoyad from Tbl_Ogrenciler where ogrId=@p2", baglanti);
            komut2.Parameters.AddWithValue("@p2", numara);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                this.Text = dr[0] + " " + dr[1];
            }
            baglanti.Close();*/
        }
    }
}
