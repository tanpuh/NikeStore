using System;
using System.Windows.Forms;

namespace QuanLiNike
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Mở form đăng nhập
            frmLogin loginForm = new frmLogin();
            this.Hide(); // Ẩn form chính
            loginForm.ShowDialog(); // Hiển thị form đăng nhập
            this.Show(); // Hiển thị lại form chính sau khi đăng nhập
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // Mở form đăng ký
            frmsignup signUpForm = new frmsignup();
            this.Hide(); // Ẩn form chính
            signUpForm.ShowDialog(); // Hiển thị form đăng ký
            this.Show(); // Hiển thị lại form chính sau khi đăng ký
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
