using Elsa.Testing.Shared;
using Elsa.Zendesk.Activities.Tickets;
using Elsa.Zendesk.Client;
using Elsa.Zendesk.Client.Api;
using Elsa.Zendesk.Models;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit.Abstractions;

namespace Elsa.Zendesk.Tests.Activities.Tickets;

public class TicketActivitiesTests : IAsyncLifetime
{
    private readonly Mock<ITicketsApi> _ticketsApi = new();
    private readonly WorkflowTestFixture _fixture;

    public TicketActivitiesTests(ITestOutputHelper output)
    {
        var client = new Mock<IZendeskClient>();
        client.SetupGet(c => c.Tickets).Returns(_ticketsApi.Object);

        _fixture = new WorkflowTestFixture(output)
            .AddActivitiesFrom<Elsa.Zendesk.Activities.ZendeskActivity>()
            .ConfigureServices(s => s.AddSingleton(client.Object));
    }

    public async Task InitializeAsync() => await _fixture.BuildAsync();
    public Task DisposeAsync() => Task.CompletedTask;

    [Fact]
    public async Task GetTicket_CallsShowTicketWithProvidedId()
    {
        _ticketsApi
            .Setup(a => a.ShowTicketAsync(99L, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ZendeskResponse<Ticket> { Ticket = new() { Id = 99 } });

        var activity = new GetTicket { TicketId = new(99L) };

        await _fixture.RunActivityAsync(activity);

        _ticketsApi.Verify(a => a.ShowTicketAsync(99L, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task ListTickets_PassesPageAndPageSizeToApi()
    {
        _ticketsApi
            .Setup(a => a.ListTicketsAsync(2, 50, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ZendeskListResponse<Ticket>());

        var activity = new ListTickets
        {
            Page = new(2),
            PageSize = new(50)
        };

        await _fixture.RunActivityAsync(activity);

        _ticketsApi.Verify(a => a.ListTicketsAsync(2, 50, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task UpdateTicket_AppendsComment_WhenCommentProvided()
    {
        UpdateTicketRequest? captured = null;
        _ticketsApi
            .Setup(a => a.UpdateTicketAsync(7L, It.IsAny<UpdateTicketRequest>(), It.IsAny<CancellationToken>()))
            .Callback<long, UpdateTicketRequest, CancellationToken>((_, req, _) => captured = req)
            .ReturnsAsync(new ZendeskResponse<Ticket> { Ticket = new() { Id = 7 } });

        var activity = new UpdateTicket
        {
            TicketId = new(7L),
            Subject = new("New subject"),
            Status = new("solved"),
            Priority = new("urgent"),
            AssigneeId = new(1L),
            GroupId = new(2L),
            Comment = new("Adding context"),
            CommentPublic = new(false)
        };

        await _fixture.RunActivityAsync(activity);

        Assert.NotNull(captured);
        Assert.Equal("New subject", captured!.Ticket.Subject);
        Assert.Equal("solved", captured.Ticket.Status);
        Assert.Equal("urgent", captured.Ticket.Priority);
        Assert.Equal(1L, captured.Ticket.AssigneeId);
        Assert.Equal(2L, captured.Ticket.GroupId);
        Assert.NotNull(captured.Ticket.Comment);
        Assert.Equal("Adding context", captured.Ticket.Comment!.Body);
        Assert.False(captured.Ticket.Comment.Public);
    }

    [Fact]
    public async Task UpdateTicket_OmitsComment_WhenCommentIsEmpty()
    {
        UpdateTicketRequest? captured = null;
        _ticketsApi
            .Setup(a => a.UpdateTicketAsync(7L, It.IsAny<UpdateTicketRequest>(), It.IsAny<CancellationToken>()))
            .Callback<long, UpdateTicketRequest, CancellationToken>((_, req, _) => captured = req)
            .ReturnsAsync(new ZendeskResponse<Ticket> { Ticket = new() });

        var activity = new UpdateTicket
        {
            TicketId = new(7L),
            Subject = new("Updated")
        };

        await _fixture.RunActivityAsync(activity);

        Assert.NotNull(captured);
        Assert.Null(captured!.Ticket.Comment);
    }

    [Fact]
    public async Task UpdateTicket_DefaultsCommentPublicToTrue_WhenFlagNotProvided()
    {
        UpdateTicketRequest? captured = null;
        _ticketsApi
            .Setup(a => a.UpdateTicketAsync(7L, It.IsAny<UpdateTicketRequest>(), It.IsAny<CancellationToken>()))
            .Callback<long, UpdateTicketRequest, CancellationToken>((_, req, _) => captured = req)
            .ReturnsAsync(new ZendeskResponse<Ticket> { Ticket = new() });

        var activity = new UpdateTicket
        {
            TicketId = new(7L),
            Comment = new("Default visibility")
        };

        await _fixture.RunActivityAsync(activity);

        Assert.NotNull(captured?.Ticket.Comment);
        Assert.True(captured!.Ticket.Comment!.Public);
    }

    [Fact]
    public async Task DeleteTicket_CallsApiWithProvidedId()
    {
        _ticketsApi
            .Setup(a => a.DeleteTicketAsync(11L, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var activity = new DeleteTicket { TicketId = new(11L) };

        await _fixture.RunActivityAsync(activity);

        _ticketsApi.Verify(a => a.DeleteTicketAsync(11L, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task ListTicketComments_PassesArgumentsAndReturnsResult()
    {
        _ticketsApi
            .Setup(a => a.ListTicketCommentsAsync(5L, 1, 25, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ZendeskListResponse<TicketComment>());

        var activity = new ListTicketComments
        {
            TicketId = new(5L),
            Page = new(1),
            PageSize = new(25)
        };

        await _fixture.RunActivityAsync(activity);

        _ticketsApi.Verify(a => a.ListTicketCommentsAsync(5L, 1, 25, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetTicketMetrics_CallsApiWithProvidedId()
    {
        _ticketsApi
            .Setup(a => a.ShowTicketMetricsAsync(3L, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ZendeskResponse<TicketMetrics> { Ticket = new() });

        var activity = new GetTicketMetrics { TicketId = new(3L) };

        await _fixture.RunActivityAsync(activity);

        _ticketsApi.Verify(a => a.ShowTicketMetricsAsync(3L, It.IsAny<CancellationToken>()), Times.Once);
    }
}
