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

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DangNhap frmLogin = new DangNhap();
            frmLogin.Show();
            this.Close();
        }

        private void btnQLNV_Click_1(object sender, EventArgs e)
        {
            NhanVien frmNhanVien = new NhanVien();
            frmNhanVien.Show();
            this.Hide();
        }

        private void btnQLL_Click_1(object sender, EventArgs e)
        {
            Luong frmLuong = new Luong();
            //TrangChu frmHT = new TrangChu();
            //frmLuong.MdiParent = this;
            frmLuong.Show();
            this.Hide();
        }

        private void btnQLNCC_Click_1(object sender, EventArgs e)
        {
            NhaCungCap frmNhaCungCap = new NhaCungCap();
            frmNhaCungCap.Show();
            this.Hide();
        }

        private void btnQLSP_Click_1(object sender, EventArgs e)
        {
            SanPham frmSanPham = new SanPham();
            frmSanPham.Show();
            this.Hide();
        }

        private void btnQLPN_Click_1(object sender, EventArgs e)
        {
            PhieuNhap frmPhieuNhap = new PhieuNhap();
            frmPhieuNhap.Show();
            this.Hide();
        }

        private void btnQLPX_Click_1(object sender, EventArgs e)
        {
            HoaDon frmHoaDon = new HoaDon();
            frmHoaDon.Show();
            this.Hide();
        }

        private void btnTKDT_Click(object sender, EventArgs e)
        {
            ThongKeDoanhthu frm = new ThongKeDoanhthu();
            frm.Show();
            this.Hide();
        }


        //private void quảnLýPhiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    HoaDon frmHoaDon = new HoaDon();
        //    frmHoaDon.Show();
        //    this.Hide();
        //}

    }
}
