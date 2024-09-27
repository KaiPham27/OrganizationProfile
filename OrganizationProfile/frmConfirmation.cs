using System;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmConfirmation : Form
    {
        public frmConfirmation()
        {
            InitializeComponent();
        }
        private void frmConfirmation_Load(object sender, EventArgs e)
        {
            lblStudentNo.Text = StudentInformationClass.SetStudentNo.ToString(); 
            lblProgram.Text = StudentInformationClass.SetProgram; 
            lblBirthday.Text = StudentInformationClass.SetBirthday; 
            lblGender.Text = StudentInformationClass.SetGender; 
            lblContactNo.Text = StudentInformationClass.SetContactNo.ToString(); 
            lblAge.Text = StudentInformationClass.SetAge.ToString(); 
        }
    }
}

