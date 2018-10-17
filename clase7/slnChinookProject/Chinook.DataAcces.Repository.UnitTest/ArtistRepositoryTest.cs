using System;
using System.Data.Entity;
using Chinook.DataAccess.Interfaces;
using Chinook.DataAccess.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Chinook.Entities.Base;

namespace Chinook.DataAcces.Repository.UnitTest
{
    [TestClass]
    public class ArtistRepositoryTest
    {
        private readonly DbContext dbcontext;
        private readonly IArtistRepository artistRepository;
        private readonly IUnitOfWork unitOfWork;

        public ArtistRepositoryTest()
        {
            this.dbcontext = new ChinookDBModel();
            artistRepository = new ArtistRepository(dbcontext);
            unitOfWork = new UnitOfWork(dbcontext);
        }

        [TestMethod]
        public void GetCount()
        {
            var cantidad = artistRepository.Count();
            Assert.IsTrue(cantidad > 0, "OK");
        }
        [TestMethod]
        public void GetCountUW()
        {
            var cantidad = unitOfWork.ArtistRepository.Count();
            Assert.IsTrue(cantidad > 0, "OK");
        }
        [TestMethod]
        public void GetListByName()
        {
            var cantidad = artistRepository.GetListByName("Bla").Count();
            Assert.IsTrue(cantidad == 5, "Ok");
        }
        [TestMethod]
        public void GetListByNameStore()
        {
            var cantidad = artistRepository.GetListByNameStore("%Bla%").Count();
            Assert.IsTrue(cantidad == 5, "Ok");
        }
        [TestMethod]
        public void AddUW()
        {
            var artist = new Artist();
            artist.Name = "Test1";
            unitOfWork.ArtistRepository.Add(artist);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            Assert.IsTrue(artist.ArtistId>0,"ok");
        }
    }
}
