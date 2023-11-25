using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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

        public void refresh_tb()
        {
            txtMaBL.Text = "";
            txtMaNV.Text = "";
            txtNgayCong.Text = "";
            txtHSLuong.Text = "";
            txtNgayCong.Text = "";
            cbThang.Text = "";
        }

        private string tinhLuong(string hsluong, string ngaycong, string Thuong)
        {
            string tongluong = "";
            if (hsluong != "" && ngaycong != "")
            {
                if (txtThuong.Text != "")
                {
                    float HSLuong = Convert.ToInt32(hsluong);
                    int ngayCong = Convert.ToInt32(ngaycong);
                    float thuong = Convert.ToInt32(Thuong);
                    tongluong = ((HSLuong * ngayCong) + thuong).ToString();
                }
                else
                {
                    float HSLuong = Convert.ToInt32(hsluong);
                    int ngayCong = Convert.ToInt32(ngaycong);
                    tongluong = (HSLuong * ngayCong).ToString();
                }
            }
            else
            {
                if (hsluong == "")
                {
                    MessageBox.Show("Nhập hệ số lương!");
                }
                else
                {
                    if (ngaycong == "")
                    {
                        MessageBox.Show("Nhập số ngày Công");
                    }
                }
            }

            return tongluong;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            string truyVan = $"INSERT INTO Luong VALUES ('{txtMaBL.Text}','{txtMaNV.Text}',{txtNgayCong.Text},{txtHSLuong.Text},{txtThuong.Text},{tinhLuong(txtHSLuong.Text, txtNgayCong.Text, txtThuong.Text)},{cbThang.Text})";

            if (txtMaNV.Text != "")
            {
                if (kn.ThucThi(truyVan))
                {
                    MessageBox.Show("Thêm thành công!");
                    getdata();
                    refresh_tb();
                }
            }
            else
            {
                MessageBox.Show("Nhập mã nhân viên!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            string truyVan = string.Format("UPDATE LUONG SET ngayCong ={2}, HSluong = {3}, Thuong = {4}, tongLuong ={5}, thang ='{6}' WHERE maNV ='{1}'AND maBangLuong ='{0}'",
                                            txtMaBL.Text,
                                            txtMaNV.Text,
                                            txtNgayCong.Text,
                                            txtHSLuong.Text,
                                            txtThuong.Text,
                                            tinhLuong(txtHSLuong.Text, txtNgayCong.Text, txtThuong.Text),
                                            cbThang.Text);

            if (txtMaNV.Text != "")
            {
                if (kn.ThucThi(truyVan))
                {
                    MessageBox.Show("sửa thành công!");
                    getdata();
                    refresh_tb();
                }
            }
            else
            {
                MessageBox.Show("Nhập mã nhân viên!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string truyVan = string.Format("DELETE FROM Luong WHERE maBangLuong = '{0}' AND maNV ='{1}'",
                                            txtMaBL.Text,
                                            txtMaNV.Text);

            if (txtMaNV.Text != "")
            {
                if(txtMaBL.Text != "")
                {
                    if (kn.ThucThi(truyVan))
                    {
                        MessageBox.Show("Xóa thành công!");
                        getdata();
                        refresh_tb();
                    }
                }
                else
                {
                    MessageBox.Show("Nhập mã bảng lương!");
                }
            }
            else
            {
                MessageBox.Show("Nhập mã nhân viên!");
            }
        }

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if(r >= 0)
            {
                txtMaBL.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                txtMaBL.Text = dgvLuong.Rows[r].Cells["maBangLuong"].Value.ToString();
                txtMaNV.Text = dgvLuong.Rows[r].Cells["maNV"].Value.ToString();
                txtNgayCong.Text = dgvLuong.Rows[r].Cells["ngayCong"].Value.ToString();
                txtHSLuong.Text = dgvLuong.Rows[r].Cells["HSLuong"].Value.ToString();
                txtThuong.Text = dgvLuong.Rows[r].Cells["Thuong"].Value.ToString();
                cbThang.Text = dgvLuong.Rows[r].Cells["thang"].Value.ToString();

            }
            


        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string truyVan = string.Format(@"SELECT *  FROM Luong  WHERE maBangLuong LIKE N'%{0}%' OR maNV LIKE N'%{0}%' OR ngayCong LIKE N'%{0}%' OR HSluong LIKE N'%{0}%' OR Thuong LIKE '%{0}%' OR tongLuong LIKE N'%{0}%' OR thang LIKE '%{0}%'", txtTimKiem.Text);
            dgvLuong.DataSource = kn.LayDuLieu(truyVan);
        }
    }
}
