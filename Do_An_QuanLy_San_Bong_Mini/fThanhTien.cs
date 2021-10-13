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
    public partial class fThanhTien : Form
    {
        public fThanhTien()
        {
            InitializeComponent();
        }

        private void fdem_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.HDTHANHTOANs.ToList();
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }
        DataClassesTestDataContext db = new DataClassesTestDataContext();
        public void load()
        {
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

        private void btnDeChoi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xin Lỗi Chúng Tôi Đang Update Thêm Chức Năng Này. Xin Cám Ơn", "Thông Báo");
        }
    }
}
