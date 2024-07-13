import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams, Link, useNavigate } from 'react-router-dom';

const RecipeDetail = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [recipe, setRecipe] = useState(null);

    useEffect(() => {
        fetchRecipe();
    }, [id]);

    const fetchRecipe = async () => {
        try {
            const response = await axios.get(`https://localhost:7160/api/Recipe/${id}`);
            setRecipe(response.data);
        } catch (error) {
            console.error('Error fetching recipe:', error);
        }
    };

    const handleDeleteRecipe = async () => {
        try {
            await axios.delete(`https://localhost:7160/api/Recipe/${id}`);
            navigate('/', { replace: true });
        } catch (error) {
            console.error('Error deleting recipe:', error);
        }
    };

    const handleEditRecipe = () => {
        navigate(`/edit/${id}`);
    };

    if (!recipe) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <h2>{recipe.name}</h2>
            <p>{recipe.ingredients}</p>
            <p>{recipe.instructions}</p>
            <p>Cooking Time: {recipe.cookingTime} minutes</p>
            <p>Difficulty: {recipe.difficulty}</p>
            <p>Diet Type: {recipe.dietType}</p>
            <button onClick={handleDeleteRecipe}>Delete Recipe</button>
            <button onClick={handleEditRecipe}>Edit Recipe</button>
            <Link to="/">Back to Recipe List</Link>
        </div>
    );
};

export default RecipeDetail;
