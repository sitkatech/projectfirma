using System;

namespace ProjectFirma.Web.Models
{
    public class PersonSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PersonSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonSimple(int personID, Guid personGuid, string firstName, string lastName, string email, string phone, string passwordPdfK2SaltHash, int eIPRoleID, DateTime createDate, DateTime? updateDate, DateTime? lastActivityDate, bool isActive, int organizationID, int sustainabilityRoleID, int lTInfoRoleID, int parcelTrackerRoleID, Guid? webServiceAccessToken)
            : this()
        {
            PersonID = personID;
            PersonGuid = personGuid;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            PasswordPdfK2SaltHash = passwordPdfK2SaltHash;
            EIPRoleID = eIPRoleID;
            CreateDate = createDate;
            UpdateDate = updateDate;
            LastActivityDate = lastActivityDate;
            IsActive = isActive;
            OrganizationID = organizationID;
            SustainabilityRoleID = sustainabilityRoleID;
            LTInfoRoleID = lTInfoRoleID;
            ParcelTrackerRoleID = parcelTrackerRoleID;
            WebServiceAccessToken = webServiceAccessToken;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PersonSimple(Person person)
            : this()
        {
            PersonID = person.PersonID;
            PersonGuid = person.PersonGuid;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Email = person.Email;
            Phone = person.Phone;
            PasswordPdfK2SaltHash = person.PasswordPdfK2SaltHash;
            EIPRoleID = person.EIPRoleID;
            CreateDate = person.CreateDate;
            UpdateDate = person.UpdateDate;
            LastActivityDate = person.LastActivityDate;
            IsActive = person.IsActive;
            OrganizationID = person.OrganizationID;
            SustainabilityRoleID = person.SustainabilityRoleID;
            LTInfoRoleID = person.LTInfoRoleID;
            ParcelTrackerRoleID = person.ParcelTrackerRoleID;
            WebServiceAccessToken = person.WebServiceAccessToken;
        }

        public int PersonID { get; set; }
        public Guid PersonGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordPdfK2SaltHash { get; set; }
        public int EIPRoleID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public bool IsActive { get; set; }
        public int OrganizationID { get; set; }
        public int SustainabilityRoleID { get; set; }
        public int LTInfoRoleID { get; set; }
        public int ParcelTrackerRoleID { get; set; }
        public Guid? WebServiceAccessToken { get; set; }
        public string DisplayName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
    }
}