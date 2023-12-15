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
    public partial class FrmStaffDetail : Form
    {
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        private NhanVienDTO nhanVienDetail;
        public FrmStaffDetail(NhanVienDTO nhanVien)
        {
            InitializeComponent();
            nhanVienDetail = nhanVien;
        }


        private void FrmStaffDetail_Load(object sender, EventArgs e)
        {
            txtTenNhanVien.Text = nhanVienDetail.TenNhanVien;
            cbChucvu.Text = nhanVienDetail.ChucVu;
            cbTendangnhap.Text = nhanVienDetail.TenDangNhap;
            cbTrangthai.Text = nhanVienDetail.TrangThai;

            // Cập nhật label lblID
            lblID.Text = nhanVienDetail.MaNhanVien;


            // Hiển thị Danh sách những chức vụ hiện có
            List<string> chucVuList = busNhanVien.GetChucVuList();

            foreach (string chucVu in chucVuList)
            {
                cbChucvu.Items.Add(chucVu);
            }

            // Add vào combobox những tên đăng nhập chưa được sử dụng
            List<string> unusedUsernames = busNhanVien.GetUnusedUsernames();

            foreach (string username in unusedUsernames)
            {
                cbTendangnhap.Items.Add(username);
            }

            cbTrangthai.Items.Add("Còn làm");
            cbTrangthai.Items.Add("Nghỉ");
        }

// Inside FrmStaffDetail class
private void btnChange_Click(object sender, EventArgs e)
{
    string maNhanVien = lblID.Text;
    string tenNhanVien = txtTenNhanVien.Text;
    string chucVu = cbChucvu.Text.ToString();    
    string tenDangNhap = cbTendangnhap.Text.ToString();
    string trangThai = cbTrangthai.Text.ToString();

    NhanVienDTO updatedNhanVien = new NhanVienDTO
    {
        MaNhanVien = maNhanVien,
        TenNhanVien = tenNhanVien,
        ChucVu = chucVu,
        TenDangNhap = tenDangNhap,
        TrangThai = trangThai
    };

    // Display a confirmation dialog
    DialogResult result = MessageBox.Show("Bạn có muốn cập nhật thông tin nhân viên?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

    if (result == DialogResult.Yes)
    {
        // User clicked Yes, proceed with updating employee information
        busNhanVien.UpdateNhanVien(updatedNhanVien);
        MessageBox.Show("Thông tin nhân viên đã được cập nhật thành công.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    else
    {
        // User clicked No, do nothing or handle accordingly
    }
}

    }
}
