using System.Runtime.Serialization;

namespace Google.Maps.WebServices.Common;

/// <summary>
/// The Address Component types.
/// </summary>
/// <remarks>
/// See <see
/// href="https://developers.google.com/maps/documentation/geocoding/overview#Types">Address
/// Types and Address Component Types</see> for more detail.
/// </remarks>
public enum AddressComponentType
{
    /// <summary>
    /// Indicates an unknown address component type returned by the server.
    /// </summary>
    [EnumMember(Value = "unknown")]
    Unknown,

    /// <summary>
    /// A precise street address.
    /// </summary>
    [EnumMember(Value = "street_address")]
    StreetAddress,

    /// <summary>
    /// A named route (such as "US 101").
    /// </summary>
    [EnumMember(Value = "route")]
    Route,

    /// <summary>
    /// A major intersection, usually of two major roads.
    /// </summary>
    [EnumMember(Value = "intersection")]
    Intersection,

    /// <summary>
    /// A continent.
    /// </summary>
    [EnumMember(Value = "continent")]
    Continent,

    /// <summary>
    /// A political entity. Usually, this type indicates a polygon of some civil administration.
    /// </summary>
    [EnumMember(Value = "political")]
    Political,

    /// <summary>
    /// The national political entity, typically the highest order type returned by the Geocoder.
    /// </summary>
    [EnumMember(Value = "country")]
    Country,

    /// <summary>
    /// A first-order civil entity below the country level.
    /// </summary>
    /// <remarks>
    /// Within the United States, these administrative levels are states. Not all nations
    /// exhibit these administrative levels.
    /// </remarks>
    [EnumMember(Value = "administrative_area_level_1")]
    AdministrativeAreaLevel1,

    /// <summary>
    /// A second-order civil entity below the country level.
    /// </summary>
    /// <remarks>
    /// Within the United States, these administrative levels are counties. Not all nations
    /// exhibit these administrative levels.
    /// </remarks>
    [EnumMember(Value = "administrative_area_level_2")]
    AdministrativeAreaLevel2,

    /// <summary>
    /// A third-order civil entity below the country level.
    /// </summary>
    /// <remarks>Not all nations exhibit these administrative levels.</remarks>
    [EnumMember(Value = "administrative_area_level_3")]
    AdministrativeAreaLevel3,

    /// <summary>
    /// A fourth-order civil entity below the country level.
    /// </summary>
    /// <remarks>Not all nations exhibit these administrative levels.</remarks>
    [EnumMember(Value = "administrative_area_level_4")]
    AdministrativeAreaLevel4,

    /// <summary>
    /// A fifth-order civil entity below the country level.
    /// </summary>
    /// <remarks>Not all nations exhibit these administrative levels.</remarks>
    [EnumMember(Value = "administrative_area_level_5")]
    AdministrativeAreaLevel5,

    /// <summary>
    /// A commonly-used alternative name for the entity.
    /// </summary>
    [EnumMember(Value = "colloquial_area")]
    ColloquialArea,

    /// <summary>
    /// An incorporated city or town political entity.
    /// </summary>
    [EnumMember(Value = "locality")]
    Locality,

    /// <summary>
    /// A specific type of Japanese locality, used to facilitate distinction between multiple
    /// locality components within a Japanese address.
    /// </summary>
    [EnumMember(Value = "ward")]
    Ward,

    /// <summary>
    /// A first-order civil entity below a locality.
    /// </summary>
    /// <remarks>
    /// For some locations may receive one of the additional types: <see
    /// cref="SubLocalityLevel1" /> to <see cref="SubLocalityLevel5" />. Each sublocality level
    /// is a civil entity. Larger numbers indicate a smaller geographic area.
    /// </remarks>
    [EnumMember(Value = "sublocality")]
    SubLocality,

    /// <inheritdoc cref="SubLocality" />
    [EnumMember(Value = "sublocality_level_1")]
    SubLocalityLevel1,

    /// <inheritdoc cref="SubLocality" />
    [EnumMember(Value = "sublocality_level_2")]
    SubLocalityLevel2,

    /// <inheritdoc cref="SubLocality" />
    [EnumMember(Value = "sublocality_level_3")]
    SubLocalityLevel3,

    /// <inheritdoc cref="SubLocality" />
    [EnumMember(Value = "sublocality_level_4")]
    SubLocalityLevel4,

    /// <inheritdoc cref="SubLocality" />
    [EnumMember(Value = "sublocality_level_5")]
    SubLocalityLevel5,

    /// <summary>
    /// A named neighborhood.
    /// </summary>
    [EnumMember(Value = "neighborhood")]
    Neighborhood,

    /// <summary>
    /// A named location, usually a building or collection of buildings with a common name.
    /// </summary>
    [EnumMember(Value = "premise")]
    Premise,

    /// <summary>
    /// A first-order entity below a named location, usually a singular building within a
    /// collection of buildings with a common name.
    /// </summary>
    [EnumMember(Value = "subpremise")]
    SubPremise,

    /// <summary>
    /// A postal code as used to address postal mail within the country.
    /// </summary>
    [EnumMember(Value = "postal_code")]
    PostalCode,

    /// <summary>
    /// A postal code prefix as used to address postal mail within the country.
    /// </summary>
    [EnumMember(Value = "postal_code_prefix")]
    PostalCodePrefix,

    /// <summary>
    /// A postal code suffix as used to address postal mail within the country.
    /// </summary>
    [EnumMember(Value = "postal_code_suffix")]
    PostalCodeSuffix,

    /// <summary>
    /// A prominent natural feature.
    /// </summary>
    [EnumMember(Value = "natural_feature")]
    NaturalFeature,

    /// <summary>
    /// An airport.
    /// </summary>
    [EnumMember(Value = "airport")]
    Airport,

    /// <summary>
    /// A named park.
    /// </summary>
    [EnumMember(Value = "park")]
    Park,

    /// <summary>
    /// A named point of interest. Typically, these "POI"s are prominent local entities that
    /// don't easily fit in another category, such as "Empire State Building" or "Statue of Liberty."
    /// </summary>
    [EnumMember(Value = "point_of_interest")]
    PointOfInterest,

    /// <summary>
    /// The floor in the address of the building.
    /// </summary>
    [EnumMember(Value = "floor")]
    Floor,

    /// <summary>
    /// Typically indicates a place that has not yet been categorized.
    /// </summary>
    [EnumMember(Value = "establishment")]
    Establishment,

    /// <summary>
    /// A parking lot or parking structure.
    /// </summary>
    [EnumMember(Value = "parking")]
    Parking,

    /// <summary>
    /// A specific postal box.
    /// </summary>
    [EnumMember(Value = "post_box")]
    PostBox,

    /// <summary>
    /// A grouping of geographic areas, such as locality and sublocality, used for mailing
    /// addresses in some countries.
    /// </summary>
    [EnumMember(Value = "postal_town")]
    PostalTown,

    /// <summary>
    /// The room of a building address.
    /// </summary>
    [EnumMember(Value = "room")]
    Room,

    /// <summary>
    /// The precise street number of an address.
    /// </summary>
    [EnumMember(Value = "street_number")]
    StreetNumber,

    /// <summary>
    /// The location of a bus stop.
    /// </summary>
    [EnumMember(Value = "bus_station")]
    BusStation,

    /// <summary>
    /// The location of a train station.
    /// </summary>
    [EnumMember(Value = "train_station")]
    TrainStation,

    /// <summary>
    /// The location of a subway station.
    /// </summary>
    [EnumMember(Value = "subway_station")]
    SubwayStation,

    /// <summary>
    /// The location of a transit station.
    /// </summary>
    [EnumMember(Value = "transit_station")]
    TransitStation,

    /// <summary>
    /// The location of a light rail station.
    /// </summary>
    [EnumMember(Value = "light_rail_station")]
    LightRailStation,

    /// <summary>
    /// A general contractor.
    /// </summary>
    [EnumMember(Value = "general_contractor")]
    GeneralContractor,

    /// <summary>
    /// A food service establishment.
    /// </summary>
    [EnumMember(Value = "food")]
    Food,

    /// <summary>
    /// A real-estate agency.
    /// </summary>
    [EnumMember(Value = "real_estate_agency")]
    RealEstateAgency,

    /// <summary>
    /// A car-rental establishment.
    /// </summary>
    [EnumMember(Value = "car_rental")]
    CarRental,

    /// <summary>
    /// A travel agency.
    /// </summary>
    [EnumMember(Value = "travel_agency")]
    TravelAgency,

    /// <summary>
    /// An electronics store.
    /// </summary>
    [EnumMember(Value = "electronics_store")]
    ElectronicsStore,

    /// <summary>
    /// A home goods store.
    /// </summary>
    [EnumMember(Value = "home_goods_store")]
    HomeGoodsStore,

    /// <summary>
    /// A school.
    /// </summary>
    [EnumMember(Value = "school")]
    School,

    /// <summary>
    /// A store.
    /// </summary>
    [EnumMember(Value = "store")]
    Store,

    /// <summary>
    /// A shopping mall.
    /// </summary>
    [EnumMember(Value = "shopping_mall")]
    ShoppingMall,

    /// <summary>
    /// A lodging establishment.
    /// </summary>
    [EnumMember(Value = "lodging")]
    Lodging,

    /// <summary>
    /// An art gallery.
    /// </summary>
    [EnumMember(Value = "art_gallery")]
    ArtGallery,

    /// <summary>
    /// A lawyer.
    /// </summary>
    [EnumMember(Value = "lawyer")]
    Lawyer,

    /// <summary>
    /// A restaurant.
    /// </summary>
    [EnumMember(Value = "restaurant")]
    Restaurant,

    /// <summary>
    /// A bar.
    /// </summary>
    [EnumMember(Value = "bar")]
    Bar,

    /// <summary>
    /// A take-away meal establishment.
    /// </summary>
    [EnumMember(Value = "meal_takeaway")]
    MealTakeaway,

    /// <summary>
    /// A clothing store.
    /// </summary>
    [EnumMember(Value = "clothing_store")]
    ClothingStore,

    /// <summary>
    /// A local government office.
    /// </summary>
    [EnumMember(Value = "local_government_office")]
    LocalGovernmentOffice,

    /// <summary>
    /// A finance establishment.
    /// </summary>
    [EnumMember(Value = "finance")]
    Finance,

    /// <summary>
    /// A moving company.
    /// </summary>
    [EnumMember(Value = "moving_company")]
    MovingCompany,

    /// <summary>
    /// A storage establishment.
    /// </summary>
    [EnumMember(Value = "storage")]
    Storage,

    /// <summary>
    /// A cafe.
    /// </summary>
    [EnumMember(Value = "cafe")]
    Cafe,

    /// <summary>
    /// A car repair establishment.
    /// </summary>
    [EnumMember(Value = "car_repair")]
    CarRepair,

    /// <summary>
    /// A health service provider.
    /// </summary>
    [EnumMember(Value = "health")]
    Health,

    /// <summary>
    /// An insurance agency.
    /// </summary>
    [EnumMember(Value = "insurance_agency")]
    InsuranceAgency,

    /// <summary>
    /// A painter.
    /// </summary>
    [EnumMember(Value = "painter")]
    Painter,

    /// <summary>
    /// An archipelago.
    /// </summary>
    [EnumMember(Value = "archipelago")]
    Archipelago,

    /// <summary>
    /// A museum.
    /// </summary>
    [EnumMember(Value = "museum")]
    Museum,

    /// <summary>
    /// A campground.
    /// </summary>
    [EnumMember(Value = "campground")]
    Campground,

    /// <summary>
    /// An RV park.
    /// </summary>
    [EnumMember(Value = "rv_park")]
    RvPark,

    /// <summary>
    /// A meal delivery establishment.
    /// </summary>
    [EnumMember(Value = "meal_delivery")]
    MealDelivery,

    /// <summary>
    /// A primary school.
    /// </summary>
    [EnumMember(Value = "primary_school")]
    PrimarySchool,

    /// <summary>
    /// A town square.
    /// </summary>
    [EnumMember(Value = "town_square")]
    TownSquare,

    /// <summary>
    /// A secondary school.
    /// </summary>
    [EnumMember(Value = "secondary_school")]
    SecondarySchool,

    /// <summary>
    /// A tourist attraction.
    /// </summary>
    [EnumMember(Value = "tourist_attraction")]
    TouristAttraction,

    /// <summary>
    /// Plus code.
    /// </summary>
    [EnumMember(Value = "plus_code")]
    PlusCode,

    /// <summary>
    /// A drug store.
    /// </summary>
    [EnumMember(Value = "drugstore")]
    Drugstore
}