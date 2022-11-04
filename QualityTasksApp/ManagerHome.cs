using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QualityTasksApp
{
    public partial class ManagerHome : Form
    {
        public ManagerHome()
        {
            InitializeComponent();
        }

        private void AddNewTechBtn_Click(object sender, EventArgs e)
        {
            Signup signUpForm = new Signup();
            signUpForm.Show();
            this.Hide();
        }

        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            //Add signOut logic
            Login LoginForm = new Login();
            LoginForm.Show();
            this.Hide();
        }
    }
}
