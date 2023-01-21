using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Globalization;
using PresentationControls;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using VS = System.Windows.Forms.VisualStyles;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using BrightIdeasSoftware;
//using ObjectListView

namespace HillRobinsonTech
{
    public partial class Users : Form
    {
        TechDboDataContext pd = new TechDboDataContext();
        ImageList Imagelist = new ImageList();

        ////initial states
        //bool technicalInitialCheck = false;
        //bool HKInitialCheck = false;
        //bool FBInitialCheck = false;
        //bool ProcInitialCheck = false;
        //bool CulInitialCheck = false;
        //bool AllInitialCheck = false;
        //bool selectAllIndividual = false;
        //bool deSelectAllIndividual = false;

        public Users()
        {
            InitializeComponent();
            UserView.FullRowSelect = true;
            UserView.GridLines = true;
            UserView.View = View.Details;
            //UserView.Items.Add(new ListViewItem() { ImageIndex = 0 });
            this.CenterToScreen();
            Util.persAccount = false;
           // this.WindowState = FormWindowState.Maximized;
            CustomizeUserView(UserView);

            if (Util.userRolePermissions.Contains("VIEW_USERS_ALL_DEP") || Util.userPermissions.Contains("VIEW_USERS_ALL_DEP")) //(Util.userTypeConnected == "guest")
            {
                cBoxAll.Enabled = true; 
                TechnicalcBox.Enabled = true; TechnicalcBox.Checked = Util.departmentConnected == "Technical" ? true : false;
                HKckBox.Enabled = true; HKckBox.Checked = Util.departmentConnected == "Housekeeping" ? true : false;
                FBcBox.Enabled = true; FBcBox.Checked = Util.departmentConnected == "F&B" ? true : false;
                cBoxCulinary.Enabled = true; cBoxCulinary.Checked = Util.departmentConnected == "Culinary" ? true : false;
                cBoxProcurement.Enabled = true; cBoxProcurement.Checked = Util.departmentConnected == "Procurement" ? true : false;
            }
            if (Util.userRolePermissions.Contains("VIEW_USERS_DEP") || Util.userPermissions.Contains("VIEW_USERS_DEP"))
            {
                if (Util.departmentConnected == "Technical")
                {
                    TechnicalcBox.Enabled = true; TechnicalcBox.Checked = true;
                }
                if(Util.departmentConnected == "Housekeeping")
                {
                    HKckBox.Enabled = true; HKckBox.Checked = true;
                }
                if(Util.departmentConnected == "F&B")
                {
                    FBcBox.Enabled = true; FBcBox.Checked = true;
                }
                if(Util.departmentConnected == "Culinary")
                {
                    cBoxCulinary.Enabled = true; cBoxCulinary.Checked = true;
                }
                if(Util.departmentConnected == "Procurement")
                {
                    cBoxProcurement.Enabled = true; cBoxProcurement.Checked = true;
                }
            }
            Util.UserDepartmentString = Util.departmentConnected;          
        }



        private void Users_Load(object sender, EventArgs e)
        {
            SelectUser(UserView);
            SearchcBox.SelectedIndex = 0;
            // IntTrackerEdit.ReloadForm1 += Reload;                
        }
        //outside method
        void Reload()
        {
            Refresh();
            //IntTracker_Load(sender, e);
            //this.Reload();
        }

        private void Users_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void CustomizeUserView(ListView UserView)
        {
            this.UserView.View = View.Details;
            this.UserView.FullRowSelect = true;
           
            this.UserView.Columns.Add("Id");
            this.UserView.Columns.Add("Name");
            this.UserView.Columns.Add("Department");
            this.UserView.Columns.Add("Position");
            this.UserView.Columns.Add("User");
            //this.UserView.Columns.Add("Password");           
            this.UserView.Columns.Add("Email");
            this.UserView.Columns.Add("Type");
            this.UserView.Columns.Add("Active");
            this.UserView.Columns.Add("Default project");

            ResizeListViewColumns(this.UserView);
        }

        public void ResizeListViewColumns(ListView IntTrackerView)
        {
            foreach (ColumnHeader column in IntTrackerView.Columns)
            {
                column.Width = -2;
            }
        }
    
        public void SelectUser(ListView UserView)
        {
            UserView.Items.Clear();

            ////retrieve all image files
            //String[] ImageFiles = Directory.GetFiles(@"D:\Florentin\HillRobinsonTech_LocalAdmin_versions\HillRobinsonTech_LocalAdmin_currentversion_2.1.5.21\HillRobinsonTech\Images\Icons");
            //foreach (var file in ImageFiles)
            //{
            //    //Add images to Imagelist
            //    Imagelist.Images.Add(System.Drawing.Image.FromFile(file));
            //}
            ////set the amall and large ImageList properties of listview
            ////UserView.LargeImageList = Imagelist;
            //UserView.SmallImageList = Imagelist;

            // if (!Util.FilterUsed)
            //{

            //var users = (from x in pd.Users
            //                where x.DeletedUser == 0 || x.DeletedUser == null
            //                select x).OrderBy(v => (int)v.id);//OrderByDescending


            //int i = 1;
            //foreach (var user in users)
            //{
            //    ListViewItem lviUser = new ListViewItem(user.id.ToString());
            //    ////set the font to the item
            //    //lviIntTrack.Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);

            //    //lviIntTrack.
            //    //if (li.Text = "Sample")
            //    //{
            //    //    li.ForeColor = Color.Green;
            //    //}
            //    //lviIntTrack.BackColor = Color.Azure; -- colors the table background

            //    //lviIntTrack.UseItemStyleForSubItems = false;

            //    //lviIntTrack.SubItems.Add(track.Type != null ? track.Type.ToString() : "").ForeColor = System.Drawing.Color.Red;

            //    //lviIntTrack.UseItemStyleForSubItems = true;

            //    //// Change the expenseItem object's color and font.
            //    //tracks.ForeColor = System.Drawing.Color.Red;
            //    //expenseItem.Font = new System.Drawing.Font(
            //    //    "Arial", 10, System.Drawing.FontStyle.Italic);


            //    //set the font to the item
            //    lviUser.Font = new System.Drawing.Font(lviUser.Font, FontStyle.Regular);

            //    lviUser.SubItems.Add(user.department.ToString());
            //    lviUser.SubItems.Add(user.position != null ? user.position.ToString() : "");
            //    lviUser.SubItems.Add(user.userName.ToString());
            //    //lviUser.SubItems.Add(user.pass.ToString());
            //    lviUser.SubItems.Add(user.name.ToString());
            //    lviUser.SubItems.Add(user.Email.ToString());
            //    lviUser.SubItems.Add(user.userType.ToString());                   
            //    lviUser.SubItems.Add(user.Active == 1 ? "true".ToString() : "false".ToString());
            //    lviUser.SubItems.Add(Convert.ToInt32(user.DefaultProject) == 1 ? "Al Yamama" : (user.DefaultProject) == 2 ? "Sharma" : "");
            //    //lviUser.ImageIndex = user.Active == 1 ? 6 : 5;




            //    // lviUser.SubItems.Add(user.Active == 1 ? "truesign" : "falsesign");
            //    // lviUser.ImageKey = user.Active == 1 ? "truesign" : "falsesign";


            //    UserView.Items.Add(lviUser);
            //    i++;
            //}
            //showlbl.Text = "Displaying "+(i - 1)+" user(s)";
            ////}

            int i = 1;
            //int j = 1;
            int pageNr = (pgNrTbox.Text != "" ? Convert.ToInt32(pgNrTbox.Text) : 1);
            int totalRows = 0;
            int curRow = 0;

            UnivSource.connection.Open();
            System.Data.DataTable UserList = new System.Data.DataTable();
            DataSet ds = null;
            SqlDataAdapter da = null;

            using (SqlCommand cmd = new SqlCommand("[avitsql].[GetUserList]", UnivSource.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UserTypeString", SqlDbType.VarChar).Value = Util.UserTypeString;
                cmd.Parameters.Add("@DepartmentString", SqlDbType.VarChar).Value = Util.UserDepartmentString;
                cmd.Parameters.Add("@PositionString", SqlDbType.VarChar).Value = Util.UserPositionString;
                cmd.Parameters.Add("@NameString", SqlDbType.VarChar).Value = Util.UserNameString;
                cmd.Parameters.Add("@DefaultProjectString", SqlDbType.VarChar).Value = Util.UserDefaultProjectString;
                cmd.Parameters.Add("@PageNum", SqlDbType.Int).Value = pageNr; // Util.pageNum;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = Util.pageSizeUser;
                cmd.Parameters.Add("@Order", SqlDbType.VarChar).Value = Util.OrderUser;
                cmd.Parameters.Add("@Cols", SqlDbType.VarChar).Value = Util.ColsUser;

                cmd.ExecuteNonQuery();

                using (da = new SqlDataAdapter(cmd))
                {
                    ds = new DataSet();
                    da.Fill(ds);

                }

                UserList = ds.Tables["Table"];
                totalRows = (from DataRow dr in UserList.Rows
                             select (int)dr["Total_Rows_Count"]).FirstOrDefault();

                //int r = 1;

                foreach (DataRow row in UserList.Rows)
                {
                    ListViewItem lviUser = new ListViewItem(row["Id"].ToString());

                    curRow = Convert.ToInt32(row["RowNum"].ToString());

                    //set the font to the item
                    lviUser.Font = new System.Drawing.Font(lviUser.Font, FontStyle.Regular);

                    if (pgNrTbox.Text == "")
                        pgNrTbox.Text = "1";

                    if ((pageNr == 1 && i < (32 * pageNr + 1)) || (pageNr > 1 && i > (32 * (pageNr - 1)) && i <= (32 * pageNr)))
                    {

                        lviUser.SubItems.Add(row["Name"].ToString());
                        lviUser.SubItems.Add(row["Department"].ToString() != null ? row["Department"].ToString() : "");
                        lviUser.SubItems.Add(row["Position"].ToString() != null ? row["Position"].ToString() : "");
                        lviUser.SubItems.Add(row["UserName"].ToString());
                        lviUser.SubItems.Add(row["Email"].ToString() != null ? row["Email"].ToString() : "");
                        lviUser.SubItems.Add(row["UserType"].ToString() != null ? row["UserType"].ToString() : "");
                        lviUser.SubItems.Add(row["Active"].ToString() != null ? row["Active"].ToString() : "");
                        lviUser.SubItems.Add(row["DefaultProject"].ToString() != null ? (Convert.ToInt32(row["DefaultProject"]) == 1 ? "Al Yamama" : "Sharma"): "");
                        UserView.Items.Add(lviUser);
                       
                    }
                    i++;
                }
                // showlbl.Text = "Displaying " + (i - 1) + " user(s)";
                int itemsPerLastPage = 0;
                int lastPage = 0;


                totalPageslbl.Text = (totalRows % 32) == 0 ? (totalRows / 32).ToString() : ((totalRows / 32) + 1).ToString();
                lastPage = (totalRows % 32) == 0 ? (totalRows / 32) : ((totalRows / 32) + 1);
                itemsPerLastPage = totalRows % 32;
                if (pageNr < lastPage)
                    showlbl.Text = "Displaying 32 item(s) of " + totalRows;
                if (pageNr == lastPage || totalRows == 0)
                    showlbl.Text = "Displaying " + itemsPerLastPage + "  user(s) of " + totalRows;

                UnivSource.connection.Close();

                
            }

            //showlbl.Text = "Displaying " + (i - 1) + " user(s)";
           
        }           


        private void UserView_DoubleClick(object sender, EventArgs e)
        {
            Util.newUser = false;
            if (UserView.SelectedItems.Count > 0)
            {
                int userId = Convert.ToInt32(UserView.SelectedItems[0].SubItems[0].Text);
                var query = from x in pd.Users
                            join xy in pd.UserRoles on x.id equals xy.UserID into userRole
                            from userRoleResult in userRole.DefaultIfEmpty()
                            join xyz in pd.Roles on userRoleResult.RoleID equals xyz.Id into Roles
                            from RoleResult in Roles.DefaultIfEmpty()
                           
                            where x.id == userId 

                            select new
                            {
                                id = x.id,
                                userType = x.userType,
                                DefaultProject = x.DefaultProject,
                                department = x.department,
                                position = x.position,
                                userName = x.userName,
                                Password = x.Password,
                                name = x.name,
                                Email = x.Email,
                                Active = x.Active,
                                Role = RoleResult.Description
                            };

                foreach (var x in query)
                {
                    Util.userId = x.id;
                    Util.userType = x.userType;
                    Util.userProject = x.DefaultProject.ToString();
                    Util.department = x.department;
                    Util.position = x.position;
                    Util.user = x.userName;
                    Util.pass = x.Password;
                    Util.name = x.name;
                    Util.Email = x.Email;
                    Util.active = x.Active != null ? (int)x.Active : 0;
                    Util.userRole = x.Role;
                }
            }

            UserEdit form = new UserEdit();
            form.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
            form.ShowDialog();
        }

        void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed
            // //IntTrackerView.Items.Clear();
            // Refresh(sender, e);

            if (Util.newUser != true)
            {
                this.Dispose();
                Users form = new Users();
                form.ShowDialog();
                form.BringToFront();
            }
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            Util.userId = 0;
            Util.userType = "";
            Util.userProject = "";
            Util.department = "";
            Util.position = "";
            Util.user = "";
            Util.pass = "";
            Util.name = "";
            Util.Email = "";
            Util.active = 1;

            Util.newUser = true;
            UserEdit form = new UserEdit();
            form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed
            form.ShowDialog();                             
        }
        void child_FormClosedRefresh(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed
            UserView.Items.Clear();
            Users_Load(sender, e);
            //Refresh(sender, e);
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            //IntTracker_Load(sender, e);
            UserView.Items.Clear();
            Refresh(sender, e);
        }
        public void Refresh(object sender, EventArgs e)
        {
            Users_Load(sender, e);
        }

        private void IntTrackerView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            //if (e.ColumnIndex == 0)
            //{
            //    e.DrawBackground();
            //    bool value = false;
            //    try
            //    {
            //        value = Convert.ToBoolean(e.Header.Tag);
            //    }
            //    catch (Exception)
            //    {
            //    }
            //    CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
            //        value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
            //        System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            //}
            //else
            //{
            //    e.DrawDefault = true;
            //}
        }

        private void IntTrackerView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            //e.DrawDefault = true;
        }

        private void IntTrackerView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            //e.DrawDefault = true;
        }

        private void IntTrackerView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //if (checkedListBox1.Visible == false)
            //checkedListBox1.Show();
            //if (checkedListBox1.Visible == true)
            //    checkedListBox1.Hide();
            //contextMenuStrip2.Show();
            //// if (e.Column == 0)
            // {
            //     bool value = false;
            //     try
            //     {
            //         value = Convert.ToBoolean(this.IntTrackerView.Columns[e.Column].Tag);
            //     }
            //     catch (Exception)
            //     {
            //     }
            //     this.IntTrackerView.Columns[e.Column].Tag = !value;
            //     foreach (ListViewItem item in this.IntTrackerView.Items)
            //         item.Checked = !value;

            //     this.IntTrackerView.Invalidate();
            // }

        }

        

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
           


            // handle the event for the selected ListViewItem accessing it by
            // ListViewItem selected_lvi = this.lviIntTrack.SelectedItem as ListViewItem;
            //if (e.Button == MouseButtons.Right)
            //{
            //    if (listView1.FocusedItem != null && listView1.FocusedItem.Bounds.Contains(e.Location) == true)
            //    {
            //        ContextMenu m = new ContextMenu();
            //        MenuItem cashMenuItem = new MenuItem("編輯");
            //        cashMenuItem.Click += delegate (object sender2, EventArgs e2) {
            //            ActionClick(sender, e, id);
            //        };// your action here 
            //        m.MenuItems.Add(cashMenuItem);

            //        MenuItem cashMenuItem2 = new MenuItem("-");
            //        m.MenuItems.Add(cashMenuItem2);

            //        MenuItem delMenuItem = new MenuItem("刪除");
            //        delMenuItem.Click += delegate (object sender2, EventArgs e2) {
            //            DelectAction(sender, e, id);
            //        };// your action here
            //        m.MenuItems.Add(delMenuItem);

            //        m.Show(listView1, new Point(e.X, e.Y));

            //    }
            //}
        }

      

        private void IntTracker_Load_1(object sender, EventArgs e)
        {
            
        }      
           

         public void Reset()
        {
            List<string> statusFilterListsReset = new List<string>();
            //Util.statusFilterLists = statusFilterListsReset;
            Util.StatusString = "";
            Util.LocationString = "";
            Util.DateCreatedIn = "";
            Util.DateCreatedOut = "";
            Util.ReportedByString = "";
            Util.PriorityString = "";
            Util.DepartmentRefString = "";
            Util.AssignedToString = "";
            Util.EscalatedToString = "";
            Util.DepartmentEsomString = "";
            Util.ReportDateIn = "";
            Util.ReportDateOut = "";   ///to continue        
        }

        private void ResetFilterbtn_Click(object sender, EventArgs e)
        {
            Reset();
            Users_Load(sender, e);
        }
             
        private void SearchApplybtn_Click(object sender, EventArgs e)
        {
            //if (SearchTBox.Text != String.Empty)
            //{
            //    UserView.Items.Clear();
            //    string searchText = SearchTBox.Text.ToString();
            //    string searchOption = SearchcBox.Text.ToString();            

            //    UnivSource.connection.Open();
            //    System.Data.DataTable TrackList = new System.Data.DataTable();
            //    DataSet ds = null;
            //    SqlDataAdapter da = null;

            //    using (SqlCommand cmd = new SqlCommand("GetSearchString", UnivSource.connection))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;

            //        cmd.Parameters.Add("@SearchString", SqlDbType.VarChar).Value = searchText;
            //        cmd.Parameters.Add("@SearchOption", SqlDbType.VarChar).Value = searchOption;                 

            //        cmd.ExecuteNonQuery();

            //        using (da = new SqlDataAdapter(cmd))
            //        {
            //            ds = new DataSet();
            //            da.Fill(ds);

            //        }

            //        TrackList = ds.Tables["Table"];

            //        int i = 1;
            //        foreach (DataRow row in TrackList.Rows)
            //        {
            //            ListViewItem lviIntTrack = new ListViewItem(row["TrackId"].ToString());

            //            //set the font to the item
            //            lviIntTrack.Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);

            //            lviIntTrack.SubItems.Add(row["Type"].ToString() != null ? row["Type"].ToString() : "");
            //            lviIntTrack.SubItems.Add(row["Status"].ToString());
            //            lviIntTrack.SubItems.Add(row["Priority"].ToString());
            //            lviIntTrack.SubItems.Add(row["IssueDescription"].ToString());
            //            lviIntTrack.SubItems.Add(row["Location"].ToString());
            //            lviIntTrack.SubItems.Add(row["DateCreated"].ToString() != null ? row["DateCreated"].ToString() : "");//DateTime.Parse(track.DateCreated.ToString()).ToShortDateString()

            //            //lviIntTrack.SubItems.Add(track.DateReceived.ToString()); // DateTime.Parse(track.DateReceived.ToString()).ToShortDateString());
            //            lviIntTrack.SubItems.Add(row["ReportedBy"].ToString());
            //            lviIntTrack.SubItems.Add(row["DepartmentRef"].ToString());
            //            lviIntTrack.SubItems.Add(row["DepartmentInternal"].ToString() != null ? row["DepartmentInternal"].ToString() : "");
            //            lviIntTrack.SubItems.Add(row["AssignedTo"].ToString());
            //            lviIntTrack.SubItems.Add(row["EscalatedTo"].ToString());
            //            lviIntTrack.SubItems.Add(row["EscalationComments"].ToString());
            //            lviIntTrack.SubItems.Add(row["EscalCompletedBy"].ToString());
            //            lviIntTrack.SubItems.Add(row["EscalationStartDate"].ToString());
            //            lviIntTrack.SubItems.Add(row["Manager"].ToString());
            //            lviIntTrack.SubItems.Add(row["TechnicianAssigned"].ToString());
            //            lviIntTrack.SubItems.Add(row["EscalationComplDate"].ToString());

            //            lviIntTrack.SubItems.Add(row["DepartmentEsom"].ToString());
            //            lviIntTrack.SubItems.Add(row["EsomRef"].ToString());
            //            lviIntTrack.SubItems.Add(row["ReportDate"].ToString());   /// DateTime.Parse(track.ReportDate.ToString()).ToShortDateString());

            //            lviIntTrack.SubItems.Add(row["ClosingComment"].ToString());
            //            lviIntTrack.SubItems.Add(row["ClosedBy"].ToString() != null ? row["ClosedBy"].ToString() : "");
            //            lviIntTrack.SubItems.Add(row["ClosingDate"].ToString() != null ? row["ClosingDate"].ToString() : "");//DateTime.Parse(track.InspectionDate.ToString()).ToShortDateString()
            //            lviIntTrack.SubItems.Add(row["FollowUp"].ToString());

            //            UserView.Items.Add(lviIntTrack);
            //            i++;
            //        }
            //        showlbl.Text = "Displaying " + (i - 1) + " item(s)";

            //        UnivSource.connection.Close();
            //}


            //var tracks = (from x in pd.GetSearchString(searchText, searchOption)
            //              select x).OrderBy(v => (int)v.TrackId);

            //int i = 1;
            //foreach (var track in tracks)
            //{
            //    ListViewItem lviIntTrack = new ListViewItem(track.TrackId.ToString());
            //    ///set the font to the item
            //    lviIntTrack.Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);

            //    lviIntTrack.SubItems.Add(track.Type != null ? track.Type.ToString() : "");
            //    lviIntTrack.SubItems.Add(track.Status.ToString());
            //    lviIntTrack.SubItems.Add(track.Priority.ToString());
            //    lviIntTrack.SubItems.Add(track.IssueDescription.ToString());
            //    lviIntTrack.SubItems.Add(track.Location.ToString());
            //    lviIntTrack.SubItems.Add(track.DateCreated != null ? track.DateCreated.ToString() : "");// DateTime.Parse(track.DateCreated.ToString()).ToShortDateString()

            //   // lviIntTrack.SubItems.Add(DateTime.Parse(track.DateReceived.ToString()).ToShortDateString());
            //    lviIntTrack.SubItems.Add(track.ReportedBy.ToString());
            //    lviIntTrack.SubItems.Add(track.DepartmentRef.ToString());
            //    lviIntTrack.SubItems.Add(track.DepartmentInternal != null ? track.DepartmentInternal.ToString() : "");
            //    // lviIntTrack.SubItems.Add(track.AssignedTo.ToString());

            //    lviIntTrack.SubItems.Add(track.EscalatedTo.ToString());

            //    lviIntTrack.SubItems.Add(track.DepartmentEsom.ToString());
            //    lviIntTrack.SubItems.Add(track.EsomRef.ToString());
            //    lviIntTrack.SubItems.Add(DateTime.Parse(track.ReportDate.ToString()).ToShortDateString());

            //    lviIntTrack.SubItems.Add(track.ClosingComment.ToString());
            //    lviIntTrack.SubItems.Add(track.ClosedBy != null ? track.ClosedBy.ToString() : "");
            //    lviIntTrack.SubItems.Add(track.InspectionDate != null ? track.InspectionDate.ToString() : ""); //DateTime.Parse(track.InspectionDate.ToString()).ToShortDateString()
            //    lviIntTrack.SubItems.Add(track.FollowUp.ToString());

            //    IntTrackerView.Items.Add(lviIntTrack);
            //    i++;
            //}
            //showlbl.Text = "Displaying " + (i - 1) + " item(s)";       
            //}
        }

        private void ClearSearchBtn_Click(object sender, EventArgs e)
        {
            SearchcBox.SelectedIndex = 0;
            SearchTBox.Text = "";
            Refresh(sender, e);
        }

        private void Statisticsbtn_Click(object sender, EventArgs e)
        {
            //Statistics form = new Statistics();
            //form.ShowDialog();
        }

        private void internalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Util.trackId = 0;
            //Util.RecordType = "";
            //Util.status = "";
            //Util.issueDesc = "";
            //Util.location = "";
            //Util.dateReceived = "";
            //Util.reportedBy = "";
            //Util.priority = "";
            //Util.departmentRef = "";
            //Util.assignedTo = "";
            //Util.escalatedTo = "";
            //Util.departmentEsom = "";
            //Util.departmentInternal = "";
            //Util.esomRef = "";
            //Util.reportDate = "";
            //Util.closingComment = "";
            //Util.followUp = "";
            //Util.dateCreated = "";
            //Util.closedBy = "";
            //Util.ClosingDate = "";
            //Util.RecordType = "";
            //Util.EscalComm = "";
            //Util.EscalCompBy = "";
            //Util.EscalStartDate = "";
            //Util.Manager = "";
            //Util.TechnicianAssigned = "";
            //Util.EscalComplDate = "";

            //Util.newItem = true;
            //Util.RecordType = "Internal";           

            //InternalRecord form = new InternalRecord();
            //form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed
            //form.ShowDialog();
        }


        private void PDFExportbtn_Click(object sender, EventArgs e)
        {
            //string fileName = "C:\\Users\\Local Admin\\Hill Robinson\\Project Bianca - Shared\\Technical\\TaskAlocation\\Int Track List  - " + DateTime.Now.Date.ToShortDateString().Replace("/", ".") + ".pdf".ToString();
            //FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);           

            //iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A3.Rotate());
            //Document doc = new Document(rec);
            //PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            //doc.Open();

            //TechIntTracker dp = new TechIntTracker();
            //var tracks = (from x in pd.TechIntTrackers
            //             select x).OrderByDescending(v => v.TrackId);
            //PdfPTable table = new PdfPTable(8);
            //PdfPCell cell = new PdfPCell(new Phrase("Int Track List  - " + DateTime.Now.Date.ToShortDateString().Replace("/", ".").ToString()));

            //cell.Colspan = 8;

            ////cell.VerticalAlignment = 1;
            //cell.FixedHeight = 35f;
            //table.WidthPercentage = 100;
            //table.SetWidths(new[] { 5f, 5f, 5f, 8f, 25f, 20f, 10f, 15f });
            //cell.HorizontalAlignment = 1; // 0=left, 1= centre, 2= right
            //cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            //table.AddCell(cell);

            //table.AddCell(new PdfPCell(new Phrase(("Track Id"))) { FixedHeight = 35, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_MIDDLE });
            //table.AddCell(new PdfPCell(new Phrase(("Type"))) { FixedHeight = 35, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            //table.AddCell(new PdfPCell(new Phrase(("Status"))) { FixedHeight = 35, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            //table.AddCell(new PdfPCell(new Phrase(("Priority"))) { HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            //table.AddCell(new PdfPCell(new Phrase(("Issue Description"))) { HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            //table.AddCell(new PdfPCell(new Phrase(("Location"))) { FixedHeight = 35, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            //table.AddCell(new PdfPCell(new Phrase(("DateCreated"))) { FixedHeight = 35, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            //table.AddCell(new PdfPCell(new Phrase(("ReportedBy"))) { FixedHeight = 35, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });



            //foreach (var track in tracks)
            //{                
            //    table.AddCell(new PdfPCell(new Phrase((track.TrackId.ToString()))) { MinimumHeight = 25, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_MIDDLE });
            //    table.AddCell(new PdfPCell(new Phrase((track.Type))) { MinimumHeight = 25, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_MIDDLE });
            //    table.AddCell(new PdfPCell(new Phrase((track.Status))) { MinimumHeight = 25, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            //    table.AddCell(new PdfPCell(new Phrase((track.Priority))) { MinimumHeight = 25, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            //    table.AddCell(new PdfPCell(new Phrase((track.IssueDescription))) { MinimumHeight = 25, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            //    table.AddCell(new PdfPCell(new Phrase((track.Location))) { MinimumHeight = 25, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            //    table.AddCell(new PdfPCell(new Phrase((track.DateCreated.ToString()))) { MinimumHeight = 25, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            //    table.AddCell(new PdfPCell(new Phrase((track.ReportedBy))) { MinimumHeight = 25, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });

            //}





            //doc.Add(table);

            //doc.Close();
        }

        private void ExportXlsbtn_Click(object sender, EventArgs e)
        {
            //Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //excel.Visible = true;
            //Microsoft.Office.Interop.Excel.Workbook wBook = excel.Workbooks.Add(1);
            //Microsoft.Office.Interop.Excel.Worksheet wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.Worksheets[1];
            //DataSet dset = new DataSet();
            //dset.Tables.Add();

            //int i = 1;
            //int i2 = 2;
            //int x = 1;
            //int x2 = 1;
            //int colNum = UserView.Columns.Count;

            //// Set first ROW as Column Headers Text
            //foreach (ColumnHeader ch in UserView.Columns)
            //{
            //    x++;
            //    wSheet.Cells[x2, x] = ch.Text;
            //    //x++;
            //}

            //foreach (ListViewItem lvi in UserView.Items)
            //{
            //    i = 1;
            //    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
            //    {
            //        i++;
            //        wSheet.Cells[i2, i] = lvs.Text;
            //        //i++;
            //    }
            //    i2++;
            //}

            //// AutoSet Cell Widths to Content Size
            //wSheet.Cells.Select();
            //wSheet.Cells.EntireColumn.AutoFit();
            //wSheet.Columns.AutoFit();

            //Range line = (Range)wSheet.Rows[1];
            //line.Insert(); 
            //string date = DateTime.Today.ToShortDateString().Replace("/", ".");//.Replace(":", ".");
            //wBook.SaveAs(@"C:\Users\Local Admin\Hill Robinson\Project Bianca - Shared\Technical\TaskAlocation\Int Track List  - " + date + ".xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing);
        }

        private void Delbtn_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbSession.Text = Util.currentSession;
        }
        
        private void UserView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (UserView.SelectedItems.Count > 0)
                {
                    //DeleteUsermenuStrip.Items[0].Visible = true;
                    ////if (IntTrackerView.FocusedItem.Bounds.Contains(e.Location))
                    //{
                    //    System.Drawing.Point point = new System.Drawing.Point(this.Location.X + UserView.Location.X + e.X + 20,
                    //    this.Location.Y + UserView.Location.Y + e.Y);
                    //    //DeleteUsermenuStrip.Show(point);
                    //}
                }
            }
        }

        private void DeleteUsermenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            MessageBox.Show("Under development");
        }

        public void quickFilterOption()
        {            
            //add
            if (TechnicalcBox.Checked == true  && !Util.UserDepartmentString.Contains("Technical"))
                Util.UserDepartmentString += ", Technical";
            if (HKckBox.Checked == true  && !Util.UserDepartmentString.Contains("Housekeeping"))
                Util.UserDepartmentString += ", Housekeeping";
            if (FBcBox.Checked == true && !Util.UserDepartmentString.Contains("F&B"))
                Util.UserDepartmentString += ", F&B";
            if (cBoxProcurement.Checked == true  && !Util.UserDepartmentString.Contains("Procurement"))
                Util.UserDepartmentString += ", Procurement";
            if (cBoxCulinary.Checked == true && !Util.UserDepartmentString.Contains("Culinary"))
                Util.UserDepartmentString += ", Culinary";
                    

            //last comma ??

            //remove
            if (TechnicalcBox.Checked == false  && Util.UserDepartmentString != String.Empty)
                Util.UserDepartmentString = Util.UserDepartmentString.Contains("Technical, ") ? Util.UserDepartmentString.Replace("Technical, ", "") : Util.UserDepartmentString.Replace("Technical", "");

            if (HKckBox.Checked == false  && Util.UserDepartmentString != String.Empty)
                Util.UserDepartmentString = Util.UserDepartmentString.Contains("Housekeeping, ") ? Util.UserDepartmentString.Replace("Housekeeping, ", "") : Util.UserDepartmentString.Replace("Housekeeping", "");

            if (FBcBox.Checked == false  && Util.UserDepartmentString != String.Empty)
                Util.UserDepartmentString = Util.UserDepartmentString.Contains("F&B, ") ? Util.UserDepartmentString.Replace("F&B, ", "") : Util.UserDepartmentString.Replace("F&B", "");

            if (cBoxProcurement.Checked == false  && Util.UserDepartmentString != String.Empty)
                Util.UserDepartmentString = Util.UserDepartmentString.Contains("Procurement, ") ? Util.UserDepartmentString.Replace("Procurement, ", "") : Util.UserDepartmentString.Replace("Procurement", "");

            if (cBoxCulinary.Checked == false  && Util.UserDepartmentString != String.Empty)
                Util.UserDepartmentString = Util.UserDepartmentString.Contains("Culinary, ") ? Util.UserDepartmentString.Replace("Culinary, ", "") : Util.UserDepartmentString.Replace("Culinary", "");

          
            //pgNrTbox.Text = "1";                    
           

            if (Util.UserDepartmentString == string.Empty)
                Util.UserDepartmentString = "0".ToString();

            SelectUser(UserView);

            if (TechnicalcBox.Checked == true && HKckBox.Checked == true && FBcBox.Checked == true &&
                cBoxProcurement.Checked == true && cBoxCulinary.Checked == true && !cBoxAll.Checked)
            
                cBoxAll.Checked = true;
               
             if (TechnicalcBox.Checked == false || HKckBox.Checked == false || FBcBox.Checked == false ||
                cBoxProcurement.Checked == false || cBoxCulinary.Checked == false)
            
                cBoxAll.Checked = false;              
        }

        private void HKckBox_CheckedChanged(object sender, EventArgs e)
        {
            quickFilterOption();
        }

        private void FBcBox_CheckedChanged(object sender, EventArgs e)
        {
            quickFilterOption();
        }

        private void cBoxProcurement_CheckedChanged(object sender, EventArgs e)
        {
            quickFilterOption();
        }

        private void cBoxCulinary_CheckedChanged(object sender, EventArgs e)
        {
            quickFilterOption();
        }

        private void TechnicalcBox_CheckedChanged(object sender, EventArgs e)
        {
            quickFilterOption();
        }

        private void cBoxAll_Click(object sender, EventArgs e)
        {
            if (cBoxAll.Checked == true)
            {
                if (!TechnicalcBox.Checked)
                    TechnicalcBox.Checked = true;
                if (!HKckBox.Checked)
                    HKckBox.Checked = true;
                if (!FBcBox.Checked)
                    FBcBox.Checked = true;
                if (!cBoxProcurement.Checked)
                    cBoxProcurement.Checked = true;
                if (!cBoxCulinary.Checked)
                    cBoxCulinary.Checked = true;

            }
            if (cBoxAll.Checked == false)
            {
                if (TechnicalcBox.Checked)
                    TechnicalcBox.Checked = false;
                if (HKckBox.Checked)
                    HKckBox.Checked = false;
                if (FBcBox.Checked)
                    FBcBox.Checked = false;
                if (cBoxProcurement.Checked)
                    cBoxProcurement.Checked = false;
                if (cBoxCulinary.Checked)
                    cBoxCulinary.Checked = false;
            }
            SelectUser(UserView);
        }

        private void firstLbl_Click(object sender, EventArgs e)
        {
            pgNrTbox.Text = "1";
            SelectUser(UserView);
        }

        private void lastLbl_Click(object sender, EventArgs e)
        {
            pgNrTbox.Text = totalPageslbl.Text;
            SelectUser(UserView);
        }

        private void nextLbl_Click(object sender, EventArgs e)
        {
            pgNrTbox.Text = Convert.ToInt32(pgNrTbox.Text) < Convert.ToInt32(totalPageslbl.Text) ? (Convert.ToInt32(pgNrTbox.Text) + 1).ToString() : pgNrTbox.Text;
            SelectUser(UserView);
        }

        private void prevLbl_Click(object sender, EventArgs e)
        {
            pgNrTbox.Text = Convert.ToInt32(pgNrTbox.Text) > 1 ? (Convert.ToInt32(pgNrTbox.Text) - 1).ToString() : pgNrTbox.Text;
            SelectUser(UserView);
        }
    }
}
