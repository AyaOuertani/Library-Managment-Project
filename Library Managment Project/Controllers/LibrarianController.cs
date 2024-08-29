using Library_Managment_Project.DTOs.LibarianDTOs;
using Library_Managment_Project.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Library_Managment_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    #region Librarian
    public class LibrarianController : ControllerBase
    {
        #region Variables+Constractor
        private readonly ILibrarianService _librarianService;
        public LibrarianController(ILibrarianService libarianService) => _librarianService = libarianService;
        #endregion

        #region Get

        #region All
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNumber = 1, int pageSize = 10) => Ok(await _librarianService.GetAllAsync(pageNumber, pageSize));
        #endregion

        #region ById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByNumberAsync(int id) => Ok(await _librarianService.GetByNumberAsync(id));

        #endregion

        #endregion

        #region Add
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddLibrarianRequest librarianRequest) => Ok(await _librarianService.AddAsync(librarianRequest));
        #endregion

        #region Update
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateLibrarianRequest librarianRequest) => Ok(await _librarianService.UpdateAsync(librarianRequest));
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return (await _librarianService.DeleteAsync(id)) ? Ok("Deleted Successfully") : NotFound("Failed To Delete");
        }
        #endregion
    }
    #endregion
}
