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
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void quảnLýLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Luong frmLuong = new Luong();
            //TrangChu frmHT = new TrangChu();
            //frmLuong.MdiParent = this;
            frmLuong.Show();
            this.Hide();
        }

        private void quảnLýThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien frmNhanVien = new NhanVien();
            frmNhanVien.Show();
            this.Hide();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Login frmLogin = new Login();
            frmLogin.Show();
            this.Close();
        }
    }
}
