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
    public partial class FrmStudents : Form
    { int jambsc1, jambsc2, jambsc3, jambsc4;
        myschoolEntities3 db = new myschoolEntities3();
        public FrmStudents()
        {
            InitializeComponent();
        }

        private void subjs()
        {
            combo3.DataSource = db.subjects.ToList();
            combo4.DataSource = db.subjects.ToList();
            combo5.DataSource = db.subjects.ToList();
            combo6.DataSource = db.subjects.ToList();
            combo7.DataSource = db.subjects.ToList();
            combo8.DataSource = db.subjects.ToList();

            combo3.DisplayMember =
           combo4.DisplayMember = combo5.DisplayMember =
           combo6.DisplayMember = combo7.DisplayMember = combo8.DisplayMember = "subjectName";




        }


        private void grade()
        {
            combograde1.DataSource = db.grades.ToList();
            combograde2.DataSource = db.grades.ToList();
            combograde3.DataSource = db.grades.ToList();
            combograde4.DataSource = db.grades.ToList();
            combograde5.DataSource = db.grades.ToList();
            combograde6.DataSource = db.grades.ToList();
            combograde7.DataSource = db.grades.ToList();
            combograde8.DataSource = db.grades.ToList();
            combograde11.DataSource = db.grades.ToList();
            combograde12.DataSource = db.grades.ToList();
            combograde13.DataSource = db.grades.ToList();
            combograde14.DataSource = db.grades.ToList();
            combograde15.DataSource = db.grades.ToList();
            combograde16.DataSource = db.grades.ToList();
            combograde17.DataSource = db.grades.ToList();
            combograde18.DataSource = db.grades.ToList();


            combograde1.DisplayMember = combograde2.DisplayMember = combograde3.DisplayMember = combograde4.DisplayMember
             = combograde5.DisplayMember = combograde6.DisplayMember = combograde7.DisplayMember = combograde8.DisplayMember
             = combograde11.DisplayMember = combograde12.DisplayMember = combograde13.DisplayMember = combograde14.DisplayMember
             = combograde15.DisplayMember = combograde16.DisplayMember = combograde17.DisplayMember = combograde18.DisplayMember = "grade1";


            combograde1.ValueMember = combograde2.ValueMember = combograde3.ValueMember = combograde4.ValueMember
            = combograde5.ValueMember = combograde6.ValueMember = combograde7.ValueMember = combograde8.ValueMember
            = combograde11.ValueMember = combograde12.ValueMember = combograde13.ValueMember = combograde14.ValueMember
            = combograde15.ValueMember = combograde16.ValueMember = combograde17.ValueMember = combograde18.ValueMember = "grade1";

        }

        private void combostate()
        {
            statecombo.DataSource = db.states.ToList();
            statecombo.DisplayMember = "stateName";
            statecombo.ValueMember = "Id";


        }
        //  private void exam()

        private void jambsuby()
        {

            jambsub1.DataSource = db.subjects.ToList();
            jambsub2.DataSource = db.subjects.ToList();
            jambsub3.DataSource = db.subjects.ToList();
            jambsub4.DataSource = db.subjects.ToList();

            jambsub1.DisplayMember = jambsub2.DisplayMember =
             jambsub3.DisplayMember = jambsub4.DisplayMember = "subjectName";

        }

        private void faculty()
        {
            combofaculty.DataSource = db.faculties.ToList();
            combofaculty.DisplayMember = "facultyName";
            combofaculty.ValueMember = "Id";
        }

        byte[] Convertimages(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }

        }
        public void FrmStudents_Load(object sender, EventArgs e)
        {
            faculty();
            jambsuby();
            combostate();

            subjs();

            grade();
            combositting.SelectedIndex = 0;
            comboexam.SelectedIndex = 0;


        }

        private void statecombo_SelectedIndexChanged(object sender, EventArgs e)
        { int sid = statecombo.SelectedIndex + 1;

            var choosenstte = db.LocalGovernments.Where(s => s.stateID == sid);

            if (choosenstte != null)
            {
                LocalgvCombo.DataSource = choosenstte.ToList();
                LocalgvCombo.DisplayMember = "localGov";
                LocalgvCombo.ValueMember = "Id";
            }

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void comboBox45_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboexam2.SelectedIndex = 0;

            if (combositting.SelectedIndex == 1)
            {
                combo13.DataSource = db.subjects.ToList();
                combo14.DataSource = db.subjects.ToList();
                combo15.DataSource = db.subjects.ToList();
                combo16.DataSource = db.subjects.ToList();
                combo17.DataSource = db.subjects.ToList();
                combo18.DataSource = db.subjects.ToList();


                combo13.DisplayMember = combo14.DisplayMember =
                     combo15.DisplayMember = combo16.DisplayMember =
                     combo17.DisplayMember = combo18.DisplayMember =
                     combo3.DisplayMember = combo4.DisplayMember =
                   combo5.DisplayMember = combo6.DisplayMember =
                   combo7.DisplayMember = combo8.DisplayMember = "subjectName";
                panelexam2.Visible = true;
            }
            else
            {
                panelexam2.Visible = false;
            }
        }

        private void combofaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            var chosenfaculty = db.departments.Where(f => f.facultyID == (combofaculty.SelectedIndex + 1));
            comboDepartment.DataSource = chosenfaculty.ToList();
            comboDepartment.ValueMember = "Id";
            comboDepartment.DisplayMember = "departmentName";
        }
        public void jamscore()
        {

        }
        public void button4_Click(object sender, EventArgs e)
        {

            jambsc1 = Convert.ToInt32(txtjamb1.Text);
            jambsc2 = Convert.ToInt32(txtjamb2.Text);
            jambsc3 = Convert.ToInt32(txtjamb3.Text);
            jambsc4 = Convert.ToInt32(txtjamb4.Text);

            //validation//
            if (txtFname.Text == "" || txtSurname.Text == "" || txtMidd.Text == "" ||
                jambsub1.Text == "" || jambsub2.Text == "" || jambsub3.Text == "" ||
                jambsub4.Text == "" || combo3.Text == "" || combo4.Text == "" || combo5.Text == ""
                    || txtjamb1.Text == "" || txtjamb2.Text == "" || txtjamb3.Text == ""
                    || txtjamb4.Text == "" || combofaculty.Text == "" || comboDepartment.Text == "" ||
                    combograde1.Text == "" || combograde2.Text == "" ||
                    combograde3.Text == "" || combograde4.Text == "" ||
                    combograde5.Text == "" || labeljamb.Text == "" ||
                combositting.Text == "" || comboexam.Text == ""
             )
            {
                MessageBox.Show("one or more required filed not filled", ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            // where i stopped for bed
            //setting condition for Olevel
            int jamboscore = jambsc1 + jambsc2 + jambsc3 + jambsc4;

            if (combositting.SelectedIndex == 0 && jamboscore>= 180)
            {

                if (combograde1.SelectedIndex > 5 || combograde2.SelectedIndex > 5)
                {
                    MessageBox.Show("Unaccepted Olevel Result");
                    return;
                }
                else
                {
                    fulldetail detail = new fulldetail()
                    {
                        firstName = txtFname.Text,
                        lastName = txtSurname.Text,
                        middleName = txtMidd.Text,
                        dateofBirth = date.MinDate,
                        state = statecombo.Text,
                        localGov = LocalgvCombo.Text,
                        nationality = txtnationality.Text,
                        examSitting = Convert.ToInt32(combositting.Text),
                        exam1Name = comboexam.Text,
                        sub1 = "English" + combograde1.Text,
                        sub12 = "Mathematics" + combograde2.Text,
                        sub13 = combo3.Text + combograde3.Text,
                        sub14 = combo4.Text + combograde4.Text,
                        sub15 = combo5.Text + combograde5.Text,
                        sub21 = "",
                        sub22 = "",
                        sub23 = "",
                        sub24 = "",
                        sub25 = "",
                        exam2Name = "",
                        jambsub1 = jambsub1.Text,
                        jambsub2 = jambsub2.Text,
                        jambsub3 = jambsub3.Text,
                        jambsub4 = jambsub4.Text,
                        jambScore = jamboscore,
                        department = comboDepartment.Text,
                        faculty = combofaculty.Text,
                        passWord = txtSurname.Text + jamboscore,
                        userName = txtSurname.Text,
                        image = Convertimages(pictureBox1.Image)


                    };

                    db.fulldetails.Add(detail);
                    db.SaveChanges();
                    MessageBox.Show("Your have successfully registered", Name);


                    this.Hide();
                    Student_details std = new Student_details();
                    std.Show();
                }
            }

            else if( combositting.SelectedIndex ==1 && jamboscore >= 180)
            {
                if (combograde1.SelectedIndex > 5 && combograde11.SelectedIndex > 5)
                    MessageBox.Show("Unaccepted 2 english Result");

                else if (combograde2.SelectedIndex > 5 && combograde12.SelectedIndex > 5)
                    MessageBox.Show("Unaccepted Olevel Result");
                else
                {
                    fulldetail detail = new fulldetail()
                    {
                        firstName = txtFname.Text,
                        lastName = txtSurname.Text,
                        middleName = txtMidd.Text,
                        dateofBirth = date.MinDate,
                        state = statecombo.Text,
                        localGov = LocalgvCombo.Text,
                        nationality = txtnationality.Text,
                        examSitting = Convert.ToInt32(combositting.Text),
                        exam1Name = comboexam.Text,
                        sub1 = "English" + combograde1.Text,
                        sub12 = "Mathematics" + combograde2.Text,
                        sub13 = combo3.Text + combograde3.Text,
                        sub14 = combo4.Text + combograde4.Text,
                        sub15 = combo5.Text + combograde5.Text,
                        sub21 = "English" + combograde11.Text,
                        sub22 = "Mathematics" + combograde12.Text,
                        sub23 = combo13.Text + combograde13.Text,
                        sub24 = combo14.Text + combograde14.Text,
                        sub25 = combo15.Text + combograde15.Text,
                        exam2Name = comboexam2.Text,
                        jambsub1 = jambsub1.Text,
                        jambsub2 = jambsub2.Text,
                        jambsub3 = jambsub3.Text,
                        jambsub4 = jambsub4.Text,
                        jambScore = jamboscore,
                        department = comboDepartment.Text,
                        faculty = combofaculty.Text,
                        passWord = txtSurname.Text + jamboscore,
                        userName = txtSurname.Text,
                        image = Convertimages(pictureBox1.Image)


                    };

                    db.fulldetails.Add(detail);
                    db.SaveChanges();
                    MessageBox.Show("Your have successfully registered", Name);


                    this.Hide();
                    Student_details std = new Student_details();
                    std.Show();
                }
            }
             else
            {
                MessageBox.Show(" Unqualified  ");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           

            if (txtjamb1.Text == "" || txtjamb2.Text == "" || txtjamb3.Text == ""
                  || txtjamb4.Text == "")
            {
                MessageBox.Show("Wronge Jamb Score Update");
                txtjamb1.Text =
               txtjamb2.Text =
               txtjamb3.Text =
               txtjamb4.Text = "";
                return;
            }

          
            else if (Convert.ToInt32(txtjamb1.Text) > 100 || Convert.ToInt32(txtjamb2.Text) > 100 ||
                   Convert.ToInt32(txtjamb3.Text) > 100 || Convert.ToInt32(txtjamb4.Text) > 100 ||
                   Convert.ToInt32(txtjamb1.Text) < 0 || Convert.ToInt32(txtjamb2.Text) < 0 ||
                   Convert.ToInt32(txtjamb3.Text) < 0 || Convert.ToInt32(txtjamb4.Text) < 0)
            {
                MessageBox.Show("Wronge Jamb Score Update");
                txtjamb1.Text =
               txtjamb2.Text =
               txtjamb3.Text =
               txtjamb4.Text = "";
                return;
            }
         

           else
            { int jamboscore = Convert.ToInt32(txtjamb1.Text) + Convert.ToInt32(txtjamb2.Text) +
                      Convert.ToInt32(txtjamb3.Text) + Convert.ToInt32(txtjamb4.Text);
            

                    labeljamb.Text = Convert.ToString(jamboscore);
            }
               
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
