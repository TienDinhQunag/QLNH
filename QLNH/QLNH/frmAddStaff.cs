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
    public partial class frmAddStaff : Form
    {
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
   
        public frmAddStaff()
        {
            InitializeComponent();
          
        }

        private void frmAddStaff_Load(object sender, EventArgs e)
        {
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
            // Thêm 2 trạng thái còn làm và nghỉ cho combo box trạng thái
            cbTrangThai.Items.Add("Còn làm");
            cbTrangThai.Items.Add("Nghỉ");


            // Chỉ cho chọn không cho nhập trường giá trị mới
            cbChucvu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTendangnhap.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string tenNhanVien = txtNhanvien.Text;
            string chucVu = cbChucvu.SelectedItem?.ToString();
            string tenDangNhap = cbTendangnhap.SelectedItem?.ToString();
            string trangThai = cbTrangThai.SelectedItem?.ToString();


            // Hỏi có muốn thêm mới hay không
            DialogResult result = MessageBox.Show("Bạn có muốn thêm mới nhân viên?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // người dùng chọn yes thì thêm mới
                busNhanVien.AddNhanVien(tenNhanVien, chucVu, tenDangNhap, trangThai);
                MessageBox.Show("Nhân viên đã được thêm mới thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // người dùng chọn no thì không làm gì cả
            }
        }

    }
}
