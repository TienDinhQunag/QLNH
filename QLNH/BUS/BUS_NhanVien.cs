using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using static DTO.DTO;

namespace BUS
{
    public class BUS_NhanVien
    {

        private DAL.DAL_NhanVien dalNhanVien;

        public BUS_NhanVien()
        {
            dalNhanVien = new DAL.DAL_NhanVien();
        }

        public List<NhanVienDTO> GetNhanVienList()
        {
            // Gọi phương thức từ DAL để lấy danh sách nhân viên
            return dalNhanVien.GetNhanVienList();
        }

        public NhanVienDTO GetNhanVienDetail(string maNhanVien)
        {
            return dalNhanVien.GetNhanVienDetail(maNhanVien);
        }
        public List<string> GetChucVuList()
        {
            return dalNhanVien.GetChucVuList();
        }
        public List<string> GetUnusedUsernames()
        {
            return dalNhanVien.GetUnusedUsernames();
        }
        public void AddNhanVien(string tenNhanVien, string chucVu, string tenDangNhap, string trangThai)
        {
            dalNhanVien.AddNhanVien(tenNhanVien, chucVu, tenDangNhap, trangThai);
        }

        public void UpdateNhanVien(NhanVienDTO nhanVien)
        {
            dalNhanVien.UpdateNhanVien(nhanVien);
        }

        public List<string> GetUnusedUsernamesExceptCurrent(string currentUsername)
        {
            List<string> unusedUsernames = dalNhanVien.GetUnusedUsernames();

            // Remove the current username from the list
            unusedUsernames.Remove(currentUsername);

            return unusedUsernames;
        }
        public bool CheckNhanVienExist(string maNhanVien)
        {
            // Gọi phương thức mới từ DAL để kiểm tra sự tồn tại
            return dalNhanVien.CheckNhanVienExistById(maNhanVien);
        }

        public void DeleteNhanVien(string maNhanVien)
        {
            dalNhanVien.DeleteNhanVien(maNhanVien);
        }



    }

}
