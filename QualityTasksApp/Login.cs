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
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace QualityTasksApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //add login logic
            string email = Email.Text;
            string password = Password.Text;

            //var dbConnect = ConfigurationManager.AppSettings["dbConnectionString"];

            string loginQuery = $"SELECT * FROM USERS WHERE email = \'{email}\' AND password=\'{password}\'";

            Debug.WriteLine("\n\n loginQuery = " + loginQuery + "\n\n");

            DBAccess dbConnectObj = new DBAccess();
            DataTable dtUsers = new DataTable();

            if(email == "")
            {
                MessageBox.Show("Please enter email");
            }
            if(password == "")
            {
                MessageBox.Show("Please enter password");
            }
            if(email != "" && password != "")
            {
                dbConnectObj.readDatathroughAdapter(loginQuery, dtUsers);
                string firstName = "";
                string lastName = "";
                string userEmail = "";
                string role = "";

                Debug.WriteLine("\n\n\nuser = " + firstName + "\n\n\n");

                if (dtUsers.Rows.Count == 1)
                {
                    foreach (DataRow row in dtUsers.Rows)
                    {
                        firstName = row["firstName"].ToString();
                        lastName = row["lastName"].ToString();
                        userEmail = row["email"].ToString();
                        role = row["role"].ToString();
                    }

                   ConfigurationManager.AppSettings["firstName"] = firstName;
                    ConfigurationManager.AppSettings["lastName"] = lastName;
                    ConfigurationManager.AppSettings["userEmail"] = userEmail;
                    ConfigurationManager.AppSettings["role"] = role;

                    if (role == "manager")
                    {
                        ManagerHome managerHomeForm = new ManagerHome();
                        managerHomeForm.Show();
                        this.Hide();
                    }else if(role == "tech")
                    {
                        TechHome techHomeForm = new TechHome();
                        techHomeForm.Show();
                        this.Hide();
                    }
                    dbConnectObj.closeConn();
                    Email.Text = "";
                    Password.Text = "";
                }
                else
                {
                    MessageBox.Show("Email/Password do not match");
                }
            }
            

            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AssignedTasks assignedTasksForm = new AssignedTasks();
            assignedTasksForm.Show();
            this.Hide();
        }
    }
}
