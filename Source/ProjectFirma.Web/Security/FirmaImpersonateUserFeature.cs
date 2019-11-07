using System;
using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Impersonate User")]
    public class FirmaImpersonateUserFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Person>
    {
        private readonly FirmaFeatureWithContextImpl<Person> _firmaFeatureWithContextImpl;

        public FirmaImpersonateUserFeature()
            : base(new List<Role> {Role.SitkaAdmin})
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Person>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, Person contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Person personToImpersonate)
        {
            if (personToImpersonate == null)
            {
                // Or should this just return false? Unsure; we'll see if it's a real use case or represents an actual coding error.
                return new PermissionCheckResult("You can't impersonate an Anonymous/null user.");
            }

#pragma warning disable 612
            bool userHasAppropriateRole = HasPermissionByFirmaSession(firmaSession);
#pragma warning restore 612
            if (!userHasAppropriateRole)
            {
                return new PermissionCheckResult("You can't impersonate users. If you aren't logged in, do that and try again.");
            }

            bool userViewingOwnPage = !firmaSession.IsAnonymousUser() && firmaSession.PersonID == personToImpersonate.PersonID;
            if (userViewingOwnPage)
            {
                return new PermissionCheckResult("You can't impersonate yourself.");
            }

            // Success - Current logged-in-user can impersonate this particular Person.
            return new PermissionCheckResult();
        }

        ////This should only ever be called by HasPermission
        //[Obsolete]
        //public new bool HasPermissionByFirmaSession(FirmaSession firmaSession)
        //{
        //    return base.HasPermissionByPerson(person);
        //}

        public new bool HasPermissionByFirmaSession(FirmaSession firmaSession)
        {
            bool currentEffectiveUserHasRole = firmaSession.Person != null && base.HasPermissionByFirmaSession(firmaSession);
            bool isImpersonatingAndOriginalUserHasRole = firmaSession.IsImpersonating() && base.HasPermissionByFirmaSession(firmaSession);

            // Impersonation allowed if:
            //
            //  -- If your currently logged-in account has the rights
            // OR
            //  -- If you are currently impersonating and your original role had the rights
            return currentEffectiveUserHasRole || isImpersonatingAndOriginalUserHasRole;
        }
    }
}