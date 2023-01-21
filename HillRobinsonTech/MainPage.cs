using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace HillRobinsonTech
{
    public partial class MainPage : Form
    {
       // PersoaneDataContext pd = new PersoaneDataContext();

        public MainPage()
        {
            InitializeComponent();
            CenterToParent();
            signInToolStripMenuItem.Text = Util.fullNameConnected + " - " + Util.departmentConnected + (Util.positionUserConnected != null && Util.positionUserConnected != ""  ? (" - " + Util.positionUserConnected).ToString() : "");

            //to update!!!
            if (Util.userTypeConnected == "guest")
                manageAccountToolStripMenuItem.Enabled = false;

            if (Util.userRoleConnected !=null && Util.userRoleConnected.Contains("Admin"))//(Util.userTypeConnected == "admin")
            {
                //Userbtn.Enabled = true;
                //pictureBox2.Enabled = true;
                AdminToolStripMenuItem.Visible = true;
                if(Util.userRoleConnected.Equals("masterAdmin"))
                {                    
                    inventoryToolStripMenuItem.Visible = true;
                    emailToolStripMenuItem.Visible = true;
                    /////
                    rolesToolStripMenuItem.Visible = true;
                    permissionsToolStripMenuItem1.Visible = true;
                    departmentsToolStripMenuItem.Visible = true;
                    locationsToolStripMenuItem.Visible = true;
                    historyLogToolStripMenuItem.Visible = true;
                }
                if (Util.userRolePermissions.Contains("VIEW_LOCATIONS") || Util.userPermissions.Contains("VIEW_LOCATIONS"))
                    locationsToolStripMenuItem.Visible = true;
            }
            else
            {
                //Userbtn.Enabled = false;
                //pictureBox2.Enabled = false;
                AdminToolStripMenuItem.Visible = false;
            }
        }

        internal struct LASTINPUTINFO
        {
            public uint cbSize;

            public uint dwTime;
        }

        /// <summary>
        /// Helps to find the idle time, (in milliseconds) spent since the last user input
        /// </summary>
        public class IdleTimeFinder
        {
            [DllImport("User32.dll")]
            private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

            [DllImport("Kernel32.dll")]
            private static extern uint GetLastError();


            public static uint GetIdleTime()
            {
                LASTINPUTINFO lastInPut = new LASTINPUTINFO();
                lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
                GetLastInputInfo(ref lastInPut);

                return ((uint)Environment.TickCount - lastInPut.dwTime);
            }
            /// <summary>
            /// Get the Last input time in milliseconds
            /// </summary>
            /// <returns></returns>
            public static long GetLastInputTime()
            {
                LASTINPUTINFO lastInPut = new LASTINPUTINFO();
                lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
                if (!GetLastInputInfo(ref lastInPut))
                {
                    throw new Exception(GetLastError().ToString());
                }
                return lastInPut.dwTime;
            }
        }

        public void disconnectUser()
        {    
            var userConnection = (from x in Util.pd.Users
                                  where x.id == Util.userIdConnected
                                  select x);

            foreach (var x in userConnection)
            {
                x.LastTimeLoggedOut = DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                
                x.Online = 0;
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

        private void timer1_Tick(object sender, EventArgs e)
        {

            uint idleTime = IdleTimeFinder.GetIdleTime();

            TimeSpan t = TimeSpan.FromMilliseconds(300000 - idleTime);
            string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);
            Util.currentSession = ("Current session: " + t.Minutes.ToString() + " min, " + t.Seconds.ToString() + " sec left").ToString();
            lblCurrentSession.Text = Util.currentSession;


            if (idleTime > 300000)
            {
                disconnectUser();
                this.Dispose();
                Login form = new Login();
                form.ShowDialog();
            }
                      
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }  

        private void lblClock_Click(object sender, EventArgs e)
        {
            DateTime CurrentTime = DateTime.Now;
            Clocklbl.Text = CurrentTime.ToLongTimeString();

        }

        
        private void pBoxIntTrackerAY_Click(object sender, EventArgs e)
        {
            if (Util.userRolePermissions.Contains("VIEW_INTERNAL_TASKS") || Util.userPermissions.Contains("VIEW_INTERNAL_TASKS") ||
                Util.userRolePermissions.Contains("VIEW_CONTRACTOR_TASKS") || Util.userPermissions.Contains("VIEW_CONTRACTOR_TASKS")) //(Util.userTypeConnected == "guest")
            {
                IntTrackerAlYamama form = new IntTrackerAlYamama();
                form.ShowDialog();
            }
            else
                MessageBox.Show("You do not have permissions for this page!");//("This is not available for your user!");
        }
        

        private void ContactsBtn_Click(object sender, EventArgs e)
        {
            if (Util.userRolePermissions.Contains("VIEW_CONTACTS") || Util.userPermissions.Contains("VIEW_CONTACTS")) //(Util.userTypeConnected == "guest")
            {
                Contacts form = new Contacts();
                form.Show();
            }
            else
                MessageBox.Show("You do not have permissions for this page!");//("This is not available for your user!");

            // MessageBox.Show("Page under construction!");       
        }

        private void pBoxContacts_Click(object sender, EventArgs e)
        {
            if (Util.userRolePermissions.Contains("VIEW_CONTACTS") || Util.userPermissions.Contains("VIEW_CONTACTS")) //(Util.userTypeConnected == "guest")
            {
                Contacts form = new Contacts();
                form.Show();
            }
            else
                MessageBox.Show("You do not have permissions for this page!");//("This is not available for your user!");

            // MessageBox.Show("Page under construction!");       
        }



        private void IntTrackerbtn_Click(object sender, EventArgs e)
        {
            if (Util.userRolePermissions.Contains("VIEW_INTERNAL_TASKS") || Util.userPermissions.Contains("VIEW_INTERNAL_TASKS") ||
                Util.userRolePermissions.Contains("VIEW_CONTRACTOR_TASKS") || Util.userPermissions.Contains("VIEW_CONTRACTOR_TASKS")) //(Util.userTypeConnected == "guest")
            {
                IntTrackerAlYamama form = new IntTrackerAlYamama();
                form.ShowDialog();
            }
            else
                MessageBox.Show("You do not have permissions for this page!"); //("This is not available for your user!");
        }


        private void usersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Users form = new Users();
            form.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Roles form = new Roles();
            form.Show();
        }

        private void permissionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Permissions form = new Permissions();
            form.Show();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disconnectUser();
            this.Dispose();
            Login form = new Login();
            form.ShowDialog();
        }

        private void manageAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.newUser = false;
            Util.persAccount = true;
            UserEdit form = new UserEdit();
            form.ShowDialog();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void versionHillRobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Version form = new Version();
            form.ShowDialog();
        }


        private void pBoxIntTrackerSharma_Click(object sender, EventArgs e)
        {
            if (Util.userRolePermissions.Contains("VIEW_INTERNAL_TASKS") || Util.userPermissions.Contains("VIEW_INTERNAL_TASKS") ||
               Util.userRolePermissions.Contains("VIEW_CONTRACTOR_TASKS") || Util.userPermissions.Contains("VIEW_CONTRACTOR_TASKS")) //(Util.userTypeConnected == "guest")
            {
                IntTrackerSharma form = new IntTrackerSharma();
                form.ShowDialog();
            }
            else
                MessageBox.Show("You do not have permissions for this page!"); //("This is not available for your user!");           
        }

        private void btIntTrackerSharma_Click(object sender, EventArgs e)
        {
            if (Util.userRolePermissions.Contains("VIEW_INTERNAL_TASKS") || Util.userPermissions.Contains("VIEW_INTERNAL_TASKS") ||
              Util.userRolePermissions.Contains("VIEW_CONTRACTOR_TASKS") || Util.userPermissions.Contains("VIEW_CONTRACTOR_TASKS")) //(Util.userTypeConnected == "guest")
            {
                IntTrackerSharma form = new IntTrackerSharma();
                form.ShowDialog();
            }
            else
                MessageBox.Show("You do not have permissions for this page!"); //("This is not available for your user!");
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Util.userRoleConnected.Equals("masterAdmin"))
            // (Util.userRolePermissions.Contains("VIEW_INTERNAL_TASKS") || Util.userPermissions.Contains("VIEW_INTERNAL_TASKS") ||
            //Util.userRolePermissions.Contains("VIEW_CONTRACTOR_TASKS") || Util.userPermissions.Contains("VIEW_CONTRACTOR_TASKS")) //(Util.userTypeConnected == "guest")
            {
                Inventory form = new Inventory();
                form.ShowDialog();
            }
            else
                MessageBox.Show("You do not have permissions for this page!");
        }

        private void aYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Util.userRolePermissions.Contains("VIEW_INTERNAL_TASKS") || Util.userPermissions.Contains("VIEW_INTERNAL_TASKS") ||
                Util.userRolePermissions.Contains("VIEW_CONTRACTOR_TASKS") || Util.userPermissions.Contains("VIEW_CONTRACTOR_TASKS")) //(Util.userTypeConnected == "guest")
            {
                IntTrackerAlYamama form = new IntTrackerAlYamama();
                form.ShowDialog();
            }
            else
                MessageBox.Show("You do not have permissions for this page!");
        }

        private void sharmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Util.userRolePermissions.Contains("VIEW_INTERNAL_TASKS") || Util.userPermissions.Contains("VIEW_INTERNAL_TASKS") ||
               Util.userRolePermissions.Contains("VIEW_CONTRACTOR_TASKS") || Util.userPermissions.Contains("VIEW_CONTRACTOR_TASKS")) //(Util.userTypeConnected == "guest")
            {
                IntTrackerSharma form = new IntTrackerSharma();
                form.ShowDialog();
            }
            else
                MessageBox.Show("You do not have permissions for this page!");
        }     

      

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (Util.userConnected == "Guest")
            //    MessageBox.Show("This is not available for 'guest' user!");
            //else
            //{
                //MessageBox.Show("Page under consruction!");

                Email form = new Email();
                form.ShowDialog();
            //}
        }

        private void ContactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Util.userRolePermissions.Contains("VIEW_CONTACTS") || Util.userPermissions.Contains("VIEW_CONTACTS")) //(Util.userTypeConnected == "guest")
            {
                Contacts form = new Contacts();
                form.Show();
            }
            else
                MessageBox.Show("You do not have permissions for this page!"); //("This is not available for your user!");

            // MessageBox.Show("Page under construction!");      
        }

        private void liToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //License form = new License();
            //form.ShowDialog();
        }

        private void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            disconnectUser();
            this.Dispose();
        }

        private void lbversiune_VisibleChanged(object sender, EventArgs e)
        {
            lbversiune.Text = "v." + Util.fullVersionInfo;
        }

        private void AdminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void locationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locations form = new Locations();
            form.ShowDialog();
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconnectUser();
        }

        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("Int Tracker app - How to use.pdf");
        }
    }
}
