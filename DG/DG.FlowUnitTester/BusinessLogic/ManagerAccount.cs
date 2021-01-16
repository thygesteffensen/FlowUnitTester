using System;
using System.Linq;
using DG.XrmFramework.BusinessDomain.ServiceContext;
using Microsoft.Xrm.Sdk;
using HBD = DG.FlowUnitTester.BusinessLogic.Helpers.HelperBusinessDomain;
using HP = DG.FlowUnitTester.BusinessLogic.Helpers.HelperPlugin;
using HU = DG.FlowUnitTester.BusinessLogic.Helpers.HelperUtils;
using Microsoft.Xrm.Sdk.Workflow;

namespace DG.FlowUnitTester.BusinessLogic.Managers
{
    public class ManagerAccount : ManagerBase
    {
        #region Constructors

        public ManagerAccount(
            ITracingService pluginTracingService,
            IPluginExecutionContext pluginExecutionContext,
            IOrganizationService pluginOrgService,
            IOrganizationService pluginOrgAdminService)
            : base(pluginTracingService, pluginExecutionContext,
                pluginOrgService, pluginOrgAdminService)
        {
        }

        public ManagerAccount(
            ITracingService tracingService,
            IWorkflowContext workflowExecutionContext,
            IOrganizationService orgService,
            IOrganizationService orgAdminService)
            : base(tracingService, workflowExecutionContext,
                orgService, orgAdminService)
        {
        }

        public ManagerAccount(
            ITracingService tracingService,
            IOrganizationService orgService,
            IOrganizationService orgAdminService)
            : base(tracingService, orgService, orgAdminService)
        {
        }

        #endregion


        public void FooPlugin(Guid primaryEntityId, bool isUpdate)
        {
            using (var context = new Xrm(this.orgService))
            {
                var acc = new Account();
                var account = context.AccountSet.FirstOrDefault();
                throw new NotImplementedException();
            }
        }

        public Guid BarWorkflow(Guid accountId)
        {
            throw new NotImplementedException();
        }
    }
}