/*-----------------------------------------------------------------------
<copyright file="PersonSimple.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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
        public PersonSimple(int personID, Guid personGuid, string firstName, string lastName, string email, string phone, string passwordPdfK2SaltHash, int roleID, DateTime createDate, DateTime? updateDate, DateTime? lastActivityDate, bool isActive, int organizationID, Guid? webServiceAccessToken)
            : this()
        {
            PersonID = personID;
            PersonGuid = personGuid;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            PasswordPdfK2SaltHash = passwordPdfK2SaltHash;
            RoleID = roleID;
            CreateDate = createDate;
            UpdateDate = updateDate;
            LastActivityDate = lastActivityDate;
            IsActive = isActive;
            OrganizationID = organizationID;
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
            RoleID = person.RoleID;
            CreateDate = person.CreateDate;
            UpdateDate = person.UpdateDate;
            LastActivityDate = person.LastActivityDate;
            IsActive = person.IsActive;
            OrganizationID = person.OrganizationID;
            WebServiceAccessToken = person.WebServiceAccessToken;
        }

        public int PersonID { get; set; }
        public Guid PersonGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordPdfK2SaltHash { get; set; }
        public int RoleID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public bool IsActive { get; set; }
        public int OrganizationID { get; set; }
        public Guid? WebServiceAccessToken { get; set; }
        public string DisplayName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
    }
}
