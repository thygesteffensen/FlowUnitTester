using System;
using System.Collections.Generic;
using DG.Tools.XrmMockup;
using IXrmMockupExtension;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using PAMU_CDS;
using Parser;

namespace Tests
{
    [TestClass]
    public class TestBase
    {
        protected IOrganizationService orgAdminUIService;
        protected IOrganizationService orgAdminService;
        protected static XrmMockup365 crm;
        static XrmMockupCdsTrigger _pamuCds;

        public TestBase()
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
            
            // This stops the recursion or bad flow from running
            services.Configure<CdsFlowSettings>(x =>
                x.DontExecuteFlows = new[] {"Recursiveflow-Contact-CB0D4934-F754-EB11-A812-000D3AB11E51"});

            var sp = services.BuildServiceProvider();

            var flowFolderPath =
                new Uri(System.IO.Path.GetFullPath(@"Workflows"));

            _pamuCds = sp.GetRequiredService<XrmMockupCdsTrigger>();
            _pamuCds.AddFlows(flowFolderPath);
            
            // _pamuCds =
                // new CommonDataServiceCurrentEnvironment(flowFolderPath, sp);

            InitializeMockup(context);
        }

        public static void InitializeMockup(TestContext context)
        {
            crm = XrmMockup365.GetInstance(new XrmMockupSettings
            {
                BasePluginTypes = new[]
                {
                    typeof(Delegate.DG.FlowUnitTester.Plugins.Plugin)
                },
                CodeActivityInstanceTypes = new Type[] { },
                EnableProxyTypes = true,
                IncludeAllWorkflows = true,
                MockUpExtensions = 
                    new List<IMockUpExtension> {_pamuCds}
            });
        }
    }
}