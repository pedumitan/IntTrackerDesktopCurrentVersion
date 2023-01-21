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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using IronPdf;


namespace HillRobinsonTech
{
    public partial class ContractorRecordSharma : Form
    {
        TechDboDataContext pd = new TechDboDataContext();       

        public Delegate UpdateContractor;
      
        public ContractorRecordSharma()
        {
            InitializeComponent();
            this.CenterToScreen();
            //this.WindowState = FormWindowState.Maximized;

            if (Util.userTypeConnected == "guest" || !Util.departmentConnected.Contains("Technical"))
            {
                savebtn.Enabled = false;
                ExportPdfBtn.Enabled = false;               
            }

            if (Util.userListInDepartment.Count > 0)
                Util.userListInDepartment.Clear();
            Util.userDisplay();

            foreach (var item in Util.userListInDepartment)
            {
                ClosedByCmbBox.Items.Add(item);
            }

        }

        private void ContractorRecord_Load(object sender, EventArgs e)
        {
            cBoxTesting.Visible = (Util.userIdConnected == 1 || Util.userIdConnected == 2) ? true : false;

            refNotBox.Text = Util.trackId.ToString();
            if(Util.status != "")
            StatusCmbBox.Text = Util.status;
            else
                StatusCmbBox.SelectedIndex = 0;

            if (Util.priority != "")
            prioritycBox.Text = Util.priority;
            else
                prioritycBox.SelectedIndex = 2;

            cBoxDuringAfterVisit.Text = Util.duringAfterVisit;
            TaskDesctBox.Text = Util.issueDesc;

            if (Util.location != "")
                cBoxlocation.Text = Util.location;
            else
                cBoxlocation.SelectedIndex = 0;

            cBoxSublocation.Text = Util.subLocation;
            SpecLocationtBox.Text = Util.specLocation;
            DetailstBox.Text = Util.locationDetails;
            DateCreatedTimePicker.Text = Util.dateCreated;///DateTime.Now.ToString();
            dateTimePickerDueByDate.Text = Util.dueDate;
            tBoxDaysOpen.Text = Util.daysOpen != "" ? Util.daysOpen : "1";

            if (Util.newItem)
            {
                reportedBytBox.Text = Util.fullNameConnected;
            }
            else
            { reportedBytBox.Text = Util.reportedBy; }

            cBoxOwner.Text = Util.Owner != "" ? Util.Owner : "CPPA"; 

            if(Util.assignedTo != "")
            cBoxAssignedTo.Text = Util.assignedTo;
            else
                cBoxAssignedTo.SelectedIndex = 0;

            EscalationStartDateTimePicker.Text = Util.EscalStartDate;
            EsomReftBox.Text = Util.esomRef;
            tBoxActionPlan.Text = Util.ActionPlan;
            EscalationComtBox.Text = Util.EscalComm;
            ManagertBox.Text = Util.Manager;
            TechAssignedtBox.Text = Util.TechnicianAssigned;
           
            cBoxEscalationComBy.Text = Util.EscalCompBy;
            if(!cBoxEscalationComBy.Items.Contains(Util.fullNameConnected))
            cBoxEscalationComBy.Items.Add(Util.fullNameConnected);

            //Util.EscalCompBy != "" ? Util.EscalCompBy : Util.fullNameConnected;  //Util.EscalCompBy;
            EscalationCompDateTimePicker.Text = Util.EscalComplDate;
            DepartmEsomcBox.Text = Util.departmentEsom;
            tBoxMaterials.Text = Util.MaterialsNeeded;
            tBoxMaterials.Enabled = Util.MaterialsNeeded != "" ? true : false;
            lbMatNeeded.Enabled = Util.MaterialsNeeded != "" ? true : false;
            rButtonYes.Checked = Util.MaterialsNeeded != "" ? true : false;
            rBtnNo.Checked = Util.MaterialsNeeded != "" ? false : true;



            ClosedByCmbBox.Text = Util.closedBy;
            if (!ClosedByCmbBox.Items.Contains(Util.fullNameConnected))
                ClosedByCmbBox.Items.Add(Util.fullNameConnected);
            //Util.closedBy != "" ? Util.closedBy : Util.fullNameConnected; //Util.closedBy;
            ClosingDateTimePicker.Text = Util.ClosingDate;
            ClosingComtBox.Text = Util.closingComment;
            followUptBox.Text = Util.followUp;

            tBoxHLRFReport.Text = Util.HLRFReport;
            tBoxFRContractor.Text = Util.ContractorFReport;

            if (Util.newItem == true)
                ExportPdfBtn.Enabled = false;
            if (Util.newItem == false)
            {
                //reportedBytBox.Enabled = false;
                //locationtBox.Enabled = false;
                //SublocationtBox.Enabled = false;
                //SpecLocationtBox.Enabled = false;
                //DetailstBox.Enabled = false;
                //DateCreatedTimePicker.Enabled = false;
                //prioritycBox.Enabled = false;
                //DepartmEsomcBox.Enabled = false;
                ////StatusCmbBox.Enabled = false;
                //TaskDesctBox.Enabled = false;
            }
            if (Util.userRolePermissions.Contains("TESTING_OPTION") || (Util.userPermissions.Count > 0 && Util.userPermissions.Contains("TESTING_OPTION")))
                cBoxTesting.Visible = true;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
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



            this.Dispose();
        }
        public void savebtn_Click(object sender, EventArgs e)
        {
            //+= String.Join(":", nic.GetPhysicalAddress().GetAddressBytes().Select(b => b.ToString("X2")).ToArray());
            //DateTime dt = DateTime.ParseExact("05-16-2014", format, CultureInfo.InvariantCulture, DateTimeStyles.None);
            //IFormatProvider culture = new CultureInfo("en-US", true);

            if (Util.newItem == true)
            {
                if (cBoxlocation.Text == string.Empty || TaskDesctBox.Text == string.Empty || prioritycBox.Text == string.Empty
                    /*|| EscalatedTocBox.Text == string.Empty || DepartmEsomcBox.Text == string.Empty*/)///////////to add, improve!!!
                {
                    MessageBox.Show("You have mandatory fields left empty. You cannot save without filling them in!");
                    Util.SaveError = true;
                }
                else
                {
                    DialogResult rezultat = MessageBox.Show("Do you want to add a new track?", "Confirmation", MessageBoxButtons.OKCancel);
                    if (rezultat == DialogResult.OK)
                        insertTrack(null, StatusCmbBox.Text, prioritycBox.Text, cBoxDuringAfterVisit.Text, TaskDesctBox.Text, cBoxlocation.Text, cBoxSublocation.Text, SpecLocationtBox.Text, DetailstBox.Text, DateTime.ParseExact(DateCreatedTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), DateTime.ParseExact(dateTimePickerDueByDate.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), Convert.ToInt32(tBoxDaysOpen.Text), 0,null, reportedBytBox.Text, cBoxOwner.Text, cBoxAssignedTo.Text, DateTime.ParseExact(EscalationStartDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), EsomReftBox.Text, tBoxActionPlan.Text, EscalationComtBox.Text, ManagertBox.Text, TechAssignedtBox.Text, cBoxEscalationComBy.Text, DateTime.ParseExact(EscalationCompDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), DepartmEsomcBox.Text, tBoxMaterials.Text, ClosedByCmbBox.Text, DateTime.ParseExact(ClosingDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), ClosingComtBox.Text, followUptBox.Text,  tBoxHLRFReport.Text, tBoxFRContractor.Text,   0,  DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), null,null, null, null, 0);
                }
            }
            if (Util.newItem == false)
            {
                DialogResult rezultat = MessageBox.Show("Do you want to update the track?", "Confirmation", MessageBoxButtons.OKCancel);
                    if (rezultat == DialogResult.OK)
                        updateTrack(null, StatusCmbBox.Text, prioritycBox.Text, cBoxDuringAfterVisit.Text, TaskDesctBox.Text, cBoxlocation.Text, cBoxSublocation.Text, SpecLocationtBox.Text, DetailstBox.Text, DateTime.ParseExact(DateCreatedTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), DateTime.ParseExact(dateTimePickerDueByDate.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), Convert.ToInt32(tBoxDaysOpen.Text), 0, reportedBytBox.Text, cBoxOwner.Text, cBoxAssignedTo.Text, DateTime.ParseExact(EscalationStartDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), EsomReftBox.Text, tBoxActionPlan.Text, EscalationComtBox.Text, ManagertBox.Text, TechAssignedtBox.Text, cBoxEscalationComBy.Text, DateTime.ParseExact(EscalationCompDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), DepartmEsomcBox.Text, tBoxMaterials.Text, ClosedByCmbBox.Text, DateTime.ParseExact(ClosingDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), ClosingComtBox.Text, followUptBox.Text, tBoxHLRFReport.Text, tBoxFRContractor.Text, 0,null, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), null, null, null, null, 0);
            }
            if (Util.SaveError != true)
                this.Dispose();
            Util.SaveError = false;


           
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
            Util.reportedBy = "";

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


        }

        public void insertTrack(string RecordType, string StatusId, string PriorityId, string DuringAfterVisit, string IssueDesc, string LocationId, string SubLocationId, string SpecLocationId, string DetailsId, DateTime DateCreatedId, DateTime DueByDate, int DaysOpen, int CreatedBy, string CreatedByVersion, string ReportedById, string Owner, string AssignedTo, DateTime EscalationStartDate, string EsomRefer, string ActionPlan, string EscalationCommId, string ManagerId, string TechAss, string EscalationComById, DateTime EscalCompDate, string DepartmEsom, string Materials, string ClosedById, DateTime CloseDate, string ClosingComm, string FollowUpId, string HLRFReport, string ContractorFreport,        int UserId, DateTime LastUpdate, string MachineName, string Macc, string IPAdress, string CreatedByWinAcc, int TestingId)
        {
            IPAdress = Util.userIp; //Dns.GetHostAddresses(Environment.MachineName)[1].ToString();

            TechIntTrackerSharma dp = new TechIntTrackerSharma()
            {
                Type = "Contractor".ToString(),
                Status = StatusId != "" ? StatusId : "Open",
                Priority = PriorityId,
                DuringAfterVisit = DuringAfterVisit,
                IssueDescription = IssueDesc,

                Location = LocationId,
                SublocationArea = SubLocationId,
                SpecificLocation = SpecLocationId,
                LocationDetails = DetailsId,

                DateCreated = DateCreatedId,
                DueByDate = DueByDate,
                DaysOpen = DaysOpen,
                CreatedBy = Util.userIdConnected,
                CreatedByVersion = Util.fullVersionInfo,
                ReportedBy = ReportedById,
                Owner = Owner,
                AssignedTo = AssignedTo,

                EscalationStartDate = EscalationStartDate,
                EsomRef = EsomRefer,
                ActionPlan = ActionPlan,
                EscalationComments = EscalationCommId,
                Manager = ManagerId,
                TechnicianAssigned = TechAss,
                EscalCompletedBy = EscalationComById,
                EscalationComplDate = EscalCompDate,
                DepartmentEsom = DepartmEsom,
                MaterialsNeeded = Materials,

                ClosedBy = ClosedById,
                ClosingDate = CloseDate,
                ClosingComment = ClosingComm,
                FollowUp = FollowUpId,     

                HLRFinalReport = HLRFReport,
                ContractorFReport = ContractorFreport,   
               
                UserId = Util.userIdConnected,
                LastUpdate = LastUpdate,
                HostMachine = Util.userMachine,
                HostMaccAdress = Util.userMachineMacc,
                IPAdress = IPAdress,
                WindowsAccount = Environment.UserName,

                Testing = cBoxTesting.Checked == true ? 1 : 0
            };
           

            try
            {
               // pd.TechIntTrackerTests.InsertOnSubmit(dp);
               //if(Util.AlYamamabtn == true)
                pd.TechIntTrackerSharmas.InsertOnSubmit(dp);
               //if(Util.Sharmabtn  == true)
               // pd.TechIntTrackerSharmas.InsertOnSubmit(dp2); 
                pd.SubmitChanges();
                MessageBox.Show("Data was successfully saved!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Data was not saved!" + ex.Message);
            }
        }

        public void updateTrack(string RecordType, string StatusId, string PriorityId, string DuringAfterVisit, string IssueDesc, string LocationId, string SubLocationId, string SpecLocationId, string DetailsId, DateTime DateCreatedId, DateTime DueByDate, int DaysOpen, int CreatedBy, string ReportedById, string Owner, string AssignedTo, DateTime EscalationStartDate, string EsomRefer, string ActionPlan, string EscalationCommId, string ManagerId, string TechAss, string EscalationComById, DateTime EscalCompDate, string DepartmEsom, string Materials, string ClosedById, DateTime CloseDate, string ClosingComm, string FollowUpId, string HLRFReport, string ContractorFreport, int UserId, string UpdatedByVersion, DateTime LastUpdate, string MachineName, string Macc, string IPAdress, string UpdatedByWinAcc, int TestingId)
        {
            int trackId = Util.trackId;
            IPAdress = Util.userIp;//Dns.GetHostAddresses(Environment.MachineName)[1].ToString();
            //if (Util.AlYamamabtn == true)
            //{
            //    var trackUpdateAlY = (from x in pd.TechIntTrackers
            //                              //TechIntTrackerTests 
            //                          where x.TrackId == trackId
            //                          select x);

            //    foreach (var x in trackUpdateAlY)
            //    {
            //        x.Type = x.Type;
            //        x.Status = StatusId;// CloseClosedByCmbBox.Text == "" ?  "In progress" : "Closed";
            //        x.IssueDescription = IssueDesc;
            //        x.Location = LocationId;
            //        x.SublocationArea = SubLocationId;
            //        x.SpecificLocation = SpecLocationId;
            //        x.LocationDetails = DetailsId;
            //        x.DateCreated = DateCreatedId; 
            //        x.ReportedBy = ReportedById;
            //        x.Priority = PriorityId;
            //        x.EsomRef = EsomRefer;
            //        // x.EscalatedTo = EscalatedToId; 
            //        // x.ReportDate = RepDate;
            //        x.ClosingComment = ClosingComm;
            //        x.FollowUp = FollowUpId;
            //        x.EscalationStartDate = EscalationStartDate; 
            //        x.Manager = ManagerId;
            //        x.TechnicianAssigned = TechAss;
            //        x.EscalationComplDate = EscalCompDate; 
            //        x.EscalationComments = EscalationCommId;
            //        x.EscalCompletedBy = EscalationComById;
            //        x.ClosedBy = ClosedById;
            //        x.DepartmentEsom = DepartmEsom;
            //        x.ClosingDate = CloseDate;
            //        x.UserId = Util.userIdConnected;
            //        x.LastUpdate = LastUpdate;
            //        x.HostMachine = Util.userMachine;
            //        x.HostMaccAdress = Util.userMachineMacc;
            //        x.IPAdress = IPAdress;
            //        x.WindowsAccount = Environment.UserName;
            //    }
            //}
            //else
            //if (Util.Sharmabtn == true)
            //{
                var trackUpdateSharma = (from x in pd.TechIntTrackerSharmas
                                             //TechIntTrackerTests 
                                         where x.TrackId == trackId
                                         select x);

                foreach (var x in trackUpdateSharma)
                {
                    x.Type = x.Type;
                    x.Status = StatusId;// CloseClosedByCmbBox.Text == "" ?  "In progress" : "Closed";
                    x.Priority = PriorityId;
                    x.DuringAfterVisit = DuringAfterVisit;
                    x.IssueDescription = IssueDesc;

                    x.Location = LocationId;
                    x.SublocationArea = SubLocationId;
                    x.SpecificLocation = SpecLocationId;
                    x.LocationDetails = DetailsId;

                    x.DateCreated = DateCreatedId;
                    x.DueByDate = DueByDate;
                    x.DaysOpen = DaysOpen;
                    x.UserId = UserId;
                    x.ReportedBy = ReportedById;
                    x.Owner = Owner;
                    x.AssignedTo = AssignedTo;

                    x.EscalationStartDate = EscalationStartDate;
                    x.EsomRef = EsomRefer;
                    x.ActionPlan = ActionPlan;
                    x.EscalationComments = EscalationCommId;
                    x.Manager = ManagerId;
                    x.TechnicianAssigned = TechAss;
                    x.EscalCompletedBy = EscalationComById;
                    x.EscalationComplDate = EscalCompDate;
                    x.DepartmentEsom = DepartmEsom;
                    x.MaterialsNeeded = Materials;

                    x.ClosedBy = ClosedById;
                    x.ClosingDate = CloseDate;
                    x.ClosingComment = ClosingComm;
                    x.FollowUp = FollowUpId;

                    x.HLRFinalReport = HLRFReport;
                    x.ContractorFReport = ContractorFreport;
                   
                    
                    x.UserId = Util.userIdConnected;
                    x.UpdatedByVersion = Util.fullVersionInfo;
                    x.LastUpdate = LastUpdate;
                    x.HostMachine = Util.userMachine;
                    x.HostMaccAdress = Util.userMachineMacc;
                    x.IPAdress = IPAdress;
                    x.WindowsAccount = Environment.UserName;

                    x.Testing = cBoxTesting.Checked == true ? 1 : 0;
            }
            //}

            try
            {

                pd.SubmitChanges();
                MessageBox.Show("Data was successfully updated!");

                // Perform save operation 
                UpdateContractor.DynamicInvoke(); // this will call the `RefreshListView` method of mainWindow
               //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data was not updated!" + ex.Message);
            }         

        }

        private void AddFolDatebt_Click(object sender, EventArgs e)
        {
            string today = DateTime.Today.ToShortDateString();
            string shortDate = today.Substring(0, today.Length - 5);

            followUptBox.Text += !followUptBox.Text.Contains(shortDate) ? shortDate + " - " : "";
        }

        private void ExportPdfBtn_Click(object sender, EventArgs e)
        {
            Util.exportLocation = "Sharma";
            ExportContractorToPDF form = new ExportContractorToPDF();
            form.ShowDialog();          

        }

        private void DocReflbl_Click(object sender, EventArgs e)
        {

        }

        private void antet2lbl_Validating(object sender, CancelEventArgs e)
        {
            //if (Util.AlYamamabtn == true)
            //{
            //    antet2lbl.Text = "Contractor Task Allocation - Al Yamama";
            //}
            //else
            //    antet2lbl.Text = "Contractor Task Allocation - Sharma";
        }

        private void antet2lbl_Validated(object sender, EventArgs e)
        {
            //if (Util.AlYamamabtn == true)
            //{
            //    antet2lbl.Text = "Contractor Task Allocation - Al Yamama";
            //}
            //else
            //    antet2lbl.Text = "Contractor Task Allocation - Sharma";
        }

        private void antet2lbl_Layout(object sender, LayoutEventArgs e)
        {
            //if (Util.AlYamamabtn == true)
            //{
            //    antet2lbl.Text = "Contractor Task Allocation - Al Yamama";
            //}
            //else
            //    antet2lbl.Text = "Contractor Task Allocation - Sharma";
        }

        private void antet2lbl_VisibleChanged(object sender, EventArgs e)
        {
            //if (Util.AlYamamabtn == true)
            //{
            //    antet2lbl.Text = "Contractor Task Allocation - Al Yamama";
            //}
            //else
            //if (Util.Sharmabtn == true)
            //{
            //    antet2lbl.Text = "Contractor Task Allocation - Sharma";
            //}
        }

        private void infoBtn_MouseHover(object sender, EventArgs e)
        {
            contractorToolTip.Show("Click to display info of the page!", infoBtn);
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            ContractorRecordInfo form = new ContractorRecordInfo();
            form.ShowDialog();
        }

        private void ContractorRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Are you sure you want to quit?", "My Application", MessageBoxButtons.YesNo) == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}


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
            Util.reportedBy = "";

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

        }

        private void AddComlDatebt_Click(object sender, EventArgs e)
        {
            string today = DateTime.Today.ToShortDateString();
            string shortDate = today.Substring(0, today.Length - 5);

            EscalationComtBox.Text += !EscalationComtBox.Text.Contains(shortDate) ? shortDate + " - " : "";
        }

        private void reportedBylbl_Click(object sender, EventArgs e)
        {

        }

        private void reportedBytBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerDueByDate_ValueChanged(object sender, EventArgs e)
        {
            //int daysOpen = dateTimePickerDueByDate.Value.Date.Subtract(DateTime.Now.Date).Days - DateCreatedTimePicker.Value.Date.Subtract(DateTime.Now.Date).Days;
            //tBoxDaysOpen.Text = daysOpen.ToString();

            DateTime dueByDate = DateTime.ParseExact(dateTimePickerDueByDate.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime closingDate = DateTime.ParseExact(ClosingDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            if (closingDate < dueByDate)
            ClosingDateTimePicker.Text = dateTimePickerDueByDate.Text;
        }

        private void DateCreatedTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateCreated = DateTime.ParseExact(DateCreatedTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime dueByDate = DateTime.ParseExact(dateTimePickerDueByDate.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime startDate = DateTime.ParseExact(EscalationStartDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime completionDate = DateTime.ParseExact(EscalationCompDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime closingDate = DateTime.ParseExact(ClosingDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            if (dueByDate < dateCreated)
                dateTimePickerDueByDate.Text = DateCreatedTimePicker.Text;

            int daysOpen = ClosingDateTimePicker.Value.Date.Subtract(DateTime.Now.Date).Days - DateCreatedTimePicker.Value.Date.Subtract(DateTime.Now.Date).Days +1;
            tBoxDaysOpen.Text = daysOpen.ToString();

            if (startDate < dateCreated)
                EscalationStartDateTimePicker.Text = DateCreatedTimePicker.Text;

            if (completionDate < dateCreated)
                EscalationCompDateTimePicker.Text = DateCreatedTimePicker.Text; if (startDate < dateCreated)

            if (closingDate < dateCreated)
                ClosingDateTimePicker.Text = DateCreatedTimePicker.Text;
        }

        private void cBoxOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cBoxOwner.SelectedIndex = 0;

        }

        private void cBoxlocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cBoxlocation.SelectedIndex = 0;
        }

        private void prioritycBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //prioritycBox.SelectedIndex = 2;
        }

        private void cBoxAssignedTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cBoxAssignedTo.SelectedIndex = 0;
        }

        private void ClosingDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            int daysOpen = ClosingDateTimePicker.Value.Date.Subtract(DateTime.Now.Date).Days - DateCreatedTimePicker.Value.Date.Subtract(DateTime.Now.Date).Days + 1;
            tBoxDaysOpen.Text = daysOpen.ToString();
        }

        private void rButtonYes_CheckedChanged(object sender, EventArgs e)
        {
            tBoxMaterials.Enabled = true;
            lbMatNeeded.Enabled = true;
        }

        private void rBtnNo_CheckedChanged(object sender, EventArgs e)
        {
            tBoxMaterials.Enabled = false;
            lbMatNeeded.Enabled = false;
        }
    }
    
}
 