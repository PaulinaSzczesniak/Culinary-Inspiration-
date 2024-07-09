using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Services
{
    public class ReviewService : IReviewService
    {
        private readonly ReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _reviewRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Review>> GetReviewsByRecipeIdAsync(int recipeId)
        {
            return await _reviewRepository.GetByRecipeIdAsync(recipeId);
        }

        public async Task<Review> CreateReviewAsync(Review review)
        {
            return await _reviewRepository.CreateAsync(review);
        }

        public async Task<Review> UpdateReviewAsync(Review review)
        {
            return await _reviewRepository.UpdateAsync(review);
        }

        public async Task<bool> DeleteReviewAsync(int id)
        {
            return await _reviewRepository.DeleteAsync(id);
        }
    }
}
