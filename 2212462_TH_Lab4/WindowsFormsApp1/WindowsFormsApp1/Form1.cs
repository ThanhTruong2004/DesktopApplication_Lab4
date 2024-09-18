using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<SinhVien> danhSachSinhVien = new List<SinhVien>();
        public Form1()
        {
            InitializeComponent();

            SinhVien sv1 = new SinhVien("SV22222", "Trương Công Thành", "Nam", new DateTime(2004, 3, 5), "CTK46A", "0987654321", "2212462@dlu.edu.vn", "Đà Lạt", "");
            danhSachSinhVien.Add(sv1);
            SinhVien sv2 = new SinhVien("SV22322", "Trương Tấn Dũng", "Nam", new DateTime(2003, 1, 1), "CTk46B", "0932323221", "2212222@dlu.edu.vn", "Đà Lạt", "");
            danhSachSinhVien.Add(sv2);

            foreach (SinhVien sv in danhSachSinhVien)
            {
                ListViewItem item = new ListViewItem(sv.MaSV);
                item.SubItems.Add(sv.HoTen);
                item.SubItems.Add(sv.Phai);
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.Lop);
                item.SubItems.Add(sv.SoDienThoai);
                item.SubItems.Add(sv.Email);
                item.SubItems.Add(sv.DiaChi);
                item.SubItems.Add(sv.HinhAnh);
                lsDSSV.Items.Add(item);
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lsDSSV.SelectedIndexChanged += lsDSSV_SelectedIndexChanged;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.MaSV = txtMSSV.Text;
            sv.HoTen = txtHoTen.Text;
            sv.Phai = rdNam.Checked ? "Nam" : "Nữ";
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.Lop = cboLop.SelectedItem.ToString();
            sv.SoDienThoai = mtbSoDT.Text;
            sv.Email = txtEmail.Text;
            sv.DiaChi = txtDiaChi.Text;
            // Thêm sinh viên vào danh sách
            danhSachSinhVien.Add(sv);

            // Cập nhật ListVie
            ListViewItem item = new ListViewItem(sv.MaSV);
            item.SubItems.Add(sv.HoTen);
            item.SubItems.Add(sv.Phai);
            item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
            item.SubItems.Add(sv.Lop);
            item.SubItems.Add(sv.SoDienThoai);
            item.SubItems.Add(sv.Email);
            item.SubItems.Add(sv.DiaChi);
            item.SubItems.Add(sv.HinhAnh);
            lsDSSV.Items.Add(item);
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)

            {
                string selectedFileName = openFileDialog.FileName;
                txtHinh.Text = selectedFileName;
                pictureBox1.Image = Image.FromFile(selectedFileName);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            this.txtMSSV.Text = "";
            this.txtHoTen.Text = "";
            this.txtEmail.Text = "";
            this.dtpNgaySinh.Value = DateTime.Now;
            this.txtDiaChi.Text = "";
            this.cboLop.Text = this.cboLop.Items[0].ToString();
            this.txtHinh.Text = "";
            this.pictureBox1.ImageLocation = "";
            this.mtbSoDT.Text = "";
            this.rdNam.Checked = true;
        }

        private void lsDSSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsDSSV.SelectedIndices.Count > 0)
            {
                // Lấy thông tin sinh viên được chọn
                int selectedIndex = lsDSSV.SelectedIndices[0];
                //Lấy thông tin sinh viên từ danh sách
                SinhVien sinhVien = danhSachSinhVien[selectedIndex];

                // Gán thông tin vào các ô nhập liệu
                txtMSSV.Text = sinhVien.MaSV;
                txtHoTen.Text = sinhVien.HoTen;
                txtEmail.Text = sinhVien.Email;
                txtDiaChi.Text=sinhVien.DiaChi;
                txtHinh.Text = sinhVien.HinhAnh;
                dtpNgaySinh.Value = sinhVien.NgaySinh;
                if (sinhVien.Phai=="Nam")
                {
                    rdNam.Checked = true;
                }
                else
                {
                    rdNu.Checked = true;
                }
                cboLop.SelectedItem = sinhVien.Lop;
                mtbSoDT.Text = sinhVien.SoDienThoai;
            }
   
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa các sinh viên đã chọn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // ... phần code xóa như trên
                foreach (ListViewItem item in lsDSSV.SelectedItems)
                {
                // Lấy chỉ số của mục
                int index = item.Index;

                // Xóa mục khỏi ListView
                lsDSSV.Items.RemoveAt(index);

                // Xóa sinh viên tương ứng khỏi danh sách dữ liệu (danhSachSinhVien)
                danhSachSinhVien.RemoveAt(index);
                 }
            }
        }
    }
}
