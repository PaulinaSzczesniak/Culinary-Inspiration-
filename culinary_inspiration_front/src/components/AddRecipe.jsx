import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const AddRecipe = () => {
    const [name, setName] = useState('');
    const [ingredients, setIngredients] = useState('');
    const [instructions, setInstructions] = useState('');
    const [cookingTime, setCookingTime] = useState('');
    const [difficulty, setDifficulty] = useState('');
    const [dietType, setDietType] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();

        const newRecipe = {
            name,
            ingredients,
            instructions,
            cookingTime: parseInt(cookingTime),
            difficulty,
            dietType
        };

        try {
            await axios.post('https://localhost:7160/api/Recipe', newRecipe);
            navigate('/');
        } catch (error) {
            console.error('Error creating recipe:', error);
        }
    };

    return (
        <div>
            <h2>Add New Recipe</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Name:</label>
                    <input type="text" value={name} onChange={(e) => setName(e.target.value)} required />
                </div>
                <div>
                    <label>Ingredients:</label>
                    <textarea value={ingredients} onChange={(e) => setIngredients(e.target.value)} required></textarea>
                </div>
                <div>
                    <label>Instructions:</label>
                    <textarea value={instructions} onChange={(e) => setInstructions(e.target.value)} required></textarea>
                </div>
                <div>
                    <label>Cooking Time (minutes):</label>
                    <input type="number" value={cookingTime} onChange={(e) => setCookingTime(e.target.value)} required />
                </div>
                <div>
                    <label>Difficulty:</label>
                    <select value={difficulty} onChange={(e) => setDifficulty(e.target.value)} required>
                        <option value="">Select...</option>
                        <option value="Easy">Easy</option>
                        <option value="Medium">Medium</option>
                        <option value="Hard">Hard</option>
                    </select>
                </div>
                <div>
                    <label>Diet Type:</label>
                    <select value={dietType} onChange={(e) => setDietType(e.target.value)} required>
                        <option value="">Select...</option>
                        <option value="Normal">Normal</option>
                        <option value="Dietetic">Dietetic</option>
                        <option value="Vegan">Vegan</option>
                    </select>
                </div>
                <button type="submit">Add Recipe</button>
            </form>
        </div>
    );
};

export default AddRecipe;
