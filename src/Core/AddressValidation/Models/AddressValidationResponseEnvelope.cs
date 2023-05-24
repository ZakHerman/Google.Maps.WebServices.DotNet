﻿using Newtonsoft.Json;

namespace Google.Maps.WebServices.AddressValidation
{
    /// <summary>
    ///
    /// </summary>
    public class AddressValidationResponseEnvelope
    {
        /// <summary>
        /// Serialization constructor.
        /// </summary>
        public AddressValidationResponseEnvelope()
        { }

        /// <summary>
        /// Constructs an instance of the <see cref="AddressValidationResponseEnvelope" /> class.
        /// </summary>
        /// <param name="addressValidationResult">A <see cref="AddressValidationResult" />.</param>
        /// <param name="responseId">A <see cref="ResponseId" />.</param>
        public AddressValidationResponseEnvelope(AddressValidationResult addressValidationResult, string responseId)
        {
            AddressValidationResult = addressValidationResult;
            ResponseId = responseId;
        }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("result")]
        public AddressValidationResult AddressValidationResult { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("responseId")]
        public string ResponseId { get; set; }
    }
}
