namespace ProjectFirmaModels.Models
{
    /// <summary>
    /// These have been implemented as extension methods on <see cref="Person"/> so we can handle the anonymous user as a null person object
    /// </summary>
    public static class FirmaSessionExtensions
    {
        public static bool IsImpersonating(this FirmaSession firmaSession)
        {
            return firmaSession.OriginalPersonID != null && firmaSession.PersonID != firmaSession.OriginalPersonID;
        }
    }
}