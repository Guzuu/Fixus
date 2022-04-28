using Fixus.Service.Contract;
using Fixus.Service.Contract.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainWindow : Form
    {
        UserViewModel LoggedUser;

        public MainWindow(User user)
        {
            InitializeComponent();
            LoggedUser = new UserViewModel(user.UserId, user.Username);
            label1.Text = "Welcome, " + LoggedUser.Username;
        }
    }
}
