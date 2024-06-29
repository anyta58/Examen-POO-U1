using Newtonsoft.Json;
using ProyectoExamenU1.Database.Entities;
using ProyectoExamenU1.Dtos.categories;
using ProyectoExamenU1.Services.Interfaces;
using System.Diagnostics;

namespace ProyectoExamenU1.Services
{
    public class ratingService : IRatingService
    {
        public readonly string _JSON_FILE;

        public ratingService()
        {
            _JSON_FILE = "SeedData/rating.json";
        }

        public async Task<List<ratingDtos>> GetRatingsListAsync()
        {
            return await ReadRatingsFromFileAsync();
        }
        public async Task<ratingDtos> GetRatingByIdAsync(Guid id)
        {
            var ratings = await ReadRatingsFromFileAsync();
            ratingDtos rating = ratings.FirstOrDefault(c => c.Id == id);
            return rating;
        }

        public async Task<bool> CreateAsync(ratingCreateDto dto)
        {
            var ratingsDtos = await ReadRatingsFromFileAsync();

            var ratingDto = new ratingDtos
            {
                Id = Guid.NewGuid(),
                StudentId = Guid.NewGuid(),
                Subject = dto.Subject,
                Grade = dto.Grade,
            };

            ratingsDtos.Add(ratingDto);

            var ratings = ratingsDtos.Select(x => new Rating
            {
                Id = x.Id,
                StudentId = x.StudentId,
                Subject = dto.Subject,
                Grade = dto.Grade,
            }).ToList();

            return true;
        }

        public async Task<bool> EditAsync(ratingEditDto dto, Guid id)
        {
            var ratingsDto = await ReadRatingsFromFileAsync();

            var existingRating = ratingsDto
                .FirstOrDefault(rating => rating.StudentId == id);
            if (existingRating is null)
            {
                return false;
            }

            for (int i = 0; i < ratingsDto.Count; i++)
            {
                if (ratingsDto[i].StudentId == id)
                {
                    ratingsDto[i].Subject = dto.Subject;
                    ratingsDto[i].Grade = dto.Grade;
                }
            }

            var ratings = ratingsDto.Select(x => new Rating
            {
                Id = x.Id,
                StudentId = x.StudentId,
                Subject = dto.Subject,
                Grade = dto.Grade,
            }).ToList();

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var ratingsDto = await ReadRatingsFromFileAsync();
            var ratingToDelete = ratingsDto.FirstOrDefault(x => x.Id == id);

            if (ratingToDelete is null)
            {
                return false;
            }

            ratingsDto.Remove(ratingToDelete);

            var categories = ratingsDto.Select(x => new Rating
            {
                Id = x.Id,
                StudentId = x.StudentId,
                Subject = x.Subject,
                Grade = x.Grade,
            }).ToList();


            return true;
        }

        private async Task<List<ratingDtos>> ReadRatingsFromFileAsync()
        {
            if (!File.Exists(_JSON_FILE))
            {
                return new List<ratingDtos>();
            }

            var json = await File.ReadAllTextAsync(_JSON_FILE);

            var ratings = JsonConvert.DeserializeObject<List<Rating>>(json);

            var dtos = ratings.Select(x => new ratingDtos
            {
                Id = x.Id,
                StudentId = x.StudentId,
                Subject = x.Subject,
                Grade = x.Grade,
            }).ToList();

            return dtos;
        }

    }
}