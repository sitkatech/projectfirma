namespace ProjectFirmaModels.Models
{

    public class CustomPageSimple
    {
        public int CustomPageID { get; set; }
        public string CustomPageDisplayName { get; set; }
        public int? DocumentLibraryID { get; set; }

        public CustomPageSimple(CustomPage customPage)
        {
            CustomPageID = customPage.CustomPageID;
            CustomPageDisplayName = customPage.CustomPageDisplayName;
            DocumentLibraryID = customPage.DocumentLibraryID;
        }
    }
}