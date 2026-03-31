using Newtonsoft.Json;

namespace Doklado.Integration.Contracts.Requests;

public class GetDocumentsRequest
{
    [JsonProperty("data")]
    public GetDocumentsRequestData Data { get; set; } = new();
}

public class GetDocumentsRequestData
{
    [JsonProperty("organizationId")]
    public string OrganizationId { get; set; } = string.Empty;

    [JsonProperty("dateFrom", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? DateFrom { get; set; }

    [JsonProperty("dateTo", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? DateTo { get; set; }

    [JsonProperty("dateType")]
    public string DateType { get; set; } = "create";

    [JsonProperty("isExported", NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsExported { get; set; }
}