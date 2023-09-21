using Liga.web.Models.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Liga.web.Models
{
    public class AddItemsViewModel
    {
        [Display(Name ="Team")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Team.")]
        public int TeamAId { get; set; }

        [Display(Name = "Team")]
        [Compare("TeamAId")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Team.")]
        public int TeamBId { get; set; }
        
        public IEnumerable<SelectListItem> Teams { get; set; }

    }
}
