namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// Alter a route by directing it through the specified location(s).
    /// </summary>
    public class Waypoint
    {
        /// <summary>
        /// Indicates whether this waypoint is a stopover waypoint.
        /// </summary>
        public bool IsStopOver { get; }

        /// <summary>
        /// Gets the address or location recognized by the Google Maps Web Service.
        /// </summary>
        public string Location { get; }

        /// <summary>
        /// Constructs an instance of the <see cref="Waypoint" /> class.
        /// </summary>
        /// <param name="location">Any address or location recognized by the Google Maps Web Service.</param>
        /// <param name="isStopover">Indicates whether this waypoint is a stopover waypoint.</param>
        public Waypoint(string location, bool isStopover = true)
        {
            Location = location;
            IsStopOver = isStopover;
        }

        /// <summary>
        /// Gets the String representation of this Waypoint, as an API request parameter fragment.
        /// </summary>
        /// <returns>The HTTP parameter fragment representing this waypoint.</returns>
        public override string ToString()
        {
            return IsStopOver ? Location : $"via:{Location}";
        }
    }
}
