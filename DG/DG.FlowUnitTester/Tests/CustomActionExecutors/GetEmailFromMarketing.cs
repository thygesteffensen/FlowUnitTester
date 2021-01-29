using System.Collections.Generic;
using System.Threading.Tasks;
using Parser.ExpressionParser;
using Parser.FlowParser.ActionExecutors;

namespace Tests.CustomActionExecutors
{
    public class GetEmailFromMarketing : DefaultBaseActionExecutor
    {
        public override Task<ActionResult> Execute()
        {
            return Task.FromResult(new ActionResult
            {
                ActionStatus = ActionStatus.Succeeded,
                ActionOutput = new ValueContainer(new Dictionary<string, ValueContainer>
                {
                    {
                        "Body", new ValueContainer(new Dictionary<string, ValueContainer>
                        {
                            {"email", new ValueContainer("somer@andom.mail")}
                        })
                    }
                })
            });
        }
    }
}