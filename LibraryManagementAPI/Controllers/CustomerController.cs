using LibraryManagementAPI.Filters;
using LibraryManagementCore.DTOs.Requests;
using LibraryManagementCore.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Controllers
{
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        /// <summary>
        /// Register customer
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("RegisterCustomer")]
        public async Task<IActionResult> Create(RegisterDto register)
        {
            var result = await _customerServices.CreateCustomer(register);
            if (result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Log in customer
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("LoginCustomer")]
        public async Task<IActionResult> Login(LoginRequestDto login)
        {
            var result = await _customerServices.Login(login);
            if (result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Get Existing Customer
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetACustomer")]
        public async Task<IActionResult> Get(string Id)
        {
            var result = await _customerServices.GetCustomerById(Id);
            if (result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Get Existing Customer with the borrow books
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetACustomerBook")]
        public async Task<IActionResult> GetCustomerBook(string Id)
        {
            var result = await _customerServices.GetCustomerBook(Id);
            if (result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Get all Exiting Customer
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerServices.GetCustomers();
            if (result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Update Exiting Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPatch("UpdateCustomer")]
        public async Task<IActionResult> Update(CustomerUpdateDto customer)
        {
            var result = await _customerServices.UpdateCustomer(customer);
            if (result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Customer borrows Book
        /// </summary>
        /// <param name="borrow"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPatch("BorrowBook")]
        public async Task<IActionResult> Borrow(BorrowRequestDto borrow)
        {
            var result = await _customerServices.CustomerBorrowBook(borrow);
            if (result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Customer returns the Book
        /// </summary>
        /// <param name="borrow"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPatch("ReturnBook")]
        public async Task<IActionResult> Return(BorrowRequestDto borrow)
        {
            var result = await _customerServices.CustomerReturnBook(borrow);
            if (result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Delete Existing Customer
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> Delete(string Id)
        {
            var result = await _customerServices.DeleteCustomer(Id);
            if (result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
