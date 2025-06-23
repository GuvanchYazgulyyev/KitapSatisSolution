using AutoMapper;
using KitapSatisAPI.DTOs;
using KitapSatisAPI.Models;
using KitapSatisAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KitapSatisAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _repo.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = _mapper.Map<Category>(dto);
            await _repo.AddAsync(category);
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateCategoryDto dto)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null)
                return NotFound("Kategori bulunamadı.");

            category.Name = dto.Name;
            await _repo.UpdateAsync(category);

            return Ok("Kategori güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null)
                return NotFound("Silinecek kategori bulunamadı.");

            await _repo.DeleteAsync(category);
            return Ok("Kategori silindi.");
        }

    }
}
