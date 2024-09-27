using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string fullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                long studentNo = StudentNumber(txtStudentNo.Text);
                long contactNo = ContactNo(txtContactNo.Text);
                int age = Age(txtAge.Text);
                string program = cbPrograms.Text;
                string gender = cbGender.Text;
                string birthday = datePickerBirthday.Value.ToString("yyyy-MM-dd");

                // Set the student information in StudentInformationClass
                StudentInformationClass.SetFullName = fullName;
                StudentInformationClass.SetStudentNo = (int)studentNo;
                StudentInformationClass.SetContactNo = contactNo;
                StudentInformationClass.SetProgram = program;
                StudentInformationClass.SetGender = gender;
                StudentInformationClass.SetBirthday = birthday;

                // Calculate the correct age based on the birthday
                DateTime birthdayDate = datePickerBirthday.Value;
                if (birthdayDate > DateTime.Now.AddYears(-age)) age--;
                StudentInformationClass.SetAge = age;

                // Show the confirmation form after registering
                frmConfirmation confirmationForm = new frmConfirmation();
                confirmationForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public int Age(string age)
        {
            try
            {
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    return int.Parse(age);
                }
                else
                {
                    MessageBox.Show("Invalid age format! Please enter a number between 1 and 3 digits.");
                    return 0;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Age must be a numeric value.");
                return 0;
            }
            catch (OverflowException)
            {
                MessageBox.Show("The entered age is too large.");
                return 0;
            }
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
            try
            {
                return long.Parse(studNum);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Student Number format! Please enter numeric values only.");
                return 0;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Student Number cannot be empty.");
                return 0;
            }
        }

        public long ContactNo(string contact)
        {
            try
            {
                if (Regex.IsMatch(contact, @"^[0-9]{10,11}$"))
                {
                    return long.Parse(contact);
                }
                else
                {
                    MessageBox.Show("Invalid Contact Number format! It should be 10 or 11 digits.");
                    return 0;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Contact Number must contain only numbers.");
                return 0;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Contact Number is too large.");
                return 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
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

