using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shelterly.Models
{
    public class Shelter
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string ShelterName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int Capacity { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public IList<Animal> Animals { get; set; }
    }
}