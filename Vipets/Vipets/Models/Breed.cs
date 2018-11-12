using System;
using System.Collections.Generic;
using System.Text;

namespace Vipets.Models
{
    public class Breed
    {
        public long BreedId { get; set; }
        public AnimalSpecies AnimalSpecies { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExampleImage { get; set; }

        public Breed() { }

    }
}
