using Meziantou.Framework.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HillRobinsonTech
{
    public partial class Login : Form
    {
        //TechDboDataContext pd = new TechDboDataContext();
        string codedPass = null;
        string user = null;
        string pass = null;


        public Login()
        {
            InitializeComponent();
            this.CenterToScreen();

            var mac = NetworkInterface.GetAllNetworkInterfaces();
            var macAddress = String.Join(":", mac[0].GetPhysicalAddress()
                                    .GetAddressBytes()
                                    .Select(b => b.ToString("X2"))
                                    .ToArray());
            Util.userMachineMacc = macAddress;
            Util.windowsAccount = Environment.UserName;
            Util.userMachine = Environment.MachineName;
            if (Util.userPermissions.Count > 0)
            {
                Util.userPermissions.Clear();
            }
            if (Util.userRolePermissions.Count > 0)
            {
                Util.userRolePermissions.Clear();
            }

            if (Environment.UserName.ToLower().Contains("admin") || Environment.UserName.ToLower().Contains("red5"))
                cBoxCredentials.Visible = false;

            cBoxLocalList.SelectedIndex = 0;
            cBoxCloudList.Enabled = false;
            cBoxCloudList.SelectedIndex = -1;

        }

        public void checkVersion()
        {
            string[] versionInfo = lblVersion.Text.Split('.');
            double version = Convert.ToDouble(versionInfo[0] + "." + versionInfo[1]);
            Util.version = version;
            string versionDate = (versionInfo[2] + "." + versionInfo[3]).ToString();
            Util.versionDate = versionDate;
            Util.fullVersionInfo = (version.ToString() + "." + versionDate).ToString();

            if (getConnectionString() == true)
            {
                //check version, if older than dbo version block access
                SqlConnection connection = new SqlConnection(UnivSource.connectionString);
                connection.Open();
                System.Data.DataTable TrackDt = new System.Data.DataTable();
                System.Data.DataTable TrackDtAllRows = new System.Data.DataTable();
                DataSet ds = null;
                SqlDataAdapter da = null;
                string dbo = "[avitsql].[GetVersionCheck]";

                using (SqlCommand cmd = new SqlCommand(dbo, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Version", SqlDbType.Float).Value = Util.version;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    using (da = new SqlDataAdapter(cmd))
                    {
                        ds = new DataSet();
                        da.Fill(ds);

                    }
                }
                connection.Close();
            }
        }

        public void buton()
        {
            checkVersion();            

            bool WrongUser = true;
            bool noUser = false;
            bool noPass = false;
            user = tBoxuser.Text.ToString();
            pass = tBoxpass.Text.ToString();
            Util.passw = pass;
            Util.userTypeConnected = "";
            Util.departmentConnected = "";
            Util.positionUserConnected = "";

            if (tBoxuser.Text == "")
            {
                noUser = true;                
            }
            else
            if (tBoxpass.Text == "")
            {
                noPass = true;               
            }

            var userInfo =
                            //(from x in pd.Users
                            //join xy in pd.UserRoles.DefaultIfEmpty() on x.id equals xy.UserID
                            //join xyz in pd.Roles.DefaultIfEmpty() on xy.RoleID equals xyz.Id
                            //select new
                            (from x in Util.pd.Users
                            join xy in Util.pd.UserRoles on x.id equals xy.UserID into userRole
                            from userRoleResult in userRole.DefaultIfEmpty()
                            join xyz in Util.pd.Roles on userRoleResult.RoleID equals xyz.Id into Roles
                            from RoleResult in Roles.DefaultIfEmpty()
                             select new
                             {
                                id = x.id,
                                name = x.name,
                                userName = x.userName,
                                department = x.department,
                                userType = x.userType,
                                DefaultProject = x.DefaultProject,
                                Email = x.Email,
                                Active = x.Active,
                                position = x.position,
                                Password = x.Password,
                                UserRole = RoleResult.Name,
                                UserRolePriorityId = RoleResult.PriorityLevel
                             }
                            //select x
                            ).OrderBy(v => v.id);

            string[] accounts = new string[50];
            int k = 1;

            foreach (var userItem in userInfo)
            {
                if (String.Equals(tBoxuser.Text.Trim(), userItem.userName.Trim()) || String.Equals(tBoxuser.Text.Trim(), userItem.userName.Trim().ToLower())|| String.Equals(tBoxuser.Text.Trim().ToLower(), userItem.userName.Trim().ToLower())) 
                {
                    WrongUser = false;
                    Util.userConnected = userItem.userName;
                    Util.fullNameConnected = userItem.name;
                    Util.departmentConnected = userItem.department;
                    Util.userTypeConnected = userItem.userType;
                    Util.userProject = userItem.DefaultProject.ToString();
                    Util.userIdConnected = userItem.id;
                    Util.userEmailConnected = userItem.Email;
                    Util.active = (int)userItem.Active;
                    Util.positionUserConnected = userItem.position;
                    Util.userRoleConnected = userItem.UserRole;
                    Util.userRolePriorityIdConnected = (int)userItem.UserRolePriorityId;
                }
                accounts[k] = userItem.userName.ToString();

                k++;
            }
           

            getUserPermissions(Util.userIdConnected);

            //for (int i = 1; i <= k; i++)
            //{
            //   if (accounts[i] != null && (tBoxuser.Text == accounts[i] || tBoxuser.Text == accounts[i].ToLower()))
            //    {
            //        WrongUser = false;
            //    }
            //}
            if (noUser == true)
            {
                MessageBox.Show("Please put in your username!!!");
            }
            if (noUser == false && WrongUser == true)
            {
                MessageBox.Show("Wrong username!");
            }

            if (noPass == true & WrongUser == false)
            {
                MessageBox.Show("Please put in your password!!!");
            }
            else
                if (noUser == false && WrongUser == false && noPass == false)
                {

                    foreach (var us in userInfo)
                    {
                        if (String.Equals(tBoxuser.Text.Trim(), us.userName.Trim()) || String.Equals(tBoxuser.Text.Trim(), us.userName.Trim().ToLower()) || String.Equals(tBoxuser.Text.Trim().ToLower(), us.userName.Trim().ToLower()))
                         {
                            Criptare.cript();
                            codedPass = Util.passCript;

                            if (!String.Equals(codedPass,us.Password))
                            {
                                MessageBox.Show("Wrong password!");
                            }
                            else
                            if (String.Equals(codedPass, us.Password))
                            {

                            connectUser(0, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), null, null, null, null, null);

                            Login.ActiveForm.Hide();
                                MainPage form = new MainPage();
                                form.ShowDialog();
                                this.Close();
                            }
                        }
                    }
                }  
        }

        private void connectUser(int userId, DateTime Connected, string ip, string MachineName, string Macc, string windowsAccount, string Version)
        {
            userId = Util.userIdConnected;
            ip = Dns.GetHostAddresses(Environment.MachineName)[1].ToString();

            var userConnection = (from x in Util.pd.Users
                                  where x.id == userId
                                  select x);

            foreach (var x in userConnection)
            {
                x.LastTimeLogged = DateTime.ParseExact(Connected.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                x.LastTimeIpAdress = ip;
                Util.userIp = ip;
                x.LastTimeMachine = Util.userMachine;
                x.LastTimeMaccAdress = Util.userMachineMacc;
                x.WindowsAccount = Util.windowsAccount;
                x.LastTimeVersion = Util.fullVersionInfo;
                x.Online = 1;
            }

            try
            {

                Util.pd.SubmitChanges();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Data was not updated!" + ex.Message);
            }
        }

        private bool getConnectionString()
        {
            if (rbtnLocalServer.Checked && cBoxLocalList.SelectedIndex > -1)// && cBoxLocalList.SelectedItem.ToString().Equals("10.19.107.154"))
            {
                UnivSource.connectionString = @"Data Source="+cBoxLocalList.Text+", 1433; Database=florent_hillrobinsontech_local; User ID=sa;Password=Mranderson1!";
                return true;
            }else

            if (rbtnCloudServer.Checked && cBoxCloudList.SelectedIndex > -1)// && cBoxCloudList.SelectedItem.ToString().Equals("188.213.133.2,1533"))
            {
                UnivSource.connectionString = @"Data Source=" + cBoxCloudList.Text + ",1533; Database=florent_hillrobinsontech; User ID=florent_avitsql;Password=BlackMatza777!!!???";
                return true;
            }

            else
             if ((cBoxLocalList.SelectedIndex == -1 && cBoxCloudList.SelectedIndex == -1)
                  || (rbtnLocalServer.Checked && cBoxLocalList.SelectedIndex == -1)
                  || (rbtnCloudServer.Checked && cBoxCloudList.SelectedIndex == -1))
            {
                MessageBox.Show("Please select a valid server!");
                return false;
            }
            else
                return false;

            //string connectionString = @"Data Source=10.19.107.154, 1433; Database=florent_hillrobinsontech_local; User ID=sa;Password=Mranderson1!";
            //@"Data Source=188.213.133.2,1533; Database=florent_hillrobinsontech; User ID=florent_avitsql;Password=BlackMatza777!!!???";
            //@"Data Source=188.213.132.104,1533; User ID=avitsql;Password=Mranderson1!";
        }

        private void getUserPermissions(int userId)
        {
            SqlConnection connection = new SqlConnection(UnivSource.connectionString);
            connection.Open();
            //get user role permissions
            DataTable TrackDt = new DataTable();
            //System.Data.DataTable TrackDtAllRows = new System.Data.DataTable();
            DataSet ds = null;
            SqlDataAdapter da = null;
            string dbo = "[dbo].[GetUserRolePermission]";

            using (SqlCommand cmd = new SqlCommand(dbo, connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;

                cmd.ExecuteNonQuery();

                using (da = new SqlDataAdapter(cmd))
                {
                    ds = new DataSet();
                    da.Fill(ds);
                }

                TrackDt = ds.Tables["Table"];
                if (TrackDt.Rows.Count > 0)
                {
                    foreach (DataRow row in TrackDt.Rows)
                    {
                        Util.userRolePermissions.Add(row["Permission"].ToString());
                        //Util.userRoleConnected = row["Role"].ToString();
                    }
                }
            }
            //get user individual permissions
            DataTable TrackDt2 = new DataTable();
            //System.Data.DataTable TrackDtAllRows = new System.Data.DataTable();
            DataSet ds2 = null;
            SqlDataAdapter da2 = null;
            string dbo2 = "[avitsql].[GetUserPermission]";

            using (SqlCommand cmd = new SqlCommand(dbo2, connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;

                cmd.ExecuteNonQuery();

                using (da2 = new SqlDataAdapter(cmd))
                {
                    ds2 = new DataSet();
                    da2.Fill(ds2);
                }

                TrackDt2 = ds2.Tables["Table"];
                if (TrackDt2.Rows.Count > 0)
                {
                    foreach (DataRow row in TrackDt2.Rows)
                    {
                        Util.userPermissions.Add(row["Permission"].ToString());
                    }
                }
            }
            connection.Close();
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            //checkVersion();

            if (getConnectionString() == true)
            {


                DateTime dtlimit = new DateTime(2024, 3, 1); //DateTime.Parse("12/31/2021");//till license is built!!!
                DateTime dtToday = DateTime.Today;

                if (dtlimit.Date > dtToday.Date)
                {
                    buton();
                }
                else
                {
                    MessageBox.Show("You need to set up the new version of the app to continue!");
                }

                //buton();
            }
            
        }

        private void cBoxguest_CheckStateChanged(object sender, EventArgs e)
        {
            if (cBoxguest.Checked == true)
            {
                tBoxuser.Text = "Guest";
                tBoxpass.Text = "guest";
            }
            if (cBoxguest.Checked == false)
            {
                tBoxuser.Text = "";
                tBoxpass.Text = "";
            }

        }



        //private void tBoxpass_Validated(object sender, EventArgs e)
        //{
        //    checkVersion();

        //    buton();
        //}

        private void btreset_Click(object sender, EventArgs e)
        {
            tBoxuser.Text = "";
            tBoxpass.Text = "";
        }

        //private void btrecparola_Click(object sender, EventArgs e)
        //{

        //}

        private void cBoxguest_CheckStateChanged_1(object sender, EventArgs e)
        {
            if (cBoxguest.Checked == true)
            {
                tBoxuser.Text = "Guest";
                tBoxpass.Text = "guest";
            }
            if (cBoxguest.Checked == false)
            {
                tBoxuser.Text = "";
                tBoxpass.Text = "";
            }
        }

        private void tBoxpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkVersion();
                buton();
            }               
        }

        private void tBoxuser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // checkVersion();
                //buton();
            //}

            //if (e.KeyCode == Keys.Enter)
            //{
                DateTime dtlimit = new DateTime(2024, 3, 1); //DateTime.Parse("12/31/2021");//till license is built!!!
                DateTime dtToday = DateTime.Today;

                if (dtlimit.Date > dtToday.Date)
                {
                    buton();
                }
                else
                {
                    MessageBox.Show("You need to set up the new version of the app to continue!");
                }
            }
            //buton();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("       For password reset or new account send email to " + Environment.NewLine + "                florentin.mitan@projectbianca.com or " + Environment.NewLine + "                     avit@projectbianca.com.");
        }

        private void cBoxCredentials_CheckedChanged(object sender, EventArgs e)
        {
            // Save the credential to the credential manager
            CredentialManager.WriteCredential(
                applicationName: "Int Tracker",
                userName: tBoxuser.Text,//"meziantou",
                secret: tBoxpass.Text,//"Pa$$w0rd",
                //comment: "Test",
                persistence: CredentialPersistence.LocalMachine);

            //// Get a credential from the credential manager
            //var cred = CredentialManager.ReadCredential(applicationName: "Int Tracker local v.4.1.2.23");
            //Console.WriteLine(cred.UserName);
            //Console.WriteLine(cred.Password);

            //// Delete a credential from the credential manager
            //CredentialManager.DeleteCredential(applicationName: "CredentialManagerTests");
        }

        private void tBoxuser_Click(object sender, EventArgs e)
        {            
            // Get a credential from the credential manager
            var cred = CredentialManager.ReadCredential(applicationName: "Int Tracker");
            if (cred != null)
            {
                tBoxuser.Text = cred.UserName;
                tBoxpass.Text = cred.Password;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void tBoxuser_TextChanged(object sender, EventArgs e)
        {
            if(tBoxuser.Text.Contains("florentin.m"))
            {
                groupBox1.Visible = true;
                rbtnLocalServer.Visible = true;
                cBoxLocalList.Visible = true;

                rbtnCloudServer.Visible = true;
                cBoxCloudList.Visible = true;
            }
            else
            {
                groupBox1.Visible = false;
                rbtnLocalServer.Visible = false;
                cBoxLocalList.Visible = false;

                rbtnCloudServer.Visible = false;
                cBoxCloudList.Visible = false;
            }
        }

        private void rbtnLocalServer_CheckedChanged(object sender, EventArgs e)
        {
            cBoxCloudList.SelectedIndex = -1;
            cBoxCloudList.Enabled = false;
            cBoxLocalList.Enabled = true;
            cBoxLocalList.SelectedIndex = 0;
            Util.LocalServer = true;
            Util.CloudServer = false;            
        }

        private void rbtnCloudServer_CheckedChanged(object sender, EventArgs e)
        {
            cBoxLocalList.SelectedIndex = -1;
            cBoxLocalList.Enabled = false;
            cBoxCloudList.Enabled = true;
            cBoxCloudList.SelectedIndex = 0;
            Util.LocalServer = false; 
            Util.CloudServer = true;
        }

        //private void infoBtn_Click(object sender, EventArgs e)
        //{
        //    //ContractorRecordInfo form = new ContractorRecordInfo();
        //    //form.ShowDialog();
        //    // MessageBox.Show("       If you forgot your password or need an account " + Environment.NewLine + "              send email to avit@projectbianca.com.");
        //}

        //private void infoBtn_MouseHover(object sender, EventArgs e)
        //{
        //    toolTipLogin.Show("Click to display info of the page!", infoBtn);
        //}
    }
}

