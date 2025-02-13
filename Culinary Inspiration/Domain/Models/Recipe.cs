﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public int CookingTime { get; set; } // in minutes możliwe jako timespan
        public string Difficulty { get; set; } 
        public string DietType { get; set; } 
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public List<Review> Reviews { get; set; }
    }

    public enum DifficultyType
    {
        Easy,
        Medium,
        Hard
    }

    public enum DietType
    {
        Normal,
        Dietetic,
        Vegan
    }
}
