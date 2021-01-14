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
     
    public partial class Student_details : Form
    {
        string search;
        myschoolEntities3 db = new myschoolEntities3();
        public Student_details()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
           var  Frm = new FrmStudents();
            Frm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            search = txtsearch.Text;
            var found = db.fulldetails.Where(f => f.userName == search);
            dataGridView1.DataSource = found.ToList();
        }

        private void Student_details_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.fulldetails.ToList();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            var log = new Login_form();
            log.Show();
            this.Hide();

        }
    }
}
