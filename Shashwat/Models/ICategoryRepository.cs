﻿namespace Shashwat.Models
{
    public interface ICategoryRepository
    {
       
        IEnumerable<Category> AllCategories { get; }

    }
}
