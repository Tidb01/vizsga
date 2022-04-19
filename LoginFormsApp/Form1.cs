using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace LoginFormsApp
{
    public partial class Form1 : Form
    {

        string userpassword = "";
        string useremail = "";


        public Form1()
        {
            InitializeComponent();

        }
        SqlConnection sqlconnection = new SqlConnection(@"Data Source=ezaz.database.windows.net;Initial Catalog=EZAZ;User ID=Zsombor;Password=Zsozso0620;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        private void btnLogin_Click(object sender, EventArgs e)
        {
            sqlconnection.Open();
            string query = "Select Email from AspNetUsers";
            SqlCommand sqlcommand = new SqlCommand(query, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            string output = ""; int counter = 0;
            while (sqldatareader.Read())

            { output += sqldatareader.GetValue(counter); counter++; };

            sqldatareader.Close();
            string passwordquery = "Select PasswordHash from AspNetUsers";
            SqlCommand passwordsqlcommand = new SqlCommand(passwordquery, sqlconnection);
            SqlDataReader sqlpasswordreader = passwordsqlcommand.ExecuteReader();

            string passwordoutput = ""; int passwordcounter = 0;
            while (sqlpasswordreader.Read())
            { passwordoutput += sqlpasswordreader.GetValue(passwordcounter); passwordcounter++; };



            if (useremail.Contains(output) && userpassword.Contains(passwordoutput))
            {
                
                Process.Start(@"C:\Users\patri\Desktop\Eddigi\Akasztofa\bin\Debug\Akasztofa.exe");
            }
            sqlconnection.Close();








           
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            useremail = sender.ToString();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            userpassword = sender.ToString();
        }


         private void btnExit_Click_1(object sender, EventArgs e)
         {
          this.Close();
          }
    }
}
