using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DTO.DTO;

namespace DAL
{
    public class DAL_NhanVien
    {
        private string connectionString = "Data Source=LAPTOPNAYCUATIE;Initial Catalog=QLNH;Integrated Security=True";

        public List<NhanVienDTO> GetNhanVienList()
        {
            List<NhanVienDTO> nhanVienList = new List<NhanVienDTO>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Viết truy vấn SQL để lấy danh sách nhân viên
                string query = "SELECT * FROM NhanVien";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NhanVienDTO nhanVien = new NhanVienDTO();
                        nhanVien.MaNhanVien = reader["MaNhanVien"].ToString();
                        nhanVien.TenNhanVien = reader["TenNhanVien"].ToString();
                        nhanVien.ChucVu = reader["ChucVu"].ToString();
                        nhanVien.TenDangNhap = reader["TenDangNhap"].ToString();
                        nhanVien.TrangThai = reader["TrangThai"].ToString();

                        nhanVienList.Add(nhanVien);
                    }
                }

                // Đóng kết nối
                connection.Close();
            }

            return nhanVienList;
        }

        public NhanVienDTO GetNhanVienDetail(string maNhanVien)
        {
            NhanVienDTO nhanVien = new NhanVienDTO();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nhanVien.MaNhanVien = reader["MaNhanVien"].ToString();
                        nhanVien.TenNhanVien = reader["TenNhanVien"].ToString();
                        nhanVien.ChucVu = reader["ChucVu"].ToString();
                        nhanVien.TenDangNhap = reader["TenDangNhap"].ToString();
                        nhanVien.TrangThai = reader["TrangThai"].ToString();
                    }
                }

                connection.Close();
            }

            return nhanVien;
        }
        public List<string> GetChucVuList()
        {
            List<string> chucVuList = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Write SQL query to get the list of job positions
                string query = "SELECT DISTINCT ChucVu FROM NhanVien";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string chucVu = reader["ChucVu"].ToString();
                        chucVuList.Add(chucVu);
                    }
                }

                // Close the connection
                connection.Close();
            }

            return chucVuList;
        }

        public List<string> GetUnusedUsernames()
        {
            List<string> unusedUsernames = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Write SQL query to get unused usernames
                string query = "SELECT DISTINCT TK.TenDangNhap " +
                               "FROM TaiKhoan TK LEFT JOIN NhanVien NV ON TK.TenDangNhap = NV.TenDangNhap " +
                               "WHERE NV.TenDangNhap IS NULL";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string username = reader["TenDangNhap"].ToString();
                        unusedUsernames.Add(username);
                    }
                }

                // Close the connection
                connection.Close();
            }

            return unusedUsernames;
        }

        public void AddNhanVien(string tenNhanVien, string chucVu, string tenDangNhap, string trangThai)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Generate a new employee ID (assuming it's in the format "NV01", "NV02", ...)
                string newEmployeeID = GenerateNewEmployeeID(connection);

                // Insert the new employee record into the NhanVien table
                string query = "INSERT INTO NhanVien (MaNhanVien, TenNhanVien, ChucVu, TenDangNhap, TrangThai) " +
                               "VALUES (@MaNhanVien, @TenNhanVien, @ChucVu, @TenDangNhap, @TrangThai)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNhanVien", newEmployeeID);
                command.Parameters.AddWithValue("@TenNhanVien", tenNhanVien);
                command.Parameters.AddWithValue("@ChucVu", chucVu);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                command.Parameters.AddWithValue("@TrangThai", trangThai);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        private string GenerateNewEmployeeID(SqlConnection connection)
        {
            // Retrieve the latest employee ID from the database
            string query = "SELECT TOP 1 MaNhanVien FROM NhanVien ORDER BY MaNhanVien DESC";
            SqlCommand command = new SqlCommand(query, connection);

            object result = command.ExecuteScalar();
            int latestID;

            if (result != null && int.TryParse(result.ToString().Substring(2), out latestID))
            {
                // Increment the latest ID and format it
                return "NV" + (latestID + 1).ToString("D2");
            }
            else
            {
                // If no records are found, start with NV01
                return "NV01";
            }
        }
        public void UpdateNhanVien(NhanVienDTO nhanVien)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE NhanVien SET TenNhanVien = @TenNhanVien, ChucVu = @ChucVu, TenDangNhap = @TenDangNhap, TrangThai = @TrangThai WHERE MaNhanVien = @MaNhanVien";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@MaNhanVien", nhanVien.MaNhanVien);
                command.Parameters.AddWithValue("@TenNhanVien", nhanVien.TenNhanVien);
                command.Parameters.AddWithValue("@ChucVu", nhanVien.ChucVu);
                command.Parameters.AddWithValue("@TenDangNhap", nhanVien.TenDangNhap);
                command.Parameters.AddWithValue("@TrangThai", nhanVien.TrangThai);

              

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public void DeleteNhanVien(string maNhanVien)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public bool CheckNhanVienExistById(string maNhanVien)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                int count = (int)command.ExecuteScalar();

                connection.Close();

                // Trả về true nếu có ít nhất một nhân viên có ID như vậy, ngược lại trả về false
                return count > 0;
            }
        }




    }

}
