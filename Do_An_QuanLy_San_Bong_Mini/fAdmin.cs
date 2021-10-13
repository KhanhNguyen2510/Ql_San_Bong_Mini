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
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn đăng xuất không ?","Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (r == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                return;
            }
            
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuan_Ly_Nhan_Vien f = new fQuan_Ly_Nhan_Vien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void quảnLýSânBóngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuan_Ly_San_Bong f = new fQuan_Ly_San_Bong();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        
        public static string tendangnhap = "";
        private void fAdmin_Load(object sender, EventArgs e)
        {
            label1.Text = tendangnhap; 
        }
        private void đăngXuấtToolStripMenuItem_Click_2(object sender, EventArgs e)
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

        private void đặtSânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FromDatSan f = new FromDatSan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKhach_Hang f = new fKhach_Hang();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
