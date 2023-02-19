﻿using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Exceptions;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.AddressValidation
{
    /// <summary>
    ///
    /// </summary>
    public class AddressValidationServiceResponse : IResponse<AddressValidationResponse>
    {
        /// <inheritdoc />
        public string ErrorMessage => Error?.Message;

        /// <inheritdoc />
        public bool IsSuccessful => ResponseStatus == ApiResponseStatus.Ok;

        /// <inheritdoc />
        public ApiResponseStatus ResponseStatus => Error?.ResponseStatus ?? ApiResponseStatus.Ok;

        /// <inheritdoc />
        public AddressValidationResponse Result => new AddressValidationResponse(AddressValidationResult, ResponseId);

        [JsonProperty("result")]
        private AddressValidationResult AddressValidationResult { get; set; }

        [JsonProperty("error")]
        private GoogleMapsError Error { get; set; }

        [JsonProperty("responseId")]
        private string ResponseId { get; set; }
    }
}
