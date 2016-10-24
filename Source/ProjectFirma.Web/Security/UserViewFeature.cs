using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View User")]
    public class UserViewFeature : EIPFeatureWithContext, ILakeTahoeInfoBaseFeatureWithContext<Person>
    {
        private readonly LakeTahoeInfoFeatureWithContextImpl<Person> _lakeTahoeInfoFeatureWithContextImpl;

        public UserViewFeature() : base(EIPRole.All)
        {
            _lakeTahoeInfoFeatureWithContextImpl = new LakeTahoeInfoFeatureWithContextImpl<Person>(this);
            ActionFilter = _lakeTahoeInfoFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, Person contextModelObject)
        {
            _lakeTahoeInfoFeatureWithContextImpl.DemandPermission(person, contextModelObject);
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