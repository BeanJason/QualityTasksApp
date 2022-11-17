using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace QualityTasksApp
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void Signup_SubmitBtn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("test");
            string firstNameVal = firstName.Text;
            string lastNameVal = lastName.Text;
            string Email = email.Text;
            string Password = password.Text;
            string Password2 = password2.Text;

            //var dbConnect = ConfigurationManager.AppSettings["dbConnectionString"];

            //ConfigurationManager.AppSettings["email"] = Email;


            //Debug.WriteLine("dbConnect = " + dbConnect);
            //Console.Write("dbConnect = " + dbConnect);

            DBAccess dbConnectObj = new DBAccess();

            string sqlQuery = "";

            if (Password == Password2){
                var newEmail = ConfigurationManager.AppSettings["email"];
                
                sqlQuery = $"INSERT INTO USERS (firstName, lastName, email, password, role) VALUES (\'{firstNameVal}\',\'{lastNameVal}\',\'{Email}\',\'{Password}\', 1)";

                Debug.WriteLine("\n\n\n\n\n" + "insert into Users " + sqlQuery + "\n\n\n\n\n");
                Debug.WriteLine("email = " + newEmail);

                SqlCommand insertCommand = new SqlCommand(sqlQuery);

                //execute our insert query
                int row = dbConnectObj.executeQuery(insertCommand);

                //execute query returns a one on successful add 
                if(row == 1)
                {
                    MessageBox.Show("Account Created Successfully");
                }

                //SqlConnection con = new SqlConnection(dbConnect);
                //SqlConnection con = new SqlConnection();

                //con.Open();
                //SqlCommand sc = new SqlCommand(sqlQuery, con);
                //sc.ExecuteNonQuery();
                //con.Close();

                firstName.Text = "";
                lastName.Text = "";
                email.Text = "";
                password.Text = "";
                password2.Text = ""; 

            } else{
                Debug.WriteLine("Passwords do not match");
            }
            Debug.WriteLine("sqlQuery = " + sqlQuery);
        }

        private void Signup_BackBtn_Click(object sender, EventArgs e)
        {
            ManagerHome managerHomeForm = new ManagerHome();
            managerHomeForm.Show();
            this.Hide();
        }
    }
}
