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
    public partial class Permissions : Form
    {
        TechDboDataContext pd = new TechDboDataContext();        

        public Permissions()
        {
            InitializeComponent();
            PermissionView.FullRowSelect = true;
            PermissionView.GridLines = true;
            PermissionView.View = View.Details;
            this.CenterToScreen();
           // this.WindowState = FormWindowState.Maximized;
            CustomizePermissionView(PermissionView);   
        }
            
        private void Permissions_Load(object sender, EventArgs e)
        {
            SelectPermission(PermissionView);
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

        public void CustomizePermissionView(ListView PermissionView)
        {
            this.PermissionView.View = View.Details;
            this.PermissionView.FullRowSelect = true;
            //Task Description
            this.PermissionView.Columns.Add("Id");           
            this.PermissionView.Columns.Add("Name");
            this.PermissionView.Columns.Add("Description");               

            ResizeListViewColumns(this.PermissionView);
        }

        public void ResizeListViewColumns(ListView IntTrackerView)
        {
            foreach (ColumnHeader column in IntTrackerView.Columns)
            {
                column.Width = -2;
            }
        }
    
        public void SelectPermission(ListView PermissionView)
        {
            PermissionView.Items.Clear();

            if (!Util.FilterUsed)
            {

                var permissions = (from x in pd.Permissions
                                  //TechIntTrackerTests
                              select x).OrderBy(v => (int)v.Id);//OrderByDescending


                int i = 1;
                foreach (var permission in permissions)
                {
                    ListViewItem lviPermission = new ListViewItem(permission.Id.ToString());
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
                    lviPermission.Font = new System.Drawing.Font(lviPermission.Font, FontStyle.Regular);   
                                  
                    lviPermission.SubItems.Add(permission.Name.ToString());
                    lviPermission.SubItems.Add(permission.Description.ToString());
                    //lviPermission.SubItems.Add(permission.userType.ToString());
                         

                    PermissionView.Items.Add(lviPermission);
                    i++;
                }
                showlbl.Text = "Displaying "+(i - 1)+" permission(s)";
            }
        
        }           


        private void PermissionView_DoubleClick(object sender, EventArgs e)
        {
            Util.newPermission = false;
            if (PermissionView.SelectedItems.Count > 0)
            {
                int Id = Convert.ToInt32(PermissionView.SelectedItems[0].SubItems[0].Text);
                var query = from x in pd.Permissions
                            where x.Id == Id

                            select new
                            {
                                x.Id,
                                x.Name,
                                x.Description
                                                              
                            };

                foreach (var x in query)
                {
                    Util.permissionId = x.Id;
                    Util.permissionName = x.Name;
                    Util.permissionDescription = x.Description;       
                }
            }

            PermissionEdit form = new PermissionEdit();
            form.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
            form.ShowDialog();
        }

        void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed
            // //IntTrackerView.Items.Clear();
            // Refresh(sender, e);

            if (Util.newPermission != true)
            {
                this.Dispose();
                Permissions form = new Permissions();
                form.ShowDialog();
                form.BringToFront();
            }
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            Util.permissionId = 0;
            Util.permissionName = "";
            Util.permissionDescription = "";

            Util.newPermission = true;
            PermissionEdit form = new PermissionEdit();
            form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed
            form.ShowDialog();                             
        }
        void child_FormClosedRefresh(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed
            PermissionView.Items.Clear();
            Permissions_Load(sender, e);
            //Refresh(sender, e);
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            //IntTracker_Load(sender, e);
            PermissionView.Items.Clear();
            Refresh(sender, e);
        }
        public void Refresh(object sender, EventArgs e)
        {
            Permissions_Load(sender, e);
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

        private void IntTrackerView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //if (PermissionView.SelectedItems.Count > 0 )
                //{
                //    if (PermissionView.SelectedItems[0].SubItems[1].Text == "Internal")
                //    {
                //        contextMenuStrip1.Items[0].Visible = true;
                //        contextMenuStrip1.Items[1].Visible = false;
                //    }
                //    if (PermissionView.SelectedItems[0].SubItems[1].Text == "Contractor")
                //    {
                //        contextMenuStrip1.Items[0].Visible = false;
                //        contextMenuStrip1.Items[1].Visible = true;
                //    }

                //    //if (IntTrackerView.FocusedItem.Bounds.Contains(e.Location))
                //    {
                //        System.Drawing.Point point = new System.Drawing.Point(this.Location.X + PermissionView.Location.X + e.X + 20,
                //        this.Location.Y + PermissionView.Location.Y + e.Y);
                //        contextMenuStrip1.Show(point);
                //    }
                //}
            }

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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (PermissionView.SelectedItems.Count > 0)
            {
                int trackId = Convert.ToInt32(PermissionView.SelectedItems[0].SubItems[0].Text);
                var query = from x in pd.TechIntTrackers
                                //TechIntTrackerTests
                            where x.TrackId == trackId

                            select new
                            {
                                x.TrackId,
                                x.Type,
                                x.Status,
                                x.IssueDescription,
                                x.Location,
                                x.DateCreated,
                               // x.DateReceived,
                                x.ReportedBy,
                                x.Priority,
                                x.DepartmentRef,
                                x.DepartmentInternal,
                                x.AssignedTo,
                                x.EscalatedTo,
                                x.EscalationComments,
                                x.EscalCompletedBy,
                                x.EscalationStartDate,
                                x.Manager,
                                x.TechnicianAssigned,
                                x.EscalationComplDate,
                                x.DepartmentEsom,
                                x.EsomRef,
                                x.ReportDate,
                                x.ClosingComment,
                                x.ClosedBy,
                                x.ClosingDate,
                                x.FollowUp

                            };

                foreach (var x in query)
                {  
                    Util.trackId = Convert.ToInt32(x.TrackId);
                    Util.RecordType = x.Type;
                    Util.status = x.Status;
                    Util.issueDesc = x.IssueDescription;
                    Util.location = x.Location;
                    Util.dateCreated = x.DateCreated.ToString();
                    //Util.dateReceived = x.DateReceived.ToString();
                    Util.reportedBy = x.ReportedBy;
                    Util.priority = x.Priority;
                    Util.departmentRef = x.DepartmentRef;
                    Util.departmentInternal = x.DepartmentInternal;
                    Util.assignedTo = x.AssignedTo;
                    Util.escalatedTo = x.EscalatedTo;
                    Util.EscalComm = x.EscalationComments;
                    Util.EscalCompBy = x.EscalCompletedBy;
                    Util.EscalStartDate = x.EscalationStartDate.ToString();
                    Util.Manager = x.Manager != null ? x.Manager.ToString() : "";
                    Util.TechnicianAssigned = x.TechnicianAssigned != null ? x.TechnicianAssigned.ToString() : "";
                    Util.EscalComplDate = x.EscalationComplDate.ToString();
                    Util.departmentEsom = x.DepartmentEsom;
                    Util.esomRef = x.EsomRef != null ? x.EsomRef.ToString() : "";
                    Util.reportDate = x.ReportDate.ToString();
                    Util.closingComment = x.ClosingComment;
                    Util.closedBy = x.ClosedBy;
                    Util.ClosingDate = x.ClosingDate.ToString();
                    Util.followUp = x.FollowUp;
                }
            }
            //ExportInternalToPDF form = new ExportInternalToPDF();
            //form.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (PermissionView.SelectedItems.Count > 0)
            {
                int trackId = Convert.ToInt32(PermissionView.SelectedItems[0].SubItems[0].Text);
                var query = from x in pd.TechIntTrackers
                            //TechIntTrackerTests
                            where x.TrackId == trackId

                            select new
                            {
                                x.TrackId,
                                x.Type,
                                x.Status,
                                x.IssueDescription,
                                x.Location,
                                x.DateCreated,
                                //x.DateReceived,
                                x.ReportedBy,
                                x.Priority,
                                x.DepartmentRef,
                                x.DepartmentInternal,
                                x.AssignedTo,
                                x.EscalatedTo,
                                x.EscalationComments,
                                x.EscalCompletedBy,
                                x.EscalationStartDate,
                                x.Manager,
                                x.TechnicianAssigned,
                                x.EscalationComplDate,
                                x.DepartmentEsom,
                                x.EsomRef,
                                x.ReportDate,
                                x.ClosingComment,
                                x.ClosedBy,
                                x.ClosingDate,
                                x.FollowUp

                            };

                foreach (var x in query)
                {
                    Util.trackId = Convert.ToInt32(x.TrackId);
                    Util.RecordType = x.Type;
                    Util.status = x.Status;
                    Util.issueDesc = x.IssueDescription;
                    Util.location = x.Location;
                    Util.dateCreated = x.DateCreated.ToString();
                    //Util.dateReceived = x.DateReceived.ToString();
                    Util.reportedBy = x.ReportedBy;
                    Util.priority = x.Priority;
                    Util.departmentRef = x.DepartmentRef;
                    Util.departmentInternal = x.DepartmentInternal;
                    Util.assignedTo = x.AssignedTo;
                    Util.escalatedTo = x.EscalatedTo;
                    Util.EscalComm = x.EscalationComments;
                    Util.EscalCompBy = x.EscalCompletedBy;
                    Util.EscalStartDate = Convert.ToDateTime(x.EscalationStartDate.ToString()).ToShortDateString();
                    Util.Manager = x.Manager.ToString();
                    Util.TechnicianAssigned = x.TechnicianAssigned.ToString();
                    Util.EscalComplDate = x.EscalationComplDate.ToString();
                    Util.departmentEsom = x.DepartmentEsom;
                    Util.esomRef = x.EsomRef.ToString();
                    Util.reportDate = x.ReportDate.ToString();
                    Util.closingComment = x.ClosingComment;
                    Util.closedBy = x.ClosedBy;
                    Util.ClosingDate = x.ClosingDate.ToString();
                    Util.followUp = x.FollowUp;
                }
            }
            //ExportContractorToPDF form = new ExportContractorToPDF();
            //form.ShowDialog();
        }

        private void IntTracker_Load_1(object sender, EventArgs e)
        {
            
        }
        

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Reset();
        //    Filters form = new Filters();
        //    form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed        
        //    form.ShowDialog();
             
        //}

        //void child_FiltersFormClosed(object sender, FormClosedEventArgs e)
        //{
        //    //when child form is closed, this code is executed
        //    // //IntTrackerView.Items.Clear();
        //    // Refresh(sender, e);
        //    this.Dispose();
        //    IntTracker form = new IntTracker();
        //    form.ShowDialog();
        //    form.BringToFront();
        //}

    

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
            Permissions_Load(sender, e);
        }
             
        private void SearchApplybtn_Click(object sender, EventArgs e)
        {
            //if (SearchTBox.Text != String.Empty)
            //{
            //    PermissionView.Items.Clear();
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

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contractorToolStripMenuItem_Click(object sender, EventArgs e)
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
            //Util.RecordType = "Contractor";

            //ContractorRecord form = new ContractorRecord();
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
    }
}
