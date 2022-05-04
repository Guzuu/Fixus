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
        IEnumerable<Category> Categories;
        IEnumerable<Post> Posts;
        IEnumerable<Post> MyJobPosts;
        LoginWindow LoginWindow;

        public MainWindow(User user, LoginWindow loginWindow)
        {
            InitializeComponent();
            LoginWindow = loginWindow;
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

            Categories = fixusService.GetAllParentCategories(0);
            MyJobPosts = fixusService.GetPostsAssignedToUser(LoggedUser.UserId);

            listBoxCategory.DataSource = Categories;
            listBoxCategory.DisplayMember = "Name";
            listBoxPostCategory.DataSource = Categories;
            listBoxPostCategory.DisplayMember = "Name";
            listBoxEntries.DisplayMember = "Title";
            listBoxMyJobPosts.DataSource = MyJobPosts;
            listBoxMyJobPosts.DisplayMember = "Title";
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

        private void listBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Posts = fixusService.GetAllCategoryPosts(Categories.ToList()[listBoxCategory.SelectedIndex].CategoryId)
                .Where(p => p.AssignedUserId == 0)
                .ToList();
            listBoxEntries.DataSource = Posts;
        }

        private void listBoxEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            var post = Posts.ToList()[listBoxEntries.SelectedIndex];
            labelAddedByUser.Text = fixusService.GetUserById(post.AddedByUserId).Username;
            labelTitle.Text = post.Title;
            labelDesc.Text = post.Description;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginWindow.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fixusService.AddPost(
                textBoxTitle.Text, 
                richTextBoxDesc.Text, 
                Categories.ToList()[listBoxPostCategory.SelectedIndex].CategoryId, 
                LoggedUser.UserId
                );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fixusService.EditPost(
                labelTitle.Text,
                labelDesc.Text,
                Categories.ToList()[listBoxCategory.SelectedIndex].CategoryId,
                LoggedUser.UserId
                );
        }

        private void listBoxMyJobPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var post = MyJobPosts.ToList()[listBoxMyJobPosts.SelectedIndex];
            labelMyJobsPostAddedByUser.Text = fixusService.GetUserById(post.AddedByUserId).Username;
            labelMyJobsPostTitle.Text = post.Title;
            labelMyJobPostDesc.Text = post.Description;
            labelCategory.Text = fixusService.GetCategoryById(post.CategoryId).Name;
        }

        private void buttonMyJobCancel_Click(object sender, EventArgs e)
        {
            //fixusService.EditPost(
            //    labelMyJobsPostTitle.Text,
            //    labelMyJobPostDesc.Text,
            //    fixusService.GetCategoryByNameAndParentId(labelCategory.Text, 0).CategoryId,
            //    0
            //    );
        }
    }
}
