using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Attachments;

[Activity("Elsa.Zendesk.Attachments", "Zendesk Attachments", "Gets an attachment by ID.", DisplayName = "Get Attachment")]
[UsedImplicitly]
public class GetAttachment : ZendeskActivity
{
    [Input(Description = "The ID of the attachment.")] public Input<long> AttachmentId { get; set; } = null!;
    [Output(Description = "The attachment.")] public Output<Attachment?> Attachment { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).Attachments.ShowAttachmentAsync(context.Get(AttachmentId), context.CancellationToken);
        context.Set(Attachment, response.Attachment);
    }
}

[Activity("Elsa.Zendesk.Attachments", "Zendesk Attachments", "Deletes an attachment.", DisplayName = "Delete Attachment")]
[UsedImplicitly]
public class DeleteAttachment : ZendeskActivity
{
    [Input(Description = "The ID of the attachment to delete.")] public Input<long> AttachmentId { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context) =>
        await GetClient(context).Attachments.DeleteAttachmentAsync(context.Get(AttachmentId), context.CancellationToken);
}

