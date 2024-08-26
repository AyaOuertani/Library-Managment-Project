using Library_Managment_Project.DTOs.BookDTOs;
using Library_Managment_Project.Interface;
using Library_Managment_Project.Entities;
using LibraryManagment.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Diagnostics;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.Mvc;

namespace Library_Managment_Project.Service
{
    public class BookService : IBooksService
    {
        #region Variables+Constractor
        private readonly ApplicationDBcontext _dbcontext;
        public BookService(ApplicationDBcontext dbcontext) => _dbcontext = dbcontext;
        #endregion

        #region Get

        #region ByCode
        public async Task<GetBookByCodeResponse> GetByCodeAsync(int code)
        {
            Book? searchedBook = await _dbcontext.Book.FirstOrDefaultAsync(bookSelected => bookSelected.Code == code );
            if (searchedBook == null) 
               throw new KeyNotFoundException("Book NoT Found !");
            return new GetBookByCodeResponse(searchedBook.Id,
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
        public async Task<GetBookByTitleResponse> GetByTitleAsync(string title)
        {
            Book? searchedBook = await _dbcontext.Book.FirstOrDefaultAsync(bookSelected => bookSelected.Title.ToUpper() == title.ToUpper());
            if (searchedBook == null) 
                throw new KeyNotFoundException("Book Not Found");
            return new GetBookByTitleResponse(searchedBook.Id, 
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
        public async Task<GetBookByAuthorResponse> GetByAutherAsync(string auther)
        {
            Book? searchedBoook = await _dbcontext.Book.FirstOrDefaultAsync(bookSelected => bookSelected.Auther.ToUpper() == auther.ToUpper());
            if (searchedBoook == null)
                throw new KeyNotFoundException("Auther Not Found!");
            return new GetBookByAuthorResponse(searchedBoook.Id, 
                                               searchedBoook.Title, 
                                               searchedBoook.Code, 
                                               searchedBoook.Qte, 
                                               searchedBoook.About, 
                                               searchedBoook.Category, 
                                               searchedBoook.PublishDate, 
                                               searchedBoook.CreatedDate, 
                                               searchedBoook.UpdatedDate);
        }
        #endregion

        #region ByAvailability
        public async Task<IEnumerable<GetBookByAvailabilityResponce>> GetByAvailabilityAsync()
        {
            List<Book> availableBooks = await _dbcontext.Book.Where(b => b.Qte > 0).ToListAsync();
            return availableBooks.Count == 0
                ? throw new KeyNotFoundException("Not Found")
                : (IEnumerable<GetBookByAvailabilityResponce>) availableBooks.Select(b => new GetBookByAvailabilityResponce(b.Id, b.Title, b.Code, b.Auther, b.Qte, b.About, b.Category, b.PublishDate, b.CreatedDate, b.UpdatedDate));

        }
        #endregion

        #endregion

        #region Add
        public async Task<AddBookResponse> AddAsync(AddBookRequest book)
        {
            Book newBook = new Book
            {
                Id = book.Id,
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
            return new AddBookResponse(newBook.Id,
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
        public async Task<UpdateBookResponse> UpdateAsync(UpdateBookRequest book)
        {

            Book? bookInDb = await _dbcontext.Book.FindAsync(book.Id);
            if (bookInDb == null)
                throw new KeyNotFoundException("Book not found");
            bookInDb.Qte = book.Qte;
            bookInDb.Qte = book.Qte;
            bookInDb.About = book.About;
            bookInDb.UpdatedDate = DateTime.Now;
            await _dbcontext.SaveChangesAsync();
            return new UpdateBookResponse(bookInDb.Id, 
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
        public async Task<bool> DeleteAsync (string id)
        {
            Book? bookInDb = await _dbcontext.Book.FindAsync(id);
            if (bookInDb == null)
                return false;
            _dbcontext.Book.Remove(bookInDb);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
        #endregion
}
