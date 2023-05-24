using System.Collections.Generic;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Geocoding;

namespace Google.Maps.WebServices.Tests.Data;

public class GeocodingTestData
{
    public static IEnumerable<object[]> GetValidAddress()
    {
        yield return new object[] { "1600 Amphitheatre Parkway, Mountain View, CA" };
        yield return new object[] { "上海+中國" };
        yield return new object[] { "1 Rue Fernand Raynaud, 36000 Châteauroux, France" };
    }

    public static IEnumerable<object[]> GetValidLocation()
    {
        yield return new object[] { new LatLngLiteral(40.714224, -73.961452), "40.714224,-73.961452" };
        yield return new object[] { new LatLngLiteral(180, -179.99999999), "180,-179.99999999" };
        yield return new object[] { new LatLngLiteral(), "0,0" };
    }

    public static IEnumerable<object[]> GetValidBounds()
    {
        yield return new object[]
        {
            new Bounds
            {
                NorthEast = new LatLngLiteral(42.1282269, -87.7108162),
                SouthWest = new LatLngLiteral(42.0886089, -87.7708629)
            },
            "42.0886089,-87.7708629|42.1282269,-87.7108162"
        };
    }

    public static IEnumerable<object[]> GetValidBoundsLatLngs()
    {
        yield return new object[]
        {
            new LatLngLiteral(42.0886089, -87.7708629),
            new LatLngLiteral(42.1282269, -87.7108162),
            "42.0886089,-87.7708629|42.1282269,-87.7108162"
        };
    }

    public static IEnumerable<object[]> GetInvalidBounds()
    {
        yield return new object[] { null };
        yield return new object[] { new Bounds() };
        yield return new object[] { new Bounds { NorthEast = null } };
        yield return new object[] { new Bounds { SouthWest = null } };
        yield return new object[] { new Bounds { NorthEast = null, SouthWest = null } };
        yield return new object[] { new Bounds { SouthWest = new LatLngLiteral(42.0886089, -87.7708629) } };
        yield return new object[] { new Bounds { SouthWest = new LatLngLiteral(42.0886089, -87.7708629) } };
    }

    public static IEnumerable<object[]> GetInvalidLatLng()
    {
        yield return new object[] { null, null };
        yield return new object[] { new LatLngLiteral(), null };
        yield return new object[] { null, new LatLngLiteral() };
    }

    public static IEnumerable<object[]> GetComponentFilters()
    {
        // Expected value first to allow usage of params
        yield return new object[] { "route:TEST_ROUTE", ComponentFilter.SetRoute("TEST_ROUTE") };
        yield return new object[] { "country:GB", new ComponentFilter(ComponentFilterType.Country, "GB") };
        yield return new object[]
        {
            "route:high st|locality:hasting|country:GB",
            ComponentFilter.SetRoute("high st"),
            ComponentFilter.SetLocality("hasting"),
            ComponentFilter.SetCountry("GB")
        };
        yield return new object[]
        {
            "locality:上海|country:中國",
            ComponentFilter.SetLocality("上海"),
            ComponentFilter.SetCountry("中國")
        };
    }

    public static IEnumerable<object[]> GetComponentFilterCollection()
    {
        yield return new object[]
        {
            new List<ComponentFilter>
            {
                ComponentFilter.SetRoute("TEST_ROUTE"),
                ComponentFilter.SetCountry("TEST_COUNTRY"),
                ComponentFilter.SetPostalCode("TEST_POSTALCODE")
            },
            "route:TEST_ROUTE|country:TEST_COUNTRY|postal_code:TEST_POSTALCODE"
        };
    }

    public static IEnumerable<object[]> GetComponentFilterTypeDictionary()
    {
        yield return new object[]
        {
            new Dictionary<ComponentFilterType, string>
            {
                { ComponentFilterType.Route, "TEST_ROUTE" },
                { ComponentFilterType.Country,"TEST_COUNTRY" },
                { ComponentFilterType.PostalCode, "TEST_POSTALCODE" }
            },
            "route:TEST_ROUTE|country:TEST_COUNTRY|postal_code:TEST_POSTALCODE"
        };
    }

    public static IEnumerable<object[]> GetInvalidComponentFilters()
    {
        yield return new object[]
        {
            null,
            null
        };

        yield return new object[]
        {
            ComponentFilter.SetRoute("high st"),
            null
        };
    }

    public static IEnumerable<object[]> GetInvalidComponentFilterCollection()
    {
        yield return new object[] { new List<ComponentFilter>() };
        yield return new object[] { new List<ComponentFilter>{ null } };
        yield return new object[]
        {
            new List<ComponentFilter>
            {
                null,
                null
            }
        };
        yield return new object[]
        {
            new List<ComponentFilter>
            {
                ComponentFilter.SetRoute("high st"),
                null,
                ComponentFilter.SetCountry("GB")
            }
        };
    }

    public static IEnumerable<object[]> GetInvalidComponentFilterTypeDictionary()
    {
        yield return new object[]
        {
            new Dictionary<ComponentFilterType, string>
            {
                { ComponentFilterType.Route, "TEST_ROUTE" },
                { ComponentFilterType.Country, null },
                { ComponentFilterType.PostalCode, "TEST_POSTALCODE" }
            }
        };
    }

    public static IEnumerable<object[]> GetLocationTypes()
    {
        yield return new object[]
        {
            "RANGE_INTERPOLATED",
            LocationType.RangeInterpolated
        };

        yield return new object[]
        {
            "RANGE_INTERPOLATED|GEOMETRIC_CENTER",
            LocationType.RangeInterpolated,
            LocationType.GeometricCenter
        };
    }

    public static IEnumerable<object[]> GetLocationTypeCollection()
    {
        yield return new object[]
        {
            new List<LocationType>
            {
                LocationType.RangeInterpolated,
                LocationType.GeometricCenter
            },
            "RANGE_INTERPOLATED|GEOMETRIC_CENTER"
        };
    }

    public static IEnumerable<object[]> GetRegion()
    {
        yield return new object[]
        {
            "Germany"
        };
    }

    public static IEnumerable<object[]> GetAddressTypes()
    {
        yield return new object[]
        {
            "amusement_park",
            AddressType.AmusementPark
        };

        yield return new object[]
        {
            "locality|gas_station",
            AddressType.Locality,
            AddressType.GasStation
        };
    }

    public static IEnumerable<object[]> GetAddressTypeCollection()
    {
        yield return new object[]
        {
            new List<AddressType>
            {
                AddressType.AmusementPark
            },
            "amusement_park"
        };

        yield return new object[]
        {
            new List<AddressType>
            {
                AddressType.Locality,
                AddressType.GasStation
            },
            "locality|gas_station"
        };
    }
}