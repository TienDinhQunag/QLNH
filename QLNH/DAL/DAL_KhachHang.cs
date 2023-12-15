using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_KhachHang
    {
        private string connectionString = "Data Source=LAPTOPNAYCUATIE;Initial Catalog=QLNH;Integrated Security=True";

        public DataTable GetAllCustomers()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM KhachHang"; // Adjust the table name accordingly
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
        public DataTable SearchCustomers(string searchKeyword)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Thay đổi truy vấn để tìm kiếm theo Mã, Tên, Điểm tích lũy hoặc Số điện thoại
                string query = "SELECT * FROM KhachHang WHERE MaKhachHang LIKE @searchKeyword OR TenKhachHang LIKE @searchKeyword OR DiemTichLuy LIKE @searchKeyword OR SoDienThoai LIKE @searchKeyword";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchKeyword", "%" + searchKeyword + "%");

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
        public void UpdateCustomers(DataTable dataTable)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM KhachHang", connection))
                    {
                        using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                        {
                            adapter.UpdateCommand = builder.GetUpdateCommand();
                            adapter.Update(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, display an error message, etc.)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public DataTable GetBillsForCustomer(string maKhachHang)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Thay đổi truy vấn để lấy danh sách hóa đơn cho khách hàng
                string query = "SELECT * FROM HoaDon WHERE MaKhachHang = @maKhachHang";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@maKhachHang", maKhachHang);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
        public DataTable GetBillDetails(string maHoaDon)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Thay đổi truy vấn để lấy chi tiết hóa đơn
                string query = "SELECT * FROM ChiTietHoaDon WHERE MaHoaDon = @maHoaDon";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@maHoaDon", maHoaDon);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

    }
}
