using LibrarySystem.Data.Interfaces;
using LibrarySystem.Data.Settings;
using LibrarySystem.Models.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LibrarySystem.Data.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IMongoCollection<Member> _collection;

        public MemberRepository(IOptionsMonitor<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.CurrentValue.ConnectionString);

            var database = client.GetDatabase(settings.CurrentValue.DatabaseName);

            _collection = database.GetCollection<Member>(
                settings.CurrentValue.MembersCollection);
        }

        public async Task Add(Member member)
            => await _collection.InsertOneAsync(member);

        public async Task<Member?> GetById(string id)
            => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<List<Member>> GetAll()
            => await _collection.Find(_ => true).ToListAsync();

    }
}
