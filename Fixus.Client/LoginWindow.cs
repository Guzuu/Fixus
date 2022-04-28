using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fixus.Service;
using System.ServiceModel;
using Fixus.Service.Contract;

namespace WindowsFormsApp1
{
    public partial class LoginWindow : Form
    {
        private readonly IUserService _client2 = new ChannelFactory<IUserService>("UserService").CreateChannel();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text != "" && textBoxPassword.Text != "" && textBoxPassword.Text == textBoxPassword2.Text)
            {
                if (_client2.AddUser(textBoxUsername.Text, textBoxPassword.Text) != null) label3.Text = "success";
                else label3.Text = "failed";
            }
            else label3.Text = "failed";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxUsernameLogin.Text != "" && textBoxPasswordLogin.Text != "")
            {
                var user = _client2.GetUserByUsername(textBoxUsernameLogin.Text);
                if (user != null && user.Password == textBoxPasswordLogin.Text)
                {
                    label6.Text = "success";
                    MainWindow MainForm = new MainWindow(user);
                    MainForm.Show();
                    this.Hide();
                }
                else label6.Text = "failed";
            }
            else label6.Text = "failed";
        }
    }
}
