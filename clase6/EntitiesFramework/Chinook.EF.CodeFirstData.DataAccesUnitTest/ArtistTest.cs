using System;
using EF.CodeFirstData.DataAcces;
using EF.CodeFirstData.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.EF.CodeFirstData.DataAccesUnitTest
{
    [TestClass]
    public class ArtistTest
    {
        ArtistDA artistDA = new ArtistDA(); 
        public ArtistTest()
        {

        }
        [TestMethod]
        public void Update()
        {
            var artist = artistDA.GetArtistById(1);
            artist.Name = "AC/DC version 2";

            var resultado =artistDA.UpdateArtist(artist);

            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void Delete()
        {
            var artist = new Artist();
            artist.ArtistId = 289; //AeroSmith

            var resultado = artistDA.DeleteArtist(artist);

            Assert.IsTrue(resultado);
        }
    }
}
