using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HillRobinsonTech
{
    public partial class PermissionEdit : Form
    {
        TechDboDataContext pd = new TechDboDataContext();
        public PermissionEdit()
        {
            InitializeComponent();
            this.CenterToScreen();

            //if (Util.userTypeConnected != "admin")
            //    cBoxActive.Enabled = false;
        }

        private void PermissionEdit_Load(object sender, EventArgs e)
        {           
            PermissionIdtbox.Text = Util.permissionId.ToString();
            tBoxPName.Text = Util.permissionName;
            tBoxDescription.Text = Util.permissionDescription;

            if(Util.newPermission)
            {
                Util.permissionId = 0;
                Util.permissionName = "";
                Util.permissionDescription = "";
            }

         

            // UserIdtbox.Text = Util.userId.ToString();
            // UsertBox.Enabled = Util.userTypeConnected == "admin" ? true : false;
            // UsertBox.Text = Util.user;
            //// PassTBox.Text = Util.pass;
            // oldPasslb.Enabled = Util.newUser == true || (Util.newUser == false && Util.userTypeConnected == "admin" && Util.persAccount == false)  ? false : true;
            // oldPassTBox.Enabled = Util.newUser == true || (Util.newUser == false && Util.userTypeConnected == "admin" && Util.persAccount == false) ? false : true;
            // PassTBox.Enabled = (Util.newUser == true ||( Util.newUser == false && oldPassTBox.Text != "") || (Util.newUser == false && Util.userTypeConnected == "admin") ? true : false);
            // confPassTBox.Enabled = PassTBox.Enabled == true ? true : false;
            // departmentCBox.Enabled = Util.userTypeConnected == "admin" ? true : false;
            // departmentCBox.Text = Util.department;
            // cBoxPosition.Enabled = Util.userTypeConnected == "admin" ? true : false;
            // cBoxPosition.Text = Util.position;
            // NametBox.Text = Util.name;
            // EmailtBox.Text = Util.Email;
            // cBoxActive.Checked = Convert.ToInt32(Util.active) == 1 ? true : false;

            // TypeCBox.Enabled = Util.userTypeConnected == "admin" ? true : false;
            // TypeCBox.Text = Util.userType;
            // cBoxProject.Text = Util.userProject;
            // btbDelete.Enabled = Util.userTypeConnected == "admin" && UserIdtbox.Text != Util.userIdConnected.ToString() ? true : false;

            // if (Util.persAccount == true)
            // {
            //     UserIdtbox.Text = Util.userIdConnected.ToString();
            //     UsertBox.Text = Util.userConnected;
            //    // PassTBox.Text = Util.pass;
            //     departmentCBox.Text = Util.departmentConnected;
            //     cBoxPosition.Text = Util.positionUserConnected;
            //     NametBox.Text = Util.fullNameConnected;
            //     EmailtBox.Text = Util.userEmailConnected;
            //     TypeCBox.Text = Util.userTypeConnected;

            //     PassTBox.Enabled = (Util.newUser == true || (Util.newUser == false && oldPassTBox.Text != "") /*|| (Util.newUser == false && Util.userTypeConnected == "admin")*/ ? true : false);
            //     confPassTBox.Enabled = PassTBox.Enabled == true ? true : false;
            //     cBoxProject.Enabled = Util.userTypeConnected == "admin" ? true : false;
            //     btbDelete.Enabled = Util.userConnected.ToLower() == "florentin.m".ToString() ? true : false;
            // }     
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }       

        private void savebtn_Click(object sender, EventArgs e)
        {

            if (Util.newPermission == true)
            {
                var permissionInfo = (from x in pd.Permissions
                                select x).OrderBy(v => v.Id);

             
                DialogResult rezultat = MessageBox.Show("Do you want to add a new permission?", "Confirmation", MessageBoxButtons.OKCancel);

                if (rezultat == DialogResult.OK)
                    insertPermission(tBoxPName.Text, tBoxDescription.Text, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
                   
            }
            if (Util.newPermission == false)
            {
                if (Util.userTypeConnected == "admin" )//|| ( Util.persAccount == true && UsertBox.Text == Util.userConnected))
                {
                    DialogResult rezultat = MessageBox.Show("Do you want to update the permission?", "Confirmation", MessageBoxButtons.OKCancel);
                
                    var userInfo = (from x in pd.Permissions
                                    where x.Id == Util.permissionId
                                    select x);

                    if (rezultat == DialogResult.OK)
                        updatePermission(tBoxPName.Text, tBoxDescription.Text, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));

                    this.Dispose();


                 }
            }

            this.Dispose();
        }


        public void insertPermission(string permissionName, string DescriptionName, DateTime CreateDate)
        {
            //IPAdress = Util.userIp;

           Permission dp = new Permission()
            {
                Name = permissionName,
                Description = DescriptionName,
                LastUpdate = CreateDate              
            };

            try
            {
                pd.Permissions.InsertOnSubmit(dp);
                pd.SubmitChanges();
                MessageBox.Show("Permission was successfully added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Permission was not added!" + ex.Message);
            }
        }

        public void updatePermission(string permissionName, string DescriptionName, DateTime LastUpdate)
        {
            int id = Convert.ToInt32(PermissionIdtbox.Text);
                //Util.persAccount == false ? Util.userId : Util.userIdConnected;
          
            var permissionUpdate = (from x in pd.Permissions
                                    where x.Id == id
                                select x);

            foreach (var x in permissionUpdate)
            {
                x.Name = permissionName;
                x.Description = DescriptionName;
                x.LastUpdate = LastUpdate;
            }

            try
            {
                pd.SubmitChanges();
                MessageBox.Show("Permission was successfully updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Permission was not updated!" + ex.Message);
            }            
        }

        private void AddFolDatebt_Click(object sender, EventArgs e)
        {
            //string today = DateTime.Today.ToShortDateString();

            //followUptBox.Text += !followUptBox.Text.Contains(today) ? today + "; " : "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //validationPicBox.ImageLocation = "E:/C:\Users\hp\Desktop\HillRobinsonTech_LocalAdmin_currentversion_1.1.08.20\HillRobinsonTech\Images";

        }

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    string genPass = RandomPassword(20);
        //    //MessageBox.Show(genPass);
        //    PassTBox.Text = genPass;
        //    PassTBox.UseSystemPasswordChar = false;
        //    confPassTBox.Text = genPass;
        //}

        //public string RandomPassword(int size = 0)
        //{
        //    StringBuilder builder = new StringBuilder();
        //    builder.Append(RandomString(7, true));
        //    builder.Append(RandomNumber(100, 999));
        //    builder.Append(RandomString(8, false));
        //    return builder.ToString();
        //}
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
      
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        //private void oldPassTBox_TextChanged(object sender, EventArgs e)
        //{
        //    PassTBox.Enabled = oldPassTBox.Text != string.Empty ? true : false;
        //    confPassTBox.Enabled = oldPassTBox.Text != string.Empty ? true : false;
        //}

        private void btbDelete_Click(object sender, EventArgs e)
        {
            string IPAdress = Util.userIp;

            DialogResult DeletePrompt = MessageBox.Show("Do you want to delete the current user?", "Confirmation", MessageBoxButtons.OKCancel);

            if (DeletePrompt == DialogResult.OK)
            {
                var userUpdate = (from x in pd.Users
                                  where x.id == Convert.ToInt32(PermissionIdtbox.Text)
                                  select x);

                foreach (var x in userUpdate)
                {                   
                    x.DeletedUser = 1;
                    x.UpdatedBy = Util.userIdConnected;
                    x.LastUpdate = DateTime.Now;
                    x.HostMachine = Util.userMachine;
                    x.HostMaccAdress = Util.userMachineMacc;
                    x.IPAdress = IPAdress;
                    x.UpdatedByWindowsAccount = Environment.UserName;
                }

                try
                {
                    pd.SubmitChanges();
                    MessageBox.Show("User was successfully deleted!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("User was not deleted!" + ex.Message);
                }
                this.Dispose();
            }
        }
    }
}
