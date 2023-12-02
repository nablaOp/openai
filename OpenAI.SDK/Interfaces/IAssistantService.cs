using OpenAI.ObjectModels.ResponseModels;

namespace OpenAI.Interfaces;

public interface IAssistantService
{
    Task<AssistantCreateResponse> CreateAssistant(AssistantCreateRequest request, string? modelId = null,
        CancellationToken cancellationToken = default);

    Task<AssistantRetrieveResponse>
        RetrieveAssistant(string assistantId, CancellationToken cancellationToken = default);

    Task<AssistantModifyResponse> ModifyAssistant(string assistantId, AssistantModifyRequest request,
        CancellationToken cancellationToken = default);

    Task<AssistantDeleteResponse?> DeleteAssistant(string assistantId, CancellationToken cancellationToken = default);

    Task<AssistantListResponse> ListAssistants(CancellationToken cancellationToken = default);
}

public interface IThreadService
{
    Task<ThreadCreateResponse> CreateThread(ThreadCreateRequest request, CancellationToken cancellationToken = default);

    Task<ThreadRetrieveResponse> RetrieveThread(string threadId, CancellationToken cancellationToken = default);

    Task<ThreadModifyResponse> ModifyThread(string threadId, ThreadModifyRequest request,
        CancellationToken cancellationToken = default);

    Task<ThreadDeleteResponse?> DeleteThread(string threadId, CancellationToken cancellationToken = default);
}

public interface IMessageService
{
    Task<ThreadMessageCreateResponse> CreateMessage(string threadId, ThreadMessageCreateRequest request,
        CancellationToken cancellationToken = default);

    Task<ThreadMessageRetrieveResponse> RetrieveMessage(string threadId, string messageId,
        CancellationToken cancellationToken = default);

    Task<ThreadMessageModifyResponse> ModifyMessage(string threadId, string messageId,
        ThreadMessageModifyRequest request, CancellationToken cancellationToken = default);

    Task<ThreadMessageListResponse> ListMessages(string threadId, CancellationToken cancellationToken = default);

    Task<ThreadMessageRetrieveFileResponse> RetrieveMessageFile(string threadId, string messageId, string fileId,
        CancellationToken cancellationToken = default);

    Task<ThreadMessageListFileResponse> ListMessageFiles(string threadId, string messageId,
        CancellationToken cancellationToken = default);
}

public interface IRunService
{
    Task<ThreadRunCreateResponse> CreateRun(string threadId, ThreadRunCreateRequest request,
        CancellationToken cancellationToken = default);

    Task<ThreadRunRetrieveResponse> RetrieveRun(string threadId, string runId,
        CancellationToken cancellationToken = default);

    Task<ThreadRunModifyResponse> ModifyRun(string threadId, string runId, ThreadRunModifyRequest request,
        CancellationToken cancellationToken = default);

    Task<ThreadRunListResponse> ListRuns(string threadId, CancellationToken cancellationToken = default);

    Task<ThreadRunCancelResponse> CancelRun(string threadId, string runId,
        CancellationToken cancellationToken = default);

    Task<ThreadAndRunCreateResponse> CreateThreadAndRun(ThreadAndRunCreateRequest request,
        CancellationToken cancellationToken = default);

    Task<ThreadRunStepRetrieveResponse> RetrieveRunStep(string threadId, string runId, string stepId,
        CancellationToken cancellationToken = default);

    Task<ThreadRunStepListResponse> ListRunSteps(string threadId, string runId,
        CancellationToken cancellationToken = default);
}