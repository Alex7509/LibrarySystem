using LibrarySystem.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers;

[ApiController]
[Route("api/borrow")]
public class BorrowController : ControllerBase
{
    private readonly IBorrowService _borrowService;

    public BorrowController(IBorrowService borrowService)
    {
        _borrowService = borrowService;
    }

    [HttpPost("{bookId}/{memberId}")]
    public async Task<IActionResult> Borrow(string bookId, string memberId)
    {
        await _borrowService.BorrowBook(bookId, memberId);

        return Ok();
    }

    [HttpPost("return/{bookId}")]
    public async Task<IActionResult> Return(string bookId)
    {
        await _borrowService.ReturnBook(bookId);

        return Ok();
    }
}
