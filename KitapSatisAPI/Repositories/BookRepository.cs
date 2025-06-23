using KitapSatisAPI.Data;
using KitapSatisAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace KitapSatisAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly KitapDbContext _context;

        public BookRepository(KitapDbContext context)
        {
            _context = context;
        }

        public async Task<Book> AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteAsync(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}

