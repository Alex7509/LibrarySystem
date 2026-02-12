using Mapster;
using LibrarySystem.Models.Entities;
using LibrarySystem.Models.Requests;

namespace LibrarySystem.Common.Mappings;

public static class MappingConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<AddBookRequest, Book>.NewConfig();
        TypeAdapterConfig<Book, AddBookResponse>.NewConfig()
            .Map(dest => dest.Id, src => src.Id);

        TypeAdapterConfig<AddMemberRequest, Member>.NewConfig();
        TypeAdapterConfig<Member, AddMemberResponse>.NewConfig()
            .Map(dest => dest.Id, src => src.Id);
    }
}
