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
    public partial class fQuan_Ly_Nhan_Vien : Form
    {
        public fQuan_Ly_Nhan_Vien()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn đăng xuất không ?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (r == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void fQuan_Ly_Nhan_Vien_Load(object sender, EventArgs e)
        {
            loadNhanVien();
        }
        public void loadNhanVien()
        {
            using (DataClassesTestDataContext db = new DataClassesTestDataContext())
            {
                dtvgQL_NhanVien.ClearSelection();
                dtvgQL_NhanVien.DataSource = db.NHANVIENs.ToList();
            }
        }
        // Xóa trống textbox
        public void resetTextBox()
        {
            txtID.Clear();
            txtName.Clear();
            txtPhoneNumber.Clear();
            numPrice.Value = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtID.Enabled = true;
            txtID.Focus();
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            resetTextBox();
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
                    NHANVIEN nv = new NHANVIEN();
                    nv.MaNV = txtID.Text;
                    nv.TenNV = txtName.Text;
                    nv.Gioitinh = cboGioiTinh.GetItemText(this.cboGioiTinh.SelectedItem);
                    nv.Ngaysinh = dtpkDate.Value;
                    nv.SDT = txtPhoneNumber.Text;
                    nv.LuongThang = numPrice.Value;
                    db.NHANVIENs.InsertOnSubmit(nv);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công!", "Thông Báo");
                    loadNhanVien();
                    resetTextBox();
                }

            }
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            if (dtvgQL_NhanVien.CurrentRow == null)
            {
                return;
            }
            using (DataClassesTestDataContext db = new DataClassesTestDataContext())
            {
                NHANVIEN nvOld = dtvgQL_NhanVien.CurrentRow.DataBoundItem as NHANVIEN;
                NHANVIEN nvNew = db.NHANVIENs.Where(ma => ma.MaNV == nvOld.MaNV).First();
                db.NHANVIENs.DeleteOnSubmit(nvNew);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công!", "Thông Báo");
                loadNhanVien();
                resetTextBox();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dtvgQL_NhanVien.CurrentRow == null)
            {
                return;
            }
            using (DataClassesTestDataContext db = new DataClassesTestDataContext())
            {
                NHANVIEN nvOld = dtvgQL_NhanVien.CurrentRow.DataBoundItem as NHANVIEN;
                NHANVIEN nvNew = db.NHANVIENs.Where(ma => ma.MaNV == nvOld.MaNV).First();
                nvNew.MaNV = txtID.Text;
                nvNew.TenNV = txtName.Text;
                nvNew.Gioitinh = cboGioiTinh.GetItemText(this.cboGioiTinh.SelectedItem);
                nvNew.Ngaysinh = dtpkDate.Value;
                nvNew.SDT = txtPhoneNumber.Text;
                nvNew.LuongThang = numPrice.Value;
                db.SubmitChanges();
                MessageBox.Show("Thay đổi thành công", "Thông Báo");
                loadNhanVien();
                resetTextBox();
            }
        }

        private void dtvgQL_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NHANVIEN nv = dtvgQL_NhanVien.CurrentRow.DataBoundItem as NHANVIEN;
            txtID.Text = nv.MaNV;
            txtName.Text = nv.TenNV;
            cboGioiTinh.SelectedItem = nv.Gioitinh;
            dtpkDate.Value = Convert.ToDateTime(dtpkDate.Text);
            txtPhoneNumber.Text = nv.SDT;
            numPrice.Value = nv.LuongThang;
        }

    }
}
