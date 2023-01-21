using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HillRobinsonTech
{
    public partial class IntTrackerEditOld : Form
    {
        TechDboDataContext pd = new TechDboDataContext();
        public IntTrackerEditOld()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void IntTrackerEdit_Load(object sender, EventArgs e)
        {
            TrackIdtbox.Text =(Util.newItem == true ? "" : Util.trackId.ToString());
            statusCBox.Text = Util.status;
            issueDescTBox.Text = Util.issueDesc;
            locationTBox.Text = Util.location;
            DateCreatedDateTimePicker.Text = Util.dateCreated;
            //dateRecPicker.Text = Util.dateReceived;
            reportedBycBox.Text = Util.reportedBy;
            prioritycBox.Text = Util.priority;
            departmRefcBox.Text = Util.departmentRef;
            assignedtocBox.Text = Util.assignedTo;
            escalatedTocBox.Text = Util.escalatedTo;
            departmEsomcBox.Text = Util.departmentEsom;
            EsomRefTBox.Text = Util.esomRef;
            ReportDatePicker.Text = Util.reportDate;
            closingComTBox.Text = Util.closingComment;
            CloseBytBox.Text = Util.closedBy;
            InspdateTimePicker.Text = Util.inspDate;
            followUptBox.Text = Util.followUp;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }       

        private void savebtn_Click(object sender, EventArgs e)
        {            
            if (Util.newItem == true)
            {
                if (statusCBox.Text == string.Empty && issueDescTBox.Text == string.Empty)///////////to add, improve!!!
                {
                    MessageBox.Show("You have empty fields. You cannot save an empty row!");
                }
                else
                {
                    DialogResult rezultat = MessageBox.Show("Do you want to add a new track?", "Confirmation", MessageBoxButtons.OKCancel);
                    if (rezultat == DialogResult.OK)
                        insertTrack(statusCBox.Text, issueDescTBox.Text, locationTBox.Text, Convert.ToDateTime(dateRecPicker.Text), reportedBycBox.Text, prioritycBox.Text, departmRefcBox.Text, assignedtocBox.Text, escalatedTocBox.Text, departmEsomcBox.Text, EsomRefTBox.Text, Convert.ToDateTime(ReportDatePicker.Text), closingComTBox.Text, followUptBox.Text, Convert.ToDateTime(DateCreatedDateTimePicker.Text), CloseBytBox.Text, Convert.ToDateTime(InspdateTimePicker.Text));
                }
            }
            if (Util.newItem == false)
            {
                DialogResult rezultat = MessageBox.Show("Do you want to update the track?", "Confirmation", MessageBoxButtons.OKCancel);
                if (rezultat == DialogResult.OK)
                    updateTrack(statusCBox.Text, issueDescTBox.Text, locationTBox.Text, Convert.ToDateTime(dateRecPicker.Text), reportedBycBox.Text, prioritycBox.Text, departmRefcBox.Text, assignedtocBox.Text, escalatedTocBox.Text, departmEsomcBox.Text, EsomRefTBox.Text, Convert.ToDateTime(ReportDatePicker.Text), closingComTBox.Text, followUptBox.Text, Convert.ToDateTime(DateCreatedDateTimePicker.Text), CloseBytBox.Text, Convert.ToDateTime(InspdateTimePicker.Text));
            }
            this.Dispose();

            //IntTrackerView.Items.Clear();
            //Refresh(sender, e);
            // this.Dispose();

            //form = new IntTracker();
            //form.Show();
            //IntTracker.ActiveForm.Refresh();
            //IntTracker.ActiveForm.Show();
            //public event Action ReloadForm1;

            ////on the place where you will reload form1
            // ReloadForm1();
        }

        //public void ReloadForm1()
        //{

        //}

       // public event Action ReloadForm1;

        public void insertTrack(string StatusId, string IssueDesc, string LocationId, DateTime DateRec, string ReportedById, string PriorityId, string DepartmRef, string AssignedToId, string EscalatedToId, string DepartmEsom, string EsomRefer, DateTime RepDate, string ClosingComm, string FollowUpId, DateTime CreatedDate, string ClosedById, DateTime InspDate)
        {
            TechIntTracker dp = new TechIntTracker()
            {
                //Status = StatusId,
                //IssueDescription = IssueDesc,
                //Location = LocationId,
                //DateReceived = DateRec,
                //ReportedBy = ReportedById,
                //Priority = PriorityId,
                //DepartmentRef = DepartmRef,
                //AssignedTo = AssignedToId,
                //EscalatedTo = EscalatedToId,
                //DepartmentEsom = DepartmEsom,
                //EsomRef = Convert.ToInt32(EsomRefer),
                //ReportDate = RepDate,
                //ClosingComment = ClosingComm,
                //FollowUp = FollowUpId,
                //DateCreated = CreatedDate,
                //ClosedBy = ClosedById,
                //InspectionDate = InspDate
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

        public void updateTrack(string StatusId, string IssueDesc, string LocationId, DateTime DateRec, string ReportedById, string PriorityId, string DepartmRef, string AssignedToId, string EscalatedToId, string DepartmEsom, string EsomRefer, DateTime RepDate, string ClosingComm, string FollowUp, DateTime CreatedDate, string ClosedById, DateTime InspDate)
        {          
            int trackId = Util.trackId;
            var trackUpdate = (from x in pd.TechIntTrackers
                                where x.TrackId == trackId
                                select x);

            foreach (var x in trackUpdate)
            {
                //x.Status = StatusId;
                //x.IssueDescription = IssueDesc;
                //x.Location = LocationId;
                //x.DateReceived = DateRec;
                //x.ReportedBy = ReportedById;
                //x.Priority = PriorityId;
                //x.DepartmentRef = DepartmRef;
                //x.AssignedTo = AssignedToId;
                //x.EscalatedTo = EscalatedToId;
                //x.DepartmentEsom = DepartmEsom;
                //x.EsomRef = Convert.ToInt32(EsomRefer);
                //x.ReportDate = RepDate;
                //x.ClosingComment = ClosingComm;
                //x.FollowUp = FollowUp;
                //x.DateCreated = CreatedDate;
                //x.ClosedBy = ClosedById;
                //x.InspectionDate = InspDate;
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
    }
}
