namespace HotelListing.API.Core.Exceptions
{
    public class BadRequestException: ApplicationException
    {
        public BadRequestException(string name, string data): base($"{name} recieved a bad request with data {data}")
        {

        }
    }
}
