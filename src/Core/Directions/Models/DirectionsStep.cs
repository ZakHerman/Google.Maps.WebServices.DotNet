using System.Collections.Generic;
using System.Text;
using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions
{
    /// <summary>
    /// Each element in the steps of a <see cref="DirectionsLeg" /> defines a single step of the
    /// calculated directions.
    /// </summary>
    /// <remarks>
    /// A step is the most atomic unit of a direction's route, containing a single step describing a
    /// specific, single instruction on the journey. E.g. "Turn left at Queen St." The step not only
    /// describes the instruction but also contains distance and duration information relating to
    /// how this step relates to the following step. For example, a step denoted as "Merge onto
    /// Queen street" may contain a duration of "1.3 kilometers" and "40 minutes," indicating that
    /// the next step is 37 kilometers/40 minutes from this step.
    /// </remarks>
    public class DirectionsStep
    {
        /// <summary>
        /// The distance covered by this step until the next step.
        /// </summary>
        [JsonProperty("distance")]
        public Distance Distance { get; set; }

        /// <summary>
        /// The typical time required to perform the step, until the next step.
        /// </summary>
        [JsonProperty("duration")]
        public Duration Duration { get; set; }

        /// <summary>
        /// The location of the last point of this step.
        /// </summary>
        [JsonProperty("end_location")]
        public LatLng EndLocation { get; set; }

        /// <summary>
        /// Formatted instructions for this step, presented as an HTML text string.
        /// </summary>
        [JsonProperty("html_instructions")]
        public string HtmlInstructions { get; set; }

        /// <summary>
        /// The action to take for the current step (turn left, merge, straight, etc.).
        /// </summary>
        [JsonProperty("maneuver")]
        public string Maneuver { get; set; }

        /// <summary>
        /// The path of this step.
        /// </summary>
        /// <remarks>This <see cref="PolyLine" /> is an approximate (smoothed) path of the step.</remarks>
        [JsonProperty("polyline")]
        public EncodedPolyline PolyLine { get; set; }

        /// <summary>
        /// The location of the starting point of this step.
        /// </summary>
        [JsonProperty("start_location")]
        public LatLng StartLocation { get; set; }

        /// <summary>
        /// Detailed directions for walking or driving steps in transit directions.
        /// </summary>
        /// <remarks>
        /// Substeps are only available when <see cref="TravelMode" /> is set to <see
        /// cref="Common.TravelMode.Transit" />.
        /// </remarks>
        [JsonProperty("steps")]
        public List<DirectionsStep> Steps { get; } = new List<DirectionsStep>();

        /// <summary>
        /// The travel mode of this step.
        /// </summary>
        /// <remarks>
        /// See <a
        /// href="https://developers.google.com/maps/documentation/directions/get-directions#TravelModes">Travel
        /// Modes</a> for more detail.
        /// </remarks>
        [JsonProperty("travel_mode")]
        public TravelMode TravelMode { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder($"[{nameof(DirectionsStep)}:");

            sb.Append($" {nameof(HtmlInstructions)} = \"{HtmlInstructions}\"");
            sb.Append($", {nameof(StartLocation)} = {StartLocation}");
            sb.Append($", {nameof(EndLocation)} = {EndLocation}");
            sb.Append($", {nameof(Duration)} = {Duration}");
            sb.Append($", {nameof(Distance)} = {Distance}");
            sb.Append($", {nameof(TravelMode)} = {TravelMode}");

            if (Steps.Count > 0)
                sb.Append($", {Steps.Count} {nameof(Steps)}");

            return sb.Append(']').ToString();
        }
    }
}
