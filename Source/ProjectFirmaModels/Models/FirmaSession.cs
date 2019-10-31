using System;
using LtInfo.Common.DesignByContract;

namespace ProjectFirmaModels.Models
{
    public partial class FirmaSession : IAuditableEntity
    {

        /// <summary>
        /// Static constructor
        /// </summary>
        /// <returns></returns>
        public static FirmaSession MakeEmptyFirmaSession(Tenant tenant)
        {
            Check.EnsureNotNull(tenant, "Tenant must not be null. Should be current Tenant.");

            // I'd prefer just to write this as a real constructor, but it's already in EF generated code, so we resort to this.
            var newFirmaSession = new FirmaSession();
            newFirmaSession.FirmaSessionGuid = Guid.NewGuid();
            newFirmaSession.CreateDate = DateTime.Now;
            newFirmaSession.TenantID = tenant.TenantID;

            return newFirmaSession;
        }

        /// <summary>
        /// Constructor for a new FirmaSession for a given Person
        /// </summary>
        /// <param name="person"></param>
        public FirmaSession(Person person)
        {
            Check.EnsureNotNull(person, "Do not call this if Person is null");

            FirmaSessionGuid = Guid.NewGuid();
            CreateDate = DateTime.Now;
            Person = person;
            TenantID = person.Tenant.TenantID;
        }

        public string GetAuditDescriptionString()
        {
            return string.Format($"{this.FirmaSessionGuid}");
        }

        public bool IsAnonymousUser()
        {
            return Person == null;
        }

        public bool IsAnonymousOrUnassigned()
        {
            return IsAnonymousUser() || Person.Role == Role.Unassigned;
        }
    }
}