using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace QualityTasksApp
{
    public partial class TechHome : Form
    {
        public TechHome()
        {
            InitializeComponent();
            var userFirstName = ConfigurationManager.AppSettings["firstName"];
            var userLastName = ConfigurationManager.AppSettings["lastName"];
            var name = userFirstName + " " + userLastName;

            label1.Text = "Welcome " + name;
        }

        private void label1_Click(object sender, EventArgs e)
        {
    
        }
    }
}
