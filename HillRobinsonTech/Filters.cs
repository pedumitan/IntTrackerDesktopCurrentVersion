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
    public partial class Filters : Form
    {
        TechDboDataContext pd = new TechDboDataContext();
        //List<string> statusFilterList = new List<string>();
        public Filters()
        {
            InitializeComponent();
            this.CenterToScreen();

            //reset combos
            typeFiltercheckedComboBox.Items.Clear();
            StatusFiltercheckedComboBox.Items.Clear();
            PriorityFiltercheckedComboBox.Items.Clear();
            LocationFiltercheckedComboBox.Items.Clear();
            SubLocationFiltercheckedComboBox.Items.Clear();
            SpecLocationFiltercheckedComboBox.Items.Clear();
            LocDetailsFiltercheckedComboBox.Items.Clear();
            ReportedByFiltercheckedComboBox.Items.Clear();
            CompletedByFiltercheckedComboBox.Items.Clear();
            ClosedByFiltercheckedComboBox.Items.Clear();
            DepartmentEsomFiltercheckedComboBox.Items.Clear();

            typeFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheckType);
            StatusFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheckStatus);
            PriorityFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheckPriority);
            LocationFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheckLocation);
            SubLocationFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheckSubLocation);
            SpecLocationFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheckSpecLocation);
            LocDetailsFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheckLocationDetails);
            ReportedByFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheckReportedBy);
            CompletedByFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheckCompBy);
            ClosedByFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheckClosedBy);
            DepartmentEsomFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheckDepartmentEsom);
            
            // AssignedToFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheckAssignedTo);
            //EscalatedToFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheckEscalatedTo);
            //DepartmentInternalFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheckDepartment);           

            populateCombos();
        }
        public void populateCombos()
        {
            //checked comboboxes

            //1. type
            if (Util.AlYamamabtn == true)
            {
                var TypeFilter = (from x in pd.TypeFilters
                                  select x).OrderBy(v => v.Type);

                typeFiltercheckedComboBox.Items.Add("ALL");
                typeFiltercheckedComboBox.SetItemChecked(0, true);


                int n = 1;
                foreach (var item in TypeFilter)
                {
                    typeFiltercheckedComboBox.Items.Add(item.Type);
                    typeFiltercheckedComboBox.SetItemChecked(n, true);
                    n++;
                }
                ////If more then 5 items, add a scroll bar to the dropdown.
                //// PriorityFiltercheckedComboBox.MaxDropDownItems = 5;
                //// Make the "Name" property the one to display, rather than the ToString() representation.
                //typeFiltercheckedComboBox.DisplayMember = "Name";
                //typeFiltercheckedComboBox.ValueSeparator = ", ";
            }
            else if(Util.Sharmabtn == true)
            {
                var TypeFilter = (from x in pd.TypeFilterSharmas
                                  select x).OrderBy(y => y.Type);

                typeFiltercheckedComboBox.Items.Add("ALL");
                typeFiltercheckedComboBox.SetItemChecked(0, true);


                int n = 1;
                foreach (var item in TypeFilter)
                {
                    typeFiltercheckedComboBox.Items.Add(item.Type);
                    typeFiltercheckedComboBox.SetItemChecked(n, true);
                    n++;
                }
                ////If more then 5 items, add a scroll bar to the dropdown.
                //// PriorityFiltercheckedComboBox.MaxDropDownItems = 5;
                //// Make the "Name" property the one to display, rather than the ToString() representation.
                //typeFiltercheckedComboBox.DisplayMember = "Name";
                //typeFiltercheckedComboBox.ValueSeparator = ", ";
            }

            //If more then 5 items, add a scroll bar to the dropdown.
            // PriorityFiltercheckedComboBox.MaxDropDownItems = 5;
            // Make the "Name" property the one to display, rather than the ToString() representation.
            typeFiltercheckedComboBox.DisplayMember = "Name";
            typeFiltercheckedComboBox.ValueSeparator = ", ";

            

            //2. status
            if (Util.AlYamamabtn == true)
            {
                var statusFilter = (from x in pd.StatusFilters
                                    select x).OrderBy(v => v.STATUS);

                StatusFiltercheckedComboBox.Items.Add("ALL");
                StatusFiltercheckedComboBox.SetItemChecked(0, true);

                int i = 1;
                foreach (var item in statusFilter)
                {
                    StatusFiltercheckedComboBox.Items.Add(item.STATUS);
                    StatusFiltercheckedComboBox.SetItemChecked(i, true);
                    i++;
                }
            }

            else if (Util.Sharmabtn == true)
            {
                var statusFilter = (from x in pd.StatusFilterSharmas
                                    select x).OrderBy(x => x.Status);

                StatusFiltercheckedComboBox.Items.Add("ALL");
                StatusFiltercheckedComboBox.SetItemChecked(0, true);

                int i = 1;
                foreach (var item in statusFilter)
                {
                    StatusFiltercheckedComboBox.Items.Add(item.Status);
                    StatusFiltercheckedComboBox.SetItemChecked(i, true);
                    i++;
                }
            }

            //If more then 5 items, add a scroll bar to the dropdown.
            // StatusFiltercBox.MaxDropDownItems = 5;
            // Make the "Name" property the one to display, rather than the ToString() representation.
            StatusFiltercheckedComboBox.DisplayMember = "Name";
            StatusFiltercheckedComboBox.ValueSeparator = ", ";
            //StatusFiltercBox.SetItemCheckState(0, CheckState.Indeterminate);

            //3. priority
            if (Util.AlYamamabtn == true)
            {
                var PriorityFilter = (from x in pd.PriorityFilters
                                      select x).OrderBy(v => v.Priority);

                PriorityFiltercheckedComboBox.Items.Add("ALL");
                PriorityFiltercheckedComboBox.SetItemChecked(0, true);


                int o = 1;
                foreach (var item in PriorityFilter)
                {
                    PriorityFiltercheckedComboBox.Items.Add(item.Priority);
                    PriorityFiltercheckedComboBox.SetItemChecked(o, true);
                    o++;
                }
            }
            else if (Util.Sharmabtn == true)
            {
                var PriorityFilter = (from x in pd.PriorityFilterSharmas
                                      select x).OrderBy(v => v.Priority);

                PriorityFiltercheckedComboBox.Items.Add("ALL");
                PriorityFiltercheckedComboBox.SetItemChecked(0, true);


                int o = 1;
                foreach (var item in PriorityFilter)
                {
                    PriorityFiltercheckedComboBox.Items.Add(item.Priority);
                    PriorityFiltercheckedComboBox.SetItemChecked(o, true);
                    o++;
                }
            }

            //If more then 5 items, add a scroll bar to the dropdown.
            // PriorityFiltercheckedComboBox.MaxDropDownItems = 5;
            // Make the "Name" property the one to display, rather than the ToString() representation.
            PriorityFiltercheckedComboBox.DisplayMember = "Name";
            PriorityFiltercheckedComboBox.ValueSeparator = ", ";


            //4. location
            if (Util.AlYamamabtn == true)
            {
                var locationFilter = (from x in pd.LocationFilters
                                      select x).OrderBy(v => v.Location);

                //LocationFiltercBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_location_ItemCheck);
                LocationFiltercheckedComboBox.Items.Add("ALL");
                LocationFiltercheckedComboBox.SetItemChecked(0, true);


                int j = 1;
                foreach (var item in locationFilter)
                {
                    LocationFiltercheckedComboBox.Items.Add(item.Location);
                    LocationFiltercheckedComboBox.SetItemChecked(j, true);
                    j++;
                }
            }
            else if (Util.Sharmabtn == true)
            {
                var locationFilter = (from x in pd.LocationFilterSharmas
                                      select x).OrderBy(v => v.Location);

                //LocationFiltercBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_location_ItemCheck);
                LocationFiltercheckedComboBox.Items.Add("ALL");
                LocationFiltercheckedComboBox.SetItemChecked(0, true);


                int j = 1;
                foreach (var item in locationFilter)
                {
                    LocationFiltercheckedComboBox.Items.Add(item.Location);
                    LocationFiltercheckedComboBox.SetItemChecked(j, true);
                    j++;
                }
            }

            //If more then 5 items, add a scroll bar to the dropdown.
            // LocationFiltercheckedComboBox.MaxDropDownItems = 5;
            // Make the "Name" property the one to display, rather than the ToString() representation.
            LocationFiltercheckedComboBox.DisplayMember = "Name";
            LocationFiltercheckedComboBox.ValueSeparator = ", ";
            //StatusFiltercBox.SetItemCheckState(0, CheckState.Indeterminate);

            //5. sublocation
            if (Util.AlYamamabtn == true)
            {
                var subLocationFilter = (from x in pd.SubLocationFilters
                                         select x).OrderBy(v => v.SublocationArea);

               // SubLocationFiltercBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_location_ItemCheck);
                SubLocationFiltercheckedComboBox.Items.Add("ALL");
                SubLocationFiltercheckedComboBox.SetItemChecked(0, true);


                int j = 1;
                foreach (var item in subLocationFilter)
                {
                    SubLocationFiltercheckedComboBox.Items.Add(item.SublocationArea != null ? item.SublocationArea : "");
                    SubLocationFiltercheckedComboBox.SetItemChecked(j, true);
                    j++;
                }
            }
            else if (Util.Sharmabtn == true)
            {
                var subLocationFilter = (from x in pd.SubLocationSharmaFilters
                                         select x).OrderBy(v => v.SublocationArea);

                //LocationFiltercBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_location_ItemCheck);
                SubLocationFiltercheckedComboBox.Items.Add("ALL");
                SubLocationFiltercheckedComboBox.SetItemChecked(0, true);


                int j = 1;
                foreach (var item in subLocationFilter)
                {
                    SubLocationFiltercheckedComboBox.Items.Add(item.SublocationArea != null ? item.SublocationArea : "");
                    SubLocationFiltercheckedComboBox.SetItemChecked(j, true);
                    j++;
                }
            }

            //If more then 5 items, add a scroll bar to the dropdown.
            // LocationFiltercheckedComboBox.MaxDropDownItems = 5;
            // Make the "Name" property the one to display, rather than the ToString() representation.
            SubLocationFiltercheckedComboBox.DisplayMember = "Name";
            SubLocationFiltercheckedComboBox.ValueSeparator = ", ";
            //StatusFiltercBox.SetItemCheckState(0, CheckState.Indeterminate);

            //6. speclocation
            if (Util.AlYamamabtn == true)
            {
                var specLocationFilter = (from x in pd.SpecLocationFilters
                                      select x).OrderBy(v => v.SpecificLocation);

                //LocationFiltercBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_location_ItemCheck);
                SpecLocationFiltercheckedComboBox.Items.Add("ALL");
                SpecLocationFiltercheckedComboBox.SetItemChecked(0, true);


                int j = 1;
                foreach (var item in specLocationFilter)
                {
                    SpecLocationFiltercheckedComboBox.Items.Add(item.SpecificLocation != null ? item.SpecificLocation : "");
                    SpecLocationFiltercheckedComboBox.SetItemChecked(j, true);
                    j++;
                }
            }
            else if (Util.Sharmabtn == true)
            {
                var specLocationFilter = (from x in pd.SpecLocationSharmaFilters
                                          select x).OrderBy(v => v.SpecificLocation);

                //LocationFiltercBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_location_ItemCheck);
                SpecLocationFiltercheckedComboBox.Items.Add("ALL");
                SpecLocationFiltercheckedComboBox.SetItemChecked(0, true);


                int j = 1;
                foreach (var item in specLocationFilter)
                {
                    SpecLocationFiltercheckedComboBox.Items.Add(item.SpecificLocation != null ? item.SpecificLocation : "");
                    SpecLocationFiltercheckedComboBox.SetItemChecked(j, true);
                    j++;
                }
            }
            //If more then 5 items, add a scroll bar to the dropdown.
            // LocationFiltercheckedComboBox.MaxDropDownItems = 5;
            // Make the "Name" property the one to display, rather than the ToString() representation.
            SpecLocationFiltercheckedComboBox.DisplayMember = "Name";
            SpecLocationFiltercheckedComboBox.ValueSeparator = ", ";
            //StatusFiltercBox.SetItemCheckState(0, CheckState.Indeterminate);

            //7. location details
            if (Util.AlYamamabtn == true)
            {
                var locationdetailsFilter = (from x in pd.LocationDetailsFilters
                                             select x).OrderBy(v => v.LocationDetails);

                //LocationFiltercBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_location_ItemCheck);
                LocDetailsFiltercheckedComboBox.Items.Add("ALL");
                LocDetailsFiltercheckedComboBox.SetItemChecked(0, true);


                int j = 1;
                foreach (var item in locationdetailsFilter)
                {
                    LocDetailsFiltercheckedComboBox.Items.Add(item.LocationDetails != null ? item.LocationDetails : "");
                    LocDetailsFiltercheckedComboBox.SetItemChecked(j, true);
                    j++;
                }
            }
            else if (Util.Sharmabtn == true)
            {
                var locationdetailsFilter = (from x in pd.LocationDetailsSharmaFilteers
                                             select x).OrderBy(v => v.LocationDetails);

                //LocationFiltercBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_location_ItemCheck);
                LocDetailsFiltercheckedComboBox.Items.Add("ALL");
                LocDetailsFiltercheckedComboBox.SetItemChecked(0, true);


                int j = 1;
                foreach (var item in locationdetailsFilter)
                {
                    LocDetailsFiltercheckedComboBox.Items.Add(item.LocationDetails != null ? item.LocationDetails : "");
                    LocDetailsFiltercheckedComboBox.SetItemChecked(j, true);
                    j++;
                }
            }


            //If more then 5 items, add a scroll bar to the dropdown.
            // LocationFiltercheckedComboBox.MaxDropDownItems = 5;
            // Make the "Name" property the one to display, rather than the ToString() representation.
            LocDetailsFiltercheckedComboBox.DisplayMember = "Name";
            LocDetailsFiltercheckedComboBox.ValueSeparator = ", ";
            //StatusFiltercBox.SetItemCheckState(0, CheckState.Indeterminate);

            //8. reported by
            if (Util.AlYamamabtn == true)
            {
                var reportedBy = (from x in pd.ReportedByFilters
                                  select x).OrderBy(v => v.ReportedBy);

                ReportedByFiltercheckedComboBox.Items.Add("ALL");
                ReportedByFiltercheckedComboBox.SetItemChecked(0, true);


                int m = 1;
                foreach (var item in reportedBy)
                {
                    ReportedByFiltercheckedComboBox.Items.Add(item.ReportedBy != null ? item.ReportedBy : "");
                    ReportedByFiltercheckedComboBox.SetItemChecked(m, true);
                    m++;
                }
            }
            else if (Util.Sharmabtn == true)
            {
                var reportedBy = (from x in pd.ReportedByFilterSharmas
                                  select x).OrderBy(v => v.ReportedBy);

                ReportedByFiltercheckedComboBox.Items.Add("ALL");
                ReportedByFiltercheckedComboBox.SetItemChecked(0, true);


                int m = 1;
                foreach (var item in reportedBy)
                {
                    ReportedByFiltercheckedComboBox.Items.Add(item.ReportedBy != null ? item.ReportedBy : "");
                    ReportedByFiltercheckedComboBox.SetItemChecked(m, true);
                    m++;
                }
            }

            //If more then 5 items, add a scroll bar to the dropdown.
            //ReportedByFiltercheckedComboBox.MaxDropDownItems = 5;
            // Make the "Name" property the one to display, rather than the ToString() representation.
            ReportedByFiltercheckedComboBox.DisplayMember = "Name";
            ReportedByFiltercheckedComboBox.ValueSeparator = ", ";

            //9. completed by
            if (Util.AlYamamabtn == true)
            {
                var completedBy = (from x in pd.CompletedByFilters
                                  select x).OrderBy(v => v.EscalCompletedBy);

                CompletedByFiltercheckedComboBox.Items.Add("ALL");
                CompletedByFiltercheckedComboBox.SetItemChecked(0, true);


                int m = 1;
                foreach (var item in completedBy)
                {
                    CompletedByFiltercheckedComboBox.Items.Add(item.EscalCompletedBy != null ? item.EscalCompletedBy : "");
                    CompletedByFiltercheckedComboBox.SetItemChecked(m, true);
                    m++;
                }
            }
            else if (Util.Sharmabtn == true)
            {
                var completedBy = (from x in pd.CompletedByFilterSharmas
                                   select x).OrderBy(v => v.EscalCompletedBy);

                CompletedByFiltercheckedComboBox.Items.Add("ALL");
                CompletedByFiltercheckedComboBox.SetItemChecked(0, true);


                int m = 1;
                foreach (var item in completedBy)
                {
                    CompletedByFiltercheckedComboBox.Items.Add(item.EscalCompletedBy != null ? item.EscalCompletedBy : "");
                    CompletedByFiltercheckedComboBox.SetItemChecked(m, true);
                    m++;
                }
            }

            //If more then 5 items, add a scroll bar to the dropdown.
            //ReportedByFiltercheckedComboBox.MaxDropDownItems = 5;
            // Make the "Name" property the one to display, rather than the ToString() representation.
            CompletedByFiltercheckedComboBox.DisplayMember = "Name";
            CompletedByFiltercheckedComboBox.ValueSeparator = ", ";

            //10. closed by
            if (Util.AlYamamabtn == true)
            {
                var closedBy = (from x in pd.ClosedByFilters
                                   select x).OrderBy(v => v.ClosedBy);

                ClosedByFiltercheckedComboBox.Items.Add("ALL");
                ClosedByFiltercheckedComboBox.SetItemChecked(0, true);


                int m = 1;
                foreach (var item in closedBy)
                {
                    ClosedByFiltercheckedComboBox.Items.Add(item.ClosedBy != null ? item.ClosedBy : "");
                    ClosedByFiltercheckedComboBox.SetItemChecked(m, true);
                    m++;
                }
            }
            else if (Util.Sharmabtn == true)
            {
                var closedBy = (from x in pd.ClosedByFilterSharmas
                                select x).OrderBy(v => v.ClosedBy);

                ClosedByFiltercheckedComboBox.Items.Add("ALL");
                ClosedByFiltercheckedComboBox.SetItemChecked(0, true);


                int m = 1;
                foreach (var item in closedBy)
                {
                    ClosedByFiltercheckedComboBox.Items.Add(item.ClosedBy != null ? item.ClosedBy : "");
                    ClosedByFiltercheckedComboBox.SetItemChecked(m, true);
                    m++;
                }
            }

            //If more then 5 items, add a scroll bar to the dropdown.
            //ReportedByFiltercheckedComboBox.MaxDropDownItems = 5;
            // Make the "Name" property the one to display, rather than the ToString() representation.
            ClosedByFiltercheckedComboBox.DisplayMember = "Name";
            ClosedByFiltercheckedComboBox.ValueSeparator = ", ";

            //11. department esom
            if (Util.AlYamamabtn == true)
            {
                var departmentEsom = (from x in pd.DepartmentEsomFilters
                                select x).OrderBy(v => v.DepartmentEsom);

                DepartmentEsomFiltercheckedComboBox.Items.Add("ALL");
                DepartmentEsomFiltercheckedComboBox.SetItemChecked(0, true);


                int m = 1;
                foreach (var item in departmentEsom)
                {
                    DepartmentEsomFiltercheckedComboBox.Items.Add(item.DepartmentEsom != null ? item.DepartmentEsom : "");
                    DepartmentEsomFiltercheckedComboBox.SetItemChecked(m, true);
                    m++;
                }
            }
            else if (Util.Sharmabtn == true)
            {
                var departmentEsom = (from x in pd.DepartmentEsomFilterSharmas
                                      select x).OrderBy(v => v.DepartmentEsom);

                DepartmentEsomFiltercheckedComboBox.Items.Add("ALL");
                DepartmentEsomFiltercheckedComboBox.SetItemChecked(0, true);


                int m = 1;
                foreach (var item in departmentEsom)
                {
                    DepartmentEsomFiltercheckedComboBox.Items.Add(item.DepartmentEsom != null ? item.DepartmentEsom : "");
                    DepartmentEsomFiltercheckedComboBox.SetItemChecked(m, true);
                    m++;
                }
            }

            //If more then 5 items, add a scroll bar to the dropdown.
            //ReportedByFiltercheckedComboBox.MaxDropDownItems = 5;
            // Make the "Name" property the one to display, rather than the ToString() representation.
            DepartmentEsomFiltercheckedComboBox.DisplayMember = "Name";
            DepartmentEsomFiltercheckedComboBox.ValueSeparator = ", ";


            ////assigned to
            //var AssignedToFilter = (from x in pd.AssignedToFilters
            //                           select x).OrderBy(v => v.AssignedTo);

            //AssignedToFiltercheckedComboBox.Items.Add("ALL");
            //AssignedToFiltercheckedComboBox.SetItemChecked(0, true);


            ////int p = 1;
            ////foreach (var item in AssignedToFilter)
            ////{
            ////    AssignedToFiltercheckedComboBox.Items.Add(item.AssignedTo);
            ////    AssignedToFiltercheckedComboBox.SetItemChecked(p, true);
            ////    p++;
            ////}

            ////If more then 5 items, add a scroll bar to the dropdown.
            ////AssignedToFiltercheckedComboBox.MaxDropDownItems = 5;
            //// Make the "Name" property the one to display, rather than the ToString() representation.
            //AssignedToFiltercheckedComboBox.DisplayMember = "Name";
            //AssignedToFiltercheckedComboBox.ValueSeparator = ", ";




        }
        //private void resetFilters()
        //{
        //    Util.TrackNoFrom ="";
        //    Util.TrackNoTo = "";
        //    Util.TypeString = "";
        //    Util.StatusString = "";
        //    Util.PriorityString = "";
        //    Util.LocationString = "";
        //    Util.SubLocationString = "";
        //    Util.SpecLocationString = "";
        //    Util.LocationDetailsString = "";
        //    Util.ReportedByString = "";
        //}

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            //Util.AlYamamabtn = false;
            //Util.Sharmabtn = false;
            this.Dispose();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            Util.FilterUsed = true;
            //save data to be filtered
            if (tBoxTrackIdfrom.Enabled == true && tBoxTrackIdTo.Enabled == true)
            {
                Util.TrackNoFrom = tBoxTrackIdfrom.Text;
                Util.TrackNoTo = tBoxTrackIdTo.Text;
            }

            if (typecheckBox.Checked == true)
                Util.TypeString = typeFiltercheckedComboBox.Text;
            if (statuscheckBox.Checked == true)           
                Util.StatusString = StatusFiltercheckedComboBox.Text;
            if (PrioritycheckBox.Checked == true)
                Util.PriorityString = PriorityFiltercheckedComboBox.Text;
            if (LocationCheckBox.Checked == true)
                Util.LocationString = LocationFiltercheckedComboBox.Text;
            if (checkBoxSubLocation.Checked == true)
                Util.SubLocationString = SubLocationFiltercheckedComboBox.Text;
            if (checkBoxSpecLocation.Checked == true)
                Util.SpecLocationString = SpecLocationFiltercheckedComboBox.Text;
            if (checkBoxLocDetails.Checked == true)
                Util.LocationDetailsString = LocDetailsFiltercheckedComboBox.Text;
            if (ReportedBycheckBox.Checked == true)
                Util.ReportedByString = ReportedByFiltercheckedComboBox.Text;
            if (cBoxCompBy.Checked == true)
                Util.CompletedByString = CompletedByFiltercheckedComboBox.Text;
            if(cBoxClosedBy.Checked == true)
                Util.ClosedByString = ClosedByFiltercheckedComboBox.Text;
            if (cBoxDepartmentEsom.Checked == true)
                Util.DepartmentEsomString = DepartmentEsomFiltercheckedComboBox.Text;     
            if (DateCreatedcBox.Checked == true)
            {
                Util.DateCreatedIn = dateCreatedInTimePicker.Text;
                Util.DateCreatedOut = dateCreatedOutTimePicker.Text;
            }
            if (cBoxCompDate.Checked == true)
            {
                Util.CompDateIn = CompDateInTimePicker.Text;
                Util.CompDateOut = CompDateOutTimePicker.Text;
            }
            if (cBoxClosingDate.Checked == true)
            {
                Util.ClosingDateIn = ClosingDateInTimePicker.Text;
                Util.ClosingDateOut = ClosingDateOutTimePicker.Text;
            }
            //if (AssignedTocheckBox.Checked == true)
            //    Util.AssignedToString = AssignedToFiltercheckedComboBox.Text;

            //Util.AlYamamabtn = false;
            //Util.Sharmabtn = false;

            //resetFilters();

            this.Dispose();

            this.Refresh();
        }

        private void ccb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //CCBoxItem item = StatusFiltercheckedComboBox.Items[e.Index] as CCBoxItem;///de verificat click pe item

            //    ////
            //    //if (((System.Windows.Forms.CheckedListBox)(sender)).Text != "")
            //    {
            //        //string objsender = ((System.Windows.Forms.CheckedListBox)(sender)).Text;
            //        //int count = StatusFiltercBox.CheckedIndices.Count;

            //        //bool allSelected = true;
            //        //bool allDeselected = true;
            //        //for (int i = 0; i < StatusFiltercBox.Items.Count; i++)
            //        //{
            //        //    if(StatusFiltercBox.GetItemChecked(i) == false)
            //        //    allSelected = false;
            //        //    if (StatusFiltercBox.GetItemChecked(i) == true)
            //        //        allDeselected = false;
            //        //    //objCombo.SetItemChecked(i, false);
            //        //}

            //        ////if (e.NewValue == CheckState.Checked)
            //        ////{
            //        ////    count = count + 1;
            //        ////}
            //        //else
            //        //    count = count - 1;
            //        //if (
            //        //    objsender.ToLower() == "all" &&
            //        //    e.NewValue == CheckState.Unchecked
            //        ////    //&& allDeselected != true
            //        //    )
            //        //{
            //        //    StatusFiltercBox.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.StatusFiltercBox_Click);
            //        //    UncheckedAll(StatusFiltercBox);
            //        //    StatusFiltercBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.StatusFiltercBox_Click);
            //        //}
            //        //else if (objsender.ToLower() == "all" && e.NewValue == CheckState.Checked)
            //        //{
            //        //    StatusFiltercBox.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.StatusFiltercBox_Click);
            //        //    CheckedAll(StatusFiltercBox);
            //        //    StatusFiltercBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.StatusFiltercBox_Click);
            //        //}
            //        //else if ((objsender.ToLower() != "" && objsender.ToLower() != "all") && e.NewValue == CheckState.Unchecked)
            //        //{
            //        //    this.StatusFiltercBox.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.StatusFiltercBox_Click);
            //        //    StatusFiltercBox.SetItemChecked(0, false);
            //        //    this.StatusFiltercBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.StatusFiltercBox_Click);
            //        //}
            //        //else if ((objsender.ToLower() != "" && objsender.ToLower() != "all") && count == (StatusFiltercBox.Items.Count - 1))
            //        //{
            //        //    StatusFiltercBox.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.StatusFiltercBox_Click);
            //        //    StatusFiltercBox.SetItemChecked(0, true);
            //        //    StatusFiltercBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.StatusFiltercBox_Click);
            //        //}
            //        //return;
            //    }
            //    ////
        }

        private void ccb_ItemCheckType(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = typeFiltercheckedComboBox.Items[e.Index] as CCBoxItem;

        }
        private void ccb_ItemCheckStatus(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = StatusFiltercheckedComboBox.Items[e.Index] as CCBoxItem;

        }
        private void ccb_ItemCheckLocation(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = LocationFiltercheckedComboBox.Items[e.Index] as CCBoxItem;

        }

        private void ccb_ItemCheckSubLocation(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = SubLocationFiltercheckedComboBox.Items[e.Index] as CCBoxItem;

        }

        private void ccb_ItemCheckSpecLocation(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = SpecLocationFiltercheckedComboBox.Items[e.Index] as CCBoxItem;

        }

        private void ccb_ItemCheckLocationDetails(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = LocDetailsFiltercheckedComboBox.Items[e.Index] as CCBoxItem;

        }

        private void ccb_ItemCheckReportedBy(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = ReportedByFiltercheckedComboBox.Items[e.Index] as CCBoxItem;

        }

        private void ccb_ItemCheckCompBy(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = CompletedByFiltercheckedComboBox.Items[e.Index] as CCBoxItem;

        }

        private void ccb_ItemCheckClosedBy(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = ClosedByFiltercheckedComboBox.Items[e.Index] as CCBoxItem;

        }

        private void ccb_ItemCheckDepartmentEsom(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = DepartmentEsomFiltercheckedComboBox.Items[e.Index] as CCBoxItem;

        }

        private void ccb_ItemCheckPriority(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = PriorityFiltercheckedComboBox.Items[e.Index] as CCBoxItem;

        }

        //private void ccb_ItemCheckAssignedTo(object sender, ItemCheckEventArgs e)
        //{
        //    CCBoxItem item = AssignedToFiltercheckedComboBox.Items[e.Index] as CCBoxItem;

        //}       

        //private void ccb_ItemCheckDepartmentInternal(object sender, ItemCheckEventArgs e)
        //{
        //    CCBoxItem item = DepartmentFiltercheckedComboBox.Items[e.Index] as CCBoxItem;

        //}


        private void typecheckBox_CheckedChanged_1(object sender, EventArgs e)
        {
            if (typecheckBox.Checked == true)
                typeFiltercheckedComboBox.Enabled = true;
            if (typecheckBox.Checked == false)
                typeFiltercheckedComboBox.Enabled = false;
        }

        private void statuscheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(statuscheckBox.Checked == true)
                StatusFiltercheckedComboBox.Enabled = true;
            if(statuscheckBox.Checked == false)
                StatusFiltercheckedComboBox.Enabled = false;
        }

        private void LocationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LocationCheckBox.Checked == true)
                LocationFiltercheckedComboBox.Enabled = true;
            if (LocationCheckBox.Checked == false)
                LocationFiltercheckedComboBox.Enabled = false;
        }

        private void checkBoxSubLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSubLocation.Checked == true)
                SubLocationFiltercheckedComboBox.Enabled = true;
            if (checkBoxSubLocation.Checked == false)
                SubLocationFiltercheckedComboBox.Enabled = false;
        }

        private void checkBoxSpecLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSpecLocation.Checked == true)
                SpecLocationFiltercheckedComboBox.Enabled = true;
            if (checkBoxSpecLocation.Checked == false)
                SpecLocationFiltercheckedComboBox.Enabled = false;
        }

        private void checkBoxLocDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLocDetails.Checked == true)
                LocDetailsFiltercheckedComboBox.Enabled = true;
            if (checkBoxLocDetails.Checked == false)
                LocDetailsFiltercheckedComboBox.Enabled = false;
        }

        private void ReportedBycheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ReportedBycheckBox.Checked == true)
                ReportedByFiltercheckedComboBox.Enabled = true;
            if (ReportedBycheckBox.Checked == false)
                ReportedByFiltercheckedComboBox.Enabled = false;
        }

        private void CompBycheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxCompBy.Checked == true)
                CompletedByFiltercheckedComboBox.Enabled = true;
            if (cBoxCompBy.Checked == false)
                CompletedByFiltercheckedComboBox.Enabled = false;
        }

        private void ClosedBycheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxClosedBy.Checked == true)
                ClosedByFiltercheckedComboBox.Enabled = true;
            if (cBoxClosedBy.Checked == false)
                ClosedByFiltercheckedComboBox.Enabled = false;
        }

        private void DepartmentEsomcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxDepartmentEsom.Checked == true)
                DepartmentEsomFiltercheckedComboBox.Enabled = true;
            if (cBoxDepartmentEsom.Checked == false)
                DepartmentEsomFiltercheckedComboBox.Enabled = false;
        }

        private void PrioritycheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PrioritycheckBox.Checked == true)
                PriorityFiltercheckedComboBox.Enabled = true;
            if (PrioritycheckBox.Checked == false)
                PriorityFiltercheckedComboBox.Enabled = false;
        }        

        //private void AssignedTocheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (AssignedTocheckBox.Checked == true)
        //        AssignedToFiltercheckedComboBox.Enabled = true;
        //    if (AssignedTocheckBox.Checked == false)
        //        AssignedToFiltercheckedComboBox.Enabled = false;
        //}      

        //private void DepartmentInternalcheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (DepartmentcheckBox.Checked == true)
        //        DepartmentFiltercheckedComboBox.Enabled = true;
        //    if (DepartmentcheckBox.Checked == false)
        //        DepartmentFiltercheckedComboBox.Enabled = false;
        //}

        private void DateCreatedcBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DateCreatedcBox.Checked == true)
            {
                dateCreatedInTimePicker.Enabled = true;
                dateCreatedOutTimePicker.Enabled = true;
            }
            if (DateCreatedcBox.Checked == false)
            {
                dateCreatedInTimePicker.Enabled = false;
                dateCreatedOutTimePicker.Enabled = false;
            }
        }

        private void cBoxCompDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxCompDate.Checked == true)
            {
                CompDateInTimePicker.Enabled = true;
                CompDateOutTimePicker.Enabled = true;
            }
            if (cBoxCompDate.Checked == false)
            {
                CompDateInTimePicker.Enabled = false;
                CompDateOutTimePicker.Enabled = false;
            }
        }

        private void cBoxCloseDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxClosingDate.Checked == true)
            {
                ClosingDateInTimePicker.Enabled = true;
                ClosingDateOutTimePicker.Enabled = true;
            }
            if (cBoxClosingDate.Checked == false)
            {
                ClosingDateInTimePicker.Enabled = false;
                ClosingDateOutTimePicker.Enabled = false;
            }
        }


        private void StatusFiltercBox_Click(object sender, EventArgs e)
        {
            int g = 0;
            //statuscheckBox.it
            //if (this.Visible == true)
            //{
            //    this.Hide();
            //}
            //else
            //    this.Show();
        }

        private void StatusFiltercBox_MouseClick(object sender, MouseEventArgs e)
        {
            int g = 0;
        }

        private void StatusFiltercBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //StatusFiltercBox.Items.Add("ALL");
            //StatusFiltercBox.SetItemChecked(0, true);
        }

        private void TrackIdcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TrackIdcheckBox.Checked == true)
            {
                tBoxTrackIdfrom.Enabled = true;
                tBoxTrackIdTo.Enabled = true;
            }
            if (TrackIdcheckBox.Checked == false)
            {
                tBoxTrackIdfrom.Enabled = false;
                tBoxTrackIdTo.Enabled = false;
                tBoxTrackIdfrom.Text = "";
                tBoxTrackIdTo.Text = "";
            }
        }

       






        //private void StatusSelectbtn_Click(object sender, EventArgs e)
        //{
        //    if(StatusSelectbtn.Text == "SelectAll")
        //        {
        //            for (int i = 0; i < StatusFiltercheckedComboBox.Items.Count; i++)
        //            {
        //            StatusFiltercheckedComboBox.SetItemChecked(i, true);
        //            }
        //        StatusSelectbtn.Text = "DeselectAll";
        //        StatusSelectbtn.ForeColor = Color.Red;
        //        return;
        //        }

        //    if (StatusSelectbtn.Text == "DeselectAll")
        //    {
        //        for (int i = 0; i < StatusFiltercheckedComboBox.Items.Count; i++)
        //        {
        //            StatusFiltercheckedComboBox.SetItemChecked(i, false);
        //        }
        //        StatusSelectbtn.Text = "SelectAll";
        //        StatusSelectbtn.ForeColor = Color.Green;
        //        return;
        //    }
        //}


    }
}
