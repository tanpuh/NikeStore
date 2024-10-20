using MongoDB.Driver; // Thêm thư viện MongoDB
using System;
using System.Configuration;
using System.Windows.Forms;

namespace QuanLiNike
{
    public partial class frmLogin : Form
    {
        // Khai báo IMongoCollection để truy cập vào bảng "admin"
        IMongoCollection<signup> signupCollection;

        public frmLogin()
        {
            InitializeComponent();

            // Thiết lập kết nối với MongoDB
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase("Nike"); // Thay thế bằng tên cơ sở dữ liệu của bạn
            signupCollection = database.GetCollection<signup>("admin"); // Bảng "admin" lưu trữ thông tin tài khoản
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Lấy thông tin tài khoản và mật khẩu từ textbox
            string username = txtName.Text;
            string password = txbPsw.Text;

            // Tạo bộ lọc để tìm kiếm người dùng trong MongoDB với tên đăng nhập và mật khẩu
            var filter = Builders<signup>.Filter.Eq(u => u.Username, username) &
                         Builders<signup>.Filter.Eq(u => u.Password, password);

            var user = await signupCollection.Find(filter).FirstOrDefaultAsync();

            // Kiểm tra thông tin đăng nhập
            if (user != null)
            {
                // Nếu thông tin chính xác, mở form ProductMng
                ProductMng productManager = new ProductMng();
                this.Hide();
                productManager.ShowDialog();
                this.Show();
            }
            else
            {
                // Nếu không tìm thấy tài khoản, hiển thị thông báo lỗi
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
