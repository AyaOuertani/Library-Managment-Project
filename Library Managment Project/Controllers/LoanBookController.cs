using AutoMapper;
using Library_Managment_Project.DTOs.LoanBookDTOs;
using Library_Managment_Project.Service;
using LibraryManagment.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Managment_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanBookController : ControllerBase
    {
        private readonly LoanBookService _loanBookService;
        public LoanBookController(ApplicationDBcontext context, IMapper mapper)
        {
            _loanBookService = new LoanBookService(context, mapper);
        }
        [HttpPost]
        public async Task<IActionResult> LoanBook(LoanBookRequest loanBookRequest)
        {

            return Ok(await _loanBookService.LoanBook(loanBookRequest));


        }
        [HttpPut]
        public async Task<IActionResult> ReturnBook(ReturnLoanedBookRequest returnLoanedBookRequest)
        {
            return Ok(await _loanBookService.ReturnBook(returnLoanedBookRequest));
        } 
    }
}
