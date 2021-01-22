using System;
using System.Collections.Generic;
using DG.Tools.XrmMockup;
using IXrmMockupExtension;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using PAMU_CDS;
using Parser;

namespace TestRecursive
{
    [TestClass]
    public class TestBaseRecursive
    {
        protected IOrganizationService orgAdminUIService;
        protected IOrganizationService orgAdminService;
        protected static XrmMockup365 crm;
        static XrmMockupCdsTrigger _pamuCds;

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
            var services = new ServiceCollection();
            services.AddFlowRunner();
            services.AddPamuCds();

            var sp = services.BuildServiceProvider();

            var flowFolderPath =
                new Uri(System.IO.Path.GetFullPath(@"Workflows"));

            _pamuCds = sp.GetRequiredService<XrmMockupCdsTrigger>();
            _pamuCds.AddFlows(flowFolderPath);
            
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