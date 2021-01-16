using System;
using System.Collections.Generic;
using DG.Tools.XrmMockup;
using IXrmMockupExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using PAMU_CDS;

namespace TestRecursive
{
    [TestClass]
    public class TestBaseRecursive
    {
        protected IOrganizationService orgAdminUIService;
        protected IOrganizationService orgAdminService;
        protected static XrmMockup365 crm;
        static CommonDataServiceCurrentEnvironment _pamuCds;

        public TestBaseRecursive()
        {
            orgAdminUIService =
                crm.GetAdminService(new MockupServiceSettings(true, false, MockupServiceSettings.Role.UI));
            orgAdminService = crm.GetAdminService();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            crm.ResetEnvironment();
        }


        [AssemblyInitialize]
        public static void InitializeServices(TestContext context)
        {
            var flowFolderPath = new Uri(System.IO.Path.GetFullPath(@"Workflows"));
            _pamuCds = new CommonDataServiceCurrentEnvironment(flowFolderPath);

            // Figure out how to get all json

            InitializeMockup(context);
        }

        public static void InitializeMockup(TestContext context)
        {
            crm = XrmMockup365.GetInstance(new XrmMockupSettings
            {
                BasePluginTypes = new[] {typeof(Delegate.DG.FlowUnitTester.Plugins.Plugin)},
                CodeActivityInstanceTypes = new Type[] { },
                EnableProxyTypes = true,
                IncludeAllWorkflows = true,
                MockUpExtensions = new List<IMockUpExtension> {_pamuCds}
            });
        }
    }
}