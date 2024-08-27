using Library_Managment_Project.Interface;
using Library_Managment_Project.Service;
using Microsoft.AspNetCore.Authorization;
using Library_Managment_Project.DTOs.BookDTOs;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using Library_Managment_Project.Entities;

namespace Library_Managment_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    #region Book
    public class BookController : ControllerBase
    {
        #region Variable+Constructor
        private readonly IBooksService _bookService;
        public BookController(IBooksService bookService) => _bookService = bookService;
        #endregion

        #region Get

        #region All
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNumber =1 , int pageSize = 10) => Ok(await _bookService.GetAllAsync(pageNumber, pageSize));
        #endregion

        #region ByCode
        [HttpGet("SearchByCode/{code}")]
        public async Task<IActionResult> GetByCodeAsync(int code) => Ok(await _bookService.GetByCodeAsync(code));
        #endregion

        #region ByTitle
        [HttpGet("SearchByTitle/{title}")]
        public async Task<IActionResult> GetByTitle(string title) => Ok(await _bookService.GetByTitleAsync(title));
        #endregion

        #region ByAuther
        [HttpGet("SearchByAuther/{auther}")]
        public async Task<IActionResult> GetByAuthor(string auther,int pageNumber = 1, int pageSize = 10) => Ok(await _bookService.GetByAuthorAsync(auther, pageNumber,pageSize));
        #endregion

        #region ByAvailability
        [HttpGet("Availability")]
        public async Task<IActionResult> GetByAvailability(int pageNumber = 1, int pageSize =10) => Ok(await _bookService.GetByAvailabilityAsync(pageNumber, pageSize));

        #endregion

        #endregion

        #region Add
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddBookRequest bookRequest) => Ok(await _bookService.AddAsync(bookRequest));
     
        #endregion

        #region Update
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBookRequest updateRequest) => Ok(await _bookService.UpdateAsync(updateRequest));
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync (int id)
        { 
            return (await _bookService.DeleteAsync(id)) ? Ok("Deleted Successfully") : NotFound("Failed To Delete");
        }
        #endregion

    }
    #endregion
}
