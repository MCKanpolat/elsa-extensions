using System.Text.Json.Serialization;

namespace Elsa.Zendesk.Models;

/// <summary>Represents a Zendesk attachment.</summary>
public class Attachment
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("file_name")] public string? FileName { get; set; }
    [JsonPropertyName("content_url")] public string? ContentUrl { get; set; }
    [JsonPropertyName("content_type")] public string? ContentType { get; set; }
    [JsonPropertyName("size")] public long Size { get; set; }
    [JsonPropertyName("inline")] public bool Inline { get; set; }
    [JsonPropertyName("deleted")] public bool Deleted { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
}

/// <summary>Represents a Zendesk upload token response.</summary>
public class UploadResponse
{
    [JsonPropertyName("upload")] public UploadToken? Upload { get; set; }
}

/// <summary>Represents an upload token returned by Zendesk after a file upload.</summary>
public class UploadToken
{
    [JsonPropertyName("token")] public string? Token { get; set; }
    [JsonPropertyName("expires_at")] public DateTimeOffset? ExpiresAt { get; set; }
    [JsonPropertyName("attachment")] public Attachment? Attachment { get; set; }
    [JsonPropertyName("attachments")] public IList<Attachment>? Attachments { get; set; }
}

