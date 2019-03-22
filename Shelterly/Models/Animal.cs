using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shelterly.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Race Race { get; set; }

        [Required]
        public int RaceId { get; set; }

        public Shelter Shelter { get; set; }

        [Required]
        public int ShelterId { get; set; }

        public string ImageUrl { get; set; }

    }
}