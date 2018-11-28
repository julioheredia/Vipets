using System;
using System.Collections.Generic;
using System.Text;

namespace Vipets.Models
{
    public class Pet
    {
        public long petId { get; set; }
        public string name { get; set; }
        public byte[] photo { get; set; }
        public string imageName { get; set; }
        public Breed breed { get; set; }
        public string color { get; set; }
        public string description { get; set; }
        public string favoriteWalkingPlace { get; set; }
        public string favoritePlay { get; set; }
        public string regularFeed { get; set; }
        public string favoriteFeed { get; set; }
        public DateTime registrationDate { get; set; }
        public DateTime lastChangeDate { get; set; }
        public DateTime birthDate { get; set; }

        public Pet() { }
    }
}
