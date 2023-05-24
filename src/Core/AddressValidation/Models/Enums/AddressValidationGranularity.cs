using System.Runtime.Serialization;

namespace Google.Maps.WebServices.AddressValidation;

/// <summary>
/// The various granularities that an address or a geocode can have.
/// </summary>
public enum AddressValidationGranularity
{
    /// <summary>
    /// Default value. This value is unused.
    /// </summary>
    [EnumMember(Value = "GRANULARITY_UNSPECIFIED")]
    GranularityUnspecified,

    /// <summary>
    /// Below-building level result, such as an apartment.
    /// </summary>
    [EnumMember(Value = "SUB_PREMISE")]
    SubPremise,

    /// <summary>
    /// Building-level result.
    /// </summary>
    [EnumMember(Value = "PREMISE")]
    Premise,

    /// <summary>
    /// A geocode that should be very close to the building-level location of the address.
    /// Only used for geocodes and not for addresses.
    /// </summary>
    [EnumMember(Value = "PREMISE_PROXIMITY")]
    PremiseProximity,

    /// <summary>
    /// The address or geocode indicates a block. Only used in regions which have block-level addressing, such as Japan.
    /// </summary>
    [EnumMember(Value = "BLOCK")]
    Block,

    /// <summary>
    /// The geocode or address is granular to route, such as a street, road, or highway.
    /// </summary>
    [EnumMember(Value = "ROUTE")]
    Route,

    /// <summary>
    /// All other granularities, which are bucketed together since they are not deliverable.
    /// </summary>
    [EnumMember(Value = "OTHER")]
    Other
}