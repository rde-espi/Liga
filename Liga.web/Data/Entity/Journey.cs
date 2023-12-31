﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Liga.web.Data.Entity
{
    
    public class Journey : IEntity
    {
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        public IEnumerable<Game> Games { get; set; }

        [Display(Name ="Started on")]
        public DateTime JourneyStart = DateTime.Now;

        [Display(Name ="Ended in")]
        public DateTime JourneyEnd { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public int ConcludedGames => Games == null ? 0 : Games.Count(Game => Game != null);

    }
}
