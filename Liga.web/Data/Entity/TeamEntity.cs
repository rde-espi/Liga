﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Liga.web.Models.Entity
{
    public class TeamEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The field {0} can contain {1} characters.")]
        public string Name { get; set; }
        public string PathLogo { get; set; }

        public ICollection<PlayerEntity>Players { get; set; }
    }
}