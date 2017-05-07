using Newtonsoft.Json;
using PetOwnerGender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace PetOwnerGender.Repository
{
    public class PetOwnerRepository
    {
        public List<ResponseContent> GetJsonData()
        {
            Uri geturi = new Uri("http://agl-developer-test.azurewebsites.net/people.json");

            HttpClient client = new HttpClient();

            using (HttpClient httpClient = new HttpClient())
            {

                var response = httpClient.GetAsync(geturi).Result;

                var content = JsonConvert.DeserializeObject<List<ResponseContent>>(response.Content.ReadAsStringAsync().Result);

                return content;
            }
        }
        public List<PetOwnerVM> GetPetOwnerByGender(List<ResponseContent> petOwners)
        {
            var allPets = petOwners.Where(x => x.pets != null);

            var allCats = allPets
               .GroupBy(p => p.gender)
               .Select(g => new PetOwnerVM
               {
                   gender = g.Key,
                   pets = g.SelectMany(p => p.pets.Where(c => c.type == "Cat")).OrderBy(p => p.name).ToList()
               }).ToList();

            return allCats;
        }
    }
}