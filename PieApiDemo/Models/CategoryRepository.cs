using PieApiDemo.Models;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext appDbContext;
    public CategoryRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public IEnumerable<Category> AllCategories => appDbContext.Categories;
    /* new List<Category>
     {
             new Category{CategoryId=1, CategoryName="Fruit pies", Description="All-fruity pies"},
             new Category{CategoryId=2, CategoryName="Cheese cakes", Description="Cheesy all the way"},
             new Category{CategoryId=3, CategoryName="Seasonal pies", Description="Get in the mood for a seasonal pie"}
     };*/
    public Category InsertCategory(Category category)
    {
        var InsertCat = this.appDbContext.Categories.Add(category);
        this.appDbContext.SaveChanges();
        return InsertCat.Entity;
    }
    public Category DeleteCategory(int categoryID)
    {
        var DeleteCat = AllCategories
            .FirstOrDefault(category => category.CategoryId == categoryID);
        var entry = this.appDbContext.Categories.Remove(DeleteCat);
        this.appDbContext.SaveChanges();
        return entry.Entity;
    }
    public Category UpdateCategory(Category category)
    {
        var UpdateCat = this.appDbContext.Categories.Update(category);
        this.appDbContext.SaveChanges();
        return UpdateCat.Entity;
    }
}