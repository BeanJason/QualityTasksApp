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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

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

        private void signOutBtn_Click(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings["firstName"] = "";
            ConfigurationManager.AppSettings["lastName"] = "";
            ConfigurationManager.AppSettings["userEmail"] = "";
            ConfigurationManager.AppSettings["role"] = "";

            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void TechHome_Load(object sender, EventArgs e)
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
                lineComboBox.DataSource = dtLines;
                lineComboBox.DisplayMember = "Line";
                lineComboBox.ValueMember = "Line_ID";
            }
            if (dtVersion.Rows.Count >= 1)
            {
                versionComboBox1.DataSource = dtVersion;
                versionComboBox1.DisplayMember = "Version";
                versionComboBox1.ValueMember = "Version_ID";
            }
        }

        private void lineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTankType3 = new DataTable();

            string lineSelected = lineComboBox.Text;
            var versionSelected = versionComboBox1.Text;
            string tankTypeQuery = $"SELECT Type, TANK_TYPES.TYPE_ID FROM LINE_TYPES INNER JOIN TANK_TYPES ON LINE_TYPES.Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = Lines.Line_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE Line = \'{lineSelected}\' AND Version = \'{versionSelected}\'";
            Debug.WriteLine($"\n\n{tankTypeQuery}\n\n");

            dbConnectObj.readDatathroughAdapter(tankTypeQuery, dtTankType3);

            typeComboBox.Text = "";
            typeComboBox.DataSource = dtTankType3;
            typeComboBox.DisplayMember = "Type";
            typeComboBox.ValueMember = "Type_ID";
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            var lineID = lineComboBox.SelectedValue;
            var tank = typeComboBox.SelectedValue;
            var versionID = versionComboBox1.SelectedValue;
            DateTime from = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            DateTime to = DateTime.Now.LastDayOfWeek();

            string selectedFrequency = "";
            string tasksQuery = "";

            if (startUpRadioBtn.Checked)
            {
                selectedFrequency = "Start Up";
            }else if (dailyRadioBtn.Checked)
            {
                selectedFrequency = "daily";
            }else if (weeklyBtn.Checked)
            {
                selectedFrequency = "Weekly";
            }

            if (selectedFrequency == "Daily" || selectedFrequency == "Weekly")
            {
                tasksQuery = $"SELECT tank_tasks_id, task FROM TANK_TASKS INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN LINE_TYPES ON TANK_TASKS.Line_Type_ID = LINE_TYPES.Line_Type_ID INNER JOIN TANK_TYPES ON LINE_TYPES.Line_Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = LINES.LIne_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE (TASK_SCHEDULE_KEY.schedule = \'{selectedFrequency}\' OR TASK_SCHEDULE_KEY.schedule = \'Daily/Weekly\') AND LINES.Line_ID = {lineID} AND TANK_TYPES.Type_ID = {tank} AND TANK_VERSION.Version_ID = {versionID} EXCEPT SELECT completed_tasks.tank_tasks_id, task FROM TANK_TASKS INNER JOIN COMPLETED_TASKS ON TANK_TASKS.Tank_Tasks_ID = COMPLETED_TASKS.Tank_Tasks_ID INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN LINE_TYPES ON TANK_TASKS.Line_Type_ID = LINE_TYPES.Line_Type_ID INNER JOIN TANK_TYPES ON LINE_TYPES.Line_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = LINES.LIne_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE COMPLETED_TASKS.Date > '{from}' AND COMPLETED_TASKS.Date < '{to}'";
            }
            else
            {
                tasksQuery = $"SELECT tank_tasks_id, task FROM TANK_TASKS INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN LINE_TYPES ON TANK_TASKS.Line_Type_ID = LINE_TYPES.Line_Type_ID INNER JOIN TANK_TYPES ON LINE_TYPES.Line_Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = LINES.LIne_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE TASK_SCHEDULE_KEY.schedule = \'{selectedFrequency}\' AND LINES.Line_ID = {lineID} AND TANK_TYPES.Type_ID = {tank} AND TANK_VERSION.Version_ID = {versionID} EXCEPT SELECT completed_tasks.tank_tasks_id, task FROM TANK_TASKS INNER JOIN COMPLETED_TASKS ON TANK_TASKS.Tank_Tasks_ID = COMPLETED_TASKS.Tank_Tasks_ID INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN LINE_TYPES ON TANK_TASKS.Line_Type_ID = LINE_TYPES.Line_Type_ID INNER JOIN TANK_TYPES ON LINE_TYPES.Line_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = LINES.LIne_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE COMPLETED_TASKS.Date > '{from}' AND COMPLETED_TASKS.Date < '{to}'";
            }

            Debug.WriteLine(tasksQuery);

            DBAccess dbConnectObj = new DBAccess();
            DataTable dtLines = new DataTable();
            
            dbConnectObj.readDatathroughAdapter(tasksQuery, dtLines);

            if (dtLines.Rows.Count >= 1)
            {
                incompleteTasks.DataSource = dtLines;
                incompleteTasks.DisplayMember = "task";
                incompleteTasks.ValueMember = "tank_tasks_ID";
            }
        }

        private void completeBtn_Click(object sender, EventArgs e)
        {
            var taskId = incompleteTasks.SelectedValue;
            //actually will nvr be null bc have to be logged in to be here stupid IDE
            var userId = int.Parse(ConfigurationManager.AppSettings["userID"]);
            DateTime currDate = DateTime.Now;
            string insertNewCompletedTask = $"INSERT INTO COMPLETED_TASKS (Tank_Tasks_ID, User_ID, Date) VALUES ({taskId}, {userId}, \'{currDate}\')";
            Debug.WriteLine($"\n\ncomp task q = {insertNewCompletedTask}\n\n");

            DBAccess dbConnectObj = new DBAccess();
            SqlCommand insertCommand = new SqlCommand(insertNewCompletedTask);

            //execute our insert query
            int row = dbConnectObj.executeQuery(insertCommand);

            //execute query returns a one on successful add 
            if (row == 1)
            {
                MessageBox.Show("Task Successfully completed");
            //refresh combobox
            var lineID = lineComboBox.SelectedValue;
            var tank = typeComboBox.SelectedValue;
            DateTime from = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            DateTime to = DateTime.Now.LastDayOfWeek();

            Debug.WriteLine($"\n\nfrom: {from} to: {to}\n\n");
            string selectedFrequency = "";
            string tasksQuery = "";

            if (startUpRadioBtn.Checked)
            {
                selectedFrequency = "Start Up";
            }
            else if (dailyRadioBtn.Checked)
            {
                selectedFrequency = "daily";
            }
            else if (weeklyBtn.Checked)
            {
                selectedFrequency = "Weekly";
            }

            if (selectedFrequency == "Daily" || selectedFrequency == "Weekly")
            {
                tasksQuery = $"SELECT tank_tasks_id, task FROM TANK_TASKS INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN LINE_TYPES ON TANK_TASKS.Line_Type_ID = LINE_TYPES.Line_Type_ID INNER JOIN TANK_TYPES ON LINE_TYPES.Line_Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_Type_ID = LINES.LIne_ID WHERE TASK_SCHEDULE_KEY.schedule = \'{selectedFrequency}\' OR TASK_SCHEDULE_KEY.Schecule = \'Daily/Weekly\' AND LINES.Line_ID = {lineID} AND TANK_TYPES.Type_ID = {tank} EXCEPT SELECT TANK_TASKS.tank_tasks_id, task FROM TANK_TASKS INNER JOIN COMPLETED_TASKS ON TANK_TASKS.Tank_Tasks_ID = COMPLETED_TASKS.Tank_Tasks_ID INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN LINE_TYPES ON TANK_TASKS.Line_Type_ID = LINE_TYPES.Line_Type_ID INNER JOIN TANK_TYPES ON LINE_TYPES.Line_Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_Type_ID = LINES.LIne_ID WHERE COMPLETED_TASKS.Date > \'{from}\' AND COMPLETED_TASKS.Date < \'{to}\'";
            }
            else
            {
                tasksQuery = $"SELECT tank_tasks_id, task FROM TANK_TASKS INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN LINE_TYPES ON TANK_TASKS.Line_Type_ID = LINE_TYPES.Line_Type_ID INNER JOIN TANK_TYPES ON LINE_TYPES.Line_Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_Type_ID = LINES.LIne_ID WHERE TASK_SCHEDULE_KEY.schedule = \'{selectedFrequency}\' AND LINES.Line_ID = {lineID} AND TANK_TYPES.Type_ID = {tank} EXCEPT SELECT TANK_TASKS.tank_tasks_id, task FROM TANK_TASKS INNER JOIN COMPLETED_TASKS ON TANK_TASKS.Tank_Tasks_ID = COMPLETED_TASKS.Tank_Tasks_ID INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN LINE_TYPES ON TANK_TASKS.Line_Type_ID = LINE_TYPES.Line_Type_ID INNER JOIN TANK_TYPES ON LINE_TYPES.Line_Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_Type_ID = LINES.LIne_ID WHERE COMPLETED_TASKS.Date > \'{from}\' AND COMPLETED_TASKS.Date < \'{to}\'";
                Debug.WriteLine($"\n\ntq = {tasksQuery}\n\n");
            }

            DataTable dtLines = new DataTable();

            dbConnectObj.readDatathroughAdapter(tasksQuery, dtLines);

            if (dtLines.Rows.Count >= 1)
            {
                incompleteTasks.DataSource = dtLines;
                incompleteTasks.DisplayMember = "task";
                incompleteTasks.ValueMember = "tank_tasks_ID";
                }
                else
                {
                    incompleteTasks.DataSource = dtLines;
                    incompleteTasks.DisplayMember = "task";
                    incompleteTasks.ValueMember = "tank_tasks_ID";
                    incompleteTasks.Text = "";
                }
            }

        }

        private void versionComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTankType3 = new DataTable();

            string lineSelected = lineComboBox.Text;
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
