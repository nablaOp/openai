using System.Net.Http.Json;
using OpenAI.Extensions;
using OpenAI.Interfaces;
using OpenAI.ObjectModels.ResponseModels;

namespace OpenAI.Managers;

public partial class OpenAIService : IAssistantService
{
    public async Task<AssistantResponse> CreateAssistant(AssistantCreateRequest request, string? modelId = null,
        CancellationToken cancellationToken = default)
    {
        request.ProcessModelId(modelId, _defaultModelId);
        return await _httpClient
            .PostAndReadAsAsync<AssistantResponse>(
                _endpointProvider.AssistantCreate(), request, cancellationToken);
    }

    public Task<AssistantResponse> RetrieveAssistant(string assistantId, CancellationToken cancellationToken = default)
    {
        return _httpClient
            .GetFromJsonAsync<AssistantResponse>(
                _endpointProvider.AssistantRetrieve(assistantId), cancellationToken)!;
    }

    public Task<AssistantResponse> ModifyAssistant(string assistantId, AssistantModifyRequest request,
        CancellationToken cancellationToken = default)
    {
        return _httpClient
            .PostAndReadAsAsync<AssistantResponse>(
                _endpointProvider.AssistantModify(assistantId), request, cancellationToken);
    }

    public Task<AssistantListResponse> ListAssistants(CancellationToken cancellationToken = default)
    {
        return _httpClient
            .GetFromJsonAsync<AssistantListResponse>(
                _endpointProvider.AssistantList(), cancellationToken)!;
    }

    public Task<AssistantResponse> DeleteAssistant(string assistantId, CancellationToken cancellationToken = default)
    {
        return _httpClient
            .GetFromJsonAsync<AssistantResponse>(
                _endpointProvider.AssistantDelete(assistantId), cancellationToken)!;
    }
}