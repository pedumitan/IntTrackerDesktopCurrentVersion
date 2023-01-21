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
    public partial class IntTrackerSharma : Form
    {
        TechDboDataContext pd = new TechDboDataContext();
        //Boolean SharmabtnState = Convert.ToInt32(Util.userProject) == 2 ? true : false;
        //Boolean AlYamamabtnState = Convert.ToInt32(Util.userProject) == 1 ? true : false;
       


        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;


        public void RefreshListView()
        {          
            SelectIntTracker(IntTrackerView);
        }
        
        public IntTrackerSharma()
        {
            InitializeComponent();
            IntTrackerView.FullRowSelect = true;
            IntTrackerView.GridLines = true;
            IntTrackerView.View = View.Details;
            //IntTrackerView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            //IntTrackerView.CheckBoxes = true;
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
            CustomizeIntTrackerView(IntTrackerView);

            //Util.AlYamamabtn = AlYamamabtnState;
            //rBtnAlYamama.Checked = AlYamamabtnState ? true : false;
            //Util.Sharmabtn = SharmabtnState;
            //rBtnSharma.Checked = SharmabtnState ? true : false;

            resetFilters();

            Util.Sharmabtn = true;
            Util.AlYamamabtn = false;
            if (Util.departmentConnected == "Technical")
                Util.TypeString = "Internal, Contractor";
            else
            {
                Util.TypeString = "Internal";
                ContractorcheckBox.Checked = false;
            }
            Util.StatusString = "Open, In progress";
            quickFilterOption();

            if (Util.userTypeConnected == "guest" || Util.departmentConnected != "Technical")
            {
                ExportToolStripMenuItem.Enabled = false;
                contractorToolStripMenuItem.Enabled = false;
            }

           

        }
            
        private void IntTrackerSharma_Load(object sender, EventArgs e)
        {
            SelectIntTracker(IntTrackerView);
            SearchcBox.SelectedIndex = 0;
            lbSession.Text = Util.currentSession;
        }

        private void resetFilters()
        {
            Util.TrackNoFrom = "";
            Util.TrackNoTo = "";
            Util.TypeString = "";
            Util.StatusString = "";
            Util.PriorityString = "";
            Util.LocationString = "";
            Util.SubLocationString = "";
            Util.SpecLocationString = "";
            Util.LocationDetailsString = "";
            Util.ReportedByString = "";
        }


        public void CustomizeIntTrackerView(ListView IntTrackerView)
        {
            //IntTrackerView.View = View.Details;
            IntTrackerView.FullRowSelect = true;
            //IntTrackerView.RedrawItems = true;
            //IntTrackerView.LabelWrap = true;

            //Task Description
            IntTrackerView.Columns.Add("Track Id", -2);
            IntTrackerView.Columns.Add("Type", 70);
            IntTrackerView.Columns.Add("Status", 70);
            IntTrackerView.Columns.Add("Priority", 70); 
            IntTrackerView.Columns.Add("During/After visit", 70);
            IntTrackerView.Columns.Add("Issue Description", 700);
            IntTrackerView.Columns.Add("Location", -2);
            IntTrackerView.Columns.Add("Sublocation", -2);
            IntTrackerView.Columns.Add("Specific location", -2);
            IntTrackerView.Columns.Add("Location details", -2);

            //Work assignment/Owner
            IntTrackerView.Columns.Add("Date Created", -2);
            IntTrackerView.Columns.Add("Due by date", -2);
            IntTrackerView.Columns.Add("Days open", -2);
            IntTrackerView.Columns.Add("Reported By", 120);
            IntTrackerView.Columns.Add("Owner", -2);
            IntTrackerView.Columns.Add("Assigned to", -2);

            IntTrackerView.Columns.Add("Department", 170);
            IntTrackerView.Columns.Add("Manager", -2);
            IntTrackerView.Columns.Add("Technicians assigned", 220);

            //Escalation
            IntTrackerView.Columns.Add("Escalation start date", -2);
            IntTrackerView.Columns.Add("Contractor Ref/Tracking number PPM", 100);           
            IntTrackerView.Columns.Add("Escalation comments", 350);
            IntTrackerView.Columns.Add("Action plan", 150);
            IntTrackerView.Columns.Add("Materials needed", 150);            
            IntTrackerView.Columns.Add("Escalation completion date", -2);
            IntTrackerView.Columns.Add("Escalation Completed By", -2);
            IntTrackerView.Columns.Add("Last Update", -2);

            //Close Out
            IntTrackerView.Columns.Add("Closing Date", -2);
            IntTrackerView.Columns.Add("Closed by", 150);
            IntTrackerView.Columns.Add("Closing Comment", 230);

            //Follow up
            IntTrackerView.Columns.Add("Follow up", 200);

           

            //Reports
            IntTrackerView.Columns.Add("Final report (Contractor)", -2);
            IntTrackerView.Columns.Add("Final report (HLR)", -2);
            //IntTrackerView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //IntTrackerView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


            //ResizeListViewColumns(IntTrackerView);
        }

        private void getDataCallProcedure()
        {
            int i = 1;
            int j = 1;
            int pageNr = (pgNrTbox.Text != "" ? Convert.ToInt32(pgNrTbox.Text) : 1);
            int totalRows = 0;
            int curRow = 0;
            bool noRows = true;

            string searchText = SearchTBox.Text.ToString();
            string searchOption = SearchcBox.Text.ToString();


            Util.DateCreatedIn = Util.DateCreatedIn != "" ? DateTime.Parse(Util.DateCreatedIn).ToString("yyyy-MM-dd") : Util.DateCreatedIn;
            Util.DateCreatedOut = Util.DateCreatedOut != "" ? DateTime.Parse(Util.DateCreatedOut).ToString("yyyy-MM-dd") : Util.DateCreatedOut;
            Util.CompDateIn = Util.CompDateIn != "" ? DateTime.Parse(Util.CompDateIn).ToString("yyyy-MM-dd") : Util.CompDateIn;
            Util.CompDateOut = Util.CompDateOut != "" ? DateTime.Parse(Util.CompDateOut).ToString("yyyy-MM-dd") : Util.CompDateOut;
            Util.ClosingDateIn = Util.ClosingDateIn != "" ? DateTime.Parse(Util.ClosingDateIn).ToString("yyyy-MM-dd") : Util.ClosingDateIn;
            Util.ClosingDateOut = Util.ClosingDateOut != "" ? DateTime.Parse(Util.ClosingDateOut).ToString("yyyy-MM-dd") : Util.ClosingDateOut;


            UnivSource.connection.Open();
            System.Data.DataTable TrackDt = new System.Data.DataTable();
            System.Data.DataTable TrackDtAllRows = new System.Data.DataTable();
            DataSet ds = null;
            SqlDataAdapter da = null;
            string dbo = "[avitsql].[GetDataSharma]";
            //Util.AlYamamabtn ? "GetData".ToString() : "GetDataSharma".ToString();



            using (SqlCommand cmd = new SqlCommand(dbo, UnivSource.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@TrackNoFrom", SqlDbType.VarChar).Value = Util.TrackNoFrom;
                cmd.Parameters.Add("@TrackNoTo", SqlDbType.VarChar).Value = Util.TrackNoTo;
                cmd.Parameters.Add("@TypeString", SqlDbType.VarChar).Value = Util.TypeString;
                cmd.Parameters.Add("@StatusString", SqlDbType.VarChar).Value = Util.StatusString;
                cmd.Parameters.Add("@PriorityString", SqlDbType.VarChar).Value = Util.PriorityString;
                cmd.Parameters.Add("@LocationString", SqlDbType.VarChar).Value = Util.LocationString;
                cmd.Parameters.Add("@SubLocationString", SqlDbType.VarChar).Value = Util.SubLocationString;
                cmd.Parameters.Add("@SpecLocationString", SqlDbType.VarChar).Value = Util.SpecLocationString;
                cmd.Parameters.Add("@LocationDetailsString", SqlDbType.VarChar).Value = Util.LocationDetailsString;
                cmd.Parameters.Add("@Today", SqlDbType.Int).Value = Util.today;
                cmd.Parameters.Add("@CurWeek", SqlDbType.Int).Value = Util.curWeek;
                cmd.Parameters.Add("@CurMonth", SqlDbType.Int).Value = Util.curMonth;
                cmd.Parameters.Add("@DateReceivedIn", SqlDbType.VarChar).Value = Util.DateCreatedIn;
                cmd.Parameters.Add("@DateReceivedOut", SqlDbType.VarChar).Value = Util.DateCreatedOut;
                cmd.Parameters.Add("@ReportedByString", SqlDbType.VarChar).Value = Util.ReportedByString;
                cmd.Parameters.Add("@CompDateIn", SqlDbType.VarChar).Value = Util.CompDateIn;
                cmd.Parameters.Add("@CompDateOut", SqlDbType.VarChar).Value = Util.CompDateOut;
                cmd.Parameters.Add("@CompletedByString", SqlDbType.VarChar).Value = Util.CompletedByString;
                cmd.Parameters.Add("@ClosingDateIn", SqlDbType.VarChar).Value = Util.ClosingDateIn;
                cmd.Parameters.Add("@ClosingDateOut", SqlDbType.VarChar).Value = Util.ClosingDateOut;
                cmd.Parameters.Add("@ClosedByString", SqlDbType.VarChar).Value = Util.ClosedByString;
                cmd.Parameters.Add("@DepartmentRefString", SqlDbType.VarChar).Value = Util.DepartmentRefString;
                cmd.Parameters.Add("@AssignedToString", SqlDbType.VarChar).Value = Util.AssignedToString;
                cmd.Parameters.Add("@EscalatedToString", SqlDbType.VarChar).Value = Util.EscalatedToString;
                cmd.Parameters.Add("@DepartmentEsomString", SqlDbType.VarChar).Value = Util.DepartmentEsomString;
                cmd.Parameters.Add("@ReportDateIn", SqlDbType.VarChar).Value = Util.ReportDateIn;
                cmd.Parameters.Add("@ReportDateOut", SqlDbType.VarChar).Value = Util.ReportDateOut;
                cmd.Parameters.Add("@PageNum", SqlDbType.Int).Value = pageNr; // Util.pageNum;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = Util.pageSize;
                cmd.Parameters.Add("@Order", SqlDbType.VarChar).Value = Util.Order;
                cmd.Parameters.Add("@Cols", SqlDbType.VarChar).Value = Util.Cols;
                cmd.Parameters.Add("@SearchString", SqlDbType.VarChar).Value = searchText;
                cmd.Parameters.Add("@SearchOption", SqlDbType.VarChar).Value = searchOption;

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
                    noRows = false;
                    ListViewItem lviIntTrack = new ListViewItem(row["TrackId"].ToString());

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

                        lviIntTrack.SubItems.Add(row["Type"].ToString() != null ? row["Type"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["Status"].ToString());
                        lviIntTrack.SubItems.Add(row["Priority"].ToString());
                        lviIntTrack.SubItems.Add(row["DuringAfterVisit"].ToString());
                        lviIntTrack.SubItems.Add(row["IssueDescription"].ToString());
                        lviIntTrack.SubItems.Add(row["Location"].ToString());
                        lviIntTrack.SubItems.Add(row["SublocationArea"].ToString() != null ? row["SublocationArea"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["SpecificLocation"].ToString() != null ? row["SpecificLocation"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["LocationDetails"].ToString() != null ? row["LocationDetails"].ToString() : "");

                        lviIntTrack.SubItems.Add(row["DateCreated"].ToString() != null ? row["DateCreated"].ToString() : "");//DateTime.Parse(track.DateCreated.ToString()).ToShortDateString()
                        lviIntTrack.SubItems.Add(row["DueByDate"].ToString() != null ? row["DueByDate"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["DaysOpen"].ToString() != null ? row["DaysOpen"].ToString() : "");

                        //lviIntTrack.SubItems.Add(track.DateReceived.ToString()); // DateTime.Parse(track.DateReceived.ToString()).ToShortDateString());
                        lviIntTrack.SubItems.Add(row["ReportedBy"].ToString());
                        lviIntTrack.SubItems.Add(row["Owner"].ToString() != null ? row["Owner"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["AssignedTo"].ToString() != null ? row["AssignedTo"].ToString() : "");

                        lviIntTrack.SubItems.Add(row["DepartmentEsom"].ToString());
                        lviIntTrack.SubItems.Add(row["Manager"].ToString());
                        lviIntTrack.SubItems.Add(row["TechnicianAssigned"].ToString());

                        lviIntTrack.SubItems.Add(row["EscalationStartDate"].ToString());
                        lviIntTrack.SubItems.Add(row["EsomRef"].ToString());
                        lviIntTrack.SubItems.Add(row["EscalationComments"].ToString());
                        lviIntTrack.SubItems.Add(row["ActionPlan"].ToString() != null ? row["ActionPlan"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["MaterialsNeeded"].ToString() != null ? row["MaterialsNeeded"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["EscalationComplDate"].ToString());
                        lviIntTrack.SubItems.Add(row["EscalCompletedBy"].ToString());
                        lviIntTrack.SubItems.Add(row["LastUpdate"].ToString() != null ? row["LastUpdate"].ToString() : "");

                        lviIntTrack.SubItems.Add(row["ClosingDate"].ToString() != null ? row["ClosingDate"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["ClosedBy"].ToString() != null ? row["ClosedBy"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["ClosingComment"].ToString());
                        lviIntTrack.SubItems.Add(row["FollowUp"].ToString());

                        lviIntTrack.SubItems.Add(row["ContractorFReport"].ToString() != null ? row["ContractorFReport"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["HLRFinalReport"].ToString() != null ? row["HLRFinalReport"].ToString() : "");


                        IntTrackerView.Items.Add(lviIntTrack);

                        //color to certain cells
                        //this is very Important
                        IntTrackerView.Items[r - 1].UseItemStyleForSubItems = false;
                        // Now you can Change the Particular Cell Property of Style
                        //lviIntTrack.Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);

                        for (int p = 0; p < IntTrackerView.Items[r - 1].SubItems.Count; p++)
                        {
                            IntTrackerView.Items[r - 1].SubItems[p].Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);
                            //priority color
                            if (row["Priority"].ToString().ToLower() == "critical")
                                IntTrackerView.Items[r - 1].SubItems[3].BackColor = Color.Crimson;
                            IntTrackerView.Items[r - 1].SubItems[4].BackColor = Color.White;
                            if (row["Priority"].ToString().ToLower() == "urgent")
                                IntTrackerView.Items[r - 1].SubItems[3].BackColor = Color.OrangeRed;
                            if (row["Priority"].ToString().ToLower() == "high")
                                IntTrackerView.Items[r - 1].SubItems[3].BackColor = Color.Red;
                            if (row["Priority"].ToString().ToLower() == "medium")
                                IntTrackerView.Items[r - 1].SubItems[3].BackColor = Color.Orange;
                            if (row["Priority"].ToString().Contains("LOW"))
                                IntTrackerView.Items[r - 1].SubItems[3].BackColor = Color.Yellow;

                            //status color
                            if (row["Status"].ToString().ToLower() == "open")
                                IntTrackerView.Items[r - 1].SubItems[2].BackColor = Color.LightSkyBlue;
                            if (row["Status"].ToString().ToLower() == "in progress")
                                IntTrackerView.Items[r - 1].SubItems[2].BackColor = Color.Aquamarine;
                            if (row["Status"].ToString().ToLower() == "closed")
                                IntTrackerView.Items[r - 1].SubItems[2].BackColor = Color.Bisque;
                            if (row["Status"].ToString().ToLower() == "cancelled")
                                IntTrackerView.Items[r - 1].SubItems[2].BackColor = Color.LightCoral;



                        }

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
            itemsPerLastPage = totalRows != 32 ? totalRows % 32 : totalRows;
            if (pageNr < lastPage)
                showlbl.Text = "Displaying 32 item(s) of " + totalRows;
            if (pageNr == lastPage)
                showlbl.Text = "Displaying " + itemsPerLastPage + " item(s) of " + totalRows;

            if (noRows)
                showlbl.Text = "Displaying 0 item(s) of 0";

        }

        public void SelectIntTracker(ListView IntTrackerView)
        {
            IntTrackerView.Items.Clear();
            getDataCallProcedure();      
        }

        public void IntTrackerView_DoubleClick(object sender, EventArgs e)
        {         

            Util.newItem = false;
            if (IntTrackerView.SelectedItems.Count > 0)
            {
               
                int trackId = Convert.ToInt32(IntTrackerView.SelectedItems[0].SubItems[0].Text);
                var query = from x in pd.TechIntTrackerSharmas
                                //TechIntTrackerTests

                            where x.TrackId == trackId

                            select new
                            {
                                x.TrackId,
                                x.Type,
                                x.Status,
                                x.Priority,
                                x.DuringAfterVisit,
                                x.IssueDescription,

                                x.Location,
                                x.SublocationArea,
                                x.SpecificLocation,
                                x.LocationDetails,

                                x.DateCreated,
                                x.DueByDate,
                                x.DaysOpen,
                                x.ReportedBy,
                                x.Owner,
                                x.AssignedTo,

                                x.EscalationStartDate,
                                x.EsomRef,
                                x.DepartmentEsom,
                                x.EscalationComments,
                                x.ActionPlan,
                                x.MaterialsNeeded,
                                x.Manager,
                                x.TechnicianAssigned,
                                x.EscalationComplDate,
                                x.EscalCompletedBy,

                                x.ClosingDate,
                                x.ClosedBy,
                                x.ClosingComment,
                                x.FollowUp,
                                x.ContractorFReport,
                                x.HLRFinalReport

                            };

                foreach (var x in query)
                {
                    Util.trackId = Convert.ToInt32(x.TrackId);
                    Util.RecordType = x.Type;
                    Util.status = x.Status;
                    Util.priority = x.Priority;
                    Util.duringAfterVisit = x.DuringAfterVisit;
                    Util.issueDesc = x.IssueDescription;

                    Util.location = x.Location;
                    Util.subLocation = x.SublocationArea;
                    Util.specLocation = x.SpecificLocation;
                    Util.locationDetails = x.LocationDetails;

                    Util.dateCreated = x.DateCreated.ToString();
                    Util.dueDate = x.DueByDate.ToString();
                    Util.daysOpen = x.DaysOpen.ToString();
                    Util.reportedBy = x.ReportedBy;
                    Util.Owner = x.Owner;
                    Util.assignedTo = x.AssignedTo;

                    Util.EscalStartDate = x.EscalationStartDate.ToString();
                    Util.esomRef = x.EsomRef != null ? x.EsomRef.ToString() : "";
                    Util.departmentEsom = x.DepartmentEsom;
                    Util.EscalComm = x.EscalationComments;
                    Util.ActionPlan = x.ActionPlan;
                    Util.MaterialsNeeded = x.MaterialsNeeded;
                    Util.Manager = x.Manager != null ? x.Manager.ToString() : "";
                    Util.TechnicianAssigned = x.TechnicianAssigned != null ? x.TechnicianAssigned.ToString() : "";
                    Util.EscalComplDate = x.EscalationComplDate.ToString();
                    Util.EscalCompBy = x.EscalCompletedBy;
                       
                       
                    Util.ClosingDate = x.ClosingDate.ToString();
                    Util.closedBy = x.ClosedBy;
                    Util.closingComment = x.ClosingComment;

                    Util.followUp = x.FollowUp;
                    Util.HLRFReport = x.HLRFinalReport;
                    Util.ContractorFReport = x.ContractorFReport;
                }
            }
        //}

            //IntTrackerEdit form = new IntTrackerEdit();
            if (IntTrackerView.SelectedItems[0].SubItems[1].Text == "Contractor")
            {

                ContractorRecordSharma newInstance = new ContractorRecordSharma();
                RefreshListEvent += new RefreshList(RefreshListView); // event initialization
                newInstance.UpdateContractor = RefreshListEvent; // assigning event to the Delegate
                newInstance.ShowDialog();

               // ContractorRecord form = new ContractorRecord();
               // form.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
               // form.ShowDialog();
            }
            if (IntTrackerView.SelectedItems.Count > 0 && IntTrackerView.SelectedItems[0].SubItems[1].Text == "Internal")
            {
                InternalRecordOld newInstance = new InternalRecordOld();
                RefreshListEvent += new RefreshList(RefreshListView); // event initialization
                newInstance.UpdateInternal = RefreshListEvent; // assigning event to the Delegate
                newInstance.ShowDialog();

                //InternalRecord form = new InternalRecord();
                //form.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
                // form.ShowDialog();
            }

        }

        //void child_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    //when child form is closed, this code is executed
        //    // //IntTrackerView.Items.Clear();
        //    // Refresh(sender, e);

        //    //IntTrackerView.Items.Clear();
        //    //IntTracker_Load(sender, e);
        //    Refresh(sender, e);            
        //}

        private void newbtn_Click(object sender, EventArgs e)
        {
            Util.trackId =0;
            Util.RecordType = "";
            Util.status = "";
            Util.priority = "";
            Util.duringAfterVisit = "";
            Util.issueDesc = "";

            Util.location = "";
            Util.subLocation = "";
            Util.specLocation = "";
            Util.locationDetails = "";

            Util.dateCreated = "";
            Util.dueDate = "";
            Util.daysOpen = "";
            Util.reportedBy = "";
            Util.Owner = "";
            Util.assignedTo = "";

            Util.EscalStartDate = "";
            Util.esomRef = "";
            Util.departmentEsom = "";
            Util.EscalComm = "";
            Util.ActionPlan = "";
            Util.MaterialsNeeded = "";
            Util.Manager = "";
            Util.TechnicianAssigned = "";
            Util.EscalComplDate = "";
            Util.EscalCompBy = "";


            Util.ClosingDate = "";
            Util.closedBy = "";
            Util.closingComment = "";

            Util.followUp = "";
            Util.HLRFReport = "";
            Util.ContractorFReport = "";

            Util.newItem = true;

            //IntTrackerEdit form = new IntTrackerEdit();
            //form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed
            //form.ShowDialog();                             
    }
        void child_FormClosedRefresh(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed
            IntTrackerView.Items.Clear();
           
            IntTrackerSharma_Load(sender, e);
            //Refresh(sender, e);
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            //resetFilters();
            this.Dispose();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            //IntTracker_Load(sender, e);
            IntTrackerView.Items.Clear();
            Refresh(sender, e);
        }
        public void Refresh(object sender, EventArgs e)
        {
            IntTrackerSharma_Load(sender, e);
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
                if (IntTrackerView.SelectedItems.Count > 0 )
                {
                    if (IntTrackerView.SelectedItems[0].SubItems[1].Text == "Internal")
                    {
                        contextMenuStrip1.Items[0].Visible = true;
                        contextMenuStrip1.Items[1].Visible = false;
                    }
                    if (IntTrackerView.SelectedItems[0].SubItems[1].Text == "Contractor")
                    {
                        contextMenuStrip1.Items[0].Visible = false;
                        contextMenuStrip1.Items[1].Visible = true;
                    }

                    //if (IntTrackerView.FocusedItem.Bounds.Contains(e.Location))
                    {
                        System.Drawing.Point point = new System.Drawing.Point(this.Location.X + IntTrackerView.Location.X + e.X + 20,
                        this.Location.Y + IntTrackerView.Location.Y + e.Y);
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

            if (IntTrackerView.SelectedItems.Count > 0)
            {
                int trackId = Convert.ToInt32(IntTrackerView.SelectedItems[0].SubItems[0].Text);
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
                                x.SublocationArea,
                                x.SpecificLocation,
                                x.LocationDetails,
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
                    Util.subLocation = x.SublocationArea;
                    Util.specLocation = x.SpecificLocation;
                    Util.locationDetails = x.LocationDetails;
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
            Util.exportLocation = "Sharma";
            ExportInternalToPDF form = new ExportInternalToPDF();
            form.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (IntTrackerView.SelectedItems.Count > 0)
            {
               
                int trackId = Convert.ToInt32(IntTrackerView.SelectedItems[0].SubItems[0].Text);
                var query = from x in pd.TechIntTrackerSharmas
                                //TechIntTrackerTests

                            where x.TrackId == trackId

                            select new
                            {
                                x.TrackId,
                                x.Type,
                                x.Status,
                                x.Priority,
                                x.DuringAfterVisit,
                                x.IssueDescription,

                                x.Location,
                                x.SublocationArea,
                                x.SpecificLocation,
                                x.LocationDetails,

                                x.DateCreated,
                                x.DueByDate,
                                x.DaysOpen,
                                x.ReportedBy,
                                x.Owner,
                                x.AssignedTo,

                                x.EscalationStartDate,
                                x.EsomRef,
                                x.DepartmentEsom,
                                x.EscalationComments,
                                x.ActionPlan,
                                x.MaterialsNeeded,
                                x.Manager,
                                x.TechnicianAssigned,
                                x.EscalationComplDate,
                                x.EscalCompletedBy,

                                x.ClosingDate,
                                x.ClosedBy,
                                x.ClosingComment,
                                x.FollowUp,
                                x.ContractorFReport,
                                x.HLRFinalReport

                            };

                foreach (var x in query)
                {
                    Util.trackId = Convert.ToInt32(x.TrackId);
                    Util.RecordType = x.Type;
                    Util.status = x.Status;
                    Util.priority = x.Priority;
                    Util.duringAfterVisit = x.DuringAfterVisit;
                    Util.issueDesc = x.IssueDescription;

                    Util.location = x.Location;
                    Util.subLocation = x.SublocationArea;
                    Util.specLocation = x.SpecificLocation;
                    Util.locationDetails = x.LocationDetails;

                    Util.dateCreated = x.DateCreated.ToString();
                    Util.dueDate = x.DueByDate.ToString();
                    Util.daysOpen = x.DaysOpen.ToString();
                    Util.reportedBy = x.ReportedBy;
                    Util.Owner = x.Owner;
                    Util.assignedTo = x.AssignedTo;

                    Util.EscalStartDate = x.EscalationStartDate.ToString();
                    Util.esomRef = x.EsomRef != null ? x.EsomRef.ToString() : "";
                    Util.departmentEsom = x.DepartmentEsom;
                    Util.EscalComm = x.EscalationComments;
                    Util.ActionPlan = x.ActionPlan;
                    Util.MaterialsNeeded = x.MaterialsNeeded;
                    Util.Manager = x.Manager != null ? x.Manager.ToString() : "";
                    Util.TechnicianAssigned = x.TechnicianAssigned != null ? x.TechnicianAssigned.ToString() : "";
                    Util.EscalComplDate = x.EscalationComplDate.ToString();
                    Util.EscalCompBy = x.EscalCompletedBy;


                    Util.ClosingDate = x.ClosingDate.ToString();
                    Util.closedBy = x.ClosedBy;
                    Util.closingComment = x.ClosingComment;

                    Util.followUp = x.FollowUp;
                    Util.HLRFReport = x.HLRFinalReport;
                    Util.ContractorFReport = x.ContractorFReport;
                }
            }
            Util.exportLocation = "Sharma";
            ExportContractorToPDF form = new ExportContractorToPDF();
            form.ShowDialog();
        }

        private void IntTracker_Load_1(object sender, EventArgs e)
        {
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            Util.Sharmabtn = true;
            Filters form = new Filters();
            form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed        
            form.ShowDialog();
             
        }

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
            Util.TrackNoFrom = "";
            Util.TrackNoTo = "";
            Util.StatusString = "";
            Util.LocationString = "";
            Util.SubLocationString = "";
            Util.SpecLocationString = "";
            Util.LocationDetailsString = "";
            Util.DateCreatedIn = "";
            Util.DateCreatedOut = "";
            Util.ReportedByString = "";
            Util.CompDateIn = "";
            Util.CompDateOut = "";
            Util.CompletedByString = "";
            Util.ClosingDateIn = "";
            Util.ClosingDateOut = "";
            Util.ClosedByString = "";
            Util.PriorityString = "";
            Util.DepartmentRefString = "";
            Util.AssignedToString = "";
            //Util.AssignedToPString = "";
            Util.EscalatedToString = "";
            Util.DepartmentEsomString = "";
            Util.ReportDateIn = "";
            Util.ReportDateOut = "";   ///to continue        

        }

        private void ResetFilterbtn_Click(object sender, EventArgs e)
        {
            Reset();
            IntTrackerSharma_Load(sender, e);
        }
             
        private void SearchApplybtn_Click(object sender, EventArgs e)
        {
            Util.SearchBoxFilterUsed = true;
            IntTrackerView.Items.Clear();
            getDataCallProcedure();

            //if (SearchTBox.Text != String.Empty)
            //{
            //    int i = 1;
            //    int j = 1;
            //    int pageNr = (pgNrTbox.Text != "" ? Convert.ToInt32(pgNrTbox.Text) : 1);
            //    int totalRows = 0;

            //    IntTrackerView.Items.Clear();
            //    string searchText = SearchTBox.Text.ToString();
            //    string searchOption = SearchcBox.Text.ToString();

            //    UnivSource.connection.Open();
            //    System.Data.DataTable TrackDt = new System.Data.DataTable();
            //    DataSet ds = null;
            //    SqlDataAdapter da = null;
            //    string dbo = "[avitsql].[GetDataSharma]";
            //    //Util.AlYamamabtn ? "GetSearchString" : "GetSearchStringSharma";

            //    using (SqlCommand cmd = new SqlCommand(dbo, UnivSource.connection))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;

            //        cmd.Parameters.Add("@SearchString", SqlDbType.VarChar).Value = searchText;
            //        cmd.Parameters.Add("@SearchOption", SqlDbType.VarChar).Value = searchOption;
            //        cmd.Parameters.Add("@PageNum", SqlDbType.Int).Value = pageNr; // Util.pageNum;
            //        cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = Util.pageSize;
            //        cmd.Parameters.Add("@Order", SqlDbType.VarChar).Value = Util.Order;
            //        cmd.Parameters.Add("@Cols", SqlDbType.VarChar).Value = Util.Cols;

            //        cmd.ExecuteNonQuery();

            //        using (da = new SqlDataAdapter(cmd))
            //        {
            //            ds = new DataSet();
            //            da.Fill(ds);

            //        }

            //        TrackDt = ds.Tables["Table"];
            //        totalRows = (from DataRow dr in TrackDt.Rows
            //                     select (int)dr["Total_Rows_Count"]).FirstOrDefault();

            //        int r = 1;
            //        //TO UPDATE LISTVIEW
            //        foreach (DataRow row in TrackDt.Rows)
            //        {
            //            ListViewItem lviIntTrack = new ListViewItem(row["TrackId"].ToString());

            //            //set the font to the item
            //            lviIntTrack.Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);

            //            lviIntTrack.SubItems.Add(row["Type"].ToString() != null ? row["Type"].ToString() : "");
            //            lviIntTrack.SubItems.Add(row["Status"].ToString());
            //            lviIntTrack.SubItems.Add(row["Priority"].ToString());
            //            lviIntTrack.SubItems.Add(row["DuringAfterVisit"].ToString());
            //            lviIntTrack.SubItems.Add(row["IssueDescription"].ToString());
            //            lviIntTrack.SubItems.Add(row["Location"].ToString());
            //            lviIntTrack.SubItems.Add(row["SublocationArea"].ToString() != null ? row["SublocationArea"].ToString() : "");
            //            lviIntTrack.SubItems.Add(row["SpecificLocation"].ToString() != null ? row["SpecificLocation"].ToString() : "");
            //            lviIntTrack.SubItems.Add(row["LocationDetails"].ToString() != null ? row["LocationDetails"].ToString() : "");

            //            lviIntTrack.SubItems.Add(row["DateCreated"].ToString() != null ? row["DateCreated"].ToString() : "");//DateTime.Parse(track.DateCreated.ToString()).ToShortDateString()
            //            lviIntTrack.SubItems.Add(row["DueByDate"].ToString() != null ? row["DueByDate"].ToString() : "");
            //            lviIntTrack.SubItems.Add(row["DaysOpen"].ToString() != null ? row["DaysOpen"].ToString() : "");

            //            //lviIntTrack.SubItems.Add(track.DateReceived.ToString()); // DateTime.Parse(track.DateReceived.ToString()).ToShortDateString());
            //            lviIntTrack.SubItems.Add(row["ReportedBy"].ToString());
            //            lviIntTrack.SubItems.Add(row["Owner"].ToString() != null ? row["Owner"].ToString() : "");
            //            lviIntTrack.SubItems.Add(row["AssignedTo"].ToString() != null ? row["AssignedTo"].ToString() : "");

            //            lviIntTrack.SubItems.Add(row["DepartmentEsom"].ToString());
            //            lviIntTrack.SubItems.Add(row["Manager"].ToString());
            //            lviIntTrack.SubItems.Add(row["TechnicianAssigned"].ToString());

            //            lviIntTrack.SubItems.Add(row["EscalationStartDate"].ToString());
            //            lviIntTrack.SubItems.Add(row["EsomRef"].ToString());
            //            lviIntTrack.SubItems.Add(row["EscalationComments"].ToString());
            //            lviIntTrack.SubItems.Add(row["ActionPlan"].ToString() != null ? row["ActionPlan"].ToString() : "");
            //            lviIntTrack.SubItems.Add(row["MaterialsNeeded"].ToString() != null ? row["MaterialsNeeded"].ToString() : "");
            //            lviIntTrack.SubItems.Add(row["EscalationComplDate"].ToString());
            //            lviIntTrack.SubItems.Add(row["EscalCompletedBy"].ToString());
            //            lviIntTrack.SubItems.Add(row["LastUpdate"].ToString() != null ? row["LastUpdate"].ToString() : "");

            //            lviIntTrack.SubItems.Add(row["ClosingDate"].ToString() != null ? row["ClosingDate"].ToString() : "");
            //            lviIntTrack.SubItems.Add(row["ClosedBy"].ToString() != null ? row["ClosedBy"].ToString() : "");
            //            lviIntTrack.SubItems.Add(row["ClosingComment"].ToString());
            //            lviIntTrack.SubItems.Add(row["FollowUp"].ToString());

            //            lviIntTrack.SubItems.Add(row["ContractorFReport"].ToString() != null ? row["ContractorFReport"].ToString() : "");
            //            lviIntTrack.SubItems.Add(row["HLRFinalReport"].ToString() != null ? row["HLRFinalReport"].ToString() : "");

            //            IntTrackerView.Items.Add(lviIntTrack);

            //            //color to certain cells
            //            //this is very Important
            //            IntTrackerView.Items[r - 1].UseItemStyleForSubItems = false;
            //            // Now you can Change the Particular Cell Property of Style
            //            //lviIntTrack.Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);

            //            for (int p = 0; p < IntTrackerView.Items[r - 1].SubItems.Count; p++)
            //            {
            //                IntTrackerView.Items[r - 1].SubItems[p].Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);
            //                //priority color
            //                if (row["Priority"].ToString().ToLower() == "critical")
            //                    IntTrackerView.Items[r - 1].SubItems[3].BackColor = Color.Crimson;
            //                IntTrackerView.Items[r - 1].SubItems[4].BackColor = Color.White;
            //                if (row["Priority"].ToString().ToLower() == "urgent")
            //                    IntTrackerView.Items[r - 1].SubItems[3].BackColor = Color.OrangeRed;
            //                if (row["Priority"].ToString().ToLower() == "high")
            //                    IntTrackerView.Items[r - 1].SubItems[3].BackColor = Color.Red;
            //                if (row["Priority"].ToString().ToLower() == "medium")
            //                    IntTrackerView.Items[r - 1].SubItems[3].BackColor = Color.Orange;
            //                if (row["Priority"].ToString().Contains("LOW"))
            //                    IntTrackerView.Items[r - 1].SubItems[3].BackColor = Color.Yellow;

            //                //status color
            //                if (row["Status"].ToString().ToLower() == "open")
            //                    IntTrackerView.Items[r - 1].SubItems[2].BackColor = Color.LightSkyBlue;
            //                if (row["Status"].ToString().ToLower() == "in progress")
            //                    IntTrackerView.Items[r - 1].SubItems[2].BackColor = Color.Aquamarine;
            //                if (row["Status"].ToString().ToLower() == "closed")
            //                    IntTrackerView.Items[r - 1].SubItems[2].BackColor = Color.Bisque;
            //                if (row["Status"].ToString().ToLower() == "cancelled")
            //                    IntTrackerView.Items[r - 1].SubItems[2].BackColor = Color.LightCoral;


            //            }

            //            r++;

            //            i++;
            //        }
            //        //showlbl.Text = "Displaying " + (i - 1) + " item(s)";


            //    }

            //    UnivSource.connection.Close();

            //    int itemsPerLastPage = 0;
            //    int lastPage = 0;


            //    totalPageslbl.Text = (totalRows % 32) == 0 ? (totalRows / 32).ToString() : ((totalRows / 32) + 1).ToString();
            //    lastPage = (totalRows % 32) == 0 ? (totalRows / 32) : ((totalRows / 32) + 1);
            //    itemsPerLastPage = totalRows % 32;
            //    if (pageNr < lastPage)
            //        showlbl.Text = "Displaying 32 item(s) of " + totalRows;
            //    if (pageNr == lastPage)
            //        showlbl.Text = "Displaying " + itemsPerLastPage + " item(s) of " + totalRows;

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
            Statistics form = new Statistics();
            form.ShowDialog();
        }

        private void internalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.trackId = 0;
            Util.RecordType = "";
            Util.status = "";
            Util.issueDesc = "";
            Util.location = "";
            //Util.dateReceived = "";
            Util.reportedBy = "";
            Util.priority = "";
            Util.departmentRef = "";
            Util.assignedTo = "";
            Util.escalatedTo = "";
            Util.departmentEsom = "";
            Util.departmentInternal = "";
            Util.esomRef = "";
            Util.reportDate = "";
            Util.closingComment = "";
            Util.followUp = "";
            Util.dateCreated = "";
            Util.closedBy = "";
            Util.ClosingDate = "";
            Util.RecordType = "";
            Util.EscalComm = "";
            Util.EscalCompBy = "";
            Util.EscalStartDate = "";
            Util.Manager = "";
            Util.TechnicianAssigned = "";
            Util.EscalComplDate = "";

            Util.newItem = true;
            Util.RecordType = "Internal";           

            InternalRecordOld form = new InternalRecordOld();
            form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed
            form.ShowDialog();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Util.departmentConnected != "Technical")
                ContractorcheckBox.Checked = false;
        }

        private void contractorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.trackId = 0;
            
            Util.reportedBy = "";
            Util.status = "";
            Util.priority = "";
            Util.duringAfterVisit = "";
            Util.issueDesc = "";
            Util.location = "";
            Util.subLocation = "";
            Util.specLocation = "";
            Util.locationDetails = "";
            Util.dateCreated = DateTime.Now.ToString();
            Util.dueDate = DateTime.Now.ToString();
            Util.daysOpen = "";

            Util.Owner = "";
            Util.assignedTo = "";

            Util.EscalStartDate = DateTime.Now.ToString();
            Util.esomRef = "";
            Util.ActionPlan = "";
            Util.MaterialsNeeded = "";
            Util.EscalComm = "";
            Util.Manager = "";
            Util.TechnicianAssigned = "";
            Util.EscalCompBy = "";  //Util.EscalCompBy;
            Util.EscalComplDate = DateTime.Now.ToString();
            Util.departmentEsom = "";

            Util.closedBy = "";
            Util.ClosingDate = DateTime.Now.ToString();
            Util.closingComment = "";
            Util.followUp = "";

            Util.HLRFReport = "";
            Util.ContractorFReport = "";


            Util.newItem = true;
            Util.RecordType = "Contractor";

            ContractorRecordSharma form = new ContractorRecordSharma();
            form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed
            form.ShowDialog();
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

            TechIntTracker dp = new TechIntTracker();
            var tracks = (from x in pd.TechIntTrackers
                         select x).OrderByDescending(v => v.TrackId);
            PdfPTable table = new PdfPTable(8);
            PdfPCell cell = new PdfPCell(new Phrase("Int Track List  - " + DateTime.Now.Date.ToShortDateString().Replace("/", ".").ToString()));

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



            foreach (var track in tracks)
            {                
                table.AddCell(new PdfPCell(new Phrase((track.TrackId.ToString()))) { MinimumHeight = 25, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_MIDDLE });
                table.AddCell(new PdfPCell(new Phrase((track.Type))) { MinimumHeight = 25, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_MIDDLE });
                table.AddCell(new PdfPCell(new Phrase((track.Status))) { MinimumHeight = 25, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
                table.AddCell(new PdfPCell(new Phrase((track.Priority))) { MinimumHeight = 25, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
                table.AddCell(new PdfPCell(new Phrase((track.IssueDescription))) { MinimumHeight = 25, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
                table.AddCell(new PdfPCell(new Phrase((track.Location))) { MinimumHeight = 25, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
                table.AddCell(new PdfPCell(new Phrase((track.DateCreated.ToString()))) { MinimumHeight = 25, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });
                table.AddCell(new PdfPCell(new Phrase((track.ReportedBy))) { MinimumHeight = 25, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_MIDDLE });

            }





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
        //    int colNum = IntTrackerView.Columns.Count;

        //    // Set first ROW as Column Headers Text
        //    foreach (ColumnHeader ch in IntTrackerView.Columns)
        //    {
        //        x++;
        //        wSheet.Cells[x2, x] = ch.Text;
        //        wSheet.Cells[x2, x].Font.Bold = true;
        //        wSheet.Cells[x2, x].Font.Size = 14;
        //        wSheet.Cells[x2, x].Borders.Value = 1;
        //        wSheet.Cells[x2, x].Borders.LineStyle = Excel.XlLineStyle.xlDouble;

        //        //x++;
        //    }

        //    foreach (ListViewItem lvi in IntTrackerView.Items)
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
                SelectIntTracker(IntTrackerView);
        }

        private void firstLbl_Click(object sender, EventArgs e)
        {
            pgNrTbox.Text = "1";
            SelectIntTracker(IntTrackerView);
        }

        private void lastLbl_Click(object sender, EventArgs e)
        {
            pgNrTbox.Text = totalPageslbl.Text;
            SelectIntTracker(IntTrackerView);
        }

        private void prevLbl_Click(object sender, EventArgs e)
        {
            pgNrTbox.Text = Convert.ToInt32(pgNrTbox.Text) > 1 ? (Convert.ToInt32(pgNrTbox.Text) -1).ToString() : pgNrTbox.Text;
            SelectIntTracker(IntTrackerView);
        }

        private void nextLbl_Click(object sender, EventArgs e)
        {
            pgNrTbox.Text = Convert.ToInt32(pgNrTbox.Text) < Convert.ToInt32(totalPageslbl.Text) ? (Convert.ToInt32(pgNrTbox.Text) + 1).ToString() : pgNrTbox.Text;
            SelectIntTracker(IntTrackerView);
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            IntTrackerFormInfo form = new IntTrackerFormInfo();
            form.ShowDialog();
        }

        private void infoBtn_MouseHover(object sender, EventArgs e)
        {
            infoToolTip.Show("Click to display info of the page!", infoBtn);
        }

        private void AlYambtn_Click(object sender, EventArgs e)
        {
            SelectIntTracker(IntTrackerView);
        }

        //private void SharmaBtn_Click(object sender, EventArgs e)
        //{
        //    SelectIntTracker(IntTrackerView);
        //}

        private void IntTrackerView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IntTrackerView.SelectedItems.Count > 0)
            {
                int trackId = Convert.ToInt32(IntTrackerView.SelectedItems[0].SubItems[0].Text);

                var query = from x in pd.TechIntTrackerSharmas
                            where x.TrackId == trackId

                            select new
                            {
                                //x.TrackId,
                                x.Type,
                                x.Status,
                                x.IssueDescription,
                                x.Location,
                                x.SublocationArea,
                                x.SpecificLocation,
                                x.LocationDetails,

                                x.DateCreated,
                                x.ReportedBy,
                                x.Priority,
                                x.DepartmentRef,
                                x.DepartmentEsom,
                                x.DepartmentInternal,
                                //x.Position,
                                x.AssignedTo,
                                x.EscalatedTo

                            };

                foreach (var x in query)
                {
                    // Util.trackId = Convert.ToInt32(x.TrackId);
                    Util.RecordType = x.Type;
                    Util.status = x.Status;
                    Util.issueDesc = x.IssueDescription;
                    Util.location = x.Location;
                    Util.subLocation = x.SublocationArea;
                    Util.specLocation = x.SpecificLocation;
                    Util.locationDetails = x.LocationDetails;
                    Util.dateCreated = x.DateCreated.ToString();
                    Util.reportedBy = x.ReportedBy;
                    Util.priority = x.Priority;
                    Util.departmentRef = x.DepartmentRef;
                    Util.departmentEsom = x.DepartmentEsom;
                    Util.departmentInternal = x.DepartmentInternal;
                   // Util.position = x.Position;
                    Util.assignedTo = x.AssignedTo;
                    Util.escalatedTo = x.EscalatedTo;
                }
            }
        }

        private void IntTrackerView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //IntTrackerView.Items[e.Item.Index].Checked = true;

            ListView.CheckedListViewItemCollection checkedItems =
            IntTrackerView.CheckedItems;

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
            int i2 = 6;//row for data
            int x = 2;
            int x2 = 5;
            int colNum = IntTrackerView.Columns.Count;

            //foreach (ColumnHeader ch in IntTrackerView.Columns)
            //{

            //    x++;

            //    // wSheet.Range["B2:D3"].Rows[1].Merge();
            //    x++;
            //}

            //Microsoft.Office.Interop.Excel.Borders border = wSheet.Cells.Borders;
            //border[XlBordersIndex.xlEdgeLeft].LineStyle =
            //    Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            //border[XlBordersIndex.xlEdgeTop].LineStyle =
            //    Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            //border[XlBordersIndex.xlEdgeBottom].LineStyle =
            //    Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            //border[XlBordersIndex.xlEdgeRight].LineStyle =
            //    Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            wSheet.Cells[2, 2].Value = "INT TRACK LIST SHARMA PALACE";
            wSheet.Cells[2, 2].Font.Bold = true;
            wSheet.Cells[2, 2].Font.Size = 16;
            wSheet.Cells[2, 2].Font.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            wSheet.Cells[2, 2].Borders.Value = 1;
            wSheet.Cells[2, 2].Borders.LineStyle = Excel.XlLineStyle.xlDouble;
            wSheet.Cells[2, 2].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.MidnightBlue);
            wSheet.Cells[2, 2].RowHeight = 150;
            wSheet.Range["B:AH"].Rows[2].Merge();
            //wSheet.Rows[2].Height = 150;


            wSheet.Cells[3, 2].Value = "Identification of Task";
            wSheet.Cells[3, 2].Font.Bold = true;
            wSheet.Cells[3, 2].Font.Size = 14;
            wSheet.Cells[3, 2].Font.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            wSheet.Cells[3, 2].Borders.Value = 1;
            wSheet.Cells[3, 2].Borders.LineStyle = Excel.XlLineStyle.xlDouble;
            wSheet.Cells[3, 2].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSlateGray);
            //wSheet.Cells[3, 2].RowHeight = 150;
            wSheet.Range["B:K"].Rows[3].Merge();

            wSheet.Cells[3, 12].Value = "Company Owner (Work assignment )";
            wSheet.Cells[3, 12].Font.Bold = true;
            wSheet.Cells[3, 12].Font.Size = 14;
            wSheet.Cells[3, 12].Font.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            wSheet.Cells[3, 12].Borders.Value = 1;
            wSheet.Cells[3, 12].Borders.LineStyle = Excel.XlLineStyle.xlDouble;
            wSheet.Cells[3, 12].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSlateGray);
            wSheet.Range["L:Q"].Rows[3].Merge();

            wSheet.Cells[3, 18].Value = "Work Completion";
            wSheet.Cells[3, 18].Font.Bold = true;
            wSheet.Cells[3, 18].Font.Size = 14;
            wSheet.Cells[3, 18].Font.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            wSheet.Cells[3, 18].Borders.Value = 1;
            wSheet.Cells[3, 18].Borders.LineStyle = Excel.XlLineStyle.xlDouble;
            wSheet.Cells[3, 18].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSlateGray);
            wSheet.Range["R:AA"].Rows[3].Merge();


            wSheet.Cells[3, 28].Value = "Work closed and documented";
            wSheet.Cells[3, 28].Font.Bold = true;
            wSheet.Cells[3, 28].Font.Size = 14;
            wSheet.Cells[3, 28].Font.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            wSheet.Cells[3, 28].Borders.Value = 1;
            wSheet.Cells[3, 28].Borders.LineStyle = Excel.XlLineStyle.xlDouble;
            wSheet.Cells[3, 28].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSlateGray);
            wSheet.Range["AB:AF"].Rows[3].Merge();

            wSheet.Cells[3, 33].Value = "Final Reports";
            wSheet.Cells[3, 33].Font.Bold = true;
            wSheet.Cells[3, 33].Font.Size = 14;
            wSheet.Cells[3, 33].Font.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            wSheet.Cells[3, 33].Borders.Value = 1;
            wSheet.Cells[3, 33].Borders.LineStyle = Excel.XlLineStyle.xlDouble;
            wSheet.Cells[3, 33].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSlateGray);
            wSheet.Range["AG:AH"].Rows[3].Merge();

            //oRange = SHEET2.get_Range("a1", "a10");
            //oRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous;
            //oRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
            //oRange.Borders.get_Item(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous;
            //oRange.Borders.get_Item(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous;

            // Set first ROW as Column Headers Text
            foreach (ColumnHeader ch in IntTrackerView.Columns)
            {
                //x++;


                wSheet.Cells[x2, x] = ch.Text;
                //wSheet.Cells[x2, x].RowHeight = 352;
                //wSheet.Rows.RowHeight(40);
                wSheet.Cells[x2, x].Font.Bold = true;
                wSheet.Cells[x2, x].Font.Size = 14;
                wSheet.Cells[x2, x].Borders.Value = 1;
                wSheet.Cells[x2, x].Borders.LineStyle = Excel.XlLineStyle.xlDouble;
                //wSheet.Cells[x2, x].Cells.RowHeight = 150;

                x++;
            }

            wSheet.get_Range("A1", "AH5").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            wSheet.get_Range("A1", "AH5").Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //wSheet.get_Range("A1", "AH5").Cells.Font.FontStyle = "Arial";

            //wSheet.get_Range("A2", "AH3").Cells.RowHeight = 350;




            if (option == "currentPage")
            {
                foreach (ListViewItem lvi in IntTrackerView.Items)
                {
                    i = 1;
                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        i++;
                        wSheet.Cells[i2, i] = lvs.Text;
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        if(lvs.Text == "HIGH")
                        wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        if (lvs.Text == "CRITICAL")
                            wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Crimson);
                        if (lvs.Text == "URGENT")
                            wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.OrangeRed);
                        if (lvs.Text == "During")
                            wSheet.Cells[i2, 6].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSteelBlue);
                        if (lvs.Text == "After")
                            wSheet.Cells[i2, 6].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        //i++;
                    }
                    i2++;
                }
                Excel.Range range = wSheet.get_Range("B6:AH"+(i2-1), Type.Missing);
                range.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);               

                range.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                range.Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //range3.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //range3.Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                //Excel.Range range2 = wSheet.get_Range("G6:G" + (i2 - 1), Type.Missing);
                //range2.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                //Excel.Range range3 = wSheet.get_Range("U6:V" + (i2 - 1), Type.Missing);
                //range3.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            }
   

            if (option == "wholeList")
            {

                    var tracks = (from y in pd.TechIntTrackerSharmas
                                    where y.Status != "Cancelled"
                                    select y).OrderByDescending(v => (int)v.TrackId);

                    int j = 1;
                    i2 = 6;

                    foreach (var track in tracks)
                    {


                        i = 1;

                        ListViewItem lviIntTrackExcel = new ListViewItem();

                        foreach (ListViewItem.ListViewSubItem lvs in lviIntTrackExcel.SubItems)
                        {
                            i++;
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.TrackId.ToString();
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.Type != null ? track.Type.ToString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.Status != null ? track.Status.ToString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.Priority.ToString();

                            if (track.Priority.ToString() == "HIGH")
                                wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            if (track.Priority.ToString() == "CRITICAL")
                                wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Crimson);
                            if (track.Priority.ToString() == "URGENT")
                                wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.OrangeRed);

                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.DuringAfterVisit != null ? track.DuringAfterVisit.ToString() : "";

                            if (track.DuringAfterVisit != null && track.DuringAfterVisit.ToString() == "During")
                                wSheet.Cells[i2, 6].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSteelBlue);
                            if (track.DuringAfterVisit != null && track.DuringAfterVisit.ToString() == "After")
                                wSheet.Cells[i2, 6].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.IssueDescription.ToString();

                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.Location.ToString();
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.SublocationArea != null ? track.SublocationArea.ToString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.SpecificLocation != null ? track.SpecificLocation.ToString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.LocationDetails != null ? track.LocationDetails.ToString() : "";

                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.DateCreated != null ? DateTime.Parse(track.DateCreated.ToString()).ToShortDateString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.DueByDate != null ? DateTime.Parse(track.DueByDate.ToString()).ToShortDateString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.DaysOpen != null ? track.DaysOpen.ToString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.ReportedBy != null ? track.ReportedBy.ToString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.Owner != null ? track.Owner.ToString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.AssignedTo != null ? track.AssignedTo.ToString() : "";

                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.DepartmentEsom != null ? track.DepartmentEsom.ToString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.Manager != null ? track.Manager.ToString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.TechnicianAssigned != null ? track.TechnicianAssigned.ToString() : "";

                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.EscalationStartDate.ToString();
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.EsomRef != null ? track.EsomRef.ToString() : "";                            
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.EscalationComments != null ? track.EscalationComments.ToString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.ActionPlan != null ? track.ActionPlan.ToString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.MaterialsNeeded != null ? track.MaterialsNeeded.ToString() : "";                            
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.EscalationComplDate.ToString();
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.EscalCompletedBy != null ? track.EscalCompletedBy.ToString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.LastUpdate != null ? track.LastUpdate.ToString() : "";


                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.ClosingDate != null ? DateTime.Parse(track.ClosingDate.ToString()).ToShortDateString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.ClosedBy != null ? track.ClosedBy.ToString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.ClosingComment != null ? track.ClosingComment.ToString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.FollowUp != null ? track.FollowUp.ToString() : "";
                           
                              
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.ContractorFReport != null ? track.ContractorFReport.ToString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = track.HLRFinalReport != null ? track.HLRFinalReport.ToString() : "";

                    }
                        i2++;
                    }
                    //}
                     Excel.Range range = wSheet.get_Range("B6:AH"+(i2-1), Type.Missing);
                    range.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
                    range.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    range.Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    //Excel.Range range2 = wSheet.get_Range("G6:G" + (i2 - 1), Type.Missing);                
                    //range2.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    //range2.Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    //i2++;
                    //}

            }



            // AutoSet Cell Widths to Content Size
            wSheet.Cells.Select();
            //wSheet.Cells.EntireColumn.AutoFit();
            wSheet.Columns.AutoFit();
            wSheet.Rows.AutoFit();


            Range line = (Range)wSheet.Rows[5];
            line.Insert();
            var filter = wSheet.Cells[5, x].AutoFilter();

            Excel.Range TempRange = wSheet.get_Range("B4", "B5");

            // 1. To Delete Entire Row - below rows will shift up
            TempRange.EntireRow.Delete(Type.Missing);

            //// 2. To Delete Cells - Below cells will shift up
            //TempRange.Cells.Delete(Type.Missing);

            //// 3. To clear Cells - No shifting
            //TempRange.Cells.Clear();
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
            string fileName = "Int Track List Sharma -" + date + " by " + Util.userConnected;

            //check if shared folder is synced, otherwise save locally
            string subPath = currentUserPath + "\\Hill Robinson\\Project Sharma - Shared\\Technical\\TaskAlocationSharma\\";

            bool exists = Directory.Exists(subPath);
                //Directory.Exists(System.Web.Hosting.HostingEnvironment.MapPath(subPath));
            bool continueOperation = false;

            if (!exists)
            {
                DialogResult dialogResult = MessageBox.Show("Destination shared drive folder does not exist. Do you want to save locally?", "Destination folder error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (dialogResult == DialogResult.Yes)
                {
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    // Show the FolderBrowserDialog.
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        System.Windows.Forms.TextBox textBox1 = new System.Windows.Forms.TextBox();
                        textBox1.Text = folderDlg.SelectedPath;
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        currentUserPath = (textBox1.Text + "\\").ToString();
                        continueOperation = true;
                    }
                }

            }
            if (exists || (!exists & continueOperation))
            { 
                wBook.SaveAs(@currentUserPath + (!continueOperation ? "\\Hill Robinson\\Project Sharma - Shared\\Technical\\TaskAlocationSharma\\Int Track List Sharma - " : "") + fileName + ".xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
                excel.ActiveWindow.Close();

                //insert in log table
                int UserId = Util.userIdConnected;
                string exportOption = option == "currentPage" ? "current page" : (option == "wholeList" ? "whole list" : "selected list");
                string Action = "Excel export - " + exportOption + (continueOperation ? " saved locally " : "");
                string TableInvolved = "TechIntTrackerSharma";
                string Description = "Exported " + exportOption + " of Int Tracker List: " + fileName;
                DateTime UpdateTime = DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                string MachineName = Util.userMachine;
                string Macc = Util.userMachineMacc;
                string IPAdress = Util.userIp;
                string CreatedByWinAcc = Util.windowsAccount;

                insertLog(UserId, Action, TableInvolved, Description, UpdateTime, MachineName, Macc, IPAdress, CreatedByWinAcc);
            }
        }

        public void insertLog(int UserId, string Action, string TableInvolved, string Description, DateTime UpdateTime, string MachineName, string Macc, string IPAdress, string CreatedByWinAcc)
        {
            IPAdress = Util.userIp;
            // string[] format = new[] { "MM/dd/yyyy" };
            HistoryLog dp = new HistoryLog()
            {
                UserId = Util.userIdConnected,
                Action = Action,
                TableInvolved = TableInvolved,
                Description = Description,
                UpdateTime = UpdateTime,
                HostMachine = MachineName,
                HostMaccAdress = Macc,
                IPAdress = IPAdress,
                WindowsAccount = CreatedByWinAcc

            };


            try
            {
                pd.HistoryLogs.InsertOnSubmit(dp);
                pd.SubmitChanges();
                //MessageBox.Show("Data was successfully saved!");

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Data was not saved!" + ex.Message);
            }

        }

        private void rBtnSharma_CheckedChanged(object sender, EventArgs e)
        {
           // SharmabtnState = true;
           // AlYamamabtnState = false;
           // Util.Sharmabtn = true;
           // Util.AlYamamabtn = false;
           //SelectIntTracker(IntTrackerView);//Sharma
        }

        private void rBtnAlYamama_CheckedChanged(object sender, EventArgs e)
        {
            //AlYamamabtnState = true;
            //SharmabtnState = false;
            //Util.AlYamamabtn = true;
            //Util.Sharmabtn = false;
            //SelectIntTracker(IntTrackerView);
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
            //add
            if (cBoxOpen.Checked == true && cBoxAll.Checked == false)
                Util.StatusString += "Open, ";
            if(cBoxInProgress.Checked == true && cBoxAll.Checked == false)
                Util.StatusString += "In progress, ";
            if (cBoxAll.Checked == true)
                Util.StatusString = "";
            if (InternalcheckBox.Checked == true)
                Util.TypeString += "Internal, ";
            if (ContractorcheckBox.Checked == true)
                Util.TypeString += "Contractor, ";
            //last comma

            //remove
            if (cBoxOpen.Checked == false && cBoxAll.Checked == false && Util.StatusString!= String.Empty)
                Util.StatusString = Util.StatusString.Contains("Open, ") ? Util.StatusString.Replace("Open, ", "") : Util.StatusString.Replace("Open", "");
            if (cBoxOpen.Checked == false && cBoxAll.Checked == true)
                cBoxAll.Checked = false;
            if (cBoxInProgress.Checked == false && cBoxAll.Checked == false && Util.StatusString != String.Empty)
                Util.StatusString = Util.StatusString.Contains("In progress, ") ? Util.StatusString.Replace("In progress, ", "") : Util.StatusString.Replace("In progress", "");
            if (cBoxInProgress.Checked == false && cBoxAll.Checked == true)
                cBoxAll.Checked = false;

            //Util.TypeString = "Internal, Contractor";

            if (InternalcheckBox.Checked == false && Util.TypeString != String.Empty)
                Util.TypeString = Util.TypeString.Contains("Internal, ") ? Util.TypeString.Replace("Internal, ", "") : Util.TypeString.Replace("Internal", "");
            if (ContractorcheckBox.Checked == false && Util.TypeString != String.Empty)
                Util.TypeString = Util.TypeString.Contains("Contractor, ") ? Util.TypeString.Replace("Contractor, ", "") : Util.TypeString.Replace("Contractor", "");

            //select
            if (rBtnToday.Checked == true)
            {
                Util.today = 1;
                Util.curWeek = 0;
                Util.curMonth = 0;
                Util.wholeList = 0;
            }
            if (rBtnCurrentWeek.Checked == true)
            {
                Util.curWeek = 1;
                Util.today = 0;
                Util.curMonth = 0;
                Util.wholeList = 0;
            }
            if(rBtnCurrentMonth.Checked == true)
            {
                Util.curMonth = 1;
                Util.curWeek = 0;
                Util.today = 0;
                Util.wholeList = 0;
            }
            if (rBtnWholelist.Checked == true)
            {
                Util.wholeList = 1;
                Util.today = 0;
                Util.curWeek = 0;
                Util.curMonth = 0;
            }
            //pgNrTbox.Text = "1";

            SelectIntTracker(IntTrackerView);
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
            if (cBoxOpen.Checked == false && cBoxAll.Checked == true)
                cBoxOpen.Checked = true;
            if (cBoxInProgress.Checked == false && cBoxAll.Checked == true)
                cBoxInProgress.Checked = true;
            quickFilterOption();
        }

        private void SearchTBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchApplybtn_Click(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbSession.Text = Util.currentSession;
        }

        private void cloneTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.newItem = true;

            IntTrackerView_SelectedIndexChanged(sender, e);
            Util.status = "Open";
            Util.dateCreated = DateTime.Now.ToString();


            if (Util.RecordType == "Contractor")
            {
                ContractorRecordSharma form = new ContractorRecordSharma();
                form.ShowDialog();
            }
            else if (Util.RecordType == "Internal")
            {
                //InternalRecordAlYamama form = new InternalRecordAlYamama();
                //form.ShowDialog();
            }
        }

        //private void lbSession_Validated(object sender, EventArgs e)
        //{
        //    lbSession.Text = Util.currentSession;
        //}

        //private void lbSession_Validating(object sender, CancelEventArgs e)
        //{
        //    lbSession.Text = Util.currentSession;
        //}
    }
}
