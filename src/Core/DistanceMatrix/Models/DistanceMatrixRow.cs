using System.Collections.Generic;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.DistanceMatrix;

/// <summary>
/// Represents a single row in a Distance Matrix Web Service response. A row represents the
/// results for a single origin.
/// </summary>
public class DistanceMatrixRow
{
    /// <summary>
    /// The results for this row, or individual origin.
    /// </summary>
    [JsonProperty("elements")]
    public IEnumerable<DistanceMatrixElement> Elements { get; } = new List<DistanceMatrixElement>();
}