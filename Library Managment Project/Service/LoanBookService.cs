using AutoMapper;
using Library_Managment_Project.DTOs.LoanBookDTOs;
using Library_Managment_Project.Entities;
using Library_Managment_Project.Enum;
using Library_Managment_Project.Interface;
using LibraryManagment.Data;
using Microsoft.EntityFrameworkCore;

namespace Library_Managment_Project.Service
{
    public class LoanBookService : ILoanBookService
    {
        private readonly ApplicationDBcontext _context;
        private readonly IMapper _mapper;

        public LoanBookService(ApplicationDBcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LoanBookResponse> LoanBook(LoanBookRequest loanBookRequest)
        {
            Book book = await _context.Book.FirstOrDefaultAsync(bookSelected => bookSelected.Code == loanBookRequest.BookCode);
            Member member = await _context.Member.FirstOrDefaultAsync(memberSelected => memberSelected.MemberCode == loanBookRequest.MemberCode);
            if(book == null )
                throw new Exception("Book not found");
            if(member == null)
                throw new Exception("Member not found");
            LoansBook loanBook =  new LoansBook()
            {
                BookId = book.Id,
                MemberId = member.Id,
                DateOfLoan = DateTime.Now,
                DateOfReturn = DateTime.Now.AddDays(7),
                LoanStatus = StatusOfLoans.Pending
            };

            _context.Add(loanBook);
            await _context.SaveChangesAsync();

            return new LoanBookResponse(loanBook);

        }

        public async Task<string> ReturnBook(ReturnLoanedBookRequest returnLoanedBookRequest)
        {
            LoansBook loanBook = await _context.
                                     LoansBooks.
                                     FirstOrDefaultAsync(loanBookSelected =>  loanBookSelected.Book.Code == returnLoanedBookRequest.BookCode && 
                                                                              loanBookSelected.Member.MemberCode == returnLoanedBookRequest.MemberCode);
            if( loanBook == null ) return "no Loan found  found";
            loanBook.LoanStatus = StatusOfLoans.Returned;
            await _context.SaveChangesAsync();
            return "Book Returned Successfully";
        }
    }
}
