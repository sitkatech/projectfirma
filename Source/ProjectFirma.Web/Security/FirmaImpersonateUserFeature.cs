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

        public void DemandPermission(Person person, Person contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person currentUser, Person personToImpersonate)
        {
            if (personToImpersonate == null)
            {
                // Or should this just return false? Unsure; we'll see if it's a real use case or represents an actual coding error.
                return new PermissionCheckResult("You can't impersonate an Anonymous/null user.");
            }

#pragma warning disable 612
            bool userHasAppropriateRole = HasPermissionByPerson(currentUser);
#pragma warning restore 612
            if (!userHasAppropriateRole)
            {
                return new PermissionCheckResult("You can't impersonate users. If you aren't logged in, do that and try again.");
            }

            bool userViewingOwnPage = currentUser.PersonID == personToImpersonate.PersonID;
            if (userViewingOwnPage)
            {
                return new PermissionCheckResult("You can't impersonate yourself.");
            }

            // Success - Current logged-in-user can impersonate this particular Person.
            return new PermissionCheckResult();
        }

        //This should only ever be called by HasPermission
        [Obsolete]
        public new bool HasPermissionByPerson(Person person)
        {
            return base.HasPermissionByPerson(person);
        }

        public new bool HasPermissionByFirmaSession(FirmaSession firmaSession)
        {
            bool currentEffectiveUserHasRole = firmaSession.Person != null && base.HasPermissionByPerson(firmaSession.Person);
            bool isImpersonatingAndOriginalUserHasRole = firmaSession.IsImpersonating() && base.HasPermissionByPerson(firmaSession.OriginalPerson);

            // Impersonation allowed if:
            //
            //  -- If your currently logged-in account has the rights
            // OR
            //  -- If you are currently impersonating and your original role had the rights
            return currentEffectiveUserHasRole || isImpersonatingAndOriginalUserHasRole;
        }
    }
}