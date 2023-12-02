using System.Net.Http.Json;
using OpenAI.Extensions;
using OpenAI.Interfaces;
using OpenAI.ObjectModels.ResponseModels;

namespace OpenAI.Managers;

public partial class OpenAIService : IAssistantService
{
    public async Task<AssistantCreateResponse> CreateAssistant(AssistantCreateRequest request, string? modelId = null,
        CancellationToken cancellationToken = default)
    {
        request.ProcessModelId(modelId, _defaultModelId);
        return await _httpClient.PostAndReadAsAsync<AssistantCreateResponse>(_endpointProvider.AssistantCreate(),
            request, cancellationToken);
    }

    public async Task<AssistantRetrieveResponse> RetrieveAssistant(string assistantId,
        CancellationToken cancellationToken = default)
    {
        return (await _httpClient.GetFromJsonAsync<AssistantRetrieveResponse>(
            _endpointProvider.AssistantRetrieve(assistantId), cancellationToken))!;
    }

    public async Task<AssistantModifyResponse> ModifyAssistant(string assistantId, AssistantModifyRequest request,
        CancellationToken cancellationToken = default)
    {
        return (await _httpClient.PostAndReadAsAsync<AssistantModifyResponse>(
            _endpointProvider.AssistantModify(assistantId), request, cancellationToken));
    }

    public async Task<AssistantDeleteResponse?> DeleteAssistant(string assistantId,
        CancellationToken cancellationToken = default)
    {
        return await (await _httpClient.DeleteAsync(_endpointProvider.AssistantDelete(assistantId), cancellationToken))
            .Content.ReadFromJsonAsync<AssistantDeleteResponse>(cancellationToken: cancellationToken);
    }

    public async Task<AssistantListResponse> ListAssistants(CancellationToken cancellationToken = default)
    {
        return (await _httpClient.GetFromJsonAsync<AssistantListResponse>(_endpointProvider.AssistantList(),
            cancellationToken))!;
    }
}

public partial class OpenAIService : IThreadService
{
    public async Task<ThreadCreateResponse> CreateThread(ThreadCreateRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.PostAndReadAsAsync<ThreadCreateResponse>(_endpointProvider.ThreadCreate(),
            request, cancellationToken);
    }

    public async Task<ThreadRetrieveResponse> RetrieveThread(string threadId, CancellationToken cancellationToken = default)
    {
        return (await _httpClient.GetFromJsonAsync<ThreadRetrieveResponse>(
            _endpointProvider.ThreadRetrieve(threadId), cancellationToken))!;
    }

    public async Task<ThreadModifyResponse> ModifyThread(string threadId, ThreadModifyRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.PostAndReadAsAsync<ThreadModifyResponse>(
            _endpointProvider.ThreadModify(threadId), request, cancellationToken);
    }

    public async Task<ThreadDeleteResponse?> DeleteThread(string threadId, CancellationToken cancellationToken = default)
    {
        return await (await _httpClient.DeleteAsync(_endpointProvider.ThreadDelete(threadId), cancellationToken))
            .Content.ReadFromJsonAsync<ThreadDeleteResponse>(cancellationToken: cancellationToken);
    }
}

public partial class OpenAIService : IMessageService
{
    public async Task<ThreadMessageCreateResponse> CreateMessage(string threadId, ThreadMessageCreateRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.PostAndReadAsAsync<ThreadMessageCreateResponse>(_endpointProvider.MessageCreate(threadId),
            request, cancellationToken);
    }

    public async Task<ThreadMessageRetrieveResponse> RetrieveMessage(string threadId, string messageId, CancellationToken cancellationToken = default)
    {
        return (await _httpClient.GetFromJsonAsync<ThreadMessageRetrieveResponse>(
            _endpointProvider.MessageRetrieve(threadId, messageId), cancellationToken))!;
    }

    public async Task<ThreadMessageModifyResponse> ModifyMessage(string threadId, string messageId, ThreadMessageModifyRequest request,
        CancellationToken cancellationToken = default)
    {
        return await _httpClient.PostAndReadAsAsync<ThreadMessageModifyResponse>(
            _endpointProvider.MessageModify(threadId, messageId), request, cancellationToken);
    }

    public async Task<ThreadMessageListResponse> ListMessages(string threadId, CancellationToken cancellationToken = default)
    {
        return (await _httpClient.GetFromJsonAsync<ThreadMessageListResponse>(_endpointProvider.MessageList(threadId),
            cancellationToken))!;
    }

    public async Task<ThreadMessageRetrieveFileResponse> RetrieveMessageFile(string threadId, string messageId, string fileId,
        CancellationToken cancellationToken = default)
    {
        return (await _httpClient.GetFromJsonAsync<ThreadMessageRetrieveFileResponse>(
            _endpointProvider.MessageFileRetrieve(threadId, messageId, fileId), cancellationToken))!;
    }

    public async Task<ThreadMessageListFileResponse> ListMessageFiles(string threadId, string messageId, CancellationToken cancellationToken = default)
    {
        return (await _httpClient.GetFromJsonAsync<ThreadMessageListFileResponse>(_endpointProvider.MessageFileList(threadId, messageId),
            cancellationToken))!;
    }
}

public partial class OpenAIService : IRunService
{
    public async Task<ThreadRunCreateResponse> CreateRun(string threadId, ThreadRunCreateRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.PostAndReadAsAsync<ThreadRunCreateResponse>(_endpointProvider.RunCreate(threadId),
            request, cancellationToken);
    }

    public async Task<ThreadRunRetrieveResponse> RetrieveRun(string threadId, string runId, CancellationToken cancellationToken = default)
    {
        return (await _httpClient.GetFromJsonAsync<ThreadRunRetrieveResponse>(
            _endpointProvider.RunRetrieve(threadId, runId), cancellationToken))!;
    }

    public async Task<ThreadRunModifyResponse> ModifyRun(string threadId, string runId, ThreadRunModifyRequest request,
        CancellationToken cancellationToken = default)
    {
        return await _httpClient.PostAndReadAsAsync<ThreadRunModifyResponse>(
            _endpointProvider.RunModify(threadId, runId), request, cancellationToken);
    }

    public async Task<ThreadRunListResponse> ListRuns(string threadId, CancellationToken cancellationToken = default)
    {
        return (await _httpClient.GetFromJsonAsync<ThreadRunListResponse>(_endpointProvider.RunList(threadId),
            cancellationToken))!;
    }

    public async Task<ThreadRunCancelResponse> CancelRun(string threadId, string runId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.PostAndReadAsAsync<ThreadRunCancelResponse>(_endpointProvider.RunCancel(threadId, runId), null, cancellationToken);
    }

    public async Task<ThreadAndRunCreateResponse> CreateThreadAndRun(ThreadAndRunCreateRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.PostAndReadAsAsync<ThreadAndRunCreateResponse>(_endpointProvider.ThreadAndRunCreate(),
            request, cancellationToken);
    }

    public async Task<ThreadRunStepRetrieveResponse> RetrieveRunStep(string threadId, string runId, string stepId, CancellationToken cancellationToken = default)
    {
        return (await _httpClient.GetFromJsonAsync<ThreadRunStepRetrieveResponse>(
            _endpointProvider.RunStepRetrieve(threadId, runId, stepId), cancellationToken))!;
    }

    public async Task<ThreadRunStepListResponse> ListRunSteps(string threadId, string runId, CancellationToken cancellationToken = default)
    {
        return (await _httpClient.GetFromJsonAsync<ThreadRunStepListResponse>(_endpointProvider.RunStepList(threadId, runId),
            cancellationToken))!;
    }
}
