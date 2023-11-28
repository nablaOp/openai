using OpenAI.ObjectModels.ResponseModels;

namespace OpenAI.Interfaces;

public interface IAssistantService
{
    Task<AssistantResponse> CreateAssistant(AssistantCreateRequest request, string? modelId = null, CancellationToken cancellationToken = default);
    
    Task<AssistantResponse> RetrieveAssistant(string assistantId, CancellationToken cancellationToken = default);

    Task<AssistantResponse> ModifyAssistant(string assistantId, AssistantModifyRequest request, CancellationToken cancellationToken = default);
    
    Task<AssistantResponse> DeleteAssistant(string assistantId, CancellationToken cancellationToken = default);
    
    Task<AssistantListResponse> ListAssistants(CancellationToken cancellationToken = default);
}

public interface IThreadService
{
    Task<ThreadResponse> CreateThread(ThreadCreateRequest request, string? modelId = null, CancellationToken cancellationToken = default);
    
    Task<ThreadResponse> RetrieveThread(string threadId, CancellationToken cancellationToken = default);

    Task<ThreadResponse> ModifyThread(string threadId, ThreadModifyRequest request, CancellationToken cancellationToken = default);
    
    Task<ThreadResponse> DeleteThread(string threadId, CancellationToken cancellationToken = default);
}

public interface IMessageService
{
    Task<MessageResponse> CreateMessage(MessageCreateRequest request, string? modelId = null, CancellationToken cancellationToken = default);
    
    Task<MessageResponse> RetrieveMessage(string messageId, CancellationToken cancellationToken = default);

    Task<MessageResponse> ModifyMessage(string messageId, MessageModifyRequest request, CancellationToken cancellationToken = default);
    
    Task<MessageListResponse> ListMessages(CancellationToken cancellationToken = default);
    
    Task<MessageFileResponse> RetrieveMessageFile(string messageId, CancellationToken cancellationToken = default);
    
    Task<MessageFileListResponse> ListMessageFiles(CancellationToken cancellationToken = default);
}

public interface IRunService
{
    Task<RunResponse> CreateRun(RunCreateRequest request, string? modelId = null,
        CancellationToken cancellationToken = default);

    Task<RunResponse> RetrieveRun(string runId, CancellationToken cancellationToken = default);

    Task<RunResponse> ModifyRun(string runId, RunModifyRequest request, CancellationToken cancellationToken = default);

    Task<RunResponse> DeleteRun(string runId, CancellationToken cancellationToken = default);

    Task<RunListResponse> ListRuns(CancellationToken cancellationToken = default);

    Task<RunFileResponse> SubmitToolOutputs(string threadId, string runId,
        CancellationToken cancellationToken = default);

    Task<RunResponse> CancelRun(string threadId, string runId, CancellationToken cancellationToken = default);

    Task<object> CreateThreadAndRun(CancellationToken cancellationToken = default);

    Task<object> RetrieveRunStep(string threadId, string runId, string stepId,
        CancellationToken cancellationToken = default);
    
    Task<object> ListRunSteps(string threadId, string runId,
        CancellationToken cancellationToken = default);
}