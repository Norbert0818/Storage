﻿using CoreBuisness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.MySQL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext db;

        public CategoryRepository(DataContext db)
        {
            this.db = db;
        }

        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = db.Categories.Find(categoryId);
            if (category == null) return;

            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return db.Categories.Find(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            var cat = db.Categories.Find(category.Id);
            cat.Name = category.Name;
            cat.Description = category.Description;
            db.SaveChanges();
        }
    }
}