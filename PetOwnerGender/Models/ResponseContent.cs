using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetOwnerGender.Models
{
    public class ResponseContent
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public List<Pet> pets { get; set; }
    }
}