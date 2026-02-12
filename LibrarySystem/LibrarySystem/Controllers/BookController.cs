using LibrarySystem.Business.Interfaces;
using LibrarySystem.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(AddBookRequest request)
    {
        var response = await _bookService.AddBook(request);

        return Ok(response);
    }
}


