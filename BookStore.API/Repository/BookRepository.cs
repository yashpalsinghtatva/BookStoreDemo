using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _dbContext;

        public BookRepository(BookStoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var books = await _dbContext.Books.Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).ToListAsync();

            return books;
        }
        public async Task<BookModel> GetBookByIdAsync(int id)
        {
            var book = await _dbContext.Books.Where(x => x.Id == id).Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).FirstOrDefaultAsync();

            return book;
        }
        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Title
            };
            _dbContext.Add(book);
            await _dbContext.SaveChangesAsync();
            return book.Id;
        }
        public async Task<int> UpdateBookAsync(int bookId, BookModel bookModel)
        {
            var book = new Books()
            {
                Id = bookId,
                Description = bookModel.Description,
                Title = bookModel.Title
            };
            _dbContext.Books.Update(book);
            return await _dbContext.SaveChangesAsync();

            //var book = await _dbContext.Books.FindAsync(bookId);
            //if (book != null)
            //{

            //    book.Description = bookModel.Description;
            //    book.Title = bookModel.Title;

            //    await _dbContext.SaveChangesAsync();
            //}
        }
        public async Task<int> DeleteBookAsync(int bookId)
        {
            var book = new Books()
            {
                Id = bookId
            };
            _dbContext.Books.Remove(book);
            return await _dbContext.SaveChangesAsync();
        }
    }
}

