using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_QuanLy_San_Bong_Mini
{
    public partial class fTest : Form
    {
        DataClassesTestDataContext db = new DataClassesTestDataContext();
        public fTest()
        {
            InitializeComponent();
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            loadNhanVien();
            loadSanBong();
            loadDichVu();
        }
        public void loadNhanVien()
        {
            ////Tạo nút gốc
            //TreeNode root = new TreeNode("Họ tên nhân viên");
            //root.Tag = 0;
            ////Duyệt nhân viên
            //foreach (var dep in db.NHANVIENs)
            //{
            //    TreeNode tenNV = new TreeNode(dep.MA_NHANVIEN, 0, 0);
            //    tenNV.Tag = dep.MA_NHANVIEN;
            //    root.Nodes.Add(tenNV);
            //}
            ////Dưa nút gốc lên treeview
            //trvNhanVien.Nodes.Add(root);
            //trvNhanVien.ExpandAll();
        }
        private void trvNhanVien_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ////Clear
            //lvNhanVien.Items.Clear();
            ////Lấy mã nhân viên
            //string ma = e.Node.Tag.ToString();
            ////Lấy danh sách nhân viên theo mã nhân viên
            //var listNV = from r in db.NHANVIENs
            //             where r.MA_NHANVIEN == ma
            //             select new {r.MA_NHANVIEN, r.TEN_NHANVIEN, r.NGAY_SINH, r.GIOI_TINH, r.SDT };
            //foreach (var r in listNV)
            //{
            //    ListViewItem item = new ListViewItem(r.MA_NHANVIEN.ToString());
            //    item.ImageIndex = r.GIOI_TINH.Value ? 1 : 2;
            //    item.SubItems.Add(r.TEN_NHANVIEN);
            //    item.SubItems.Add(r.NGAY_SINH.ToString("dd/MM/yyyy"));
            //    item.SubItems.Add(r.SDT);
            //    lvNhanVien.Items.Add(item);
            //}
        }

        private void lvNhanVien_Click(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lvNhanVien.SelectedItems[0];
                MessageBox.Show(item.Text + ":" + item.SubItems[1].Text + ":" + item.SubItems[2].Text);
            }
        }

        private void radLageIcon_Click(object sender, EventArgs e)
        {
            lvNhanVien.View = View.LargeIcon;
        }

        private void radSmallicon_CheckedChanged(object sender, EventArgs e)
        {
            lvNhanVien.View = View.SmallIcon;
        }

        private void radDetails_CheckedChanged(object sender, EventArgs e)
        {
            lvNhanVien.View = View.Details;
        }
        //Sân bóng
        public void loadSanBong()
        {
            ////Tạo nút gốc
            //TreeNode root = new TreeNode("Loại Sân", 3, 3);
            //root.Tag = 0;
            ////Duyệt nhân viên
            //foreach (var dep in db.LOAI_SANs)
            //{
            //    TreeNode sb = new TreeNode(dep.TEN_LS, 3, 3);
            //    sb.Tag = dep.MA_LS;
            //    root.Nodes.Add(sb);
            //}
            ////Dưa nút gốc lên treeview
            //trvSanBong.Nodes.Add(root);
            //trvSanBong.ExpandAll();
        }
        private void trvSanBong_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ////Clear
            //lvSanBong.Items.Clear();
            ////Lấy mã nhân viên
            //string ma = e.Node.Tag.ToString();
            ////Lấy danh sách nhân viên theo mã nhân viên
            //var listSB = from r in db.SAN_BONGs
            //             where r.MA_LS.ToString() == ma
            //             select new { r.MA_SB, r.TEN_SB, r.TRANG_THAI};
            //foreach (var r in listSB)
            //{
            //    ListViewItem item = new ListViewItem(r.MA_SB.ToString());
            //    item.SubItems.Add(r.TEN_SB);
            //    item.SubItems.Add(r.TRANG_THAI);
            //    lvSanBong.Items.Add(item);
            //}
        }
        //Dịch vụ
        public void loadDichVu()
        {
            ////Tạo nút gốc
            //TreeNode root = new TreeNode("Loại dịch vụ");
            //root.Tag = 0;
            ////Duyệt nhân viên
            //foreach (var dep in db.LOAI_DICH_VUs)
            //{
            //    TreeNode sb = new TreeNode(dep.TEN_LDV, 3, 3);
            //    sb.Tag = dep.MA_LDV;
            //    root.Nodes.Add(sb);
            //}
            ////Dưa nút gốc lên treeview
            //trvDichVu.Nodes.Add(root);
            //trvDichVu.ExpandAll();
        }

        private void trvDichVu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ////Clear
            //lvDichVu.Items.Clear();
            ////Lấy mã nhân viên
            //string ma = e.Node.Tag.ToString();
            ////Lấy danh sách nhân viên theo mã nhân viên
            //var listSB = from r in db.DICH_VUs
            //             where r.MA_LDV.ToString() == ma
                         
            //             select new { r.MA_DV, r.TEN_DV, r.GIA };
            //foreach (var r in listSB)
            //{
            //    ListViewItem item = new ListViewItem(r.MA_DV.ToString());
            //    item.SubItems.Add(r.TEN_DV);
            //    item.SubItems.Add(r.GIA.ToString());
            //    lvDichVu.Items.Add(item);
            //}
        }
    }
}
