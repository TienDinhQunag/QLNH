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

namespace QLNH
{
    public partial class FrmCustomerBills : Form
    {
        private string maKhachHang;
        private BUS_KhachHang busKhachHang = new BUS_KhachHang();
        public FrmCustomerBills(string maKhachHang)
        {
            InitializeComponent();
            this.maKhachHang = maKhachHang;
        }

        private void FrmCustomerBills_Load(object sender, EventArgs e)
        {
            LoadBills();
        }
        private void LoadBills()
        {
            // Sử dụng mã khách hàng để tải danh sách hóa đơn từ BUS_KhachHang
            dgvBills.DataSource = busKhachHang.GetBillsForCustomer(maKhachHang);
        }

        private void dgvBills_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvBills.Rows[e.RowIndex];
                string maHoaDon = selectedRow.Cells["MaHoaDon"].Value.ToString();

                // Hiển thị chi tiết hóa đơn dựa vào mã hóa đơn
                LoadBillDetails(maHoaDon);
            }
        }
        private void LoadBillDetails(string maHoaDon)
        {
            // Gọi hàm BUS_KhachHang.GetBillDetails để lấy chi tiết hóa đơn
            DataTable billDetails = busKhachHang.GetBillDetails(maHoaDon);

            // Hiển thị chi tiết hóa đơn trong DataGridView chi tiết hóa đơn
            dgvBillDetails.DataSource = billDetails;

            // Ẩn DataGridView danh sách hóa đơn và hiển thị DataGridView chi tiết hóa đơn
            dgvBills.Visible = false;
            dgvBillDetails.Visible = true;

            // Hiển thị nút Quay lại
            btnBack.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            dgvBillDetails.Visible = false;
            dgvBills.Visible = true;

            // Ẩn nút Quay lại
            btnBack.Visible = false;
        }
    }
}
