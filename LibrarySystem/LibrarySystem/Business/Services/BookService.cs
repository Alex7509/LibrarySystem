using LibrarySystem.Business.Interfaces;
using LibrarySystem.Data.Interfaces;
using LibrarySystem.Models.Entities;
using LibrarySystem.Models.Requests;

namespace LibrarySystem.Business.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<AddBookResponse> AddBook(AddBookRequest request)
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Year = request.Year,
                IsBorrowed = false
            };

            await _bookRepository.Add(book);

            return new AddBookResponse
            {
                Id = book.Id
            };
        }
    }
}
