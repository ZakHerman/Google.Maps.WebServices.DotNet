using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions;

/// <summary>
/// Transit vehicle.
/// </summary>
public class DirectionsTransitVehicle
{
    /// <summary>
    /// The URL for an icon associated with this vehicle type.
    /// </summary>
    [JsonProperty("icon")]
    public string Icon { get; set; }

    /// <summary>
    /// The URL for the icon associated with this vehicle type, based on the local transport signage.
    /// </summary>
    [JsonProperty("local_icon")]
    public string LocalIcon { get; set; }

    /// <summary>
    /// The name of this vehicle, capitalized.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// The type of vehicle used.
    /// </summary>
    [JsonProperty("type")]
    public TransitVehicleType Type { get; set; }
}