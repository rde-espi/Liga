﻿using Liga.web.Models.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Liga.web.Data.Entity
{
    public class Game : IEntity
    {
        public int Id { get; set; }

        //[Required]
        //public User User { get; set; }


        [Required]
        public TeamEntity TeamA { get; set; }
        [Required]
        public TeamEntity TeamB { get; set; }
        public IEnumerable<TeamEntity> Teams { get; set; }

        //[Required]
        public uint? GolsTeamA { get ; set; }
        //[Required]
        public uint? GolsTeamB { get; set; }
        //[Required]
        public uint? YellowCardA { get; set; }
        //[Required]
        public uint? YellowCardB { get; set; }
        //[Required]
        public uint? RedCardA { get; set; }
        //[Required]
        public uint? RedCardB { get; set; }

        [Required]
        public bool IsConcluded { get; set; }
    }
}
