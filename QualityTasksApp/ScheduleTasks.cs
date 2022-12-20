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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.LinkLabel;
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
            DataTable dtLines2 = new DataTable();
            DataTable dtLines3 = new DataTable();
            DataTable dtVersion = new DataTable();


            string TankQuery = $"SELECT * FROM TANK_TYPES";
            string TasksQuery = $"SELECT * FROM TASKS";
            string ScheduleQuery = $"SELECT * FROM TASK_SCHEDULE_KEY";
            string LinesQuery = $"SELECT * FROM LINES";
            string VersionQuery = $"SELECT * FROM TANK_VERSION";

            dbConnectObj.readDatathroughAdapter(TankQuery, dtTanks);
            dbConnectObj.readDatathroughAdapter(TasksQuery, dtTasks);
            dbConnectObj.readDatathroughAdapter(ScheduleQuery, dtSchedule);
            dbConnectObj.readDatathroughAdapter(LinesQuery, dtLines);
            dbConnectObj.readDatathroughAdapter(LinesQuery, dtLines2);
            dbConnectObj.readDatathroughAdapter(LinesQuery, dtLines3);
            dbConnectObj.readDatathroughAdapter(VersionQuery, dtVersion);

            if (dtTanks.Rows.Count >= 1)
            {
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

                lineComboBox2.DataSource = dtLines2;
                lineComboBox2.DisplayMember = "Line";
                lineComboBox2.ValueMember = "Line_ID";

                comboBox1.DataSource = dtLines3;
                comboBox1.DisplayMember = "Line";
                comboBox1.ValueMember = "Line_ID";
            }

            if (dtVersion.Rows.Count >= 1)
            {
                versionComboBox1.DataSource = dtVersion;
                versionComboBox1.DisplayMember = "Version";
                versionComboBox1.ValueMember = "Version_ID";

                versionComboBox2.DataSource = dtVersion;
                versionComboBox2.DisplayMember = "Version";
                versionComboBox2.ValueMember = "Version_ID";

                versionComboBox3.DataSource = dtVersion;
                versionComboBox3.DisplayMember = "Version";
                versionComboBox3.ValueMember = "Version_ID";
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
            var lineID = lineComboBox2.SelectedValue;
            var versionID = versionComboBox2.SelectedValue;
            var versionID2 = versionComboBox3.SelectedValue;

            int typeID = 0;

            DBAccess dbConnectObj = new DBAccess();

            var checkForTankTypeQuery = $"SELECT * FROM TANK_TYPES WHERE Type = (\'{newTankType}\')";

            var sqlQuery = $"INSERT INTO TANK_TYPES (Type) VALUES (\'{newTankType}\')";

            DataTable dtCheck = new DataTable();

            dbConnectObj.readDatathroughAdapter(checkForTankTypeQuery, dtCheck);

            if(dtCheck.Rows.Count == 0)
            {
                //insert into Tank_TYPES
                SqlCommand insertCommand = new SqlCommand(sqlQuery);

                int row = dbConnectObj.executeQuery(insertCommand);

                if(row == 1)
                {
                    //MessageBox.Show("Tank Type added Successfully");

                    //Get the ID of the newly added tank
                    DataTable dtTanks = new DataTable();
                    string TankQuery = $"SELECT Type_ID FROM TANK_TYPES WHERE Type = \'{newTankType}\'";

                    dbConnectObj.readDatathroughAdapter(TankQuery, dtTanks);

                    //Store ID of newly added tank as well as selected line ID into LINE_TYPES table

                    typeID = dtTanks.Rows[0].Field<int>("Type_ID");

                    var lineTypesInsertQuery = $"INSERT INTO LINE_TYPES (Type_ID, Line_ID, Version_ID) VALUES ({typeID}, {lineID}, {versionID})";
                    Debug.WriteLine($"\n\nlineTypesInsertQuery = {lineTypesInsertQuery}\n\n");
                    insertCommand = new SqlCommand(lineTypesInsertQuery);

                    //execute our insert query
                    row = dbConnectObj.executeQuery(insertCommand);

                if(row == 1)
                    {
                        MessageBox.Show("Line type added");
                        //refresh tank type comboboxes
                        DataTable dtTankType = new DataTable();

                        string lineSelected = comboBox1.Text;
                        string tankTypeQuery = $"SELECT Type, TANK_TYPES.TYPE_ID FROM LINE_TYPES INNER JOIN TANK_TYPES ON LINE_TYPES.Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = Lines.Line_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE Line = \'{lineSelected}\' AND LINE_TYPES.Version_ID = {versionID}";
                        Debug.WriteLine($"\n\n{tankTypeQuery}\n\n");

                        dbConnectObj.readDatathroughAdapter(tankTypeQuery, dtTankType);

                        comboBox4.Text = "";
                        comboBox4.DataSource = dtTankType;
                        comboBox4.DisplayMember = "Type";
                        comboBox4.ValueMember = "Type_ID";

                        DataTable dtTankType2 = new DataTable();
                        
                        string lineSelected2 = lineComboBox.Text;
                        string tankTypeQuery2 = $"SELECT Type, TANK_TYPES.TYPE_ID FROM LINE_TYPES INNER JOIN TANK_TYPES ON LINE_TYPES.Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = Lines.Line_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE Line = \'{lineSelected2}\' AND LINE_TYPES.Version_ID = {versionID2}";
                        Debug.WriteLine($"\n\n{tankTypeQuery}\n\n");

                        dbConnectObj.readDatathroughAdapter(tankTypeQuery2, dtTankType2);

                        tankTypeComboBox.Text = "";
                        tankTypeComboBox.DataSource = dtTankType2;
                        tankTypeComboBox.DisplayMember = "Type";
                        tankTypeComboBox.ValueMember = "Type_ID";
                    }

                    newTankTypeInput.Text = "";

                }
                else
                {
                    MessageBox.Show("Error occured while executing query");
                }
            }
            else //In this case a tank type that already exist is being added to a new line
            {
                
                DataTable dtTanks = new DataTable();
                string TankQuery = $"SELECT Type_ID FROM TANK_TYPES WHERE Type = \'{newTankType}\'";

                dbConnectObj.readDatathroughAdapter(TankQuery, dtTanks);

                //Store ID of newly added tank as well as selected line ID into LINE_TYPES table

                typeID = dtTanks.Rows[0].Field<int>("Type_ID");

                //Check if tank type already exists for line
                string lineTypeExistsQuery = $"SELECT * FROM LINE_TYPES WHERE line_ID = {lineID} AND Type_ID = {typeID} AND Version_ID = {versionID}";
                DataTable dtTLineTypes = new DataTable();
                dbConnectObj.readDatathroughAdapter(lineTypeExistsQuery, dtTLineTypes);

                if(dtTLineTypes.Rows.Count == 0)
                {
                    string insertLineType = $"INSERT INTO LINE_TYPES (Type_ID, Line_ID, Version_ID) VALUES ({typeID},{lineID}, {versionID})";

                    Debug.WriteLine($"\n\ninsertLineTypeQuery = {insertLineType}\n\n");

                    SqlCommand insertCommand = new SqlCommand(insertLineType);

                    int row = dbConnectObj.executeQuery(insertCommand);

                    if(row == 1)
                    {
                        MessageBox.Show("Line type added");
                    }
                }
                else
                {
                    MessageBox.Show("Tank Type Already Exists For This Line.");
                }

            }
            
        }
        private void addTaskName_Click(object sender, EventArgs e)
        {
            string newTaskName = newTaskNameInput.Text;

            DBAccess dbConnectObj = new DBAccess();

            var sqlQuery = $"INSERT INTO TASKS (Task) VALUES (\'{newTaskName}\')";

            string checkForExistingQuery = $"SELECT * FROM TASKS WHERE Task = \'{newTaskName}\'";

            DataTable dtCheck = new DataTable();

            dbConnectObj.readDatathroughAdapter(checkForExistingQuery, dtCheck);

            if(dtCheck.Rows.Count == 0)
            {
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
            else
            {
                MessageBox.Show("Task already exists");
            }

        }
        private void addTaskBtn_Click(object sender, EventArgs e)
        {

            //get the ID of the selected values
            var tank = tankTypeComboBox.SelectedValue;
            var task = comboBox2.SelectedValue;
            var schedule = comboBox3.SelectedValue;
            var line = lineComboBox.SelectedValue;
            var version = versionComboBox2.SelectedValue;

            string findLineTypeID = $"SELECT Line_Type_ID FROM LINE_TYPES INNER JOIN LINES ON LINE_TYPES.Line_ID = LINES.LIne_ID INNER JOIN TANK_TYPES ON LINE_TYPES.Type_ID = TANK_TYPES.Type_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE LINES.Line_ID = \'{line}\' AND TANK_TYPES.Type_ID = \'{tank}\' AND TANK_VERSION.Version_ID = {version}";

            DBAccess dbConnectObj = new DBAccess();

            //get the LINE_TYPE_ID
            DataTable dtLineType = new DataTable();

            dbConnectObj.readDatathroughAdapter(findLineTypeID, dtLineType);

            if(dtLineType.Rows.Count > 0)
            {
                var line_type_ID = dtLineType.Rows[0].Field<int>("Line_Type_ID");

                string checkIfTankExistsQuery = $"SELECT * FROM TANK_TASKS WHERE Line_Type_ID = {line_type_ID} AND Schedule_ID = \'{schedule}\' AND Task_ID = \'{line}\'";

                string addTankQuery = $"INSERT INTO TANK_TASKS (Task_ID, Schedule_ID, Line_Type_ID) VALUES ({task},{schedule}, {line_type_ID})";

                Debug.WriteLine("\n\n\n Insert Task Query + " + addTankQuery + "\n\n\n");

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

        }
        private void viewBtn_Click(object sender, EventArgs e)
        {
            var tank = comboBox4.SelectedValue;
            var lineID = comboBox1.SelectedValue;
            var versionID = versionComboBox3.SelectedValue;
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
                tasksQuery = $"SELECT Version, Task, Schedule FROM TANK_TASKS INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN LINE_TYPES ON TANK_TASKS.Line_Type_ID = LINE_TYPES.Line_Type_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE (Schedule = \'{selectedFrequency}\' OR Schedule = \'Daily/Weekly\') AND Line_types.Type_ID = {tank} AND Line_Types.Line_ID = {lineID} AND Tank_Version.Version_ID = {versionID} ORDER BY Schedule";
            }
            else
            {
                tasksQuery = $"SELECT version, Task, Schedule FROM TANK_TASKS INNER JOIN TASKS ON TANK_TASKS.Task_ID = TASKS.Task_ID INNER JOIN LINE_TYPES ON TANK_TASKS.Line_Type_ID = LINE_TYPES.Line_Type_ID INNER JOIN TASK_SCHEDULE_KEY ON TANK_TASKS.Schedule_ID = TASK_SCHEDULE_KEY.Schedule_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE (Schedule = \'{selectedFrequency}\' OR Schedule = \'Daily/Weekly\') AND Line_types.Type_ID = {tank} AND Line_Types.Line_ID = {lineID} Tank_Version.Version_ID = {versionID} ORDER BY Schedule";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTankType3 = new DataTable();

            string lineSelected = lineComboBox.Text;
            var versionSelected = versionComboBox2.Text;
            string tankTypeQuery = $"SELECT Type, TANK_TYPES.TYPE_ID FROM LINE_TYPES INNER JOIN TANK_TYPES ON LINE_TYPES.Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = Lines.Line_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE Line = \'{lineSelected}\' AND Version = \'{versionSelected}\'";
            Debug.WriteLine($"\n\n{tankTypeQuery}\n\n");

            dbConnectObj.readDatathroughAdapter(tankTypeQuery, dtTankType3);

            tankTypeComboBox.Text = "";
            tankTypeComboBox.DataSource = dtTankType3;
                tankTypeComboBox.DisplayMember = "Type";
                tankTypeComboBox.ValueMember = "Type_ID";
        }

        private void viewTankTypesBtn_Click(object sender, EventArgs e)
        {
            var lineSelected = lineComboBox2.SelectedValue;
            var versionSelected = versionComboBox1.SelectedValue;

            string viewTankTypesQuery = $"SELECT Line, Version, Type AS Tank_Type FROM LINE_TYPES INNER JOIN TANK_TYPES ON LINE_TYPES.Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = Lines.Line_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE LINES.Line_ID = \'{lineSelected}\' AND TANK_VERSION.Version_ID = {versionSelected}";

            Debug.WriteLine($"\n\nviewTankQuery = {viewTankTypesQuery}\n\n");
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTypes = new DataTable();

            dbConnectObj.readDatathroughAdapter(viewTankTypesQuery, dtTypes);

            if (dtTypes.Rows.Count >= 1)
            {
                dataGridView1.DataSource = dtTypes;
            }
            else
            {
                dataGridView1.DataSource = dtTypes;
                MessageBox.Show("No data found");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTankType = new DataTable();

            string lineSelected = comboBox1.Text;
            var versionSelected = versionComboBox3.Text;
            string tankTypeQuery = $"SELECT Type, TANK_TYPES.TYPE_ID FROM LINE_TYPES INNER JOIN TANK_TYPES ON LINE_TYPES.Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = Lines.Line_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE Line = \'{lineSelected}\' AND Version = \'{versionSelected}\'";
            Debug.WriteLine($"\n\n{tankTypeQuery}\n\n");

            dbConnectObj.readDatathroughAdapter(tankTypeQuery, dtTankType);

            comboBox4.Text = ""; 
                comboBox4.DataSource = dtTankType;
                comboBox4.DisplayMember = "Type";
                comboBox4.ValueMember = "Type_ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string viewTasksQuery = $"SELECT Task FROM TASKS";

            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTasks = new DataTable();

            dbConnectObj.readDatathroughAdapter(viewTasksQuery, dtTasks);

            if (dtTasks.Rows.Count >= 1)
            {
                dataGridView1.DataSource = dtTasks;
            }
            else
            {
                dataGridView1.DataSource = dtTasks;
                MessageBox.Show("No data found");
            }
        }

        private void versionComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTankType3 = new DataTable();

            string lineSelected = lineComboBox.Text;
            var versionSelected = versionComboBox2.Text;
            string tankTypeQuery = $"SELECT Type, TANK_TYPES.TYPE_ID FROM LINE_TYPES INNER JOIN TANK_TYPES ON LINE_TYPES.Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = Lines.Line_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE Line = \'{lineSelected}\' AND Version = \'{versionSelected}\'";
            Debug.WriteLine($"\n\n{tankTypeQuery}\n\n");

            dbConnectObj.readDatathroughAdapter(tankTypeQuery, dtTankType3);

            tankTypeComboBox.Text = "";
            tankTypeComboBox.DataSource = dtTankType3;
            tankTypeComboBox.DisplayMember = "Type";
            tankTypeComboBox.ValueMember = "Type_ID";
        }

        private void versionComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTankType = new DataTable();

            string lineSelected = comboBox1.Text;
            var versionSelected = versionComboBox3.Text;
            string tankTypeQuery = $"SELECT Type, TANK_TYPES.TYPE_ID FROM LINE_TYPES INNER JOIN TANK_TYPES ON LINE_TYPES.Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = Lines.Line_ID INNER JOIN TANK_VERSION ON LINE_TYPES.Version_ID = TANK_VERSION.Version_ID WHERE Line = \'{lineSelected}\' AND Version = \'{versionSelected}\'";
            Debug.WriteLine($"\n\n{tankTypeQuery}\n\n");

            dbConnectObj.readDatathroughAdapter(tankTypeQuery, dtTankType);

            comboBox4.Text = "";
            comboBox4.DataSource = dtTankType;
            comboBox4.DisplayMember = "Type";
            comboBox4.ValueMember = "Type_ID";
        }
    }
}
