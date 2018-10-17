using EF.CodeFirstData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.CodeFirstData.DataAcces
{
    public class CustomerDA
    {
        private ChinookModel _context;

        public CustomerDA()
        {
            _context = new ChinookModel();
        }
        /// <summary>
        /// Obtiene la cantidad de Registros 
        /// </summary>
        /// <returns> Retorna un numero Entero </returns>
        public int Count()
        {
            //Utilizando Linq Para obtener la cantidad de registros
            return _context.Customer.Count();
        }
        /// <summary>
        /// Permite obtener los datos de un Customera
        /// </summary>
        /// <param name="id">Parametro de tipo Entero que representa el codigo del Customera</param>
        /// <returns>Retorna la informacion del Artista </returns>
        public Customer GetCustomerById(int id)
        {
            return _context.Customer.Find(id);
        }
        /// <summary>
        /// Obtiene el Listado de Customers filtrado x nombre
        /// </summary>
        /// <param name="FiltroByName">Fitro x Nombre</param>
        /// <returns>Retorna lista de Customeras</returns>
        public IEnumerable<Customer> GetCustomers(string FiltroByName)
        {
            return _context.Customer.Where(item => item.FirstName.Contains(FiltroByName)
                                                || item.LastName.Contains(FiltroByName)).ToList();
        }
        /// <summary>
        /// Inserta un registro en la tabla Customer
        /// </summary>
        /// <param name="Customer">Entidad Customera</param>
        /// <returns>Retorna el codigo Generado</returns>
        public int InsertCustomer(Customer Customer)
        {
            _context.Customer.Add(Customer);
            _context.SaveChanges();

            return Customer.CustomerId;
        }
        public bool UpdateCustomer(Customer Customer)
        {
            _context.Customer.Attach(Customer);
            _context.Entry(Customer).State = System.Data.Entity.EntityState.Modified;

            return _context.SaveChanges() > 0;
        }
        public bool DeleteCustomer(Customer Customer)
        {
            _context.Customer.Attach(Customer);
            _context.Customer.Remove(Customer);

            return _context.SaveChanges() > 0;
        }
        public bool UpdateContactos(Customer customer)              
        {
            //Obteniendo Informacion del Customer
            var customerFound = _context.Customer.Find(customer.CustomerId);
            customerFound.Phone = customer.Phone;
            customerFound.Email = customer.Email;

            return _context.SaveChanges() > 0;
        }
        public bool UpdateContactos2(Customer customer)
        {
            //Quita la validacion de entidad
            _context.Configuration.ValidateOnSaveEnabled = false;
            //Obteniendo Informacion del Customer
            _context.Customer.Attach(customer);
            _context.Entry(customer).Property(item => item.Phone).IsModified = true;
            _context.Entry(customer).Property(item => item.Email).IsModified = true;

            return _context.SaveChanges() > 0;
        }
    }
}
