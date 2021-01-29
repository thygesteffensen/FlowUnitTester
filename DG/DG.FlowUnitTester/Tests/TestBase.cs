using System;
using System.Collections.Generic;
using DG.Tools.XrmMockup;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using PAMU_CDS;
using Parser;
using Tests.CustomActionExecutors;

namespace Tests
{
    [TestClass]
    public class TestBase
    {
        protected readonly IOrganizationService OrgAdminUiService;
        protected readonly IOrganizationService OrgAdminService;
        private static XrmMockup365 _crm;
        private static XrmMockupCdsTrigger _pamuCds;

        public TestBase()
        {
            OrgAdminUiService =
                _crm.GetAdminService(new MockupServiceSettings(true, false, MockupServiceSettings.Role.UI));
            OrgAdminService = _crm.GetAdminService();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _crm.ResetEnvironment();
        }


        [AssemblyInitialize]
        public static void InitializeServices(TestContext context)
        {
            var services = new ServiceCollection();
            services.AddFlowRunner();
            services.AddPamuCds();

            services.AddFlowActionByName<GetEmailFromMarketing>("Run_a_Child_Flow");
            
            // This stops the recursion or bad flow from running
            services.Configure<CdsFlowSettings>(x =>
                x.DontExecuteFlows = new[] {"Recursiveflow-Contact-CB0D4934-F754-EB11-A812-000D3AB11E51.json"});

            var sp = services.BuildServiceProvider();

            var flowFolderPath =
                new Uri(System.IO.Path.GetFullPath(@"Workflows"));

            _pamuCds = sp.GetRequiredService<XrmMockupCdsTrigger>();
            _pamuCds.AddFlows(flowFolderPath);
            
            InitializeMockup(context);
        }

        public static void InitializeMockup(TestContext context)
        {
            _crm = XrmMockup365.GetInstance(new XrmMockupSettings
            {
                BasePluginTypes = new[]
                {
                    typeof(Delegate.DG.FlowUnitTester.Plugins.Plugin)
                },
                CodeActivityInstanceTypes = new Type[] { },
                EnableProxyTypes = true,
                IncludeAllWorkflows = true,
                MockUpExtensions = 
                    new List<DG.Tools.XrmMockup.IXrmMockupExtension> {_pamuCds}
            });
        }
    }
}