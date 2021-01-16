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
            using (var context = new Xrm(orgAdminUIService))
            {
                var contact = new Contact();
                contact.Id = orgAdminUIService.Create(contact);

                /*
                 * JobTitle is set to "Technical Supervisor" in Power Automate flow
                 */
                var retrievedContact = Contact.Retrieve(orgAdminService, contact.Id, c => c.JobTitle);
                
                Assert.IsNotNull(retrievedContact.JobTitle);
                Assert.AreEqual("Technical Supervisor", retrievedContact.JobTitle);
            }
        }
    }
}
