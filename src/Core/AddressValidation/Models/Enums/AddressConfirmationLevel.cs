using System.Runtime.Serialization;

namespace Google.Maps.WebServices.AddressValidation;

/// <summary>
/// The different possible values for confirmation levels.
/// </summary>
public enum AddressConfirmationLevel
{
    /// <summary>
    /// Default value. This value is unused.
    /// </summary>
    [EnumMember(Value = "CONFIRMATION_LEVEL_UNSPECIFIED")]
    Unspecified,

    /// <summary>
    /// Component verified and exists and makes sense in the context of the rest of the address.
    /// </summary>
    [EnumMember(Value = "CONFIRMED")]
    Confirmed,

    /// <summary>
    /// This component could not be confirmed, but it is plausible that it exists.
    /// </summary>
    /// <remarks>
    /// For example, a street number within a known valid range of numbers on a street where
    /// specific house numbers are not known.
    /// </remarks>
    [EnumMember(Value = "UNCONFIRMED_BUT_PLAUSIBLE")]
    Plausible,

    /// <summary>
    /// This component was not confirmed and is likely to be wrong.
    /// </summary>
    /// <remarks>
    /// For example, a neighborhood that does not fit the rest of the address.
    /// </remarks>
    [EnumMember(Value = "UNCONFIRMED_AND_SUSPICIOUS")]
    Suspicious
}
