using Application.BusinessDomain.IService;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WEP_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            var result = await _customerService.CreateCustomer(customer);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _customerService.GetAllCustomers();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var result = await _customerService.GetCustomerById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            var response = await _customerService.UpdateCustomer(customer);
            return Ok(response);
        }

    }
}
