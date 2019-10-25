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
        public static FirmaSession MakeEmptyFirmaSession()
        {
            // I'd prefer just to write this as a real constructor, but it's already in EF generated code, so we resort to this.
            var newFirmaSession = new FirmaSession();
            newFirmaSession.FirmaSessionGuid = new Guid();
            newFirmaSession.CreateDate = DateTime.Now;

            return newFirmaSession;
        }

        /// <summary>
        /// Constructor for a new FirmaSession for a given Person
        /// </summary>
        /// <param name="person"></param>
        public FirmaSession(Person person)
        {
            Check.EnsureNotNull(person, "Do not call this if Person is null");

            FirmaSessionGuid = new Guid();
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
    }
}