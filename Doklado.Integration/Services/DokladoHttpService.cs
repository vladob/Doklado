using Newtonsoft.Json;
using System.Text;
using Doklado.Integration.Contracts.Requests;
using Doklado.Integration.Contracts.Enums;
using Doklado.Integration.Extensions;

namespace Doklado.Integration.Services;

public class DokladoHttpService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<string> GetDocumentsRawAsync(
        string organizationId,
        DateTime? dateFrom,
        DokladoDateType dateType,
        CancellationToken cancellationToken = default)
    {
        var request = new GetDocumentsRequest
        {
            Data = new GetDocumentsRequestData
            {
                OrganizationId = organizationId,
                DateFrom = dateFrom?.ToUniversalTime(),
                DateType = dateType.ToApiValue(),
                IsExported = false
            }
        };

        var json = JsonConvert.SerializeObject(request);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("/v2/documents", content, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }
}