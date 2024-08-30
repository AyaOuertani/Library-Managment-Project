using Library_Managment_Project.DTOs.LibarianDTOs;
using Library_Managment_Project.Entities;
using Library_Managment_Project.Interface;
using Library_Managment_Project.Models;
using LibraryManagment.Data;
using Microsoft.EntityFrameworkCore;

namespace Library_Managment_Project.Service
{
    #region Libarian
    public class LibrarianService : ILibrarianService
    {

        #region Variables+Constracor
        private readonly ApplicationDBcontext _dbcontext;
        public LibrarianService(ApplicationDBcontext dbcontext) => _dbcontext = dbcontext;
        #endregion

        #region Get

        #region All
        public async Task<PaginatedList<GetAllLibrarianResponse>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<GetAllLibrarianResponse> librarians = await _dbcontext.Librarian.Skip((pageNumber - 1) * pageSize)
                                                                                .Take(pageSize)
                                                                                .Select(librarianSelected => new GetAllLibrarianResponse(librarianSelected.Id,
                                                                                                                                        librarianSelected.FirstName,
                                                                                                                                        librarianSelected.LastName,
                                                                                                                                        librarianSelected.Email,
                                                                                                                                        librarianSelected.Phone,
                                                                                                                                        librarianSelected.WorkSchedule))
                                                                                                                                        .ToListAsync();

            int totalCount = await _dbcontext.Librarian.CountAsync();
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            return new PaginatedList<GetAllLibrarianResponse>(librarians, pageNumber, pageSize);
        }
        #endregion

        #region ById
        public async Task<GetLibrarianByIdResponse> GetByNumberAsync(int id)
        {
            Librarian? librarianSelected = await _dbcontext.Librarian.FindAsync(id);
            if (librarianSelected == null)
                throw new KeyNotFoundException("Librarian Not Found!");

            return new GetLibrarianByIdResponse(librarianSelected.FirstName,
                                               librarianSelected.LastName,
                                               librarianSelected.Email,
                                               librarianSelected.Phone,
                                               librarianSelected.WorkSchedule);
        }
        #endregion

        #endregion

        #region Add
        public async Task<AddLibrarianResponse> AddAsync(AddLibrarianRequest request)
        {
            Librarian librarian = new Librarian
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.PhoneNumber,
                WorkSchedule = request.WorkSchedule,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };
            _dbcontext.Librarian.Add(librarian);
            await _dbcontext.SaveChangesAsync();
            return new AddLibrarianResponse(librarian.Id,
                                           librarian.FirstName,
                                           librarian.LastName,
                                           librarian.Email,
                                           librarian.Phone,
                                           librarian.WorkSchedule,
                                           librarian.CreateAt);

        }

        #endregion

        #region Update
        public async Task<UpdateLibrarianResponse> UpdateAsync(UpdateLibrarianRequest request)
        {
            Librarian librarian = _dbcontext.Librarian.Find(request.Id)
                                              ?? throw new KeyNotFoundException("Librarian Not Found");
            librarian.Email = request.Email ?? librarian.Email;
            librarian.Phone = request.PhoneNumber ?? librarian.Phone;
            librarian.WorkSchedule = request.WorkSchedule??librarian.WorkSchedule;
            librarian.FirstName = request.FirstName ?? librarian.FirstName;
            librarian.LastName = request.LastName ?? librarian.LastName;
            librarian.PhoneNumber = request.PhoneNumber ?? librarian.PhoneNumber;
            librarian.Password = request.Password ?? librarian.Password;
            librarian.UpdateAt = DateTime.Now;
            await _dbcontext.SaveChangesAsync();
            return new UpdateLibrarianResponse(librarian.Id,
                                              librarian.FirstName,
                                              librarian.LastName,
                                              librarian.Email,
                                              librarian.Phone,
                                              librarian.WorkSchedule);
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
