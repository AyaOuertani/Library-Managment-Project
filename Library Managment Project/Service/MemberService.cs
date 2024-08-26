using Library_Managment_Project.DTOs.MemberDTOs;
using Library_Managment_Project.Entities;
using Library_Managment_Project.Enum;
using Library_Managment_Project.Interface;
using Library_Managment_Project.Models;
using LibraryManagment.Data;
using Microsoft.EntityFrameworkCore;

namespace Library_Managment_Project.Service
{
    #region Memeber
    public class MemberService : IMemberService
    {
        #region Variables+Constracor
        private readonly ApplicationDBcontext _dbcontext;
        public MemberService(ApplicationDBcontext dbcontext) => _dbcontext = dbcontext;
        #endregion

        #region Get

        #region All
        public async Task<PaginatedList<GetAllMembersResponce>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<GetAllMembersResponce> members = await _dbcontext.Member.Include(loan => loan.Loans)
                                                                         .Skip((pageNumber - 1) * pageSize)
                                                                         .Take(pageSize)
                                                                         .Select(memberSelected => new GetAllMembersResponce(memberSelected.MemberCode,
                                                                                                                             memberSelected.FirstName,
                                                                                                                             memberSelected.LastName,
                                                                                                                             memberSelected.Email,
                                                                                                                             memberSelected.phone,
                                                                                                                             memberSelected.MemberShipType,
                                                                                                                             memberSelected.Loans.Select(loanSelected => loanSelected.Book.Title).ToList(),
                                                                                                                             memberSelected.CreateAt,
                                                                                                                             memberSelected.UpdateAt)).ToListAsync();
            int count = members.Count();
            int totalPages = (int)Math.Ceiling(count / (double)pageSize);
            return new PaginatedList<GetAllMembersResponce>(members, pageNumber, totalPages);

        }
        #endregion

        #region ByNumber
        public async Task<GetMemberByNumberResponce> GetByNumberAsync(long number)
        {
            Member? selectedMember = await _dbcontext.Member.Include(m => m.Loans)
                                                            .ThenInclude(loan => loan.Book)
                                                            .FirstOrDefaultAsync(m => m.MemberCode == number);
            if (selectedMember == null)
                throw new KeyNotFoundException("Member Not Found!");
            List<GetLoanedBooksResponce> loanedBooks = selectedMember.Loans.Select(loan => new GetLoanedBooksResponce(loan.Book.Title,
                                                                                                                       loan.Book.Code,
                                                                                                                       loan.Book.Auther,
                                                                                                                       loan.LoanStatus,
                                                                                                                       loan.DateOfLoan,
                                                                                                                       loan.DateOfReturn)).ToList();
            return new GetMemberByNumberResponce(selectedMember.FirstName,
                                                  selectedMember.LastName,
                                                  selectedMember.Email,
                                                  selectedMember.phone,
                                                  selectedMember.MemberShipType,
                                                  loanedBooks,
                                                  selectedMember.CreateAt,
                                                  selectedMember.UpdateAt);

        }
        #endregion

        #region GetLoanedBook
        public async Task<PaginatedList<GetLoanedBooksResponce>> GetLoanedAsync(string memberId, int pageNumber, int pageSize)
        {
            List<LoansBook> loanedBook = await _dbcontext.LoansBooks.Include(loanSelected => loanSelected.Book)
                                                                   .Include(loanSelected => loanSelected.Member)
                                                                   .Where(loanSelected => loanSelected.Member.Id.Equals(memberId))
                                                                   .Where(loanSelected => loanSelected.LoanStatus == StatusOfLoans.Returned)
                                                                   .Skip((pageNumber - 1) * pageSize)
                                                                   .Take(pageSize)
                                                                   .ToListAsync();

            List<GetLoanedBooksResponce> responseList = loanedBook.Select(loanSelected => new GetLoanedBooksResponce(loanSelected.Book.Title,
                                                                                                                      loanSelected.Book.Code,
                                                                                                                      loanSelected.Book.Auther,
                                                                                                                      loanSelected.LoanStatus,
                                                                                                                      loanSelected.DateOfLoan,
                                                                                                                      loanSelected.DateOfReturn
                                                                                                                      )).ToList();
            int count = loanedBook.Count();
            int totalPages = (int)Math.Ceiling(count / (double)pageSize);
            return new PaginatedList<GetLoanedBooksResponce>(responseList, pageNumber, pageSize);
        }

        #endregion

        #region GetCurrentLoans
        public async Task<PaginatedList<GetCurrentLoansResponce>> GetCurrentLoansAsync(string memeberId, int pageNumber, int pageSize)
        {
            List<LoansBook> loanedBook = await _dbcontext.LoansBooks.Include(loanSelected => loanSelected.Book)
                                                                   .Include(loanSelected => loanSelected.Member)
                                                                   .Where(loanSelected => loanSelected.Member.Id.Equals(memeberId))
                                                                   .Where(loanSelected => loanSelected.LoanStatus == StatusOfLoans.Overdue || loanSelected.LoanStatus == StatusOfLoans.Pending)
                                                                   .Skip((pageNumber - 1) * pageSize)
                                                                   .Take(pageSize)
                                                                   .ToListAsync();
            List<GetCurrentLoansResponce> responseList = loanedBook.Select(loanSelected => new GetCurrentLoansResponce(loanSelected.Book.Title,
                                                                                                                     loanSelected.Book.Code,
                                                                                                                     loanSelected.Book.Auther,
                                                                                                                     loanSelected.LoanStatus,
                                                                                                                     loanSelected.DateOfLoan,
                                                                                                                     loanSelected.DateOfReturn)).ToList();
            int count = loanedBook.Count();
            int totalPages = (int)Math.Ceiling(count / (double)pageSize);
            return new PaginatedList<GetCurrentLoansResponce>(responseList, pageNumber, pageSize);

        }
        #endregion

        #endregion

        #region Add
        public async Task<AddMemberResponce> AddAsync(AddMemberRequest request)
        {
            Member newMember = new Member
            {
                Id = request.MemberId,
                MemberCode = request.MemberNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                phone = request.PhoneNumber,
                MemberShipType = request.MemberShipType,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
            };
            _dbcontext.Member.Add(newMember);
            await _dbcontext.SaveChangesAsync();
            return new AddMemberResponce(newMember.MemberCode, newMember.FirstName, newMember.LastName, newMember.Email, newMember.Password, newMember.phone, newMember.CreateAt, newMember.UpdateAt);

        }

        #endregion

        #region Update
        public async Task<UpdateMemberResponce> UpdateAsync(UpdateMemberRequest memberRequest)
        {
            Member member = _dbcontext.Member.Find(memberRequest.MemberNumber)
                                              ?? throw new KeyNotFoundException("Memeber Not Found");

          
            member.Email = memberRequest.Email is null || memberRequest.Email == "string" ? member.Email : memberRequest.Email;
            member.phone = memberRequest.PhoneNumber is 0  ? member.phone : memberRequest.PhoneNumber;
            member.MemberShipType = memberRequest.MemberShipType;
            member.UpdateAt = DateTime.Now;
            await _dbcontext.SaveChangesAsync();
            return new UpdateMemberResponce(member.MemberCode, 
                                            member.FirstName,
                                            member.LastName, 
                                            member.Email, 
                                            member.Password,
                                            member.phone,
                                            member.MemberShipType,
                                            member.CreateAt,
                                            member.UpdateAt);
        }
        #endregion

        #region Delete
        public async Task<bool> DeleteAsync(long memberNumber)
        {
            Member? member = await _dbcontext.Member.FindAsync(memberNumber)
                                                     ?? throw new KeyNotFoundException("Member Not Found");
            try
            {
                _dbcontext.Member.Remove(member);
                await _dbcontext.SaveChangesAsync();
            }
            catch { return false; }
            return true;
        }
        #endregion
    }
    #endregion

}
