using Elsa.Zendesk.Client;
using Elsa.Workflows;

namespace Elsa.Zendesk.Activities;

/// <summary>
/// Base class for all Zendesk activities. Auth is configured globally via <c>ZendeskOptions</c>.
/// </summary>
public abstract class ZendeskActivity : Activity
{
    /// <summary>Gets the <see cref="IZendeskClient"/> from the DI container.</summary>
    protected IZendeskClient GetClient(ActivityExecutionContext context) =>
        context.GetRequiredService<IZendeskClient>();
}

