using LibrarySystem.Business.Interfaces;
using LibrarySystem.Data.Interfaces;
using LibrarySystem.Models.Entities;
using LibrarySystem.Models.Requests;

namespace LibrarySystem.Business.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<AddMemberResponse> AddMember(AddMemberRequest request)
        {
            var member = new Member
            {
                Name = request.Name,
                Email = request.Email
            };

            await _memberRepository.Add(member);

            return new AddMemberResponse
            {
                Id = member.Id
            };
        }
    }
}
