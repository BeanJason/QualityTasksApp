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
            DataTable dtLines = new DataTable();
            DataTable dtFrequency = new DataTable();
            DataTable dtTasks = new DataTable();

            string linesQuery = $"SELECT * FROM LINES";
            dbConnectObj.readDatathroughAdapter(linesQuery, dtLines);

            string frequencyQuery = $"SELECT * FROM TASK_SCHEDULE_KEY";
            dbConnectObj.readDatathroughAdapter(frequencyQuery, dtFrequency);

            string tasksQuery = $"SELECT * FROM TASKS";
            dbConnectObj.readDatathroughAdapter(tasksQuery, dtTasks);

            if(dtLines.Rows.Count >= 1)
            {
                lineComboBox2.DataSource = dtLines;
                lineComboBox2.DisplayMember = "Line";
                lineComboBox2.ValueMember = "Line_ID";

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
            if(dtTasks.Rows.Count >= 1)
            {
                tasksComboBox.DataSource = dtTasks;
                tasksComboBox.DisplayMember = "Task";
                tasksComboBox.ValueMember = "Task_ID";
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTankType = new DataTable();

            string lineSelected = lineComboBox.Text;
            string tankTypeQuery = $"SELECT Type, TANK_TYPES.TYPE_ID FROM LINE_TYPES INNER JOIN TANK_TYPES ON LINE_TYPES.Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = Lines.Line_ID WHERE Line = \'{lineSelected}\'";
            Debug.WriteLine($"\n\n{tankTypeQuery}\n\n");

            dbConnectObj.readDatathroughAdapter(tankTypeQuery, dtTankType);

            if (dtTankType.Rows.Count >= 1)
            {
                tankTypeComboBox.DataSource = dtTankType;
                tankTypeComboBox.DisplayMember = "Type";
                tankTypeComboBox.ValueMember = "Type_ID";
            }
        }
    }
}
