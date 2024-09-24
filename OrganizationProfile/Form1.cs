using System.Text.RegularExpressions;
using System.Windows.Forms;
using System;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo, _StudentNo;
        private object Age;

        public frmRegistration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
            long studentNo = StudentNumber(txtStudentNo.Text);
            long contactNo = ContactNo(txtContactNo.Text);
            string program = cbPrograms.Text;
            string gender = cbGender.Text;
            string birthday = datePickerBirthday.Value.ToString("yyyy-MM-dd");

            StudentInformationClass.SetFullName = fullName;
            StudentInformationClass.SetStudentNo = (int)studentNo;
            StudentInformationClass.SetContactNo = contactNo;
            StudentInformationClass.SetProgram = program;
            StudentInformationClass.SetGender = gender;
            StudentInformationClass.SetBirthday = birthday;
            
            DateTime birthdayDate = datePickerBirthday.Value;
            int age = DateTime.Now.Year - birthdayDate.Year;
            if (birthdayDate > DateTime.Now.AddYears(-age)) age--;
            
            StudentInformationClass.SetAge = Age;
            
            

            frmConfirmation confirmationForm = new frmConfirmation();
            confirmationForm.Show();
            this.Hide();
        }

        

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") &&
                Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") &&
                Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                return LastName + ", " + FirstName + " " + MiddleInitial;
            }
            return "Invalid Name";
        }

        public long StudentNumber(string studNum)
        {
            return long.Parse(studNum);
        }

        public long ContactNo(string contact)
        {
            if (Regex.IsMatch(contact, @"^[0-9]{10,11}$"))
            {
                return long.Parse(contact);
            }
            return 0;
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
            for (int i = 0; i < ListOfProgram.Length; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i]);
            }
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
        }
    }
}