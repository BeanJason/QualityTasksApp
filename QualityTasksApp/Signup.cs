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
       

            string dbConnect = @"Data Source=SHURWP0009;Initial Catalog=USERS;Integrated Security=True";
            Debug.WriteLine("dbConnect = " + dbConnect);
            Console.Write("dbConnect = " + dbConnect);
            string sqlQuery = "";

            if (Password == Password2){
                Debug.WriteLine("insert into Users " + sqlQuery);
                sqlQuery = $"INSERT INTO USERS (firstName, lastName, eamil, password) VALUES (\"{firstNameVal}\",\"{lastNameVal}\",\"{Email}\",\"{Password}\", 1)";

                //dont want to connect bc security shiz
                //test commit

                //SqlConnection con = new SqlConnection(dbConnect);

                //con.Open();
                //SqlCommand sc = new SqlCommand(sqlQuery, con);
                //sc.ExecuteNonQuery();
                //con.Close();

            } else{
                Debug.WriteLine("Passwords do not match");
            }
            
            Debug.WriteLine("sqlQuery = " + sqlQuery);
        }

        private void Signup_BackBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
