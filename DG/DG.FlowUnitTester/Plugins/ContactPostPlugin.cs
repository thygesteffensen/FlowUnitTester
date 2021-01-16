using DG.XrmFramework.BusinessDomain.ServiceContext;
using Microsoft.Xrm.Sdk;

namespace Delegate.DG.FlowUnitTester.Plugins
{
    public class ContactPostPlugin : Plugin
    {
        public ContactPostPlugin() : base(typeof(ContactPostPlugin))
        {
            // RegisterPluginStep<Contact>(
            //     EventOperation.Update,
            //     ExecutionStage.PostOperation,
            //     RecursivePlugin);
        }

        protected void RecursivePlugin(LocalPluginContext localContext)
        {
            var contact = ((Entity) localContext.PluginExecutionContext.InputParameters["Target"]).ToEntity<Contact>();

            localContext.OrganizationService.Update(new Entity(contact.LogicalName, contact.Id) {["firstname"] = "John"});
        }
    }
}