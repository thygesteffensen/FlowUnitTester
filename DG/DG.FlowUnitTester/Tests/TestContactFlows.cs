using DG.XrmFramework.BusinessDomain.ServiceContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestContactFlows : TestBase
    {
        [TestMethod]
        public void TestLastNameIsDoe()
        {
            var contact = new Contact {FirstName = "John"};

            contact.Id = OrgAdminService.Create(contact);

            var retrievedContact = Contact.Retrieve(
                OrgAdminService, contact.Id,
                x => x.LastName,
                x => x.JobTitle);


            Assert.IsNotNull(retrievedContact.LastName);
            Assert.IsNotNull(retrievedContact.JobTitle);

            Assert.AreEqual("Doe", retrievedContact.LastName);
            Assert.AreEqual("Test dummy",
                retrievedContact.JobTitle);
        }
    }
}