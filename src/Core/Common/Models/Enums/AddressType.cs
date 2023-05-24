using System.Runtime.Serialization;

namespace Google.Maps.WebServices.Common;

/// <summary>
/// The Address type.
/// </summary>
/// <remarks>
/// See <a
/// href="https://developers.google.com/maps/documentation/geocoding/overview#Types">Address
/// Types and Address Component Types</a> for more detail.
/// </remarks>
public enum AddressType
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
    /// A precise street number.
    /// </summary>
    [EnumMember(Value = "street_number")]
    StreetNumber,

    /// <summary>
    /// The floor in the address of the building.
    /// </summary>
    [EnumMember(Value = "floor")]
    Floor,

    /// <summary>
    /// The room in the address of the building
    /// </summary>
    [EnumMember(Value = "room")]
    Room,

    /// <summary>
    /// A specific mailbox.
    /// </summary>
    [EnumMember(Value = "post_box")]
    PostBox,

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
    /// A postal code prefix as used to address postal mail within the country.
    /// </summary>
    [EnumMember(Value = "postal_code_suffix")]
    PostalCodeSuffix,

    /// <summary>
    /// Plus code.
    /// </summary>
    [EnumMember(Value = "plus_code")]
    PlusCode,

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
    /// A university.
    /// </summary>
    [EnumMember(Value = "university")]
    University,

    /// <summary>
    /// A named park.
    /// </summary>
    [EnumMember(Value = "park")]
    Park,

    /// <summary>
    /// A museum.
    /// </summary>
    [EnumMember(Value = "museum")]
    Museum,

    /// <summary>
    /// A named point of interest. Typically, these "POI"s are prominent local entities that
    /// don't easily fit in another category, such as "Empire State Building" or "Statue of Liberty."
    /// </summary>
    [EnumMember(Value = "point_of_interest")]
    PointOfInterest,

    /// <summary>
    /// A place that has not yet been categorized.
    /// </summary>
    [EnumMember(Value = "establishment")]
    Establishment,

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
    /// A museum.
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
    /// The location of a church.
    /// </summary>
    [EnumMember(Value = "church")]
    Church,

    /// <summary>
    /// The location of a primary school.
    /// </summary>
    [EnumMember(Value = "primary_school")]
    PrimarySchool,

    /// <summary>
    /// The location of a secondary school.
    /// </summary>
    [EnumMember(Value = "secondary_school")]
    SecondarySchool,

    /// <summary>
    /// The location of a finance institute.
    /// </summary>
    [EnumMember(Value = "finance")]
    Finance,

    /// <summary>
    /// The location of a post office.
    /// </summary>
    [EnumMember(Value = "post_office")]
    PostOffice,

    /// <summary>
    /// The location of a place of worship.
    /// </summary>
    [EnumMember(Value = "place_of_worship")]
    PlaceOfWorship,

    /// <summary>
    /// A grouping of geographic areas, such as locality and sublocality, used for mailing
    /// addresses in some countries.
    /// </summary>
    [EnumMember(Value = "postal_town")]
    PostalTown,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "synagogue")]
    Synagogue,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "food")]
    Food,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "grocery_or_supermarket")]
    GroceryOrSupermarket,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "store")]
    Store,

    /// <summary>
    /// The location of a drugstore.
    /// </summary>
    [EnumMember(Value = "drugstore")]
    Drugstore,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "lawyer")]
    Lawyer,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "health")]
    Health,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "insurance_agency")]
    InsuranceAgency,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "gas_station")]
    GasStation,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "car_dealer")]
    CarDealer,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "car_repair")]
    CarRepair,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "meal_takeaway")]
    MealTakeaway,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "furniture_store")]
    FurnitureStore,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "home_goods_store")]
    HomeGoodsStore,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "shopping_mall")]
    ShoppingMall,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "gym")]
    Gym,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "accounting")]
    Accounting,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "moving_company")]
    MovingCompany,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "lodging")]
    Lodging,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "storage")]
    Storage,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "casino")]
    Casino,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "parking")]
    Parking,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "stadium")]
    Stadium,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "travel_agency")]
    TravelAgency,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "night_club")]
    NightClub,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "beauty_salon")]
    BeautySalon,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "hair_care")]
    HairCare,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "spa")]
    Spa,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "shoe_store")]
    ShoeStore,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "bakery")]
    Bakery,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "pharmacy")]
    Pharmacy,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "school")]
    School,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "book_store")]
    BookStore,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "department_store")]
    DepartmentStore,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "restaurant")]
    Restaurant,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "real_estate_agency")]
    RealEstateAgency,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "bar")]
    Bar,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "doctor")]
    Doctor,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "hospital")]
    Hospital,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "fire_station")]
    FireStation,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "supermarket")]
    Supermarket,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "city_hall")]
    CityHall,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "local_government_office")]
    LocalGovernmentOffice,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "atm")]
    Atm,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "bank")]
    Bank,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "library")]
    Library,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "car_wash")]
    CarWash,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "hardware_store")]
    HardwareStore,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "amusement_park")]
    AmusementPark,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "aquarium")]
    Aquarium,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "art_gallery")]
    ArtGallery,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "bicycle_store")]
    BicycleStore,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "bowling_alley")]
    BowlingAlley,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "cafe")]
    Cafe,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "campground")]
    Campground,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "car_rental")]
    CarRental,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "cemetery")]
    Cemetery,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "clothing_store")]
    ClothingStore,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "convenience_store")]
    ConvenienceStore,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "courthouse")]
    Courthouse,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "dentist")]
    Dentist,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "electrician")]
    Electrician,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "electronics_store")]
    ElectronicsStore,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "embassy")]
    Embassy,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "florist")]
    Florist,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "funeral_home")]
    FuneralHome,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "general_contractor")]
    GeneralContractor,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "hindu_temple")]
    HinduTemple,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "jewelry_store")]
    JewelryStore,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "laundry")]
    Laundry,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "liquor_store")]
    LiquorStore,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "locksmith")]
    Locksmith,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "meal_delivery")]
    MealDelivery,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "mosque")]
    Mosque,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "movie_rental")]
    MovieRental,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "movie_theater")]
    MovieTheater,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "painter")]
    Painter,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "pet_store")]
    PetStore,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "physiotherapist")]
    Physiotherapist,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "plumber")]
    Plumber,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "police")]
    Police,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "roofing_contractor")]
    RoofingContractor,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "rv_park")]
    RvPark,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "taxi_stand")]
    TaxiStand,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "veterinary_care")]
    VeterinaryCare,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "zoo")]
    Zoo,

    /// <summary>
    /// An archipelago.
    /// </summary>
    [EnumMember(Value = "archipelago")]
    Archipelago,

    /// <summary>
    /// A tourist attraction.
    /// </summary>
    [EnumMember(Value = "tourist_attraction")]
    TouristAttraction,

    /// <summary>
    /// Currently not a documented return type.
    /// </summary>
    [EnumMember(Value = "town_square")]
    TownSquare
}