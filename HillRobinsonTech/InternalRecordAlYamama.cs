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
    public partial class InternalRecordAlYamama : Form
    {
        TechDboDataContext pd = new TechDboDataContext();

        public Delegate UpdateInternal;


        public delegate void RefreshInternalLocationFields();
        public event RefreshInternalLocationFields RefreshLocationsEvent;

        public void UpdateSpecLocation()
        {
            if (cBoxLocation.Text != Util.LocationBuildingId)
                cBoxLocation.SelectedItem = Util.LocationBuildingId;
            if (cBoxSubLocation.Text != Util.LocationSublocation)
                cBoxSubLocation.SelectedItem = Util.LocationSublocation;
            cBoxSpecLocation.SelectedItem = Util.LocationSpecificLocation;
            //lblACid.Text = Util.LocationAHU != "" || Util.LocationAHU.ToLower() != "Nan".ToLower() ? Util.LocationAHU : "";
        }       


        public InternalRecordAlYamama()
        {
            InitializeComponent();
            this.CenterToScreen();
            //this.WindowState = FormWindowState.Maximized;

            if(!Util.userRolePermissions.Contains("ADD_EDIT_INTERNAL_TASKS") && (Util.userPermissions.Count > 0 && !Util.userPermissions.Contains("ADD_EDIT_INTERNAL_TASKS")) 
                || (Util.userTypeConnected == "guest"))
            {
                savebtn.Enabled = false;
                ExportPdfBtn.Enabled = false;                                
            }
            if (Util.departmentConnected.ToLower() != DepartmInterncBox.Text.ToLower() && Util.departmentConnected.ToLower() != cBoxAssignedTo.Text.ToLower())
                savebtn.Enabled = false;
            if (Util.userRolePermissions.Contains("ADD_EDIT_CONTRACTOR_TASKS") || (Util.userPermissions.Count > 0 && Util.userPermissions.Contains("ADD_EDIT_CONTRACTOR_TASKS")))
                btnEscalation.Visible = true; // Util.departmentConnected == "Technical" ? true : false;           

            //if (StatusCmbBox.Text != "Open" && Util.departmentConnected.ToLower().Equals(cBoxAssignedTo.Text.ToLower()))// || StatusCmbBox.Text == "Cancelled" || StatusCmbBox.Text == "Closed")
            //{
            //    EscalationStartDateTimePicker.Enabled = true;
            //}

            if (Util.userListInDepartment.Count > 0)
            Util.userListInDepartment.Clear();
            Util.userDisplay();

            foreach (var item in Util.userListInDepartment)
            {
                cBoxAssignedToPerson.Items.Add(item);
                cBoxEscalationComBy.Items.Add(item);
                ClosedByCmbBox.Items.Add(item);
            }

            if (Util.locationListAY.Count > 0)
                Util.locationListAY.Clear();
            Util.locationListAYDisplay();

            foreach (var item in Util.locationListAY)
            {
                cBoxLocation.Items.Add(item);
            }

        }

        private void InternalRecord_Load(object sender, EventArgs e)
        {
            cBoxTesting.Visible = (Util.userIdConnected == 1 || Util.userIdConnected == 2) ? true : false;

            if (Util.newItem)
            {
                reportedBytBox.Text = Util.fullNameConnected;
                PositiontBox.Text = Util.positionUserConnected;
                DepartmInterncBox.Text = Util.departmentConnected;
            }
            else
            { reportedBytBox.Text = Util.reportedBy; }
            //DepartmEsomcBox.Text = Util.departmentEsom;
            refNotBox.Text = Util.trackId.ToString();
            cBoxLocation.Text = Util.location;
            cBoxSubLocation.Text = Util.subLocation;
            cBoxSpecLocation.Text = Util.specLocation;
            DetailstBox.Text = Util.locationDetails;
            DateCreatedTimePicker.Text = Util.dateCreated;///DateTime.Now.ToString();
            prioritycBox.Text = Util.priority;
            if (!Util.newItem)
            {
                PositiontBox.Text = Util.position; // != "" ? Util.position : Util.positionUserConnected
                DepartmInterncBox.Text = Util.departmentInternal; // != "" ? Util.departmentInternal : Util.departmentConnected
            }
            cBoxAssignedTo.Text = Util.assignedTo;
            cBoxAssignedToPerson.Text = Util.assignedToPerson;
            StatusCmbBox.Text = Util.status;
           // TypetBox.Text = Util.RecordType;
            TaskDesctBox.Text = Util.issueDesc;
            refInternalNotBox.Text = Util.ContractorTrackIdInternalRef.ToString();            
            followUptBox.Text = Util.followUp;

            EscalationComtBox.Text = Util.EscalComm;
            cBoxEscalationComBy.Text = Util.EscalCompBy;
            if (!cBoxEscalationComBy.Items.Contains(Util.fullNameConnected))
                cBoxEscalationComBy.Items.Add(Util.fullNameConnected);
            ////EscalationComBytBox.Text = Util.EscalCompBy != "" ? Util.EscalCompBy : Util.fullNameConnected;  //Util.EscalCompBy;
            ////////
            ///           

            //EscalationStartDateTimePicker.CustomFormat = Util.EscalStartDate == Util.NADate.ToString() || Util.newItem ? "N/A" : DateTime.Now.ToShortDateString();
            //EscalationCompDateTimePicker.CustomFormat = Util.EscalComplDate == Util.NADate.ToString() || Util.newItem ? "N/A" : DateTime.Now.ToShortDateString();

            EscalationStartDateTimePicker.Text = Util.EscalStartDate;
            EscalationCompDateTimePicker.Text = Util.EscalComplDate;

            ClosingDateTimePicker.CustomFormat = Util.ClosingDate == Util.NADate.ToString() || Util.newItem ? "N/A" : DateTime.Now.ToShortDateString();

            ClosingComtBox.Text = Util.closingComment;
            ClosedByCmbBox.Text = Util.closedBy;
            if (!ClosedByCmbBox.Items.Contains(Util.fullNameConnected))
                ClosedByCmbBox.Items.Add(Util.fullNameConnected);
            //// ClosedByCmbBox.Text = Util.closedBy != "" ? Util.closedBy : Util.fullNameConnected; //Util.closedBy;
            ClosingDateTimePicker.Text = Util.ClosingDate;


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
            if(Util.newItem == false && Util.departmentConnected.ToLower().Equals(DepartmInterncBox.Text.ToLower()) && (Util.userTypeConnected != "guest"))
                ExportPdfBtn.Enabled = true;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            reset();
            closePage();
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
            Util.position = "";
            Util.departmentInternal = "";
            Util.assignedTo = "";
            Util.assignedToPerson = "";

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
            Util.ContractorTrackIdInternalRef = 0;
        }
        public void closePage()
        {
            this.Dispose();
        }
        public void savebtn_Click(object sender, EventArgs e)
        {
            //+= String.Join(":", nic.GetPhysicalAddress().GetAddressBytes().Select(b => b.ToString("X2")).ToArray());
            //DateTime dt = DateTime.ParseExact("05-16-2014", format, CultureInfo.InvariantCulture, DateTimeStyles.None);
            //IFormatProvider culture = new CultureInfo("en-US", true);

            if (Util.newItem == true)
            {
                if (cBoxLocation.Text == string.Empty || TaskDesctBox.Text == string.Empty || prioritycBox.Text == string.Empty
                    /*|| EscalatedTocBox.Text == string.Empty || DepartmEsomcBox.Text == string.Empty*/)///////////to add, improve!!!
                {
                    MessageBox.Show("You have mandatory fields left empty. You cannot save without filling them in!");
                    Util.SaveError = true;
                }
                else
                {
                    DialogResult rezultat = MessageBox.Show("Do you want to add a new track?", "Confirmation", MessageBoxButtons.OKCancel);
                    if (rezultat == DialogResult.OK)
                        insertTrack(null, StatusCmbBox.Text, TaskDesctBox.Text, cBoxLocation.Text, cBoxSubLocation.Text, cBoxSpecLocation.Text, DetailstBox.Text, DateTime.ParseExact(DateCreatedTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), 0,null,reportedBytBox.Text, prioritycBox.Text, PositiontBox.Text, DepartmInterncBox.Text, cBoxAssignedTo.Text, cBoxAssignedToPerson.Text, ClosingComtBox.Text, followUptBox.Text, DateTime.ParseExact(EscalationStartDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), DateTime.ParseExact(EscalationCompDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), EscalationComtBox.Text, cBoxEscalationComBy.Text, ClosedByCmbBox.Text, DateTime.ParseExact(ClosingDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), 0, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), null,null, null, null, 0);
                }
            }
            if (Util.newItem == false)
            {
                DialogResult rezultat = MessageBox.Show("Do you want to update the track?", "Confirmation", MessageBoxButtons.OKCancel);
                if (rezultat == DialogResult.OK)
                    updateTrack(null, StatusCmbBox.Text, TaskDesctBox.Text, cBoxLocation.Text, cBoxSubLocation.Text, cBoxSpecLocation.Text, DetailstBox.Text, DateTime.ParseExact(DateCreatedTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), reportedBytBox.Text, prioritycBox.Text, PositiontBox.Text, DepartmInterncBox.Text, cBoxAssignedTo.Text, cBoxAssignedToPerson.Text, ClosingComtBox.Text, followUptBox.Text, DateTime.ParseExact(EscalationStartDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), DateTime.ParseExact(EscalationCompDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), EscalationComtBox.Text, cBoxEscalationComBy.Text, ClosedByCmbBox.Text, DateTime.ParseExact(ClosingDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), 0,null, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), null, null, null, null, 0);
            }
            if (Util.SaveError != true)
                this.Dispose();
            Util.SaveError = false;


            //Util.reportedBy = "";
            //Util.departmentEsom = "";
            //Util.location = "";
            //Util.subLocation = "";
            //Util.specLocation = "";
            //Util.locationDetails = "";
            //Util.dateCreated = DateTime.Now.ToString();
            //Util.priority = "";
            //Util.position = "";
            //Util.departmentInternal = "";
            //Util.assignedTo = "";
            //Util.status = "";
            //Util.issueDesc = "";
            //Util.escalation = false;
            //Util.EscalComm = "";
            //Util.EscalCompBy = "";
            //Util.EscalStartDate = DateTime.Now.ToString();
            //Util.EscalComplDate = "";

            //Util.closingComment = "";
            //Util.closedBy = "";
            //Util.ClosingDate = DateTime.Now.ToString();
            //Util.followUp = "";

            reset();
        }

        public void insertTrack(string RecordType, string StatusId, string IssueDesc, string LocationId, string SubLocationId, string SpecLocationId, string DetailsId, DateTime DateCreatedId, int CreatedBy, string CreatedByVersion, string ReportedById, string PriorityId,  string PositionId, string DepartmentInternalId,string AssignedToId, string AssignedToPer, string ClosingComm, string FollowUpId, DateTime EscalationStartDate, DateTime EscalCompDate, string EscalationCommId, string EscalationComById, string ClosedById, DateTime CloseDate, int UserId, DateTime LastUpdate, string MachineName, string Macc, string IPAdress, string CreatedByWinAcc, int TestingId)
        {
            IPAdress = Util.userIp;
            // string[] format = new[] { "MM/dd/yyyy" };
            //TechIntTrackerTest dp = new TechIntTrackerTest()
            TechIntTracker dp = new TechIntTracker()
            {
                Type = "Internal".ToString(),
                Status = StatusId != "" ? StatusId : "Open",
                IssueDescription = IssueDesc,
                Location = LocationId,
                SublocationArea = SubLocationId,
                SpecificLocation = SpecLocationId,
                LocationDetails = DetailsId,
                DateCreated = DateCreatedId,
                CreatedBy = Util.userIdConnected,
                CreatedByVersion = Util.fullVersionInfo,
                ReportedBy = ReportedById,
                Priority = PriorityId,
                Position = PositionId,
                DepartmentInternal = DepartmentInternalId,
                AssignedTo = AssignedToId,
                AssignedToPerson = AssignedToPer,
                ClosingComment = ClosingComm,
                FollowUp = FollowUpId,
                EscalationStartDate = EscalationStartDateTimePicker.Enabled == true ?  EscalationStartDate : (DateTime)System.Data.SqlTypes.SqlDateTime.Null, //DBNull.Value,
                EscalationComplDate = EscalationCompDateTimePicker.Enabled == true ? EscalCompDate : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,
                EscalationComments = EscalationCommId,
                EscalCompletedBy = EscalationComById,
                ClosedBy = ClosedById,               
                ClosingDate = ClosingDateTimePicker.Enabled == true ? CloseDate : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,

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
                pd.TechIntTrackers.InsertOnSubmit(dp);
                pd.SubmitChanges();
                MessageBox.Show("Data was successfully saved!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Data was not saved!" + ex.Message);
            }
        }

        public void updateTrack(string RecordType, string StatusId, string IssueDesc, string LocationId, string SubLocationId, string SpecLocationId, string DetailsId, DateTime DateCreatedId, string ReportedById, string PriorityId, string PositionId, string DepartmentInternalId, string AssignedToId, string AssignedToPer, string ClosingComm, string FollowUpId, DateTime EscalationStartDate, DateTime EscalCompDate, string EscalationCommId, string EscalationComById, string ClosedById, DateTime CloseDate,int UserId, string UpdatedByVersion, DateTime LastUpdate,string MachineName, string Macc, string IPAdress, string UpdatedByWinAcc, int TestingId)
        {
            int trackId = Convert.ToInt32(refNotBox.Text);//Util.trackId;
            IPAdress = Util.userIp;
                var trackUpdateAlY = (from x in pd.TechIntTrackers
                                          //TechIntTrackerTests
                                      where x.TrackId == trackId
                                      select x);

                foreach (var x in trackUpdateAlY)
                {
                    x.Type = x.Type;
                    x.Status = StatusId;// CloseClosedByCmbBox.Text == "" ?  "In progress" : "Closed";
                    x.IssueDescription = IssueDesc;
                    x.Location = LocationId;
                    x.SublocationArea = SubLocationId;
                    x.SpecificLocation = SpecLocationId;
                    x.LocationDetails = DetailsId;
                    x.DateCreated = DateCreatedId; 
                    x.ReportedBy = ReportedById;
                    x.Priority = PriorityId;
                    x.Position = PositionId;
                    x.DepartmentInternal = DepartmentInternalId;
                    x.AssignedTo = AssignedToId;
                    x.AssignedToPerson = AssignedToPer;
                    x.ClosingComment = ClosingComm;
                    x.FollowUp = FollowUpId;
                    x.EscalationStartDate = EscalationStartDate;                   
                    x.EscalationComplDate = EscalCompDate; 
                    x.EscalationComments = EscalationCommId;
                    x.EscalCompletedBy = EscalationComById;
                    x.ClosedBy = ClosedById;
                    x.ClosingDate = CloseDate;

                    x.UserId = Util.userIdConnected;
                    x.UpdatedByVersion = Util.fullVersionInfo;
                    x.LastUpdate = LastUpdate;
                    x.HostMachine = Util.userMachine;
                    x.HostMaccAdress = Util.userMachineMacc;
                    x.IPAdress = IPAdress;
                    x.WindowsAccount = Environment.UserName;

                    x.Testing = cBoxTesting.Checked == true ? 1 : 0;
            }
          
            try
            {

                pd.SubmitChanges();
                MessageBox.Show("Data was successfully updated!");

                // Perform save operation 
                UpdateInternal.DynamicInvoke(); // this will call the RefreshListView` method of mainWindow
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
            //int day = DateTime.Today.Day;
            //int month = DateTime.Today.Month;
            string shortDate = today.Substring(0, today.Length - 5);

           followUptBox.Text += !followUptBox.Text.Contains(shortDate) ? shortDate + " - " : "";
        }

        private void ExportPdfBtn_Click(object sender, EventArgs e)
        {
            Util.exportLocation = "Al Yamamah";
            ExportInternalToPDF form = new ExportInternalToPDF();
            form.ShowDialog();

        }

        private void antet2lbl_Validating(object sender, CancelEventArgs e)
        {
            //if (Util.AlYamamabtn == true)
            //{
            //antet2lbl.Text = "Contractor Task Allocation - Al Yamama";
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
            //if (Util.exportLocation == "Al Yamama")
            //{
                antet2lbl.Text = "Internal Task Allocation - Al Yamamah";
            //}
            //else
            //if (Util.exportLocation == "Sharma")
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

        private void InternalRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Are you sure you want to quit?", "My Application", MessageBoxButtons.YesNo) == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}

            reset();

            //Util.reportedBy = "";
            //Util.departmentEsom = "";
            //Util.location = "";
            //Util.subLocation = "";
            //Util.specLocation = "";
            //Util.locationDetails = "";  
            //Util.dateCreated = DateTime.Now.ToString();
            //Util.priority = "";
            //Util.status = "";
            //Util.issueDesc = "";
            // Util.escalation = false;

            //Util.esomRef = "";
            //Util.EscalComm = "";
            //Util.EscalCompBy = "";
            //Util.EscalStartDate = DateTime.Now.ToString();
            //Util.Manager = "";
            //Util.TechnicianAssigned = "";
            //Util.EscalComplDate = "";

            //Util.closingComment = "";
            //Util.closedBy = "";
            //Util.ClosingDate = DateTime.Now.ToString();
            //Util.followUp = "";

        }

        private void AddComlDatebt_Click(object sender, EventArgs e)
        {
            string today = DateTime.Today.ToShortDateString();
            string shortDate = today.Substring(0, today.Length - 5);

            EscalationComtBox.Text += !EscalationComtBox.Text.Contains(shortDate) ? shortDate + " - " : "";
        }

        private void DateCreatedTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateCreated = DateTime.ParseExact(DateCreatedTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            //DateTime.ParseExact(DateCreatedTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            //DateTime dueByDate = DateTime.ParseExact(dateTimePickerDueByDate.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime startDate = DateTime.ParseExact(EscalationStartDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            //DateTime.ParseExact(EscalationStartDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime completionDate = DateTime.ParseExact(EscalationCompDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            //DateTime.ParseExact(EscalationCompDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime closingDate = DateTime.ParseExact(ClosingDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            //DateTime.ParseExact(ClosingDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            //if (dueByDate < dateCreated)
            //    dateTimePickerDueByDate.Text = DateCreatedTimePicker.Text;

            //int daysOpen = ClosingDateTimePicker.Value.Date.Subtract(DateTime.Now.Date).Days - DateCreatedTimePicker.Value.Date.Subtract(DateTime.Now.Date).Days + 1;
            //tBoxDaysOpen.Text = daysOpen.ToString();

            if (startDate < dateCreated && EscalationStartDateTimePicker.Enabled == true)
                EscalationStartDateTimePicker.Text = DateCreatedTimePicker.Text;

            if (completionDate < dateCreated && EscalationCompDateTimePicker.Enabled == true)
                EscalationCompDateTimePicker.Text = DateCreatedTimePicker.Text; 

                if (closingDate < dateCreated && ClosingDateTimePicker.Enabled == true)
                    ClosingDateTimePicker.Text = DateCreatedTimePicker.Text;
        }

        private void EscalationStartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.ParseExact(EscalationStartDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime completionDate = DateTime.ParseExact(EscalationCompDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime closingDate = DateTime.ParseExact(ClosingDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);


            if (completionDate < startDate && EscalationCompDateTimePicker.Text != "N/A") //&& EscalationCompDateTimePicker.Text != "N/A"
                EscalationCompDateTimePicker.Text = EscalationStartDateTimePicker.Text; 

                if (closingDate < startDate && ClosingDateTimePicker.Enabled == true)
                    ClosingDateTimePicker.Text = EscalationStartDateTimePicker.Text;
        }

        private void EscalationCompDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime completionDate = DateTime.ParseExact(EscalationCompDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime closingDate = DateTime.ParseExact(ClosingDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);


            if (closingDate < completionDate && ClosingDateTimePicker.Enabled == true)
                ClosingDateTimePicker.Text = EscalationCompDateTimePicker.Text;
        }

        private void StatusCmbBox_TextChanged(object sender, EventArgs e)
        {
            if ((StatusCmbBox.Text == "In progress" || StatusCmbBox.Text == "Cancelled" || StatusCmbBox.Text == "Closed") && Util.departmentConnected.ToLower().Equals(cBoxAssignedTo.Text.ToLower()))// || StatusCmbBox.Text == "Cancelled" || StatusCmbBox.Text == "Closed")
            {
                if (!savebtn.Enabled)
                    savebtn.Enabled = true;

                EscalationStartDateTimePicker.Enabled = true;
                EscalationStartDateTimePicker.CustomFormat = "";
                EscalationStartDateTimePicker.Text = Util.EscalStartDate == Util.NADate.ToString() ? DateTime.Now.ToString() : Util.EscalStartDate;
                //refInternalNotBox.Enabled = true;
                btnEscalation.Enabled = true;
                //PositiontBox.Enabled = true;
                // cBoxAssignedTo.Enabled = true;
                EscalationComtBox.Enabled = true;
                //AddComlDatebt.Enabled = true;
                cBoxEscalationComBy.Enabled = true;
                cBoxAssignedToPerson.Enabled = true;

                if (cBoxEscalationComBy.Text == String.Empty && cBoxEscalationComBy.Items.Count > 0)
                cBoxEscalationComBy.SelectedIndex = 0;

                EscalationCompDateTimePicker.Enabled = true;
                EscalationCompDateTimePicker.CustomFormat = "";
                EscalationCompDateTimePicker.Text = Util.EscalComplDate == Util.NADate.ToString() ? DateTime.Now.ToString() : Util.EscalComplDate;
            }
            if ((StatusCmbBox.Text == "Closed" || StatusCmbBox.Text == "Cancelled") && Util.departmentConnected.ToLower().Equals(DepartmInterncBox.Text.ToLower()))
            {
                ClosingComtBox.Enabled = true;
                ClosedByCmbBox.Enabled = true;

                if (ClosedByCmbBox.Text == String.Empty && ClosedByCmbBox.Items.Count > 0)
                    ClosedByCmbBox.SelectedIndex = 0;

                ClosingDateTimePicker.Enabled = true;
                ClosingDateTimePicker.CustomFormat = "";
                ClosingDateTimePicker.Text = Util.ClosingDate == Util.NADate.ToString() ? DateTime.Now.ToShortDateString() : Util.ClosingDate;
            }
            else
                 if ((StatusCmbBox.Text == "Closed" || StatusCmbBox.Text == "Cancelled") && !Util.departmentConnected.ToLower().Equals(DepartmInterncBox.Text.ToLower()))
                    savebtn.Enabled = false;

            if (StatusCmbBox.Text == "Open")
            {
                if (!savebtn.Enabled)
                    savebtn.Enabled = true;

                EscalationStartDateTimePicker.Enabled = false;
                EscalationStartDateTimePicker.CustomFormat = "N/A";// Util.EscalStartDate == Util.NADate.ToString() ? "N/A" : DateTime.Now.ToShortDateString();
                //EscalationStartDateTimePicker.Text = Util.EscalStartDate == "01/01/1900 00:00:00".ToString() ? DateTime.Now.ToString() : Util.EscalStartDate;
                //refInternalNotBox.Enabled = false;
                btnEscalation.Enabled = false;
                //PositiontBox.Enabled = true;
                // cBoxAssignedTo.Enabled = true;
                EscalationComtBox.Enabled = false;
                cBoxAssignedToPerson.Enabled = false;
                //AddComlDatebt.Enabled = false;
                cBoxEscalationComBy.Enabled = false;
                //cBoxEscalationComBy.Text = "";

                //if (cBoxEscalationComBy.Text == String.Empty && cBoxEscalationComBy.Items.Count > 0)
                //    cBoxEscalationComBy.SelectedIndex = 0;

                EscalationCompDateTimePicker.Enabled = false;
                EscalationCompDateTimePicker.CustomFormat = "N/A";// Util.EscalComplDate == Util.NADate.ToString() ? "N/A" : DateTime.Now.ToShortDateString();
                //EscalationCompDateTimePicker.Text = Util.EscalComplDate == "01/01/1900 00:00:00".ToString() ? DateTime.Now.ToString() : Util.EscalComplDate;

                ClosingComtBox.Enabled = false;
                ClosedByCmbBox.Enabled = false;
                //ClosedByCmbBox.Text = "";

                //if (ClosedByCmbBox.Text == String.Empty && ClosedByCmbBox.Items.Count > 0)
                //    ClosedByCmbBox.SelectedIndex = 0;

                ClosingDateTimePicker.Enabled = false;
                ClosingDateTimePicker.CustomFormat = "N/A";// Util.ClosingDate == Util.NADate.ToString() ? "N/A" : DateTime.Now.ToShortDateString();
                //ClosingDateTimePicker.Text = Util.ClosingDate == "01/01/1900 00:00:00".ToString() ? DateTime.Now.ToString() : Util.ClosingDate;
            }
        }

        private void btnEscalation_Click(object sender, EventArgs e)
        {
           Util.escalation = true;

            int trackId = Convert.ToInt32(refNotBox.Text);
            var query = from x in pd.TechIntTrackers
                            //TechIntTrackerTests
                        where x.InternalRef == trackId || x.TrackId == trackId 

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
                            //x.ReportedBy,
                            x.Priority,
                            //x.DepartmentRef,
                            x.DepartmentInternal,
                            x.AssignedTo,
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
                            x.FollowUp

                        };

            foreach (var x in query)
            {
                Util.trackId = x.TrackId;
                Util.InternalRef = x.InternalRef != null ? x.InternalRef.ToString() : x.TrackId.ToString();
                Util.newItem = x.InternalRef != null ? false : true;
                Util.RecordType = x.Type;
                Util.status = Util.newItem ? "Open" : x.Status;
                Util.issueDesc = x.IssueDescription;
                Util.location = x.Location;
                Util.subLocation = x.SublocationArea;
                Util.specLocation = x.SpecificLocation;
                Util.locationDetails = x.LocationDetails;
                Util.dateCreated = x.DateCreated.ToString();
                //Util.reportedBy = x.ReportedBy;
                Util.priority = x.Priority;

                if (!Util.newItem)
                {
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
            ContractorRecordAlYamama newInstance = new ContractorRecordAlYamama();
            //RefreshListEvent += new RefreshList(RefreshListView); // event initialization
            newInstance.UpdateContractor = UpdateInternal; // assigning event to the Delegate
            newInstance.Show();
        }

        private void cBoxSubLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

           cBoxSpecLocation.Text = "";
            DetailstBox.Text = "";

            if (Util.specLocationListAY.Count > 0)
                Util.specLocationListAY.Clear();

            if (cBoxSpecLocation.Items.Count > 0)
                cBoxSpecLocation.Items.Clear();

            Util.specLocationListAYDisplay(cBoxLocation.Text, cBoxSubLocation.Text);

            foreach (var item in Util.specLocationListAY)
            {
                cBoxSpecLocation.Items.Add(item);
            }
        }

        private void cBoxLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBoxSubLocation.Text = "";
            cBoxSpecLocation.Text = "";
            DetailstBox.Text = "";

            if (Util.subLocationListAY.Count > 0)
                Util.subLocationListAY.Clear();

            if (cBoxSubLocation.Items.Count > 0)
                cBoxSubLocation.Items.Clear();

            Util.subLocationListAYDisplay(cBoxLocation.Text);

            foreach (var item in Util.subLocationListAY)
            {
                cBoxSubLocation.Items.Add(item);
            }
        }

        private void cBoxSpecLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
           DetailstBox.Text = "";

            if (Util.LocationDetailListAY.Count > 0)
                Util.LocationDetailListAY.Clear();

            DetailstBox.Text = "";
            Util.LocationDetailListAYDisplay(cBoxLocation.Text, cBoxSubLocation.Text, cBoxSpecLocation.Text);

            DetailstBox.Text = Util.LocationDetailListAY.Count > 0 ?  Util.LocationDetailListAY[0] : "";

            if (Util.AHULocationListAY.Count > 0)
                Util.AHULocationListAY.Clear();

            Util.AHULocationListAYDisplay(cBoxLocation.Text, cBoxSubLocation.Text, cBoxSpecLocation.Text);
            lblACid.Text = Util.AHULocationListAY.Count > 0 && Util.AHULocationListAY[0] != null && Util.AHULocationListAY[0] != "" && Util.AHULocationListAY[0].ToLower() != "NaN".ToLower() ? Util.AHULocationListAY[0] : "";
        }

        private void pBoxSearch_Click(object sender, EventArgs e)
        {
            Util.SearchLocationTool = true;

            Locations newInstance = new Locations();
            RefreshLocationsEvent += new RefreshInternalLocationFields(UpdateSpecLocation); // event initialization
            newInstance.UpdateSpecLocation = RefreshLocationsEvent; // assigning event to the Delegate            
            newInstance.Show();

            //Locations form = new Locations();
            //form.ShowDialog();
        }

        private void pBoxSearch_MouseHover(object sender, EventArgs e)
        {
            toolTipSearch.Show("Click to search for locations!", pBoxSearch);
        }

        private void SearchtoolTip_Popup(object sender, PopupEventArgs e)
        {

        }

        private void lblACid_MouseHover(object sender, EventArgs e)
        {
            AHUtoolTip.Show("Click to add AHU id in the task description!", lblACid);
        }

        private void lblACid_Click(object sender, EventArgs e)
        {
            TaskDesctBox.Text = !TaskDesctBox.Text.Contains(lblACid.Text) ? lblACid.Text : "";
        }
    }
    
}
