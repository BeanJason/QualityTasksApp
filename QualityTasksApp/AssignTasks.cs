using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QualityTasksApp
{
    public partial class AssignTasks : Form
    {
        public AssignTasks()
        {
            InitializeComponent();
        }

        private void AssignTasks_Load(object sender, EventArgs e)
        {
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtEmployees = new DataTable();

            string UsersQuery = $"SELECT User_ID,(lastname + ', ' + firstName) AS NAME FROM USERS WHERE Role = 'tech'";
            dbConnectObj.readDatathroughAdapter(UsersQuery, dtEmployees);

            if (dtEmployees.Rows.Count >= 1)
            {
                employeesComboBox.DataSource = dtEmployees;
                employeesComboBox.DisplayMember = "name";
                employeesComboBox.ValueMember = "User_ID";
            }
        }

        private void EmployeeComboBoxFormat(object sender, ListControlConvertEventArgs e)
        {

        }
    }
}
