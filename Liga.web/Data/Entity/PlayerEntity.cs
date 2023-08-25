using System;
using System.ComponentModel.DataAnnotations;

namespace Liga.web.Models.Entity
{
    public class PlayerEntity : IPlayerEntity
    {
        public int Id { get; set; }

        [Display(Name= "Player Name")]
        public string Name { get; set; }

        [Display(Name ="Team")]
        public TeamEntity PlayerTeam { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Salary { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Display (Name = "Last Login")]
        public DateTime LastLogin=DateTime.Now;

    }
}
