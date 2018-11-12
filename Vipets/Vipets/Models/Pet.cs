using System;
using System.Collections.Generic;
using System.Text;

namespace Vipets.Models
{
    public class Pet
    {
        public long PetId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string ImageName { get; set; }
        public AnimalSpecies AnimalSpecies { get; set; }
        public Breed Breed { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string FavoriteWalkingPlace { get; set; }
        public string FavoritePlay { get; set; }
        public string RegularFeed { get; set; }
        public string FavoriteFeed { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastChangeDate { get; set; }
        public DateTime BirthDate { get; set; }

        public Pet() { }
    }
}
