namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// Interface implemented by classes to ensure valid request strings.
    /// </summary>
    public interface IUrlValue
    {
        /// <summary>
        /// Returns the object, represented as a URI value.
        /// </summary>
        /// <returns>The object, represented as a URI value (not URL encoded).</returns>
        string ToUriValue();
    }
}
