# Elsa.Zendesk

<details>
  <summary>📖 Table of Contents</summary>
  <ol>
    <li><a href="#overview">Overview</a></li>
    <li><a href="#features">Features</a></li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li>
      <a href="#configuration">Configuration</a>
      <ul>
        <li><a href="#programcs">Program.cs</a></li>
        <li><a href="#appsettings">appsettings.json</a></li>
        <li><a href="#authentication-modes">Authentication Modes</a></li>
      </ul>
    </li>
    <li><a href="#available-activities">Available Activities</a></li>
    <li><a href="#paging">Paging</a></li>
    <li><a href="#examples">Examples</a></li>
    <li><a href="#troubleshooting">Troubleshooting</a></li>
    <li><a href="#notes">Notes & Comments</a></li>
    <li><a href="#references">References</a></li>
  </ol>
</details>

---

## 🧠 Overview

This package extends [Elsa Workflows](https://github.com/elsa-workflows/elsa-core) with full integration for the **Zendesk Support Ticketing API**. It exposes all major Zendesk API resources as Elsa workflow activities, enabling you to automate support operations — creating and updating tickets, managing users, organisations, groups, macros, triggers, views, automations, SLA policies, and much more — directly within your workflow definitions.

Authentication is configured **globally** at startup (no credentials in individual activities), supports both **API token (Basic Auth)** and **OAuth Bearer token** modes, and all list operations expose **pagination** via `Page` / `PageSize` inputs.

---

## ✨ Key Features

- 🎫 Full **Tickets** CRUD — create, read, update, delete, list, search, comments, audits, metrics
- 👤 Full **Users** CRUD — create, read, update, delete, list, search
- 🏢 Full **Organizations** CRUD — create, read, update, delete, list, search
- 👥 **Groups** — create, list, update, memberships, users
- 🤖 **Macros**, **Triggers**, **Trigger Categories**, **Views**, **Automations**
- 🏷️ **SLA Policies**, **Custom Statuses**, **Tags**, **Bookmarks**
- 📎 **Attachments** and **File Uploads**
- 🌐 **Brands**, **Locales**, **Targets**, **Dynamic Content**
- 🔍 Global **Search** across all resource types
- 😊 **Satisfaction Ratings** — list, get, create
- 📋 **Audit Logs**
- ⚙️ **Account Settings**
- 📨 **End-User Requests**
- 🔐 Dual auth: **API token** (Basic Auth) or **OAuth Bearer** token
- 📄 **Pagination** support on all list activities

---

## ⚡ Getting Started

### 📋 Prerequisites

- Elsa Workflows **V3** installed in your project
- A Zendesk account with an API token or OAuth credentials
  - API token: Generate in **Zendesk Admin > Apps and Integrations > Zendesk API**
  - OAuth: Create a client under **Zendesk Admin > Apps and Integrations > OAuth Clients**

### 🛠 Installation

```bash
dotnet add package Elsa.Zendesk
```

---

## ⚙️ Configuration

### Program.cs

Register the Zendesk module in your Elsa builder:

```csharp
using Elsa.Extensions;

services.AddElsa(elsa =>
{
    elsa.UseZendesk(zendesk =>
    {
        zendesk.ConfigureZendeskOptions = options =>
            configuration.GetSection("Zendesk").Bind(options);
    });
});
```

Or configure options inline without `appsettings.json`:

```csharp
services.AddElsa(elsa =>
{
    elsa.UseZendesk(zendesk =>
    {
        zendesk.ConfigureZendeskOptions = options =>
        {
            options.Subdomain = "mycompany";
            options.AuthMode  = ZendeskAuthMode.ApiToken;
            options.Email     = "agent@mycompany.com";
            options.ApiToken  = "your-api-token";
        };
    });
});
```

### appsettings.json

```json
{
  "Zendesk": {
    "Subdomain": "mycompany",
    "AuthMode": "ApiToken",
    "Email": "agent@mycompany.com",
    "ApiToken": "your-zendesk-api-token"
  }
}
```

For **OAuth Bearer** token mode:

```json
{
  "Zendesk": {
    "Subdomain": "mycompany",
    "AuthMode": "OAuthBearer",
    "OAuthToken": "your-oauth-bearer-token"
  }
}
```

### 🔐 Authentication Modes

| Mode | `AuthMode` Value | Required Fields | Header Sent |
|------|-----------------|-----------------|-------------|
| API Token (Basic Auth) | `ApiToken` | `Subdomain`, `Email`, `ApiToken` | `Authorization: Basic base64(email/token:apitoken)` |
| OAuth Bearer | `OAuthBearer` | `Subdomain`, `OAuthToken` | `Authorization: Bearer {token}` |

> 💡 **Tip:** Store sensitive values like `ApiToken` and `OAuthToken` using [Elsa Secrets Management](https://v3.elsaworkflows.io/docs/extensibility/secrets) rather than placing them directly in `appsettings.json`.

---

## 🚀 Available Activities

All activities are grouped under the **Zendesk** category in Elsa Studio and organised by resource type.

### 🎫 Tickets

| Activity | Description |
|----------|-------------|
| `CreateTicket` | Creates a new support ticket |
| `GetTicket` | Retrieves a ticket by ID |
| `ListTickets` | Lists tickets with pagination |
| `UpdateTicket` | Updates subject, status, priority, assignee, or adds a comment |
| `DeleteTicket` | Moves a ticket to trash |
| `ListTicketComments` | Lists comments on a ticket |
| `GetTicketMetrics` | Retrieves reply/resolution time metrics for a ticket |

#### Ticket Inputs (CreateTicket / UpdateTicket)

| Input | Type | Description |
|-------|------|-------------|
| `Subject` | `string` | The ticket subject |
| `CommentBody` | `string` | Body of the initial or update comment |
| `RequesterId` | `long?` | Requester user ID |
| `AssigneeId` | `long?` | Assignee user ID |
| `GroupId` | `long?` | Group ID |
| `Priority` | `string?` | `urgent`, `high`, `normal`, or `low` |
| `Type` | `string?` | `problem`, `incident`, `question`, or `task` |
| `Status` | `string?` | `open`, `pending`, `hold`, `solved`, or `closed` _(UpdateTicket only)_ |

---

### 👤 Users

| Activity | Description |
|----------|-------------|
| `CreateUser` | Creates a new user |
| `GetUser` | Retrieves a user by ID |
| `ListUsers` | Lists users with pagination |
| `SearchUsers` | Searches users by name, email, or other fields |
| `UpdateUser` | Updates user name, email, or role |
| `DeleteUser` | Deletes (suspends) a user |

---

### 🏢 Organizations

| Activity | Description |
|----------|-------------|
| `CreateOrganization` | Creates a new organization |
| `GetOrganization` | Retrieves an organization by ID |
| `ListOrganizations` | Lists organizations with pagination |
| `SearchOrganizations` | Searches organizations |
| `UpdateOrganization` | Updates an organization |
| `DeleteOrganization` | Deletes an organization |

---

### 👥 Groups

| Activity | Description |
|----------|-------------|
| `CreateGroup` | Creates a new group |
| `GetGroup` | Retrieves a group by ID |
| `ListGroups` | Lists groups with pagination |
| `UpdateGroup` | Updates a group |
| `ListGroupUsers` | Lists users that belong to a group |
| `CreateGroupMembership` | Adds a user to a group |
| `DeleteGroupMembership` | Removes a user from a group |

---

### 🤖 Macros

| Activity | Description |
|----------|-------------|
| `CreateMacro` | Creates a new macro |
| `GetMacro` | Retrieves a macro by ID |
| `ListMacros` | Lists macros (optionally filtered by active status) |
| `SearchMacros` | Searches macros by query |
| `UpdateMacro` | Updates a macro |
| `DeleteMacro` | Deletes a macro |

---

### ⚡ Triggers & Trigger Categories

| Activity | Description |
|----------|-------------|
| `CreateTrigger` | Creates a new trigger |
| `ListTriggers` | Lists triggers with pagination |
| `UpdateTrigger` | Updates a trigger |
| `DeleteTrigger` | Deletes a trigger |
| `ListTriggerCategories` | Lists trigger categories |
| `CreateTriggerCategory` | Creates a trigger category |

---

### 👁️ Views

| Activity | Description |
|----------|-------------|
| `CreateView` | Creates a new view |
| `GetView` | Retrieves a view by ID |
| `ListViews` | Lists views with pagination |
| `UpdateView` | Updates a view |
| `DeleteView` | Deletes a view |
| `ListViewTickets` | Lists tickets contained in a view |

---

### 🔄 Automations

| Activity | Description |
|----------|-------------|
| `CreateAutomation` | Creates a new automation |
| `GetAutomation` | Retrieves an automation by ID |
| `ListAutomations` | Lists automations with pagination |
| `UpdateAutomation` | Updates an automation |
| `DeleteAutomation` | Deletes an automation |

---

### 🏷️ Brands

| Activity | Description |
|----------|-------------|
| `CreateBrand` | Creates a new brand |
| `GetBrand` | Retrieves a brand by ID |
| `ListBrands` | Lists brands with pagination |
| `UpdateBrand` | Updates a brand |
| `DeleteBrand` | Deletes a brand |

---

### 📎 Attachments

| Activity | Description |
|----------|-------------|
| `GetAttachment` | Retrieves an attachment by ID |
| `DeleteAttachment` | Deletes an attachment |

---

### 📜 SLA Policies

| Activity | Description |
|----------|-------------|
| `ListSlaPolicies` | Lists all SLA policies |
| `CreateSlaPolicy` | Creates a new SLA policy |
| `GetSlaPolicy` | Retrieves an SLA policy by ID |
| `DeleteSlaPolicy` | Deletes an SLA policy |

---

### 🟢 Custom Ticket Statuses

| Activity | Description |
|----------|-------------|
| `ListCustomStatuses` | Lists custom ticket statuses |
| `CreateCustomStatus` | Creates a custom status |
| `GetCustomStatus` | Retrieves a custom status by ID |
| `UpdateCustomStatus` | Updates a custom status |

---

### 🔍 Search

| Activity | Description |
|----------|-------------|
| `Search` | Searches across all Zendesk resource types using Zendesk query syntax |

**Search query examples:**

```
type:ticket status:open priority:high
type:user email:agent@company.com
type:organization name:"Acme Corp"
```

---

### 😊 Satisfaction Ratings

| Activity | Description |
|----------|-------------|
| `ListSatisfactionRatings` | Lists satisfaction ratings (filterable by score) |
| `GetSatisfactionRating` | Retrieves a satisfaction rating by ID |
| `CreateSatisfactionRating` | Creates a satisfaction rating for a ticket |

---

### 📋 Audit Logs

| Activity | Description |
|----------|-------------|
| `ListAuditLogs` | Lists audit log entries with pagination |
| `GetAuditLog` | Retrieves an audit log entry by ID |

---

### ⚙️ Account Settings

| Activity | Description |
|----------|-------------|
| `GetAccountSettings` | Retrieves the account settings |
| `UpdateAccountSettings` | Updates account settings |

---

### 🏷️ Tags

| Activity | Description |
|----------|-------------|
| `ListTags` | Lists all tags used in the account |

---

### 📌 Bookmarks

| Activity | Description |
|----------|-------------|
| `ListBookmarks` | Lists bookmarks |
| `CreateBookmark` | Bookmarks a ticket |
| `DeleteBookmark` | Removes a bookmark |

---

### 🌐 Dynamic Content

| Activity | Description |
|----------|-------------|
| `ListDynamicContentItems` | Lists dynamic content items |
| `CreateDynamicContentItem` | Creates a dynamic content item |
| `GetDynamicContentItem` | Retrieves a dynamic content item by ID |
| `DeleteDynamicContentItem` | Deletes a dynamic content item |

---

### 🌍 Locales

| Activity | Description |
|----------|-------------|
| `ListLocales` | Lists available locales |
| `GetLocale` | Retrieves a locale by ID |

---

### 🎯 Targets

| Activity | Description |
|----------|-------------|
| `ListTargets` | Lists outbound notification targets |
| `DeleteTarget` | Deletes a target |

---

### 📨 End-User Requests

| Activity | Description |
|----------|-------------|
| `ListRequests` | Lists end-user requests |
| `CreateRequest` | Creates a new end-user request |
| `GetRequest` | Retrieves a request by ID |
| `SearchRequests` | Searches end-user requests |

---

## 📄 Paging

All `List*` and `Search*` activities support pagination through two optional inputs:

| Input | Type | Description | Default |
|-------|------|-------------|---------|
| `Page` | `int?` | Page number (1-based) | Zendesk API default (page 1) |
| `PageSize` | `int?` | Number of results per page (max 100) | Zendesk API default (100) |

All paged activities return a `ZendeskListResponse<T>` output that includes:

| Field | Description |
|-------|-------------|
| `Count` | Total number of matching records |
| `NextPage` | URL of the next page (or `null` if no more pages) |
| `PreviousPage` | URL of the previous page |
| `Tickets` / `Users` / `Organizations` / `Results` / … | The items for this page (property name depends on resource type) |

---

## 🧪 Examples

### Create a ticket and post a follow-up comment

```csharp
public class CreateAndUpdateTicketWorkflow : IWorkflow
{
    public void Build(IWorkflowBuilder builder)
    {
        builder
            .StartWith<CreateTicket>(activity =>
            {
                activity.Subject     = new Input<string>("Billing issue reported");
                activity.CommentBody = new Input<string>("Customer reported an unexpected charge.");
                activity.Priority    = new Input<string?>("high");
                activity.Type        = new Input<string?>("problem");
            })
            .Then<UpdateTicket>(activity =>
            {
                activity.TicketId      = new JavaScriptValue<long>("return createTicket.ticket.id;");
                activity.Status        = new Input<string?>("pending");
                activity.Comment       = new Input<string?>("Escalated to billing team.");
                activity.CommentPublic = new Input<bool?>(false);
            });
    }
}
```

### Search for open high-priority tickets

Use the `Search` activity with a Zendesk query string:

```
type:ticket status:open priority:high assignee:me
```

The output `Result` contains a `ZendeskListResponse<SearchResult>` with matching records.

### List tickets page by page

```csharp
.StartWith<ListTickets>(activity =>
{
    activity.Page     = new Input<int?>(1);
    activity.PageSize = new Input<int?>(50);
})
```

Check `result.NextPage` in a subsequent step to determine whether more pages exist, and increment `Page` accordingly.

---

## 🆘 Troubleshooting

### `401 Unauthorized`

- Verify `Subdomain`, `Email`, and `ApiToken` are correct.
- For API token auth, ensure the token was generated (not the account password) under **Zendesk Admin > Apps and Integrations > Zendesk API**.
- For OAuth auth, verify the Bearer token is valid and not expired.

### `403 Forbidden`

- The authenticated agent may lack permission for the requested operation (e.g., accessing audit logs requires admin role).

### `404 Not Found`

- Double-check the resource ID passed to the activity.
- Ensure the resource exists and hasn't been deleted.

### `422 Unprocessable Entity`

- The request body is missing required fields or contains invalid values.
- Review the activity inputs — for example, `CreateTicket` requires both `Subject` and `CommentBody`.

### Activities not visible in Elsa Studio

- Confirm `UseZendesk(...)` is called inside `AddElsa(...)` in `Program.cs`.
- Rebuild and restart the server to pick up the newly registered activities.

---

## 🗒️ Notes & Comments

- **No per-activity credentials**: Authentication is configured globally via `ZendeskOptions`. Credentials are **never** embedded in individual workflow activities or definitions.
- **Naming conventions**: Two Zendesk model types were renamed to avoid collisions with built-in Elsa types — `Bookmark` → `ZendeskBookmark` and `Trigger` → `ZendeskTrigger`.
- **Rate limiting**: The Zendesk API enforces rate limits (typically 700 requests/minute for Enterprise plans). For high-volume workflows, consider adding delays between bulk operations.
- **Paged results**: All `List*` activities return the full `ZendeskListResponse<T>` object so you can inspect `NextPage` and drive cursor-based iteration in your workflow logic.

---

## 📚 References

- [Zendesk API Reference](https://developer.zendesk.com/api-reference/)
- [Zendesk Authentication](https://developer.zendesk.com/documentation/ticketing/working-with-oauth/creating-and-using-oauth-tokens-with-the-api/)
- [Zendesk Rate Limits](https://developer.zendesk.com/documentation/ticketing/managing-tickets/rate-limits/)
- [Elsa Workflows Documentation](https://v3.elsaworkflows.io/)
- [Refit — Type-safe REST clients for .NET](https://github.com/reactiveui/refit)

