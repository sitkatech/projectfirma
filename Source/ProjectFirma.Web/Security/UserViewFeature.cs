using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View User")]
    public class UserViewFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Person>
    {
        private readonly FirmaFeatureWithContextImpl<Person> _firmaFeatureWithContextImpl;

        public UserViewFeature() : base(Role.All)
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Person>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, Person contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }


        public PermissionCheckResult HasPermission(Person person, Person contextModelObject)
        {
            var userHasEditPermission = new UserEditFeature().HasPermissionByPerson(person);
            var userViewingOwnPage = person.PersonID == contextModelObject.PersonID;
            
            if (userViewingOwnPage || userHasEditPermission)
            {
                return new PermissionCheckResult();    
            }

            return new PermissionCheckResult("You don\'t have permission to view this user.");
        }

    }
}