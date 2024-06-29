using Microsoft.AspNetCore.Mvc;
using ProyectoExamenU1.Dtos.categories;
using ProyectoExamenU1.Services.Interfaces;

namespace ProyectoExamenU1.Controllers
{

    [ApiController]
    [Route("api/ratings")]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingsService;
        public RatingsController(IRatingService ratingsService)
        {
            this._ratingsService = ratingsService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _ratingsService.GetRatingsListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var rating = await _ratingsService.GetRatingByIdAsync(id);

            if (rating == null)
            {
                return NotFound(new { Message = $"No se encontro la categoría: {id}" });
            }

            return Ok(rating);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ratingCreateDto dto)
        {
            await _ratingsService.CreateAsync(dto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(ratingEditDto dto, Guid id)
        {
            var result = await _ratingsService.EditAsync(dto, id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var rating = await _ratingsService.GetRatingByIdAsync(id);

            if (rating is null)
            {
                return NotFound();
            }

            await _ratingsService.DeleteAsync(id);

            return Ok();

        }

    }
}
