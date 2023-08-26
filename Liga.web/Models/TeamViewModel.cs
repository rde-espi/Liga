using Liga.web.Models.Entity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Liga.web.Models
{
    public class TeamViewModel : TeamEntity
    {
        [Display(Name ="Team Logo")]
         public IFormFile Imagefile { get; set; }
    }
}
