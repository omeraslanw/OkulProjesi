using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulProjesi
{
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtID.Text));
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-BOV3B8B\SQLEXPRESS;Initial Catalog=OkulSistemi;Integrated Security=True");

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbKulup.DisplayMember = "DERSAD";
            cmbKulup.ValueMember = "DERSID";
            cmbKulup.DataSource = dt;
            baglanti.Close();
        }

        int notid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            int sinav1, sinav2, sinav3, proje;
            double ortalama;
            sinav1 = Convert.ToInt16(txtSinav1.Text);
            sinav2 = Convert.ToInt16(txtSinav2.Text);
            sinav3 = Convert.ToInt16(txtSinav3.Text);
            proje = Convert.ToInt16(txtProje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4.00;
            txtOrtalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                txtDurum.Text = "True";
            }
            else
            {
                txtDurum.Text = "False";
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(cmbKulup.SelectedValue.ToString()),int.Parse(txtID.Text.ToString()),byte.Parse(txtSinav1.ToString()), byte.Parse(txtSinav2.ToString()), byte.Parse(txtSinav3.ToString()), byte.Parse(txtProje.ToString()),decimal.Parse(txtOrtalama.Text),bool.Parse(txtDurum.Text),notid );
        }
    }
}
