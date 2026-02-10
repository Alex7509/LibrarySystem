namespace LibrarySystem.Models.Entities
{
    public class Book
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public int Year { get; set; }

        public bool IsBorrowed { get; set; }
    }
}
