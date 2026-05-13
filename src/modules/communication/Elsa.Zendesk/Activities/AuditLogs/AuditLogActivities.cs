using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.AuditLogs;

[Activity("Elsa.Zendesk.AuditLogs", "Zendesk Audit Logs", "Lists audit log entries.", DisplayName = "List Audit Logs")]
[UsedImplicitly]
public class ListAuditLogs : ZendeskActivity
{
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of audit logs.")] public Output<ZendeskListResponse<AuditLog>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).AuditLogs.ListAuditLogsAsync(context.Get(Page), context.Get(PageSize), context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.AuditLogs", "Zendesk Audit Logs", "Gets an audit log entry by ID.", DisplayName = "Get Audit Log")]
[UsedImplicitly]
public class GetAuditLog : ZendeskActivity
{
    [Input(Description = "The ID of the audit log entry.")] public Input<long> AuditLogId { get; set; } = null!;
    [Output(Description = "The audit log entry.")] public Output<AuditLog?> AuditLog { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).AuditLogs.ShowAuditLogAsync(context.Get(AuditLogId), context.CancellationToken);
        context.Set(AuditLog, response.AuditLog);
    }
}

