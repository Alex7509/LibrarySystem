using LibrarySystem.Models.Requests;

namespace LibrarySystem.Business.Interfaces
{
    public interface IMemberService
    {
        Task<AddMemberResponse> AddMember(AddMemberRequest request);
    }
}
