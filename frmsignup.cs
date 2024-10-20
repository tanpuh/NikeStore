using Amazon.Runtime.Internal;
using MongoDB.Driver;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace QuanLiNike
{
    public partial class frmsignup : Form
    {
        IMongoCollection<signup> signupCollection;

        public frmsignup()
        {
            InitializeComponent();

            // Thiết lập kết nối với MongoDB
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase("Nike"); // Thay đổi tên cơ sở dữ liệu của bạn
            signupCollection = database.GetCollection<signup>("admin"); // Sử dụng bảng admin để lưu người dùng
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu mật khẩu và xác nhận mật khẩu không trùng khớp
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không trùng khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Ngừng quá trình đăng ký nếu không trùng
            }

            var newUser = new signup()
            {
                Username = txtUsername.Text, // Tên người dùng từ textbox
                Password = txtPassword.Text // Mật khẩu từ textbox
            };

            // Lưu người dùng vào MongoDB
            await signupCollection.InsertOneAsync(newUser);

            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Dọn dẹp các trường nhập sau khi đăng ký
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear(); // Dọn dẹp ô xác nhận mật khẩu
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
          private void frmsignup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void frmsignup_Load(object sender, EventArgs e)
        {

        }
    }
}
