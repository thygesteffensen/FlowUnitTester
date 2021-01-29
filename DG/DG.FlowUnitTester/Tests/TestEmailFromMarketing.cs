using DG.XrmFramework.BusinessDomain.ServiceContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestEmailFromMarketing : TestBase
    {
        [TestMethod]
        public void TestMarketingEmail()
        {
            var contact = new Contact();
            contact.Id = OrgAdminService.Create(contact);

            var retContact = Contact.Retrieve(OrgAdminService, contact.Id, x => x.EMailAddress1);
            
            Assert.IsNotNull(retContact.EMailAddress1);
            Assert.AreEqual("somer@andom.mail", retContact.EMailAddress1);
        }
    }
}