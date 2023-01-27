using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Authentication
{
    public class UserDto: LoginDto
    {        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}