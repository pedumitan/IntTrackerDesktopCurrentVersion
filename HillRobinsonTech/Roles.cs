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
    public partial class Roles : Form
    {
        TechDboDataContext pd = new TechDboDataContext();
        ImageList Imagelist = new ImageList();

        public Roles()
        {
            InitializeComponent();
            RoleView.FullRowSelect = true;
            RoleView.GridLines = true;
            RoleView.View = View.Details;
            //RoleView.Items.Add(new ListViewItem() { ImageIndex = 0 });
            this.CenterToScreen();
            Util.persAccount = false;
           // this.WindowState = FormWindowState.Maximized;
            CustomizeRoleView(RoleView);   
        }

       

        private void Roles_Load(object sender, EventArgs e)
        {
            SelectRole(RoleView);
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

        private void Roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void CustomizeRoleView(ListView RoleView)
        {
            this.RoleView.View = View.Details;
            this.RoleView.FullRowSelect = true;
            //Task Description
            this.RoleView.Columns.Add("Id");
            this.RoleView.Columns.Add("Name");
            this.RoleView.Columns.Add("Description");
            //this.RoleView.Columns.Add("Position");
            //this.RoleView.Columns.Add("User");
            //this.RoleView.Columns.Add("Password");
            
            //this.RoleView.Columns.Add("Email");
            //this.RoleView.Columns.Add("Type");
            //this.RoleView.Columns.Add("Active");
            //this.RoleView.Columns.Add("Default project");

            ResizeListViewColumns(this.RoleView);
        }

        public void ResizeListViewColumns(ListView RoleView)
        {
            foreach (ColumnHeader column in RoleView.Columns)
            {
                column.Width = -2;
            }
        }
    
        public void SelectRole(ListView RoleView)
        {
            RoleView.Items.Clear();           

            if (!Util.FilterUsed)
            {

                var roles = (from x in pd.Roles
                            // where x.DeletedUser == 0 || x.DeletedUser == null
                              select x).OrderBy(v => (int)v.Id);//OrderByDescending


                int i = 1;
                foreach (var role in roles)
                {
                    ListViewItem lviRole = new ListViewItem(role.Id.ToString());
                    ////set the font to the item
                    //lviIntTrack.Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);

                    //lviIntTrack.
                    //if (li.Text = "Sample")
                    //{
                    //    li.ForeColor = Color.Green;
                    //}
                    //lviIntTrack.BackColor = Color.Azure; -- colors the table background

                    //lviIntTrack.UseItemStyleForSubItems = false;

                    //lviIntTrack.SubItems.Add(track.Type != null ? track.Type.ToString() : "").ForeColor = System.Drawing.Color.Red;

                    //lviIntTrack.UseItemStyleForSubItems = true;

                    //// Change the expenseItem object's color and font.
                    //tracks.ForeColor = System.Drawing.Color.Red;
                    //expenseItem.Font = new System.Drawing.Font(
                    //    "Arial", 10, System.Drawing.FontStyle.Italic);


                    //set the font to the item
                    lviRole.Font = new System.Drawing.Font(lviRole.Font, FontStyle.Regular);

                    //lviUser.SubItems.Add(user.department.ToString());
                    //lviUser.SubItems.Add(user.position != null ? user.position.ToString() : "");
                    //lviUser.SubItems.Add(user.userName.ToString());
                    //lviUser.SubItems.Add(user.pass.ToString());
                    lviRole.SubItems.Add(role.Name.ToString());
                    lviRole.SubItems.Add(role.Description.ToString());
                    //lviUser.SubItems.Add(user.Email.ToString());
                    //lviUser.SubItems.Add(user.userType.ToString());                   
                    //lviUser.SubItems.Add(user.Active == 1 ? "true".ToString() : "false".ToString());
                    //lviUser.SubItems.Add(Convert.ToInt32(user.DefaultProject) == 1 ? "Al Yamama" : (user.DefaultProject) == 2 ? "Sharma" : "");
                    //lviUser.ImageIndex = user.Active == 1 ? 6 : 5;




                    // lviUser.SubItems.Add(user.Active == 1 ? "truesign" : "falsesign");
                    // lviUser.ImageKey = user.Active == 1 ? "truesign" : "falsesign";


                    RoleView.Items.Add(lviRole);
                    i++;
                }
                showlbl.Text = "Displaying "+(i - 1)+" role(s)";
            }


            //if (Util.FilterUsed)
            //{
            //    Util.DateReceivedIn = Util.DateReceivedIn != "" ? DateTime.Parse(Util.DateReceivedIn).ToString("yyyy-MM-dd") : Util.DateReceivedIn;
            //    Util.DateReceivedOut = Util.DateReceivedOut != "" ? DateTime.Parse(Util.DateReceivedOut).ToString("yyyy-MM-dd") : Util.DateReceivedOut;
            //    Util.ReportDateIn = Util.ReportDateIn != "" ? DateTime.Parse(Util.ReportDateIn).ToString("yyyy-MM-dd") : Util.ReportDateIn;
            //    Util.ReportDateOut = Util.ReportDateOut != "" ? DateTime.Parse(Util.ReportDateOut).ToString("yyyy-MM-dd") : Util.ReportDateOut;

            //    UnivSource.connection.Open();
            //    System.Data.DataTable TrackList = new System.Data.DataTable();
            //    DataSet ds = null;
            //    SqlDataAdapter da = null;

            //    using (SqlCommand cmd = new SqlCommand("GetData", UnivSource.connection))
            //        {
            //            cmd.CommandType = CommandType.StoredProcedure;

            //            cmd.Parameters.Add("@StatusString", SqlDbType.VarChar).Value = Util.StatusString;
            //            cmd.Parameters.Add("@LocationString", SqlDbType.VarChar).Value = Util.LocationString;
            //            cmd.Parameters.Add("@DateReceivedIn", SqlDbType.VarChar).Value = Util.DateReceivedIn;
            //            cmd.Parameters.Add("@ReportedByString", SqlDbType.VarChar).Value = Util.ReportedByString;
            //            cmd.Parameters.Add("@PriorityString", SqlDbType.VarChar).Value = Util.PriorityString;
            //            cmd.Parameters.Add("@DepartmentRefString", SqlDbType.VarChar).Value = Util.DepartmentRefString;
            //            cmd.Parameters.Add("@AssignedToString", SqlDbType.VarChar).Value = Util.AssignedToString;
            //            cmd.Parameters.Add("@EscalatedToString", SqlDbType.VarChar).Value = Util.EscalatedToString;
            //            cmd.Parameters.Add("@DepartmentEsomString", SqlDbType.VarChar).Value = Util.DepartmentEsomString;
            //            cmd.Parameters.Add("@ReportDateIn", SqlDbType.VarChar).Value = Util.ReportDateIn;
            //            cmd.Parameters.Add("@ReportDateOut", SqlDbType.VarChar).Value = Util.ReportDateOut;                    

            //            cmd.ExecuteNonQuery();

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

            //            IntTrackerView.Items.Add(lviIntTrack);
            //            i++;
            //        }
            //        showlbl.Text = "Displaying " + (i - 1) + " item(s)";                  

            //        UnivSource.connection.Close();
            //    }


            //var tracks = (from x in  pd.GetData(Util.StatusString, Util.LocationString, Util.DateReceivedIn, Util.DateReceivedOut, Util.ReportedByString, Util.PriorityString, Util.DepartmentRefString, Util.AssignedToString, Util.EscalatedToString, Util.DepartmentEsomString, Util.ReportDateIn, Util.ReportDateOut)

            //              select x).OrderBy(v => (int)v.TrackId);

            //int i = 1;
            //foreach (var track in tracks)
            //{
            //    ListViewItem lviIntTrack = new ListViewItem(track.TrackId.ToString());
            ////set the font to the item
            //lviIntTrack.Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);

            //    lviIntTrack.SubItems.Add(track.Type != null ? track.Type.ToString() : "");
            //    lviIntTrack.SubItems.Add(track.Status.ToString());
            //    lviIntTrack.SubItems.Add(track.Priority.ToString());
            //    lviIntTrack.SubItems.Add(track.IssueDescription.ToString());
            //    lviIntTrack.SubItems.Add(track.Location.ToString());
            //    lviIntTrack.SubItems.Add(track.DateCreated != null ? track.DateCreated.ToString() : "");//DateTime.Parse(track.DateCreated.ToString()).ToShortDateString()

            //    //lviIntTrack.SubItems.Add(track.DateReceived.ToString()); // DateTime.Parse(track.DateReceived.ToString()).ToShortDateString());
            //    lviIntTrack.SubItems.Add(track.ReportedBy.ToString());
            //    lviIntTrack.SubItems.Add(track.DepartmentRef.ToString());
            //    lviIntTrack.SubItems.Add(track.DepartmentInternal != null ? track.DepartmentInternal.ToString() : "");
            //    // lviIntTrack.SubItems.Add(track.AssignedTo.ToString());
            //    lviIntTrack.SubItems.Add(track.EscalatedTo.ToString());
            //    lviIntTrack.SubItems.Add(track.EscalationComments.ToString());
            //    lviIntTrack.SubItems.Add(track.EscalCompletedBy.ToString());
            //    lviIntTrack.SubItems.Add(track.EscalationDate.ToString());

            //    lviIntTrack.SubItems.Add(track.DepartmentEsom.ToString());
            //    lviIntTrack.SubItems.Add(track.EsomRef.ToString());
            //    lviIntTrack.SubItems.Add(track.ReportDate.ToString());   /// DateTime.Parse(track.ReportDate.ToString()).ToShortDateString());

            //    lviIntTrack.SubItems.Add(track.ClosingComment.ToString());
            //    lviIntTrack.SubItems.Add(track.ClosedBy != null ? track.ClosedBy.ToString() : "");
            //    lviIntTrack.SubItems.Add(track.InspectionDate != null ? track.InspectionDate.ToString() : "");//DateTime.Parse(track.InspectionDate.ToString()).ToShortDateString()
            //    lviIntTrack.SubItems.Add(track.FollowUp.ToString());

            //    IntTrackerView.Items.Add(lviIntTrack);
            //    i++;
            //}
            //showlbl.Text = "Displaying " + (i - 1) + " item(s)";
            //}
        }


        private void RoleView_DoubleClick(object sender, EventArgs e)
        {
            //Util.newUser = false;
            if (RoleView.SelectedItems.Count > 0)
            {
                int roleId = Convert.ToInt32(RoleView.SelectedItems[0].SubItems[0].Text);
                var query = from x in pd.Roles
                            where x.Id == roleId

                            select new
                            {
                                x.Id,                               
                                x.Name,
                                x.Description                  
                            };

                foreach (var x in query)
                {
                    Util.roleId = x.Id;
                    Util.roleName = x.Name;
                    Util.roleDescription = x.Description;
                }
            }

            RoleEdit form = new RoleEdit();
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
                Roles form = new Roles();
                form.ShowDialog();
                form.BringToFront();
            }
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            //Util.userId = 0;
            //Util.userType = "";
            //Util.userProject = "";
            //Util.department = "";
            //Util.position = "";
            //Util.user = "";
            //Util.pass = "";
            //Util.name = "";
            //Util.Email = "";
            //Util.active = 1;

            //Util.newUser = true;
            //UserEdit form = new UserEdit();
            //form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed
            //form.ShowDialog();                             
        }
        void child_FormClosedRefresh(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed
            RoleView.Items.Clear();
            Roles_Load(sender, e);
            //Refresh(sender, e);
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            //IntTracker_Load(sender, e);
            RoleView.Items.Clear();
            Refresh(sender, e);
        }
        public void Refresh(object sender, EventArgs e)
        {
            Roles_Load(sender, e);
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
            Roles_Load(sender, e);
        }
             
        private void SearchApplybtn_Click(object sender, EventArgs e)
        {
            //if (SearchTBox.Text != String.Empty)
            //{
            //    RoleView.Items.Clear();
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

            //            RoleView.Items.Add(lviIntTrack);
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
            //int colNum = RoleView.Columns.Count;

            //// Set first ROW as Column Headers Text
            //foreach (ColumnHeader ch in RoleView.Columns)
            //{
            //    x++;
            //    wSheet.Cells[x2, x] = ch.Text;
            //    //x++;
            //}

            //foreach (ListViewItem lvi in RoleView.Items)
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
        
        private void RoleView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (RoleView.SelectedItems.Count > 0)
                {
                    //DeleteUsermenuStrip.Items[0].Visible = true;
                    ////if (IntTrackerView.FocusedItem.Bounds.Contains(e.Location))
                    //{
                    //    System.Drawing.Point point = new System.Drawing.Point(this.Location.X + RoleView.Location.X + e.X + 20,
                    //    this.Location.Y + RoleView.Location.Y + e.Y);
                    //    //DeleteUsermenuStrip.Show(point);
                    //}
                }
            }
        }

        private void DeleteUsermenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            MessageBox.Show("Under development");
        }
    }
}
