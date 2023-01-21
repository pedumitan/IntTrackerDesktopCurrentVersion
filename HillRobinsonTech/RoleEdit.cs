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
    public partial class RoleEdit : Form
    {
        TechDboDataContext pd = new TechDboDataContext();
        public RoleEdit()
        {
            InitializeComponent();
            this.CenterToScreen();

            //if (Util.userTypeConnected != "admin")
            //    cBoxActive.Enabled = false;

            //role permissions
            var roleInfo = (from x in pd.RolePermissions
                            join xy in pd.Permissions/*.DefaultIfEmpty()*/ on x.PermissionID equals xy.Id
                            where x.RoleID == Util.roleId
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
            if (Util.objRolePermissionsList.Count > 0)
                Util.objRolePermissionsList.Clear();

            foreach (var item in roleInfo)
            {
                myPermissions.Add(item.description);
                Util.objRolePermissionsList.Add(item.id,item.description);
                //objRolePermissions[j] = new {item.id, item.description };
                
            }
            //Util.objRolePermissions = objRolePermissions;//objRolePermissions[0].GetType().GetProperty("id").GetValue(objRolePermissions[0])
            string[] myPermissionList = myPermissions.ToArray();
            checkedListBoxPermissions.Items.AddRange(myPermissionList);
            for(int m = 0; m< checkedListBoxPermissions.Items.Count; m++)
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

            //user role
            var roleUser = (from x in pd.UserRoles
                            join xy in pd.Users/*.DefaultIfEmpty()*/ on x.UserID equals xy.id
                            where x.RoleID == Util.roleId && xy.Active == 1//&&  xy.DeletedUser != 1 
                            select new
                            {
                                id = xy.id,
                                userName = xy.userName
                            }
                            //select x
                            ).OrderBy(v => v.id);

            List<string> assignedUsers = new List<string>();
            List<string> unAssignedUsers = new List<string>();

            foreach (var item in roleUser)
            {
                assignedUsers.Add(item.userName);
            }
            string[] assignedUserList = assignedUsers.ToArray();
            checkedListBoxRoleUsers.Items.AddRange(assignedUserList);
            for (int m = 0; m < checkedListBoxRoleUsers.Items.Count; m++)
            {
                checkedListBoxRoleUsers.SetItemChecked(m, true);
            }
            checkedListBoxRoleUsers.CheckOnClick = true;

            //var unAssignedUser = (from x in pd.Users
            //                       where x.DeletedUser != 1 && x.Active == 1
            //                      select x).OrderBy(v => v.id);

            //foreach (var x in unAssignedUser)
            //{
            //    if (!assignedUsers.Contains(x.userName))
            //        unAssignedUsers.Add(x.userName);
            //}
            //string[] unAssignedUserList = unAssignedUsers.ToArray();
            //checkedListBoxRoleUsers.Items.AddRange(unAssignedUserList);
        }

        private void RoleEdit_Load(object sender, EventArgs e)
        {           
            RoleIdtbox.Text = Util.roleId.ToString();
            tBoxRoleName.Text = Util.roleName;
            tBoxDescription.Text = Util.roleDescription;

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

            if (Util.newRole == true)
            {
                var RoleInfo = (from x in pd.Roles
                                select x).OrderBy(v => v.Id);

             
                DialogResult rezultat = MessageBox.Show("Do you want to add a new role?", "Confirmation", MessageBoxButtons.OKCancel);

                if (rezultat == DialogResult.OK)
                    insertRole(tBoxRoleName.Text, tBoxDescription.Text, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
                   
            }
            if (Util.newRole == false)
            {
                if (Util.userRoleConnected == "masterAdmin")//|| ( Util.persAccount == true && UsertBox.Text == Util.userConnected))
                {
                    DialogResult rezultat = MessageBox.Show("Do you want to update the role?", "Confirmation", MessageBoxButtons.OKCancel);

                    var roleInfo = (from x in pd.Roles
                                    where x.Id == Util.roleId
                                    select x);

                    if (rezultat == DialogResult.OK)
                        updateRole(tBoxRoleName.Text, tBoxDescription.Text, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));

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
                        
                        if(!Util.objRolePermissionsList.ContainsKey(permissionsIds[i]))
                            permissionsIdsToAdd[i] = permissionsIds[i];
                    }
                    int p = 0;
                    foreach (var item in Util.objRolePermissionsList)
                    {
                        if (!permissionsIds.Contains(item.Key))
                            permissionsIdsToRemove[p] = item.Key;
                        p++;
                    }
                    permissionsIdsToAdd = permissionsIdsToAdd.Except(new int[] { 0 }).ToArray();
                    permissionsIdsToRemove = permissionsIdsToRemove.Except(new int[] { 0 }).ToArray();

                    if (permissionsIdsToAdd.Length > 0)
                        insertRolePermission(permissionsIdsToAdd, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
                    if (permissionsIdsToRemove.Length > 0)
                        deleteRolePermission(permissionsIdsToRemove);

                    this.Dispose();


                 }
            }

            this.Dispose();
        }


        public void insertRole(string roleName, string DescriptionName, DateTime CreateDate)
        {
            //IPAdress = Util.userIp;

            Role dp = new Role()
            {
                Name = roleName,
                Description = DescriptionName,
                LastUpdate = CreateDate              
            };

            try
            {
                pd.Roles.InsertOnSubmit(dp);
                pd.SubmitChanges();
                MessageBox.Show("Role was successfully added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Role was not added!" + ex.Message);
            }
        }

        public void updateRole(string roleName, string DescriptionName, DateTime LastUpdate)
        {
            int id = Convert.ToInt32(RoleIdtbox.Text);
                //Util.persAccount == false ? Util.userId : Util.userIdConnected;
          
            var roleUpdate = (from x in pd.Roles
                              where x.Id == id
                                select x);

            foreach (var x in roleUpdate)
            {
                x.Name = roleName;
                x.Description = DescriptionName;
                x.LastUpdate = LastUpdate;
            }

            try
            {
                pd.SubmitChanges();
                MessageBox.Show("Role was successfully updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Role was not updated!" + ex.Message);
            }            
        }

        public void insertRolePermission(int[] permissionsIdsToAdd, DateTime CreateDate)
        {
            foreach ( var item in permissionsIdsToAdd)
            {
                RolePermission dp = new RolePermission()
                {
                    PermissionID = item,
                    RoleID = Util.roleId,
                    UpdateTime = CreateDate
                };

                try
                {
                    pd.RolePermissions.InsertOnSubmit(dp);
                    pd.SubmitChanges();
                    //MessageBox.Show("Permission was assigned  was successfully to the role!");
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Role was not added!" + ex.Message);
                }
            }
        }

        public void deleteRolePermission(int[] permissionsIdsToRemove)
        {
            foreach (var item in permissionsIdsToRemove)
            {
                var rolePermDel = (from x in pd.RolePermissions
                                  where x.RoleID == Util.roleId && x.PermissionID == item
                                   select x).FirstOrDefault();

                try
                {
                    pd.RolePermissions.DeleteOnSubmit(rolePermDel);
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
                                  where x.id == Convert.ToInt32(RoleIdtbox.Text)
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
