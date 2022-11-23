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

            string TankQuery = $"SELECT * FROM TANK_TYPE";
            string TasksQuery = $"SELECT * FROM TASKS";
            string ScheduleQuery = $"SELECT * FROM TASK_SCHEDULE_KEY";

            dbConnectObj.readDatathroughAdapter(TankQuery, dtTanks);
            dbConnectObj.readDatathroughAdapter(TasksQuery, dtTasks);
            dbConnectObj.readDatathroughAdapter(ScheduleQuery, dtSchedule);

            if (dtTanks.Rows.Count >= 1)
            {
                comboBox1.DataSource = dtTanks;
                comboBox1.DisplayMember = "Type";
                comboBox1.ValueMember = "Type_ID";

                comboBox4.DataSource = dtTanks;
                comboBox4.DisplayMember = "Type";
                comboBox4.ValueMember = "Type";
                //foreach (DataRow row in dtTanks.Rows)
                //{

                //    //comboBox1.Items.Add(row["Type"].ToString());
                //}
            }

            if (dtTasks.Rows.Count >= 1)
            {
                comboBox2.DataSource = dtTasks;
                comboBox2.DisplayMember = "Task";
                comboBox2.ValueMember = "Task_ID";
                //foreach (DataRow row in dtTasks.Rows)
                //{
                //    comboBox2.Items.Add(row["Task"].ToString());
                //}
            }


            if (dtSchedule.Rows.Count >= 1)
            {
                comboBox3.DataSource = dtSchedule;
                comboBox3.DisplayMember = "Schedule";
                comboBox3.ValueMember = "Schedule_ID";
                //foreach (DataRow row in dtSchedule.Rows)
                //{
                //    comboBox3.Items.Add(row["Schedule"].ToString());
                //}
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

        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            //ERROR: CAN ADD DATA THAT IS ALREADY THERE


            //get the ID of the selected values
            var tank = comboBox1.SelectedValue;
            var task = comboBox2.SelectedValue;
            var schedule = comboBox3.SelectedValue;

            string sqlQuery = $"INSERT INTO TANK_TASKS (Task_ID, Type_ID, Schedule_ID) VALUES ({task},{tank},{schedule})";

            Debug.WriteLine("\n\n\n" + sqlQuery + "\n\n\n");

            DBAccess dbConnectObj = new DBAccess();

            SqlCommand insertCommand = new SqlCommand(sqlQuery);

            //execute our insert query
            int row = dbConnectObj.executeQuery(insertCommand);

            //execute query returns a one on successful add 
            if (row == 1)
            {
                MessageBox.Show("New Task Added Successfully");
            }
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            var tank = comboBox4.SelectedValue;
            string selectedFrequency = "";

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

            string tasksQuery = $"SELECT Type, Task, Schedule FROM TANK_TASKS INNER JOIN TASKS ON  TANK_TASKS.Tank_Tasks_ID = TASKS.Task_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN TANK_TYPE ON TANK_TASKS.Type_ID = TANK_TASKS.Type_ID WHERE Schedule = \'{selectedFrequency}\' AND Type =\'{tank}\'";

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
                MessageBox.Show("No data found");
            }
        }
    }
}
