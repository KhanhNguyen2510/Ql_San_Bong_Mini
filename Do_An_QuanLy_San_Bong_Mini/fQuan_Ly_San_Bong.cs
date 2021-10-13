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
    public partial class fQuan_Ly_San_Bong : Form
    {
        public fQuan_Ly_San_Bong()
        {
            InitializeComponent();
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

        private void fQuan_Ly_San_Bong_Load(object sender, EventArgs e)
        {
            loadSanBong();
        }
        public void loadSanBong()
        {
            using (DataClassesTestDataContext db = new DataClassesTestDataContext())
            {
                dtvgQL_SanBong.ClearSelection();
                dtvgQL_SanBong.DataSource = db.SANBONGs.ToList();
            }
        }
        public void resetText()
        {
            txtID.Clear();
            txtName.Clear();
            txtAcreage.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtID.Enabled = true;
            txtID.Focus();
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            resetText();
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
                    SANBONG nv = new SANBONG();
                    nv.MaSB = txtID.Text;
                    nv.TenSB = txtName.Text;
                    nv.Dientich = txtAcreage.Text;
                    db.SANBONGs.InsertOnSubmit(nv);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công!", "Thông Báo");
                    loadSanBong();
                    resetText();
                }
            }

        }

        private void dtvgQL_SanBong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SANBONG kh = dtvgQL_SanBong.CurrentRow.DataBoundItem as SANBONG;
            txtID.Text = kh.MaSB;
            txtName.Text = kh.TenSB;
            txtAcreage.Text = kh.Dientich;
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            if (dtvgQL_SanBong.CurrentRow == null)
            {
                return;
            }
            using (DataClassesTestDataContext db = new DataClassesTestDataContext())
            {
                SANBONG khOld = dtvgQL_SanBong.CurrentRow.DataBoundItem as SANBONG;
                SANBONG khNew = db.SANBONGs.Where(ma => ma.MaSB == khOld.MaSB).First();
                db.SANBONGs.DeleteOnSubmit(khNew);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công!", "Thông Báo");
                loadSanBong();
                resetText();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dtvgQL_SanBong.CurrentRow == null)
            {
                return;
            }
            using (DataClassesTestDataContext db = new DataClassesTestDataContext())
            {
                SANBONG khOld = dtvgQL_SanBong.CurrentRow.DataBoundItem as SANBONG;
                SANBONG khNew = db.SANBONGs.Where(ma => ma.MaSB == khOld.MaSB).First();
                khNew.MaSB = txtID.Text;
                khNew.TenSB = txtName.Text;
                khNew.Dientich = txtAcreage.Text;
                db.SubmitChanges();
                MessageBox.Show("Thay đổi thành công", "Thông Báo");
                loadSanBong();
                resetText();
            }
        }

        private void dtvgQL_SanBong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
