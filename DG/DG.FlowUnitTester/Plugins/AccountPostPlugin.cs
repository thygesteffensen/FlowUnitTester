using DG.FlowUnitTester.BusinessLogic.Managers;
using DG.XrmFramework.BusinessDomain.ServiceContext;

namespace Delegate.DG.FlowUnitTester.Plugins
{
    using System;

    public class AccountPostPlugin : Plugin
    {
        public AccountPostPlugin()
            : base(typeof(AccountPostPlugin))
        {
            RegisterPluginStep<Account>(
                EventOperation.Update,
                ExecutionStage.PostOperation,
                ExecuteAccountPostPlugin);
        }

        protected void ExecuteAccountPostPlugin(LocalPluginContext localContext)
        {
            if (localContext == null)
            {
                throw new ArgumentNullException("localContext");
            }

            var isUpdate = MatchesEventOperation(localContext, EventOperation.Update);

            var accountManager = new ManagerAccount(
                localContext.TracingService,
                localContext.PluginExecutionContext,
                localContext.OrganizationService,
                localContext.OrganizationAdminService);

            accountManager.FooPlugin(localContext.PluginExecutionContext.PrimaryEntityId, isUpdate);
        }
    }
}