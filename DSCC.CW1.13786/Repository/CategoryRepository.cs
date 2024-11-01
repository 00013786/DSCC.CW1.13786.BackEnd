using DSCC.CW1._13786.DBContexts;
using DSCC.CW1._13786.Model;

namespace DSCC.CW1._13786.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CarContext _dbContext;
        public CategoryRepository(CarContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCategory(int CategoryId)
        {
            var Category = _dbContext.Categories.Find(CategoryId);
            _dbContext.Categories.Remove(Category);
            Save();
        }

        public Category GetCategoryById(int CategoryId)
        {
            return _dbContext.Categories.Find(CategoryId);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _dbContext.Categories;
        }

        public void InsertCategory(Category Category)
        {
            _dbContext.Add(Category);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(Category Category)
        {
            _dbContext.Entry(Category).State =
            Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
