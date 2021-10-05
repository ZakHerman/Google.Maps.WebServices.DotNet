namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// You may specify transit mode when requesting transit directions or distances.
    /// </summary>
    public enum TransitMode
    {
        /// <summary>
        /// Indicates that the calculated route should prefer travel by bus.
        /// </summary>
        Bus,

        /// <summary>
        /// Indicates that the calculated route should prefer travel by subway.
        /// </summary>
        Subway,

        /// <summary>
        /// Indicates that the calculated route should prefer travel by train.
        /// </summary>
        Train,

        /// <summary>
        /// Indicates that the calculated route should prefer travel by tram and light rail.
        /// </summary>
        Tram,

        /// <summary>
        /// Indicates that the calculated route should prefer travel by train, tram, light rail, and subway.
        /// </summary>
        /// <remarks>This is equivalent to transit_mode=train|tram|subway.</remarks>
        Rail
    }
}
