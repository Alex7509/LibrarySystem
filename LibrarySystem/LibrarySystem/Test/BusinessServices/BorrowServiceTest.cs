using LibrarySystem.Business.Services;
using LibrarySystem.Data.Interfaces;
using LibrarySystem.Models.Entities;
using Moq;
using Xunit;

namespace LibrarySystem.Tests.BusinessServices;

public class BorrowServiceTests
{
    [Fact]
    public async Task BorrowBook_ShouldWork()
    {
        var bookRepo = new Mock<IBookRepository>();
        var memberRepo = new Mock<IMemberRepository>();

        bookRepo.Setup(x => x.GetById("1"))
            .ReturnsAsync(new Book());

        memberRepo.Setup(x => x.GetById("1"))
            .ReturnsAsync(new Member());

        var service = new BorrowService(bookRepo.Object, memberRepo.Object);

        await service.BorrowBook("1", "1");

        bookRepo.Verify(x => x.Update(It.IsAny<Book>()), Times.Once);
    }

    [Fact]
    public async Task BorrowBook_ShouldThrow_WhenBookMissing()
    {
        var bookRepo = new Mock<IBookRepository>();

        bookRepo.Setup(x => x.GetById("1"))
            .ReturnsAsync((Book?)null);

        var service = new BorrowService(bookRepo.Object,
            new Mock<IMemberRepository>().Object);

        await Assert.ThrowsAsync<Exception>(() =>
            service.BorrowBook("1", "1"));
    }
}

