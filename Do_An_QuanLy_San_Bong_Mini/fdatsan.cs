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
    public partial class fdatsan : Form
    {
        public fdatsan()
        {
            InitializeComponent();
            Loaddulieu();

            if (t3.TimeOfDay <= t1.TimeOfDay && t1.TimeOfDay <= t4.TimeOfDay)
            {
                MessageBox.Show("Khoign");

            }
            else if (t5.TimeOfDay <= t1.TimeOfDay && t1.TimeOfDay <= t6.TimeOfDay)
            {
                MessageBox.Show("ga");
            }
        }

        public void Loaddulieu()
        {
            dataGridView1.DataSource = db.PHIEUDATSANs.Where(n => n.Trangthai == "Chưa thanh toán").ToList();


            var tts = from hd in db.PHIEUDATSANs.Where(n => n.Magio == lbgiothue.Text)
                      join kk in db.GIAGIOTHUEs on hd.Magio equals kk.Magio
                      select new
                      {
                          thanhtien = kk.Dongia
                      };



        }
        DataClassesTestDataContext db = new DataClassesTestDataContext();

        int count = 90;
        int count1 = 90;
        int count3 = 90;
        int count4 = 90;
        int count5 = 90;
        int count6 = 90;
        int count7 = 90;
        int count8 = 90;

        DateTime t1 = DateTime.Parse(DateTime.Now.ToString("HH:mm"));
        DateTime t3 = DateTime.Parse("8:00");
        DateTime t4 = DateTime.Parse("16:59");
        DateTime t5 = DateTime.Parse("17:00");
        DateTime t6 = DateTime.Parse("21:00");
        
     

        private void timer1_Tick(object sender, EventArgs e)
        {

            lbsan1.Text = count.ToString();
            count--;

            if (count == 0)
            {

                btnsan1.Enabled = true;
                thongbao.Text = "";
                lbsan1.Text = "";
                count = 90;
                timer1.Stop();

            }
        }

        public static string maphieu = "";
        private void btnsan1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                {
                    DateTime dt = DateTime.Now;
                    if (dateTimePicker1.Value <= dt)
                    {
                        timer1.Start();
                        btnsan1.Enabled = false;
                        thoigian.Text = dt.ToString("HH:mm") + " " + "(" + dt.ToString("dd/MM/yyyy") + ")";
                        (thoigian).Visible = true;
                        lblaysan.Text = dt.ToString("dd/MM/yyyy");
                        thongbao.Text = "Đang sữ dụng";
                        lbsanbong.Text = "S5_1";
                      
                            PHIEUDATSAN ds = new PHIEUDATSAN();
                            ds.MaNV = "NV001";
                            ds.MaKH = textBox2.Text;
                            ds.MaSB = "S5_1";
                            ds.Magio = "S5_8h_16h";
                            ds.Trangthai = "Chưa thanh toán";
                            ds.Ngaydatsan = dateTimePicker1.Value;
                            ds.Ngaylap = dt;
                            db.PHIEUDATSANs.InsertOnSubmit(ds);
                            db.SubmitChanges();
                            Loaddulieu();
                     
                    }
                    else
                    {
                        MessageBox.Show("Ngày của bạn không được lớn hơn ngày hiện tại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
            }
            else
            {
                textBox2.Select();
                MessageBox.Show("Thông tin bị để trống rồi", "Chú ý", MessageBoxButtons.OK);
            }

        }
        private void btns2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                {
                    DateTime dt = DateTime.Now;
                    if (dateTimePicker1.Value <= dt)
                    {
                        timer2.Start();
                        btns2.Enabled = false;

                        thoigian1.Text = dt.ToString("HH:mm") + " " + "(" + dt.ToString("dd/MM/yyyy") + ")";
                        (thoigian1).Visible = true;
                        lblaysan.Text = dt.ToString("dd/MM/yyyy");
                        thongbao2.Text = "Đang sữ dụng";
                        PHIEUDATSAN ds = new PHIEUDATSAN();
                        ds.MaNV = "NV001";
                        // lbnhanvien.Text = fAdmin.tendangnhap;
                        ds.MaKH = textBox2.Text;
                        lbsanbong.Text = "S5_2";
                        ds.MaSB = "S5_2";
                        if (t3.TimeOfDay <= t1.TimeOfDay && t1.TimeOfDay <= t4.TimeOfDay)
                        {
                            lbgiothue.Text = "S5_8h_16h";
                            ds.Magio = "S5_8h_16h";
                            ds.Ngaydatsan = dateTimePicker1.Value;
                            ds.Ngaylap = dt;
                            db.PHIEUDATSANs.InsertOnSubmit(ds);
                            db.SubmitChanges();
                            MessageBox.Show("Thanh cong");
                            Loaddulieu();
                        }
                        else if (t5.TimeOfDay <= t1.TimeOfDay && t1.TimeOfDay <= t6.TimeOfDay)
                        {
                            lbgiothue.Text = "S5_17h_21h";
                            ds.Magio = "S5_17h_21h";
                            ds.Ngaydatsan = dateTimePicker1.Value;
                            ds.Ngaylap = dt;
                            db.PHIEUDATSANs.InsertOnSubmit(ds);
                            db.SubmitChanges();
                            MessageBox.Show("Thanh cong");
                            Loaddulieu();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ngày của bạn không được lớn hơn ngày hiện tại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
            }
            else
            {
                textBox2.Select();
                MessageBox.Show("Thông tin bị để trống rồi", "Chú ý", MessageBoxButtons.OK);
            }

        }

        private void FromDatSan_Load(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            lbsan2.Text = count1.ToString();
            count1--;

            if (count1 == 0)
            {

                btns2.Enabled = true;
                thongbao2.Text = "";
                lbsan2.Text = "";
                count1 = 90;
                timer2.Stop();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            lbsan3.Text = count3.ToString();
            count3--;

            if (count3 == 0)
            {
                timer3.Stop();
                btnsan3.Enabled = true;
                thongbao3.Text = "";
                lbsan3.Text = "";
                count3 = 90;
                return;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            lbsan4.Text = count4.ToString();
            count4--;

            if (count4 == 0)
            {
                timer4.Stop();
                btnsan4.Enabled = true;
                thongbao4.Text = "";
                lbsan4.Text = "";
                count4 = 90;
                return;
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            lbsan5.Text = count5.ToString();
            count5--;

            if (count5 == 0)
            {
                timer5.Stop();
                btnsan5.Enabled = true;
                thongbao5.Text = "";
                lbsan5.Text = "";
                count5 = 90;
                return;
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            lbsan6.Text = count6.ToString();
            count6--;

            if (count6 == 0)
            {
                timer6.Stop();
                btnsan6.Enabled = true;
                thongbao6.Text = "";
                lbsan6.Text = "";
                count6 = 90;
                return;
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            lbsan7.Text = count7.ToString();
            count7--;

            if (count7 == 0)
            {
                timer7.Stop();
                btnsan7.Enabled = true;
                thongbao7.Text = "";
                lbsan7.Text = "";
                count7 = 90;
                return;
            }
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            lbsan8.Text = count8.ToString();
            count8--;

            if (count8 == 0)
            {
                timer8.Stop();
                btnsan8.Enabled = true;
                thongbao8.Text = "";
                lbsan8.Text = "";
                count8 = 90;
                return;
            }
        }

        private void btnsan3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                {
                    DateTime dt = DateTime.Now;
                    if (dateTimePicker1.Value <= dt)
                    {
                        timer3.Start();
                        btnsan3.Enabled = false;

                        thoigian2.Text = dt.ToString("HH:mm") + " " + "(" + dt.ToString("dd/MM/yyyy") + ")";
                        (thoigian2).Visible = true;
                        lblaysan.Text = dt.ToString("dd/MM/yyyy");
                        thongbao3.Text = "Đang sữ dụng";
                        PHIEUDATSAN ds = new PHIEUDATSAN();
                        ds.MaNV = "NV001";
                        // lbnhanvien.Text = fAdmin.tendangnhap;
                        ds.MaKH = textBox2.Text;
                        lbsanbong.Text = "S5_3";
                        ds.MaSB = "S5_3";
                        if (t3.TimeOfDay <= t1.TimeOfDay && t1.TimeOfDay <= t4.TimeOfDay)
                        {
                            lbgiothue.Text = "S5_8h_16h";
                            ds.Magio = "S5_8h_16h";
                            ds.Ngaydatsan = dateTimePicker1.Value;
                            ds.Ngaylap = dt;
                            db.PHIEUDATSANs.InsertOnSubmit(ds);
                            db.SubmitChanges();
                            Loaddulieu();
                        }
                        else if (t5.TimeOfDay <= t1.TimeOfDay && t1.TimeOfDay <= t6.TimeOfDay)
                        {
                            lbgiothue.Text = "S5_17h_21h";
                            ds.Magio = "S5_17h_21h";
                            ds.Ngaydatsan = dateTimePicker1.Value;
                            ds.Ngaylap = dt;
                            db.PHIEUDATSANs.InsertOnSubmit(ds);
                            db.SubmitChanges();
                            Loaddulieu();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ngày của bạn không được lớn hơn ngày hiện tại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
            }
            else
            {
                textBox2.Select();
                MessageBox.Show("Thông tin bị để trống rồi", "Chú ý", MessageBoxButtons.OK);
            }

        }

        private void btnsan4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                {
                    DateTime dt = DateTime.Now;
                    if (dateTimePicker1.Value <= dt)
                    {
                        timer4.Start();
                        btnsan4.Enabled = false;

                        thoigian4.Text = dt.ToString("HH:mm") + " " + "(" + dt.ToString("dd/MM/yyyy") + ")";
                        (thoigian4).Visible = true;
                        lblaysan.Text = dt.ToString("dd/MM/yyyy");
                        thongbao4.Text = "Đang sữ dụng";
                        PHIEUDATSAN ds = new PHIEUDATSAN();
                        ds.MaNV = "NV001";
                        // lbnhanvien.Text = fAdmin.tendangnhap;
                        ds.MaKH = textBox2.Text;
                        lbsanbong.Text = "S5_4";
                        ds.MaSB = "S5_4";
                        if (t3.TimeOfDay <= t1.TimeOfDay && t1.TimeOfDay <= t4.TimeOfDay)
                        {
                            lbgiothue.Text = "S5_8h_16h";
                            ds.Magio = "S5_8h_16h";
                            ds.Ngaydatsan = dateTimePicker1.Value;
                            ds.Ngaylap = dt;
                            db.PHIEUDATSANs.InsertOnSubmit(ds);
                            db.SubmitChanges();
                            Loaddulieu();
                        }
                        else if (t5.TimeOfDay <= t1.TimeOfDay && t1.TimeOfDay <= t6.TimeOfDay)
                        {
                            lbgiothue.Text = "S5_17h_21h";
                            ds.Magio = "S5_17h_21h";
                            ds.Ngaydatsan = dateTimePicker1.Value;
                            ds.Ngaylap = dt;
                            db.PHIEUDATSANs.InsertOnSubmit(ds);
                            db.SubmitChanges();
                            Loaddulieu();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ngày của bạn không được lớn hơn ngày hiện tại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
            }
            else
            {
                textBox2.Select();
                MessageBox.Show("Thông tin bị để trống rồi", "Chú ý", MessageBoxButtons.OK);
            }

        }

        private void btnsan5_Click(object sender, EventArgs e)
        {

            {
                if (textBox2.Text != "")
                {
                    {
                        DateTime dt = DateTime.Now;
                        if (dateTimePicker1.Value <= dt)
                        {
                            timer5.Start();
                            btnsan5.Enabled = false;

                            thoigian5.Text = dt.ToString("HH:mm") + " " + "(" + dt.ToString("dd/MM/yyyy") + ")";
                            (thoigian5).Visible = true;
                            lblaysan.Text = dt.ToString("dd/MM/yyyy");
                            thongbao5.Text = "Đang sữ dụng";
                            PHIEUDATSAN ds = new PHIEUDATSAN();
                            ds.MaNV = "NV001";
                            // lbnhanvien.Text = fAdmin.tendangnhap;
                            ds.MaKH = textBox2.Text;
                            lbsanbong.Text = "S5_5";
                            ds.MaSB = "S5_5";
                            if (t3.TimeOfDay <= t1.TimeOfDay && t1.TimeOfDay <= t4.TimeOfDay)
                            {
                                lbgiothue.Text = "S5_8h_16h";
                                ds.Magio = "S5_8h_16h";
                                ds.Ngaydatsan = dateTimePicker1.Value;
                                ds.Ngaylap = dt;
                                db.PHIEUDATSANs.InsertOnSubmit(ds);
                                db.SubmitChanges();
                                Loaddulieu();
                            }
                            else if (t5.TimeOfDay <= t1.TimeOfDay && t1.TimeOfDay <= t6.TimeOfDay)
                            {
                                lbgiothue.Text = "S5_17h_21h";
                                ds.Magio = "S5_17h_21h";
                                ds.Ngaydatsan = dateTimePicker1.Value;
                                ds.Ngaylap = dt;
                                db.PHIEUDATSANs.InsertOnSubmit(ds);
                                db.SubmitChanges();
                                Loaddulieu();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ngày của bạn không được lớn hơn ngày hiện tại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }
                }
                else
                {
                    textBox2.Select();
                    MessageBox.Show("Thông tin bị để trống rồi", "Chú ý", MessageBoxButtons.OK);
                }

            }
        }

        private void btnsan6_Click(object sender, EventArgs e)
        {

            {
                if (textBox2.Text != "")
                {
                    {
                        DateTime dt = DateTime.Now;
                        if (dateTimePicker1.Value <= dt)
                        {
                            timer6.Start();
                            btnsan6.Enabled = false;

                            thoigian6.Text = dt.ToString("HH:mm") + " " + "(" + dt.ToString("dd/MM/yyyy") + ")";
                            (thoigian6).Visible = true;
                            lblaysan.Text = dt.ToString("dd/MM/yyyy");
                            thongbao6.Text = "Đang sữ dụng";
                            PHIEUDATSAN ds = new PHIEUDATSAN();
                            ds.MaNV = "NV001";
                            // lbnhanvien.Text = fAdmin.tendangnhap;
                            ds.MaKH = textBox2.Text;
                            lbsanbong.Text = "S5_6";
                            ds.MaSB = "S5_6";
                            if (t3.TimeOfDay <= t1.TimeOfDay && t1.TimeOfDay <= t4.TimeOfDay)
                            {
                                lbgiothue.Text = "S5_8h_16h";
                                ds.Magio = "S5_8h_16h";
                                ds.Ngaydatsan = dateTimePicker1.Value;
                                ds.Ngaylap = dt;
                                db.PHIEUDATSANs.InsertOnSubmit(ds);
                                db.SubmitChanges();
                                Loaddulieu();
                            }
                            else if (t5.TimeOfDay <= t1.TimeOfDay && t1.TimeOfDay <= t6.TimeOfDay)
                            {
                                lbgiothue.Text = "S5_17h_21h";
                                ds.Magio = "S5_17h_21h";
                                ds.Ngaydatsan = dateTimePicker1.Value;
                                ds.Ngaylap = dt;
                                db.PHIEUDATSANs.InsertOnSubmit(ds);
                                db.SubmitChanges();
                                Loaddulieu();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ngày của bạn không được lớn hơn ngày hiện tại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }
                }
                else
                {
                    textBox2.Select();
                    MessageBox.Show("Thông tin bị để trống rồi", "Chú ý", MessageBoxButtons.OK);
                }

            }
        }

        private void btnsan7_Click(object sender, EventArgs e)
        {

            {
                if (textBox2.Text != "")
                {
                    {
                        DateTime dt = DateTime.Now;
                        if (dateTimePicker1.Value <= dt)
                        {
                            timer7.Start();
                            btnsan7.Enabled = false;

                            thoigian7.Text = dt.ToString("HH:mm") + " " + "(" + dt.ToString("dd/MM/yyyy") + ")";
                            (thoigian7).Visible = true;
                            lblaysan.Text = dt.ToString("dd/MM/yyyy");
                            thongbao7.Text = "Đang sữ dụng";
                            PHIEUDATSAN ds = new PHIEUDATSAN();
                            ds.MaNV = "NV001";
                            // lbnhanvien.Text = fAdmin.tendangnhap;
                            ds.MaKH = textBox2.Text;
                            lbsanbong.Text = "S7_7";
                            ds.MaSB = "S7_7";
                            if (t3.TimeOfDay <= t1.TimeOfDay && t1.TimeOfDay <= t4.TimeOfDay)
                            {
                                lbgiothue.Text = "S7_8h_16h";
                                ds.Magio = "S7_8h_16h";
                                ds.Ngaydatsan = dateTimePicker1.Value;
                                ds.Ngaylap = dt;
                                db.PHIEUDATSANs.InsertOnSubmit(ds);
                                db.SubmitChanges();
                                Loaddulieu();
                            }
                            else if (t5.TimeOfDay <= t1.TimeOfDay && t1.TimeOfDay <= t6.TimeOfDay)
                            {
                                lbgiothue.Text = "S7_17h_21h";
                                ds.Magio = "S7_17h_21h";
                                ds.Ngaydatsan = dateTimePicker1.Value;
                                ds.Ngaylap = dt;
                                db.PHIEUDATSANs.InsertOnSubmit(ds);
                                db.SubmitChanges();
                                Loaddulieu();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ngày của bạn không được lớn hơn ngày hiện tại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }
                }
                else
                {
                    textBox2.Select();
                    MessageBox.Show("Thông tin bị để trống rồi", "Chú ý", MessageBoxButtons.OK);
                }

            }
        }

        private void btnsan8_Click(object sender, EventArgs e)
        {
            {
                if (textBox2.Text != "")
                {
                    {
                        DateTime dt = DateTime.Now;
                        if (dateTimePicker1.Value <= dt)
                        {
                            timer8.Start();
                            btnsan8.Enabled = false;

                            thoigian8.Text = dt.ToString("HH:mm") + " " + "(" + dt.ToString("dd/MM/yyyy") + ")";
                            (thoigian8).Visible = true;
                            lblaysan.Text = dt.ToString("dd/MM/yyyy");
                            thongbao8.Text = "Đang sữ dụng";
                            PHIEUDATSAN ds = new PHIEUDATSAN();
                            ds.MaNV = "NV001";
                            // lbnhanvien.Text = fAdmin.tendangnhap;
                            ds.MaKH = textBox2.Text;
                            lbsanbong.Text = "S7_8";
                            ds.MaSB = "S7_8";
                            if (t3.TimeOfDay <= t1.TimeOfDay && t1.TimeOfDay <= t4.TimeOfDay)
                            {
                                lbgiothue.Text = "S7_8h_16h";
                                ds.Magio = "S7_8h_16h";
                                ds.Ngaydatsan = dateTimePicker1.Value;
                                ds.Ngaylap = dt;
                                db.PHIEUDATSANs.InsertOnSubmit(ds);
                                db.SubmitChanges();
                                Loaddulieu();
                            }
                            else if (t5.TimeOfDay <= t1.TimeOfDay && t1.TimeOfDay <= t6.TimeOfDay)
                            {
                                lbgiothue.Text = "S7_17h_21h";
                                ds.Magio = "S7_17h_21h";
                                ds.Ngaydatsan = dateTimePicker1.Value;
                                ds.Ngaylap = dt;
                                db.PHIEUDATSANs.InsertOnSubmit(ds);
                                db.SubmitChanges();
                                Loaddulieu();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ngày của bạn không được lớn hơn ngày hiện tại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }
                }
                else
                {
                    textBox2.Select();
                    MessageBox.Show("Thông tin bị để trống rồi", "Chú ý", MessageBoxButtons.OK);
                }


            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PHIEUDATSAN nxb = dataGridView1.CurrentRow.DataBoundItem as PHIEUDATSAN;
            lbpds.Text = nxb.MaPDS.ToString();
            textBox2.Text = nxb.MaKH;
            lbnhanvien.Text = nxb.MaNV;
            lblaysan.Text = nxb.Ngaylap.ToString();
            lbnhanvien.Text = nxb.MaNV;
            lbgiothue.Text = nxb.Magio;
            lbsanbong.Text = nxb.MaSB;

        }

        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {// khi khong co thong tin se bi loi 

                HDTHANHTOAN tt = new HDTHANHTOAN();
                tt.MaPDS = int.Parse(lbpds.Text);
                tt.MaNV = lbnhanvien.Text;
                tt.MaKH = textBox2.Text;
                tt.Ngaylap = Convert.ToDateTime(lblaysan.Text);
                tt.thanhtien = 0;
                if (lbgiothue.Text == "S5_8h_16h")
                {
                    tt.thanhtien = 180000;
                }
                else if (lbgiothue.Text == "S5_17h_21h")
                {
                    tt.thanhtien = 200000;

                }
                else if (lbgiothue.Text == "S7_8h_16h")
                {
                    tt.thanhtien = 300000;

                }
                else
                {
                    tt.thanhtien = 400000;
                }
                db.HDTHANHTOANs.InsertOnSubmit(tt);
                db.SubmitChanges();
                MessageBox.Show("Thành tiền thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Loaddulieu();
                textBox2.Clear();
            }
            else
            {
                textBox2.Select();
                MessageBox.Show("Thông tin bị để trống rồi", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
