using Microsoft.Data.SqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QualityTasksApp
{
    public partial class ScheduleTasks : Form
    {
        public ScheduleTasks()
        {
            InitializeComponent();
        }

        private void ScheduleTasks_Load(object sender, EventArgs e)
        {
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTanks = new DataTable();
            DataTable dtTasks = new DataTable();
            DataTable dtSchedule = new DataTable();
            DataTable dtLines = new DataTable();

            string TankQuery = $"SELECT * FROM TANK_TYPE";
            string TasksQuery = $"SELECT * FROM TASKS";
            string ScheduleQuery = $"SELECT * FROM TASK_SCHEDULE_KEY";
            string LinesQuery = $"SELECT * FROM LINE";

            dbConnectObj.readDatathroughAdapter(TankQuery, dtTanks);
            dbConnectObj.readDatathroughAdapter(TasksQuery, dtTasks);
            dbConnectObj.readDatathroughAdapter(ScheduleQuery, dtSchedule);
            dbConnectObj.readDatathroughAdapter(LinesQuery, dtLines);

            if (dtTanks.Rows.Count >= 1)
            {
                comboBox1.DataSource = dtTanks;
                comboBox1.DisplayMember = "Type";
                comboBox1.ValueMember = "Type_ID";

                comboBox4.DataSource = dtTanks;
                comboBox4.DisplayMember = "Type";
                comboBox4.ValueMember = "Type";
            }

            if (dtTasks.Rows.Count >= 1)
            {
                comboBox2.DataSource = dtTasks;
                comboBox2.DisplayMember = "Task";
                comboBox2.ValueMember = "Task_ID";
            }


            if (dtSchedule.Rows.Count >= 1)
            {
                comboBox3.DataSource = dtSchedule;
                comboBox3.DisplayMember = "Schedule";
                comboBox3.ValueMember = "Schedule_ID";
            }

            if (dtLines.Rows.Count >= 1)
            {
                lineComboBox.DataSource = dtLines;
                lineComboBox.DisplayMember = "Line";
                lineComboBox.ValueMember = "Line_ID";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            ManagerHome managerHomeForm = new ManagerHome();
            managerHomeForm.Show();
            this.Hide();
        }

        private void newTankTypeBtn_Click(object sender, EventArgs e)
        {
            string newTankType = newTankTypeInput.Text;

            DBAccess dbConnectObj = new DBAccess();

            var sqlQuery = $"INSERT INTO TANK_TYPE (Type) VALUES (\'{newTankType}\')";

            SqlCommand insertCommand = new SqlCommand(sqlQuery);

            int row = dbConnectObj.executeQuery(insertCommand);

            if(row == 1)
            {
                MessageBox.Show("Tank Type added Successfully");
                newTankTypeInput.Text = "";

                DataTable dtTanks = new DataTable();
                string TankQuery = $"SELECT * FROM TANK_TYPE";
                dbConnectObj.readDatathroughAdapter(TankQuery, dtTanks);

                if (dtTanks.Rows.Count >= 1)
                {
                    comboBox1.DataSource = dtTanks;
                    comboBox1.DisplayMember = "Type";
                    comboBox1.ValueMember = "Type_ID";

                    comboBox4.DataSource = dtTanks;
                    comboBox4.DisplayMember = "Type";
                    comboBox4.ValueMember = "Type";
                }

            }
            else
            {
                MessageBox.Show("Error occured while executing query");
            }
            
        }
        private void addTaskName_Click(object sender, EventArgs e)
        {
            string newTaskName = newTaskNameInput.Text;

            DBAccess dbConnectObj = new DBAccess();

            var sqlQuery = $"INSERT INTO TASKS (Task) VALUES (\'{newTaskName}\')";

            SqlCommand insertCommand = new SqlCommand(sqlQuery);

            int row = dbConnectObj.executeQuery(insertCommand);

            if (row == 1)
            {
                MessageBox.Show("Tank Type added Successfully");
                newTankTypeInput.Text = "";

                DataTable dtTasks = new DataTable();
                string TankQuery = $"SELECT * FROM TASKS";
                dbConnectObj.readDatathroughAdapter(TankQuery, dtTasks);

                if (dtTasks.Rows.Count >= 1)
                {
                    comboBox2.DataSource = dtTasks;
                    comboBox2.DisplayMember = "Task";
                    comboBox2.ValueMember = "Task_ID";
                }

            }
            else
            {
                MessageBox.Show("Error occured while executing query");
            }
        }
        private void addTaskBtn_Click(object sender, EventArgs e)
        {

            //get the ID of the selected values
            var tank = comboBox1.SelectedValue;
            var task = comboBox2.SelectedValue;
            var schedule = comboBox3.SelectedValue;
            var line = lineComboBox.SelectedValue;

            string checkIfTankExistsQuery = $"SELECT * FROM TANK_TASKS WHERE TASK_ID = \'{task}\' AND TYPE_ID = \'{tank}\' AND Schedule_ID = \'{schedule}\' AND Line_ID = \'{line}\'";

            string addTankQuery = $"INSERT INTO TANK_TASKS (Task_ID, Type_ID, Schedule_ID, Line_ID) VALUES ({task},{tank},{schedule}, {line})";

            Debug.WriteLine("\n\n\n Insert Task Query + " + addTankQuery + "\n\n\n");

            DBAccess dbConnectObj = new DBAccess();

            DataTable dtCheck = new DataTable();

            dbConnectObj.readDatathroughAdapter(checkIfTankExistsQuery, dtCheck);
            if (dtCheck.Rows.Count == 0)
            {
                    //if ~ exists insert
                    DataTable dtTasks = new DataTable();
                SqlCommand insertCommand = new SqlCommand(addTankQuery);

                //execute our insert query
                int row = dbConnectObj.executeQuery(insertCommand);

                //execute query returns a one on successful add 
                if (row == 1)
                {
                    MessageBox.Show("New Task Added Successfully");
                }
            }else
            {
                MessageBox.Show("Task already exists");
            }
        }
        private void viewBtn_Click(object sender, EventArgs e)
        {
            var tank = comboBox4.SelectedValue;
            string selectedFrequency = "";
            string tasksQuery = "";

            if (startUpRadioBtn.Checked)
            {
                selectedFrequency = "Start Up";
            }
            else if (dailyRadioBtn.Checked)
            {
                selectedFrequency = "Daily";
            }
            else if (weeklyRadioBtn.Checked)
            {
                selectedFrequency = "Weekly";
            }

            if(selectedFrequency == "Daily" || selectedFrequency == "Weekly")
            {
                tasksQuery = $"SELECT Line, Type, Schedule, Task FROM TANK_TASKS INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN TANK_TYPE ON TANK_TASKS.Type_ID = TANK_TYPE.Type_ID INNER JOIN LINE ON TANK_TASKS.Line_ID = LINE.LIne_ID WHERE Type = '{tank}' AND Schedule = \'{selectedFrequency}\' OR Schedule = \'Daily/Weekly\'";
            }
            else
            {

            tasksQuery = $"SELECT Line, Type, Schedule, Task FROM TANK_TASKS INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN TANK_TYPE ON TANK_TASKS.Type_ID = TANK_TYPE.Type_ID INNER JOIN LINE ON TANK_TASKS.Line_ID = LINE.LIne_ID WHERE Schedule = \'{selectedFrequency}\' AND Type = \'{tank}\'";
            }

            Debug.WriteLine("\n\n\n" + tasksQuery + "\n\n\n");
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTasks = new DataTable();

            dbConnectObj.readDatathroughAdapter(tasksQuery, dtTasks);

            if(dtTasks.Rows.Count >= 1)
            {
                dataGridView1.DataSource = dtTasks;
            }
            else
            {
                dataGridView1.DataSource = dtTasks;
                MessageBox.Show("No data found");
            }
        }

    }
}
