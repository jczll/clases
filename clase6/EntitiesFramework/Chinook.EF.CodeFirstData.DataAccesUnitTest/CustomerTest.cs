using System;
using EF.CodeFirstData.DataAcces;
using EF.CodeFirstData.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.EF.CodeFirstData.DataAccesUnitTest
{
    [TestClass]
    public class CustomerTest
    {
        CustomerDA customerDA = new CustomerDA();

        [TestMethod]
        public void UpdateContacto()
        {
            var customer = new Customer();
            customer.CustomerId = 1;
            customer.Phone = "04223596";
            customer.Email = "jczll@gmail.com";
            var resultado = customerDA.UpdateContactos(customer);

            Assert.IsTrue(resultado,"Actualizo Correctamente");
        }

        [TestMethod]
        public void UpdateContacto2()
        {
            var customer = new Customer();
            customer.CustomerId = 1;
            customer.Phone = "4223596";
            customer.Email = "faza@gmail.com";
            var resultado = customerDA.UpdateContactos2(customer);

            Assert.IsTrue(resultado,"Actualizo Correctamente");
        }
    }
}
