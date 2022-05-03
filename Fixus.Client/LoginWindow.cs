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
        private readonly IFixusService fixusService = new ChannelFactory<IFixusService>("FixusService").CreateChannel();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text != "" && textBoxPassword.Text != "" && textBoxPassword.Text == textBoxPassword2.Text)
            {
                if (fixusService.AddUser(textBoxUsername.Text, textBoxPassword.Text) != null) label3.Text = "success";
                else label3.Text = "failed";
            }
            else label3.Text = "failed";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxUsernameLogin.Text != "" )
            {
                if (textBoxPasswordLogin.Text != "")
                {
                    var user = fixusService.GetUserByUsername(textBoxUsernameLogin.Text);
                    if (user != null && user.Password == textBoxPasswordLogin.Text)
                    {
                        label6.Text = "success";
                        MainWindow MainForm = new MainWindow(user);
                        MainForm.Show();
                        this.Hide();
                    }
                    else label6.Text = "failed";
                }
                else textBoxPasswordLogin.BackColor = Color.PaleVioletRed;
            }
            else
            {
                textBoxUsernameLogin.BackColor = Color.PaleVioletRed;
                label6.Text = "failed";
                if (textBoxPasswordLogin.Text == "") textBoxPasswordLogin.BackColor = Color.PaleVioletRed;
            }
        }

        private void textBoxUsernameLogin_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxUsernameLogin.BackColor = Color.White;
        }

        private void textBoxPasswordLogin_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxPasswordLogin.BackColor = Color.White;
        }
    }
}
