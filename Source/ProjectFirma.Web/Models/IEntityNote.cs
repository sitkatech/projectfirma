using System;

namespace ProjectFirma.Web.Models
{
    public interface IEntityNote
    {
        DateTime LastUpdated { get; }
        string LastUpdatedBy { get; }
        string DeleteUrl { get; }
        string EditUrl { get; }
        String Note { get; set; }
    }
}