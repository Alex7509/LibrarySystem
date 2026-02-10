namespace LibrarySystem.Business.Interfaces
{
    public interface IBorrowService
    {
        Task BorrowBook(string bookId, string memberId);

        Task ReturnBook(string bookId);
    }
}
