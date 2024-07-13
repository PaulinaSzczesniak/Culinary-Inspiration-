import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';

const EditRecipe = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [recipe, setRecipe] = useState({
        name: '',
        ingredients: '',
        instructions: '',
        cookingTime: 0,
        difficulty: '',
        dietType: ''
    });

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

    const handleChange = (event) => {
        const { name, value } = event.target;
        setRecipe({ ...recipe, [name]: value });
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            await axios.put(`https://localhost:7160/api/Recipe/${id}`, recipe);
            navigate(`/recipes/${id}`, { replace: true });
        } catch (error) {
            console.error('Error updating recipe:', error);
        }
    };

    return (
        <div>
            <h2>Edit Recipe</h2>
            <form onSubmit={handleSubmit}>
                <label>
                    Name:
                    <input type="text" name="name" value={recipe.name} onChange={handleChange} />
                </label>
                <label>
                    Ingredients:
                    <textarea name="ingredients" value={recipe.ingredients} onChange={handleChange} />
                </label>
                <label>
                    Instructions:
                    <textarea name="instructions" value={recipe.instructions} onChange={handleChange} />
                </label>
                <label>
                    Cooking Time (minutes):
                    <input type="number" name="cookingTime" value={recipe.cookingTime} onChange={handleChange} />
                </label>
                <label>
                    Difficulty:
                    <select name="difficulty" value={recipe.difficulty} onChange={handleChange}>
                        <option value="Easy">Easy</option>
                        <option value="Medium">Medium</option>
                        <option value="Hard">Hard</option>
                    </select>
                </label>
                <label>
                    Diet Type:
                    <select name="dietType" value={recipe.dietType} onChange={handleChange}>
                        <option value="Normal">Normal</option>
                        <option value="Dietetic">Dietetic</option>
                        <option value="Vegan">Vegan</option>
                    </select>
                </label>
                <button type="submit">Save Changes</button>
            </form>
        </div>
    );
};

export default EditRecipe;
