using AutoMapper;
using KitapSatisAPI.DTOs;
using KitapSatisAPI.Models;
using KitapSatisAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KitapSatisAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllAsync();

            if (!books.Any())
                return Ok("Şu anda kayıtlı kitap bulunmamaktadır.");

            var result = _mapper.Map<IEnumerable<BookDto>>(books);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                return NotFound($"ID'si {id} olan kitap bulunamadı.");

            var result = _mapper.Map<BookDto>(book);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] CreateBookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Geçersiz işlem.");
            if (dto.CategoryId == 0)
                return BadRequest("Kategori Id Girmelisiniz!!");
            var book = _mapper.Map<Book>(dto);
            await _bookRepository.AddAsync(book);

            var result = _mapper.Map<BookDto>(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto dto)
        {
            var existing = await _bookRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound("Güncellenmek istenen kitap bulunamadı.");

            _mapper.Map(dto, existing);
            await _bookRepository.UpdateAsync(existing);

            return Ok("Kitap bilgileri güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                return NotFound("Silinecek kitap bulunamadı.");

            await _bookRepository.DeleteAsync(book);
            return Ok("Kitap başarıyla silindi.");
        }
    }
}
