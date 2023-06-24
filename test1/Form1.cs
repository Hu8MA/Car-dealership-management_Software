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
namespace test1
{
    public partial class Form1 : Form
    {
        public Form1()
        { 
            InitializeComponent();
           
        }
       
         SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\code\App_database\test1\test1\Data1.mdf;Integrated Security=True");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
             

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Add(2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Close();
            cn.Open();
            MessageBox.Show("the DB is open ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Close();
            MessageBox.Show("the DB is close ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //  string A = comboBox1.Text;
            //string B = comboBox2.Text;
            SqlCommand cmd = new SqlCommand("insert into T12 VALUES ("+textBox1.Text+",'"+ comboBox1.Text + "','"+textBox3.Text+"',"+textBox4.Text+",'"+ comboBox2.Text + "','"+textBox6.Text+"',"+textBox2.Text+")", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("The event is done");
        }

        private void SELECT_Click(object sender, EventArgs e)
        {
           
            SqlDataAdapter da = new SqlDataAdapter("select * from T12 ", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select count(*) from T12", cn);
            textBox5.Text = cmd.ExecuteScalar().ToString();
            

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select sum(number_of_car) from T12", cn);
           textBox12.Text = cmd.ExecuteScalar().ToString();
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da2 = new SqlDataAdapter("select "+comboBox3.Text+ ", "+comboBox4.Text+" from T12 ", cn);

            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            dataGridView2.DataSource= dt2;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from T12 where Id=" + textBox7.Text + "", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("the event is done");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update T12 set "+comboBox5.Text+" = "+textBox8.Text+" where Id = "+textBox9.Text+"", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("the event is done");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update T12 set " + comboBox6.Text + " = '" + textBox11.Text + "' where Id = " + textBox10.Text + "", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("the event is done");

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string f;
            SqlCommand cmd = new SqlCommand("select name_car from T12 where licensecar ="+textBox13.Text+" ", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                     textBox14.Text = reader[i].ToString();
                }
            }
            
           

           /* if (reader.HasRows)
            {
                MessageBox.Show(textBox14.Text, "is found & the name car is =");
            }
            else
            {
                MessageBox.Show("is not found");
            }
           */
           reader.Close();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Alter table T14 add (dana  int) ", cn);

            MessageBox.Show("is  done");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select T12.Id,T12.name_car,T14.size from  T12,T14 where  T12.Id = T14.Id",cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource=dt;
        
        
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        /* private void button13_Click(object sender, EventArgs e)
         {
             SqlCommand cmd = new SqlCommand("select datediff(dd-mm,BD_car,current_date) from T12", cn);
             SqlDataReader reader2 = cmd.ExecuteReader();
             while (reader2.Read())
             {
                 for (int i = 0; i < reader2.FieldCount; i++)
                 {
                    listBox1.Text = reader2[i].ToString()+"  ";
                 }
             }
         }*/
    }
}
