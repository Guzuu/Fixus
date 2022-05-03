using Fixus.Service.Contract;
using Fixus.Service.Contract.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainWindow : Form
    {
        private readonly IFixusService fixusService = new ChannelFactory<IFixusService>("FixusService").CreateChannel();
        UserViewModel LoggedUser;

        public MainWindow(User user)
        {
            InitializeComponent();
            LoggedUser = new UserViewModel(user.UserId, user.Username);
            label1.Text = "Welcome, " + LoggedUser.Username;
            var profile = fixusService.GetProfileByUserId(user.UserId);
            if (profile != null)
            {
                textBoxProfileName.Text = profile.Name;
                if (profile.Gender == "M") radioButtonMale.Checked = true;
                else if (profile.Gender == "F") radioButtonFemale.Checked = true;
                else if (profile.Gender != null) radioButtonOther.Checked = true;
                textBoxDescription.Text = profile.Description;
                if (profile.IsRepairman) checkBoxRepairman.Checked = true;
            }

            listBoxCategory.DataSource = fixusService.GetAllParentCategories(0);
            listBoxCategory.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var gender = "";
            if (radioButtonMale.Checked) gender = "M";
            if (radioButtonFemale.Checked) gender = "F";
            if (radioButtonOther.Checked) gender = "O";

            if (textBoxProfileName.Text != "") fixusService.EditProfile(
                 textBoxProfileName.Text,
                 gender,
                 textBoxDescription.Text,
                 checkBoxRepairman.Checked,
                 LoggedUser.UserId
                 );
            else textBoxProfileName.BackColor = Color.PaleVioletRed;
        }

        private void textBoxProfileName_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxProfileName.BackColor = Color.White;
        }
    }
}
