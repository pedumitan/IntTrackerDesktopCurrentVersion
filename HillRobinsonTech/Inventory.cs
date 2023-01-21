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
    public partial class Inventory : Form
    {
        TechDboDataContext pd = new TechDboDataContext();
        ImageList Imagelist = new ImageList();

        public Inventory()
        {
            InitializeComponent();
            InventorySharmaView.FullRowSelect = true;
            InventorySharmaView.GridLines = true;
            InventorySharmaView.View = View.Details;
            //UserView.Items.Add(new ListViewItem() { ImageIndex = 0 });
            this.CenterToScreen();
            //Util.persAccount = false;
           // this.WindowState = FormWindowState.Maximized;
            CustomizeUserView(InventorySharmaView);   
        }

       

        private void InventorySharma_Load(object sender, EventArgs e)
        {
            SelectInventorySharma(InventorySharmaView);
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


        public void CustomizeUserView(ListView InventorySharmaView)
        {
            this.InventorySharmaView.View = View.Details;
            this.InventorySharmaView.FullRowSelect = true;
            //Task Description
            this.InventorySharmaView.Columns.Add("Id");
            this.InventorySharmaView.Columns.Add("ItemNo");
            this.InventorySharmaView.Columns.Add("Category");
            this.InventorySharmaView.Columns.Add("Brand");
            this.InventorySharmaView.Columns.Add("Code");
            this.InventorySharmaView.Columns.Add("UOM");
            this.InventorySharmaView.Columns.Add("Description");
            this.InventorySharmaView.Columns.Add("Total");
            this.InventorySharmaView.Columns.Add("Last Update");

            ResizeListViewColumns(this.InventorySharmaView);
        }

        public void ResizeListViewColumns(ListView IntTrackerView)
        {
            foreach (ColumnHeader column in IntTrackerView.Columns)
            {
                column.Width = -2;
            }
        }
    
        public void SelectInventorySharma(ListView InventorySharmaView)
        {
           // InventorySharmaView.Items.Clear();

           //// if (!Util.FilterUsed)
           // //{

           //     var inventoryItems = (from x in pd.InventorySharmas
           //                   select x).OrderBy(v => (int)v.id);//OrderByDescending


           //     int i = 1;
           //     foreach (var item in inventoryItems)
           //     {
           //         ListViewItem lviInventorySharma = new ListViewItem(item.id.ToString());              


           //         //set the font to the item
           //         lviInventorySharma.Font = new System.Drawing.Font(lviInventorySharma.Font, FontStyle.Regular);

           //         lviInventorySharma.SubItems.Add(item.ItemNo != null ? item.ItemNo.ToString() : "");
           //         lviInventorySharma.SubItems.Add(item.Category != null ? item.Category.ToString() : "");
           //         lviInventorySharma.SubItems.Add(item.Brand != null ? item.Brand.ToString() : "");
           //         lviInventorySharma.SubItems.Add(item.Code != null ? item.Code.ToString() : "");
           //         lviInventorySharma.SubItems.Add(item.UOM != null ? item.UOM.ToString() : "");
           //         lviInventorySharma.SubItems.Add(item.Description != null ? item.Description.ToString() : "");
           //         lviInventorySharma.SubItems.Add(item.Total != null ? item.Total.ToString() : "");


           //         InventorySharmaView.Items.Add(lviInventorySharma);
           //         i++;
           //    }
           //    showlbl.Text = "Displaying " + (i - 1) + " item(s)";
            //}



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
            Util.department = "";
            Util.user = "";
            Util.pass = "";
            Util.name = "";
            Util.Email = "";
            Util.active = 1;

            //Util.newUser = true;
            //UserEdit form = new UserEdit();
            //form.FormClosed += new FormClosedEventHandler(child_FormClosedRefresh); //add handler to catch when child form is closed
            //form.ShowDialog();                             
        }
        //void child_FormClosedRefresh(object sender, FormClosedEventArgs e)
        //{
        //    //when child form is closed, this code is executed
        //    InventorySharmaView.Items.Clear();
        //    InventorySharma_Load(sender, e);
        //    //Refresh(sender, e);
        //}
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            //IntTracker_Load(sender, e);
            InventorySharmaView.Items.Clear();
            Refresh(sender, e);
        }
        public void Refresh(object sender, EventArgs e)
        {
            InventorySharma_Load(sender, e);
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
            InventorySharma_Load(sender, e);
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

            //    using (SqlCommand cmd = new SqlCommand("GetSearchString", connection))
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

            //        connection.Close();
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
