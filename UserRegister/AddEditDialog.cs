using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserRegister
{
    public partial class AddEditDialog : Form
    {
        private static readonly Person EmptyPerson = new();

        public AddEditDialog()
        {
            InitializeComponent();

            surnameTextBox.Text = EmptyPerson.Surname;
            nameTextBox.Text = EmptyPerson.Name;
            birthdayDateTimePicker.Value = EmptyPerson.DateOfBirth;
        }

        public AddEditDialog(Person p)
        {
            InitializeComponent();

            var person = p ?? EmptyPerson;
            surnameTextBox.Text = person.Surname;
            nameTextBox.Text = person.Name;
            birthdayDateTimePicker.Value = person.DateOfBirth;
        }

        public Person PersonInfo
        {
            get { 
                return new Person(
                    nameTextBox.Text,
                    surnameTextBox.Text,
                    birthdayDateTimePicker.Value
                ); 
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Set the dialog result to OK  
            this.Close(); // Close the dialog  
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // close the form  
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
