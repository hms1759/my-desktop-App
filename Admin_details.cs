using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myshool
{
    public partial class Admin_details : Form
    {
        myschoolEntities3 mysch = new myschoolEntities3();

        public Admin_details()
        {
            InitializeComponent();
        }

        private void Admin_details_Load(object sender, EventArgs e)
        {
           
            var adminsearch = from s in mysch.admins
                              select s;
            dataGridView1.DataSource = adminsearch.ToList();

        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student_details sds = new Student_details();
            sds.Show();

        }
        private void but3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("One or more Field not filled", ProductName, MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
        }
         private void button1_Click(object sender, EventArgs e)
        {

            if (txtName.Text == "" || txtPass.Text == "" || txtUser.Text == "")
            {
                MessageBox.Show("One or more Field not filled", ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtName.Text =
                    txtPass.Text =
                    txtUser.Text = "";

            }
            else if (txtPass.Text != conpss.Text)
            {
                MessageBox.Show("Password not match", ProductName, MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
                txtPass.Text =
                    conpss.Text = "";

            }

            else
            {
                var found = mysch.admins.FirstOrDefault (x => x.adminUser == txtUser.Text);
                if (found != null)
                {
                    MessageBox.Show("Username already existing", ProductName, MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);

                    txtName.Text =
                        txtPass.Text =
                        txtUser.Text = "";
                    return;

                }

                else
                {
                    var adbase = new admin()
                    {
                        adminName = txtName.Text,
                        adminPass = txtPass.Text,
                        adminUser = txtUser.Text
                    };

                    mysch.admins.Add(adbase);
                    mysch.SaveChanges();
                    MessageBox.Show("Successfully saved", ProductName, MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                    txtName.Text =
                txtPass.Text =
                txtUser.Text = "";


                }
                dataGridView1.DataSource = mysch.admins.ToList();


            }


        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        { }
        public void button2_Click(object sender, EventArgs e)
        {
            string search = txtsearch.Text;
            if (search != "")
            {

                button2.Text= "Delete";
                button1.Text = "Edit";
                panel1.Height = 250;
                 txtPass.UseSystemPasswordChar = false;
                conpss.Visible = false;
                label6.Visible = false;
                panel3.Visible = false;


                var found = mysch.admins.Where(f => f.adminUser == search);
                dataGridView1.DataSource = found.ToList();
                if (found != null)
                {

              
                      var st = (from s in mysch.admins where s.adminUser == txtsearch.Text select s).First();

                      txtName.Text = st.adminName;
                      txtUser.Text = st.adminUser;
                      txtPass.Text = st.adminPass;


                    MessageBox.Show("found ");
                    return;

                }
                 
                else if(search==null)
                {

                    MessageBox.Show("Not found ");
                    return;
                }
           }
           else
            {
                MessageBox.Show("Nothing in the search box");
            }
        }
        private void txtsearch_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var adbase = new admin()
            {
                adminName = txtName.Text,
                adminPass = txtPass.Text,
                adminUser = txtUser.Text
            };
            mysch.Entry(adbase).State = EntityState.Modified;
            mysch.SaveChanges();

            MessageBox.Show("Edited successfully");


        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            var std = new Student_details();
            std.Show();
            this.Hide();
        }
    }
} 
