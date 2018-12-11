using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Common
{
    public interface ICanDeleteFull
    {
        void DeleteFull(DatabaseEntities dbContext);
    }
}