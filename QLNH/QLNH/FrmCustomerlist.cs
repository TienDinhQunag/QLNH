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
    public partial class FrmCustomerlist : Form
    {
        private BUS_KhachHang busKhachHang = new BUS_KhachHang();

        public FrmCustomerlist()
        {
            InitializeComponent();
        }

        private void FrmCustomerlist_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            dgvKhachHang.DataSource = busKhachHang.GetAllCustomers();
            dgvKhachHang.Columns["MaKhachHang"].ReadOnly = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();

            // Kiểm tra xem chuỗi tìm kiếm có giá trị hay không
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                DataTable resultTable = busKhachHang.SearchCustomers(searchKeyword);

                // Hiển thị kết quả trong DataGridView hoặc bất kỳ điều kiện xử lý khác
                dgvKhachHang.DataSource = resultTable;
            }
            else
            {
                // Chuỗi tìm kiếm rỗng, có thể thông báo cho người dùng hoặc thực hiện hành động khác
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm.");
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            DataTable changesDataTable = ((DataTable)dgvKhachHang.DataSource).GetChanges();

            // Check if there are changes before attempting to update
            if (changesDataTable != null)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn lưu thay đổi không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    busKhachHang.UpdateCustomers(changesDataTable);
                    // Optionally, refresh the DataGridView or perform any other necessary actions
                    // LoadCustomers();
                }
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvKhachHang.Rows[e.RowIndex];
                string maKhachHang = selectedRow.Cells["MaKhachHang"].Value.ToString();

                // Chuyển đến Form FrmCustomerBills và truyền mã khách hàng
                FrmCustomerBills frmCustomerBills = new FrmCustomerBills(maKhachHang);
                frmCustomerBills.Show();
            }
        }
    }
}
