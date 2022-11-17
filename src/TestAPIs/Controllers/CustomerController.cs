using Microsoft.AspNetCore.Mvc;

using TestAPIs.Domain;
using TestAPIs.Interfaces;

namespace TestAPIs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            this.customerServices = customerServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(customerServices.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet(template: "Search")]
        public IActionResult Search(string? searchFilter = "")
        {
            try
            {
                return Ok(customerServices.Search(searchFilter));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut(template: "Add")]
        public IActionResult Add(Customer customer)
        {
            try
            {
                return Ok(customerServices.Add(customer));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut(template: "Update")]
        public IActionResult Update(Customer customer)
        {
            try
            {
                return Ok(customerServices.Update(customer));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}