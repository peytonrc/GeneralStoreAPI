using GeneralStoreAPIProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeneralStoreAPIProject.Controllers // Controllers: Remote for TV; holds all the logic to display whatever the commad that is given. 
{
    public class CustomerController : ApiController
    {
        private StoreDbContext _context = new StoreDbContext();



        // Create (Post)
        public IHttpActionResult Post(Customer customer)
        {
            // if an empty Customer is passed in
            if (customer == null)
            {
                return BadRequest("Your request body cannot be empty...");
            }
            // if the ModelState is not Valid
            if (ModelState.IsValid) // reads as "if ModelState valid == true"
            {
                _context.Customers.Add(customer); // must call save changes after Add method
                _context.SaveChanges();
                return Ok("You have successfully added a new customer!");
            }
            return BadRequest(ModelState);

        }



        // Get ALL customers (GET)
        public IHttpActionResult Get()
        {
            List<Customer> customers = _context.Customers.ToList();

            if (customers.Count != 0)
            {
                return Ok(customers);
            }
            return BadRequest("Your database does not contain any customers...");

        }



        // Get a customer by it's ID (GET)
        public IHttpActionResult GetById(int id)
        {
            Customer customer = _context.Customers.Find(id);

            if(customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }



        // Update an existing Customer by its ID (PUT)



        // Delete an existing Customer by its ID (DELETE)
    }
}
