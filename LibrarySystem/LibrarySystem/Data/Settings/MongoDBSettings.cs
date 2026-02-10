namespace LibrarySystem.Data.Settings
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string BooksCollection { get; set; } = null!;

        public string MembersCollection { get; set; } = null!;
    }
}
