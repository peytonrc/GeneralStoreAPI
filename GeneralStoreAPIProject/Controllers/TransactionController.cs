using GeneralStoreAPIProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeneralStoreAPIProject.Controllers // Controllers: Remote for TV; holds all the logic to display whatever the commad that is given. 
{
    public class TransactionController : ApiController
    {
        private StoreDbContext _context = new StoreDbContext();


        // Create (POST)
        public IHttpActionResult Post(Transaction transaction)
        {
            // if an empty Transaction is passed in
            if (transaction == null)
            {
                return BadRequest("Your request body cannot be empty...");
            }
           
            // if the ModelState is not Valid
            if (ModelState.IsValid && transaction.CustomerId != 0 && transaction.ProductSKU != null) // reads as "model state is valid"
            {
                _context.Transactions.Add(transaction); // must call save changes after Add method
                _context.SaveChanges();
                return Ok("You have successfully added a new product!");
            }
            return BadRequest(ModelState);

        }



        // Get All Transactions(GET)
        public IHttpActionResult Get()
        {
            List<Transaction> transactions = _context.Transactions.ToList();

            if (transactions.Count != 0)
            {
                return Ok(transactions);
            }
            return BadRequest("Your database does not contain any transactions...");

        }




        // Get a Transaction by its ID(GET)
        public IHttpActionResult GetById(int id)
        {
            Transaction transaction = _context.Transactions.Find(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }




        // Update an existing Transaction by its ID(PUT)







        // Delete an existing Transaction by its ID(DELETE)








    }
}
