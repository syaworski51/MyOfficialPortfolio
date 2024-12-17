using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace MyOfficialPortfolio.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
