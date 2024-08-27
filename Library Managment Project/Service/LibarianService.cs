using Library_Managment_Project.DTOs.LibarianDTOs;
using Library_Managment_Project.DTOs.MemberDTOs;
using Library_Managment_Project.Entities;
using Library_Managment_Project.Enum;
using Library_Managment_Project.Interface;
using Library_Managment_Project.Models;
using LibraryManagment.Data;
using Microsoft.EntityFrameworkCore;

namespace Library_Managment_Project.Service
{
    #region Libarian
    public class LibarianService : ILibarianService
    {

        #region Variables+Constracor
        private readonly ApplicationDBcontext _dbcontext;
        public LibarianService(ApplicationDBcontext dbcontext) => _dbcontext = dbcontext;
        #endregion

        #region Get

        #region All
        public async Task<PaginatedList<GetAllLibarianResponse>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<GetAllLibarianResponse> librarians = await _dbcontext.Librarian
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(librarianSelected => new GetAllLibarianResponse(
                    librarianSelected.Id,
                    librarianSelected.FirstName,
                    librarianSelected.LastName,
                    librarianSelected.Email,
                    librarianSelected.PhoneNumber,
                    librarianSelected.WorkSchedule
                ))
                .ToListAsync();

            int totalCount = await _dbcontext.Librarian.CountAsync();
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            return new PaginatedList<GetAllLibarianResponse>(librarians, pageNumber, pageSize);
        }
    #endregion

        #region ById
    public async Task<GetLibarianByIdResponse> GetByNumberAsync(int id)
        {
            Librarian? libarianSelected = await _dbcontext.Librarian.FindAsync(id);
            if (libarianSelected == null)
                throw new KeyNotFoundException("Member Not Found!");

            return new GetLibarianByIdResponse(libarianSelected.FirstName,
                                               libarianSelected.LastName,
                                               libarianSelected.Email,
                                               libarianSelected.phone,
                                               libarianSelected.WorkSchedule);
        }
        #endregion

        #endregion

        #region Add
        public async Task<AddLibarianResponse> AddAsync(AddLibarianRequest request)
        {
            Librarian newLibarian = new Librarian
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                phone = request.PhoneNumber,
                WorkSchedule = request.WorkSchedule
            };
            _dbcontext.Librarian.Add(newLibarian);
            await _dbcontext.SaveChangesAsync();
            return new AddLibarianResponse(newLibarian.Id,
                                           newLibarian.FirstName,
                                           newLibarian.LastName,
                                           newLibarian.Email,
                                           newLibarian.phone,
                                           newLibarian.WorkSchedule);

        }

        #endregion

        #region Update
        public async Task<UpdateLibarianResponse> UpdateAsync(UpdateLibarianRequest request)
        {
            Librarian libarian = _dbcontext.Librarian.Find(request.Id)
                                              ?? throw new KeyNotFoundException("Libarian Not Found");


            libarian.Email = request.Email is null || request.Email == "string" ? libarian.Email : request.Email;
            libarian.phone = request.PhoneNumber is 0 ? libarian.phone : request.PhoneNumber;
            libarian.WorkSchedule = request.WorkSchedule;
            libarian.UpdateAt = DateTime.Now;
            await _dbcontext.SaveChangesAsync();
            return new UpdateLibarianResponse(libarian.Id,
                                              libarian.FirstName,
                                              libarian.LastName,
                                              libarian.Email,
                                              libarian.phone,
                                              libarian.WorkSchedule);
        }
        #endregion

        #region Delete
        public async Task<bool> DeleteAsync(int id)
        {
            Librarian? librarian = await _dbcontext.Librarian.FindAsync(id)
                                                     ?? throw new KeyNotFoundException("Libarian Not Found");
            try
            {
                _dbcontext.Librarian.Remove(librarian);
                await _dbcontext.SaveChangesAsync();
            }
            catch { return false; }
            return true;
        }
        #endregion
    }
    #endregion
}
