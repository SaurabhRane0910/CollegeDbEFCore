using CollegeDbEC.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeDbEC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public BookController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpPost("AddBookAsync")]
        public async Task<IActionResult> AddBookAsync([FromBody] BookDto bookDto)
        {


            var book = new Book()
            {
                Id = bookDto.BookId,
                Name = bookDto.BookName,
                Description = bookDto.BookDescription,
                NoOfPagaes = bookDto.NoOfPagaes,
                IsActive = bookDto.IsActive,
                LanguageId = bookDto.LanguageId,
                Author_id = bookDto.Author_id

            };
            await _appDbContext.Books.AddAsync(book);

            await _appDbContext.SaveChangesAsync();

            return Ok(bookDto);
        }

        [HttpPost("AddBookBulkAsync")]
        public async Task<IActionResult> AddBookBulkAsync([FromBody] List<BookDto> bookDto)
        {


            var book = bookDto.Select(bookDtos => new Book
            {
                Id = bookDtos.BookId,
                Name = bookDtos.BookName,
                Description = bookDtos.BookDescription,
                NoOfPagaes = bookDtos.NoOfPagaes,
                IsActive = bookDtos.IsActive,
                LanguageId = bookDtos.LanguageId,
                Author_id = bookDtos.Author_id

            }).ToList();
            await _appDbContext.Books.AddRangeAsync(book);

            await _appDbContext.SaveChangesAsync();

            return Ok(bookDto);
        }






        [HttpGet("GetAllBookAsync")]
        public async Task<IActionResult> GetAllBookAsync()
        {
          var result = await _appDbContext.Books.FromSqlRaw("Call GetAllBooks()").ToListAsync();

            return Ok(result);
        }


        [HttpGet("GetBookByIdAsync/{id}")]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            var result = await _appDbContext.Books.Where(i  => i.Id == id).ToListAsync();
            return Ok(result);
        }



        [HttpGet("GetBookByIdOnlyTitileAndIdAsync/{id}")]
        public async Task<IActionResult> GetBookByIdOnlyTitileAndIdAsync(int id)
        {
            var result = await _appDbContext.Books.Where(i => i.Id == id)
                .Select(x => new {
                      BookId =x.Id,
                     BookName = x.Name

                    } ).ToListAsync();
                
            return Ok(result);
        }



        [HttpPut("UpdateBook/{Id}")]
       public async Task<IActionResult> UpdateBookById([FromRoute]  int Id,  [FromBody] BookDto bookDto)
        {

            var mybook = await _appDbContext.Books.FirstOrDefaultAsync( x => x.Id == Id );

            if(mybook == null)
            {
                return BadRequest("Not Found");
            }

            mybook.Name = bookDto.BookName;
            mybook.NoOfPagaes = bookDto.NoOfPagaes;
            mybook.Description = bookDto.BookDescription;
            mybook.IsActive = bookDto.IsActive;
            mybook.Author_id =bookDto.Author_id;
            mybook.LanguageId=bookDto.LanguageId;

            await _appDbContext.SaveChangesAsync();
            return Ok(mybook);
        }


        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBookById([FromRoute]int bookId)
        {
            var result = await _appDbContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);

            if (result == null)
            {
                return BadRequest("Not found");
            }

            _appDbContext.Books.Remove(result);
            await _appDbContext.SaveChangesAsync();
            return Ok(result);
        }

        

    }
}
