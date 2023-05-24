using System.Collections.Generic;
using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.DistanceMatrix;

/// <summary>
/// <see cref="DistanceMatrixServiceResponse" /> represents the the Google Maps Distance Matrix
/// Web Service response.
/// </summary>
public class DistanceMatrixServiceResponse : IResponse<DistanceMatrixResult>
{
    /// <inheritdoc />
    [JsonProperty("error_message")]
    public string ErrorMessage { get; set; }

    /// <inheritdoc />
    public bool IsSuccessful => ResponseStatus == ApiResponseStatus.Ok;

    /// <inheritdoc />
    [JsonProperty("status")]
    public ApiResponseStatus ResponseStatus { get; set; }

    /// <inheritdoc />
    public DistanceMatrixResult Result => new(OriginAddresses, DestinationAddresses, Rows);

    [JsonProperty("destination_addresses")]
    private IEnumerable<string> DestinationAddresses { get; } = new List<string>();

    [JsonProperty("origin_addresses")]
    private IEnumerable<string> OriginAddresses { get; } = new List<string>();

    [JsonProperty("rows")]
    private IEnumerable<DistanceMatrixRow> Rows { get; } = new List<DistanceMatrixRow>();
}
