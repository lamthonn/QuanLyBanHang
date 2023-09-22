﻿using System;
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
    public partial class NhanVien : Form
    {
        public NhanVien()
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

        private void NhanVien_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            string truyVan = "SELECT * FROM NhanVien";
            dgvNhanVien.DataSource = kn.LayDuLieu(truyVan);
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            clearText();
            GetData();
        }

        public void clearText()
        {
            txtMaNV.Text = string.Empty;
            txtTenNV.Text = string.Empty;
            cmbGioiTinh.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtCCCD.Text = string.Empty;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string truyVan = string.Format("INSERT INTO NhanVien VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}')", txtMaNV.Text,
                                     txtTenNV.Text,
                                     dtpNgaySinh.Value,
                                     cmbGioiTinh.Text,
                                     txtSDT.Text,
                                     txtDiaChi.Text,
                                     txtCCCD.Text
                                    );
            
            if(txtMaNV.Text != ""  &&  txtTenNV.Text != "")
            {
                if (kn.ThucThi(truyVan))
                {
                    MessageBox.Show("Thêm thành công!");
                    btnNhapLai.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("Nhập mã nhân viên và tên nhân viên");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
                string truyVan = string.Format("UPDATE NhanVien\r\nSET tenNV = '{1}', ngaySinh= '{2}', gioiTinh= '{3}' , sdt= '{4}', diaChi='{5}', cccd = '{6}'\r\nWHERE maNV = '{0}'", txtMaNV.Text,
                                         txtTenNV.Text,
                                         dtpNgaySinh.Value,
                                         cmbGioiTinh.Text,
                                         txtSDT.Text,
                                         txtDiaChi.Text,
                                         txtCCCD.Text
                                        );

                if (txtMaNV.Text != "")
                {
                    if (kn.ThucThi(truyVan))
                    {
                        MessageBox.Show("Sửa thành công!");
                        btnNhapLai.PerformClick();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên!");
                }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String truyVan = string.Format("DELETE FROM NhanVien WHERE maNV ='{0}'", txtMaNV.Text);

            if (txtMaNV.Text != "")
            {
                if (kn.ThucThi(truyVan))
                {
                    MessageBox.Show("Xóa thành công!");
                    btnNhapLai.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã nhân viên!");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string truyVan = string.Format("SELECT *  FROM NhanVien  WHERE maNV LIKE N'%{0}%' OR \n tenNV LIKE N'%{0}%' OR \n ngaySinh LIKE N'%{0}%' OR \n  gioiTinh LIKE N'%{0}%' OR \n sdt LIKE '%{0}%' OR \n diaChi LIKE N'%{0}%' OR \n cccd LIKE '%{0}%'", txtTimKiem.Text);
            dgvNhanVien.DataSource = kn.LayDuLieu(truyVan);

        }
    }
}
