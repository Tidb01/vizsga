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
        public Form1()
        {
            InitializeComponent();

        }
        SqlConnection sqlconnection = new SqlConnection(@"Data Source=ezaz.database.windows.net;Initial Catalog=EZAZ;User ID=Zsombor;Password=Zsozso0620;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        private void btnLogin_Click(object sender, EventArgs e)
        {
            sqlconnection.Open();
            SqlCommand sqlcommand = new SqlCommand();

            Process.Start(@"C:\Users\patri\Desktop\Eddigi\Akasztofa\bin\Debug\Akasztofa.exe");

            //String usernam, user_password;

            //username = dbo.AspNetUsers;


            //SqlConnection sqlconnection = new SqlConnection(@"Data Source=ezaz.database.windows.net;Initial Catalog=EZAZ;User ID=Zsombor;Password=Zsozso0620;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //string query = "Select au.username, au.password from AspNetUsers au";
            //SqlDataAdapter sda = new SqlDataAdapter(query, sqlconnection);
            //DataTable datatable = new DataTable();
            //sda.Fill(datatable);
            //if(datatable.Rows.Count == 1)
            //{
              //  MainForm objMainForm = new MainForm();
                //this.Hide();
                //objMainForm.Show();

                //MessageBox.Show("Login button was clicked");


            //}
            //else
            //{
              //  MessageBox.Show("Nem sikerült bejelentkezni. Próbáld újra.");
            //}
        }  
           

       // private void btnExit_Click_1(object sender, EventArgs e)
        //{
          //  this.Close();
        //}
    }
}
