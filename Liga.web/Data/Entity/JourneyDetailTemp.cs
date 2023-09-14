using Liga.web.Models.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Liga.web.Data.Entity
{
    // a ser criado pelo staff
    public class JourneyDetailTemp : IEntity
    {
        public int Id { get; set ; }

        [Required]
        public User User { get; set ; }

        [Required]
        public Game Game { get; set; }

       
    }
}
