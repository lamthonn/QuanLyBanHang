using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Luong : Form
    {
        public Luong()
        {
            InitializeComponent();
        }
        connect kn = new connect();

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TrangChu frmHT = new TrangChu();
            frmHT.Show();
            this.Close();
        }

        private void Luong_Load(object sender, EventArgs e)
        {
            getdata();
        }

        public void getdata()
        {
            string truyVan = @"SELECT * FROM Luong";
            dgvLuong.DataSource = kn.LayDuLieu(truyVan);
        }
    }
}
