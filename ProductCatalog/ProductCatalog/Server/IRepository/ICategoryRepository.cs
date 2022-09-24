namespace ProductCatalog.Server.IRepository
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllCategories();
        public Task<Category> Add(Category category);
        public Task<Category> Edit(Category category);
        public Task<Category> Delete(Category category);
        public Task<bool> CategoryExists(string name);
    }
}