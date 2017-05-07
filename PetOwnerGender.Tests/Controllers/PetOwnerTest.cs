using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetOwnerGender.Controllers;
using PetOwnerGender.Repository;
using PetOwnerGender.Models;

namespace PetOwnerGender.Tests.Controllers
{
    [TestClass]
    public class PetOwnerTest
    {
        PetOwnerRepository petOwnerRepository = new PetOwnerRepository();

        [TestMethod]
        public void PetOwnerRepo_GetJsonData_Test()
        {
            // Arrange
            List<ResponseContent> contentsFromWeb = null;

            // Act
            contentsFromWeb = petOwnerRepository.GetJsonData();

            // Assert
            Assert.IsNotNull(contentsFromWeb);
        }

        [TestMethod]
        public void PetOwnerRepo_GetPetOwnerByGender_Test()
        {
            // Arrange
            List<ResponseContent> contentsFromWeb = null;
            contentsFromWeb = petOwnerRepository.GetJsonData();

            // Act

            var allOwners = petOwnerRepository.GetPetOwnerByGender(contentsFromWeb);
            var count = allOwners.SelectMany(a => a.pets).Count(a => a.name == "Garfield");

            // Assert
            Assert.AreEqual(2, count);
        }
    }
}
