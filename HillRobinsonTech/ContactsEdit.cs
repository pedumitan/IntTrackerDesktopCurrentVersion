using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HillRobinsonTech
{
    public partial class ContactsEdit : Form
    {
        TechDboDataContext pd = new TechDboDataContext();
        public ContactsEdit()
        {
            InitializeComponent();
            this.CenterToScreen();

            if (!Util.userRolePermissions.Contains("ADD_EDIT_CONTACTS") || (Util.userPermissions.Count > 0 && !Util.userPermissions.Contains("ADD_EDIT_CONTACTS"))) //(Util.userTypeConnected == "guest")
            {
                savebtn.Enabled = false;
            }
        }

        private void ContactsEdit_Load(object sender, EventArgs e)
        {
            tboxId.Text = Util.ContactId.ToString();
            tBoxFName.Text = Util.ContactFirstName;
            tBoxLName.Text = Util.ContactLastName;
            tBoxFullName.Text = Util.ContactFullName;
            tBoxCompany.Text = Util.ContactCompany;
            tBoxDepartment.Text = Util.ContactDepartment;
            tBoxPosition.Text = Util.ContactPosition;
            textBoxWorkPhoneDetails.Text = Util.ContactWorkPhoneDetails;
            tBoxWorkPhoneNo.Text = Util.ContactWorkPhoneNo;
            tBoxWorkEmail.Text = Util.ContactWorkEmail;
            tBoxPersPhoneNo.Text = Util.ContactPersPhoneNo;
            tBoxPersEmail.Text = Util.ContactPersEmail;
            tBoxCountry.Text = Util.ContactCountry;
            tBoxLocation.Text = Util.ContactLocation;
            tBoxOtherInfo.Text = Util.ContactOtherInfo;
            cBoxActive.Checked = Util.ContactActive == 1 ? true : false;

            if (Util.newItem == true)
                cBoxActive.Checked = true;
        }

        private void reset()
        {
            Util.ContactId = 0;
            Util.ContactFirstName = "";
            Util.ContactLastName = "";
            Util.ContactFullName = "";
            Util.ContactCompany = "";
            Util.ContactDepartment = "";
            Util.ContactPosition = "";
            Util.ContactWorkPhoneDetails = "";
            Util.ContactWorkPhoneNo = "";
            Util.ContactWorkEmail = "";
            Util.ContactPersPhoneNo = "";
            Util.ContactPersEmail = "";
            Util.ContactCountry = "";
            Util.ContactLocation = "";
            Util.ContactOtherInfo = "";
            Util.ContactActive = 0;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            reset();
            this.Dispose();            
        }       

        private void savebtn_Click(object sender, EventArgs e)
        {
            int active = 0;
            if (cBoxActive.Checked == true)
                active = 1;

            if (Util.newItem == true)
            {
                cBoxActive.Checked = true;
                if (tBoxFName.Text == string.Empty || tBoxLName.Text == string.Empty)///////////to add, improve!!!
                {
                    MessageBox.Show("You have empty fields. You cannot save an empty row!");
                    Util.SaveError = true;
                }
                else
                {
                    DialogResult rezultat = MessageBox.Show("Do you want to add a new contact?", "Confirmation", MessageBoxButtons.OKCancel);
                    if (rezultat == DialogResult.OK)
                        insertContact(tBoxFName.Text, tBoxLName.Text, tBoxFullName.Text, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),tBoxCompany.Text, tBoxDepartment.Text, tBoxPosition.Text, textBoxWorkPhoneDetails.Text, tBoxWorkPhoneNo.Text, tBoxWorkEmail.Text, tBoxPersPhoneNo.Text, tBoxPersEmail.Text, tBoxCountry.Text, tBoxLocation.Text, tBoxOtherInfo.Text, active, 0,  null, null, null, null);
                    
                }
            }
            
            if (Util.newItem == false)
            {
                DialogResult rezultat = MessageBox.Show("Do you want to update a contact?", "Confirmation", MessageBoxButtons.OKCancel);
                if (rezultat == DialogResult.OK)
                    updateContact(tBoxFName.Text, tBoxLName.Text, tBoxFullName.Text, tBoxCompany.Text, tBoxDepartment.Text, tBoxPosition.Text, textBoxWorkPhoneDetails.Text, tBoxWorkPhoneNo.Text, tBoxWorkEmail.Text, tBoxPersPhoneNo.Text, tBoxPersEmail.Text, tBoxCountry.Text, tBoxLocation.Text, tBoxOtherInfo.Text, active, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), 0, null, null, null, null);

            }
            if (Util.SaveError != true)
                this.Dispose();
            Util.SaveError = false;

            reset();
        }
       

        public void insertContact(string FirstName, string LastName, string FullName, DateTime DateCreated, string Company, string Department, string Position, string WorkPhoneDetails, string WorkPhoneNo, string WorkEmail, string PersPhoneNo, string PersEmail, string Country, string ContactLocation,string OtherInfo, int Active, int CreatedBy, string MachineName, string Macc, string IPAdress, string WinAccount)
        {
            Contact dp = new Contact()
            {
                FirstName = FirstName,
                LastName = LastName,
                fullName = FullName,
                CreatedDate = DateCreated,
                Company = Company,
                Department = Department,
                Position = Position,
                workPhoneDetails = WorkPhoneDetails,
                workPhoneNo = WorkPhoneNo,
                workEmail = WorkEmail,
                persPhoneNo = PersPhoneNo,
                persEmail = PersEmail,
                Country = Country,
                ContactLocation = ContactLocation,
                OtherInfo = OtherInfo,
                Active = Active,
                CreatedBy = Util.userIdConnected,
                CreatedByHostMachine = Util.userMachine,
                CreatedByHostMaccAdress = Util.userMachineMacc,               
                CreatedByWindowsAccount = Util.windowsAccount,
                CreatedByIPAdress = Util.userIp
        };

            try
            {
                pd.Contacts.InsertOnSubmit(dp);
                pd.SubmitChanges();
                MessageBox.Show("Contact was successfully added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Contact was not saved!" + ex.Message);
            }
        }

        public void updateContact(string FirstName, string LastName, string FullName, string Company, string Department, string Position, string WorkPhoneDetails, string WorkPhoneNo, string WorkEmail, string PersPhoneNo, string PersEmail, string Country, string ContactLocation, string OtherInfo, int Active, DateTime LastUpdate, int UpdatedBy, string MachineName, string Macc, string IPAdress, string WinAccount)
        {          
            int Id = Util.ContactId;
            var contactUpdate = (from x in pd.Contacts
                                where x.id == Id
                                select x);

            foreach (var x in contactUpdate)
            {
                x.FirstName = FirstName;
                x.LastName = LastName;
                x.fullName = FullName;

                x.Company = Company;
                x.Department = Department;
                x.Position = Position;
                x.workPhoneDetails = WorkPhoneDetails;
                x.workPhoneNo = WorkPhoneNo;
                x.workEmail = WorkEmail;
                x.persPhoneNo = PersPhoneNo;
                x.persEmail = PersEmail;
                x.Country = Country;
                x.ContactLocation = ContactLocation;
                x.OtherInfo = OtherInfo;
                x.Active = Active;
                if(x.Active == 0)
                    x.InactiveDate = LastUpdate;
                x.LastUpdate = LastUpdate;

                x.UpdatedBy = Util.userIdConnected;
                x.UpdatedByHostMachine = Util.userMachine;
                x.UpdateByHostMaccAdress = Util.userMachineMacc;
                x.UpdatedByIPAdress = Util.userIp;
                x.UpdatedByWindowsAccount = Environment.UserName;
            }

            try
            {
                pd.SubmitChanges();
                MessageBox.Show("Contact was successfully updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Contact was not updated!" + ex.Message);
            }            
        }

        private void AddFolDatebt_Click(object sender, EventArgs e)
        {
            string today = DateTime.Today.ToShortDateString();

            //followUptBox.Text += !followUptBox.Text.Contains(today) ? today + "; " : "";
        }

        private void tBoxFName_TextChanged(object sender, EventArgs e)
        {
            tBoxFullName.Text = tBoxFName.Text + " " + tBoxLName.Text;
        }

        private void tBoxLName_TextChanged(object sender, EventArgs e)
        {
            tBoxFullName.Text = tBoxFName.Text + " " + tBoxLName.Text;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
