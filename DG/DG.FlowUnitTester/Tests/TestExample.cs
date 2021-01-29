using DG.XrmFramework.BusinessDomain.ServiceContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestExample : TestBase
    {
        [TestMethod]
        public void TestPrimaryContactIsCreated()
        {
            using (var context = new Xrm(OrgAdminUiService))
            {
                var contact = new Contact();
                contact.Id = OrgAdminUiService.Create(contact);

                /*
                 * JobTitle is set to "Test dummy" in Power Automate flow
                 */
                var retrievedContact = Contact.Retrieve(OrgAdminService, contact.Id, c => c.JobTitle);
                
                Assert.IsNotNull(retrievedContact.JobTitle);
                Assert.AreEqual("Test dummy", retrievedContact.JobTitle);
            }
        }
    }
}
