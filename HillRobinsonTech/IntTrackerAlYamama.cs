using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Reflection;
//using static BrightIdeasSoftware.TreeListView;
//using ObjectListView2012;

namespace HillRobinsonTech
{
    public partial class IntTrackerAlYamama : Form
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
        
        public IntTrackerAlYamama()
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

            Util.AlYamamabtn = true;
            Util.Sharmabtn = false;
            if (Util.departmentConnected == "Technical")            
               Util.TypeString = "Internal, Contractor";            
            else
            {
                Util.TypeString = "Internal";
                ContractorcheckBox.Checked = false;
            }
            Util.StatusString = "Open, In progress";
            //quickFilterOption();

            if (Util.userTypeConnected == "guest")
            {
                ExportToolStripMenuItem.Enabled = false;
            }
            if(Util.departmentConnected != "Technical")
            {
                currentPageExcelToolStripMenuItem.Visible = false;
                wholeListExcelToolStripMenuItem.Visible = false;
                internalListExcelToolStripMenuItem.Visible = true;
                contractorToolStripMenuItem.Visible = false;
                groupBoxWeeklyReport.Visible = false;
                btnReportSwap.Visible = false;
            }

            Notificationslbl.Text = "15";
            getDataWeeklyReport();

            //weekle report create/check if already created current week data


            //scheduled task
            //if (RunOnStartUp)
            //    hour = -1;

        }

        private void IntTracker_Load(object sender, EventArgs e)
        {
            SelectIntTracker(IntTrackerView);
            SearchcBox.SelectedIndex = 0;          
        }

        public void getDataWeeklyReport()
        {
            int i = 1;
            bool noRows = true;
            //int j = 1;
            int pageNr = (pgNrTbox.Text != "" ? Convert.ToInt32(pgNrTbox.Text) : 1);
            int totalRows = 0;
            int curRow = 0;
            DateTime startDate;
            DateTime endDate;
            string curWReportSDay = "";
            string curWReportSMonth = "";
            string curWReportSYear = "";
            string curWReportEDay = "";
            string curWReportEMonth = "";           
            string curWReportEYear = "";
            string CurWReportDate = "";

            UnivSource.connection.Open();
            System.Data.DataTable TrackDt = new System.Data.DataTable();
            System.Data.DataTable TrackDtAllRows = new System.Data.DataTable();
            DataSet ds = null;
            SqlDataAdapter da = null;

            string dbo = "[avitsql].[GetDataWeeklyReport]";

            using (SqlCommand cmd = new SqlCommand(dbo, UnivSource.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PreviousWReport", SqlDbType.VarChar).Value = Util.PreviousWReport;

                cmd.ExecuteNonQuery();

                using (da = new SqlDataAdapter(cmd))
                {
                    ds = new DataSet();
                    da.Fill(ds);

                }

                TrackDt = ds.Tables["Table"];              

                if (TrackDt.Rows.Count == 1)
                foreach (DataRow row in TrackDt.Rows)
                {
                    lblWStartWO.Text = row["WeekStartingOpenWO"].ToString();
                    lblRaisedWO.Text = row["RaisedWO"].ToString();
                    lblCompletedWO.Text = row["ClosedWO"].ToString();
                    lblWClosingWO.Text = row["WeekClosingOpenWO"].ToString();
                    startDate = Convert.ToDateTime( row["ThursdayOfPreviousOrCurrentWeek"].ToString());
                    endDate = Convert.ToDateTime(row["WednesdayOfCurrentOrNextWeek"].ToString());

                    curWReportSDay = startDate.Day.ToString();
                    curWReportEDay = endDate.Day.ToString();
                    curWReportSMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(startDate.Month); //startDate.Month.ToString("MMM");//DateTime.Now.ToString("dd MMM yyyy
                    curWReportEMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(endDate.Month); //endDate.Month.ToString("MMM");
                    curWReportSYear = startDate.Year.ToString();
                    curWReportEYear = endDate.Year.ToString();
                        
                        //start date
                        CurWReportDate = curWReportSDay;

                        if (curWReportSMonth.Equals(curWReportEMonth))
                            CurWReportDate += " - " + curWReportEDay + " " + curWReportSMonth;
                        else
                            CurWReportDate += " " + curWReportSMonth + " - " + curWReportEDay + " " + curWReportEMonth;

                        if (curWReportSYear.Equals(curWReportEYear))
                            CurWReportDate += " " + curWReportSYear;
                        else
                            CurWReportDate = curWReportSDay + " " + curWReportSMonth + " " + curWReportSYear + " - " + curWReportEDay + " " + curWReportEMonth + " " + curWReportEYear;
                        //final date display
                        lblWReportTime.Text = CurWReportDate;
                        Util.WeeklyCurrentReportStartDate = row["ThursdayOfPreviousOrCurrentWeek"].ToString();
                        Util.WeeklyCurrentReportEndDate = row["WednesdayOfCurrentOrNextWeek"].ToString();


                        updateDataWeeklyReportDBO();
                    }
            }
            UnivSource.connection.Close();
        }
        public void updateDataWeeklyReportDBO()
        {
            //check first if any records for current week saved in Reports
            bool currentReportExists = false;
            DateTime lastStartDate;

             var query = from x in pd.Reports                            
                        where x.ReportingType == "Weekly"

                        select new
                        {
                            x.StartTime,
                            x.EndTime,
                            x.WeekStartOpenWO,
                            x.RaisedWO,
                            x.ClosedWO,
                            x.WeekEndedOpenWO,
                            x.Details                            
                        };
            lastStartDate = query.Max(r => (DateTime)r.StartTime);

            //if (DateTime.Parse(Util.WeeklyCurrentReportStartDate) == lastStartDate)
            //    currentReportExists = true;

            //if (!currentReportExists )
            //{
            //    Report dp = new Report()
            //    {
            //        ReportingType = "Weekly".ToString(),
            //        StartTime = DateTime.Parse(Util.WeeklyCurrentReportStartDate),
            //        EndTime = DateTime.Parse(Util.WeeklyCurrentReportEndDate),
            //        //WeekStartOpenWO =
            //        //RaisedWO =
            //        //ClosedWO = 
            //        //WeekEndedOpenWO = 
            //        //Details = 
            //        UpdateTime = DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)                    
            //    };


            //    try
            //    {
            //        pd.Reports.InsertOnSubmit(dp);
            //        pd.SubmitChanges();
            //        //MessageBox.Show("Data was successfully saved!");
            //    }
            //    catch (Exception ex)
            //    {
            //        ///MessageBox.Show("Data was not saved!" + ex.Message);
            //    }
            //}
            //DateTime.Parse(Util.CompDateIn).ToString("yyyy-MM-dd")
        }

        private void getDataCallProcedure()
        {
            int i = 1;
            bool noRows = true; 
            //int j = 1;
            int pageNr = (pgNrTbox.Text != "" ? Convert.ToInt32(pgNrTbox.Text) : 1);
            int totalRows = 0;
            int curRow = 0;

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

            string dbo = "[avitsql].[GetData]";

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
                        lviIntTrack.SubItems.Add(row["IssueDescription"].ToString());
                        lviIntTrack.SubItems.Add(row["Location"].ToString());
                        lviIntTrack.SubItems.Add(row["SublocationArea"].ToString() != null ? row["SublocationArea"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["SpecificLocation"].ToString() != null ? row["SpecificLocation"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["LocationDetails"].ToString() != null ? row["LocationDetails"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["DateCreated"].ToString() != null ? row["DateCreated"].ToString() : "");//DateTime.Parse(track.DateCreated.ToString()).ToShortDateString()

                        //lviIntTrack.SubItems.Add(track.DateReceived.ToString()); // DateTime.Parse(track.DateReceived.ToString()).ToShortDateString());
                        lviIntTrack.SubItems.Add(row["ReportedBy"].ToString());
                        lviIntTrack.SubItems.Add(row["DepartmentEsom"].ToString() != null ? row["DepartmentEsom"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["AssignedTo"].ToString() != null ? row["AssignedTo"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["AssignedToPerson"].ToString() != null ? row["AssignedToPerson"].ToString() : "");
                                       
                       
                        lviIntTrack.SubItems.Add(row["EsomRef"].ToString());
                        lviIntTrack.SubItems.Add(row["EscalationComments"].ToString());
                        lviIntTrack.SubItems.Add(row["EscalCompletedBy"].ToString());
                        lviIntTrack.SubItems.Add(row["EscalationStartDate"].ToString() != null && row["EscalationStartDate"].ToString() != Util.NADate.ToString() ? row["EscalationStartDate"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["Manager"].ToString());
                        lviIntTrack.SubItems.Add(row["TechnicianAssigned"].ToString());
                        lviIntTrack.SubItems.Add(row["EscalationComplDate"].ToString() != null && row["EscalationComplDate"].ToString() != Util.NADate.ToString() ? row["EscalationComplDate"].ToString() : "");


                        //lviIntTrack.SubItems.Add(row["ReportDate"].ToString());   /// DateTime.Parse(track.ReportDate.ToString()).ToShortDateString());

                        lviIntTrack.SubItems.Add(row["ClosingComment"].ToString());
                        lviIntTrack.SubItems.Add(row["ClosedBy"].ToString() != null ? row["ClosedBy"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["ClosingDate"].ToString() != null && row["ClosingDate"].ToString() != Util.NADate.ToString() ? row["ClosingDate"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["FollowUp"].ToString());
                        lviIntTrack.SubItems.Add(row["LastUpdate"].ToString() != null ? row["LastUpdate"].ToString() : "");



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

                int itemsPerLastPage = 0;
                int lastPage = 0;


                totalPageslbl.Text = (totalRows % 32) == 0 ? (totalRows / 32).ToString() : ((totalRows / 32) + 1).ToString();
                lastPage = (totalRows % 32) == 0 ? (totalRows / 32) : ((totalRows / 32) + 1);
                itemsPerLastPage = totalRows != 32 ? totalRows % 32 : totalRows;
                if (pageNr < lastPage)
                    showlbl.Text = "Displaying 32 item(s) of " + totalRows;
                if (pageNr == lastPage)
                    showlbl.Text = "Displaying " + itemsPerLastPage + " item(s) of " + totalRows;

                if(noRows)
                    showlbl.Text = "Displaying 0 item(s) of 0";

            }
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
            IntTrackerView.Columns.Add("Issue Description", 700);

            IntTrackerView.Columns.Add("Location", -2);
            IntTrackerView.Columns.Add("Sublocation", -2);
            IntTrackerView.Columns.Add("Specific location", -2);
            IntTrackerView.Columns.Add("Location details", -2);
            IntTrackerView.Columns.Add("Date Created", -2);

            //Internal Escalation
           // IntTrackerView.Columns.Add("Date Received");
            IntTrackerView.Columns.Add("Reported By", 120);
            IntTrackerView.Columns.Add("Department Esom", 170);
            IntTrackerView.Columns.Add("Assigned to", -2);
            IntTrackerView.Columns.Add("Person in charge", -2);
            //IntTrackerView.Columns.Add("Department Ref", -2);
            //IntTrackerView.Columns.Add("Internal Department", -2);
            // IntTrackerView.Columns.Add("Escalated to");
            IntTrackerView.Columns.Add("Esom Ref", 100);
            IntTrackerView.Columns.Add("Escalation comments", 350);
            IntTrackerView.Columns.Add("Escalation Completed By", -2);
            IntTrackerView.Columns.Add("Escalation start date", -2);
            IntTrackerView.Columns.Add("Manager", -2);
            IntTrackerView.Columns.Add("Technician assigned", 220);
            IntTrackerView.Columns.Add("Escalation completion date", -2);


            //Contractor                       
            //IntTrackerView.Columns.Add("Report Date", -2);

            //Close Out
            IntTrackerView.Columns.Add("Closing Comment", 230);
            IntTrackerView.Columns.Add("Closed by", 150);
            IntTrackerView.Columns.Add("Closing Date", -2);

            //Follow up
            IntTrackerView.Columns.Add("Follow up", 200);

            IntTrackerView.Columns.Add("Last Update", -2);

            //IntTrackerView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //IntTrackerView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


            //ResizeListViewColumns(IntTrackerView);
        }

        //public void ResizeListViewColumns(ListView IntTrackerView) //, int autoSizeColumnIndex)
        //{
        //    //// Sum up the width of all columns except the auto-resizing one.
        //    //int otherColumnsWidth = 0;
        //    //foreach (ColumnHeader header in IntTrackerView.Columns)
        //    //    if (header.Index != autoSizeColumnIndex)
        //    //        otherColumnsWidth += header.Width;

        //    //// Calculate the (possibly) new width of the auto-resizable column.
        //    //int autoSizeColumnWidth = IntTrackerView.ClientRectangle.Width - otherColumnsWidth;

        //    //// Finally set the new width of the auto-resizing column, if it has changed.
        //    //if (IntTrackerView.Columns[autoSizeColumnIndex].Width != autoSizeColumnWidth)
        //    //    IntTrackerView.Columns[autoSizeColumnIndex].Width = autoSizeColumnWidth;

        //    //for (int i = 0; i < IntTrackerView.Columns.Count - 1; i++)
        //    //{
        //    //    //IntTrackerView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        //    //    //IntTrackerView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        //    //}
        //    //    IntTrackerView.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
        //    //IntTrackerView.Columns[IntTrackerView.Columns.Count - 1].Width = -2;
        //    //IntTrackerView.Columns[IntTrackerView.Columns.Count - 1].Width = -2;
        //    //foreach (ColumnHeader column in IntTrackerView.Columns)
        //    //{
        //    //    //    //IntTrackerView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.None);
        //    //    //    //IntTrackerView.Columns[0].Width = 70;
        //    //    //    //IntTrackerView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        //    //    //    //IntTrackerView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        //    //    column.Width = -2;

        //    //}

        //    //this.AutoSizeRowHeight = true;

        //    //int HeaderWidth = (IntTrackerView.Parent.Width - 2) / IntTrackerView.Columns.Count;
        //    //foreach (ColumnHeader header in IntTrackerView.Columns)
        //    //{
        //    //    header.Width = HeaderWidth;
        //    //}
        //}
    
        public void SelectIntTracker(ListView IntTrackerView)
        {
            IntTrackerView.Items.Clear();
            getDataCallProcedure();
            getDataWeeklyReport();
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

        public void IntTrackerView_DoubleClick(object sender, EventArgs e)
        {         

            Util.newItem = false;
            if (IntTrackerView.SelectedItems.Count > 0)
            {
                //if (AlYamamabtnState == true)
                //{
                    int trackId = Convert.ToInt32(IntTrackerView.SelectedItems[0].SubItems[0].Text);
                    var query = from x in pd.TechIntTrackers
                                    //TechIntTrackerTests
                                where x.TrackId == trackId

                                select new
                                {
                                    x.TrackId,
                                    x.InternalRef,
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
                                    //x.DepartmentRef,
                                    x.DepartmentInternal,
                                    x.AssignedTo,
                                    x.AssignedToPerson,
                                    x.Position,
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
                                    x.FollowUp,
                                    x.ContractorTrackIdInternal

                                };

                    foreach (var x in query)
                    {
                        Util.trackId = Convert.ToInt32(x.TrackId);
                        Util.InternalRef = x.InternalRef.ToString();
                        Util.RecordType = x.Type;
                        Util.status = x.Status;
                        Util.issueDesc = x.IssueDescription;
                        Util.location = x.Location;
                        Util.subLocation = x.SublocationArea;
                        Util.specLocation = x.SpecificLocation;
                        Util.locationDetails = x.LocationDetails;
                        Util.dateCreated = x.DateCreated.ToString();
                        // Util.dateReceived = x.DateReceived.ToString();
                        Util.reportedBy = x.ReportedBy;
                        Util.priority = x.Priority;
                        Util.position = x.Position;
                        Util.departmentInternal = x.DepartmentInternal;
                        //Util.InternalRef = x.internalRef,
                        Util.assignedTo = x.AssignedTo;
                        Util.assignedToPerson = x.AssignedToPerson;
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
                        Util.ContractorTrackIdInternalRef = x.ContractorTrackIdInternal != null ? (int)x.ContractorTrackIdInternal : 0;
                    }
            }

         

            //IntTrackerEdit form = new IntTrackerEdit();
            if (IntTrackerView.SelectedItems[0].SubItems[1].Text == "Contractor")
            {

                ContractorRecordAlYamama newInstance = new ContractorRecordAlYamama();
                RefreshListEvent += new RefreshList(RefreshListView); // event initialization
                newInstance.UpdateContractor = RefreshListEvent; // assigning event to the Delegate
                newInstance.Show();

               // ContractorRecord form = new ContractorRecord();
               // form.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
               // form.ShowDialog();
            }
            if (IntTrackerView.SelectedItems[0].SubItems[1].Text == "Internal")
            {
                InternalRecordAlYamama newInstance = new InternalRecordAlYamama();
                RefreshListEvent += new RefreshList(RefreshListView); // event initialization
                newInstance.UpdateInternal = RefreshListEvent; // assigning event to the Delegate               
                newInstance.Show();

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
            Util.issueDesc = "";
            Util.location = "";
            Util.subLocation = "";
            Util.specLocation = "";
            Util.locationDetails = "";
            //Util.dateReceived = "";
            Util.reportedBy = "";
            Util.priority = "";
            Util.departmentRef = "";
            Util.departmentInternal = "";
            Util.assignedTo = "";
            Util.assignedToPerson = "";
            Util.escalatedTo = "";
            Util.departmentEsom = "";
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
            Util.EscalComplDate = "";
            Util.Manager = ""; 
            Util.TechnicianAssigned = "";

            Util.newItem = true;

            //IntTrackerEdit form = new IntTrackerEdit();
            //form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed
            //form.ShowDialog();                             
    }
        void child_FormClosedRefresh(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed
            IntTrackerView.Items.Clear();
           
            IntTracker_Load(sender, e);
            //Refresh(sender, e);
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            resetFilters();
            this.Dispose();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            //IntTracker_Load(sender, e);
            IntTrackerView.Items.Clear();
            SelectIntTracker(IntTrackerView);
            //Refresh(sender, e);
        }
        public void Refresh(object sender, EventArgs e)
        {            
            IntTracker_Load(sender, e);
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
                    //loading global variables
                    IntTrackerView_SelectedIndexChanged(sender, e);

                    if (IntTrackerView.SelectedItems[0].SubItems[1].Text == "Internal")
                    {
                        contextMenuStrip1.Items[0].Visible = true;
                        contextMenuStrip1.Items[1].Visible = false;
                        if (!Util.departmentConnected.ToLower().Equals(Util.departmentInternal.ToLower()))
                            contextMenuStrip1.Items[0].Enabled = false;
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



        //    //handle the event for the selected ListViewItem accessing it by
        //    ListViewItem selected_lvi = this.lviIntTrack.SelectedItem as ListViewItem;
        //    if (e.Button == MouseButtons.Right)
        //    {
        //    if (listView1.FocusedItem != null && listView1.FocusedItem.Bounds.Contains(e.Location) == true)
        //    {
        //        ContextMenu m = new ContextMenu();
        //        MenuItem cashMenuItem = new MenuItem("編輯");
        //        cashMenuItem.Click += delegate (object sender2, EventArgs e2)
        //        {
        //            ActionClick(sender, e, id);
        //        };// your action here 
        //        m.MenuItems.Add(cashMenuItem);

        //        MenuItem cashMenuItem2 = new MenuItem("-");
        //        m.MenuItems.Add(cashMenuItem2);

        //        MenuItem delMenuItem = new MenuItem("刪除");
        //        delMenuItem.Click += delegate (object sender2, EventArgs e2)
        //        {
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
                                x.AssignedToPerson,
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
                    Util.assignedToPerson = x.AssignedToPerson;
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
            Util.exportLocation = "Al Yamamah";
            ExportInternalToPDF form = new ExportInternalToPDF();
            form.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (IntTrackerView.SelectedItems.Count > 0)
            {
                //if (AlYamamabtnState == true)
                //{
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
                                    //x.DateReceived,
                                    x.ReportedBy,
                                    x.Priority,
                                    x.DepartmentRef,
                                    x.DepartmentInternal,
                                    x.AssignedTo,
                                    x.AssignedToPerson//,
                                    //x.EscalatedTo,
                                    //x.EscalationComments,
                                    //x.EscalCompletedBy,
                                    //x.EscalationStartDate,
                                    //x.Manager,
                                    //x.TechnicianAssigned,
                                    //x.EscalationComplDate,
                                    //x.DepartmentEsom,
                                    //x.EsomRef,
                                    //x.ReportDate,
                                    //x.ClosingComment,
                                    //x.ClosedBy,
                                    //x.ClosingDate,
                                    //x.FollowUp

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
                        Util.assignedToPerson = x.AssignedToPerson;
                        //Util.escalatedTo = x.EscalatedTo;
                        //Util.EscalComm = x.EscalationComments;
                        //Util.EscalCompBy = x.EscalCompletedBy;
                        //Util.EscalStartDate = Convert.ToDateTime(x.EscalationStartDate.ToString()).ToShortDateString();
                        //Util.Manager = x.Manager != null ? x.Manager.ToString() : "";
                        //Util.TechnicianAssigned = x.TechnicianAssigned != null ? x.TechnicianAssigned.ToString() : "";
                        //Util.EscalComplDate = x.EscalationComplDate.ToString();
                        //Util.departmentEsom = x.DepartmentEsom;
                        //Util.esomRef = x.EsomRef.ToString();
                        //Util.reportDate = x.ReportDate.ToString();
                        //Util.closingComment = x.ClosingComment;
                        //Util.closedBy = x.ClosedBy;
                        //Util.ClosingDate = x.ClosingDate.ToString();
                        //Util.followUp = x.FollowUp;
                    }
                }
           
            Util.exportLocation = "Al Yamamah";
            ExportContractorToPDF form = new ExportContractorToPDF();
            form.ShowDialog();
        }

        private void IntTracker_Load_1(object sender, EventArgs e)
        {
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Util.AlYamamabtn = true;
            //Reset();
            Filters form = new Filters();
            form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed        
            form.ShowDialog();
            //Reset();
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
            //List<string> statusFilterListsReset = new List<string>();
            //Util.statusFilterLists = statusFilterListsReset;
            Util.TrackNoFrom = "";
            Util.TrackNoTo = "";
            if(!cBoxAll.Checked)
            {
                quickFilterOption();
                //if(cBoxOpen.Checked && cBoxInProgress.Checked)
                //Util.StatusString = "Open,In progress";
                //if (cBoxOpen.Checked && cBoxInProgress.Checked)
                //    Util.StatusString = "Open,In progress";

            }
            else              

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


            //if (Util.departmentConnected == "Technical")
            //    Util.TypeString = "Internal, Contractor";
            //else
            //{
            //    Util.TypeString = "Internal";
            //    ContractorcheckBox.Checked = false;
            //}
            //Util.StatusString = "Open, In progress";

        }

        private void ResetFilterbtn_Click(object sender, EventArgs e)
        {
            Reset();
            pgNrTbox.Text = "1";
            IntTracker_Load(sender, e);
        }
             
        private void SearchApplybtn_Click(object sender, EventArgs e)
        {
            Util.SearchBoxFilterUsed = true;
            IntTrackerView.Items.Clear();
            getDataCallProcedure();
        }

        private void ClearSearchBtn_Click(object sender, EventArgs e)
        {
            Util.SearchBoxFilterUsed = false;
            pgNrTbox.Text = "1";
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
            Util.assignedToPerson = "";
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

            InternalRecordAlYamama form = new InternalRecordAlYamama();
            form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed
            form.ShowDialog();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (Util.departmentConnected != "Technical")
            //    ContractorcheckBox.Checked = false;
        }

        private void contractorToolStripMenuItem_Click(object sender, EventArgs e)
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
            Util.RecordType = "Contractor";

            ContractorRecordAlYamama form = new ContractorRecordAlYamama();
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

        private void IntTrackerView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IntTrackerView.SelectedItems.Count > 0)
            {
                int trackId = Convert.ToInt32(IntTrackerView.SelectedItems[0].SubItems[0].Text);

                var query = from x in pd.TechIntTrackers
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
                                x.Position,
                                x.AssignedTo,
                                x.AssignedToPerson,
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
                    Util.position = x.Position;
                    Util.assignedTo = x.AssignedTo;
                    Util.assignedToPerson = x.AssignedToPerson;
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
            DialogResult rezultat = MessageBox.Show("Be aware that exporting the whole list unfiltered could take at least 10 min while the app will stop responding. Do you want to proceed?", "Confirmation", MessageBoxButtons.OKCancel);
            if (rezultat == DialogResult.OK)
            {
                ExportXlsbtn("wholeList");
            }
        }

        private void internalListExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportXlsbtn("internalList");                      
        }

        private void ExportXlsbtn(string option)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //excel.Visible = false;
            //excel.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Workbook wBook = excel.Workbooks.Add(1);
            Microsoft.Office.Interop.Excel.Worksheet wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.Worksheets[1];
            wSheet.Name = "HRL W.O.";

        
            DataSet dset = new DataSet();
            dset.Tables.Add();

            int i = 1;
            int i2 = 2;
            int x = 1;
            int x2 = 1;
            int colNum = IntTrackerView.Columns.Count;

            int criticalOr = 0;
            int urgentOr = 0;
            int highOr = 0;
            int mediumOr = 0;
            int lowOr = 0;
            int totalOr = 0;

            bool statistics = true; //false;

            // Set first ROW as Column Headers Text
            if(option != "internalList" && Util.departmentConnected.ToLower() == "Technical".ToLower())
            foreach (ColumnHeader ch in IntTrackerView.Columns)
            {
                x++;   
                wSheet.Cells[x2, x] = ch.Text;
                wSheet.Cells[x2, x].Font.Bold = true;
                wSheet.Cells[x2, x].Font.Size = 14;
                wSheet.Cells[x2, x].Borders.Value = 1;
                wSheet.Cells[x2, x].Borders.LineStyle = Excel.XlLineStyle.xlDouble;                              
            }

            if(option == "currentPage" && option != "internalList")
            {
                foreach (ListViewItem lvi in IntTrackerView.Items)
                {
                    i = 1;
                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        i++;
                        if ((Util.departmentConnected.ToLower() == "Technical".ToLower()) )
                        {                            
                            wSheet.Cells[i2, i] = lvs.Text;
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            if (lvs.Text == "HIGH")
                                wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            if (lvs.Text == "CRITICAL")
                                wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Crimson);
                            if (lvs.Text == "URGENT")
                                wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.OrangeRed);
                               
                            if (i == 5)
                            {
                                var cellValueStatus = (string)(wSheet.Cells[i2, 4] as Range).Value;

                                if (cellValueStatus.ToLower().Equals("open") || cellValueStatus.ToLower().Equals("in progress"))
                                {
                                    totalOr++;
                                    var cellValuePriority = (string)(wSheet.Cells[i2, 5] as Range).Value;
                                    if (cellValuePriority.ToLower().Equals("critical"))
                                        criticalOr++;
                                    if (cellValuePriority.ToLower().Equals("urgent"))
                                        urgentOr++;
                                    if (cellValuePriority.ToLower().Equals("high"))
                                        highOr++;
                                    if (cellValuePriority.ToLower().Equals("medium"))
                                        mediumOr++;
                                    if (cellValuePriority.ToLower().Equals("low") || cellValuePriority.Contains("LOW"))
                                        lowOr++;
                                }                                   
                            }                            
                        }                       
                    }
                    i2++;
                }
            }

            if (option == "wholeList" || option == "internalList")
            {
                if (option == "internalList")
                {
                    x = 1;
                    x2 = 1;
                    int z = 0;
                    List<string> InternalExcelHeader = new List<string>();

                    foreach (ColumnHeader ch in IntTrackerView.Columns)
                    {
                        z++;
                        if (ch.Text != "Department Esom" && ch.Text != "Esom Ref" && ch.Text != "Manager" && ch.Text != "Technician assigned")
                            InternalExcelHeader.Add(ch.Text);
                    }

                    // Set first ROW as Column Headers Text
                    foreach (var item in InternalExcelHeader)
                    {
                        x++;
                        wSheet.Cells[x2, x] = item;
                        wSheet.Cells[x2, x].Font.Bold = true;
                        wSheet.Cells[x2, x].Font.Size = 14;
                        wSheet.Cells[x2, x].Borders.Value = 1;
                        wSheet.Cells[x2, x].Borders.LineStyle = Excel.XlLineStyle.xlDouble;
                    }
                }

                statistics = true;

                Util.DateCreatedIn = Util.DateCreatedIn != "" ? DateTime.Parse(Util.DateCreatedIn).ToString("yyyy-MM-dd") : Util.DateCreatedIn;
                Util.DateCreatedOut = Util.DateCreatedOut != "" ? DateTime.Parse(Util.DateCreatedOut).ToString("yyyy-MM-dd") : Util.DateCreatedOut;


                UnivSource.connection.Open();
                System.Data.DataTable TrackDt = new System.Data.DataTable();
                System.Data.DataTable TrackDtAllRows = new System.Data.DataTable();
                DataSet ds = null;
                SqlDataAdapter da = null;

                string searchText = SearchTBox.Text.ToString();
                string searchOption = SearchcBox.Text.ToString();
            
                {                   
                    string dbo = "[avitsql].[GetData]";

                    using (SqlCommand cmd = new SqlCommand(dbo, UnivSource.connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@TrackNoFrom", SqlDbType.VarChar).Value = Util.TrackNoFrom;
                        cmd.Parameters.Add("@TrackNoTo", SqlDbType.VarChar).Value = Util.TrackNoTo;
                        cmd.Parameters.Add("@TypeString", SqlDbType.VarChar).Value = option == "internalList" ? "Internal" : Util.TypeString;
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
                        cmd.Parameters.Add("@DepartmentRefString", SqlDbType.VarChar).Value = Util.DepartmentRefString;
                        cmd.Parameters.Add("@AssignedToString", SqlDbType.VarChar).Value = Util.AssignedToString;
                        cmd.Parameters.Add("@EscalatedToString", SqlDbType.VarChar).Value = Util.EscalatedToString;
                        cmd.Parameters.Add("@DepartmentEsomString", SqlDbType.VarChar).Value = Util.DepartmentEsomString;
                        cmd.Parameters.Add("@ReportDateIn", SqlDbType.VarChar).Value = Util.ReportDateIn;
                        cmd.Parameters.Add("@ReportDateOut", SqlDbType.VarChar).Value = Util.ReportDateOut;
                        //cmd.Parameters.Add("@PageNum", SqlDbType.Int).Value = pageNr; // Util.pageNum;
                        cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = Util.pageSize;
                        cmd.Parameters.Add("@Order", SqlDbType.VarChar).Value = Util.Order;
                        cmd.Parameters.Add("@Cols", SqlDbType.VarChar).Value = Util.Cols;
                        cmd.Parameters.Add("@SearchString", SqlDbType.VarChar).Value = searchText;
                        cmd.Parameters.Add("@SearchOption", SqlDbType.VarChar).Value = searchOption;
                        cmd.Parameters.Add("@Export", SqlDbType.Int).Value = 1;

                        cmd.ExecuteNonQuery();

                        using (da = new SqlDataAdapter(cmd))
                        {
                            ds = new DataSet();
                            da.Fill(ds);
                        }
                    }
                }               

                TrackDt = ds.Tables["Table"];

                foreach (DataRow row in TrackDt.Rows)
                {
                    i = 1;

                    ListViewItem lviIntTrackExcel = new ListViewItem();

                    foreach (ListViewItem.ListViewSubItem lvs in lviIntTrackExcel.SubItems)
                    {
                        i++;
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["TrackId"].ToString();
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["Type"] != null ? row["Type"].ToString() : "";
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["Status"] != null ? row["Status"].ToString() : "";
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["Priority"].ToString();

                        //different cell color
                        if (row["Priority"].ToString().ToLower() == "critical")
                            wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Crimson);

                        if (row["Priority"].ToString().ToLower() == "urgent")
                            wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.OrangeRed);

                        if (row["Priority"].ToString().ToLower() == "high")
                            wSheet.Cells[i2, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["IssueDescription"].ToString();
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["Location"].ToString();
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["SublocationArea"] != null ? row["SublocationArea"].ToString() : "";
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["SpecificLocation"] != null ? row["SpecificLocation"].ToString() : "";
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["LocationDetails"] != null ? row["LocationDetails"].ToString() : "";
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["DateCreated"] != null ? DateTime.Parse(row["DateCreated"].ToString()).ToShortDateString() : "";
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["ReportedBy"] != null ? row["ReportedBy"].ToString() : "";
                        if (option != "internalList")
                        {
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = row["DepartmentEsom"] != null ? row["DepartmentEsom"].ToString() : "";
                        }

                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["AssignedTo"] != null ? row["AssignedTo"].ToString() : "";
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["AssignedToPerson"] != null ? row["AssignedToPerson"].ToString() : "";

                        if (option != "internalList")
                        {
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = row["EsomRef"] != null ? row["EsomRef"].ToString() : "";
                        }
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["EscalationComments"] != null ? row["EscalationComments"].ToString() : "";
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["EscalCompletedBy"] != null ? row["EscalCompletedBy"].ToString() : "";
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = (row["EscalationStartDate"].ToString() != null && row["EscalationStartDate"].ToString() != Util.NADate.ToString() ? row["EscalationStartDate"].ToString() : "");

                        if (option != "internalList")
                        {
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = row["Manager"] != null ? row["Manager"].ToString() : "";
                            wSheet.Cells[i2, i].Borders.Value = 1;
                            wSheet.Cells[i2, i++] = row["TechnicianAssigned"] != null ? row["TechnicianAssigned"].ToString() : "";
                        }
                        wSheet.Cells[i2, i].Borders.Value = 1; 
                        wSheet.Cells[i2, i++] = (row["EscalationComplDate"].ToString() != null && row["EscalationComplDate"].ToString() != Util.NADate.ToString() ? row["EscalationComplDate"].ToString() : "");
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["ClosingComment"] != null ? row["ClosingComment"].ToString() : "";
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["ClosedBy"] != null ? row["ClosedBy"].ToString() : "";
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = (row["ClosingDate"].ToString() != null && row["ClosingDate"].ToString() != Util.NADate.ToString() ? row["ClosingDate"].ToString() : ""); //row["ClosingDate"] != null ? DateTime.Parse(row["ClosingDate"].ToString()).ToShortDateString() : "";
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["FollowUp"] != null ? row["FollowUp"].ToString() : "";
                        wSheet.Cells[i2, i].Borders.Value = 1;
                        wSheet.Cells[i2, i++] = row["LastUpdate"] != null ? row["LastUpdate"].ToString() : "";

                        //for chart values
                        if (row["Status"].ToString().ToLower().Equals("open") || row["Status"].ToString().ToLower().Equals("in progress"))
                        {
                            totalOr++;
                            if (row["Priority"].ToString().ToLower().Equals("critical"))
                                criticalOr++;
                            if (row["Priority"].ToString().ToLower().Equals("urgent"))
                                urgentOr++;
                            if (row["Priority"].ToString().ToLower().Equals("high"))
                                highOr++;
                            if (row["Priority"].ToString().ToLower().Equals("medium"))
                                mediumOr++;
                            if (row["Priority"].ToString().Contains("LOW") || row["Priority"].ToString().ToLower().Equals("low"))
                                lowOr++;
                        }
                    }
                    i2++;
                }
                UnivSource.connection.Close();   
            }

            // AutoSet Cell Widths to Content Size
            wSheet.Cells.Select();
            //wSheet.Cells.EntireColumn.AutoFit();
            wSheet.Columns.AutoFit();
            wSheet.Rows.AutoFit();
            //wSheet.Application.ActiveWindow.SplitRow = 2;
            //freeze top row
            //wSheet.Application.ActiveWindow.FreezePanes = true;


            Range line = (Range)wSheet.Rows[1];
            line.Insert();
            var filter = wSheet.Cells[1, x].AutoFilter();

            if (statistics == true)
            {
                Excel.Worksheet wSheet2 = wBook.Sheets.Add(Type.Missing, wSheet, 1, Type.Missing) as Excel.Worksheet;
                wSheet2.Name = "Statistics";


                wSheet.Select(Type.Missing);

                //Add sample data for pie chart
                //Add headings in A1 and B1.
                //wSheet2.Cells[2, 2] = "Products";
                wSheet2.Cells[2, 2] = "HRL WORK ORDERS (opened and in progress)";
                //merge cels
                wSheet2.Range[wSheet2.Cells[2, 2], wSheet2.Cells[2, 6]].Merge();
                wSheet2.Cells[2, 2].Font.Bold = true;
                wSheet2.Cells[2, 2].Font.Size = 14;
                //wSheet2.Cells[2, 2].Borders.Value = 1;
                //wSheet2.Cells[2, 2].Borders.LineStyle = Excel.XlLineStyle.xlDouble;

                ////Add data from A2 till B4
                wSheet2.Cells[4, 3] = "Critical";
                wSheet2.Cells[4, 3].Borders.Value = 1;
                wSheet2.Cells[4, 4] = criticalOr; //6; // criticalOr;
                wSheet2.Cells[4, 4].Borders.Value = 1;
                wSheet2.Cells[5, 3] = "Urgent";
                wSheet2.Cells[5, 3].Borders.Value = 1;
                wSheet2.Cells[5, 4] = urgentOr; //19; // urgentOr;
                wSheet2.Cells[5, 4].Borders.Value = 1;
                wSheet2.Cells[6, 3] = "High";
                wSheet2.Cells[6, 3].Borders.Value = 1;
                wSheet2.Cells[6, 4] = highOr; //92; // highOr;
                wSheet2.Cells[6, 4].Borders.Value = 1;
                wSheet2.Cells[7, 3] = "Medium";
                wSheet2.Cells[7, 3].Borders.Value = 1;
                wSheet2.Cells[7, 4] = mediumOr; //140; // mediumOr;
                wSheet2.Cells[7, 4].Borders.Value = 1;
                wSheet2.Cells[8, 3] = "Low";
                wSheet2.Cells[8, 3].Borders.Value = 1;
                wSheet2.Cells[8, 4] = lowOr; //57; // lowOr;
                wSheet2.Cells[8, 4].Borders.Value = 1;
                wSheet2.Cells[9, 3] = "Total";
                wSheet2.Cells[9, 3].Borders.Value = 1;
                wSheet2.Cells[9, 4] = totalOr; //314; // totalOr;
                wSheet2.Cells[9, 4].Borders.Value = 1;

                //border
                wSheet2.Range[wSheet2.Cells[4, 3], wSheet2.Cells[9, 4]].BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
                wSheet2.Range[wSheet2.Cells[9, 3], wSheet2.Cells[9, 4]].BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
                wSheet2.Range[wSheet2.Cells[9, 3], wSheet2.Cells[9, 4]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SandyBrown);
                wSheet2.Columns[3].ColumnWidth = 20;
                wSheet2.Columns[4].ColumnWidth = 7;

                // AutoSet Cell Widths to Content Size
                //wSheet2.Cells.Select();
                //wSheet2.Cells.EntireColumn.AutoFit();
               // wSheet2.Columns.AutoFit();
                wSheet2.Rows.AutoFit();





                object misValue = System.Reflection.Missing.Value;
                Excel.Range chartRange;
                Excel.ChartObjects xlCharts = (Excel.ChartObjects)wSheet2.ChartObjects(Type.Missing);
                Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(50, 160, 600, 400);
                Excel.Chart chartPage = myChart.Chart;


                chartRange = wSheet2.get_Range("C4", "D8");
                chartPage.SetSourceData(chartRange, Excel.XlRowCol.xlRows);
                chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered; //xlColumnClustered; //xl3DColumnStacked;  //xl3DPie;
                chartPage.ApplyLayout(1);
                chartPage.ChartTitle.Text = "HRL WORK ORDERS";

                chartPage.ApplyDataLabels();               

            }

            string date = DateTime.Now.ToString("dd MMM yyyy HH:mm:ss tt").Replace("/", ".").Replace(":", ".");
            string currentUserPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string userName = Environment.UserName;
            string machineName = Util.userMachine; // Environment.MachineName;
            string fileName;
            if (option == "internalList")
              fileName = "Int Track List Al Yamamah(Internal) -" + date + " by " + Util.userConnected;
              else
              fileName = "Int Track List Al Yamamah -" + date + " by " + Util.userConnected;

            //check if shared folder is synced, otherwise save locally
            string userDepartment = Util.departmentConnected;
            string subPath = currentUserPath + "\\Hill Robinson\\Project Bianca - Staff (Bianca)\\01- HRES COMPLAINT TRACKING SYSTEM\\" + userDepartment + "\\";
            //"\\Hill Robinson\\Project Bianca - Shared\\Technical\\TaskAlocation\\";

            bool exists = Directory.Exists(subPath);
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
                wBook.SaveAs(@currentUserPath + (!continueOperation ? "\\Hill Robinson\\Project Bianca - Staff (Bianca)\\01- HRES COMPLAINT TRACKING SYSTEM\\" + userDepartment + "\\" : "") + fileName + ".xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);

                excel.ActiveWindow.Close();
           
                //insert in log table
                int UserId = Util.userIdConnected;
                string exportOption = option == "currentPage" ? "current page" : (option == "wholeList" ? "whole list" : "selected list");
                string Action = "Excel export - " + exportOption + (continueOperation ? " saved locally " : "");
                string TableInvolved = "TechIntTracker";
                string Description = "Exported " + exportOption + " of Int Tracker List: " + fileName;
                DateTime UpdateTime = DateTime.ParseExact(DateTime.Now.ToString("dd MMM yyyy HH:mm:ss tt").Replace("-", "/").Replace(".", "/"), "dd MMM yyyy HH:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                string MachineName = Util.userMachine;
                string Macc = Util.userMachineMacc;
                string IPAdress = Util.userIp;
                string CreatedByWinAcc = Util.windowsAccount;

                insertLog(UserId, Action, TableInvolved, Description, UpdateTime, MachineName, Macc, IPAdress, CreatedByWinAcc);
            }
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
            {
                if(Util.StatusString == string.Empty)
                    Util.StatusString += "Open, ";
                if (Util.StatusString != string.Empty && !Util.StatusString.Contains("Open"))
                    Util.StatusString += ",Open,";
            }
            if(cBoxInProgress.Checked == true && cBoxAll.Checked == false && !Util.StatusString.Contains("In progress"))
                Util.StatusString += "In progress, ";
            if (cBoxAll.Checked == true)
                Util.StatusString = "";

            if (InternalcheckBox.Checked == true && !Util.TypeString.Contains("Internal"))
            {
                if (Util.TypeString == string.Empty)
                    Util.TypeString += "Internal, ";
                else
                    Util.TypeString += ",Internal, ";
            }
            if (ContractorcheckBox.Checked == true && !Util.TypeString.Contains("Contractor"))
            {
                if(Util.TypeString.Contains("Internal"))
                    Util.TypeString = "Internal,Contractor";
                else
                Util.TypeString += "Contractor, ";
            }
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

            pgNrTbox.Text = "1";
            quickFilterOption();
        }

        private void SearchTBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchApplybtn_Click(sender, e);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbSession.Text = Util.currentSession;
        }

        private void cloneTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.newItem = true;          
           
            //IntTrackerView_SelectedIndexChanged(sender, e);
            Util.status = "Open";
            Util.dateCreated = DateTime.Now.ToString();
          

            if (Util.RecordType == "Contractor")
            {
                ContractorRecordAlYamama newInstance = new ContractorRecordAlYamama();
                RefreshListEvent += new RefreshList(RefreshListView); // event initialization
                newInstance.UpdateContractor = RefreshListEvent; // assigning event to the Delegate
                newInstance.Show();
                //ContractorRecordAlYamama form = new ContractorRecordAlYamama();
                //form.ShowDialog();
            }
            else if (Util.RecordType == "Internal")
            {
                InternalRecordAlYamama newInstance = new InternalRecordAlYamama();
                RefreshListEvent += new RefreshList(RefreshListView); // event initialization
                newInstance.UpdateInternal = RefreshListEvent; // assigning event to the Delegate               
                newInstance.Show();
                //InternalRecordAlYamama form = new InternalRecordAlYamama();
                //form.ShowDialog();
            }
            //SelectIntTracker(IntTrackerView);
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void IntTrackerAlYamama_FormClosing(object sender, FormClosingEventArgs e)
        {
            resetFilters();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("Int Tracker app - How to use.pdf");
        }

        private void btnReportSwap_Click(object sender, EventArgs e)
        {
            Util.PreviousWReport = Util.PreviousWReport == 0 ? 1 : 0;
            btnReportSwap.Text = Util.PreviousWReport == 0 ? " Swap current to previous week-- > " : " Swap previous to current week --> ";
            btnReportSwap.ForeColor = Util.PreviousWReport == 1 ? Color.Aquamarine : Color.Red;
            //btnReportSwap.BackColor = Util.PreviousWReport == 1 ? Color.Aquamarine : Color.Red;
            getDataWeeklyReport();
        }
    }

}
