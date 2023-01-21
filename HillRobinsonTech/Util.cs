using System;
using System.Collections.Generic;
using System.Net;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillRobinsonTech
{
    class Util
    {
        //DataContext
        public static TechDboDataContext pd = new TechDboDataContext();     


        public static string currentSession = "";
        public static double version = 0.0;
        public static string versionDate = "";
        public static string fullVersionInfo = "";

        public static string fullNameConnected = "";
        public static string departmentConnected = "";
        public static string userTypeConnected = "";       
        public static string userEmailConnected = "";
        public static string userRoleConnected = "";
        public static int userRolePriorityIdConnected = 0;
        public static string oldPassw = "";
        public static string passw = "";
        public static string userConnected = "";
        public static string positionUserConnected = "";
        public static int    userIdConnected = 0;
        public static string passCript = "";
        public static Boolean persAccount = false;

        public static int    trackId = 0;
        public static string contractor = "";
        public static string status = "";
        public static string priority = "";
        public static string duringAfterVisit = "";
        public static string issueDesc = "";
        public static string location = "";
        public static string subLocation = "";
        public static string specLocation = "";
        public static string locationDetails = "";

        //public static string dateReceived = "";
        public static string dateCreated = "";
        public static string dueDate = "";
        public static string daysOpen = "";
        public static string reportedBy = "";
        public static string Owner = "";
        public static string assignedTo = "";
        public static string assignedToPerson = "";

        public static string departmentRef = "";
       
        public static string escalatedTo = "";
        public static string departmentEsom = "";
        public static string departmentInternal = "";
        public static Boolean escalation = false;
        public static Boolean ContrToInternal = false;
        public static string InternalRef = "";
        public static int ContractorTrackIdInternalRef = 0;
        public static string esomRef = "";
        public static string reportDate = "";
        public static string closingComment = "";
        public static string followUp = "";
        public static string ActionPlan = "";
        public static string MaterialsNeeded = "";


        public static string closedBy = "";
        public static string inspDate = "";
        public static string ClosingDate = "";
        public static string RecordType = "";
        public static string EscalComm = "";
        public static string EscalCompBy = "";
        public static string EscalStartDate = "";
        public static string EscalComplDate = "";
        public static string Manager = "";
        public static string TechnicianAssigned = "";

        public static string HLRFReport = "";
        public static string ContractorFReport = "";

        public static bool newItem = false;

        public static int PreviousWReport = 0;
        public static string WeeklyCurrentReportStartDate = "";
        public static string WeeklyCurrentReportEndDate = "";

        //filters
        public static bool SearchBoxFilterUsed = false;
        public static bool FilterUsed = false;
        public static List<string> statusFilterLists = new List<string>();
        public static string TrackNoFrom = "";
        public static string TrackNoTo = "";
        public static string TypeString = "";
        public static string StatusString = "";
        public static string PriorityString = "";
        public static string LocationString = "";
        public static string SubLocationString = "";
        public static string SpecLocationString = "";
        public static string LocationDetailsString = "";
        public static string DateCreatedIn = "";
        public static string DateCreatedOut = "";
        public static string CompDateIn = "";
        public static string CompDateOut = "";
        public static string ClosingDateIn = "";
        public static string ClosingDateOut = "";
        public static string ReportedByString = "";
        public static string CompletedByString = "";
        public static string ClosedByString = "";
        public static string DepartmentRefString = "";
        public static string AssignedToString = "";
        public static string EscalatedToString = "";
        public static string DepartmentEsomString = "";
        public static string ReportDateIn = "";
        public static string ReportDateOut = "";

        public static int today = 0;
        public static int curWeek = 0;
        public static int curMonth = 0;
        public static int wholeList = 1;


        public static int CloseDropdownNr = 1;

        public static bool SaveError = false;

        //users
        public static bool newUser = false;
        public static int userId = 0;
        public static string userType = "";
        public static string userProject = "";
        public static string department = "";
        public static string position = "";
        public static string user = "";
        public static string pass = "";
        public static string name = "";
        public static string Email = "";
        public static int active = 0;
        public static string userIp = "";
        public static string userMachine = "";
        public static string userMachineMacc = "";
        public static string windowsAccount = "";
        public static List<string> userRolePermissions = new List<string>();
        public static List<string> userPermissions = new List<string>();
        public static string userRole = "";

        //user filters
        public static string UserTypeString = "";
        public static string UserDepartmentString = "";
        public static string UserPositionString = "";
        public static string UserNameString = "";
        public static string UserDefaultProjectString = "";

        //flags
        public static bool filterSel = false;
        public static bool filterAllSel = false;

        //locations
        public static bool Sharmabtn = false;
        public static bool AlYamamabtn = true;

        //page
        public static int pageNum = 0;
        public static int pageSize = 32;
        public static string Order = "TrackId DESC";
        public static string Cols = " * ";

        public static int pageNumCont = 0;
        public static int pageSizeCont = 32;
        public static string OrderCont = "Id DESC";
        public static string ColsCont = " * ";

        public static int pageNumUser = 0;
        public static int pageSizeUser = 32;
        public static string OrderUser = "Name";
        public static string ColsUser = " * ";

        public static int pageNumLocation = 0;
        public static int pageSizeLocation = 32;
        public static string OrderLocation = "BuildingId";
        public static string ColsLocation = " * ";

        //export location
        public static string exportLocation = "";

        //date format
        public static DateTime NADate = DateTime.ParseExact(Convert.ToDateTime("01/01/1900 00:00:00").ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/").Replace(".", "/"), "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

        //permissions
        public static int permissionId = 0;
        public static string permissionName = "";
        public static string permissionDescription = "";
        public static bool newPermission = false;

        //roles
        public static int roleId = 0;
        public static string roleName = "";
        public static string roleDescription = "";
        public static bool newRole = false;

        public static Object[] objRolePermissions = new Object[50];
        public static Object[] objUserPermissions = new Object[50];
        public static Dictionary<int, string> objRolePermissionsList = new Dictionary<int, string>();
        public static Dictionary<int, string> objUserPermissionsList = new Dictionary<int, string>();

        ////page permission
        //public static string InternalTaskViewPermissionId = "VIEW_INTERNAL_TASKS";
        //public static string InternalTaskEditPermissionId = "ADD_EDIT_INTERNAL_TASKS";
        //public static string ContractorTaskViewPermissionId = "VIEW_CONTRACTOR_TASKS";
        //public static string ContractorTaskEditPermissionId = "ADD_EDIT_CONTRACTOR_TASKS";
        //public static string ContactsViewPermissionId = "VIEW_CONTACTS";
        //public static string ContactsEditPermissionId = "ADD_EDIT_CONTACTS";


        //contacts
        public static int ContactId = 0;
        public static string ContactFullName = "";
        public static string ContactFirstName = "";
        public static string ContactLastName = "";
        public static string ContactCompany = "";
        public static string ContactDepartment = "";
        public static string ContactPosition = "";
        public static string ContactWorkPhoneDetails = "";
        public static string ContactWorkPhoneNo = "";
        public static string ContactWorkEmail = "";
        public static string ContactPersPhoneNo = "";
        public static string ContactPersEmail = "";
        public static string ContactCountry = "";
        public static string ContactLocation = "";
        public static string ContactOtherInfo = "";
        public static int ContactActive = 1;

        //locations
        public static int LocationId = 0;
        public static int PriorityId = 0;
        public static int LocationProject = 0;
        public static string LocationBuildingId = "";
        public static string LocationSublocation = "";
        public static string LocationSpecificLocation = "";
        public static string LocationLocationDetails = "";
        public static string LocationHKAlias = "";
        public static string LocationFBAlias = "";
        public static string LocationAHU = "";
        public static int    LocationICT = 0;
        public static string LocationOtherInfo = "";

        public static string LocationBuildingIdString = "";
        public static string LocationSublocationString = "";

        //search tool
        public static bool SearchLocationTool = false;

        //weekly report
        public static string WeekStartingWO = "";
        public static string RaisedWO = "";
        public static string CompletedWO = "";
        public static string WeekClosingWO = "";



        //user list
        public static List<string> userListInDepartment = new List<string>();
        public static Array userDisplay()
        {
            var userInfo = (from x in pd.Users
                            where x.department == Util.departmentConnected
                            && x.DefaultProject > 0 && x.userName.ToLower() != "Guest".ToLower() && x.Active == 1 && x.userName != Util.userConnected
                            select x).OrderBy(v => v.id);
           

            foreach (var userItem in userInfo)
            {
                if(!userListInDepartment.Contains(userItem.name))
                userListInDepartment.Add(userItem.name);    
            }
            return userListInDepartment.ToArray();
        }

        //location list AY
        public static List<string> locationListAY = new List<string>();
        public static Array locationListAYDisplay()
        {
            var locationInfo = (from x in pd.Locations
                            where x.Project == 1                           
                            select x).OrderBy(v => v.id);


            foreach (var location in locationInfo)
            {
                if (!locationListAY.Contains(location.BuildingId))
                    locationListAY.Add(location.BuildingId);
            }
            return locationListAY.ToArray();
        }

        //subLocation list AY
        public static List<string> subLocationListAY = new List<string>();
        public static Array subLocationListAYDisplay(string Location)
        {
            var sublocationInfo = (from x in pd.Locations
                                where x.Project == 1 && x.BuildingId == Location
                                   select x).OrderBy(v => v.Sublocation);


            foreach (var sublocation in sublocationInfo)
            {
                if (!subLocationListAY.Contains(sublocation.Sublocation))
                    subLocationListAY.Add(sublocation.Sublocation);
            }
            return subLocationListAY.ToArray();
        }

        //specLocation list AY
        public static List<string> specLocationListAY = new List<string>();
        public static Array specLocationListAYDisplay(string Location, string subLocation)
        {
            var speclocationInfo = (from x in pd.Locations
                                   where x.Project == 1 && x.BuildingId == Location && x.Sublocation == subLocation
                                   select x).OrderBy(v => v.id);


            foreach (var speclocation in speclocationInfo)
            {
                if (!specLocationListAY.Contains(speclocation.SpecificLocation))
                    specLocationListAY.Add(speclocation.SpecificLocation);
            }
            //specLocationListAY.Sort();
            return specLocationListAY.ToArray();
        }

        //Location detail list AY
        public static List<string> LocationDetailListAY = new List<string>();   
        
        public static Array LocationDetailListAYDisplay(string Location, string subLocation, string specLocation)
        {
            var locationDetailInfo = (from x in pd.Locations
                                    where x.Project == 1 && x.BuildingId == Location && x.Sublocation == subLocation && x.SpecificLocation == specLocation
                                    select x).OrderBy(v => v.id);


            foreach (var locationDetail in locationDetailInfo)
            {
                if (!LocationDetailListAY.Contains(locationDetail.LocationDetails))
                    LocationDetailListAY.Add(locationDetail.LocationDetails);
            }
            return LocationDetailListAY.ToArray();
        }

        //AHU id details
        public static List<string> AHULocationListAY = new List<string>();
        public static Array AHULocationListAYDisplay(string Location, string subLocation, string specLocation)
        {
            var locationDetailInfo = (from x in pd.Locations
                                      where x.Project == 1 && x.BuildingId == Location && x.Sublocation == subLocation && x.SpecificLocation == specLocation
                                      select x).OrderBy(v => v.id);


            foreach (var locationDetail in locationDetailInfo)
            {
                if (!AHULocationListAY.Contains(locationDetail.AHU))
                    AHULocationListAY.Add(locationDetail.AHU);
            }
            return AHULocationListAY.ToArray();
        }

        //contractor manager list AY
        public static List<string> managerListAY = new List<string>();
        public static Array contractorManagerListAY()
        {
            var managerInfo = (from x in pd.TechIntTrackers
                                //where x.Project == 1
                                select x).OrderBy(v => v.TrackId);


            foreach (var manager in managerInfo)
            {
                if (!managerListAY.Contains(manager.Manager) && manager.Manager != null && manager.Manager != String.Empty)
                    managerListAY.Add(manager.Manager);
            }
            return managerListAY.ToArray();
        }

        //contractor technician list AY
        public static List<string> technicianListAY = new List<string>();
        public static Array contractorTechnicianListAY()
        {
            var technicianInfo = (from x in pd.TechIntTrackers
                                   //where x.Project == 1
                               select x).OrderBy(v => v.TrackId);


            foreach (var technician in technicianInfo)
            {
               if (!technicianListAY.Contains(technician.TechnicianAssigned) && technician.TechnicianAssigned != null && technician.TechnicianAssigned != String.Empty)
                    technicianListAY.Add(technician.TechnicianAssigned);
            }
            return technicianListAY.ToArray();
        }


    }
}
