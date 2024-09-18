using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace WindowsFormsApp1
{
    internal class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string Phai { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        public string SoDienThoai{ get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string HinhAnh { get; set; } // Đường dẫn đến hình ảnh

        public SinhVien(string maSV, string hoTen, string phai, DateTime ngaySinh, string lop, string soDienThoai, string email, string diaChi, string hinhAnh)
        {
            MaSV = maSV;
            HoTen = hoTen;
            Phai = phai;
            NgaySinh = ngaySinh;
            Lop = lop;
            SoDienThoai = soDienThoai;
            Email = email;
            DiaChi = diaChi;
            HinhAnh = hinhAnh;
        }

        public SinhVien()
        {
        }

        List<SinhVien> danhSachSinhVien = new List<SinhVien>();
    }
}
