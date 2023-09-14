using System;
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

        public IEnumerable<JourneyDetail> Games { get; set; }

        public DateTime JourneyStart = DateTime.Now;
        public DateTime JourneyEnd { get; set; }

        //public int ConcludedGames => Games == null ? 0 : Games.Sum(g=>g.)

    }
}
