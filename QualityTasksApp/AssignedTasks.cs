using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            DataTable dtLines = new DataTable();
            DataTable dtVersion = new DataTable();

            string LinesQuery = $"SELECT * FROM LINES";
            string VersionQuery = $"SELECT * FROM TANK_VERSION";

            dbConnectObj.readDatathroughAdapter(LinesQuery, dtLines);
            dbConnectObj.readDatathroughAdapter(VersionQuery, dtVersion);

            if (dtLines.Rows.Count >= 1)
            {
                employeesComboBox.DataSource = dtLines;
                employeesComboBox.DisplayMember = "Line";
                employeesComboBox.ValueMember = "Line_ID";
            }

            if (dtVersion.Rows.Count >= 1)
            {
                versionComboBox1.DataSource = dtVersion;
                versionComboBox1.DisplayMember = "Version";
                versionComboBox1.ValueMember = "Version_ID";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //view all btn clicked

            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTasks = new DataTable();
            var line = employeesComboBox.SelectedValue;
            var tankType = typeComboBox.SelectedValue;
            var versionID = versionComboBox1.SelectedValue;

            DateTime from = fromDate.Value;
            DateTime to = toDate.Value;
            Debug.WriteLine($"\n\nfrom: {from} to: {to}\n\n");

            string completedTasksQuery = $"SELECT Line, Version, Type, Task, Schedule, CONCAT(firstName, ' ', lastName) as Completed_BY, Date as Completed_ON FROM TANK_TASKS INNER JOIN COMPLETED_TASKS ON TANK_TASKS.Tank_Tasks_ID = COMPLETED_TASKS.Tank_Tasks_ID INNER JOIN USERS ON COMPLETED_TASKS.User_ID = USERS.User_ID INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN LINE_TYPES ON TANK_TASKS.Line_Type_ID = LINE_TYPES.Line_Type_ID INNER JOIN TANK_TYPES ON LINE_TYPES.Line_Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = LINES.LIne_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID  WHERE date > \'{from}\' AND Date < \'{to}\' AND LINES.Line_ID = {line} AND TANK_TYPES.Type_ID = {tankType} AND TANK_VERSION.Version_ID = {versionID}";

            string incompletedTasksQuery = $"SELECT line, Version, type, task, schedule FROM TANK_TASKS INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN LINE_TYPES ON TANK_TASKS.Line_Type_ID = LINE_TYPES.Line_Type_ID INNER JOIN TANK_TYPES ON LINE_TYPES.Line_Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = LINES.LIne_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE LINES.Line_ID = {line} AND TANK_TYPES.Type_ID = {tankType} AND TANK_VERSION.Version_ID = {versionID} EXCEPT SELECT line, Version, type, task, schedule FROM TANK_TASKS INNER JOIN COMPLETED_TASKS ON TANK_TASKS.Tank_Tasks_ID = COMPLETED_TASKS.Tank_Tasks_ID INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN LINE_TYPES ON TANK_TASKS.Line_Type_ID = LINE_TYPES.Line_Type_ID INNER JOIN TANK_TYPES ON LINE_TYPES.Line_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = LINES.LIne_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE COMPLETED_TASKS.Date > \'{from}\' AND COMPLETED_TASKS.Date < \'{to}\'";

            Debug.WriteLine($"\nincompletedQuery  {incompletedTasksQuery}\n");
            Debug.WriteLine($"\ncompletedQuery  {completedTasksQuery}\n");

            if (completeRadioBtn.Checked)
            {
                dbConnectObj.readDatathroughAdapter(completedTasksQuery, dtTasks);
            }else if (incompleteRadioBtn.Checked)
            {
                dbConnectObj.readDatathroughAdapter(incompletedTasksQuery, dtTasks);
            }

            if (dtTasks.Rows.Count >= 1)
            {
                taskDisplay.DataSource = dtTasks;
            }
            else
            {
                taskDisplay.DataSource = dtTasks;
                MessageBox.Show("No data found");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void employeesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTankType3 = new DataTable();

            string lineSelected = employeesComboBox.Text;
            var versionSelected = versionComboBox1.Text;
            string tankTypeQuery = $"SELECT Type, TANK_TYPES.TYPE_ID FROM LINE_TYPES INNER JOIN TANK_TYPES ON LINE_TYPES.Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = Lines.Line_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE Line = \'{lineSelected}\' AND Version = \'{versionSelected}\'";
            Debug.WriteLine($"\n\n{tankTypeQuery}\n\n");

            dbConnectObj.readDatathroughAdapter(tankTypeQuery, dtTankType3);

            typeComboBox.Text = "";
            typeComboBox.DataSource = dtTankType3;
            typeComboBox.DisplayMember = "Type";
            typeComboBox.ValueMember = "Type_ID";
        }

        private void versionComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTankType3 = new DataTable();

            string lineSelected = employeesComboBox.Text;
            var versionSelected = versionComboBox1.Text;
            string tankTypeQuery = $"SELECT Type, TANK_TYPES.TYPE_ID FROM LINE_TYPES INNER JOIN TANK_TYPES ON LINE_TYPES.Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = Lines.Line_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE Line = \'{lineSelected}\' AND Version = \'{versionSelected}\'";
            Debug.WriteLine($"\n\n{tankTypeQuery}\n\n");

            dbConnectObj.readDatathroughAdapter(tankTypeQuery, dtTankType3);

            typeComboBox.Text = "";
            typeComboBox.DataSource = dtTankType3;
            typeComboBox.DisplayMember = "Type";
            typeComboBox.ValueMember = "Type_ID";
        }
    }
}
