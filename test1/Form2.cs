using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace test1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();                                                                    
        }                                                          
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB);AttachDbFilename=D:\code\App_database\test1\test1\Data1.mdf;Integrated Security=True");//Change

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;
  
            if (validInput(user, pass) == 0)
            {
                string query = "SELECT count(*) FROM T13 WHERE username = @Username AND pass = @Password";
                 SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@Username", user);
                command.Parameters.AddWithValue("@Password", pass);

                try
                {
                    cn.Open();
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                          MessageBox.Show("Login successful. ");
                          Form1 form1 = new Form1();
                          form1.Show();
                          this.Close();
                    }
                    else
                    {
                         MessageBox.Show("Invalid username or password. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                     MessageBox.Show("An error occurred: " + ex.Message);
                }



            }
        }


      private int  validInput(string user , string pass)
        {
             string error = ".~(){}[]/'\',!-%^&-_+='";

            char[] userchar = user.ToCharArray();
            char[] passchar = pass.ToCharArray();
            char[] errors = error.ToCharArray();
            int e = 0;

            foreach (char character in userchar)
            {
                bool isError = errors.Contains(character);

                if (isError)
                {
                     e++;
                }
                
            }

            foreach (char character in passchar)
            {
                bool isError = errors.Contains(character);

                if (isError)
                {
                    e++;
                }

            }

            return e;
            



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
