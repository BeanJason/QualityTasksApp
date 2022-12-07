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

            string LinesQuery = $"SELECT * FROM LINES";

            dbConnectObj.readDatathroughAdapter(LinesQuery, dtLines);

            if (dtLines.Rows.Count >= 1)
            {
                employeesComboBox.DataSource = dtLines;
                employeesComboBox.DisplayMember = "Line";
                employeesComboBox.ValueMember = "Line_ID";
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //view all btn clicked

            DBAccess dbConnectObj = new DBAccess();
            DataTable dtTasks = new DataTable();

            string tasksQuery = "";

            dbConnectObj.readDatathroughAdapter(tasksQuery, dtTasks);

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
            string tankTypeQuery = $"SELECT Type, TANK_TYPES.TYPE_ID FROM LINE_TYPES INNER JOIN TANK_TYPES ON LINE_TYPES.Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = Lines.Line_ID WHERE Line = \'{lineSelected}\'";
            Debug.WriteLine($"\n\n{tankTypeQuery}\n\n");

            dbConnectObj.readDatathroughAdapter(tankTypeQuery, dtTankType3);

            typeComboBox.Text = "";
            typeComboBox.DataSource = dtTankType3;
            typeComboBox.DisplayMember = "Type";
            typeComboBox.ValueMember = "Type_ID";
        }
    }
}
