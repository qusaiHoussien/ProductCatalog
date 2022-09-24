namespace ProductCatalog.Server.IRepository
{
    public interface IAttributeRepository
    {
        public Task<ProductAttribute> Add(ProductAttribute attribute);
        public Task<ProductAttribute> Delete(ProductAttribute attribute);
        public Task<bool> AttributeExists(string name);
    }
}