using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Dtos;
using Domain.Dtos.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository repository;

        public BookService(IBookRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(BookDto book)
        {

            await repository.CreateAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books = await repository.GetAllAsync<BookDto>();
            return books;

        }

        public async Task<BookDto> GetByIdAsync(int id)
        {
            var book = await repository.GetByIdAsync<BookDto>(id);
            return book;
        }

        public async Task UpdateAsync(BookDto book)
        {
            await repository.UpdateAsync(book);
        }

    }
}
