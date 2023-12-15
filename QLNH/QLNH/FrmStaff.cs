    using BUS;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using static DTO.DTO;

namespace QLNH
{
    public partial class FrmStaff : Form
    {
        private BUS_NhanVien busNhanVien;
        private List<NhanVienDTO> nhanVienList;
        private int currentPage = 1;
        private int itemsPerPage = 5;
        public FrmStaff()
        {
            InitializeComponent();

            busNhanVien = new BUS_NhanVien();
        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            LoadData();
            AttachClickEventToLabels();
        }


        private void LoadData()
        {
            // Gọi phương thức từ BUS để lấy toàn bộ danh sách nhân viên
            nhanVienList = busNhanVien.GetNhanVienList();

            // Hiển thị dữ liệu cho trang hiện tại
            DisplayCurrentPage();
        }
        private void lblID_Click(object sender, EventArgs e)
        {
            Label lblIDClicked = sender as Label;
            if (lblIDClicked != null)
            {
                string maNhanVien = lblIDClicked.Text;

                // Gọi phương thức từ BUS để lấy thông tin chi tiết của nhân viên
                NhanVienDTO nhanVienDetail = busNhanVien.GetNhanVienDetail(maNhanVien);

                // Chuyển đến FrmStaffDetail để hiển thị thông tin chi tiết
                FrmStaffDetail frmStaffDetail = new FrmStaffDetail(nhanVienDetail);
                frmStaffDetail.Show();
            }
        }

        private void AttachClickEventToLabels()
        {
            for (int i = 1; i <= 5; i++)
            {
                // Tìm Label theo tên
                Label lblID = this.Controls.Find("lblID" + i, true).FirstOrDefault() as Label;

                // Gán sự kiện Click cho Label nếu tìm thấy
                if (lblID != null)
                {
                    lblID.Click += new EventHandler(lblID_Click);
                }
            }
        }

        private void DisplayCurrentPage()
        {
            // Xóa nội dung của tất cả các Label trước khi hiển thị dữ liệu mới
            ClearLabels();

            // Tính chỉ số bắt đầu và chỉ số kết thúc của danh sách nhân viên cho trang hiện tại
            int startIndex = (currentPage - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage - 1, nhanVienList.Count - 1);

            for (int i = startIndex; i <= endIndex; i++)
            {
                // Hiển thị thông tin mã nhân viên
                Label lblID = this.Controls.Find("lblID" + (i - startIndex + 1), true)[0] as Label;
                if (lblID != null)
                {
                    lblID.Text = nhanVienList[i].MaNhanVien;
                }

                // Hiển thị thông tin tên nhân viên
                Label lblName = this.Controls.Find("lblName" + (i - startIndex + 1), true)[0] as Label;
                if (lblName != null)
                {
                    lblName.Text = nhanVienList[i].TenNhanVien;
                }
            }
        }

        private void ClearLabels()
        {
            // Duyệt qua tất cả các Label và xóa nội dung
            for (int i = 1; i <= itemsPerPage; i++)
            {
                Label lblID = this.Controls.Find("lblID" + i, true)[0] as Label;
                Label lblName = this.Controls.Find("lblName" + i, true)[0] as Label;

                if (lblID != null)
                {
                    lblID.Text = "";
                }

                if (lblName != null)
                {
                    lblName.Text = "";
                }
            }
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < TotalPages())
            {
                currentPage++;
                DisplayCurrentPage();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCurrentPage();
            }
        }
        private int TotalPages()
        {
            // Tính tổng số trang dựa trên số lượng nhân viên và số lượng nhân viên mỗi trang
            return (int)Math.Ceiling((double)nhanVienList.Count / itemsPerPage);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Call the search method when Enter key is pressed
                PerformSearch();
            }
        }
        private void PerformSearch()
        {
            // Lấy từ khóa tìm kiếm từ TextBox
            string keyword = txtSearch.Text.Trim().ToLower();

            // Lọc danh sách nhân viên theo từ khóa tìm kiếm
            List<NhanVienDTO> searchResults = nhanVienList
                .Where(nv => nv.MaNhanVien.ToLower().Contains(keyword) ||
                             nv.TenNhanVien.ToLower().Contains(keyword) ||
                             nv.ChucVu.ToLower().Contains(keyword) ||
                             nv.TenDangNhap.ToLower().Contains(keyword) ||
                             nv.TrangThai.ToLower().Contains(keyword))
                .ToList();

            // Gán danh sách nhân viên tìm kiếm vào danh sách hiển thị và hiển thị trang đầu tiên
            nhanVienList = searchResults;
            currentPage = 1;
            DisplayCurrentPage();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            frmAddStaff frmAddStaff = new frmAddStaff();


            frmAddStaff.Show();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string maNhanVienToDelete = TxtIDNhanvien.Text.Trim();

            // Kiểm tra xem nhân viên có tồn tại hay không
            bool isNhanVienExist = busNhanVien.CheckNhanVienExist(maNhanVienToDelete);

            if (isNhanVienExist)
            {
                // Hiển thị hộp thoại xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Thực hiện xóa nhân viên
                    busNhanVien.DeleteNhanVien(maNhanVienToDelete);

                    // Cập nhật lại dữ liệu và hiển thị trang hiện tại
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên có ID: " + maNhanVienToDelete, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCustomerlist frmCustomerList = new FrmCustomerlist();
            frmCustomerList.Show();
        
        }
    }

}
