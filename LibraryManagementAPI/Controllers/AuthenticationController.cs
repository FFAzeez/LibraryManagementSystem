using LibraryManagementCore.DTOs.Requests;
using LibraryManagementCore.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IClientServices _clientServices;
        public AuthenticationController(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }

        /// <summary>
        /// Register a new Client.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("Registration")]
        public async Task<IActionResult>  Registration(ClientDto client)
        {
            var result = await _clientServices.RegisterClient(client);
            if (result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Log in Existing Client.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        /// [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto client)
        {
            var result = await _clientServices.LoginClient(client);
            if (result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
