using Elsa.Testing.Shared;
using Elsa.Zendesk.Activities.Tickets;
using Elsa.Zendesk.Client;
using Elsa.Zendesk.Client.Api;
using Elsa.Zendesk.Models;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit.Abstractions;

namespace Elsa.Zendesk.Tests.Activities.Tickets;

public class CreateTicketTests : IAsyncLifetime
{
    private readonly Mock<ITicketsApi> _ticketsApi = new();
    private readonly WorkflowTestFixture _fixture;

    public CreateTicketTests(ITestOutputHelper output)
    {
        var client = new Mock<IZendeskClient>();
        client.SetupGet(c => c.Tickets).Returns(_ticketsApi.Object);

        _fixture = new WorkflowTestFixture(output)
            .AddActivitiesFrom<Elsa.Zendesk.Activities.ZendeskActivity>()
            .ConfigureServices(s => s.AddSingleton(client.Object));
    }

    public async Task InitializeAsync() => await _fixture.BuildAsync();
    public Task DisposeAsync() => Task.CompletedTask;

    [Fact(DisplayName = "Calls Tickets API with the configured inputs and sets the created ticket as output")]
    public async Task ExecuteAsync_PassesInputsToApiAndSetsOutput()
    {
        CreateTicketRequest? captured = null;
        var created = new Ticket { Id = 42, Subject = "Hello" };

        _ticketsApi
            .Setup(a => a.CreateTicketAsync(It.IsAny<CreateTicketRequest>(), It.IsAny<CancellationToken>()))
            .Callback<CreateTicketRequest, CancellationToken>((req, _) => captured = req)
            .ReturnsAsync(new ZendeskResponse<Ticket> { Ticket = created });

        var activity = new CreateTicket
        {
            Subject = new("Hello"),
            CommentBody = new("World"),
            RequesterId = new(123L),
            AssigneeId = new(456L),
            GroupId = new(789L),
            Priority = new("high"),
            TicketType = new("question")
        };

        await _fixture.RunActivityAsync(activity);

        _ticketsApi.Verify(a => a.CreateTicketAsync(It.IsAny<CreateTicketRequest>(), It.IsAny<CancellationToken>()), Times.Once);

        Assert.NotNull(captured);
        Assert.Equal("Hello", captured!.Ticket.Subject);
        Assert.Equal("World", captured.Ticket.Comment?.Body);
        Assert.Equal(123L, captured.Ticket.RequesterId);
        Assert.Equal(456L, captured.Ticket.AssigneeId);
        Assert.Equal(789L, captured.Ticket.GroupId);
        Assert.Equal("high", captured.Ticket.Priority);
        Assert.Equal("question", captured.Ticket.Type);
    }

    [Fact(DisplayName = "Omits optional inputs when not provided")]
    public async Task ExecuteAsync_OmitsOptionalInputs()
    {
        CreateTicketRequest? captured = null;
        _ticketsApi
            .Setup(a => a.CreateTicketAsync(It.IsAny<CreateTicketRequest>(), It.IsAny<CancellationToken>()))
            .Callback<CreateTicketRequest, CancellationToken>((req, _) => captured = req)
            .ReturnsAsync(new ZendeskResponse<Ticket> { Ticket = new() });

        var activity = new CreateTicket
        {
            Subject = new("Subject only"),
            CommentBody = new("Body only")
        };

        await _fixture.RunActivityAsync(activity);

        Assert.NotNull(captured);
        Assert.Equal("Subject only", captured!.Ticket.Subject);
        Assert.Equal("Body only", captured.Ticket.Comment?.Body);
        Assert.Null(captured.Ticket.RequesterId);
        Assert.Null(captured.Ticket.AssigneeId);
        Assert.Null(captured.Ticket.GroupId);
        Assert.Null(captured.Ticket.Priority);
        Assert.Null(captured.Ticket.Type);
    }
}
