using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PetOwnerGender.Models;
using PetOwnerGender.Repository;

namespace PetOwnerGender.Controllers
{
    public class HomeController : Controller
    {
        PetOwnerRepository petOwnerRepository = new PetOwnerRepository();

        public ActionResult Index()
        {

            List<ResponseContent> contentsFromWeb = petOwnerRepository.GetJsonData();

            List<PetOwnerVM> allCats = petOwnerRepository.GetPetOwnerByGender(contentsFromWeb);

            return View(allCats);
        }
    }
}