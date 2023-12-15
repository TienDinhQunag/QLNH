using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO
    {
        public class BanAnDTO
        {
            private string maBanAn;
            private string tenBanAn;
            private string trangThaiBanAn;

            public string MaBanAn { get => maBanAn; set => maBanAn = value; }
            public string TenBanAn { get => tenBanAn; set => tenBanAn = value; }
            public string TrangThaiBanAn { get => trangThaiBanAn; set => trangThaiBanAn = value; }
        }

        public class LoaiMonAnDTO
        {
            private string maLoai;
            private string tenLoai;

            public string MaLoai { get => maLoai; set => maLoai = value; }
            public string TenLoai { get => tenLoai; set => tenLoai = value; }
        }

        public class MonAnDTO
        {
            private string maMonAn;
            private string tenMonAn;
            private string maLoai;
            private float donGia;

            public string MaMonAn { get => maMonAn; set => maMonAn = value; }
            public string TenMonAn { get => tenMonAn; set => tenMonAn = value; }
            public string MaLoai { get => maLoai; set => maLoai = value; }
            public float DonGia { get => donGia; set => donGia = value; }
        }

        public class TaiKhoanDTO
        {
            private string tenDangNhap;
            private string tenHienThi;
            private string matKhau;
            private int loaiTaiKhoan;

            public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
            public string TenHienThi { get => tenHienThi; set => tenHienThi = value; }
            public string MatKhau { get => matKhau; set => matKhau = value; }
            public int LoaiTaiKhoan { get => loaiTaiKhoan; set => loaiTaiKhoan = value; }
        }

        public class NhanVienDTO
        {
            private string maNhanVien;
            private string tenNhanVien;
            private string chucVu;
            private string tenDangNhap;
            private string trangThai;

            public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
            public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
            public string ChucVu { get => chucVu; set => chucVu = value; }
            public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
            public string TrangThai { get => trangThai; set => trangThai = value; }
        }

        public class KhachHangDTO
        {
            private string maKhachHang;
            private string tenKhachHang;
            private string soDienThoai;
            private int diemTichLuy;

            public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
            public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
            public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
            public int DiemTichLuy { get => diemTichLuy; set => diemTichLuy = value; }
        }

        public class KhuyenMaiDTO
        {
            private string maKhuyenMai;
            private float giaTri;
            private string noiDung;
            private int soLuongMa;
            private decimal giaTriToiThieu;
            private decimal giamToiDa;
            private DateTime thoiGianBatDau;
            private DateTime thoiGianKetThuc;
            private byte trangThai;
            private DateTime thoiGianTao;
            private DateTime? thoiGianCapNhat;

            public string MaKhuyenMai { get => maKhuyenMai; set => maKhuyenMai = value; }
            public float GiaTri { get => giaTri; set => giaTri = value; }
            public string NoiDung { get => noiDung; set => noiDung = value; }
            public int SoLuongMa { get => soLuongMa; set => soLuongMa = value; }
            public decimal GiaTriToiThieu { get => giaTriToiThieu; set => giaTriToiThieu = value; }
            public decimal GiamToiDa { get => giamToiDa; set => giamToiDa = value; }
            public DateTime ThoiGianBatDau { get => thoiGianBatDau; set => thoiGianBatDau = value; }
            public DateTime ThoiGianKetThuc { get => thoiGianKetThuc; set => thoiGianKetThuc = value; }
            public byte TrangThai { get => trangThai; set => trangThai = value; }
            public DateTime ThoiGianTao { get => thoiGianTao; set => thoiGianTao = value; }
            public DateTime? ThoiGianCapNhat { get => thoiGianCapNhat; set => thoiGianCapNhat = value; }
        }

        public class HoaDonDTO
        {
            private string maHoaDon;
            private DateTime ngayLapHoaDon;
            private int trangThaiHoaDon;
            private float thanhTien;
            private string maBanAn;
            private string maNhanVien;
            private string maKhachHang;
            private string maKhuyenMai;

            public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
            public DateTime NgayLapHoaDon { get => ngayLapHoaDon; set => ngayLapHoaDon = value; }
            public int TrangThaiHoaDon { get => trangThaiHoaDon; set => trangThaiHoaDon = value; }
            public float ThanhTien { get => thanhTien; set => thanhTien = value; }
            public string MaBanAn { get => maBanAn; set => maBanAn = value; }
            public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
            public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
            public string MaKhuyenMai { get => maKhuyenMai; set => maKhuyenMai = value; }
        }

        public class ChiTietHoaDonDTO
        {
            private string maHoaDon;
            private string maMonAn;
            private int soLuong;

            public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
            public string MaMonAn { get => maMonAn; set => maMonAn = value; }
            public int SoLuong { get => soLuong; set => soLuong = value; }
        }

    }
}
