using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shelterly.Models
{
    public class Shelter
    {
        public int Id { get; set; }

        public string ShelterName { get; set; }

        public string Address { get; set; }

        public int Capacity { get; set; }

        public IList<Animal> Animals { get; set; }
    }
}