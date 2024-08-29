using Library_Managment_Project.DTOs.MemberDTOs;
using Library_Managment_Project.Interface;
using Library_Managment_Project.Service;
using Microsoft.AspNetCore.Mvc;
namespace Library_Managment_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    #region Member
    public class MemberController : ControllerBase
    {
        #region Variables+Constractor
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService) => _memberService = memberService;
        #endregion

        #region Get

        #region All
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNumber = 1, int pageSize = 10) => Ok(await _memberService.GetAllAsync(pageNumber, pageSize));
        #endregion

        #region ByNumber
        [HttpGet("Member-Number/{number}")]
        public async Task<IActionResult> GetByNumberAsync(long number) => Ok(await _memberService.GetByNumberAsync(number));

        #endregion

        #region LoanedBooks
        [HttpGet("loaned-books/{memberId}")]
        public async Task<IActionResult> GetLoanedAsync(int memberId, int pageNumber = 1, int pageSize = 10) => Ok(await _memberService.GetLoanedAsync(memberId, pageNumber, pageSize));
        #endregion

        #region CurrentLoans
        [HttpGet("Current-Loans/{memberId}")]
        public async Task<IActionResult> GetCurrentLoansAsync(int memberId, int pageNumber = 1, int pageSize = 10) => Ok(await _memberService.GetCurrentLoansAsync(memberId, pageNumber, pageSize));
        #endregion

        #endregion

        #region Add
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddMemberRequest memberRequest) => Ok(await _memberService.AddAsync(memberRequest));
        #endregion

        #region Update
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateMemberRequest memberRequest) => Ok(await _memberService.UpdateAsync(memberRequest));
        #endregion

        #region Delete
        [HttpDelete("{number}")]
        public async Task<IActionResult> DeleteAsync(long number)
        {
            return (await _memberService.DeleteAsync(number)) ? Ok("Deleted Successfully") : NotFound("Failed To Delete");
        }
        #endregion
    }
    #endregion
}
