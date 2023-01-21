using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
//using PdfSharp.Drawing;
//using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using IronPdf;


namespace HillRobinsonTech
{
    public partial class InternalRecordOld : Form
    {
        TechDboDataContext pd = new TechDboDataContext();

        public Delegate UpdateInternal;

        public InternalRecordOld()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void InternalRecord_Load(object sender, EventArgs e)
        {
            departmentcBox.Text = Util.departmentInternal;
            refNotBox.Text = Util.trackId.ToString();
            locationtBox.Text = Util.location;
            DateCreatedTimePicker.Text = Util.dateCreated;///DateTime.Now.ToString();
            prioritycBox.Text = Util.priority;
            StatusCmbBox.Text = Util.status;
           // TypetBox.Text = Util.RecordType;
            TaskDesctBox.Text = Util.issueDesc;
            reportedBytBox.Text = Util.reportedBy;
            DocReftBox.Text = Util.departmentRef;
            AssignedTotBox.Text = Util.assignedTo;

            //EscalatedTocBox.Text = Util.escalatedTo;
           // DateRepDateTimePicker.Text = Util.reportDate;
            EscalationComtBox.Text = Util.EscalComm;
            EscalationComBytBox.Text = Util.EscalCompBy;
            EscalationStartDateTimePicker.Text = Util.EscalStartDate;
            EscalationCompDateTimePicker.Text = Util.EscalComplDate;
            ClosingComtBox.Text = Util.closingComment;
            CloseClosedBytBox.Text = Util.closedBy;
            ClosingDateTimePicker.Text = Util.ClosingDate;
            followUptBox.Text = Util.followUp;

            if (Util.newItem == true)           
            ExportPdfBtn.Enabled = false;
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            if (Util.newItem == true)
            {
                if (locationtBox.Text == string.Empty || TaskDesctBox.Text == string.Empty || prioritycBox.Text == string.Empty)
                {
                    MessageBox.Show("You have mandatory fields left empty. You cannot save without filling them in!");
                }
                else
                {
                    DialogResult rezultat = MessageBox.Show("Do you want to add a new track?", "Confirmation", MessageBoxButtons.OKCancel);
                    if (rezultat == DialogResult.OK)
                        insertTrack(null, null, TaskDesctBox.Text, locationtBox.Text, Convert.ToDateTime(DateCreatedTimePicker.Text), reportedBytBox.Text, prioritycBox.Text, DocReftBox.Text, AssignedTotBox.Text, Convert.ToDateTime(EscalationStartDateTimePicker.Text), ClosingComtBox.Text, followUptBox.Text, Convert.ToDateTime(EscalationCompDateTimePicker.Text), EscalationComtBox.Text, EscalationComBytBox.Text, CloseClosedBytBox.Text, departmentcBox.Text, Convert.ToDateTime(ClosingDateTimePicker.Text));
                }
            }
            if (Util.newItem == false)
            {
                DialogResult rezultat = MessageBox.Show("Do you want to update the track?", "Confirmation", MessageBoxButtons.OKCancel);
                if (rezultat == DialogResult.OK)
                    updateTrack(null, StatusCmbBox.Text, TaskDesctBox.Text, locationtBox.Text, Convert.ToDateTime(DateCreatedTimePicker.Text), reportedBytBox.Text, prioritycBox.Text, DocReftBox.Text, AssignedTotBox.Text, Convert.ToDateTime(EscalationStartDateTimePicker.Text),  ClosingComtBox.Text, followUptBox.Text, Convert.ToDateTime(EscalationCompDateTimePicker.Text), EscalationComtBox.Text, EscalationComBytBox.Text, CloseClosedBytBox.Text, departmentcBox.Text, Convert.ToDateTime(ClosingDateTimePicker.Text));
            }
            this.Dispose();
        }

        public void insertTrack(string RecordType, string StatusId, string IssueDesc, string LocationId, DateTime DateCreatedId, string ReportedById, string PriorityId, string DepartmRef, string AssignedToId, DateTime EscalationStartDate, string ClosingComm, string FollowUpId, DateTime EscalationCompDate, string EscalationCommId, string EscalationComById, string ClosedById, string DepartmInternal, DateTime CloseDate)
        {
            //TechIntTrackerTest dp = new TechIntTrackerTest()
            TechIntTracker dp = new TechIntTracker()
            {
                Type = "Internal".ToString(),
                Status = "Opened",
                IssueDescription = IssueDesc,
                Location = LocationId,
                DateCreated = DateCreatedId,
                //DateReceived = DateRec,
                //ReportDate = DateReported,
                ReportedBy = ReportedById,
                Priority = PriorityId,
                DepartmentRef = DepartmRef,
                AssignedTo = AssignedToId,
                //EscalatedTo = EscalatedToId,
                //ReportDate = RepDate,
                ClosingComment = ClosingComm,
                FollowUp = FollowUpId,
                EscalationStartDate = EscalationStartDate,
                EscalationComplDate = EscalationCompDate,
                EscalationComments = EscalationComById,
                EscalCompletedBy = EscalationComById,
                ClosedBy = ClosedById,
                DepartmentInternal = DepartmInternal,
                ClosingDate = CloseDate
        };

            try
            {
                //pd.TechIntTrackerTests.InsertOnSubmit(dp);
                pd.TechIntTrackers.InsertOnSubmit(dp);
                pd.SubmitChanges();
                MessageBox.Show("Data was successfully saved!");

                // Perform save operation 
                UpdateInternal.DynamicInvoke(); // this will call the `RefreshListView` method of mainWindow
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data was not saved!" + ex.Message);
            }
        }

        public void updateTrack(string RecordType, string StatusId, string IssueDesc, string LocationId, DateTime DateCreatedId, string ReportedById, string PriorityId, string DepartmRef, string AssignedToId, DateTime EscalationStartDate, string ClosingComm, string FollowUpId, DateTime EscalationCompDate, string EscalationCommId, string EscalationComById, string ClosedById, string DepartmInternal, DateTime CloseDate)
        {
            int trackId = Util.trackId;
            var trackUpdate = (from x in pd.TechIntTrackers
                                   //TechIntTrackerTests
                               where x.TrackId == trackId
                               select x);

            foreach (var x in trackUpdate)
            {
                x.Type = x.Type;
                x.Status = StatusId;// (x.Status == "Opened" ?  "In progress" : StatusId);
                x.IssueDescription = IssueDesc;
                x.Location = LocationId;
                x.DateCreated = DateCreatedId;
                //x.ReportDate = DateReported;
                //x.DateReceived = DateRec;
                x.ReportedBy = ReportedById;
                x.Priority = PriorityId;
                x.DepartmentRef = DepartmRef;
                x.AssignedTo = AssignedToId;
               // x.EscalatedTo = EscalatedToId;
               // x.ReportDate = RepDate;
                x.ClosingComment = ClosingComm;
                x.FollowUp = FollowUpId;
                x.EscalationStartDate = EscalationStartDate;
                x.EscalationComplDate = EscalationCompDate;
                x.EscalationComments = EscalationCommId;
                x.EscalCompletedBy = EscalationComById;
                x.ClosedBy = ClosedById;
                x.DepartmentInternal = DepartmInternal;
                x.ClosingDate = CloseDate;
            }

            try
            {
                pd.SubmitChanges();
                MessageBox.Show("Data was successfully updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data was not updated!" + ex.Message);
            }
        }

        private void AddFolDatebt_Click(object sender, EventArgs e)
        {
            string today = DateTime.Today.ToShortDateString();

            followUptBox.Text += !followUptBox.Text.Contains(today) ? today + "; " : "";
        }

        private void ExportPdfBtn_Click(object sender, EventArgs e)
        {
            //string currentUserPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            //string fileName = currentUserPath + "\\Hill Robinson\\Project Bianca - Shared\\Technical\\TaskAlocation\\Internal Alocation\\Internal Task Allocation no. " + refNotBox.Text + " - " + DateTime.Now.Date.ToShortDateString().Replace("/", ".") + ".pdf".ToString();
            //FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);

            //iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);
            //Document doc = new Document(rec);
            //PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            //doc.Open();

            //var orange = FontFactory.GetFont("Calibri", 18, BaseColor.ORANGE);
            //PdfPTable table = new PdfPTable(2);
            //PdfPCell cell = new PdfPCell(new Paragraph(antet1lbl.Text.ToString() + Environment.NewLine + antet2lbl.Text.ToString() + Environment.NewLine, orange));//, antet2lbl.Text.ToString() + Environment.NewLine;// (antet2lbl.Text.ToString() + Environment.NewLine),blue
            //PdfPCell cell1 = new PdfPCell(iTextSharp.text.Image.GetInstance(pictureBox1.Image, System.Drawing.Imaging.ImageFormat.Jpeg));

            //var blue = FontFactory.GetFont("Calibri", 18, BaseColor.BLUE);
            //PdfPCell cell2 = new PdfPCell(new Paragraph(antet2lbl.Text.ToString() + Environment.NewLine, blue));
            ////cell.BackgroundColor = BaseColor.ORANGE;

            //cell.VerticalAlignment = Element.ALIGN_LEFT;
            //cell.FixedHeight = 60f;

            //table.WidthPercentage = 100;
            //table.SetWidths(new[] { 75f, 25f });

            //cell.HorizontalAlignment = 0; // 0=left, 1= centre, 2= right
            //cell.VerticalAlignment = Element.ALIGN_LEFT;
            //cell.Border = 0;
            //cell1.Border = 0;

            //table.AddCell(cell);
            //table.AddCell(cell1);

            //doc.Add(table);

            //string html = " <div> <br></div><div> <span style='font-weight: bold; color: blue; background-color: blue; text-align:center'><label>Preliminary info</label></span> </div><div> <br></div>";

            //iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(doc);
            //hw.Parse(new StringReader(html));

            //PdfPTable table2 = new PdfPTable(4);
            //table2.WidthPercentage = 100;
            //table2.SetWidths(new[] { 20f, 40f, 20f, 20f });
            //table2.AddCell(new PdfPCell(new Phrase((deplbl.Text.ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
            //table2.AddCell(new PdfPCell(new Phrase((departmentcBox.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
            //table2.AddCell(new PdfPCell(new Phrase((refNolbl.Text.ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT });
            //table2.AddCell(new PdfPCell(new Phrase((refNotBox.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });

            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

            //PdfPCell cell3 = new PdfPCell(new Phrase((locationlbl.Text.ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT };
            //cell3.Rowspan = 3;
            //PdfPCell cell4 = new PdfPCell(new PdfPCell(new Phrase((locationtBox.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
            //cell4.Rowspan = 3;
            //table2.AddCell(cell3);
            //table2.AddCell(cell4);
            //table2.AddCell(new PdfPCell(new Phrase((Datelbl.Text.ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT });
            //table2.AddCell(new PdfPCell(new Phrase((dateTimePicker1.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((prioritylbl.Text.ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT });
            //table2.AddCell(new PdfPCell(new Phrase((prioritycBox.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });

            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

            //table2.AddCell(new PdfPCell(new Phrase((TaskDiscriptionlbl.Text.ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
            //PdfPCell cell5 = new PdfPCell(new PdfPCell(new Phrase((TaskDesctBox.Text))) { FixedHeight = 60, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
            //cell5.Rowspan = 5;
            //cell5.Colspan = 3;
            //table2.AddCell(cell5);

            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

            //table2.AddCell(new PdfPCell(new Phrase((reportedBylbl.Text.ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
            //table2.AddCell(new PdfPCell(new Phrase((reportedBycBox.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
            //table2.AddCell(new PdfPCell(new Phrase((DocReflbl.Text.ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT });
            //table2.AddCell(new PdfPCell(new Phrase((DocRefcBox.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });

            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

            //table2.AddCell(new PdfPCell(new Phrase((EscalatedTolbl.Text.ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
            //table2.AddCell(new PdfPCell(new Phrase((EscalatedBycBox.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
            //table2.AddCell(new PdfPCell(new Phrase((DateReplbl.Text.ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT });
            //table2.AddCell(new PdfPCell(new Phrase((DateRepDateTimePicker.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });

            //doc.Add(table2);

            //string html2 = " <div> <br></div><div> <span style='font-weight: bold; color: blue; background-color: blue; text-align:center'><label>Completion report</label></span> </div><div> <br></div>";

            //iTextSharp.text.html.simpleparser.HTMLWorker hw2 = new iTextSharp.text.html.simpleparser.HTMLWorker(doc);
            //hw2.Parse(new StringReader(html2));

            //PdfPTable table3 = new PdfPTable(4);
            //table3.WidthPercentage = 100;
            //table3.SetWidths(new[] { 20f, 40f, 20f, 20f });
            //table3.AddCell(new PdfPCell(new Phrase(("Comments:".ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
            //PdfPCell cell6 = new PdfPCell(new PdfPCell(new Phrase((ComComtBox.Text))) { FixedHeight = 60, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
            //cell6.Rowspan = 5;
            //cell6.Colspan = 3;
            //table3.AddCell(cell6);

            //table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

            //table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

            //table3.AddCell(new PdfPCell(new Phrase((ComComBylbl.Text.ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
            //table3.AddCell(new PdfPCell(new Phrase((ComComBycBox.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
            //table3.AddCell(new PdfPCell(new Phrase((CompDatelbl.Text.ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT });
            //table3.AddCell(new PdfPCell(new Phrase((CompDateTimePicker.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });

            //doc.Add(table3);

            //string html3 = " <div> <br></div><div> <span style='font-weight: bold; color: blue; background-color: blue; text-align:center'><label>Closing report</label></span> </div><div> <br></div>";

            //iTextSharp.text.html.simpleparser.HTMLWorker hw3 = new iTextSharp.text.html.simpleparser.HTMLWorker(doc);
            //hw2.Parse(new StringReader(html3));

            //PdfPTable table4 = new PdfPTable(4);
            //table4.WidthPercentage = 100;
            //table4.SetWidths(new[] { 20f, 40f, 20f, 20f });
            //table4.AddCell(new PdfPCell(new Phrase(("Comments:".ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
            //PdfPCell cell7 = new PdfPCell(new PdfPCell(new Phrase((ClosingComtBox.Text))) { FixedHeight = 60, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
            //cell7.Rowspan = 5;
            //cell7.Colspan = 3;
            //table4.AddCell(cell7);

            //table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

            //table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

            //table4.AddCell(new PdfPCell(new Phrase((ClosedBylbl.Text.ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
            //table4.AddCell(new PdfPCell(new Phrase((ClosedByCmbBox.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
            //table4.AddCell(new PdfPCell(new Phrase((InspectionDatelbl.Text.ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT });
            //table4.AddCell(new PdfPCell(new Phrase((InspDateTimePicker.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });

            //table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

            //// PdfPCell cell8 = new PdfPCell(new Phrase((signlbl.Text.ToString() + Environment.NewLine))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT };
            //// cell3.Rowspan = 3;
            ////PdfPCell cell9 = new PdfPCell(new PdfPCell(new Phrase((SigntBox.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
            //// cell4.Rowspan = 3;
            ////  table4.AddCell(cell8);
            //// table4.AddCell(cell9);

            //table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
            //table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

            //doc.Add(table4);

            //doc.Close();
            this.Dispose();
            ExportInternalToPDF form = new ExportInternalToPDF();
            form.ShowDialog();
            

        }
    }
    
}
