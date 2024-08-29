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
            if (book == null)
                throw new Exception("Book not found");
            if (member == null)
                throw new Exception("Member not found");
            if (book.Qte == 0)
                throw new Exception("Book is not available");
            if (await _context.LoansBooks.FirstOrDefaultAsync(loanBook => loanBook.Book.Id == book.Id &&
                                                                          loanBook.Member.Id == member.Id &&
                                                                          (loanBook.LoanStatus == StatusOfLoans.Pending
                                                                          || loanBook.LoanStatus == StatusOfLoans.Overdue)) != null)
                throw new Exception("Book is already loaned by this member");
            LoansBook loanBook = new LoansBook()
            {
                BookId = book.Id,
                MemberId = member.Id,
                DateOfLoan = DateTime.Now,
                DateOfReturn = DateTime.Now.AddDays(7),
                LoanStatus = StatusOfLoans.Pending
            };
            book.Qte--;
            _context.Add(loanBook);
            _context.Update(book);
            await _context.SaveChangesAsync();
            return new LoanBookResponse(loanBook);
        }
        public async Task<string> ReturnBook(ReturnLoanedBookRequest returnLoanedBookRequest)
        {
            LoansBook? loanBook = await _context.
                                     LoansBooks.
                                     FirstOrDefaultAsync(loanBookSelected => loanBookSelected.Book.Code == returnLoanedBookRequest.BookCode &&
                                                                              loanBookSelected.Member.MemberCode == returnLoanedBookRequest.MemberCode &&
                                                                              (loanBookSelected.LoanStatus == StatusOfLoans.Pending || loanBookSelected.LoanStatus == StatusOfLoans.Overdue));
            if (loanBook == null) return "no Loan found  found";
            Book? book = await _context.Book.FindAsync(loanBook.BookId);
            book.Qte++;
            _context.Update(book);
            loanBook.LoanStatus = StatusOfLoans.Returned;
            await _context.SaveChangesAsync();
            return "Book Returned Successfully";
        }
    }
}
