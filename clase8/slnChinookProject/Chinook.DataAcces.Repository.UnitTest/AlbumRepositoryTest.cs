using System;
using System.Data.Entity;
using Chinook.DataAccess.Interfaces;
using Chinook.DataAccess.Repository;
using Chinook.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Chinook.DataAcces.Repository.UnitTest
{
    [TestClass]
    public class AlbumRepositoryTest
    {
        private readonly DbContext dbcontext;
        private readonly IAlbumRepository albumRepository;
        private readonly IUnitOfWork unitOfWork;

        public AlbumRepositoryTest()
        {
            this.dbcontext = new ChinookDBModel();
            albumRepository = new AlbumRepository(dbcontext);
            unitOfWork = new UnitOfWork(dbcontext);
        }

        [TestMethod]
        public void GetCount()
        {
            var cantidad = albumRepository.Count();
            Assert.IsTrue(cantidad > 0, "OK");
        }
        [TestMethod]
        public void Add()
        {
            var album = new Album();
            album.Title = "Test";
            album.ArtistId = 1;
            albumRepository.Add(album);
            dbcontext.SaveChanges();
            Assert.IsTrue(album.AlbumId>0,"Ok");
        }
        [TestMethod]
        public void Remove()
        {
            var album = new Album();
            album.AlbumId = 348;
            albumRepository.Remove(album);
            var RegistroEliminado = dbcontext.SaveChanges();
            Assert.IsTrue(RegistroEliminado > 0,"OK");
        }
        [TestMethod]
        public void GetById()
        {
            var album = albumRepository.GetById(1);
            Assert.IsTrue(album.AlbumId > 0, "Ok");
        }
        [TestMethod]
        public void GetAll()
        {
            var cantidad = albumRepository.GetAll().Count();
            Assert.IsTrue(cantidad > 0, "Ok");
        }
        [TestMethod]
        public void GetAlbunesVendidos()
        {
            var cantidad = albumRepository.GetAlbunesVendidos().Count();

            Assert.IsTrue(cantidad > 0, "Ok");
        }
        [TestMethod]
        public void GetAlbunesVendidosUW()
        {
            var listado = unitOfWork.AlbumRepository.GetAlbunesVendidos();

            Assert.IsTrue(listado.Count()> 0, "Ok");
        }
    }
}
