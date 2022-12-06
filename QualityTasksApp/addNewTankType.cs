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

namespace QualityTasksApp
{
    public partial class addNewTankType : Form
    {
        public addNewTankType()
        {
            InitializeComponent();
        }

        private void addNewTankType_Load(object sender, EventArgs e)
        {
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtLines = new DataTable();
            string LinesQuery = $"SELECT * FROM LINES";
            dbConnectObj.readDatathroughAdapter(LinesQuery, dtLines);

            if (dtLines.Rows.Count >= 1)
            {
                linesComboBox.DataSource = dtLines;
                linesComboBox.DisplayMember = "Line";
                linesComboBox.ValueMember = "Line_ID";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string newTankType = newTankTypeInput.Text;
            var lineID = linesComboBox.SelectedValue;

            int typeID = 0;

            DBAccess dbConnectObj = new DBAccess();

            var checkForTankTypeQuery = $"SELECT * FROM TANK_TYPES WHERE Type = (\'{newTankType}\')";

            var insertNewTankQuery = $"INSERT INTO TANK_TYPES (Type) VALUES (\'{newTankType}\')";

            DataTable dtCheck = new DataTable();

            dbConnectObj.readDatathroughAdapter(checkForTankTypeQuery, dtCheck);

            if(dtCheck.Rows.Count == 0)
            {
                SqlCommand insertCommand = new SqlCommand(insertNewTankQuery);

                int row = dbConnectObj.executeQuery(insertCommand);

                if(row == 1)
                {
                    //Get the ID of the newly added tank
                    DataTable dtTanks = new DataTable();
                    string TankQuery = $"SELECT Type_ID FROM TANK_TYPES WHERE Type = \'{newTankType}\'";

                    dbConnectObj.readDatathroughAdapter(TankQuery, dtTanks);

                    //Store ID of newly added tank as well as selected line ID into LINE_TYPES table
                    Console.WriteLine("\n\nbefore tank check\n\n");
                    if(dtTanks.Rows.Count == 1)
                    {
                        Console.WriteLine("\n\nbefor typeID\n\n");
                        typeID = dtTanks.Rows[0].Field<int>("Type_ID");
                        Console.WriteLine("\n\ntypeID = \'{Type_ID}\'\n\n");

                        var lineTypesInsertQuery = $"INSERT INTO LINE_TYPES (Type_ID, Line_ID) VALUES ({typeID}, {lineID})";

                        insertCommand = new SqlCommand(lineTypesInsertQuery);

                        //execute our insert query
                        int row2 = dbConnectObj.executeQuery(insertCommand);

                        if(row2 == 1)
                        {
                            MessageBox.Show("Line type added");
                        }

                    }
                    newTankTypeInput.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Error occured while executing query");
            }
        }

        private void viewTankTypesBtn_Click(object sender, EventArgs e)
        {
            DBAccess dbConnectObj = new DBAccess();
            DataTable dtLineTypes = new DataTable();
            var lineID = linesComboBox.Text;

            Debug.WriteLine($"\n\nDisplayMember = {lineID}\n\n");

            string lineTypesQuery = $"SELECT Line, Type FROM LINE_TYPES INNER JOIN TANK_TYPES ON LINE_TYPES.Type_ID = TANK_TYPES.Type_ID INNER JOIN LINES ON LINE_TYPES.Line_ID = Lines.Line_ID WHERE Line = \'{lineID}\'";
            Console.WriteLine("\nlineTypesQuery\n");
            Debug.WriteLine($"\n{lineTypesQuery}\n");
            dbConnectObj.readDatathroughAdapter(lineTypesQuery, dtLineTypes);

            if(dtLineTypes.Rows.Count >= 1)
            {
                tankTypeDisplay.DataSource = dtLineTypes;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerHome ManagerHomeForm = new ManagerHome();
            ManagerHomeForm.Show();
            this.Hide();
        }
    }
}
