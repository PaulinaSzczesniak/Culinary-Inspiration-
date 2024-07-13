import React, { useState, useEffect } from 'react';
import axios from 'axios';

const RecipeReviews = ({ recipeId }) => {
    const [reviews, setReviews] = useState([]);
    const [newReview, setNewReview] = useState({
        rating: 0,
        comment: ''
    });

    useEffect(() => {
        fetchReviews();
    }, [recipeId]);

    const fetchReviews = async () => {
        try {
            const response = await axios.get(`https://localhost:7160/api/Review/recipe/${recipeId}`);
            setReviews(response.data);
        } catch (error) {
            console.error('Error fetching reviews:', error);
        }
    };

    const handleAddReview = async () => {
        try {
            await axios.post(`https://localhost:7160/api/Review/recipe/${recipeId}`, newReview);
            // Clear the form and refresh the reviews
            setNewReview({ rating: 0, comment: '' });
            fetchReviews();
        } catch (error) {
            console.error('Error adding review:', error);
        }
    };

    const handleChange = (event) => {
        const { name, value } = event.target;
        setNewReview({ ...newReview, [name]: value });
    };

    return (
        <div>
            <h3>Reviews</h3>
            {reviews.length === 0 ? (
                <p>No reviews available for this recipe.</p>
            ) : (
                <ul>
                    {reviews.map((review) => (
                        <li key={review.id}>
                            <p><strong>Rating:</strong> {review.rating}</p>
                            <p>{review.comment}</p>
                        </li>
                    ))}
                </ul>
            )}

            {/* Form for adding a new review */}
            <div>
                <h4>Add Review</h4>
                <label>
                    Rating:
                    <input type="number" name="rating" min="1" max="5" value={newReview.rating} onChange={handleChange} />
                </label>
                <label>
                    Comment:
                    <textarea name="comment" value={newReview.comment} onChange={handleChange} />
                </label>
                <button onClick={handleAddReview}>Add Review</button>
            </div>
        </div>
    );
};

export default RecipeReviews;
