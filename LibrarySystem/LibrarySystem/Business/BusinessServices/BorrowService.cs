using LibrarySystem.Business.Interfaces;
using LibrarySystem.Data.Interfaces;

namespace LibrarySystem.Business.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMemberRepository _memberRepository;

        public BorrowService(
            IBookRepository bookRepository,
            IMemberRepository memberRepository)
        {
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
        }

        public async Task BorrowBook(string bookId, string memberId)
        {
            var book = await _bookRepository.GetById(bookId);

            if (book == null)
                throw new Exception("Book not found");

            if (book.IsBorrowed)
                throw new Exception("Book already borrowed");

            var member = await _memberRepository.GetById(memberId);

            if (member == null)
                throw new Exception("Member not found");

            book.IsBorrowed = true;

            await _bookRepository.Update(book);
        }

        public async Task ReturnBook(string bookId)
        {
            var book = await _bookRepository.GetById(bookId);

            if (book == null)
                throw new Exception("Book not found");

            book.IsBorrowed = false;

            await _bookRepository.Update(book);
        }
    }
}
