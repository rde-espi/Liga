using Liga.web.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Liga.web.Models.Entity
{
    public class TeamEntity : IEntity
    {
        public int Id { get; set; }

        [Display(Name ="Team Name")]
        [Required]
        [MaxLength(50, ErrorMessage = "The field {0} can contain {1} characters.")]
        public string Name { get; set; }

        [Display(Name ="Team Logo")]
        public Guid ImageId { get; set; }

        public User User { get; set; }
        public ICollection<PlayerEntity>Players { get; set; }

        public string ImageFullPath => ImageId == Guid.Empty
          ? $"/images/noimage.png"
          : $"https://supershoptpsirs.blob.core.windows.net/teams-liga/{ImageId}";
    }
}
