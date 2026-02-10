using LibrarySystem.Models.Entities;

namespace LibrarySystem.Data.Interfaces
{
    public interface IMemberRepository
    {
        Task Add(Member member);

        Task<Member?> GetById(string id);

        Task<List<Member>> GetAll();
    }
}
