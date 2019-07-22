namespace ProjectFirmaModels.Models
{
    public partial class ProjectContact : IAuditableEntity, IProjectContact
    {
        private string _displayCssClass;

        public string GetAuditDescriptionString()
        {
            return $"Project: {ProjectID}, PersonID: {ContactID}";
        }

        public ProjectContact(Person contact, ContactRelationshipType contactRelationshipType, string displayCssClass)
        {
            Contact = contact;
            ContactRelationshipType = contactRelationshipType;
            SetDisplayCssClass(displayCssClass);
        }

        public void SetDisplayCssClass(string value)
        {
            _displayCssClass = value;
        }

        public string GetDisplayCssClass()
        {
            return _displayCssClass;
        }

        public ProjectContact(IProjectContact projectContact)
        {
            Contact = projectContact.Contact;
            ContactRelationshipType = projectContact.ContactRelationshipType;
        }
    }
}