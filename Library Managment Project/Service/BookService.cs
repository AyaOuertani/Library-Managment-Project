using Library_Managment_Project.DTOs.BookDTOs;
using Library_Managment_Project.Entities;
using Library_Managment_Project.Interface;
using Library_Managment_Project.Models;
using LibraryManagment.Data;
using Microsoft.EntityFrameworkCore;

namespace Library_Managment_Project.Service
{
    public class BookService : IBooksService
    {
        #region Variables+Constractor
        private readonly ApplicationDBcontext _dbcontext;
        public BookService(ApplicationDBcontext dbcontext) => _dbcontext = dbcontext;
        #endregion

        #region Get

        #region All
        public async Task<PaginatedList<GetAllBooksResponce>> GetAllAsync(int pageNumber, int pageSize)
        {
            List<GetAllBooksResponce> books = await _dbcontext.Book.Skip((pageNumber - 1) * pageSize)
                                                                   .Take(pageSize)
                                                                   .Select(b => new GetAllBooksResponce(b.Title,
                                                                                                        b.Code,
                                                                                                        b.Auther,
                                                                                                        b.Qte,
                                                                                                        b.About,
                                                                                                        b.Category,
                                                                                                        b.PublishDate)).ToListAsync();
            int count = await _dbcontext.Book.CountAsync();
            int totalPages = (int)Math.Ceiling(count / (double)pageSize);
            return new PaginatedList<GetAllBooksResponce>(books, pageNumber, totalPages);
        }
        #endregion


        #region ByCode
        public async Task<GetBookByCodeResponce> GetByCodeAsync(int code)
        {
            Book? searchedBook = await _dbcontext.Book.FirstOrDefaultAsync(bookSelected => bookSelected.Code == code);
            if (searchedBook == null)
                throw new KeyNotFoundException("Book NoT Found !");
            return new GetBookByCodeResponce(searchedBook.ID,
                                           searchedBook.Title,
                                           searchedBook.Auther,
                                           searchedBook.Qte,
                                           searchedBook.About,
                                           searchedBook.Category,
                                           searchedBook.PublishDate,
                                           searchedBook.CreatedDate,
                                           searchedBook.UpdatedDate);
        }
        #endregion

        #region ByTitle
        public async Task<GetBookByTitleResponce> GetByTitleAsync(string title)
        {
            Book? searchedBook = await _dbcontext.Book.FirstOrDefaultAsync(bookSelected => bookSelected.Title.ToUpper() == title.ToUpper());
            if (searchedBook == null)
                throw new KeyNotFoundException("Book Not Found");
            return new GetBookByTitleResponce(searchedBook.ID,
                                              searchedBook.Code,
                                              searchedBook.Auther,
                                              searchedBook.Qte,
                                              searchedBook.About,
                                              searchedBook.Category,
                                              searchedBook.PublishDate,
                                              searchedBook.CreatedDate,
                                              searchedBook.UpdatedDate);
        }
        #endregion

        #region ByAuther
        public async Task<PaginatedList<GetBookByAutherResponce>> GetByAutherAsync(string auther, int pageNumber, int pageSize)
        {
            List<Book> searchedBooks = await _dbcontext.Book.Where(bookSelected => bookSelected.Auther.ToUpper() == auther.ToUpper())
                                                            .Skip((pageNumber - 1) * pageSize)
                                                            .Take(pageSize)
                                                            .ToListAsync();

            if (searchedBooks.Count == 0)
                throw new KeyNotFoundException("Author Not Found!");

            List<GetBookByAutherResponce> responseList = searchedBooks.Select(book => new GetBookByAutherResponce(
                book.ID,
                book.Title,
                book.Code,
                book.Qte,
                book.About,
                book.Category,
                book.PublishDate,
                book.CreatedDate,
                book.UpdatedDate
            )).ToList();
            int count = searchedBooks.Count();
            int totalPages = (int)Math.Ceiling(count / (double)pageSize);
            return new PaginatedList<GetBookByAutherResponce>(responseList, pageNumber, pageSize);
        }

        #endregion

        #region ByAvailability
        public async Task<PaginatedList<GetBookByAvailabilityResponce>> GetByAvailabilityAsync(int pageNumber, int pageSize)
        {
            List<Book> availableBooks = await _dbcontext.Book.Where(b => b.Qte > 0)
                                                             .Skip((pageNumber - 1) * pageSize)
                                                             .Take(pageSize)
                                                             .ToListAsync();
            if (availableBooks.Count == 0)
                throw new KeyNotFoundException("Not Found");
            List<GetBookByAvailabilityResponce> responseList = availableBooks.Select(b => new GetBookByAvailabilityResponce(b.ID,
                                                                                                                            b.Title,
                                                                                                                            b.Code,
                                                                                                                            b.Auther,
                                                                                                                            b.Qte,
                                                                                                                            b.About,
                                                                                                                            b.Category,
                                                                                                                            b.PublishDate,
                                                                                                                            b.CreatedDate,
                                                                                                                            b.UpdatedDate)).ToList();
            int count = availableBooks.Count();
            int totalPages = (int)Math.Ceiling(count / (double)pageSize);
            return new PaginatedList<GetBookByAvailabilityResponce>(responseList, pageNumber, pageSize);
        }




        #endregion

        #endregion

        #region Add
        public async Task<AddBookResponce> AddAsync(AddBookRequest book)
        {
            Book newBook = new Book
            {
                ID = book.ID,
                Title = book.Title,
                Code = book.Code,
                Auther = book.Auther,
                Qte = book.Qte,
                About = book.Auther,
                Category = book.Category,
                PublishDate = book.PublishDate,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            _dbcontext.Add(newBook);
            await _dbcontext.SaveChangesAsync();
            return new AddBookResponce(newBook.ID,
                                       newBook.Title,
                                       newBook.Code,
                                       newBook.Auther,
                                       newBook.Qte,
                                       newBook.About,
                                       newBook.Category,
                                       newBook.PublishDate,
                                       newBook.CreatedDate,
                                       newBook.UpdatedDate);
        }
        #endregion

        #region Update
        public async Task<UpdateBookResponce> UpdateAsync(UpdateBookRequest book)
        {

            Book? bookInDb = await _dbcontext.Book.FindAsync(book.Id);
            if (bookInDb == null)
                throw new KeyNotFoundException("Book not found");
            bookInDb.Qte = book.Qte;
            bookInDb.Qte = book.Qte;
            bookInDb.About = book.About;
            bookInDb.UpdatedDate = DateTime.Now;
            await _dbcontext.SaveChangesAsync();
            return new UpdateBookResponce(bookInDb.ID,
                                          bookInDb.Title,
                                          bookInDb.Code,
                                          bookInDb.Auther,
                                          bookInDb.Qte,
                                          bookInDb.About,
                                          bookInDb.Category,
                                          bookInDb.PublishDate,
                                          bookInDb.CreatedDate,
                                          bookInDb.UpdatedDate);
        }
        #endregion

        #region Delete
        public async Task<bool> DeleteAsync(string id)
        {
            Book? bookInDb = await _dbcontext.Book.FindAsync(id);
            if (bookInDb == null)
                return false;
            _dbcontext.Book.Remove(bookInDb);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        #endregion
    }

}
