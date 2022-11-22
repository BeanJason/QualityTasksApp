using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            DataTable dtTasks = new DataTable();

            string TasksQuery = $"SELECT * FROM TASKS";

            dbConnectObj.readDatathroughAdapter(TasksQuery, dtTasks);
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            //https://stackoverflow.com/questions/7423911/how-to-populate-c-sharp-windows-forms-combobox

            if (dtTasks.Rows.Count == 1)
            {
                foreach (DataRow row in dtTasks.Rows)
                {
                    //comboBox1.Items.Add(new Item("test", 1));
                }
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
            }
            else
            {
                MessageBox.Show("Error occured while executing query");
            }
            
        }
    }
}
