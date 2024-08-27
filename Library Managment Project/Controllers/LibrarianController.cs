using Library_Managment_Project.DTOs.LibarianDTOs;
using Library_Managment_Project.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Library_Managment_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    #region Libarian
    public class LibrarianController : ControllerBase
    {
        #region Variables+Constractor
        private readonly ILibarianService _libarianService;
        public LibrarianController(ILibarianService libarianService) => _libarianService = libarianService;
        #endregion

        #region Get

        #region All
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNumber = 1, int pageSize = 10) => Ok(await _libarianService.GetAllAsync(pageNumber, pageSize));
        #endregion

        #region ById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByNumberAsync(int id) => Ok(await _libarianService.GetByNumberAsync(id));

        #endregion

        #endregion

        #region Add
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddLibarianRequest libarianRequest) => Ok(await _libarianService.AddAsync(libarianRequest));
        #endregion

        #region Update
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateLibarianRequest libarianRequest) => Ok(await _libarianService.UpdateAsync(libarianRequest));
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return (await _libarianService.DeleteAsync(id)) ? Ok("Deleted Successfully") : NotFound("Failed To Delete");
        }
        #endregion
    }
    #endregion
}
