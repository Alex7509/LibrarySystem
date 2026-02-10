using LibrarySystem.Models.Requests;

namespace LibrarySystem.Business.Interfaces
{
    public interface IBookService
    {
        Task<AddBookResponse> AddBook(AddBookRequest request);
    }
}
