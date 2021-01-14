using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace myshool
{
    public partial class Student : Form
    {
        myschoolEntities3 db = new myschoolEntities3();
        public Student()
      {
            InitializeComponent();
       
       }

        private void Student_Load(object sender, EventArgs e)
        {
            myschoolEntities3 db = new myschoolEntities3();

            statecombo.DataSource = db.states.ToList();
            statecombo.DisplayMember = "stateName";
            statecombo.ValueMember = "Id";

        }
        private void statecombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int sid = statecombo.SelectedIndex + 1;

            var choosenstte = db.LocalGovernments.Where(s => s.stateID == sid);

            if (choosenstte != null)
            {
                LocalgvCombo.DataSource = choosenstte.ToList();
                LocalgvCombo.DisplayMember = "localGov";
                LocalgvCombo.ValueMember = "Id";
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {


        }
        private void button1_Click_1(object sender, EventArgs e)
        {
         try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "image file (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string file = ofd.FileName;
                    string na = Path.GetFileName("Filename :  " + file);
                    name.Text = "Filename :" + na;
                    pictureBox1.Image = new Bitmap(file);

                }

            }
            catch
            {

            }
        }

       
    }
}
