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
    public partial class AssignedTasks : Form
    {
        public AssignedTasks()
        {
            InitializeComponent();
        }

        private void AssignedTasks_Load(object sender, EventArgs e)
        {
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTasks = new DataTable();
            DataTable dtEmployees = new DataTable();

            string tasksQuery = "SELECT (FirstName + ' ' + LastName) AS Name, Line, Type, Task, Schedule, Date FROM ASSIGNED_TASKS INNER JOIN TANK_TASKS ON ASSIGNED_TASKS.Tank_Tasks_ID = TANK_TASKS.Tank_Tasks_ID INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN TANK_TYPE ON TANK_TASKS.Type_ID = TANK_TYPE.Type_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN LINE ON TANK_TASKS.Line_ID = LINE.LIne_ID INNER JOIN USERS ON ASSIGNED_TASKS.User_ID = USERS.User_ID";

            string UsersQuery = $"SELECT User_ID,(lastname + ', ' + firstName) AS NAME FROM USERS WHERE Role = 'tech'";

            dbConnectObj.readDatathroughAdapter(tasksQuery, dtTasks);

            dbConnectObj.readDatathroughAdapter(UsersQuery, dtEmployees);

            if (dtTasks.Rows.Count >= 1)
            {
                taskDisplay.DataSource = dtTasks;
            }
            else
            {
                //taskDisplay.DataSource = dtTasks;
                //MessageBox.Show("No data found");
            }
            if (dtEmployees.Rows.Count >= 1)
            {
                employeesComboBox.DataSource = dtEmployees;
                employeesComboBox.DisplayMember = "name";
                employeesComboBox.ValueMember = "User_ID";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTasks = new DataTable();

            string tasksQuery = "SELECT (FirstName + ' ' + LastName) AS Name, Line, Type, Task, Schedule, Date FROM ASSIGNED_TASKS INNER JOIN TANK_TASKS ON ASSIGNED_TASKS.Tank_Tasks_ID = TANK_TASKS.Tank_Tasks_ID INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN TANK_TYPE ON TANK_TASKS.Type_ID = TANK_TYPE.Type_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN LINE ON TANK_TASKS.Line_ID = LINE.LIne_ID INNER JOIN USERS ON ASSIGNED_TASKS.User_ID = USERS.User_ID";


            dbConnectObj.readDatathroughAdapter(tasksQuery, dtTasks);


            if (dtTasks.Rows.Count >= 1)
            {
                taskDisplay.DataSource = dtTasks;
            }
            else
            {
                //taskDisplay.DataSource = dtTasks;
                //MessageBox.Show("No data found");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}
