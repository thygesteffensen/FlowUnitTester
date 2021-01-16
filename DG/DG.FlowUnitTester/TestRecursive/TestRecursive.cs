using System;
using DG.XrmFramework.BusinessDomain.ServiceContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;

namespace TestRecursive
{
    [TestClass]
    public class TestRecursive : TestBaseRecursive
    {
        [TestMethod]
        public void Test()
        {
            var contact = new Entity("contact") {["firstname"] = "Micheal"};

            contact.Id = orgAdminService.Create(contact);
            
            Assert.ThrowsException<AggregateException>(() =>
                orgAdminService.Update(new Contact(contact.Id) {Attributes = {["lastname"] = "Die"}}));
        }
    }
}