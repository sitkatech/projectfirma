using System;
using System.Linq;
using NUnit.Framework;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirmaModels.UnitTestCommon;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class PersonModelExtensionsTests
    {

        [Test]
        public void CanDeletePersonReturnsTrueForNewlyCreatedUserDeletingOtherNewlyCreatedUser()
        {
            var tenant = Tenant.SitkaTechnologyGroup;
            var organization = HttpRequestStorage.DatabaseEntities.AllOrganizations.First(x => x.TenantID == tenant.TenantID && x.OrganizationShortName == "Sitka");

            var person1 = TestFramework.TestPerson.Create(tenant);
            person1.CreateDate = DateTime.Now;
            person1.LoginName = person1.Email;
            person1.Organization = organization;
            person1.PersonGuid = Guid.NewGuid();
            HttpRequestStorage.DatabaseEntities.AllPeople.Add(person1);
            HttpRequestStorage.DatabaseEntities.SaveChanges(person1);

            var person2 = TestFramework.TestPerson.Create(tenant);
            person2.CreateDate = DateTime.Now;
            person2.LoginName = person2.Email;
            person2.Organization = organization;
            person2.PersonGuid = Guid.NewGuid();
            HttpRequestStorage.DatabaseEntities.AllPeople.Add(person2);
            HttpRequestStorage.DatabaseEntities.SaveChanges(person2);

            var person1CanDeletePerson2 = person2.CanDeletePerson(person1);

            // clean up the DB
            person1.DeleteFull(HttpRequestStorage.DatabaseEntities);
            person2.DeleteFull(HttpRequestStorage.DatabaseEntities);
            HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(tenant.TenantID);

            Assert.That(person1CanDeletePerson2, "A person should be able to delete another person if that user newly created. (i.e. the newly created person would not be associated to any other objects besides approved types of AuditLog entries)");
        }

        [Test]
        public void CanDeletePersonShouldReturnFalseIfPersonAttemptsToDeleteSelf()
        {
            var tenant = Tenant.SitkaTechnologyGroup;
            var organization = HttpRequestStorage.DatabaseEntities.AllOrganizations.First(x => x.TenantID == tenant.TenantID && x.OrganizationShortName == "Sitka");
            var person = TestFramework.TestPerson.Create(tenant);
            person.CreateDate = DateTime.Now;
            person.LoginName = person.Email;
            person.Organization = organization;
            person.PersonGuid = Guid.NewGuid();
            HttpRequestStorage.DatabaseEntities.AllPeople.Add(person);
            HttpRequestStorage.DatabaseEntities.SaveChanges(person);
            var canDeletePerson = person.CanDeletePerson(person);
            
            // clean up the DB
            person.DeleteFull(HttpRequestStorage.DatabaseEntities);
            HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(tenant.TenantID);
            Assert.That(canDeletePerson, Is.False, "A person should not be allowed to delete themselves.");
        }

        [Test]
        public void CanDeletePersonReturnsFalseWhenPersonHasNonApprovedAuditLogEntries()
        {
            var tenant = Tenant.SitkaTechnologyGroup;
            var organization = HttpRequestStorage.DatabaseEntities.AllOrganizations.First(x => x.TenantID == tenant.TenantID && x.OrganizationShortName == "Sitka");
            var person1 = TestFramework.TestPerson.Create(tenant);
            person1.CreateDate = DateTime.Now;
            person1.LoginName = person1.Email;
            person1.Organization = organization;
            person1.PersonGuid = Guid.NewGuid();
            HttpRequestStorage.DatabaseEntities.AllPeople.Add(person1);
            HttpRequestStorage.DatabaseEntities.SaveChanges(person1);

            var person2 = TestFramework.TestPerson.Create(tenant);
            person2.CreateDate = DateTime.Now;
            person2.LoginName = person2.Email;
            person2.Organization = organization;
            person2.PersonGuid = Guid.NewGuid();
            HttpRequestStorage.DatabaseEntities.AllPeople.Add(person2);
            HttpRequestStorage.DatabaseEntities.SaveChanges(person2);

            // person1 changes something about person2. person1 should not  be able to be deleted by person2 because person1 will have an audit log record editing a person other than themselves

            person2.RoleID = Role.ProjectSteward.RoleID;
            HttpRequestStorage.DatabaseEntities.SaveChanges(person1);

            var person2CanDeletePerson1 = person1.CanDeletePerson(person2);

            // clean up the DB
            person1.DeleteFull(HttpRequestStorage.DatabaseEntities);
            person2.DeleteFull(HttpRequestStorage.DatabaseEntities);
            HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(tenant.TenantID);

            Assert.That(person2CanDeletePerson1, Is.False, "A Person should not be able to be deleted if they have audit log records editing another person.");
        }

        [Test]
        public void CanDeletePersonReturnsFalseWhenPersonIsRelatedToAnythingOtherThanApprovedAuditLogEntries()
        {
            var tenant = Tenant.SitkaTechnologyGroup;
            var organization = HttpRequestStorage.DatabaseEntities.AllOrganizations.First(x => x.TenantID == tenant.TenantID && x.OrganizationShortName == "Sitka");
            var originalOrganizationPrimaryContactPerson = organization.PrimaryContactPerson;
            var person1 = TestFramework.TestPerson.Create(tenant);
            person1.CreateDate = DateTime.Now;
            person1.LoginName = person1.Email;
            person1.Organization = organization;
            person1.PersonGuid = Guid.NewGuid();
            HttpRequestStorage.DatabaseEntities.AllPeople.Add(person1);
            HttpRequestStorage.DatabaseEntities.SaveChanges(person1);

            var person2 = TestFramework.TestPerson.Create(tenant);
            person2.CreateDate = DateTime.Now;
            person2.LoginName = person2.Email;
            person2.Organization = organization;
            person2.PersonGuid = Guid.NewGuid();
            HttpRequestStorage.DatabaseEntities.AllPeople.Add(person2);
            HttpRequestStorage.DatabaseEntities.SaveChanges(person2);

            // person1 sets themselves as a primary contact for an organization
            organization.PrimaryContactPerson = person1;
            HttpRequestStorage.DatabaseEntities.SaveChanges(person1);

            // person2 attempts to delete person1 but can't because they are a primary contact person for an organization
            var person2CanDeletePerson1 = person1.CanDeletePerson(person2);

            // clean up the DB
            organization.PrimaryContactPerson = originalOrganizationPrimaryContactPerson;
            HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(tenant.TenantID);
            person1.DeleteFull(HttpRequestStorage.DatabaseEntities);
            person2.DeleteFull(HttpRequestStorage.DatabaseEntities);
            HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(tenant.TenantID);

            Assert.That(person2CanDeletePerson1, Is.False, "A Person cannot be deleted if they are associated to an object that is not an AuditLog.");
        }


    }
}