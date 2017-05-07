using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetOwnerGender.Models
{
    public class PetOwnerVM
    {
        public string gender { get; set; }
        public List<Pet> pets { get; set; }
    }
}