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
    public partial class Locations : Form
    {
        TechDboDataContext pd = new TechDboDataContext();
        Boolean SharmabtnState = Convert.ToInt32(Util.userProject) == 2 ? true : false;
        Boolean AlYamamabtnState = Convert.ToInt32(Util.userProject) == 1 ? true : false;


        public Delegate UpdateSpecLocation;
        //public delegate void RefreshList();
        //public event RefreshList RefreshListEvent;


        //public void RefreshListView()
        //{
        //    SelectLocations(LocationsView);
        //}

        public Locations()
        {
            InitializeComponent();
            LocationsView.FullRowSelect = true;
            LocationsView.GridLines = true;
            LocationsView.View = View.Details;
            //LocationsView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            //LocationsView.CheckBoxes = true;
            this.CenterToScreen();
            this.WindowState = !Util.SearchLocationTool ? FormWindowState.Maximized : FormWindowState.Normal;
            CustomizeLocationsView(LocationsView);

            Util.AlYamamabtn = AlYamamabtnState;
            rBtnAlYamama.Checked = AlYamamabtnState ? true : false;
            Util.Sharmabtn = SharmabtnState;
            rBtnSharma.Checked = SharmabtnState ? true : false;

            LocationFiltercheckedComboBox.Items.Clear();
            LocationFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheckTypeLocation);
            populateCombos();

            //Util.TypeString = "Internal, Contractor";
            //Util.StatusString = "Open, In progress";
            quickFilterOption();

            //if (Util.userTypeConnected == "guest")
            //    ExportToolStripMenuItem.Enabled = false;

            if (Util.SearchLocationTool)
            {
                addNewToolStripMenuItem.Visible = false;
                ExportToolStripMenuItem.Visible = false;
            }
         
        }

        private void Locations_Load(object sender, EventArgs e)
        {
            SelectLocations(LocationsView);
            SearchcBox.SelectedIndex = 0;
        }

        public void CustomizeLocationsView(ListView LocationsView)
        {
            //LocationsView.View = View.Details;
            LocationsView.FullRowSelect = true;
            //LocationsView.RedrawItems = true;
            //LocationsView.LabelWrap = true;
            //Task Description
            LocationsView.Columns.Add("Id", -2);
            LocationsView.Columns.Add("Project", -2);
            LocationsView.Columns.Add("Building Id", -2);
            LocationsView.Columns.Add("Sublocation", -2);
            LocationsView.Columns.Add("Specific location", 200);
            LocationsView.Columns.Add("Location details", -2);
            LocationsView.Columns.Add("HK alias location", -2);
            LocationsView.Columns.Add("FB alias location", -2);
            LocationsView.Columns.Add("AHU", 100);
            LocationsView.Columns.Add("ICT", -2);
            LocationsView.Columns.Add("Other info", -2);


            //LocationsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //LocationsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


            //ResizeListViewColumns(LocationsView);
        }

        private void ccb_ItemCheckTypeLocation(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = LocationFiltercheckedComboBox.Items[e.Index] as CCBoxItem;

        }

        public void populateCombos()
        {
            //checked comboboxes

            //1. location
            if (Util.AlYamamabtn == true)
            {
                var LocationFilter = (from x in pd.LocationBuildingAYFilters
                                      select x).OrderBy(v => v.BuildingId);

                LocationFiltercheckedComboBox.Items.Add("ALL");
                LocationFiltercheckedComboBox.SetItemChecked(0, true);


                int n = 1;
                foreach (var item in LocationFilter)
                {
                    LocationFiltercheckedComboBox.Items.Add(item.BuildingId);
                    LocationFiltercheckedComboBox.SetItemChecked(n, true);
                    n++;
                }
                ////If more then 5 items, add a scroll bar to the dropdown.
                //// PriorityFiltercheckedComboBox.MaxDropDownItems = 5;
                //// Make the "Name" property the one to display, rather than the ToString() representation.
                //LocationFiltercheckedComboBox.DisplayMember = "Name";
                //LocationFiltercheckedComboBox.ValueSeparator = ", ";
            }
            if (Util.Sharmabtn == true)
            {
                var LocationFilter = (from x in pd.LocationBuildingSharmaFilters
                                      select x).OrderBy(v => v.BuildingId);

                LocationFiltercheckedComboBox.Items.Add("ALL");
                LocationFiltercheckedComboBox.SetItemChecked(0, true);


                int n = 1;
                foreach (var item in LocationFilter)
                {
                    LocationFiltercheckedComboBox.Items.Add(item.BuildingId);
                    LocationFiltercheckedComboBox.SetItemChecked(n, true);
                    n++;
                }
                ////If more then 5 items, add a scroll bar to the dropdown.
                //// PriorityFiltercheckedComboBox.MaxDropDownItems = 5;
                //// Make the "Name" property the one to display, rather than the ToString() representation.
                //LocationFiltercheckedComboBox.DisplayMember = "Name";
                //LocationFiltercheckedComboBox.ValueSeparator = ", ";
            }
        }
    

        private void getLocationCallProcedure()
        {
            int i = 1;
            int j = 1;
            int pageNr = (pgNrTbox.Text != "" ? Convert.ToInt32(pgNrTbox.Text) : 1);
            int totalRows = 0;
            int curRow = 0;
            string searchText = SearchTBox.Text.ToString();
            string searchOption = SearchcBox.Text.ToString();

            UnivSource.connection.Open();
            System.Data.DataTable TrackDt = new System.Data.DataTable();
            System.Data.DataTable TrackDtAllRows = new System.Data.DataTable();
            DataSet ds = null;
            SqlDataAdapter da = null;
            string dbo = "[dbo].[GetLocations]";
            //Util.AlYamamabtn ? "GetData".ToString() : "GetDataSharma".ToString();



            using (SqlCommand cmd = new SqlCommand(dbo, UnivSource.connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Project", SqlDbType.Int).Value = Util.AlYamamabtn ? 1 : 2;
                cmd.Parameters.Add("@BuildingIdString", SqlDbType.VarChar).Value = Util.LocationBuildingIdString;
                cmd.Parameters.Add("@SublocationString", SqlDbType.VarChar).Value = Util.LocationSublocationString;

                cmd.Parameters.Add("@PageNum", SqlDbType.Int).Value = pageNr; // Util.pageNum;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = Util.pageSizeLocation;
                cmd.Parameters.Add("@Order", SqlDbType.VarChar).Value = Util.OrderLocation;
                cmd.Parameters.Add("@Cols", SqlDbType.VarChar).Value = Util.ColsLocation;

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
                        lviIntTrack.SubItems.Add(row["Project"].ToString() != null ? row["Project"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["BuildingId"].ToString() != null ? row["BuildingId"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["Sublocation"].ToString() != null ? row["Sublocation"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["SpecificLocation"].ToString() != null ? row["SpecificLocation"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["LocationDetails"].ToString() != null ? row["LocationDetails"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["HKSpecificLocationAlias"].ToString() != null ? row["HKSpecificLocationAlias"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["FBSpecificLocationAlias"].ToString() != null ? row["FBSpecificLocationAlias"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["AHU"].ToString() != null ? row["AHU"].ToString() : "");
                        lviIntTrack.SubItems.Add(row["ICTReport"].ToString() != null ? (row["ICTReport"].ToString() == "1" ? "True" : "False")  : "");
                        lviIntTrack.SubItems.Add(row["OtherInfo"].ToString() != null ? row["OtherInfo"].ToString() : "");


                       

                        //lviIntTrack.SubItems.Add(row["LastUpdate"].ToString());


                        LocationsView.Items.Add(lviIntTrack);

                        //            //color to certain cells
                        //            //this is very Important
                        //            LocationsView.Items[r - 1].UseItemStyleForSubItems = false;
                        //            // Now you can Change the Particular Cell Property of Style
                        //            //lviIntTrack.Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);

                        //            for (int p = 0; p < LocationsView.Items[r - 1].SubItems.Count; p++)
                        //            {
                        //                LocationsView.Items[r - 1].SubItems[p].Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);
                        //                //priority color
                        //                if (row["Priority"].ToString().ToLower() == "critical")
                        //                    LocationsView.Items[r - 1].SubItems[3].BackColor = Color.Crimson;
                        //                LocationsView.Items[r - 1].SubItems[4].BackColor = Color.White;
                        //                if (row["Priority"].ToString().ToLower() == "urgent")
                        //                    LocationsView.Items[r - 1].SubItems[3].BackColor = Color.OrangeRed;
                        //                if (row["Priority"].ToString().ToLower() == "high")
                        //                    LocationsView.Items[r - 1].SubItems[3].BackColor = Color.Red;
                        //                if (row["Priority"].ToString().ToLower() == "medium")
                        //                    LocationsView.Items[r - 1].SubItems[3].BackColor = Color.Orange;
                        //                if (row["Priority"].ToString().Contains("LOW"))
                        //                    LocationsView.Items[r - 1].SubItems[3].BackColor = Color.Yellow;

                        //                //status color
                        //                if (row["Status"].ToString().ToLower() == "open")
                        //                    LocationsView.Items[r - 1].SubItems[2].BackColor = Color.LightSkyBlue;
                        //                if (row["Status"].ToString().ToLower() == "in progress")
                        //                    LocationsView.Items[r - 1].SubItems[2].BackColor = Color.Aquamarine;
                        //                if (row["Status"].ToString().ToLower() == "closed")
                        //                    LocationsView.Items[r - 1].SubItems[2].BackColor = Color.Bisque;
                        //                if (row["Status"].ToString().ToLower() == "cancelled")
                        //                    LocationsView.Items[r - 1].SubItems[2].BackColor = Color.LightCoral;


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
            if (pageNr < lastPage)
                showlbl.Text = "Displaying 32 item(s) of " + totalRows;
            if (pageNr == lastPage)
                showlbl.Text = "Displaying " + itemsPerLastPage + " item(s) of " + totalRows;
        }

        public void SelectLocations(ListView LocationsView)
        {
            //LocationFiltercheckedComboBox.Items.Clear();
            //LocationFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheckTypeLocation);

            //populateCombos();

            LocationsView.Items.Clear();
            getLocationCallProcedure();

        //    int i = 1;
        //    int j = 1;
        //    int pageNr = (pgNrTbox.Text != "" ? Convert.ToInt32(pgNrTbox.Text) : 1);
        //    int totalRows = 0;
        //    int curRow = 0;

        //    UnivSource.connection.Open();
        //    System.Data.DataTable TrackDt = new System.Data.DataTable();
        //    System.Data.DataTable TrackDtAllRows = new System.Data.DataTable();
        //    DataSet ds = null;
        //    SqlDataAdapter da = null;
        //    string dbo = "[dbo].[GetLocations]";
        //    //Util.AlYamamabtn ? "GetData".ToString() : "GetDataSharma".ToString();



        //    using (SqlCommand cmd = new SqlCommand(dbo, UnivSource.connection))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add("@Project", SqlDbType.Int).Value = Util.AlYamamabtn ? 1 : 2;
        //        cmd.Parameters.Add("@BuildingIdString", SqlDbType.VarChar).Value = Util.LocationBuildingIdString;
        //        cmd.Parameters.Add("@SublocationString", SqlDbType.VarChar).Value = Util.LocationSublocationString;


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

        //        foreach (DataRow row in TrackDt.Rows)
        //        {
        //            ListViewItem lviIntTrack = new ListViewItem(row["Id"].ToString());

        //            curRow = Convert.ToInt32(row["RowNum"].ToString());
        //            //set the font to the item
        //            lviIntTrack.Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);

        //            //set the font to the item
        //            //if (i % 2 != 0)
        //            //    i <= (33 * Convert.ToInt32(pgNrTbox.Text))
        //            if (pgNrTbox.Text == "")
        //                pgNrTbox.Text = "1";

        //            if ((pageNr == 1 && i < (32 * pageNr + 1)) || (pageNr > 1 && i > (32 * (pageNr - 1)) && i <= (32 * pageNr)))
        //            {
        //                lviIntTrack.SubItems.Add(row["Project"].ToString() != null ? row["Project"].ToString() : "");
        //                lviIntTrack.SubItems.Add(row["BuildingId"].ToString() != null ? row["BuildingId"].ToString() : "");
        //                lviIntTrack.SubItems.Add(row["Sublocation"].ToString() != null ? row["Sublocation"].ToString() : "");
        //                lviIntTrack.SubItems.Add(row["SpecificLocation"].ToString() != null ? row["SpecificLocation"].ToString() : "");
        //                lviIntTrack.SubItems.Add(row["LocationDetails"].ToString() != null ? row["LocationDetails"].ToString() : "");
        //                lviIntTrack.SubItems.Add(row["OtherInfo"].ToString() != null ? row["OtherInfo"].ToString() : "");


        //                cmd.Parameters.Add("@PageNum", SqlDbType.Int).Value = pageNr; // Util.pageNum;
        //                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = Util.pageSizeCont;
        //                cmd.Parameters.Add("@Order", SqlDbType.VarChar).Value = Util.OrderCont;
        //                cmd.Parameters.Add("@Cols", SqlDbType.VarChar).Value = Util.ColsCont;

        //                //lviIntTrack.SubItems.Add(row["LastUpdate"].ToString());


        //                LocationsView.Items.Add(lviIntTrack);

        //                //            //color to certain cells
        //                //            //this is very Important
        //                //            LocationsView.Items[r - 1].UseItemStyleForSubItems = false;
        //                //            // Now you can Change the Particular Cell Property of Style
        //                //            //lviIntTrack.Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);

        //                //            for (int p = 0; p < LocationsView.Items[r - 1].SubItems.Count; p++)
        //                //            {
        //                //                LocationsView.Items[r - 1].SubItems[p].Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);
        //                //                //priority color
        //                //                if (row["Priority"].ToString().ToLower() == "critical")
        //                //                    LocationsView.Items[r - 1].SubItems[3].BackColor = Color.Crimson;
        //                //                LocationsView.Items[r - 1].SubItems[4].BackColor = Color.White;
        //                //                if (row["Priority"].ToString().ToLower() == "urgent")
        //                //                    LocationsView.Items[r - 1].SubItems[3].BackColor = Color.OrangeRed;
        //                //                if (row["Priority"].ToString().ToLower() == "high")
        //                //                    LocationsView.Items[r - 1].SubItems[3].BackColor = Color.Red;
        //                //                if (row["Priority"].ToString().ToLower() == "medium")
        //                //                    LocationsView.Items[r - 1].SubItems[3].BackColor = Color.Orange;
        //                //                if (row["Priority"].ToString().Contains("LOW"))
        //                //                    LocationsView.Items[r - 1].SubItems[3].BackColor = Color.Yellow;

        //                //                //status color
        //                //                if (row["Status"].ToString().ToLower() == "open")
        //                //                    LocationsView.Items[r - 1].SubItems[2].BackColor = Color.LightSkyBlue;
        //                //                if (row["Status"].ToString().ToLower() == "in progress")
        //                //                    LocationsView.Items[r - 1].SubItems[2].BackColor = Color.Aquamarine;
        //                //                if (row["Status"].ToString().ToLower() == "closed")
        //                //                    LocationsView.Items[r - 1].SubItems[2].BackColor = Color.Bisque;
        //                //                if (row["Status"].ToString().ToLower() == "cancelled")
        //                //                    LocationsView.Items[r - 1].SubItems[2].BackColor = Color.LightCoral;


        //            //}

        //            r++;

        //        }
        //        i++;
        //    }
        //        UnivSource.connection.Close();
        //}
        //int itemsPerLastPage = 0;
        //int lastPage = 0;


        //totalPageslbl.Text = (totalRows % 32) == 0 ? (totalRows / 32).ToString() : ((totalRows / 32) + 1).ToString();
        //lastPage = (totalRows % 32) == 0 ? (totalRows / 32) : ((totalRows / 32) + 1);
        //                itemsPerLastPage = totalRows % 32;
        //                if (pageNr<lastPage)
        //                    showlbl.Text = "Displaying 32 item(s) of " + totalRows;
        //                if (pageNr == lastPage)
        //                    showlbl.Text = "Displaying " + itemsPerLastPage + " item(s) of " + totalRows;

        }

        public void LocationsView_DoubleClick(object sender, EventArgs e)
        {
            Reset();    

            if (!Util.SearchLocationTool)
            Util.newItem = false;
            if (LocationsView.SelectedItems.Count > 0)
            {
               if (AlYamamabtnState == true)
                {
                    int Id = Convert.ToInt32(LocationsView.SelectedItems[0].SubItems[0].Text);
                    var query = from x in pd.Locations                                    
                                where x.id == Id && x.Project == 1

                                select new
                                {                                   
                                    x.id,
                                    x.Project,
                                    x.BuildingId,
                                    x.Sublocation,
                                    x.SpecificLocation,
                                    x.LocationDetails,
                                    x.HKSpecificLocationAlias,
                                    x.FBSpecificLocationAlias,
                                    x.AHU,
                                    x.ICTReport,
                                    x.OtherInfo                                   
                                };

                    foreach (var x in query)
                    {
                        Util.LocationId = Convert.ToInt32(x.id);
                        Util.LocationProject = x.Project != null ? (int)x.Project : 0;
                        Util.LocationBuildingId = x.BuildingId != null ? x.BuildingId : "";
                        Util.LocationSublocation = x.Sublocation != null ? x.Sublocation : "";
                        Util.LocationSpecificLocation = x.SpecificLocation != null ? x.SpecificLocation : "";
                        Util.LocationLocationDetails = x.LocationDetails != null ? x.LocationDetails : "";
                        Util.LocationHKAlias = x.HKSpecificLocationAlias != null ? x.HKSpecificLocationAlias : "";
                        Util.LocationFBAlias = x.FBSpecificLocationAlias != null ? x.FBSpecificLocationAlias : "";
                        Util.LocationAHU = x.AHU != null ? x.AHU : "";
                        Util.LocationICT = x.ICTReport != null ? (int)x.ICTReport : 0;
                        Util.LocationOtherInfo = x.OtherInfo != null ? x.OtherInfo : "";
                    }
                }

                if (SharmabtnState == true)
                {
                    int Id = Convert.ToInt32(LocationsView.SelectedItems[0].SubItems[0].Text);
                    var query = from x in pd.Locations
                                where x.id == Id && x.Project == 2

                                select new
                                {
                                    x.id,
                                    x.Project,
                                    x.BuildingId,
                                    x.Sublocation,
                                    x.SpecificLocation,
                                    x.LocationDetails,
                                    x.HKSpecificLocationAlias,
                                    x.FBSpecificLocationAlias,
                                    x.AHU,
                                    x.ICTReport,
                                    x.OtherInfo
                                };

                    foreach (var x in query)
                    {
                        Util.LocationId = Convert.ToInt32(x.id);
                        Util.LocationProject = x.Project != null ? (int)x.Project : 0;
                        Util.LocationBuildingId = x.BuildingId != null ? x.BuildingId : "";
                        Util.LocationSublocation = x.Sublocation != null ? x.Sublocation : "";
                        Util.LocationSpecificLocation = x.SpecificLocation != null ? x.SpecificLocation : "";
                        Util.LocationLocationDetails = x.LocationDetails != null ? x.LocationDetails : "";
                        Util.LocationHKAlias = x.HKSpecificLocationAlias != null ? x.HKSpecificLocationAlias : "";
                        Util.LocationFBAlias = x.FBSpecificLocationAlias != null ? x.FBSpecificLocationAlias : "";
                        Util.LocationAHU = x.AHU != null ? x.AHU : "";
                        Util.LocationICT = x.ICTReport != null ? (int)x.ICTReport : 0;
                        Util.LocationOtherInfo = x.OtherInfo != null ? x.OtherInfo : "";
                    }
                }
            }

            if (!Util.SearchLocationTool)
            {
                LocationEdit form = new LocationEdit();

                //RefreshListEvent += new RefreshList(RefreshListView); // event initialization
                //newInstance.UpdateContractor = RefreshListEvent; // assigning event to the Delegate
                //newInstance.Show();

                form.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
                form.ShowDialog();
            }
            else if(Util.SearchLocationTool)
            {
                // Perform update operation 
                UpdateSpecLocation.DynamicInvoke(); // this will call the UpdateSpecLocation method of InternalRecord window
                Util.SearchLocationTool = false;
                this.Dispose();
            }

        }

        void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed
            LocationsView.Items.Clear();
            Locations_Load(sender, e);
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();

            Util.newItem = true;

            LocationEdit form = new LocationEdit();
            form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed
            form.ShowDialog();
        }

        void child_FormClosedRefresh(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed
            LocationsView.Items.Clear();
            //Locations_Load(sender, e);
            Refresh(sender, e);
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            //Locations_Load(sender, e);
            LocationsView.Items.Clear();
            Refresh(sender, e);
        }
        public void Refresh(object sender, EventArgs e)
        {            
            Locations_Load(sender, e);
        }

        private void LocationsView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

        private void LocationsView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            //e.DrawDefault = true;
        }

        private void LocationsView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            //e.DrawDefault = true;
        }

        private void LocationsView_ColumnClick(object sender, ColumnClickEventArgs e)
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
            //         value = Convert.ToBoolean(this.LocationsView.Columns[e.Column].Tag);
            //     }
            //     catch (Exception)
            //     {
            //     }
            //     this.LocationsView.Columns[e.Column].Tag = !value;
            //     foreach (ListViewItem item in this.LocationsView.Items)
            //         item.Checked = !value;

            //     this.LocationsView.Invalidate();
            // }

        }

        private void LocationsView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (LocationsView.SelectedItems.Count > 0 )
                {
                    contextMenuStrip1.Items[0].Visible = true;
                    //if (LocationsView.SelectedItems[0].SubItems[1].Text == "Internal")
                    //{
                    //    contextMenuStrip1.Items[0].Visible = true;
                    //    contextMenuStrip1.Items[1].Visible = false;
                    //}
                    //if (LocationsView.SelectedItems[0].SubItems[1].Text == "Contractor")
                    //{
                    //    contextMenuStrip1.Items[0].Visible = false;
                    //    contextMenuStrip1.Items[1].Visible = true;
                    //}

                    //if (LocationsView.FocusedItem.Bounds.Contains(e.Location))
                    {
                        System.Drawing.Point point = new System.Drawing.Point(this.Location.X + LocationsView.Location.X + e.X + 20,
                        this.Location.Y + LocationsView.Location.Y + e.Y);
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

        private void LocationsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LocationsView.SelectedItems.Count > 0)
            {
                int Id = Convert.ToInt32(LocationsView.SelectedItems[0].SubItems[0].Text);

                var query = from x in pd.Locations
                            where x.id == Id

                            select new
                            {
                                x.id,
                                x.Project,
                                x.BuildingId,
                                x.Sublocation,
                                x.SpecificLocation,
                                x.LocationDetails,
                                x.AHU,
                                x.OtherInfo
                            };

                foreach (var x in query)
                {
                    Util.LocationId = Convert.ToInt32(x.id);
                    Util.LocationProject = x.Project != null ? (int)x.Project : 0;
                    Util.LocationBuildingId = x.BuildingId != null ? x.BuildingId : "";
                    Util.LocationSublocation = x.Sublocation != null ? x.Sublocation : "";
                    Util.LocationSpecificLocation = x.SpecificLocation != null ? x.SpecificLocation : "";
                    Util.LocationLocationDetails = x.LocationDetails != null ? x.LocationDetails : "";
                    Util.LocationAHU = x.AHU != null ? x.AHU : "";
                    Util.LocationOtherInfo = x.OtherInfo != null ? x.OtherInfo : "";
                }
            }
        }

        private void ClonetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Util.newItem = true;

            LocationsView_SelectedIndexChanged(sender, e);
            Util.LocationId = 0;

            LocationEdit form = new LocationEdit();
            form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed
            form.ShowDialog();


            //Util.subLocation = "";
            //Util.specLocation = "";
            //Util.locationDetails = "";

            //if (LocationsView.SelectedItems.Count > 0)
            //{
          //  int trackId = Convert.ToInt32(LocationsView.SelectedItems[0].SubItems[0].Text);
            //    var query = from x in pd.TechLocationss
            //                    //TechLocationsTests
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
            //if (LocationsView.SelectedItems.Count > 0)
            //{
            //    if (AlYamamabtnState == true)
            //    {
            //        int trackId = Convert.ToInt32(LocationsView.SelectedItems[0].SubItems[0].Text);
                    //var query = from x in pd.TechLocationss
                    //                //TechLocationsTests
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
            //    int trackId = Convert.ToInt32(LocationsView.SelectedItems[0].SubItems[0].Text);
            //    var query = from x in pd.TechLocationsSharmas
            //                    //TechLocationsTests
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

        private void Locations_Load_1(object sender, EventArgs e)
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
        //    // //LocationsView.Items.Clear();
        //    // Refresh(sender, e);
        //    this.Dispose();
        //    Locations form = new Locations();
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
            Locations_Load(sender, e);
        }
             
        private void SearchApplybtn_Click(object sender, EventArgs e)
        {
            if (SearchTBox.Text != String.Empty)
            {
                pgNrTbox.Text = "1";
                LocationsView.Items.Clear();
                getLocationCallProcedure();

                //int i = 1;
                //int j = 1;
                //int pageNr = (pgNrTbox.Text != "" ? Convert.ToInt32(pgNrTbox.Text) : 1);
                //int totalRows = 0;


                //string searchText = SearchTBox.Text.ToString();
                //string searchOption = SearchcBox.Text.ToString();

                //    UnivSource.connection.Open();
                //    System.Data.DataTable TrackDt = new System.Data.DataTable();
                //    DataSet ds = null;
                //    SqlDataAdapter da = null;
                //    string dbo = Util.AlYamamabtn ? "GetSearchString" : "GetSearchStringSharma";//!!!

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
                //            lviIntTrack.SubItems.Add(row["IssueDescription"].ToString());
                //            lviIntTrack.SubItems.Add(row["Location"].ToString());
                //            lviIntTrack.SubItems.Add(row["SublocationArea"].ToString() != null ? row["SublocationArea"].ToString() : "");
                //            lviIntTrack.SubItems.Add(row["SpecificLocation"].ToString() != null ? row["SpecificLocation"].ToString() : "");
                //            lviIntTrack.SubItems.Add(row["LocationDetails"].ToString() != null ? row["LocationDetails"].ToString() : "");
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

                //            LocationsView.Items.Add(lviIntTrack);

                //            //color to certain cells
                //            //this is very Important
                //            LocationsView.Items[r - 1].UseItemStyleForSubItems = false;
                //            // Now you can Change the Particular Cell Property of Style
                //            //lviIntTrack.Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);

                //            for (int p = 0; p < LocationsView.Items[r - 1].SubItems.Count; p++)
                //            {
                //                LocationsView.Items[r - 1].SubItems[p].Font = new System.Drawing.Font(lviIntTrack.Font, FontStyle.Regular);
                //                //priority color
                //                if (row["Priority"].ToString().ToLower() == "critical")
                //                    LocationsView.Items[r - 1].SubItems[3].BackColor = Color.Crimson;
                //                LocationsView.Items[r - 1].SubItems[4].BackColor = Color.White;
                //                if (row["Priority"].ToString().ToLower() == "urgent")
                //                    LocationsView.Items[r - 1].SubItems[3].BackColor = Color.OrangeRed;
                //                if (row["Priority"].ToString().ToLower() == "high")
                //                    LocationsView.Items[r - 1].SubItems[3].BackColor = Color.Red;
                //                if (row["Priority"].ToString().ToLower() == "medium")
                //                    LocationsView.Items[r - 1].SubItems[3].BackColor = Color.Orange;
                //                if (row["Priority"].ToString().Contains("LOW"))
                //                    LocationsView.Items[r - 1].SubItems[3].BackColor = Color.Yellow;

                //                //status color
                //                if (row["Status"].ToString().ToLower() == "open")
                //                    LocationsView.Items[r - 1].SubItems[2].BackColor = Color.LightSkyBlue;
                //                if (row["Status"].ToString().ToLower() == "in progress")
                //                    LocationsView.Items[r - 1].SubItems[2].BackColor = Color.Aquamarine;
                //                if (row["Status"].ToString().ToLower() == "closed")
                //                    LocationsView.Items[r - 1].SubItems[2].BackColor = Color.Bisque;
                //                if (row["Status"].ToString().ToLower() == "cancelled")
                //                    LocationsView.Items[r - 1].SubItems[2].BackColor = Color.LightCoral;


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

            //TechLocations dp = new TechLocations();
            //var tracks = (from x in pd.TechLocationss
            //             select x).OrderByDescending(v => v.TrackId);
            PdfPTable table = new PdfPTable(8);
            PdfPCell cell = new PdfPCell(new Phrase("Locations List  - " + DateTime.Now.Date.ToShortDateString().Replace("/", ".").ToString()));

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
        //    int colNum = LocationsView.Columns.Count;

        //    // Set first ROW as Column Headers Text
        //    foreach (ColumnHeader ch in LocationsView.Columns)
        //    {
        //        x++;
        //        wSheet.Cells[x2, x] = ch.Text;
        //        wSheet.Cells[x2, x].Font.Bold = true;
        //        wSheet.Cells[x2, x].Font.Size = 14;
        //        wSheet.Cells[x2, x].Borders.Value = 1;
        //        wSheet.Cells[x2, x].Borders.LineStyle = Excel.XlLineStyle.xlDouble;

        //        //x++;
        //    }

        //    foreach (ListViewItem lvi in LocationsView.Items)
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
                SelectLocations(LocationsView);
        }

        private void firstLbl_Click(object sender, EventArgs e)
        {
            pgNrTbox.Text = "1";
            SelectLocations(LocationsView);
        }

        private void lastLbl_Click(object sender, EventArgs e)
        {
            pgNrTbox.Text = totalPageslbl.Text;
            SelectLocations(LocationsView);
        }

        private void prevLbl_Click(object sender, EventArgs e)
        {
            pgNrTbox.Text = Convert.ToInt32(pgNrTbox.Text) > 1 ? (Convert.ToInt32(pgNrTbox.Text) -1).ToString() : pgNrTbox.Text;
            SelectLocations(LocationsView);
        }

        private void nextLbl_Click(object sender, EventArgs e)
        {
            pgNrTbox.Text = Convert.ToInt32(pgNrTbox.Text) < Convert.ToInt32(totalPageslbl.Text) ? (Convert.ToInt32(pgNrTbox.Text) + 1).ToString() : pgNrTbox.Text;
            SelectLocations(LocationsView);
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            Locations form = new Locations();
            form.ShowDialog();
        }

        private void infoBtn_MouseHover(object sender, EventArgs e)
        {
            infoToolTip.Show("Click to display info of the page!", infoBtn);
        }

        private void AlYambtn_Click(object sender, EventArgs e)
        {
            SelectLocations(LocationsView);
        }

        //private void SharmaBtn_Click(object sender, EventArgs e)
        //{
        //    SelectLocations(LocationsView);
        //}
              

        private void LocationsView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //LocationsView.Items[e.Item.Index].Checked = true;

            ListView.CheckedListViewItemCollection checkedItems =
            LocationsView.CheckedItems;

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
            int colNum = LocationsView.Columns.Count;

            // Set first ROW as Column Headers Text
            foreach (ColumnHeader ch in LocationsView.Columns)
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
                foreach (ListViewItem lvi in LocationsView.Items)
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
                        //var tracks = (from y in pd.TechLocationss
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
                        //var tracks = (from y in pd.TechLocationsSharmas
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
                wBook.SaveAs(@currentUserPath + "\\Hill Robinson\\Project Bianca - Shared\\Technical\\TaskAlocation\\Contact List Al Yamama - " + date + " by " + Util.userConnected + " - " + machineName + " , " + userName + ". " + ".xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
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
           SelectLocations(LocationsView);//Sharma
        }

        private void rBtnAlYamama_CheckedChanged(object sender, EventArgs e)
        {
            AlYamamabtnState = true;
            SharmabtnState = false;
            Util.AlYamamabtn = true;
            Util.Sharmabtn = false;           
            SelectLocations(LocationsView);
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
            Util.LocationBuildingIdString = "MV";
            //add
            //if (cBoxBasement.Checked == true)// && cBoxAll.Checked == false)
            //    Util.LocationSublocationString += ",Basement,";
            //if(cBoxInProgress.Checked == true && cBoxAll.Checked == false)
            //    Util.StatusString += "In progress, ";
            //if (cBoxAll.Checked == true)
            //    Util.StatusString = "";
            //if (InternalcheckBox.Checked == true)
            //    Util.TypeString += "Internal, ";
            //if (ContractorcheckBox.Checked == true)
            //    Util.TypeString += "Contractor, ";
            ////last comma

            //remove
            //if (cBoxBasement.Checked == false)// && cBoxAll.Checked == false && Util.LocationSublocationString != String.Empty)
            //    Util.LocationSublocationString = Util.LocationSublocationString.Contains("Basement") ? Util.StatusString.Replace("Basement","") : Util.LocationSublocationString;
            ////if (cBoxOpen.Checked == false && cBoxAll.Checked == true)
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

            //if (cBoxFList.Checked == true)// && cBoxAll.Checked == false && Util.LocationSublocationString != String.Empty)
            //{
            //    Util.LocationBuildingIdString = "";
            //    Util.LocationSublocationString = "";

            //}

            pgNrTbox.Text = "1";

            SelectLocations(LocationsView);
        }

        private void InternalcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            quickFilterOption();
        }

        private void ContractorcheckBox_CheckedChanged(object sender, EventArgs e)
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

        private void cBoxBasement_CheckedChanged(object sender, EventArgs e)
        {
            quickFilterOption();
        }

        private void cBoxFList_CheckedChanged(object sender, EventArgs e)
        {
            quickFilterOption();
        }

      
        private void LocationFiltercheckedComboBox_DropDownClosed(object sender, EventArgs e)
        {
            Util.LocationBuildingIdString = LocationFiltercheckedComboBox.Text;
            SelectLocations(LocationsView);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbSession.Text = Util.currentSession;
        }

        private void lbSession_Click(object sender, EventArgs e)
        {

        }
    }
}
