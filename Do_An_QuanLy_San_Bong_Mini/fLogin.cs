using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_QuanLy_San_Bong_Mini
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
            
        }
       
        private void fLogin_Load(object sender, EventArgs e)
        {
            
        }
        DataClassesTestDataContext db = new DataClassesTestDataContext();
        public TAIKHOAN nv;
        private void LoadData()
        {
            fAdmin frChinh = new fAdmin();
            frChinh.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (NV(txtUser.Text, txtPassword.Text) || KH(txtUser.Text, txtPassword.Text))
            {
                RadioButton ckb = null;
                foreach (RadioButton item in pnl.Controls)
                {
                    if (item != null)
                    {
                        if (item.Checked == true)
                        {
                            ckb = item;
                            if (radAdmin.Checked == true)
                            {
                                MessageBox.Show("Đăng Nhập Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                fAdmin fr = new fAdmin();
                                fr.Show();
                                return;
                            }
                            if (radKhachHang.Checked == true)
                            {
                                MessageBox.Show("Đăng Nhập Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                fThanhTien f = new fThanhTien();
                                f.Show();
                                return;
                            }
                        }
                        if ((radAdmin.Checked || radKhachHang.Checked) == false)
                        {
                            MessageBox.Show("Vui lòng chọn ADMIN hoặc Khách Hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtUser.Focus();
            }
   
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát  ?", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private bool NV(string userName, string password)
        {
            DataClassesTestDataContext context = new DataClassesTestDataContext();
            {
                var q = from p in context.TAIKHOANs
                        where p.MADN == txtUser.Text
                        && p.Pass == txtPassword.Text
                        select p;
                if (q.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool KH(string userName, string password)
        {
            DataClassesTestDataContext context = new DataClassesTestDataContext();
            {
                var q = from p in context.TAIKHOANs
                        where p.MADN == txtUser.Text
                        && p.Pass == txtPassword.Text
                        select p;
                if (q.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

            DataClassesTestDataContext login = new DataClassesTestDataContext();
            {
                NHANVIEN nv = new NHANVIEN();
                KHACHHANG kh = new KHACHHANG();
                if (txtUser.Text == "NV")
                {
                    radAdmin.Enabled = true;
                    radKhachHang.Enabled = false;
                }
                else if (txtUser.Text == "KH")
                {
                    radKhachHang.Enabled = true;
                    radAdmin.Enabled = false;
                }
                else if (txtUser.Text == "")
                {
                    radKhachHang.Enabled = true;
                    radAdmin.Enabled = true;
                }
            }
        }

        private void radAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}


