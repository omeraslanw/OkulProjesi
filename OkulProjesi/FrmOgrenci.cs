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
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-BOV3B8B\SQLEXPRESS;Initial Catalog=OkulSistemi;Integrated Security=True");

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Kulupler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbKulup.DisplayMember = "kulupAd";
            cmbKulup.ValueMember = "kulupId";
            cmbKulup.DataSource = dt;
            baglanti.Close();
        }

        string cinsiyet = "";

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.OgrenciEkle(txtAd.Text, txtSoyad.Text, byte.Parse(cmbKulup.SelectedValue.ToString()), cinsiyet);
            dataGridView1.DataSource = ds.OgrenciListesi();
            MessageBox.Show("Öğrenci eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void listele()
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void cmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Text = cmbKulup.SelectedValue.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtID.Text));
            listele();
            MessageBox.Show("Öğrenci silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "Erkek")
            {
                radioErkek.Checked = true;
                radioKiz.Checked = false;
            }
            else
            {
                radioKiz.Checked = true;
                radioErkek.Checked = false;
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(txtAd.Text, txtSoyad.Text, byte.Parse(cmbKulup.SelectedValue.ToString()), cinsiyet, int.Parse(txtID.Text));
            MessageBox.Show("Öğrenci güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioKiz_CheckedChanged(object sender, EventArgs e)
        {
            if (radioKiz.Checked == true) cinsiyet = "Kadın";
        }

        private void radioErkek_CheckedChanged(object sender, EventArgs e)
        {
            if (radioErkek.Checked == true) cinsiyet = "Erkek";
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(txtAra.Text);
        }

        private void txtSoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
