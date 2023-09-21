using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Liga.web.Data.Entity
{
    public class JourneyDetail
    {
        public int Id { get; set; }

        //[Required]
        //public User User { get; set; }

        [Required]
        public IEnumerable< Game> Games { get; set; }

        

    }
}
