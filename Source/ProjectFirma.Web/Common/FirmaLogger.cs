using System;
using System.Web;
using LtInfo.Common;

namespace ProjectFirma.Web.Common
{
    public class FirmaLogger : SitkaLogger
    {
        public override string GetUserAndSessionInformationForError(HttpContext context)
        {
            var person = HttpRequestStorage.Person;
            if (person.IsAnonymousUser)
            {
                return "User: Anonymous";
            }
            string organizationName = person.Organization.OrganizationName;
            return String.Format("User: {1}{0}LogonName: {2}{0}PersonID: {3}{0}Organization: {4}{0}", Environment.NewLine, person.FullNameFirstLast, person.Email, person.PersonID, organizationName);
        }
    }
}