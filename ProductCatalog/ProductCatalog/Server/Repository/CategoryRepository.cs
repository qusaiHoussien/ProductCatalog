using ProductCatalog.Server.IRepository;
using ProductCatalog.Server.Data;
namespace ProductCatalog.Server.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            
                var categories = await _context.Categories.ToListAsync();
                return categories;
   
 
        }

        public async Task<Category> Add(Category category)
        {
            await _context.Categories.AddAsync(category);
            
                    await _context.SaveChangesAsync();
     
            return category;
        }
        public async Task<Category> Edit(Category category)
        {
            var categoryEdit = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
          
            categoryEdit.Name = category.Name;
            categoryEdit.Description = category.Description;
          
            
                    await _context.SaveChangesAsync();
      
          
            return categoryEdit;
        }
        public async Task<Category> Delete(Category category)
        {

            _context.Categories.Remove(category);
            
                    await _context.SaveChangesAsync();
          
          
            return category;
        }

        public async Task<bool> CategoryExists(string name)
        {
            if (await _context.Categories.AnyAsync(x => x.Name == name))
                return true;

            return false;
        }
    }
}