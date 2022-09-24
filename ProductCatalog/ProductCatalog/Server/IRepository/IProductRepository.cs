namespace ProductCatalog.Server.IRepository
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProductsByCategory(int CategoryId);
        public Task<Product> Add(Product product);
        public Task<Product> Edit(Product product);
        public Task<Product> Delete(Product product);
        public Task<List<ProductAttributeMapping>> AddAttributesToProduct(List<ProductAttributeMapping> productAttributeMapping);
        public Task<ProductAttributeMapping> DeleteAttributeFromProduct(ProductAttributeMapping productAttributeMapping);
    }
}