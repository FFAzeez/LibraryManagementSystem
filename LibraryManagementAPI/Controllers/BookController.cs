using LibraryManagementAPI.Filters;
using LibraryManagementCore.DTOs.Request;
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
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookServices;
        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        /// <summary>
        /// Create New Book
        /// </summary>
        /// <param name="bookDto"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("CreateBook")]
        public async Task<IActionResult>  Create(BookDTO bookDto)
        {
            var result = await _bookServices.CreateBook(bookDto);
            if (result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Update Existing Book
        /// </summary>
        /// <param name="bookDto"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPatch("UpdateBook")]
        public async Task<IActionResult> Update(BookUpdateDto bookDto)
        {
            var result = await _bookServices.UpdateBook(bookDto);
            if (result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Get Existing Book
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetABook")]
        public async Task<IActionResult> Get(string Id)
        {
            var result = await _bookServices.GetBookById(Id);
            if (result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Get all Exiting Books
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bookServices.GetBooks();
            if (result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// Delete Existing Book
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("DeleteBook")]
        public async Task<IActionResult> Delete(string Id)
        {
            var result = await _bookServices.DeleteBook(Id);
            if (result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
