using System.Linq;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ContactType GetDefaultContactType(this IQueryable<ContactType> contactTypes)
        {
            var defaultContactType = contactTypes.SingleOrDefault(x => x.IsDefaultContactType);
            if (defaultContactType == null)
            {
                defaultContactType = contactTypes.OrderBy(x => x.ContactTypeID).First();
            }
            return defaultContactType;
        }
    }
}