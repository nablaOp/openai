using System.Text.Json.Serialization;
using OpenAI.ObjectModels.SharedModels;

namespace OpenAI.ObjectModels.ResponseModels;

public record OpenAiDeleteResponse
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    
    [JsonPropertyName("object")] public string Object { get; set; } = string.Empty;
    
    [JsonPropertyName("deleted")] public bool Deleted { get; set; }
}

public record AssistantTool
{
    [JsonPropertyName("type")] 
    public string? Type { get; set; }
    
    //TODO: functions
}

public record OpenAiObject : IOpenAiModels.IId, IOpenAiModels.ICreatedAt
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    
    [JsonPropertyName("object")] public string Object { get; set; } = string.Empty;
    
    [JsonPropertyName("created_at")] public int CreatedAt { get; set; }
}

public record AssistantObjectBase
{
    [JsonPropertyName("model")] public string Model { get; set; } = string.Empty;
    
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("description")] public string Description { get; set; } = string.Empty;
    
    [JsonPropertyName("instructions")] public string Instructions { get; set; } = string.Empty;
    
    [JsonPropertyName("tools")] public List<AssistantTool>? Tools { get; set; }
    
    [JsonPropertyName("file_ids")] public List<string>? FileIds { get; set; }
    
    [JsonPropertyName("metadata")] public Dictionary<string, string>? Metadata { get; set; }
}

public record AssistantObject : AssistantObjectBase, IOpenAiModels.IId, IOpenAiModels.ICreatedAt
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    
    [JsonPropertyName("object")] public string Object { get; set; } = string.Empty;
    
    [JsonPropertyName("created_at")] public int CreatedAt { get; set; }
}

public record AssistantCreateRequest : AssistantObjectBase;

public record AssistantCreateResponse : AssistantObject;

public record AssistantRetrieveResponse : AssistantObject;

public record AssistantModifyRequest : AssistantObjectBase;

public record AssistantModifyResponse : AssistantObject;

public record AssistantDeleteResponse : OpenAiDeleteResponse;

public record AssistantListResponse : DataListBaseResponse<AssistantObject>;

public record AssistantFileObject : IOpenAiModels.IId, IOpenAiModels.ICreatedAt
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    
    [JsonPropertyName("object")] public string Object { get; set; } = string.Empty;
    
    [JsonPropertyName("created_at")] public int CreatedAt { get; set; }     
}

public record AssistantFileCreateResponse : AssistantFileObject;

public record AssistantFileRetrieveResponse : AssistantFileObject;

public record AssistantFileDeleteResponse : OpenAiDeleteResponse;

public record AssistantFileListResponse : DataListBaseResponse<AssistantFileObject>;

public record ThreadMessageBase
{
    [JsonPropertyName("role")] public string Role { get; set; } = string.Empty;
    
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;
    
    [JsonPropertyName("file_ids")] public List<string>? FileIds { get; set; }
    
    [JsonPropertyName("metadata")] public Dictionary<string, string>? Metadata { get; set; }
}

public record ThreadMessageObject : ThreadMessageBase, IOpenAiModels.IId, IOpenAiModels.ICreatedAt
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    
    [JsonPropertyName("object")] public string Object { get; set; } = string.Empty;
    
    [JsonPropertyName("created_at")] public int CreatedAt { get; set; }
    
    [JsonPropertyName("thread_id")] public string ThreadId { get; set; } = string.Empty;
    
    [JsonPropertyName("assistant_id")] public string AssistantId { get; set; } = string.Empty;
    
    [JsonPropertyName("run_id")] public string RunId { get; set; } = string.Empty;
}

public record ThreadMessageCreateRequest : ThreadMessageBase;

public record ThreadMessageCreateResponse : ThreadMessageObject;

public record ThreadMessageRetrieveResponse : ThreadMessageObject;

public record ThreadMessageModifyRequest
{
    [JsonPropertyName("metadata")] public Dictionary<string, string>? Metadata { get; set; }
}

public record ThreadMessageModifyResponse : ThreadMessageObject;

public record ThreadMessageListResponse : DataListBaseResponse<ThreadMessageObject>;

public record ThreadMessageFileObject : AssistantFileObject
{
    [JsonPropertyName("message_id")] public string MessageId { get; set; } = string.Empty;
}

public record ThreadMessageRetrieveFileResponse : ThreadMessageFileObject;

public record ThreadMessageListFileResponse : DataListBaseResponse<ThreadMessageFileObject>;

public record ThreadObjectBase
{
    [JsonPropertyName("messages")] public List<ThreadMessageBase>? Messages { get; set; }
    
    [JsonPropertyName("metadata")] public Dictionary<string, string>? Metadata { get; set; }
}

public record ThreadObject : IOpenAiModels.IId, IOpenAiModels.ICreatedAt
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    
    [JsonPropertyName("object")] public string Object { get; set; } = string.Empty;
    
    [JsonPropertyName("created_at")] public int CreatedAt { get; set; }
    
    [JsonPropertyName("metadata")] public Dictionary<string, string>? Metadata { get; set; }
}

public record ThreadCreateRequest : ThreadObjectBase;

public record ThreadCreateResponse : ThreadObject;

public record ThreadRetrieveResponse : ThreadObject;

public record ThreadModifyRequest
{
    [JsonPropertyName("metadata")] public Dictionary<string, string>? Metadata { get; set; }
}

public record ThreadModifyResponse : ThreadObject;

public record ThreadDeleteResponse : OpenAiDeleteResponse;

public record ThreadRunObjectBase
{
    [JsonPropertyName("assistant_id")] public string AssistantId { get; set; } = string.Empty;
    
    [JsonPropertyName("model")] public string Model { get; set; } = string.Empty;
    
    [JsonPropertyName("instructions")] public string Instructions { get; set; } = string.Empty;
    
    [JsonPropertyName("tools")] public List<AssistantTool>? Tools { get; set; }
    
    [JsonPropertyName("metadata")] public Dictionary<string, string>? Metadata { get; set; }
}

public record ThreadRunObject : ThreadRunObjectBase, IOpenAiModels.IId, IOpenAiModels.ICreatedAt
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    
    [JsonPropertyName("object")] public string Object { get; set; } = string.Empty;
    
    [JsonPropertyName("created_at")] public int CreatedAt { get; set; }
    
    [JsonPropertyName("thread_id")] public string ThreadId { get; set; } = string.Empty;
    
    [JsonPropertyName("status")] public string Status { get; set; } = string.Empty;
    
    [JsonPropertyName("required_action")] public string RequiredAction { get; set; } = string.Empty;
    
    [JsonPropertyName("last_error")] public string? LastError { get; set; }
    
    [JsonPropertyName("expires_at")] public int ExpiresAt { get; set; }
    
    [JsonPropertyName("started_at")] public int? StartedAt { get; set; }
    
    [JsonPropertyName("cancelled_at")] public int? CancelledAt { get; set; }
    
    [JsonPropertyName("completed_at")] public int? CompletedAt { get; set; }
    
    [JsonPropertyName("file_ids")] public List<string>? FileIds { get; set; }
}

public record ThreadRunCreateRequest : ThreadRunObjectBase;

public record ThreadRunCreateResponse : ThreadRunObject;

public record ThreadRunRetrieveResponse : ThreadRunObject;

public record ThreadRunModifyRequest
{
    [JsonPropertyName("metadata")] public Dictionary<string, string>? Metadata { get; set; }
}

public record ThreadRunModifyResponse : ThreadRunObject;

public record ThreadRunListResponse : DataListBaseResponse<ThreadRunObject>;

// TODO: tools outputs to run 

public record ThreadRunCancelResponse : ThreadRunObject;

public record ThreadAndRunCreateRequest : ThreadRunObjectBase
{
    [JsonPropertyName("thread")] public ThreadObjectBase Thread { get; set; } = new();
}

public record ThreadRunStepObject : IOpenAiModels.IId, IOpenAiModels.ICreatedAt
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    
    [JsonPropertyName("object")] public string Object { get; set; } = string.Empty;
    
    [JsonPropertyName("created_at")] public int CreatedAt { get; set; }
    
    [JsonPropertyName("assistant_id")] public string AssistantId { get; set; } = string.Empty;
    
    [JsonPropertyName("thread_id")] public string ThreadId { get; set; } = string.Empty;
    
    [JsonPropertyName("run_id")] public string RunId { get; set; } = string.Empty;
    
    [JsonPropertyName("type")] public string Type { get; set; } = string.Empty;
    
    [JsonPropertyName("step_details")] public string StepDetails { get; set; } = string.Empty;
    
    [JsonPropertyName("last_error")] public string? LastError { get; set; }
    
    [JsonPropertyName("expires_at")] public int ExpiresAt { get; set; }
    
    [JsonPropertyName("cancelled_at")] public int? CancelledAt { get; set; }
    
    [JsonPropertyName("failed_at")] public int? FailedAt { get; set; }
    
    [JsonPropertyName("completed_at")] public int? CompletedAt { get; set; }
    
    [JsonPropertyName("metadata")] public Dictionary<string, string>? Metadata { get; set; }
}

public record ThreadRunStepRetrieveResponse : ThreadRunStepObject;

public record ThreadRunStepListResponse : DataListBaseResponse<ThreadRunStepObject>;