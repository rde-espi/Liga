using Liga.web.Models.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Liga.web.Data.Entity
{
    // a ser criado pelo staff
    public class GameDetailTemp : IEntity
    {
        public int Id { get; set; }

        [Required]
        public User User { get; set; }
            

        [Required]
        public TeamEntity TeamA { get; set; }
        [Required]
        public TeamEntity TeamB { get; set; }

        //[Required]
        public uint? GolsTeamA { get; set; }
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
