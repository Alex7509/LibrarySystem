using LibrarySystem.Models.Entities;

namespace LibrarySystem.Data.Interfaces
{
    public interface IBookRepository
    {
        Task Add(Book book);

        Task<Book?> GetById(string id);

        Task<List<Book>> GetAll();

        Task Update(Book book);

        Task Delete(string id);
    }
}
