using System.Globalization;

namespace ConsoleApp5
{
    class City
    {
        private string _name;
        public GeoLocation _location;

        public City(string name, GeoLocation location)
        {
            _name = name;
            _location = location;
        }

        public City()
        {

        }
        public void SetName(string name)
        {
            _name = name;
        }

        public void SetLocation(GeoLocation location)
        {
            _location = location;
        }

        public GeoLocation Location => _location;
        public string Name => _name;
    }

    class GeoLocation
    {
        private float _latitude;
        private float _longitude;

        public GeoLocation(float latitude, float longitude)
        {
            _latitude = latitude;
            _longitude = longitude;
        }

        public GeoLocation()
        {

        }

        public void SetLatitude(float latitude)
        {
            _latitude = latitude;
        }

        public void SetLongitude(float longitude)
        {
            _longitude = longitude;
        }

        public float Latitude => _latitude;
        public float Longitude => _longitude;
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var city = new City();
            city.SetName("Minsk");
            city.SetLocation(new GeoLocation());
            city.Location.SetLongitude(56.50f);
            city.Location.SetLatitude(60.05f);
            Console.WriteLine("I love {0} located at ({1}, {2})",
                city.Name,
                city.Location.Longitude.ToString(CultureInfo.InvariantCulture),
                city.Location.Latitude.ToString(CultureInfo.InvariantCulture));
        }
    }
}