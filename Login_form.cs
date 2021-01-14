using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myshool
{
    public partial class Login_form : Form
    {

        string name, password;
        public Login_form()
        {
            InitializeComponent();
        }

        private void Login_form_Load(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new FrmStudents();
                frm.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            name = txtName.Text;
            password = txtPass.Text;

            if (e.KeyChar == (char)Keys.Enter)
            {
                myschoolEntities3 db = new myschoolEntities3();
                var found = db.admins.FirstOrDefault(x => x.adminUser == name && x.adminPass == password);
                if (found != null)
                {
                    this.Hide();
                    Admin_details addm = new Admin_details();
                    addm.Show();




                }

                else
                {
                    MessageBox.Show("Wronge Username or password");
                    txtName.Text = "";
                    txtPass.Text = "";
                }

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

            name = txtName.Text;
            password = txtPass.Text;
            myschoolEntities3 db = new myschoolEntities3();
            var found = db.admins.FirstOrDefault(x => x.adminUser == name && x.adminPass == password);
            if (found != null)
            {
                this.Hide();
                Admin_details addm = new Admin_details();
                 addm.Show();


            }

            else
            {
                MessageBox.Show("Wronge Username or password");
                txtName.Text = "";
                txtPass.Text = "";
            }
        }
    }
}
