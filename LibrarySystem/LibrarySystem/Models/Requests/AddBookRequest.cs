namespace LibrarySystem.Models.Requests
{
    public class AddBookRequest
    {
        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public int Year { get; set; }
    }
}
