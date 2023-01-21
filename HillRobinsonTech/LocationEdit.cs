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
    public partial class LocationEdit : Form
    {
        TechDboDataContext pd = new TechDboDataContext();
        public LocationEdit()
        {
            InitializeComponent();
            this.CenterToScreen();

            if (!Util.userRolePermissions.Contains("ADD_EDIT_LOCATIONS") || (Util.userPermissions.Count > 0 && !Util.userPermissions.Contains("ADD_EDIT_LOCATIONS"))) //(Util.userTypeConnected == "guest")
            {
                savebtn.Enabled = false;
            }
        }

        private void LocationEdit_Load(object sender, EventArgs e)
        {
            tboxId.Text = Util.LocationId.ToString();
            tBoxProject.Text = Util.LocationProject.ToString();
            tBoxBuildingId.Text = Util.LocationBuildingId;
            tBoxSublocation.Text = Util.LocationSublocation;
            tBoxSpecLocation.Text = Util.LocationSpecificLocation;
            tBoxLocationDetails.Text = Util.LocationLocationDetails;
            tBoxHKAlias.Text =  Util.LocationHKAlias;
            tBoxFBAlias.Text = Util.LocationFBAlias;
            tBoxAHU.Text = Util.LocationAHU;
            cBoxICT.Text = Util.LocationICT.ToString();
            tBoxOtherInfo.Text = Util.LocationOtherInfo;
          
        }

        private void reset()
        {
            Util.LocationId = 0;
            Util.LocationProject = 0;
            Util.LocationBuildingId = "";
            Util.LocationSublocation = "";
            Util.LocationSpecificLocation = "";
            Util.LocationLocationDetails = "";
            Util.LocationHKAlias ="";
            Util.LocationFBAlias = "";
            Util.LocationAHU = "";
            Util.LocationICT = 0;
            Util.LocationOtherInfo = "";           
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            reset();
            this.Dispose();            
        }       

        private void savebtn_Click(object sender, EventArgs e)
        {          

            if (Util.newItem == true)
            {
               if (tBoxProject.Text == string.Empty)///////////to add, improve!!!
                {
                    MessageBox.Show("You have empty fields. You cannot save an empty row!");
                    Util.SaveError = true;
                }
                else
                {
                    DialogResult rezultat = MessageBox.Show("Do you want to add a new location?", "Confirmation", MessageBoxButtons.OKCancel);
                    if (rezultat == DialogResult.OK)
                        insertLocation(tBoxProject.Text, tBoxBuildingId.Text, tBoxSublocation.Text, tBoxSpecLocation.Text, tBoxLocationDetails.Text, tBoxHKAlias.Text, tBoxFBAlias.Text, tBoxAHU.Text, Convert.ToInt32(cBoxICT.Text), tBoxOtherInfo.Text, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
                  
                }
            }
            
            if (Util.newItem == false)
            {
                DialogResult rezultat = MessageBox.Show("Do you want to update a location?", "Confirmation", MessageBoxButtons.OKCancel);
                if (rezultat == DialogResult.OK)
                    updateLocation(tBoxProject.Text, tBoxBuildingId.Text, tBoxSublocation.Text, tBoxSpecLocation.Text, tBoxLocationDetails.Text, tBoxHKAlias.Text, tBoxFBAlias.Text, tBoxAHU.Text, Convert.ToInt32(cBoxICT.Text), tBoxOtherInfo.Text, DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));

            }
            if (Util.SaveError != true)
                this.Dispose();
            Util.SaveError = false;

            reset();
        }
       

        public void insertLocation(string Project, string BuildingId, string Sublocation, string SpecificLocation, string LocationDetails, string HKAlias, string FBAlias, string AHU, int ICT, string OtherInfo, DateTime LastUpdate)
        {                          
            Location dp = new Location()
            {
                Project = Convert.ToInt32(Project),
                BuildingId = BuildingId,
                Sublocation = Sublocation,
                SpecificLocation = SpecificLocation,
                LocationDetails = LocationDetails,
                HKSpecificLocationAlias = HKAlias,
                FBSpecificLocationAlias =FBAlias,
                AHU = AHU,
                ICTReport = ICT,
                OtherInfo = OtherInfo                
            };

            try
            {
                pd.Locations.InsertOnSubmit(dp);
                pd.SubmitChanges();
                MessageBox.Show("Location was successfully added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Location was not saved!" + ex.Message);
            }
        }

        public void updateLocation(string Project, string BuildingId, string Sublocation, string SpecificLocation, string LocationDetails, string HKAlias, string FBAlias, string AHU, int ICT, string OtherInfo, DateTime LastUpdate)
        {          
            int Id = Util.LocationId;
            var LocationUpdate = (from x in pd.Locations
                                 where x.id == Id
                                select x);

            foreach (var x in LocationUpdate)
            {
                x.Project = Convert.ToInt32(Project);
                x.BuildingId = BuildingId;
                x.Sublocation = Sublocation;
                x.SpecificLocation = SpecificLocation;
                x.LocationDetails = LocationDetails;
                x.HKSpecificLocationAlias = HKAlias;
                x.FBSpecificLocationAlias = FBAlias;
                x.AHU = AHU;
                x.ICTReport = ICT;
                x.OtherInfo = OtherInfo;
                x.LastUpdate = LastUpdate;               
            }

            try
            {
                pd.SubmitChanges();
                MessageBox.Show("Location was successfully updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Location was not updated!" + ex.Message);
            }            
        }

        //private void AddFolDatebt_Click(object sender, EventArgs e)
        //{
        //    string today = DateTime.Today.ToShortDateString();

        //    //followUptBox.Text += !followUptBox.Text.Contains(today) ? today + "; " : "";
        //}

        private void tBoxFName_TextChanged(object sender, EventArgs e)
        {
            //tBoxSublocation.Text = tBoxProject.Text + " " + tBoxBuildingId.Text;
        }

        private void tBoxLName_TextChanged(object sender, EventArgs e)
        {
            //tBoxSublocation.Text = tBoxProject.Text + " " + tBoxBuildingId.Text;
        }

        private void btbDelete_Click(object sender, EventArgs e)
        {

        }

        //private void groupBox2_Enter(object sender, EventArgs e)
        //{

        //}
    }
}
