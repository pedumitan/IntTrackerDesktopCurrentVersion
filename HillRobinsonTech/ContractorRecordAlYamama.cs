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
    public partial class ContractorRecordAlYamama : Form
    {
        TechDboDataContext pd = new TechDboDataContext();

        public Delegate UpdateContractor;

        public delegate void RefreshContractorLocationFields();
        public event RefreshContractorLocationFields RefreshLocationsEvent;

        public void UpdateSpecLocation()
        {
            if (cBoxLocation.Text != Util.LocationBuildingId)
                cBoxLocation.SelectedItem = Util.LocationBuildingId;
            if (cBoxSubLocation.Text != Util.LocationSublocation)
                cBoxSubLocation.SelectedItem = Util.LocationSublocation;
            cBoxSpecLocation.SelectedItem = Util.LocationSpecificLocation;
            //lblACid.Text = Util.LocationAHU != "" || Util.LocationAHU.ToLower() != "Nan".ToLower() ? Util.LocationAHU : "";
        }

        public ContractorRecordAlYamama()
        {
            InitializeComponent();
            this.CenterToScreen();
            //this.WindowState = FormWindowState.Maximized;
            //if(!Util.departmentConnected.Contains("Technical"))
            //if (!Util.userRolePermissions.Contains("ADD_EDIT_CONTRACTOR_TASKS") || (Util.userPermissions.Count > 0 && !Util.userPermissions.Contains("ADD_EDIT_CONTRACTOR_TASKS"))) //(Util.userTypeConnected == "guest")
               if(Util.userTypeConnected == "guest" || !Util.departmentConnected.Contains("Technical"))
                {
                    savebtn.Enabled = false;
                    ExportPdfBtn.Enabled = false;

                    //if (Util.userTypeConnected == "guest")
                    //{
                    //    btnEscalation.Enabled = false;
                    //}
                }

            //managerListAY
            if (Util.managerListAY.Count > 0)
                Util.managerListAY.Clear();
            Util.contractorManagerListAY();

            foreach (var item in Util.managerListAY)
            {
                cBoxManager.Items.Add(item);
            }

            //technicianListAY
            if (Util.technicianListAY.Count > 0)
                Util.technicianListAY.Clear();
            Util.contractorTechnicianListAY();

            foreach (var item in Util.technicianListAY)
            {
                cBoxTechAssigned.Items.Add(item);
            }

            if (Util.userListInDepartment.Count > 0)
                Util.userListInDepartment.Clear();
            Util.userDisplay();

            foreach (var item in Util.userListInDepartment)
            {
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

        private void ContractorRecord_Load(object sender, EventArgs e)
        {
            cBoxTesting.Visible = (Util.userIdConnected == 1 || Util.userIdConnected == 2) ? true : false;

            if (Util.newItem || Util.escalation)
            {
                reportedBytBox.Text = Util.fullNameConnected;
                //if (Util.newItem)
                //cBoxTesting.Visible = (Util.userIdConnected == 1 || Util.userIdConnected == 2) ? true : false;
            }
            else 
            { reportedBytBox.Text = Util.reportedBy; }
           
            DepartmEsomcBox.Text = Util.departmentEsom;
                
            cBoxLocation.Text = Util.location;
            cBoxSubLocation.Text = Util.subLocation;
            cBoxSpecLocation.Text = Util.specLocation;
            DetailstBox.Text = Util.locationDetails;
            DateCreatedTimePicker.Text = Util.dateCreated;///DateTime.Now.ToString();
            prioritycBox.Text = Util.priority;
            InternalEscalationtBox.Text = Util.InternalRef != "0" ? Util.InternalRef : "";
            TaskDesctBox.Text = Util.issueDesc;
            refNotBox.Text = Util.escalation == true && Util.newItem ? "0".ToString() : Util.trackId.ToString();

            //if (Util.escalation == false)
            {
                
                StatusCmbBox.Text = Util.status;
                EsomReftBox.Text = Util.esomRef;

                //EscalatedTocBox.Text = Util.escalatedTo;
                // DateRepDateTimePicker.Text = Util.reportDate;
                EscalationComtBox.Text = Util.EscalComm;
                cBoxEscalationComBy.Text = Util.EscalCompBy;
                if (!cBoxEscalationComBy.Items.Contains(Util.fullNameConnected))
                    cBoxEscalationComBy.Items.Add(Util.fullNameConnected);
                //EscalationComBytBox.Text = Util.EscalCompBy != "" ? Util.EscalCompBy : Util.fullNameConnected;  //Util.EscalCompBy;
                EscalationStartDateTimePicker.Text = Util.EscalStartDate;//"1900-01-01 00:00:00.000"  ? "N/A" 
                cBoxManager.Text = Util.Manager;
                cBoxTechAssigned.Text = Util.TechnicianAssigned;
                EscalationCompDateTimePicker.Text = Util.EscalComplDate;

                ClosingComtBox.Text = Util.closingComment;              
               
                ClosedByCmbBox.Text = Util.closedBy;
                if (!ClosedByCmbBox.Items.Contains(Util.fullNameConnected))
                    ClosedByCmbBox.Items.Add(Util.fullNameConnected);
                //Johann Venter
                //Florentin Mitan
                //JoMari Kleinhans
                //Iulian Pauna
                //MD Jugnu
                //Isbar Darwis
                // ClosedByCmbBox.Text = Util.closedBy != "" ? Util.closedBy : Util.fullNameConnected; //Util.closedBy;
                ClosingDateTimePicker.Text = Util.ClosingDate;
                followUptBox.Text = Util.followUp;
               
            }

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
            btnEscalation.Visible = InternalEscalationtBox.Text!= "" /*&& Util.userTypeConnected != "guest"*/ ? true : false;
            if (Util.userRolePermissions.Contains("TESTING_OPTION") || (Util.userPermissions.Count > 0 && Util.userPermissions.Contains("TESTING_OPTION")))
                cBoxTesting.Visible = true;
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
        public void closePage()
        {
            this.Dispose();
        }
        public void savebtn_Click(object sender, EventArgs e)
        {
            //+= String.Join(":", nic.GetPhysicalAddress().GetAddressBytes().Select(b => b.ToString("X2")).ToArray());
            //DateTime dt = DateTime.ParseExact("05-16-2014", format, CultureInfo.InvariantCulture, DateTimeStyles.None);
            //IFormatProvider culture = new CultureInfo("en-US", true);

            if (Util.newItem)
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
                        insertTrack(null, StatusCmbBox.Text, TaskDesctBox.Text, cBoxLocation.Text, cBoxSubLocation.Text, cBoxSpecLocation.Text, DetailstBox.Text, DateTime.ParseExact(DateCreatedTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), 0,null,reportedBytBox.Text, InternalEscalationtBox.Text, prioritycBox.Text, EsomReftBox.Text, ClosingComtBox.Text, followUptBox.Text, DateTime.ParseExact(EscalationStartDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), cBoxManager.Text, cBoxTechAssigned.Text, DateTime.ParseExact(EscalationCompDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), EscalationComtBox.Text, cBoxEscalationComBy.Text, ClosedByCmbBox.Text, DepartmEsomcBox.Text, DateTime.ParseExact(ClosingDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), 0, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), null,null, null, null, 0, 0);
                }
            }
            if (Util.newItem == false)
            {
                DialogResult rezultat = MessageBox.Show("Do you want to update the track?", "Confirmation", MessageBoxButtons.OKCancel);
                if (rezultat == DialogResult.OK)
                    updateTrack(null, StatusCmbBox.Text, TaskDesctBox.Text, cBoxLocation.Text, cBoxSubLocation.Text, cBoxSpecLocation.Text, DetailstBox.Text, DateTime.ParseExact(DateCreatedTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), reportedBytBox.Text, InternalEscalationtBox.Text, prioritycBox.Text, EsomReftBox.Text, ClosingComtBox.Text, followUptBox.Text, DateTime.ParseExact(EscalationStartDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), cBoxManager.Text, cBoxTechAssigned.Text, DateTime.ParseExact(EscalationCompDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), EscalationComtBox.Text, cBoxEscalationComBy.Text, ClosedByCmbBox.Text, DepartmEsomcBox.Text, DateTime.ParseExact(ClosingDateTimePicker.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), 0, null,DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), null, null, null, null, 0, 0);
            }
            if (Util.SaveError != true)
                this.Dispose();
            Util.SaveError = false;


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

            Util.esomRef = "";
            Util.ContractorTrackIdInternalRef = 0;
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

            reset();

        }

        public void insertTrack(string RecordType, string StatusId, string IssueDesc, string LocationId, string SubLocationId, string SpecLocationId, string DetailsId, DateTime DateCreatedId, int CreatedBy, string CreatedByVersion,string ReportedById, string InternalRefId, string PriorityId, string EsomRefer, string ClosingComm, string FollowUpId, DateTime EscalationStartDate, string ManagerId, string TechAss, DateTime EscalCompDate, string EscalationCommId, string EscalationComById, string ClosedById, string DepartmEsom, DateTime CloseDate, int UserId, DateTime LastUpdate, string MachineName, string Macc, string IPAdress, string CreatedByWinAcc, int TestingId, int ContractorTrackId)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        {
            IPAdress = Util.userIp;
            // string[] format = new[] { "MM/dd/yyyy" };
            TechIntTracker dp = new TechIntTracker()
            {
                Type = "Contractor".ToString(),
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
                InternalRef = InternalRefId != "" ? Convert.ToInt32(InternalRefId) : 0,

                Priority = PriorityId,

                EsomRef = EsomRefer,
                ClosingComment = ClosingComm,
                FollowUp = FollowUpId,

                EscalationStartDate = EscalationStartDateTimePicker.Enabled == true ? EscalationStartDate : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,
                Manager = ManagerId,
                TechnicianAssigned = TechAss,
                EscalationComplDate = EscalationCompDateTimePicker.Enabled == true ? EscalCompDate : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,
                EscalationComments = EscalationCommId,
                EscalCompletedBy = EscalationComById,
                ClosedBy = ClosedById,

                DepartmentEsom = DepartmEsom,

                ClosingDate = ClosingDateTimePicker.Enabled == true ? CloseDate : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,

                UserId = Util.userIdConnected,
                LastUpdate = LastUpdate,
                HostMachine = Util.userMachine,
                HostMaccAdress = Util.userMachineMacc,
                IPAdress = IPAdress,
                WindowsAccount = Environment.UserName,

                Testing = cBoxTesting.Checked == true ? 1 : 0,
                ContractorTrackIdInternal = 0

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

        public void updateTrack(string RecordType, string StatusId, string IssueDesc, string LocationId, string SubLocationId, string SpecLocationId, string DetailsId, DateTime DateCreatedId, string ReportedById, string InternalRefId, string PriorityId, string EsomRefer, /*string AssignedToId, string EscalatedToId, DateTime RepDate,*/ string ClosingComm, string FollowUpId, DateTime EscalationStartDate, string ManagerId, string TechAss, DateTime EscalCompDate, string EscalationCommId, string EscalationComById, string ClosedById, string DepartmEsom, DateTime CloseDate,int UserId, string UpdatedByVersion, DateTime LastUpdate,string MachineName, string Macc, string IPAdress, string UpdatedByWinAcc, int TestingId, int ContractorTrackId)
        {
            int trackId = Util.trackId;
            //var list = new int[] { trackId, Convert.ToInt32(InternalEscalationtBox.Text) };
            //bool updateInternal = InternalEscalationtBox.Text != "" ? true : false;

            IPAdress = Util.userIp;
            //if (Util.AlYamamabtn == true)
            //{
            var trackUpdateAlY = (from x in pd.TechIntTrackers
                                        //TechIntTrackerTests 
                                    where x.TrackId == trackId //list.Contains(x.TrackId)// == trackId// || x.TrackId == Convert.ToInt32(InternalEscalationtBox.Text)
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
                x.InternalRef = InternalRefId != "" ? Convert.ToInt32(InternalRefId) : 0;
                x.Priority = PriorityId;
                x.EsomRef = EsomRefer;
                //// x.EscalatedTo = EscalatedToId; 
                //// x.ReportDate = RepDate;
                x.ClosingComment = ClosingComm;
                x.FollowUp = FollowUpId;
                x.EscalationStartDate = EscalationStartDateTimePicker.Enabled == true ? EscalationStartDate : (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
                x.Manager = ManagerId;
                x.TechnicianAssigned = TechAss;
                x.EscalationComplDate = EscalationCompDateTimePicker.Enabled == true ? EscalCompDate : (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
                x.EscalationComments = EscalationCommId;
                x.EscalCompletedBy = EscalationComById;
                x.ClosedBy = ClosedById;
                x.DepartmentEsom = DepartmEsom;
                x.ClosingDate = ClosingDateTimePicker.Enabled == true ? CloseDate : (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
                x.UserId = Util.userIdConnected;
                x.UpdatedByVersion = Util.fullVersionInfo;
                x.LastUpdate = LastUpdate;
                x.HostMachine = Util.userMachine;
                x.HostMaccAdress = Util.userMachineMacc;
                x.IPAdress = IPAdress;
                x.WindowsAccount = Environment.UserName;

                x.Testing = cBoxTesting.Checked == true ? 1 : 0;
                x.ContractorTrackIdInternal = 0;


            }
          

            try
            {

                pd.SubmitChanges();    
                MessageBox.Show("Data was successfully updated!");
                // Perform save operation 
                if(!Util.escalation)
                UpdateContractor.DynamicInvoke(); // this will call the `RefreshListView` method of mainWindow
                                                  //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data was not updated!" + ex.Message);
            }

            //update Internal track with Esom Ref no from Contractor linked task
            if (InternalEscalationtBox.Text != "")
            {
                updateInternalTrack(StatusId, EscalationStartDate, trackId, EscalCompDate, EscalationCommId, EscalationComById);
            }


        }
        private void updateInternalTrack(string StatusId, DateTime EscalationStartDate, int ContractorTrackId, DateTime EscalCompDate, string EscalationCommId, string EscalationComById)
        {
           // bool change = false;
            var trackUpdateInternalAY = (from y in pd.TechIntTrackers
                                         where y.TrackId == Convert.ToInt32(InternalEscalationtBox.Text)
                                         select y);

            foreach (var item in trackUpdateInternalAY)
            {
                if(StatusId == "In progress")
                item.Status = StatusId;
                item.EscalationStartDate = EscalationStartDateTimePicker.Enabled == true ? EscalationStartDate : (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
                //item.EsomRef = EsomRefer;
                item.ContractorTrackIdInternal = ContractorTrackId;
                //if(!item.EscalationComments.Contains(EscalationComtBox.Text))
                item.EscalationComplDate = EscalationCompDateTimePicker.Enabled == true ? EscalCompDate : (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
                item.EscalationComments = /*item.EscalationComments + Environment.NewLine +*/ EscalationComtBox.Text;               
                item.EscalationComments = EscalationCommId;
                item.EscalCompletedBy = EscalationComById;
               // change = EsomRefer.Equals(item.EsomRef.ToString());
            }

            try
            {
               // if (change)
               // {
                    pd.SubmitChanges();
                    //MessageBox.Show("Linked internal task was also updated!");
                    // Perform save operation 
                    UpdateContractor.DynamicInvoke(); // this will call the `RefreshListView` method of mainWindow
                    this.Dispose();
               // }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Linked internal task was not updated!" + ex.Message);
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
            Util.exportLocation = "Al Yamamah";
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
                antet2lbl.Text = "Contractor Task Allocation - Al Yamamah";
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

            reset();

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
            Util.escalation = false;
            Util.ContrToInternal = false;

            Util.InternalRef = "";
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
            if (StatusCmbBox.Text == "In progress" || StatusCmbBox.Text == "Cancelled" || StatusCmbBox.Text == "Closed")
            {
                EscalationStartDateTimePicker.Enabled = true;
                EscalationStartDateTimePicker.CustomFormat = "";
                EscalationStartDateTimePicker.Text = Util.EscalStartDate == Util.NADate.ToString() ? DateTime.Now.ToString() : Util.EscalStartDate;
                //EsomReftBox.Enabled = true;
                cBoxManager.Enabled = true;
                cBoxTechAssigned.Enabled = true;
                EscalationComtBox.Enabled = true;
                AddComlDatebt.Enabled = true;
                cBoxEscalationComBy.Enabled = true;

                if(cBoxEscalationComBy.Text == String.Empty && cBoxEscalationComBy.Items.Count > 0)
                cBoxEscalationComBy.SelectedIndex = 0;

                EscalationCompDateTimePicker.Enabled = true;
                EscalationCompDateTimePicker.CustomFormat = "";
                EscalationCompDateTimePicker.Text = Util.EscalComplDate == Util.NADate.ToString() ? DateTime.Now.ToString() : Util.EscalComplDate;
            }
            if (StatusCmbBox.Text == "Closed")
            {             
                ClosingComtBox.Enabled = true;
                ClosedByCmbBox.Enabled = true;

                if (ClosedByCmbBox.Text == String.Empty && ClosedByCmbBox.Items.Count > 0)
                    ClosedByCmbBox.SelectedIndex = ClosedByCmbBox.FindStringExact(Util.fullNameConnected);

                ClosingDateTimePicker.Enabled = true;
                ClosingDateTimePicker.CustomFormat = "";
                ClosingDateTimePicker.Text = Util.ClosingDate == Util.NADate.ToString() ? DateTime.Now.ToString() : Util.ClosingDate;
            }

            if (StatusCmbBox.Text == "Open")
            {
                EscalationStartDateTimePicker.Enabled = false;
                EscalationStartDateTimePicker.CustomFormat = "N/A";
                //EscalationStartDateTimePicker.Text = Util.EscalStartDate == "01/01/1900 00:00:00".ToString() ? DateTime.Now.ToString() : Util.EscalStartDate;
                cBoxManager.Enabled = false;
                cBoxTechAssigned.Enabled = false;
               // EsomReftBox.Enabled = false;
                //btnEscalation.Enabled = false;
                //PositiontBox.Enabled = true;
                // cBoxAssignedTo.Enabled = true;
                EscalationComtBox.Enabled = false;
                AddComlDatebt.Enabled = false;
                cBoxEscalationComBy.Enabled = false;
                cBoxEscalationComBy.Text = "";

                //if (cBoxEscalationComBy.Text == String.Empty && cBoxEscalationComBy.Items.Count > 0)
                //    cBoxEscalationComBy.SelectedIndex = 0;

                EscalationCompDateTimePicker.Enabled = false;
                EscalationCompDateTimePicker.CustomFormat = "N/A";
                //EscalationCompDateTimePicker.Text = Util.EscalComplDate == "01/01/1900 00:00:00".ToString() ? DateTime.Now.ToString() : Util.EscalComplDate;

                ClosingComtBox.Enabled = false;
                ClosedByCmbBox.Enabled = false;
                ClosedByCmbBox.Text = "";

                //if (ClosedByCmbBox.Text == String.Empty && ClosedByCmbBox.Items.Count > 0)
                //    ClosedByCmbBox.SelectedIndex = 0;

                ClosingDateTimePicker.Enabled = false;
                ClosingDateTimePicker.CustomFormat = "N/A";
                //ClosingDateTimePicker.Text = Util.ClosingDate == "01/01/1900 00:00:00".ToString() ? DateTime.Now.ToString() : Util.ClosingDate;
            }
        }

        private void btnEscalation_Click(object sender, EventArgs e)
        {
            Util.ContrToInternal = true;
            int trackId = Convert.ToInt32(InternalEscalationtBox.Text);
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
                Util.assignedTo = x.AssignedTo.ToString();

                Util.position = x.Position;
                Util.departmentInternal = x.DepartmentInternal;
                Util.EscalComm = x.EscalationComments;
                Util.EscalCompBy = x.EscalCompletedBy;
                Util.EscalStartDate = x.EscalationStartDate.ToString();
                Util.EscalComplDate = x.EscalationComplDate.ToString();
                Util.esomRef = x.EsomRef != null ? x.EsomRef.ToString() : "";
                Util.closingComment = x.ClosingComment;
                Util.closedBy = x.ClosedBy;
                Util.ClosingDate = x.ClosingDate.ToString();
                Util.followUp = x.FollowUp;
            }
            InternalRecordAlYamama newInstance = new InternalRecordAlYamama();
            //RefreshListEvent += new RefreshList(RefreshListView); // event initialization
            //newInstance.UpdateContractor = RefreshListEvent; // assigning event to the Delegate
            newInstance.Show();
        }

        private void cBoxTesting_CheckedChanged(object sender, EventArgs e)
        {

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

        private void cBoxSpecLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
           DetailstBox.Text = "";

            if (Util.LocationDetailListAY.Count > 0)
                Util.LocationDetailListAY.Clear();

            DetailstBox.Text = "";
            Util.LocationDetailListAYDisplay(cBoxLocation.Text, cBoxSubLocation.Text, cBoxSpecLocation.Text);
            DetailstBox.Text = Util.LocationDetailListAY.Count > 0 ? Util.LocationDetailListAY[0] : "";

            if (Util.AHULocationListAY.Count > 0)
                Util.AHULocationListAY.Clear();

            Util.AHULocationListAYDisplay(cBoxLocation.Text, cBoxSubLocation.Text, cBoxSpecLocation.Text);
            lblACid.Text = Util.AHULocationListAY.Count > 0 && Util.AHULocationListAY[0] != null && Util.AHULocationListAY[0] != "" && Util.AHULocationListAY[0].ToLower() != "NaN".ToLower() ? Util.AHULocationListAY[0] : "";

            //foreach (var item in Util.LocationDetailListAY)
            //{
            //    cBoxSpecLocation.Items.Add(item);
            //}


        }

        private void pBoxSearch_Click(object sender, EventArgs e)
        {
            Util.SearchLocationTool = true;

            Locations newInstance = new Locations();
            RefreshLocationsEvent += new RefreshContractorLocationFields(UpdateSpecLocation); // event initialization
            newInstance.UpdateSpecLocation = RefreshLocationsEvent; // assigning event to the Delegate            
            newInstance.Show();
        }

        private void AHUtoolTip_Popup(object sender, PopupEventArgs e)
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

        private void pBoxSearch_MouseHover(object sender, EventArgs e)
        {
            toolTipSearch.Show("Click to search for locations!", pBoxSearch);
        }

        private void cBoxSpecLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
    
}
