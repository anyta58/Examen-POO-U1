using ProyectoExamenU1.Dtos.categories;

namespace ProyectoExamenU1.Services.Interfaces
{
    public interface IRatingService
    {
        Task<List<ratingDtos>> GetRatingsListAsync();
        Task<ratingDtos> GetRatingByIdAsync(Guid id);
        Task<bool> CreateAsync(ratingCreateDto dto);
        Task<bool> EditAsync(ratingEditDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
