using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BUS
{
    public class BUS_KhachHang
    {
        private DAL.DAL_KhachHang dalKhachHang = new DAL.DAL_KhachHang();

        public DataTable GetAllCustomers()
        {
            return dalKhachHang.GetAllCustomers();
        }
        public DataTable SearchCustomers(string searchKeyword)
        {
            // Gọi hàm tìm kiếm trong DAL
            return dalKhachHang.SearchCustomers(searchKeyword);
        }

        public void UpdateCustomers(DataTable dataTable)
        {
            dalKhachHang.UpdateCustomers(dataTable);
        }
        public DataTable GetBillsForCustomer(string maKhachHang)
        {
            return dalKhachHang.GetBillsForCustomer(maKhachHang);
        }
        public DataTable GetBillDetails(string maHoaDon)
        {
            return dalKhachHang.GetBillDetails(maHoaDon);
        }
    }
}
