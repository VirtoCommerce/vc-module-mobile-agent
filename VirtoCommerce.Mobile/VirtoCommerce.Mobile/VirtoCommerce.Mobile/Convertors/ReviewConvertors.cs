using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Convertors
{
    public static class ReviewConvertors
    {
        public static Review ReviewEntityToReview(this ReviewEntity review)
        {
            return new Review
            {
                Content = review.Content,
                Id = review.Id,
                ReviewType = review.ReviewType
            };
        }
    }
}
