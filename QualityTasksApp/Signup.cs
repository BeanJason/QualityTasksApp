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
            string firstNameVal = firstName.Text;
            string lastNameVal = lastName.Text;
            string Email = email.Text;
            string Password = password.Text;
            string Password2 = password2.Text;

            DBAccess dbConnectObj = new DBAccess();

            string sqlQuery = "";

            if (Password == Password2){
                var newEmail = ConfigurationManager.AppSettings["email"];

                //INSERT INTO USERS (FirstName, LastName, email, password, role) VALUES ('Randy','Burchette','randy.burchette@plasticomnium.com','Plastic2022', 'manager');
                //name int NOT NULL IDENTITY (1,1)
                sqlQuery = $"INSERT INTO USERS (FirstName, LastName, Email, Password, Role) VALUES (\'{firstNameVal}\',\'{lastNameVal}\',\'{Email}\',\'{Password}\', 'tech')";

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

//old way to connect to db
//var dbConnect = ConfigurationManager.AppSettings["dbConnectionString"];

//ConfigurationManager.AppSettings["email"] = Email;


//Debug.WriteLine("dbConnect = " + dbConnect);
//Console.Write("dbConnect = " + dbConnect);
//SqlConnection con = new SqlConnection(dbConnect);
//SqlConnection con = new SqlConnection();

//con.Open();
//SqlCommand sc = new SqlCommand(sqlQuery, con);
//sc.ExecuteNonQuery();
//con.Close();
