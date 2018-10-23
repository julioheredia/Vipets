using System;
using System.Collections.Generic;
using System.Text;

namespace Vipets.Services.Models
{
    public class Breed
    {
        public long breedId { get; set; }
        public AnimalSpecies AnimalSpecies { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string exampleImage { get; set; }

        public Breed() { }

    }
}
