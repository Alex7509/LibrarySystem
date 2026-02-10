using LibrarySystem.Data.Interfaces;
using LibrarySystem.Data.Settings;
using LibrarySystem.Models.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LibrarySystem.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _collection;

        public BookRepository(IOptionsMonitor<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.CurrentValue.ConnectionString);

            var database = client.GetDatabase(settings.CurrentValue.DatabaseName);

            _collection = database.GetCollection<Book>(
                settings.CurrentValue.BooksCollection);
        }

        public async Task Add(Book book)
            => await _collection.InsertOneAsync(book);

        public async Task<Book?> GetById(string id)
            => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<List<Book>> GetAll()
            => await _collection.Find(_ => true).ToListAsync();

        public async Task Update(Book book)
            => await _collection.ReplaceOneAsync(x => x.Id == book.Id, book);

        public async Task Delete(string id)
            => await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
