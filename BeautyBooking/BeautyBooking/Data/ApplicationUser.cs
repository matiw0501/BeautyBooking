using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BeautyBooking.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(30)] public string FirstName { get; set; } = string.Empty;
        [MaxLength(50)]public string LastName { get; set; } = string.Empty;
    }

}
