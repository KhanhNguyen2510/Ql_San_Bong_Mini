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
    public partial class fKhach_Hang : Form
    {
        public fKhach_Hang()
        {
            InitializeComponent();
        }
        public void loadKhachHang()
        {
            using (DataClassesTestDataContext db = new DataClassesTestDataContext())
            {
                dtvgKhachHang.ClearSelection();
                dtvgKhachHang.DataSource = db.KHACHHANGs.ToList();
            }
        }
        // Xóa trống các Testbox
        public void resetTextBox()
        {
            txtID.Clear();
            txtName.Clear();
            txtPhoneNumber.Clear();
            txtNote.Clear();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtID.Enabled = true;
            txtID.Focus();
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            resetTextBox();
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            if (dtvgKhachHang.CurrentRow == null)
            {
                return;
            }
            using (DataClassesTestDataContext db = new DataClassesTestDataContext())
            {
                KHACHHANG khOld = dtvgKhachHang.CurrentRow.DataBoundItem as KHACHHANG;
                KHACHHANG khNew = db.KHACHHANGs.Where(ma => ma.MaKH == khOld.MaKH).First();
                db.KHACHHANGs.DeleteOnSubmit(khNew);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công!", "Thông Báo");
                loadKhachHang();
                resetTextBox();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (DataClassesTestDataContext db = new DataClassesTestDataContext())
            {
                if (txtID.Text == "")
                {
                    MessageBox.Show("Bạn chưa điền đầy đủ thông tin !!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    KHACHHANG kh = new KHACHHANG();
                    kh.MaKH = txtID.Text;
                    kh.TenKH = txtName.Text;
                    kh.Gioitinh = cboGioiTinh.GetItemText(this.cboGioiTinh.SelectedItem);
                    kh.SDT = txtPhoneNumber.Text;
                    kh.Ghichu = txtNote.Text;
                    db.KHACHHANGs.InsertOnSubmit(kh);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công!", "Thông Báo");
                    loadKhachHang();
                    resetTextBox();
                }

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dtvgKhachHang.CurrentRow == null)
            {
                return;
            }
            using (DataClassesTestDataContext db = new DataClassesTestDataContext())
            {
                KHACHHANG khOld = dtvgKhachHang.CurrentRow.DataBoundItem as KHACHHANG;
                KHACHHANG khNew = db.KHACHHANGs.Where(ma => ma.MaKH == khOld.MaKH).First();
                khNew.MaKH = txtID.Text;
                khNew.TenKH = txtName.Text;
                khNew.Gioitinh = cboGioiTinh.GetItemText(this.cboGioiTinh.SelectedItem);
                khNew.SDT = txtPhoneNumber.Text;
                khNew.Ghichu = txtNote.Text;
                db.SubmitChanges();
                MessageBox.Show("Thay đổi thành công", "Thông Báo");
                loadKhachHang();
                resetTextBox();
            }
        }

        private void dtvgKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            KHACHHANG kh = dtvgKhachHang.CurrentRow.DataBoundItem as KHACHHANG;
            txtID.Text = kh.MaKH;
            txtName.Text = kh.TenKH;
            cboGioiTinh.SelectedItem = kh.Gioitinh;
            txtPhoneNumber.Text = kh.SDT;
            txtNote.Text = kh.Ghichu;
        }

        private void fKhach_Hang_Load(object sender, EventArgs e)
        {
            loadKhachHang();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (r == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void dtvgKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
