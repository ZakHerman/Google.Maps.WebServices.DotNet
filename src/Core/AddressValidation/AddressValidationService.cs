using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Maps.WebServices.Common;

namespace Google.Maps.WebServices.AddressValidation;

/// <summary>
/// The Address Validation API is a service that accepts an address, identifies the address
/// components, and validates them.
/// </summary>
/// <remarks>
/// It also standardizes the address for mailing and finds the best known lat/long location
/// for it. It can help understand if an address refers to a real place. If the address does
/// not refer to a real place, it can identify possibly wrong components, enabling users to
/// correct them.
/// </remarks>
public static class AddressValidationService
{
    /// <summary>
    /// Validates an address.
    /// </summary>
    /// <param name="client">The instance of <see cref="GoogleMapsServiceClient" /> used to send the request.</param>
    /// <param name="address">The address being validated.</param>
    /// <param name="previousResponseId"></param>
    /// <param name="enableUspsCass">Enables USPS CASS compatible mode.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>A <see cref="GoogleMapsResponse{AddressValidationResponse}" />.</returns>
    public static Task<GoogleMapsResponse<AddressValidationResponseEnvelope>> ValidateAddressAsync(this GoogleMapsServiceClient client, PostalAddress address,
        string previousResponseId, bool enableUspsCass, CancellationToken cancellationToken = default)
    {
        Uri uri = new("https://addressvalidation.googleapis.com/v1:validateAddress");
        var request = new AddressValidationRequest(address, previousResponseId, enableUspsCass);

        return client.PostAsync<AddressValidationRequest, AddressValidationServiceResponse, AddressValidationResponseEnvelope>(uri, request, cancellationToken);
    }
}
