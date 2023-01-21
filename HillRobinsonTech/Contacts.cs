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
using Excel = Microsoft.Office.Interop.Excel;
//using ObjectListView2012;

namespace HillRobinsonTech
{
    public partial class Contacts : Form
    {
        TechDboDataContext pd = new TechDboDataContext();
        Boolean SharmabtnState = Convert.ToInt32(Util.userProject) == 2 ? true : false;
        Boolean AlYamamabtnState = Convert.ToInt32(Util.userProject) == 1 ? true : false;        


        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;


        public void RefreshListView()
        {          
            SelectContacts(ContactsView);
        }
        
        public Contacts()
        {
            InitializeComponent();
            ContactsView.FullRowSelect = true;
            ContactsView.GridLines = true;
            ContactsView.View = View.Details;
            //ContactsView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            //ContactsView.CheckBoxes = true;
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
            CustomizeContactsView(ContactsView);

            Util.AlYamamabtn = AlYamamabtnState;
            rBtnAlYamama.Checked = AlYamamabtnState ? true : false;
            Util.Sharmabtn = SharmabtnState;
            rBtnSharma.Checked = SharmabtnState ? true : false;


            //Util.TypeString = "Internal, Contractor";
            //Util.StatusString = "Open, In progress";
            quickFilterOption();

            //if (Util.userTypeConnected == "guest")
            //    ExportToolStripMenuItem.Enabled = false;


        }
            
        private void Contacts_Load(object sender, EventArgs e)
        {
            SelectContacts(ContactsView);
            SearchcBox.SelectedIndex = 0;         
        }
       
        public void CustomizeContactsView(ListView ContactsView)
        {
            //ContactsView.View = View.Details;
            ContactsView.FullRowSelect = true;
            //ContactsView.RedrawItems = true;
            //ContactsView.LabelWrap = true;
            //Task Description
            ContactsView.Columns.Add("Id", -2);
            ContactsView.Columns.Add("Full name", -2);
            ContactsView.Columns.Add("Company", -2);
            ContactsView.Columns.Add("Department", -2);
            ContactsView.Columns.Add("Position", -2);
            ContactsView.Columns.Add("Work phone details", -2);
            ContactsView.Columns.Add("Work phone no", -2);
            ContactsView.Columns.Add("Work email", -2);
            ContactsView.Columns.Add("Personal phone no", -2);
            ContactsView.Columns.Add("Personal email", -2);
            ContactsView.Columns.Add("Country", -2);
            ContactsView.Columns.Add("Location", -2);
            ContactsView.Columns.Add("Other info", 70);
            ContactsView.Columns.Add("Active", 70);
            ContactsView.Columns.Add("Last Update", -2);



            //ContactsView.Columns.Add("First name", 70);
            //ContactsView.Columns.Add("Middle name", 70);
            //ContactsView.Columns.Add("Last name", 70);


            //ContactsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //ContactsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


            //ResizeListViewColumns(ContactsView);
        }



        public void SelectContacts(ListView ContactsView)
        {
            ContactsView.Items.Clear();  

            int i = 1;
            int j = 1;
            int pageNr = (pgNrTbox.Text != "" ? Convert.ToInt32(pgNrTbox.Text) : 1);
            int totalRows = 0;
            int curRow = 0;

            UnivSource.connection.Open();
            System.Data.DataTable TrackDt = new System.Data.DataTable();
            System.Data.DataTable TrackDtAllRows = new System.Data.DataTable();
            DataSet ds = null;
            SqlDataAdapter da = null;
            string dbo = "[dbo].[GetContacts]";



            using (SqlCommand cmd = new SqlCommand(dbo, UnivSource.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

               // cmd.Parameters.Add("@TypeString", SqlDbType.VarChar).Value = Util.TypeString;
             

                cmd.ExecuteNonQuery();

                using (da = new SqlDataAdapter(cmd))
                {
                    ds = new DataSet();
                    da.Fill(ds);

                }

                TrackDt = ds.Tables["Table"];
                totalRows = (from DataRow dr in TrackDt.Rows
                             select (int)dr["Total_Rows_Count"]).FirstOrDefault();

                int r = 1;

                foreach (DataRow row in TrackDt.Rows)
                {
                    ListViewItem lviIntTrack = new ListViewItem(row["Id"].ToString());

                    curRow = Convert.ToInt32(row["RowNum"].ToString());
                    //set the font to the item
                    lviIntTrack.Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);

                    //set the font to the item
                    //if (i % 2 != 0)
                    //    i <= (33 * Convert.ToInt32(pgNrTbox.Text))
                    if (pgNrTbox.Text == "")
                        pgNrTbox.Text = "1";

                    if ((pageNr == 1 && i < (32 * pageNr + 1)) || (pageNr > 1 && i > (32 * (pageNr - 1)) && i <= (32 * pageNr)))
                    {
                        lviIntTrack.SubItems.Add(row["fullname"].ToString() != null ? row["fullname"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["Company"].ToString() != null ? row["Company"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["Department"].ToString() != null ? row["Department"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["Position"].ToString() != null ? row["Position"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["workPhoneDetails"].ToString() != null ? row["workPhoneDetails"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["workPhoneNo"].ToString() != null ? row["workPhoneNo"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["workEmail"].ToString() != null ? row["workEmail"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["persPhoneNo"].ToString() != null ? row["persPhoneNo"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["persEmail"].ToString() != null ? row["persEmail"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["Country"].ToString() != null ? row["Country"].ToString() : "");  
                        lviIntTrack.SubItems.Add(row["ContactLocation"].ToString() != null ? row["ContactLocation"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["OtherInfo"].ToString() != null ? row["OtherInfo"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["Active"].ToString() != null ? row["Active"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["LastUpdate"].ToString() != null ? row["LastUpdate"].ToString() : "");

                        lviIntTrack.SubItems.Add(row["FirstName"].ToString() != null ? row["FirstName"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["LastName"].ToString() != null ? row["LastName"].ToString() : "");


                        cmd.Parameters.Add("@PageNum", SqlDbType.Int).Value = pageNr; // Util.pageNum;
                        cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = Util.pageSizeCont;
                        cmd.Parameters.Add("@Order", SqlDbType.VarChar).Value = Util.OrderCont;
                        cmd.Parameters.Add("@Cols", SqlDbType.VarChar).Value = Util.ColsCont;
                        //lviIntTrack.SubItems.Add(row["LastUpdate"].ToString());


                        ContactsView.Items.Add(lviIntTrack);

                        //            //color to certain cells
                        //            //this is very Important
                        //            ContactsView.Items[r - 1].UseItemStyleForSubItems = false;
                        //            // Now you can Change the Particular Cell Property of Style
                        //            //lviIntTrack.Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);

                        //            for (int p = 0; p < ContactsView.Items[r - 1].SubItems.Count; p++)
                        //            {
                        //                ContactsView.Items[r - 1].SubItems[p].Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);
                        //                //priority color
                        //                if (row["Priority"].ToString().ToLower() == "critical")
                        //                    ContactsView.Items[r - 1].SubItems[3].BackColor = Color.Crimson;
                        //                ContactsView.Items[r - 1].SubItems[4].BackColor = Color.White;
                        //                if (row["Priority"].ToString().ToLower() == "urgent")
                        //                    ContactsView.Items[r - 1].SubItems[3].BackColor = Color.OrangeRed;
                        //                if (row["Priority"].ToString().ToLower() == "high")
                        //                    ContactsView.Items[r - 1].SubItems[3].BackColor = Color.Red;
                        //                if (row["Priority"].ToString().ToLower() == "medium")
                        //                    ContactsView.Items[r - 1].SubItems[3].BackColor = Color.Orange;
                        //                if (row["Priority"].ToString().Contains("LOW"))
                        //                    ContactsView.Items[r - 1].SubItems[3].BackColor = Color.Yellow;

                        //                //status color
                        //                if (row["Status"].ToString().ToLower() == "open")
                        //                    ContactsView.Items[r - 1].SubItems[2].BackColor = Color.LightSkyBlue;
                        //                if (row["Status"].ToString().ToLower() == "in progress")
                        //                    ContactsView.Items[r - 1].SubItems[2].BackColor = Color.Aquamarine;
                        //                if (row["Status"].ToString().ToLower() == "closed")
                        //                    ContactsView.Items[r - 1].SubItems[2].BackColor = Color.Bisque;
                        //                if (row["Status"].ToString().ToLower() == "cancelled")
                        //                    ContactsView.Items[r - 1].SubItems[2].BackColor = Color.LightCoral;


                    //}

                    r++;

                }
                i++;
            }
            UnivSource.connection.Close();
        }
        int itemsPerLastPage = 0;
        int lastPage = 0;


        totalPageslbl.Text = (totalRows % 32) == 0 ? (totalRows / 32).ToString() : ((totalRows / 32) + 1).ToString();
        lastPage = (totalRows % 32) == 0 ? (totalRows / 32) : ((totalRows / 32) + 1);
                        itemsPerLastPage = totalRows % 32;
                        if (pageNr<lastPage)
                            showlbl.Text = "Displaying 32 item(s) of " + totalRows;
                        if (pageNr == lastPage)
                            showlbl.Text = "Displaying " + itemsPerLastPage + " item(s) of " + totalRows;

                    }

        public void ContactsView_DoubleClick(object sender, EventArgs e)
        {
            Reset();    

            Util.newItem = false;
            if (ContactsView.SelectedItems.Count > 0)
            {
               // if (AlYamamabtnState == true)
                {
                    int Id = Convert.ToInt32(ContactsView.SelectedItems[0].SubItems[0].Text);
                    var query = from x in pd.Contacts
                                    
                                where x.id == Id

                                select new
                                {                                   
                                    x.id,
                                    x.FirstName,
                                    x.LastName,
                                    x.fullName,
                                    x.Company,
                                    x.Department,
                                    x.Position,
                                    x.workPhoneDetails,
                                    x.workPhoneNo,
                                    x.workEmail,
                                    x.persPhoneNo,
                                    x.persEmail,
                                    x.Country,
                                    x.ContactLocation,
                                    x.OtherInfo,
                                    x.Active
                                };

                    foreach (var x in query)
                    {
                        Util.ContactId = Convert.ToInt32(x.id);
                        Util.ContactFirstName = x.FirstName != null ? x.FirstName : "";
                        Util.ContactLastName = x.LastName != null ? x.LastName : "";
                        Util.ContactFullName = x.fullName != null ? x.fullName : "";
                        Util.ContactCompany = x.Company != null ? x.Company : "";
                        Util.ContactDepartment = x.Department != null ? x.Department : "";
                        Util.ContactPosition = x.Position != null ? x.Position : "";
                        Util.ContactWorkPhoneDetails = x.workPhoneDetails != null ? x.workPhoneDetails : "";
                        Util.ContactWorkPhoneNo = x.workPhoneNo != null ? x.workPhoneNo : "";
                        Util.ContactWorkEmail = x.workEmail != null ? x.workEmail : "";
                        Util.ContactPersPhoneNo = x.persPhoneNo != null ? x.persPhoneNo : "";
                        Util.ContactPersEmail = x.persEmail != null ? x.persEmail : "";
                        Util.ContactCountry = x.Country != null ? x.Country : "";
                        Util.ContactLocation = x.ContactLocation != null ? x.ContactLocation : "";
                        Util.ContactOtherInfo = x.OtherInfo != null ? x.OtherInfo : "";
                        Util.ContactActive = x.Active != null ? (int)x.Active : 0;
                    }
                }

                //if (SharmabtnState == true)
                //{
                //    int trackId = Convert.ToInt32(ContactsView.SelectedItems[0].SubItems[0].Text);
                //var query = from x in pd.Contacts
                //TechContactsTests

                //            where x.TrackId == trackId

                //            select new
                //            {
                //                x.TrackId,
                //                x.Type,
                //                x.Status,
                //                x.IssueDescription,
                //                x.Location,
                //                x.SublocationArea,
                //                x.SpecificLocation,
                //                x.LocationDetails,
                //                x.DateCreated,
                //                // x.DateReceived,
                //                x.ReportedBy,
                //                x.Priority,
                //                x.DepartmentRef,
                //                x.DepartmentInternal,
                //                x.AssignedTo,
                //                x.EscalatedTo,
                //                x.EscalationComments,
                //                x.EscalCompletedBy,
                //                x.EscalationStartDate,
                //                x.Manager,
                //                x.TechnicianAssigned,
                //                x.EscalationComplDate,
                //                x.DepartmentEsom,
                //                x.EsomRef,
                //                x.ReportDate,
                //                x.ClosingComment,
                //                x.ClosedBy,
                //                x.ClosingDate,
                //                x.FollowUp

                //            };

                //foreach (var x in query)
                //{
                //    Util.trackId = Convert.ToInt32(x.TrackId);
                //    Util.RecordType = x.Type;
                //    Util.status = x.Status;
                //    Util.issueDesc = x.IssueDescription;
                //    Util.location = x.Location;
                //    Util.subLocation = x.SublocationArea;
                //    Util.specLocation = x.SpecificLocation;
                //    Util.locationDetails = x.LocationDetails;
                //    Util.dateCreated = x.DateCreated.ToString();
                //    // Util.dateReceived = x.DateReceived.ToString();
                //    Util.reportedBy = x.ReportedBy;
                //    Util.priority = x.Priority;
                //    Util.departmentRef = x.DepartmentRef;
                //    Util.departmentInternal = x.DepartmentInternal;
                //    Util.assignedTo = x.AssignedTo;
                //    Util.escalatedTo = x.EscalatedTo;
                //    Util.EscalComm = x.EscalationComments;
                //    Util.EscalCompBy = x.EscalCompletedBy;
                //    Util.EscalStartDate = x.EscalationStartDate.ToString();
                //    Util.Manager = x.Manager != null ? x.Manager.ToString() : "";
                //    Util.TechnicianAssigned = x.TechnicianAssigned != null ? x.TechnicianAssigned.ToString() : "";
                //    Util.EscalComplDate = x.EscalationComplDate.ToString();
                //    Util.departmentEsom = x.DepartmentEsom;
                //    Util.esomRef = x.EsomRef != null ? x.EsomRef.ToString() : "";
                //    Util.reportDate = x.ReportDate.ToString();
                //    Util.closingComment = x.ClosingComment;
                //    Util.closedBy = x.ClosedBy;
                //    Util.ClosingDate = x.ClosingDate.ToString();
                //    Util.followUp = x.FollowUp;
                //}
            //}
        }


            ContactsEdit form = new ContactsEdit();
            //RefreshListEvent += new RefreshList(RefreshListView); // event initialization
            //newInstance.UpdateContractor = RefreshListEvent; // assigning event to the Delegate
            //newInstance.Show();
            form.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
            form.ShowDialog();

        }

        void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed
            ContactsView.Items.Clear();
            Contacts_Load(sender, e);
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();

            Util.newItem = true;

            ContactsEdit form = new ContactsEdit();
            form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed
            form.ShowDialog();
        }

        void child_FormClosedRefresh(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed
            ContactsView.Items.Clear();
            //Contacts_Load(sender, e);
            Refresh(sender, e);
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            //Contacts_Load(sender, e);
            ContactsView.Items.Clear();
            Refresh(sender, e);
        }
        public void Refresh(object sender, EventArgs e)
        {            
            Contacts_Load(sender, e);
        }

        private void ContactsView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

        private void ContactsView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            //e.DrawDefault = true;
        }

        private void ContactsView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            //e.DrawDefault = true;
        }

        private void ContactsView_ColumnClick(object sender, ColumnClickEventArgs e)
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
            //         value = Convert.ToBoolean(this.ContactsView.Columns[e.Column].Tag);
            //     }
            //     catch (Exception)
            //     {
            //     }
            //     this.ContactsView.Columns[e.Column].Tag = !value;
            //     foreach (ListViewItem item in this.ContactsView.Items)
            //         item.Checked = !value;

            //     this.ContactsView.Invalidate();
            // }

        }

        private void ContactsView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (ContactsView.SelectedItems.Count > 0 )
                {
                    if (ContactsView.SelectedItems[0].SubItems[1].Text == "Internal")
                    {
                        contextMenuStrip1.Items[0].Visible = true;
                        contextMenuStrip1.Items[1].Visible = false;
                    }
                    if (ContactsView.SelectedItems[0].SubItems[1].Text == "Contractor")
                    {
                        contextMenuStrip1.Items[0].Visible = false;
                        contextMenuStrip1.Items[1].Visible = true;
                    }

                    //if (ContactsView.FocusedItem.Bounds.Contains(e.Location))
                    {
                        System.Drawing.Point point = new System.Drawing.Point(this.Location.X + ContactsView.Location.X + e.X + 20,
                        this.Location.Y + ContactsView.Location.Y + e.Y);
                        contextMenuStrip1.Show(point);
                    }
                }
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
            //Util.subLocation = "";
            //Util.specLocation = "";
            //Util.locationDetails = "";

            //if (ContactsView.SelectedItems.Count > 0)
            //{
                int trackId = Convert.ToInt32(ContactsView.SelectedItems[0].SubItems[0].Text);
            //    var query = from x in pd.TechContactss
            //                    //TechContactsTests
            //                where x.TrackId == trackId

            //                select new
            //                {
            //                    x.TrackId,
            //                    x.Type,
            //                    x.Status,
            //                    x.IssueDescription,
            //                    x.Location,
            //                    x.SublocationArea,
            //                    x.SpecificLocation,
            //                    x.LocationDetails,
            //                    x.DateCreated,
            //                   // x.DateReceived,
            //                    x.ReportedBy,
            //                    x.Priority,
            //                    x.DepartmentRef,
            //                    x.DepartmentInternal,
            //                    x.AssignedTo,
            //                    x.EscalatedTo,
            //                    x.EscalationComments,
            //                    x.EscalCompletedBy,
            //                    x.EscalationStartDate,
            //                    x.Manager,
            //                    x.TechnicianAssigned,
            //                    x.EscalationComplDate,
            //                    x.DepartmentEsom,
            //                    x.EsomRef,
            //                    x.ReportDate,
            //                    x.ClosingComment,
            //                    x.ClosedBy,
            //                    x.ClosingDate,
            //                    x.FollowUp

            //                };

            //    foreach (var x in query)
            //    {  
            //        Util.trackId = Convert.ToInt32(x.TrackId);
            //        Util.RecordType = x.Type;
            //        Util.status = x.Status;
            //        Util.issueDesc = x.IssueDescription;
            //        Util.location = x.Location;
            //        Util.subLocation = x.SublocationArea;
            //        Util.specLocation = x.SpecificLocation;
            //        Util.locationDetails = x.LocationDetails;
            //        Util.dateCreated = x.DateCreated.ToString();
            //        //Util.dateReceived = x.DateReceived.ToString();
            //        Util.reportedBy = x.ReportedBy;
            //        Util.priority = x.Priority;
            //        Util.departmentRef = x.DepartmentRef;
            //        Util.departmentInternal = x.DepartmentInternal;
            //        Util.assignedTo = x.AssignedTo;
            //        Util.escalatedTo = x.EscalatedTo;
            //        Util.EscalComm = x.EscalationComments;
            //        Util.EscalCompBy = x.EscalCompletedBy;
            //        Util.EscalStartDate = x.EscalationStartDate.ToString();
            //        Util.Manager = x.Manager != null ? x.Manager.ToString() : "";
            //        Util.TechnicianAssigned = x.TechnicianAssigned != null ? x.TechnicianAssigned.ToString() : "";
            //        Util.EscalComplDate = x.EscalationComplDate.ToString();
            //        Util.departmentEsom = x.DepartmentEsom;
            //        Util.esomRef = x.EsomRef != null ? x.EsomRef.ToString() : "";
            //        Util.reportDate = x.ReportDate.ToString();
            //        Util.closingComment = x.ClosingComment;
            //        Util.closedBy = x.ClosedBy;
            //        Util.ClosingDate = x.ClosingDate.ToString();
            //        Util.followUp = x.FollowUp;
            //    }
            //}
            //ExportInternalToPDF form = new ExportInternalToPDF();
            //form.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //if (ContactsView.SelectedItems.Count > 0)
            //{
            //    if (AlYamamabtnState == true)
            //    {
            //        int trackId = Convert.ToInt32(ContactsView.SelectedItems[0].SubItems[0].Text);
                    //var query = from x in pd.TechContactss
                    //                //TechContactsTests
                    //            where x.TrackId == trackId

                    //            select new
                    //            {
                    //                x.TrackId,
                    //                x.Type,
                    //                x.Status,
                    //                x.IssueDescription,
                    //                x.Location,
                    //                x.SublocationArea,
                    //                x.SpecificLocation,
                    //                x.LocationDetails,
                    //                x.DateCreated,
                    //                //x.DateReceived,
                    //                x.ReportedBy,
                    //                x.Priority,
                    //                x.DepartmentRef,
                    //                x.DepartmentInternal,
                    //                x.AssignedTo,
                    //                x.EscalatedTo,
                    //                x.EscalationComments,
                    //                x.EscalCompletedBy,
                    //                x.EscalationStartDate,
                    //                x.Manager,
                    //                x.TechnicianAssigned,
                    //                x.EscalationComplDate,
                    //                x.DepartmentEsom,
                    //                x.EsomRef,
                    //                x.ReportDate,
                    //                x.ClosingComment,
                    //                x.ClosedBy,
                    //                x.ClosingDate,
                    //                x.FollowUp

                    //            };

                    //foreach (var x in query)
                    //{
                    //    Util.trackId = Convert.ToInt32(x.TrackId);
                    //    Util.RecordType = x.Type;
                    //    Util.status = x.Status;
                    //    Util.issueDesc = x.IssueDescription;
                    //    Util.location = x.Location;
                    //    Util.subLocation = x.SublocationArea;
                    //    Util.specLocation = x.SpecificLocation;
                    //    Util.locationDetails = x.LocationDetails;
                    //    Util.dateCreated = x.DateCreated.ToString();
                    //    //Util.dateReceived = x.DateReceived.ToString();
                    //    Util.reportedBy = x.ReportedBy;
                    //    Util.priority = x.Priority;
                    //    Util.departmentRef = x.DepartmentRef;
                    //    Util.departmentInternal = x.DepartmentInternal;
                    //    Util.assignedTo = x.AssignedTo;
                    //    Util.escalatedTo = x.EscalatedTo;
                    //    Util.EscalComm = x.EscalationComments;
                    //    Util.EscalCompBy = x.EscalCompletedBy;
                    //    Util.EscalStartDate = Convert.ToDateTime(x.EscalationStartDate.ToString()).ToShortDateString();
                    //    Util.Manager = x.Manager.ToString();
                    //    Util.TechnicianAssigned = x.TechnicianAssigned.ToString();
                    //    Util.EscalComplDate = x.EscalationComplDate.ToString();
                    //    Util.departmentEsom = x.DepartmentEsom;
                    //    Util.esomRef = x.EsomRef.ToString();
                    //    Util.reportDate = x.ReportDate.ToString();
                    //    Util.closingComment = x.ClosingComment;
                    //    Util.closedBy = x.ClosedBy;
                    //    Util.ClosingDate = x.ClosingDate.ToString();
                    //    Util.followUp = x.FollowUp;
            //        //}
            //    }
            //}
            //if (SharmabtnState == true)
            //{
            //    int trackId = Convert.ToInt32(ContactsView.SelectedItems[0].SubItems[0].Text);
            //    var query = from x in pd.TechContactsSharmas
            //                    //TechContactsTests
            //                where x.TrackId == trackId

            //                select new
            //                {
            //                    x.TrackId,
            //                    x.Type,
            //                    x.Status,
            //                    x.IssueDescription,
            //                    x.Location,
            //                    x.SublocationArea,
            //                    x.SpecificLocation,
            //                    x.LocationDetails,
            //                    x.DateCreated,
            //                    //x.DateReceived,
            //                    x.ReportedBy,
            //                    x.Priority,
            //                    x.DepartmentRef,
            //                    x.DepartmentInternal,
            //                    x.AssignedTo,
            //                    x.EscalatedTo,
            //                    x.EscalationComments,
            //                    x.EscalCompletedBy,
            //                    x.EscalationStartDate,
            //                    x.Manager,
            //                    x.TechnicianAssigned,
            //                    x.EscalationComplDate,
            //                    x.DepartmentEsom,
            //                    x.EsomRef,
            //                    x.ReportDate,
            //                    x.ClosingComment,
            //                    x.ClosedBy,
            //                    x.ClosingDate,
            //                    x.FollowUp

            //                };

            //    foreach (var x in query)
            //    {
            //        Util.trackId = Convert.ToInt32(x.TrackId);
            //        Util.RecordType = x.Type;
            //        Util.status = x.Status;
            //        Util.issueDesc = x.IssueDescription;
            //        Util.location = x.Location;
            //        Util.subLocation = x.SublocationArea;
            //        Util.specLocation = x.SpecificLocation;
            //        Util.locationDetails = x.LocationDetails;
            //        Util.dateCreated = x.DateCreated.ToString();
            //        //Util.dateReceived = x.DateReceived.ToString();
            //        Util.reportedBy = x.ReportedBy;
            //        Util.priority = x.Priority;
            //        Util.departmentRef = x.DepartmentRef;
            //        Util.departmentInternal = x.DepartmentInternal;
            //        Util.assignedTo = x.AssignedTo;
            //        Util.escalatedTo = x.EscalatedTo;
            //        Util.EscalComm = x.EscalationComments;
            //        Util.EscalCompBy = x.EscalCompletedBy;
            //        Util.EscalStartDate = Convert.ToDateTime(x.EscalationStartDate.ToString()).ToShortDateString();
            //        Util.Manager = x.Manager.ToString();
            //        Util.TechnicianAssigned = x.TechnicianAssigned.ToString();
            //        Util.EscalComplDate = x.EscalationComplDate.ToString();
            //        Util.departmentEsom = x.DepartmentEsom;
            //        Util.esomRef = x.EsomRef.ToString();
            //        Util.reportDate = x.ReportDate.ToString();
            //        Util.closingComment = x.ClosingComment;
            //        Util.closedBy = x.ClosedBy;
            //        Util.ClosingDate = x.ClosingDate.ToString();
            //        Util.followUp = x.FollowUp;
            //    }
            //}
            //ExportContractorToPDF form = new ExportContractorToPDF();
            //form.ShowDialog();
        }

        private void Contacts_Load_1(object sender, EventArgs e)
        {
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            Filters form = new Filters();
            form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed        
            form.ShowDialog();
             
        }

        //void child_FiltersFormClosed(object sender, FormClosedEventArgs e)
        //{
        //    //when child form is closed, this code is executed
        //    // //ContactsView.Items.Clear();
        //    // Refresh(sender, e);
        //    this.Dispose();
        //    Contacts form = new Contacts();
        //    form.ShowDialog();
        //    form.BringToFront();
        //}

    

         public void Reset()
        {
           // List<string> statusFilterListsReset = new List<string>();
            //Util.statusFilterLists = statusFilterListsReset;
            //Util.StatusString = "";
            //Util.LocationString = "";
            //Util.DateCreatedIn = "";
            //Util.DateCreatedOut = "";
            //Util.ReportedByString = "";
            //Util.PriorityString = "";
            //Util.DepartmentRefString = "";
            //Util.AssignedToString = "";
            //Util.EscalatedToString = "";
            //Util.DepartmentEsomString = "";
            //Util.ReportDateIn = "";
            //Util.ReportDateOut = "";   ///to continue        
        }

        private void ResetFilterbtn_Click(object sender, EventArgs e)
        {
            Reset();
            Contacts_Load(sender, e);
        }
             
        private void SearchApplybtn_Click(object sender, EventArgs e)
        {
            if (SearchTBox.Text != String.Empty)
            {
                int i = 1;
                int j = 1;
                int pageNr = (pgNrTbox.Text != "" ? Convert.ToInt32(pgNrTbox.Text) : 1);
                int totalRows = 0;

                ContactsView.Items.Clear();
                string searchText = SearchTBox.Text.ToString();
                string searchOption = SearchcBox.Text.ToString();            

                UnivSource.connection.Open();
                System.Data.DataTable TrackDt = new System.Data.DataTable();
                DataSet ds = null;
                SqlDataAdapter da = null;
                string dbo = Util.AlYamamabtn ? "GetSearchString" : "GetSearchStringSharma";//!!!!!

                using (SqlCommand cmd = new SqlCommand(dbo, UnivSource.connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SearchString", SqlDbType.VarChar).Value = searchText;
                    cmd.Parameters.Add("@SearchOption", SqlDbType.VarChar).Value = searchOption;
                    cmd.Parameters.Add("@PageNum", SqlDbType.Int).Value = pageNr; // Util.pageNum;
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = Util.pageSize;
                    cmd.Parameters.Add("@Order", SqlDbType.VarChar).Value = Util.Order;
                    cmd.Parameters.Add("@Cols", SqlDbType.VarChar).Value = Util.Cols;

                    cmd.ExecuteNonQuery();

                    using (da = new SqlDataAdapter(cmd))
                    {
                        ds = new DataSet();
                        da.Fill(ds);

                    }

                    TrackDt = ds.Tables["Table"];
                    totalRows = (from DataRow dr in TrackDt.Rows
                                 select (int)dr["Total_Rows_Count"]).FirstOrDefault();

                    int r = 1;
                    //TO UPDATE LISTVIEW
                    foreach (DataRow row in TrackDt.Rows)
                    {
                        ListViewItem lviIntTrack = new ListViewItem(row["TrackId"].ToString());

                        //set the font to the item
                        lviIntTrack.Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);

                        lviIntTrack.SubItems.Add(row["Type"].ToString() != null ? row["Type"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["Status"].ToString());
                        lviIntTrack.SubItems.Add(row["Priority"].ToString());
                        lviIntTrack.SubItems.Add(row["IssueDescription"].ToString());
                        lviIntTrack.SubItems.Add(row["Location"].ToString());
                        lviIntTrack.SubItems.Add(row["SublocationArea"].ToString() != null ? row["SublocationArea"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["SpecificLocation"].ToString() != null ? row["SpecificLocation"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["LocationDetails"].ToString() != null ? row["LocationDetails"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["DateCreated"].ToString() != null ? row["DateCreated"].ToString() : "");//DateTime.Parse(track.DateCreated.ToString()).ToShortDateString()

                        //lviIntTrack.SubItems.Add(track.DateReceived.ToString()); // DateTime.Parse(track.DateReceived.ToString()).ToShortDateString());
                        lviIntTrack.SubItems.Add(row["ReportedBy"].ToString());
                        lviIntTrack.SubItems.Add(row["DepartmentRef"].ToString());
                        lviIntTrack.SubItems.Add(row["DepartmentInternal"].ToString() != null ? row["DepartmentInternal"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["AssignedTo"].ToString());
                        lviIntTrack.SubItems.Add(row["EscalatedTo"].ToString());
                        lviIntTrack.SubItems.Add(row["EscalationComments"].ToString());
                        lviIntTrack.SubItems.Add(row["EscalCompletedBy"].ToString());
                        lviIntTrack.SubItems.Add(row["EscalationStartDate"].ToString());
                        lviIntTrack.SubItems.Add(row["Manager"].ToString());
                        lviIntTrack.SubItems.Add(row["TechnicianAssigned"].ToString());
                        lviIntTrack.SubItems.Add(row["EscalationComplDate"].ToString());

                        lviIntTrack.SubItems.Add(row["DepartmentEsom"].ToString());
                        lviIntTrack.SubItems.Add(row["EsomRef"].ToString());
                        lviIntTrack.SubItems.Add(row["ReportDate"].ToString());   /// DateTime.Parse(track.ReportDate.ToString()).ToShortDateString());

                        lviIntTrack.SubItems.Add(row["ClosingComment"].ToString());
                        lviIntTrack.SubItems.Add(row["ClosedBy"].ToString() != null ? row["ClosedBy"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["ClosingDate"].ToString() != null ? row["ClosingDate"].ToString() : "");//DateTime.Parse(track.InspectionDate.ToString()).ToShortDateString()
                        lviIntTrack.SubItems.Add(row["FollowUp"].ToString());

                        ContactsView.Items.Add(lviIntTrack);

                        //color to certain cells
                        //this is very Important
                        ContactsView.Items[r - 1].UseItemStyleForSubItems = false;
                        // Now you can Change the Particular Cell Property of Style
                        //lviIntTrack.Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);

                        for (int p = 0; p < ContactsView.Items[r - 1].SubItems.Count; p++)
                        {
                            ContactsView.Items[r - 1].SubItems[p].Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);
                            //priority color
                            if (row["Priority"].ToString().ToLower() == "critical")
                                ContactsView.Items[r - 1].SubItems[3].BackColor = Color.Crimson;
                            ContactsView.Items[r - 1].SubItems[4].BackColor = Color.White;
                            if (row["Priority"].ToString().ToLower() == "urgent")
                                ContactsView.Items[r - 1].SubItems[3].BackColor = Color.OrangeRed;
                            if (row["Priority"].ToString().ToLower() == "high")
                                ContactsView.Items[r - 1].SubItems[3].BackColor = Color.Red;
                            if (row["Priority"].ToString().ToLower() == "medium")
                                ContactsView.Items[r - 1].SubItems[3].BackColor = Color.Orange;
                            if (row["Priority"].ToString().Contains("LOW"))
                                ContactsView.Items[r - 1].SubItems[3].BackColor = Color.Yellow;

                            //status color
                            if (row["Status"].ToString().ToLower() == "open")
                                ContactsView.Items[r - 1].SubItems[2].BackColor = Color.LightSkyBlue;
                            if (row["Status"].ToString().ToLower() == "in progress")
                                ContactsView.Items[r - 1].SubItems[2].BackColor = Color.Aquamarine;
                            if (row["Status"].ToString().ToLower() == "closed")
                                ContactsView.Items[r - 1].SubItems[2].BackColor = Color.Bisque;
                            if (row["Status"].ToString().ToLower() == "cancelled")
                                ContactsView.Items[r - 1].SubItems[2].BackColor = Color.LightCoral;


                        }

                        r++;

                        i++;
                    }
                    //showlbl.Text = "Displaying " + (i - 1) + " item(s)";


                }

                UnivSource.connection.Close();

                int itemsPerLastPage = 0;
                int lastPage = 0;


                totalPageslbl.Text = (totalRows % 32) == 0 ? (totalRows / 32).ToString() : ((totalRows / 32) + 1).ToString();
                lastPage = (totalRows % 32) == 0 ? (totalRows / 32) : ((totalRows / 32) + 1);
                itemsPerLastPage = totalRows % 32;
                if (pageNr < lastPage)
                    showlbl.Text = "Displaying 32 item(s) of " + totalRows;
                if (pageNr == lastPage)
                    showlbl.Text = "Displaying " + itemsPerLastPage + " item(s) of " + totalRows;

            }
        }

        private void ClearSearchBtn_Click(object sender, EventArgs e)
        {
            SearchcBox.SelectedIndex = 0;
            SearchTBox.Text = "";
            Refresh(sender, e);
        }

        private void Statisticsbtn_Click(object sender, EventArgs e)
        {
            Statistics form = new Statistics();
            form.ShowDialog();
        }

        private void internalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Util.trackId = 0;
            //Util.RecordType = "";
            //Util.status = "";
            //Util.issueDesc = "";
            //Util.location = "";
            ////Util.dateReceived = "";
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

            //InternalRecordOld form = new InternalRecordOld();
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
            ////Util.dateReceived = "";
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

            //ContractorRecordAlYamama form = new ContractorRecordAlYamama();
            //form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed
            //form.ShowDialog();
        }

        private void PDFExportbtn_Click(object sender, EventArgs e)
        {
            string userName = Environment.UserName;
            string machineName = Environment.MachineName;
            string fileName = "C:\\Users\\Local Admin\\Hill Robinson\\Project Bianca - Shared\\Technical\\TaskAlocation\\Int Track List  - " + DateTime.Now.Date.ToShortDateString().Replace("/", ".") + " by " + Util.userConnected + " - " + machineName + " , " + userName + ".pdf".ToString();
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);           

            iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A3.Rotate());
            Document doc = new Document(rec);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            //TechContacts dp = new TechContacts();
            //var tracks = (from x in pd.TechContactss
            //             select x).OrderByDescending(v => v.TrackId);
            PdfPTable table = new PdfPTable(8);
            PdfPCell cell = new PdfPCell(new Phrase("Contacts List  - " + DateTime.Now.Date.ToShortDateString().Replace("/", ".").ToString()));

            cell.Colspan = 8;

            //cell.VerticalAlignment = 1;
            cell.FixedHeight = 35f;
            table.WidthPercentage = 100;
            table.SetWidths(new[] { 5f, 5f, 5f, 8f, 25f, 20f, 10f, 15f });
            cell.HorizontalAlignment = 1; // 0=left, 1= centre, 2= right
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            table.AddCell(cell);

            table.AddCell(new PdfPCell(new Phrase(("Track Id"))) { FixedHeight = 35, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_MIDDLE });
            table.AddCell(new PdfPCell(new Phrase(("Type"))) { FixedHeight = 35, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            table.AddCell(new PdfPCell(new Phrase(("Status"))) { FixedHeight = 35, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            table.AddCell(new PdfPCell(new Phrase(("Priority"))) { HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            table.AddCell(new PdfPCell(new Phrase(("Issue Description"))) { HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            table.AddCell(new PdfPCell(new Phrase(("Location"))) { FixedHeight = 35, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            table.AddCell(new PdfPCell(new Phrase(("DateCreated"))) { FixedHeight = 35, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
            table.AddCell(new PdfPCell(new Phrase(("ReportedBy"))) { FixedHeight = 35, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });



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





            doc.Add(table);

            doc.Close();
        }

        //private void ExportXls()
        //{
        //    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        //    excel.Visible = true;
        //    Microsoft.Office.Interop.Excel.Workbook wBook = excel.Workbooks.Add(1);
        //    Microsoft.Office.Interop.Excel.Worksheet wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.Worksheets[1];
        //    DataSet dset = new DataSet();
        //    dset.Tables.Add();

        //    int i = 1;
        //    int i2 = 2;
        //    int x = 1;
        //    int x2 = 1;
        //    int colNum = ContactsView.Columns.Count;

        //    // Set first ROW as Column Headers Text
        //    foreach (ColumnHeader ch in ContactsView.Columns)
        //    {
        //        x++;
        //        wSheet.Cells[x2, x] = ch.Text;
        //        wSheet.Cells[x2, x].Font.Bold = true;
        //        wSheet.Cells[x2, x].Font.Size = 14;
        //        wSheet.Cells[x2, x].Borders.Value = 1;
        //        wSheet.Cells[x2, x].Borders.LineStyle = Excel.XlLineStyle.xlDouble;

        //        //x++;
        //    }

        //    foreach (ListViewItem lvi in ContactsView.Items)
        //    {
        //        i = 1;
        //        foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
        //        {
        //            i++;
        //            wSheet.Cells[i2, i] = lvs.Text;
        //            wSheet.Cells[i2, i].Borders.Value = 1;
        //            //i++;
        //        }
        //        i2++;
        //    }

        //    // AutoSet Cell Widths to Content Size
        //    wSheet.Cells.Select();
        //    //wSheet.Cells.EntireColumn.AutoFit();
        //    wSheet.Columns.AutoFit();
        //    wSheet.Rows.AutoFit();


        //    Range line = (Range)wSheet.Rows[1];
        //    line.Insert();
        //    var filter = wSheet.Cells[1, x].AutoFilter();
        //    //line.Insert();


        //    object misValue = System.Reflection.Missing.Value;
        //    Excel.Range chartRange;
        //    Excel.ChartObjects xlCharts = (Excel.ChartObjects)wSheet.ChartObjects(Type.Missing);
        //    Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
        //    Excel.Chart chartPage = myChart.Chart;

        //    chartRange = wSheet.get_Range("A1", "d5");
        //    chartPage.SetSourceData(chartRange, misValue);
        //    chartPage.ChartType = Excel.XlChartType.xlColumnClustered;





        //    string date = DateTime.Now.ToString().Replace("/", ".").Replace(":", ".");
        //    string userName = Environment.UserName;
        //    string machineName = Environment.MachineName;
        //    wBook.SaveAs(@"C:\Users\Local Admin\Hill Robinson\Project Bianca - Shared\Technical\TaskAlocation\Int Track List  - " + date + " by " + Util.userConnected + " - " + machineName + " , " + userName + ". "+".xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
        //        Type.Missing, Type.Missing);
        //}      


        private void pgNrTbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectContacts(ContactsView);
        }

        private void firstLbl_Click(object sender, EventArgs e)
        {
            pgNrTbox.Text = "1";
            SelectContacts(ContactsView);
        }

        private void lastLbl_Click(object sender, EventArgs e)
        {
            pgNrTbox.Text = totalPageslbl.Text;
            SelectContacts(ContactsView);
        }

        private void prevLbl_Click(object sender, EventArgs e)
        {
            pgNrTbox.Text = Convert.ToInt32(pgNrTbox.Text) > 1 ? (Convert.ToInt32(pgNrTbox.Text) -1).ToString() : pgNrTbox.Text;
            SelectContacts(ContactsView);
        }

        private void nextLbl_Click(object sender, EventArgs e)
        {
            pgNrTbox.Text = Convert.ToInt32(pgNrTbox.Text) < Convert.ToInt32(totalPageslbl.Text) ? (Convert.ToInt32(pgNrTbox.Text) + 1).ToString() : pgNrTbox.Text;
            SelectContacts(ContactsView);
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            Contacts form = new Contacts();
            form.ShowDialog();
        }

        private void infoBtn_MouseHover(object sender, EventArgs e)
        {
            infoToolTip.Show("Click to display info of the page!", infoBtn);
        }

        private void AlYambtn_Click(object sender, EventArgs e)
        {
            SelectContacts(ContactsView);
        }

        //private void SharmaBtn_Click(object sender, EventArgs e)
        //{
        //    SelectContacts(ContactsView);
        //}

        private void ContactsView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ContactsView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //ContactsView.Items[e.Item.Index].Checked = true;

            ListView.CheckedListViewItemCollection checkedItems =
            ContactsView.CheckedItems;

            //foreach (ListViewItem item in checkedItems)
            //{
            //    item.Checked = true;
            //}
        }

        private void currentPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportXlsbtn("currentPage");

        }

        private void wholeListExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportXlsbtn("wholeList");
        }

        private void ExportXlsbtn(string option)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
           // excel.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wBook = excel.Workbooks.Add(1);
            Microsoft.Office.Interop.Excel.Worksheet wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.Worksheets[1];
            DataSet dset = new DataSet();
            dset.Tables.Add();

            int i = 1;
            int i2 = 2;
            int x = 1;
            int x2 = 1;
            int colNum = ContactsView.Columns.Count;

            // Set first ROW as Column Headers Text
            foreach (ColumnHeader ch in ContactsView.Columns)
            {
                x++;
                wSheet.Cells[x2, x] = ch.Text;
                wSheet.Cells[x2, x].Font.Bold = true;
                wSheet.Cells[x2, x].Font.Size = 14;
                wSheet.Cells[x2, x].Borders.Value = 1;
                wSheet.Cells[x2, x].Borders.LineStyle = Excel.XlLineStyle.xlDouble;

                //x++;
            }

            if(option == "currentPage")
            {
                foreach (ListViewItem lvi in ContactsView.Items)
                {
                    i = 1;
                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        i++;
                        wSheet.Cells[i2, i] = lvs.Text;
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        //if(lvs.Text == "HIGH")
                        //wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        //if (lvs.Text == "CRITICAL")
                        //    wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Crimson);
                        //if (lvs.Text == "URGENT")
                        //    wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.OrangeRed);
                        //i++;
                    }
                    i2++;
                }
            }

            if (option == "wholeList")
            {

                if (!Util.FilterUsed)
                {
                    if (AlYamamabtnState == true)
                    {
                        //var tracks = (from y in pd.TechContactss
                        //              select y).OrderByDescending(v => (int)v.TrackId);

                        //int j = 1;
                        //i2 = 2;

                        //foreach (var track in tracks)
                        //{


                        //    i = 1;

                        //    ListViewItem lviIntTrackExcel = new ListViewItem();

                        //    foreach (ListViewItem.ListViewSubItem lvs in lviIntTrackExcel.SubItems)
                        //    {
                        //        i++;
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.TrackId.ToString();
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.Type != null ? track.Type.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.Status != null ? track.Status.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.Priority.ToString();
                        //        if (track.Priority.ToString() == "HIGH")
                        //            wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        //        if (track.Priority.ToString() == "CRITICAL")
                        //            wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Crimson);
                        //        if (track.Priority.ToString() == "URGENT")
                        //            wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.OrangeRed);
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.IssueDescription.ToString();
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.Location.ToString();
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.SublocationArea != null ? track.SublocationArea.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.SpecificLocation != null ? track.SpecificLocation.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.LocationDetails != null ? track.LocationDetails.ToString() : ""; 
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.DateCreated != null ? DateTime.Parse(track.DateCreated.ToString()).ToShortDateString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.ReportedBy != null ? track.ReportedBy.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.DepartmentRef != null ? track.DepartmentRef.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.DepartmentInternal != null ? track.DepartmentInternal.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.AssignedTo != null ? track.AssignedTo.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.EscalationComments != null ? track.EscalationComments.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.EscalCompletedBy != null ? track.EscalCompletedBy.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.EscalationStartDate.ToString();
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.Manager != null ? track.Manager.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.TechnicianAssigned != null ? track.TechnicianAssigned.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.EscalationComplDate.ToString();
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.DepartmentEsom != null ? track.DepartmentEsom.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.EsomRef != null ? track.EsomRef.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.DateCreated != null ? track.ReportDate.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.ClosingComment != null ? track.ClosingComment.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.ClosedBy != null ? track.ClosedBy.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.ClosingDate != null ? DateTime.Parse(track.ClosingDate.ToString()).ToShortDateString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.FollowUp != null ? track.FollowUp.ToString() : "";
                        //    }
                        //    i2++;
                        //}
                    }
                    else
                    if (SharmabtnState == true)
                    {
                        //var tracks = (from y in pd.TechContactsSharmas
                        //              select y).OrderByDescending(v => (int)v.TrackId);

                        //int j = 1;
                        //i2 = 2;

                        //foreach (var track in tracks)
                        //{


                        //    i = 1;

                        //    ListViewItem lviIntTrackExcel = new ListViewItem();

                        //    foreach (ListViewItem.ListViewSubItem lvs in lviIntTrackExcel.SubItems)
                        //    {
                        //        i++;
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.TrackId.ToString();
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.Type != null ? track.Type.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.Status != null ? track.Status.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.Priority.ToString();
                        //        if (track.Priority.ToString() == "HIGH")
                        //            wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        //        if (track.Priority.ToString() == "CRITICAL")
                        //            wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Crimson);
                        //        if (track.Priority.ToString() == "URGENT")
                        //            wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.OrangeRed);
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.IssueDescription.ToString();
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.Location.ToString();
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.SublocationArea != null ? track.SublocationArea.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.SpecificLocation != null ? track.SpecificLocation.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.LocationDetails != null ? track.LocationDetails.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.DateCreated != null ? DateTime.Parse(track.DateCreated.ToString()).ToShortDateString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.ReportedBy != null ? track.ReportedBy.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.DepartmentRef != null ? track.DepartmentRef.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.DepartmentInternal != null ? track.DepartmentInternal.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.AssignedTo != null ? track.AssignedTo.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.EscalationComments != null ? track.EscalationComments.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.EscalCompletedBy != null ? track.EscalCompletedBy.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.EscalationStartDate.ToString();
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.Manager != null ? track.Manager.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.TechnicianAssigned != null ? track.TechnicianAssigned.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.EscalationComplDate.ToString();
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.DepartmentEsom != null ? track.DepartmentEsom.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.EsomRef != null ? track.EsomRef.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.DateCreated != null ? track.ReportDate.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.ClosingComment != null ? track.ClosingComment.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.ClosedBy != null ? track.ClosedBy.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.ClosingDate != null ? DateTime.Parse(track.ClosingDate.ToString()).ToShortDateString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.FollowUp != null ? track.FollowUp.ToString() : "";
                        //        wSheet.Cells[i2, i].Borders.Value = 1;
                        //        wSheet.Cells[i2, i++] = track.LastUpdate != null ? track.LastUpdate.ToString() : "";
                        //    }
                        //    i2++;
                        //}
                    }


                    //i2++;
                }

             }



            // AutoSet Cell Widths to Content Size
            wSheet.Cells.Select();
            //wSheet.Cells.EntireColumn.AutoFit();
            wSheet.Columns.AutoFit();
            wSheet.Rows.AutoFit();


            Range line = (Range)wSheet.Rows[1];
            line.Insert();
            var filter = wSheet.Cells[1, x].AutoFilter();
            //line.Insert();


            //object misValue = System.Reflection.Missing.Value;
            //Excel.Range chartRange;
            //Excel.ChartObjects xlCharts = (Excel.ChartObjects)wSheet.ChartObjects(Type.Missing);
            //Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
            //Excel.Chart chartPage = myChart.Chart;

            //chartRange = wSheet.get_Range("A1", "d5");
            //chartPage.SetSourceData(chartRange, misValue);
            //chartPage.ChartType = Excel.XlChartType.xlColumnClustered;





            string date = DateTime.Now.ToString().Replace("/", ".").Replace(":", ".");
            string currentUserPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string userName = Environment.UserName;
            string machineName = Util.userMachine; // Environment.MachineName;

            if (AlYamamabtnState == true)
            {
                wBook.SaveAs(@currentUserPath + "\\Hill Robinson\\Project Bianca - Shared\\Technical\\TaskAlocation\\Contact List Al Yamamah - " + date + " by " + Util.userConnected + " - " + machineName + " , " + userName + ". " + ".xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
            } else
            if (SharmabtnState == true)
            wBook.SaveAs(@currentUserPath + "\\Hill Robinson\\Project Sharma - Shared\\Technical\\TaskAlocationSharma\\Contact List Sharma - " + date + " by " + Util.userConnected + " - " + machineName + " , " + userName + ". " + ".xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
            excel.ActiveWindow.Close();
        }

        private void rBtnSharma_CheckedChanged(object sender, EventArgs e)
        {
            SharmabtnState = true;
            AlYamamabtnState = false;
            Util.Sharmabtn = true;
            Util.AlYamamabtn = false;
           SelectContacts(ContactsView);//Sharma
        }

        private void rBtnAlYamama_CheckedChanged(object sender, EventArgs e)
        {
            AlYamamabtnState = true;
            SharmabtnState = false;
            Util.AlYamamabtn = true;
            Util.Sharmabtn = false;
            SelectContacts(ContactsView);
        }

        private void cBoxOpen_CheckedChanged(object sender, EventArgs e)
        {
            quickFilterOption();
        }
        private void cBoxInProgress_CheckedChanged(object sender, EventArgs e)
        {
            quickFilterOption();
        }

        public void quickFilterOption()
        {
            ////add
            //if (cBoxOpen.Checked == true && cBoxAll.Checked == false)
            //    Util.StatusString += "Open, ";
            //if(cBoxInProgress.Checked == true && cBoxAll.Checked == false)
            //    Util.StatusString += "In progress, ";
            //if (cBoxAll.Checked == true)
            //    Util.StatusString = "";
            //if (InternalcheckBox.Checked == true)
            //    Util.TypeString += "Internal, ";
            //if (ContractorcheckBox.Checked == true)
            //    Util.TypeString += "Contractor, ";
            ////last comma

            ////remove
            //if (cBoxOpen.Checked == false && cBoxAll.Checked == false && Util.StatusString!= String.Empty)
            //    Util.StatusString = Util.StatusString.Contains("Open, ") ? Util.StatusString.Replace("Open, ", "") : Util.StatusString.Replace("Open", "");
            //if (cBoxOpen.Checked == false && cBoxAll.Checked == true)
            //    cBoxAll.Checked = false;
            //if (cBoxInProgress.Checked == false && cBoxAll.Checked == false && Util.StatusString != String.Empty)
            //    Util.StatusString = Util.StatusString.Contains("In progress, ") ? Util.StatusString.Replace("In progress, ", "") : Util.StatusString.Replace("In progress", "");
            //if (cBoxInProgress.Checked == false && cBoxAll.Checked == true)
            //    cBoxAll.Checked = false;

            ////Util.TypeString = "Internal, Contractor";

            //if (InternalcheckBox.Checked == false && Util.TypeString != String.Empty)
            //    Util.TypeString = Util.TypeString.Contains("Internal, ") ? Util.TypeString.Replace("Internal, ", "") : Util.TypeString.Replace("Internal", "");
            //if (ContractorcheckBox.Checked == false && Util.TypeString != String.Empty)
            //    Util.TypeString = Util.TypeString.Contains("Contractor, ") ? Util.TypeString.Replace("Contractor, ", "") : Util.TypeString.Replace("Contractor", "");

            //select
            //if (rBtnToday.Checked == true)
            //{
            //    Util.today = 1;
            //    Util.curWeek = 0;
            //    Util.curMonth = 0;
            //    Util.wholeList = 0;
            //}
            //if (rBtnCurrentWeek.Checked == true)
            //{
            //    Util.curWeek = 1;
            //    Util.today = 0;
            //    Util.curMonth = 0;
            //    Util.wholeList = 0;
            //}
            //if(rBtnCurrentMonth.Checked == true)
            //{
            //    Util.curMonth = 1;
            //    Util.curWeek = 0;
            //    Util.today = 0;
            //    Util.wholeList = 0;
            //}
            //if (rBtnWholelist.Checked == true)
            //{
            //    Util.wholeList = 1;
            //    Util.today = 0;
            //    Util.curWeek = 0;
            //    Util.curMonth = 0;
            //}
            //pgNrTbox.Text = "1";

            SelectContacts(ContactsView);
        }

        private void InternalcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            quickFilterOption();
        }

        private void ContractorcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            quickFilterOption();
        }

        private void rBtnCurrentWeek_CheckedChanged(object sender, EventArgs e)
        {
            quickFilterOption();
        }

        private void rBtnToday_CheckedChanged(object sender, EventArgs e)
        {
            quickFilterOption();
        }

        private void rBtnCurrentMonth_CheckedChanged(object sender, EventArgs e)
        {
            quickFilterOption();
        }

        private void rBtnWholelist_CheckedChanged(object sender, EventArgs e)
        {
            quickFilterOption();
        }

        private void cBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            //if (cBoxOpen.Checked == false && cBoxAll.Checked == true)
            //    cBoxOpen.Checked = true;
            //if (cBoxInProgress.Checked == false && cBoxAll.Checked == true)
            //    cBoxInProgress.Checked = true;
            quickFilterOption();
        }

        private void SearchTBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchApplybtn_Click(sender, e);
        }

       
    }
}
