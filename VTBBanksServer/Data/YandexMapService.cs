using Yandex.Geocoder.Enums;
using Yandex.Geocoder;

namespace VTBBanksServer.Data;

public class YandexMapService
{
    private const string ApiKey = "";

    public async void Get()
    {
        var request = new ReverseGeocoderRequest { Latitude = 58.046733, Longitude = 38.841715 };
        var client = new GeocoderClient(ApiKey);

        var response = await client.ReverseGeocode(request);

        var firstGeoObject = response.GeoObjectCollection.FeatureMember.FirstOrDefault();
        var addressComponents = firstGeoObject.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components;
        var country = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Country));
        var province = addressComponents.LastOrDefault(c => c.Kind.Equals(AddressComponentKind.Province));
        var area = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Area));
        var city = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Locality));
        var street = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Street));
        var house = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.House));

        //Assert.Equal("Россия", country.SalePointName);
        //Assert.Equal("Ярославская область", province.SalePointName);
        //Assert.Equal("городской округ Рыбинск", area.SalePointName);
        //Assert.Equal("Рыбинск", city.SalePointName);
        //Assert.Equal("улица Бородулина", street.SalePointName);
        //Assert.Equal("23", house.SalePointName);
    }
}
