using GeneralStoreAPIProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeneralStoreAPIProject.Controllers // Controllers: Remote for TV; holds all the logic to display whatever the commad that is given. 
{
    public class ProductController : ApiController
    {
        private StoreDbContext _context = new StoreDbContext();

        // Create (POST)
        public IHttpActionResult Post(Product product)
        {
            // if an empty Customer is passed in
            if (product == null)
            {
                return BadRequest("Your request body cannot be empty...");
            }
            product.SKU = GenerateSku(product.Name);
            // if the ModelState is not Valid
            if (ModelState.IsValid && product.SKU != null) 
            {
                _context.Products.Add(product); // must call save changes after Add method
                _context.SaveChanges();
                return Ok("You have successfully added a new product!");
            }
            return BadRequest(ModelState);

        }



        // Get All Products(GET)
        public IHttpActionResult Get()
        {
            List<Product> products = _context.Products.ToList();

            if (products.Count != 0)
            {
                return Ok(products);
            }
            return BadRequest("Your database does not contain any products...");

        }


        // Get a Product by its ID(GET)
        public IHttpActionResult GetById(string sku)
        {
            Product product = _context.Products.Find(sku);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        // Update an existing Product by its ID(PUT)




        // Delete an existing Product by its ID(DELETE)




        // Josh's method
        private string GenerateSku(string productName)
        {
            // Initialize a Random object so we can randomly assign this a number
            Random random = new Random();
            // Get a Random number and turn it into a string
            var randItemNum = random.Next(0, 1000).ToString();
            // Construct a 3 character string based on the above number. If the number is less than 3 digits, add 0's in front of it to make it 3 digits
            var itemId = new string('0', 3 - randItemNum.Length) + randItemNum;
            // Create the entire SKU and return it
            return $"EFA-{productName.Substring(0, 3)}-{itemId}";
        }
    }
}
