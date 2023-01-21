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
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using IronPdf;


namespace HillRobinsonTech
{
    public partial class ExportInternalToPDF : Form
    {
        TechDboDataContext pd = new TechDboDataContext();
      
        public ExportInternalToPDF()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.WindowState = FormWindowState.Normal;
        }

        private void ExportInternalToPDF_Load(object sender, EventArgs e)
        {
            refNotBox.Text = Util.trackId.ToString();

            TaskDesctBox.Text = Util.issueDesc;
            //locationtBox.Text = Util.location;

            string location = Util.location;

            if (Util.subLocation != null && Util.subLocation != "")
                location = Util.location + ", " + Environment.NewLine + Util.subLocation;
            if (Util.specLocation != null && Util.specLocation != "")
                location += ", " + Environment.NewLine + Util.specLocation;
            if (Util.locationDetails != null && Util.locationDetails != "")
                location += ", " + Environment.NewLine + Util.locationDetails;


            locationtBox.Text = location;

            // DateCreatedTimePicker.Text = DateTime.Now.ToString();
            reportedBytBox.Text = Util.reportedBy;
            PrioritytBox.Text = Util.priority;
            PositiontBox.Text = Util.position;
            DepartmInternaltBox.Text = Util.departmentInternal;
            DateCreatedTimePicker.Text = Util.dateCreated;///DateTime.Now.ToString();            
            reportedBytBox.Text = Util.reportedBy;
            //DocReftBox.Text = Util.departmentRef;
            //EscalatedTotBox.Text = Util.escalatedTo;
           // EscalationComtBox.Text = Util.EscalComm;
           //// EscalationComBytBox.Text = Util.EscalCompBy;
           // EscalationStartDatetBox.Text = Convert.ToDateTime(Util.EscalStartDate.ToString()).ToShortDateString();
            AssignedTotBox.Text = Util.assignedTo;
            tBoxAsssignedToPerson.Text = Util.assignedToPerson;
            //EscalationCompDateTimePicker.Text = Util.EscalComplDate;

            //ClosingComtBox.Text = Util.closingComment;
            //NametBox.Text = Util.closedBy;
            //ClosingDateTimePicker.Text = Util.ClosingDate;
            //followUptBox.Text = Util.followUp;
        }

        private void antet2lbl_VisibleChanged(object sender, EventArgs e)
        {
            if (Util.exportLocation == "Al Yamamah")
            {
                antet2lbl.Text = "Internal Task Allocation - Al Yamamah";
            }
            else
            if (Util.exportLocation == "Sharma")
            {
                antet2lbl.Text = "Contractor Task Allocation - Sharma";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void reset()
        {
            Util.trackId = 0;
            Util.reportedBy = "";
            Util.departmentEsom = "";
            Util.location = "";
            Util.subLocation = "";
            Util.specLocation = "";
            Util.locationDetails = "";
            Util.dateCreated = DateTime.Now.ToString();
            Util.priority = "";
            Util.status = "";
            Util.issueDesc = "";
            Util.InternalRef = "";
            Util.escalation = false;
            Util.ContrToInternal = false;
            Util.ContractorTrackIdInternalRef = 0;

            Util.esomRef = "";
            Util.EscalComm = "";
            Util.EscalCompBy = "";
            Util.EscalStartDate = DateTime.Now.ToString();
            Util.Manager = "";
            Util.TechnicianAssigned = "";
            Util.EscalComplDate = "";

            Util.closingComment = "";
            Util.closedBy = "";
            Util.ClosingDate = DateTime.Now.ToString();
            Util.followUp = "";
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            reset();
            this.Dispose();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            string currentUserPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string userName = Environment.UserName;
            string machineName = Environment.MachineName;
            string userDepartment = Util.departmentConnected;
            string fileNameAlYamama = "Internal Task Allocation Al Yamamah no. " + refNotBox.Text + " - " + DateTime.Now.ToString("dd MMM yyyy").Replace("/", ".") + " by " + Util.userConnected + ".pdf".ToString();
            string pathAY = "\\Hill Robinson\\Project Bianca - Staff (Bianca)\\01- HRES COMPLAINT TRACKING SYSTEM\\" + userDepartment + "\\Internal Allocation\\";
            //"\\Hill Robinson\\Project Bianca - Shared\\Technical\\TaskAlocation\\Internal Allocation\\";
            string finalStringFile = "";// currentUserPath + "" + fileNameAlYamama;
            string fileNameSharma = "Internal Task Allocation Sharma no. " + refNotBox.Text + " - " + DateTime.Now.ToString("dd MMM yyyy").Replace("/", ".") + " by " + Util.userConnected + ".pdf".ToString();
            string pathSharma = "\\Hill Robinson\\Project Sharma - Shared\\Technical\\TaskAlocationSharma\\Internal Allocation\\";

            //check if shared folder is synced, otherwise save locally
            string subPath = currentUserPath + (Util.exportLocation == "Al Yamamah" ? pathAY : pathSharma);

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
                        TextBox textBox1 = new TextBox();
                        textBox1.Text = folderDlg.SelectedPath;
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        currentUserPath = (textBox1.Text + "\\").ToString();
                        continueOperation = true;
                    }
                }

            }
            if (exists)
            {
                if (Util.exportLocation == "Al Yamamah")
                    finalStringFile = currentUserPath + pathAY + fileNameAlYamama;

                else if (Util.exportLocation == "Sharma")
                    finalStringFile = currentUserPath + pathSharma + fileNameSharma;
            }
            if (!exists)
            {
                if (Util.exportLocation == "Al Yamamah")
                    finalStringFile = currentUserPath + fileNameAlYamama + ".pdf".ToString();
                else if (Util.exportLocation == "Sharma")
                    finalStringFile = currentUserPath + fileNameSharma + ".pdf".ToString();
            }

            if (exists || (!exists & continueOperation))
            {
                FileStream fs = new FileStream((finalStringFile), FileMode.Create, FileAccess.Write, FileShare.None);

                //string currentUserPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                //string fileName = currentUserPath + "\\Hill Robinson\\Project Bianca - Shared\\Technical\\TaskAlocation\\Internal Allocation\\Internal Task Allocation no. " + refNotBox.Text + " - " + DateTime.Now.Date.ToShortDateString().Replace("/", ".") + ".pdf".ToString();
                //FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);

                iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);
                Document doc = new Document(rec);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                var orange = FontFactory.GetFont("Calibri", 18, BaseColor.ORANGE);
                var blue = FontFactory.GetFont("Calibri", 18, new BaseColor(51, 153, 255));
                PdfPTable table = new PdfPTable(2);
                var phrase = new Phrase();
                phrase.Add(new Chunk(antet1lbl.Text.ToString() + Environment.NewLine, orange));
                phrase.Add(new Chunk(antet2lbl.Text.ToString() + Environment.NewLine, blue));

                PdfPCell cell = new PdfPCell(phrase);
                PdfPCell cell1 = new PdfPCell(iTextSharp.text.Image.GetInstance(pictureBox1.Image, System.Drawing.Imaging.ImageFormat.Jpeg));

                // var phraseBold = new Phrase();
                // phrase.Add(new Chunk("REASON(S) FOR CANCELLATION:", boldFont));

                PdfPCell cell2 = new PdfPCell(new Paragraph(antet2lbl.Text.ToString() + Environment.NewLine, blue));
                //cell.BackgroundColor = BaseColor.ORANGE;

                cell.VerticalAlignment = Element.ALIGN_LEFT;
                cell.FixedHeight = 60f;

                table.WidthPercentage = 100;
                table.SetWidths(new[] { 75f, 25f });

                cell.HorizontalAlignment = 0; // 0=left, 1= centre, 2= right
                cell.VerticalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                cell1.Border = 0;

                table.AddCell(cell);
                table.AddCell(cell1);

                doc.Add(table);

                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var Font = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                var boldFontWhite = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
                var boldFontMedium = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                var boldFontSmall = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8);//color: blue; background-color: red;

                //PdfPRow row = new PdfPRow();
                PdfPTable table5 = new PdfPTable(1);
                table5.WidthPercentage = 100;
                table5.SetWidths(new[] { 100f });
                table5.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table5.AddCell(new PdfPCell(new Phrase(new Chunk("Task description".ToString(), boldFontWhite))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT, BackgroundColor = new BaseColor(System.Drawing.Color.LightSteelBlue) });
                table5.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                doc.Add(table5);

                //string html = " <div> <br></div><div> <span style='font-weight: bold; color: blue; background-color: blue; text-align:center'><label>Task description</label></span> </div><div> <br></div>";

                //iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(doc);
                //hw.Parse(new StringReader(html));

                PdfPTable table2 = new PdfPTable(4);
                table2.WidthPercentage = 100;
                table2.SetWidths(new[] { 15f, 30f, 25f, 20f });

                table2.AddCell(new PdfPCell(new Phrase(new Chunk((reportedBylbl.Text.ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
                table2.AddCell(new PdfPCell(new Phrase((reportedBytBox.Text.ToString() + Environment.NewLine))) { FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
                table2.AddCell(new PdfPCell(new Phrase(new Chunk((refNolbl.Text.ToString() + "        " + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT });
                table2.AddCell(new PdfPCell(new Phrase((refNotBox.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });

                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

                PdfPCell cell3 = new PdfPCell(new Phrase(new Chunk((locationlbl.Text.ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT };
                cell3.Rowspan = 3;
                PdfPCell cell4 = new PdfPCell(new PdfPCell(new Phrase((locationtBox.Text), Font)) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
                cell4.Rowspan = 3;
                table2.AddCell(cell3);
                table2.AddCell(cell4);
                table2.AddCell(new PdfPCell(new Phrase(new Chunk((Datelbl.Text.ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT });
                table2.AddCell(new PdfPCell(new Phrase((DateCreatedTimePicker.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase(new Chunk((prioritylbl.Text.ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT });
                table2.AddCell(new PdfPCell(new Phrase((PrioritytBox.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });


                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

                table2.AddCell(new PdfPCell(new Phrase(new Chunk((DepartmEsomlbl.Text.ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
                table2.AddCell(new PdfPCell(new Phrase((DepartmInternaltBox.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
                table2.AddCell(new PdfPCell(new Phrase(new Chunk((lblIssuedTo.Text.ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT });
                table2.AddCell(new PdfPCell(new Phrase((AssignedTotBox.Text))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });



                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });


                table2.AddCell(new PdfPCell(new Phrase(new Chunk((TaskDiscriptionlbl.Text.ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
                PdfPCell cell5 = new PdfPCell(new PdfPCell(new Phrase((TaskDesctBox.Text))) { FixedHeight = 60, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
                cell5.Rowspan = 5;
                cell5.Colspan = 3;
                table2.AddCell(cell5);

                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table2.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

                doc.Add(table2);

                PdfPTable table6 = new PdfPTable(1);
                table6.WidthPercentage = 100;
                table6.SetWidths(new[] { 100f });
                table6.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table6.AddCell(new PdfPCell(new Phrase(new Chunk("Internal Escalation".ToString(), boldFontWhite))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT, BackgroundColor = new BaseColor(System.Drawing.Color.LightSteelBlue) });
                table6.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                doc.Add(table6);

                //string html2 = " <div> <span style='font-weight: bold; color: blue; background-color: blue; text-align:center'><label>Completion report </label></span> </div><div> <br></div>";

                //iTextSharp.text.html.simpleparser.HTMLWorker hw2 = new iTextSharp.text.html.simpleparser.HTMLWorker(doc);
                //hw2.Parse(new StringReader(html2));

                PdfPTable table3 = new PdfPTable(4);
                table3.WidthPercentage = 100;
                table3.SetWidths(new[] { 15f, 30f, 25f, 20f });

                table3.AddCell(new PdfPCell(new Phrase(new Chunk((EscalationStartDatelbl.Text.ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
                table3.AddCell(new PdfPCell(new Phrase((""))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });

                //PdfPCell cell20 = new PdfPCell(new Phrase(new Chunk((HrStamplbl.Text.ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 30, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT };
                //cell20.Rowspan = 3;
                //PdfPCell cell21 = new PdfPCell(new PdfPCell(new Phrase((HrStamptBox.Text))) { FixedHeight = 30, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
                //cell21.Rowspan = 3;
                //table3.AddCell(cell20);
                //table3.AddCell(cell21);
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

                table3.AddCell(new PdfPCell(new Phrase(new Chunk(("Assigned to:".ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
                table3.AddCell(new PdfPCell(new Phrase((""))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
                table3.AddCell(new PdfPCell(new Phrase(new Chunk((DocReflbl.Text.ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT });
                table3.AddCell(new PdfPCell(new Phrase((""))) { FixedHeight = 10, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });

                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

                table3.AddCell(new PdfPCell(new Phrase(new Chunk(("Comments:".ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
                PdfPCell cell6 = new PdfPCell(new PdfPCell(new Phrase((""))) { FixedHeight = 60, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
                cell6.Rowspan = 5;
                cell6.Colspan = 3;
                table3.AddCell(cell6);

                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table3.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });


                table3.AddCell(new PdfPCell(new Phrase(new Chunk((ConRepsignlbl.Text.ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
                table3.AddCell(new PdfPCell(new Phrase((""))) { FixedHeight = 10, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
                table3.AddCell(new PdfPCell(new Phrase(new Chunk((CompDatelbl.Text.ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT });
                table3.AddCell(new PdfPCell(new Phrase((""))) { FixedHeight = 10, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT });

                doc.Add(table3);

                PdfPTable table7 = new PdfPTable(1);
                table7.WidthPercentage = 100;
                table7.SetWidths(new[] { 100f });
                table7.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table7.AddCell(new PdfPCell(new Phrase(new Chunk("Close out".ToString(), boldFontWhite))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT, BackgroundColor = new BaseColor(System.Drawing.Color.LightSteelBlue) });
                table7.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                doc.Add(table7);

                //string html3 = " <div> <br></div><div> <span style='font-weight: bold; color: blue; background-color: blue; text-align:center'><label> Close out report</label></span> </div><div> <br></div>";

                //iTextSharp.text.html.simpleparser.HTMLWorker hw3 = new iTextSharp.text.html.simpleparser.HTMLWorker(doc);
                //hw2.Parse(new StringReader(html3));

                PdfPTable table4 = new PdfPTable(4);
                table4.WidthPercentage = 100;
                table4.SetWidths(new[] { 15f, 30f, 25f, 20f });
                table4.AddCell(new PdfPCell(new Phrase(new Chunk(("Comments:".ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
                PdfPCell cell7 = new PdfPCell(new PdfPCell(new Phrase((""))) { FixedHeight = 60, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
                cell7.Rowspan = 5;
                cell7.Colspan = 3;
                table4.AddCell(cell7);

                table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

                table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

                table4.AddCell(new PdfPCell(new Phrase(new Chunk((Namelbl.Text.ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
                table4.AddCell(new PdfPCell(new Phrase((""))) { FixedHeight = 10, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT });
                table4.AddCell(new PdfPCell(new Phrase(new Chunk(("Closing Date: ".ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 20, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT });
                table4.AddCell(new PdfPCell(new Phrase((""))) { FixedHeight = 10, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT });


                table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });


                PdfPCell cell8 = new PdfPCell(new Phrase(new Chunk((ConRepsignlbl.Text.ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 30, HorizontalAlignment = 0, VerticalAlignment = Element.ALIGN_LEFT };
                cell8.Rowspan = 3;
                PdfPCell cell9 = new PdfPCell(new PdfPCell(new Phrase((""))) { FixedHeight = 30, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
                cell9.Rowspan = 3;
                table4.AddCell(cell8);
                table4.AddCell(cell9);

                table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });
                table4.AddCell(new PdfPCell(new Phrase((""))) { Border = 0, FixedHeight = 10 });

                //PdfPCell cell10 = new PdfPCell(new Phrase(new Chunk((HrStamplbl.Text.ToString() + Environment.NewLine), boldFont))) { Border = 0, FixedHeight = 30, HorizontalAlignment = 1, VerticalAlignment = Element.ALIGN_LEFT };
                //cell10.Rowspan = 3;
                //PdfPCell cell11 = new PdfPCell(new PdfPCell(new Phrase((HrStamptBox.Text))) { FixedHeight = 30, HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_LEFT });
                //cell11.Rowspan = 3;
                //table4.AddCell(cell10);
                //table4.AddCell(cell11);

                doc.Add(table4);

                doc.Close();
                this.Dispose();

                //insert in log table
                int UserId = Util.userIdConnected;
                //string exportOption = option == "currentPage" ? "current page" : (option == "wholeList" ? "whole list" : "selected list");
                string Action = Util.exportLocation == "Sharma" ? "PDF export Sharma" : "PDF export AY";
                Action = continueOperation ? Action + " saved locally " : Action;
                string TableInvolved = Util.exportLocation == "Sharma" ? "TechIntTrackerSharma" : "TechIntTracker";
                string Description = "PDF export of track no : " + Util.trackId + ", " + (Util.exportLocation == "Sharma" ? fileNameSharma : fileNameAlYamama);
                DateTime UpdateTime = DateTime.ParseExact(DateTime.Now.ToString("MMM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MMM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                string MachineName = Util.userMachine;
                string Macc = Util.userMachineMacc;
                string IPAdress = Util.userIp;
                string CreatedByWinAcc = Util.windowsAccount;

                insertLog(UserId, Action, TableInvolved, Description, UpdateTime, MachineName, Macc, IPAdress, CreatedByWinAcc);
                Util.exportLocation = "";
            }
        }

        private void TechAsstBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CompDatelbl_Click(object sender, EventArgs e)
        {

        }

        private void CompDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ExportInternalToPDF_Load_1(object sender, EventArgs e)
        {

        }

        private void ComComlbl_Click(object sender, EventArgs e)
        {

        }

        private void ClosedByCmbBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DepartmEsomlbl_Click(object sender, EventArgs e)
        {

        }

        private void DepartmInternalcBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
