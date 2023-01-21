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
    public partial class UserEdit : Form
    {
        TechDboDataContext pd = new TechDboDataContext();
        public UserEdit()
        {
            InitializeComponent();
            this.CenterToScreen();

            if (Util.userTypeConnected != "admin")
                cBoxActive.Enabled = false;

            var roles = (from x in pd.Roles
                             // where x.DeletedUser == 0 || x.DeletedUser == null
                         select x).OrderBy(v => (int)v.Id);//OrderByDescending
            foreach (var role in roles)
            {
                if (Util.userRoleConnected.Equals("masterAdmin"))
                    cBoxRole.Items.Add(role.Description);
                else
                if (Util.userTypeConnected == "admin" && !Util.userRoleConnected.Equals("masterAdmin"))
                    if(role.Name != "masterAdmin" && role.Name != "admin")
                        if(Util.userRolePriorityIdConnected >= role.PriorityLevel)
                        cBoxRole.Items.Add(role.Description);
                    else
                        if (Util.userTypeConnected != "admin")
                            if (!role.Name.Contains("Admin"))
                                cBoxRole.Items.Add(role.Description);

            }
            cBoxRole.Text = Util.userRole;

            //user permissions
            var userInfo = (from x in pd.UserPermissions
                            join xy in pd.Permissions on x.PermissionId equals xy.Id
                            where x.UserId == Util.userId
                            select new
                            {
                                id = xy.Id,
                                name = xy.Name,
                                description = xy.Description,
                                orderId = xy.OrderId
                            }
                            //select x
                            ).OrderBy(v => v.orderId);

            // Sets up the initial objects in the CheckedListBox
            List<string> myPermissions = new List<string>();
            // Object[] objRolePermissions = new Object[50];
            List<string> allPermissions = new List<string>();
            //int j = 0;

            if (Util.objUserPermissionsList.Count > 0)
                Util.objUserPermissionsList.Clear();

            foreach (var item in userInfo)
            {
                myPermissions.Add(item.description);
                Util.objUserPermissionsList.Add(item.id, item.description);
                //objRolePermissions[j] = new {item.id, item.description };

            }
            //Util.objRolePermissions = objRolePermissions;//objRolePermissions[0].GetType().GetProperty("id").GetValue(objRolePermissions[0])
            string[] myPermissionList = myPermissions.ToArray();
            checkedListBoxPermissions.Items.AddRange(myPermissionList);
            for (int m = 0; m < checkedListBoxPermissions.Items.Count; m++)
            {
                checkedListBoxPermissions.SetItemChecked(m, true);
            }
            checkedListBoxPermissions.CheckOnClick = true;

            var permissions = (from x in pd.Permissions
                                   //where x.id == id
                               select x).OrderBy(v => v.OrderId);

            foreach (var x in permissions)
            {
                if (!myPermissions.Contains(x.Description))
                    allPermissions.Add(x.Description);
            }
            string[] allPermissionList = allPermissions.ToArray();
            checkedListBoxPermissions.Items.AddRange(allPermissionList);
        }

        private void UserEdit_Load(object sender, EventArgs e)
        {
            //Util.userId = 0;
            //Util.userType = "";
            //Util.department = "";
            //Util.user = "";
            //Util.pass = "";
            //Util.name = "";
            //Util.Email = "";

            if (Util.newUser == true || (Util.newUser == false && Util.userTypeConnected == "admin" && Util.persAccount == false))
            {
                genRanPasslLabel.Show();
               
            }
            else
                genRanPasslLabel.Hide();

            UserIdtbox.Text = Util.userId.ToString();
            UsertBox.Enabled = Util.userTypeConnected == "admin" ? true : false;
            UsertBox.Text = Util.user;
            // PassTBox.Text = Util.pass;
            oldPasslb.Enabled = (Util.persAccount || Convert.ToInt32(UserIdtbox.Text) == Util.userIdConnected) && Util.newUser == false ? true : false; //Util.newUser == true || (Util.newUser == false && Util.userTypeConnected == "admin" && Util.persAccount == false && Convert.ToInt32(UserIdtbox.Text) != Util.userIdConnected)  ? false : true;
            oldPassTBox.Enabled = (Util.persAccount || Convert.ToInt32(UserIdtbox.Text) == Util.userIdConnected) && Util.newUser == false ? true : false;//Util.newUser == true || (Util.newUser == false && Util.userTypeConnected == "admin" && Util.persAccount == false && Convert.ToInt32(UserIdtbox.Text) != Util.userIdConnected) ? false : true;
            PassTBox.Enabled = (Util.newUser == true ||( Util.newUser == false && oldPassTBox.Enabled == true && oldPassTBox.Text != "") || (Util.newUser == false && Util.userTypeConnected == "admin" && Convert.ToInt32(UserIdtbox.Text) != Util.userIdConnected) ? true : false);
            confPassTBox.Enabled = PassTBox.Enabled == true ? true : false;
            genRanPasslLabel.Visible = !Util.persAccount && PassTBox.Enabled == true ? true : false;
            departmentCBox.Enabled = Util.userTypeConnected == "admin" ? (Util.userRoleConnected != "depAdmin" ? true : false) : false ;
            departmentCBox.Text = Util.newUser == true ? Util.departmentConnected : Util.department;
            cBoxPosition.Enabled = Util.userTypeConnected == "admin" ? true : false;
            cBoxPosition.Text = Util.position;
            NametBox.Text = Util.name;
            EmailtBox.Text = Util.Email;
            cBoxActive.Checked = Convert.ToInt32(Util.active) == 1 ? true : false;

            TypeCBox.Enabled = Util.userTypeConnected == "admin" ? true : false;
            TypeCBox.Text = Util.userType;
            cBoxProject.Text = Util.userProject;
            btbDelete.Enabled = Util.userTypeConnected == "admin" && UserIdtbox.Text != Util.userIdConnected.ToString() && Util.newUser == false && !Util.persAccount ? true : false;
            lbRole.Visible = Util.userRolePermissions.Contains("VIEW_ROLES") || Util.userPermissions.Count > 0 && !Util.userPermissions.Contains("VIEW_ROLES") ? true : false;//if(!Util.userRolePermissions.Contains("ADD_EDIT_INTERNAL_TASKS") && (Util.userPermissions.Count > 0 && !Util.userPermissions.Contains("ADD_EDIT_INTERNAL_TASKS"))) 
            //Util.userRoleConnected == "masterAdmin"
            cBoxRole.Visible = Util.userRolePermissions.Contains("VIEW_ROLES") || Util.userPermissions.Count > 0 && !Util.userPermissions.Contains("VIEW_ROLES") ? true : false;//if(!Util.userRolePermissions.Contains("ADD_EDIT_INTERNAL_TASKS") && (Util.userPermissions.Count > 0 && !Util.userPermissions.Contains("ADD_EDIT_INTERNAL_TASKS")))  ? true : false;
            //Util.userRoleConnected == "masterAdmin"

            if (Util.persAccount == true)
            {
                UserIdtbox.Text = Util.userIdConnected.ToString();
                UsertBox.Text = Util.userConnected;
               // PassTBox.Text = Util.pass;
                departmentCBox.Text = Util.departmentConnected;
                cBoxPosition.Text = Util.positionUserConnected;
                NametBox.Text = Util.fullNameConnected;
                EmailtBox.Text = Util.userEmailConnected;
                TypeCBox.Text = Util.userTypeConnected;

                PassTBox.Enabled = (Util.newUser == true || (Util.newUser == false && oldPassTBox.Text != "") /*|| (Util.newUser == false && Util.userTypeConnected == "admin")*/ ? true : false);
                confPassTBox.Enabled = PassTBox.Enabled == true ? true : false;
                cBoxProject.Enabled = Util.userTypeConnected == "admin" ? true : false;
                //btbDelete.Enabled = Util.userConnected.ToLower() == "florentin.m".ToString() ? true : false;
            }  
            
           
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }       

        private void savebtn_Click(object sender, EventArgs e)
        {
            int roleId = cBoxRole.Text !=string.Empty ? cBoxRole.SelectedIndex + 1 : 0;
            int active = 0;
            if (cBoxActive.Checked == true)
                active = 1;
            string codedPass = "";
            string passwordToSave = "";
            bool existingUser = false;

            if (Util.newUser == true)
            {
                var userInfo = (from x in pd.Users
                                select x).OrderBy(v => v.id);

                //string[] accounts = new string[50];
                //int k = 1;

                foreach (var user in userInfo)
                {
                    if (String.Equals(UsertBox.Text.Trim(), user.userName.Trim()) || String.Equals(UsertBox.Text.Trim(), user.userName.Trim().ToLower()) || String.Equals(UsertBox.Text.Trim().ToLower(), user.userName.Trim().ToLower()))
                    {
                        existingUser = true;
                        MessageBox.Show("This username exists already!");
                        return;
                    }
                    
                }

                if (!existingUser)
                {
                    //if (statusCBox.Text == string.Empty && issueDescTBox.Text == string.Empty)///////////to add, improve!!!
                    //{
                    //    MessageBox.Show("You have empty fields. You cannot save an empty row!");
                    //}
                    //else
                    {
                        DialogResult rezultat = MessageBox.Show("Do you want to add a new user?", "Confirmation", MessageBoxButtons.OKCancel);
                        Util.passw = PassTBox.Text;
                        Criptare.cript();
                        passwordToSave = PassTBox.Enabled == true ? Util.passCript : null;
                        if (rezultat == DialogResult.OK)
                            insertUser(UsertBox.Text, passwordToSave, departmentCBox.Text, cBoxPosition.Text, NametBox.Text, EmailtBox.Text, TypeCBox.Text, cBoxProject.Text, active, 0, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), null, null, null, null);
                    }
                }
            }
            if (Util.newUser == false)
            {
                if (Util.userTypeConnected == "admin" || ( Util.persAccount == true && UsertBox.Text == Util.userConnected))
                {
                    DialogResult rezultat = MessageBox.Show("Do you want to update the user?", "Confirmation", MessageBoxButtons.OKCancel);
                    // codedPass = PassTBox.Text;
                    //Util.oldPassw = oldPassTBox.Text;
                    string oldPassCripted = "";


                    var userInfo = (from x in pd.Users
                                    where x.id == Util.userIdConnected
                                    select x);
                    if (Util.userTypeConnected == "admin" && Util.persAccount == false)
                    {
                        oldPassTBox.Enabled = false;
                    }

                    oldPassCripted = userInfo.First().Password;

                    //Util.passw = oldPassTBox.Text;
                    //Criptare.cript();

                    if (PassTBox.Text !=  "" && oldPassTBox.Enabled == true && oldPassTBox.Text == "")
                        MessageBox.Show("Please insert old password!!!");
                    if (oldPassTBox.Enabled == true && oldPassTBox.Text != "" && oldPassCripted != Util.passCript)
                     MessageBox.Show("Old password is wrong!!!");
                    else
                        if (confPassTBox.Text == String.Empty && PassTBox.Text != "")
                        MessageBox.Show("Please insert confirmation for the new password!");
                    else
                        if (PassTBox.Text != confPassTBox.Text)
                        MessageBox.Show("The two new passwords do not match!!!");
                    else
                    {
                        Util.passw = PassTBox.Text;
                        Criptare.cript();
                        passwordToSave = PassTBox.Enabled == true ? Util.passCript : null;
                        if (rezultat == DialogResult.OK)
                        {
                            updateUser(UsertBox.Text, Util.passCript, departmentCBox.Text, cBoxPosition.Text, NametBox.Text, EmailtBox.Text, TypeCBox.Text, cBoxProject.Text, active, 0, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), null, null, null, null);
                            if (Util.userRoleConnected == "masterAdmin")
                            {
                                updateUserRole(roleId);
                                //update role permissions
                                int[] permissionsIds = new int[pd.Permissions.ToArray().Length];
                                int[] permissionsIdsToAdd = new int[pd.Permissions.ToArray().Length];
                                int[] permissionsIdsToRemove = new int[pd.Permissions.ToArray().Length];
                                for (int i = 0; i < checkedListBoxPermissions.CheckedItems.Count; i++)
                                {
                                    foreach (var item in pd.Permissions.ToArray())
                                    {
                                        if (item.Description.Equals(checkedListBoxPermissions.CheckedItems[i]))
                                            permissionsIds[i] = item.Id;
                                    }

                                    if (!Util.objUserPermissionsList.ContainsKey(permissionsIds[i]))
                                        permissionsIdsToAdd[i] = permissionsIds[i];
                                }
                                int p = 0;
                                foreach (var item in Util.objUserPermissionsList)
                                {
                                    if (!permissionsIds.Contains(item.Key))
                                        permissionsIdsToRemove[p] = item.Key;
                                    p++;
                                }
                                permissionsIdsToAdd = permissionsIdsToAdd.Except(new int[] { 0 }).ToArray();
                                permissionsIdsToRemove = permissionsIdsToRemove.Except(new int[] { 0 }).ToArray();

                                if (permissionsIdsToAdd.Length > 0)
                                    insertUserPermission(permissionsIdsToAdd, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
                                if (permissionsIdsToRemove.Length > 0)
                                    deleteUserPermission(permissionsIdsToRemove);
                            }
                        }

                        this.Dispose();
                    }
                 }
            }


            //IntTrackerView.Items.Clear();
            //Refresh(sender, e);
            this.Dispose();

            //form = new IntTracker();
            //form.Show();
            //IntTracker.ActiveForm.Refresh();
            //IntTracker.ActiveForm.Show();
            //public event Action ReloadForm1;

            ////on the place where you will reload form1
            // ReloadForm1();
        }


        public void insertUser(string UserName, string Password, string Department, string Position, string Name, string Email, string Type, string UserProject, int Active, int CreatedBy, DateTime CreatedDate, string MachineName, string Macc, string IPAdress, string WinAccount)
        {
            IPAdress = Util.userIp;

            User dp = new User()
            {
                userName = UserName,
                Password = Password,
                department = Department,
                position = Position,
                name = Name,
                Email = Email,
                userType = Type,
                DefaultProject = Convert.ToInt32(UserProject),
                Active = Active,
                CreatedByHostMachine = Util.userMachine,
                CreatedByHostMaccAdress = Util.userMachineMacc,
                CreatedBy = Util.userIdConnected,
                CreatedDate = CreatedDate,
                CreatedByIPAdress = IPAdress,
                CreatedByWindowsAccount = Environment.UserName
            };

            try
            {
                pd.Users.InsertOnSubmit(dp);
                pd.SubmitChanges();
                MessageBox.Show("User was successfully added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("User was not added!" + ex.Message);
            }
        }

        public void updateUser(string UserName, string Password, string Department, string Position, string Name, string Email, string Type, string UserProject, int Active,int UpdatedBy, DateTime LastUpdate, string MachineName, string Macc, string IPAdress, string WinAccount)
        {
            int id = Util.persAccount == false ? Util.userId : Util.userIdConnected;
            IPAdress = Util.userIp;
            var userUpdate = (from x in pd.Users
                                where x.id == id
                                select x);

            foreach (var x in userUpdate)
            {
                x.userName = UserName;
                if(PassTBox.Text != "")
                x.Password = Password;
                x.department = Department;
                x.position = Position;
                x.name = Name;
                x.Email = Email;
                x.userType = Type;
                x.DefaultProject = Convert.ToInt32(UserProject);
                x.Active = Active;
                x.UpdatedBy = Util.userIdConnected;
                x.LastUpdate = LastUpdate;
                x.HostMachine = Util.userMachine;
                x.HostMaccAdress = Util.userMachineMacc;
                x.IPAdress = IPAdress;
                x.UpdatedByWindowsAccount = Environment.UserName;
            }

            try
            {
                pd.SubmitChanges();
                MessageBox.Show("User was successfully updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("User was not updated!" + ex.Message);
            }            
        }
        public void updateUserRole(int userRole)
        {
            int id = Util.persAccount == false ? Util.userId : Util.userIdConnected;
            //IPAdress = Util.userIp;
            var userRoleUpdate = (from x in pd.UserRoles
                              where x.UserID == id
                              select x);

            foreach (var x in userRoleUpdate)
            {
                x.RoleID = userRole;
                x.UpdateTime = DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }

            if (userRoleUpdate.ToArray().Length == 0 && cBoxRole.Text != string.Empty)
            {
                UserRole dp = new UserRole()
                {
                    RoleID = userRole,
                    UserID = Util.userId,
                    UpdateTime = DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
            
                };

                try
                {
                    pd.UserRoles.InsertOnSubmit(dp);
                    pd.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {

                try
                {
                    pd.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }

        public void insertUserPermission(int[] permissionsIdsToAdd, DateTime CreateDate)
        {
            foreach (var item in permissionsIdsToAdd)
            {
                UserPermission dp = new UserPermission()
                {
                    UserId = Util.userId,
                    PermissionId = item,
                   UpdateTime = DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)

                };

                try
                {
                    pd.UserPermissions.InsertOnSubmit(dp);
                    pd.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }

        public void deleteUserPermission(int[] permissionsIdsToRemove)
        {
            foreach (var item in permissionsIdsToRemove)
            {
                var userPermDel = (from x in pd.UserPermissions
                                   where x.UserId == Util.userId && x.PermissionId == item
                                   select x).FirstOrDefault();

                try
                {
                    pd.UserPermissions.DeleteOnSubmit(userPermDel);
                    pd.SubmitChanges();
                    //MessageBox.Show("Permission was assigned  was successfully to the role!");
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Role was not added!" + ex.Message);
                }
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string genPass = RandomPassword(20);
            //MessageBox.Show(genPass);
            PassTBox.Text = genPass;
            PassTBox.UseSystemPasswordChar = false;
            confPassTBox.Text = genPass;
        }

        public string RandomPassword(int size = 0)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(7, true));
            builder.Append(RandomNumber(100, 999));
            builder.Append(RandomString(8, false));
            return builder.ToString();
        }
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

        private void oldPassTBox_TextChanged(object sender, EventArgs e)
        {
            PassTBox.Enabled = oldPassTBox.Text != string.Empty ? true : false;
            confPassTBox.Enabled = oldPassTBox.Text != string.Empty ? true : false;
            genRanPasslLabel.Visible = !Util.persAccount && oldPassTBox.Text != string.Empty ? true : false;
        }

        private void btbDelete_Click(object sender, EventArgs e)
        {
            string IPAdress = Util.userIp;

            DialogResult DeletePrompt = MessageBox.Show("Do you want to delete the current user?", "Confirmation", MessageBoxButtons.OKCancel);

            if (DeletePrompt == DialogResult.OK)
            {
                var userUpdate = (from x in pd.Users
                                  where x.id == Convert.ToInt32(UserIdtbox.Text)
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
