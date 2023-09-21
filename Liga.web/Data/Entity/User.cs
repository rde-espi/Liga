using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Liga.web.Data.Entity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name ="Full Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
