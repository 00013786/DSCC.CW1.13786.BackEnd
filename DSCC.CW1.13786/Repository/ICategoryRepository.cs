using DSCC.CW1._13786.Model;

namespace DSCC.CW1._13786.Repository
{
    public interface ICategoryRepository
    {
        void InsertCategory(Category Category);
        void UpdateCategory(Category Category);
        void DeleteCategory(int CategoryId);
        Category GetCategoryById(int Id);
        IEnumerable<Category> GetCategories();
    }
}
