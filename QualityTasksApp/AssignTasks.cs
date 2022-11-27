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
            DataTable dtLines = new DataTable();
            DataTable dtFrequency = new DataTable();

            string UsersQuery = $"SELECT User_ID,(lastname + ', ' + firstName) AS NAME FROM USERS WHERE Role = 'tech'";
            dbConnectObj.readDatathroughAdapter(UsersQuery, dtEmployees);

            string linesQuery = $"SELECT * FROM LINE";
            dbConnectObj.readDatathroughAdapter(linesQuery, dtLines);

            string frequencyQuery = $"SELECT * FROM TASK_SCHEDULE_KEY";
            dbConnectObj.readDatathroughAdapter(frequencyQuery, dtFrequency);

            if (dtEmployees.Rows.Count >= 1)
            {
                employeesComboBox.DataSource = dtEmployees;
                employeesComboBox.DisplayMember = "name";
                employeesComboBox.ValueMember = "User_ID";
            }
            if(dtLines.Rows.Count >= 1)
            {
                lineComboBox.DataSource = dtLines;
                lineComboBox.DisplayMember = "Line";
                lineComboBox.ValueMember = "Line_ID";
            }
            if(dtFrequency.Rows.Count >= 1)
            {
                frequencyComboBox.DataSource = dtFrequency;
                frequencyComboBox.DisplayMember = "Schedule";
                frequencyComboBox.ValueMember = "Schedule_ID";
            }
        }

        private void EmployeeComboBoxFormat(object sender, ListControlConvertEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerHome managerHomeForm = new ManagerHome();
            managerHomeForm.Show();
            this.Hide();
        }
    }
}
