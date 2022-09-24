using ProductCatalog.Server.IRepository;
using ProductCatalog.Server.Data;
namespace ProductCatalog.Server.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetProductsByCategory(int CategoryId)
        {
   
                var products = await _context.Products
               .Include(p=>p.Pictures)
               .Include(p=>p.productCategoryMapping)
               .Include(p=>p.productAttributeMapping)
               .ThenInclude(pam=>pam.productAttribute)
               .Where(p => p.forSearchByCategory
               .Contains(CategoryId.ToString()))
               .ToListAsync();
                return products;
            
           
        }

        public async Task<Product> Add(Product product)
        {
                foreach (var item in product.productCategoryMapping)
                {
                    int id = item.CategoryId;
                    product.forSearchByCategory += "." + id;
                }
            
            await _context.Products.AddAsync(product);
           
            
                    await _context.SaveChangesAsync();
  

            return product;
        }

        public async Task<Product> Edit(Product product)
        {
            var productEdit = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
           
            productEdit.Name = product.Name;
            productEdit.Description = product.Description;
            productEdit.Price = product.Price;
           
            
                    await _context.SaveChangesAsync();
        
           
            return productEdit;
        }
        public async Task<Product> Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
           
            return product;
        }

        public async Task<List<ProductAttributeMapping>> AddAttributesToProduct(List<ProductAttributeMapping> productAttributeMapping)
        {
            await _context.Product_Attribute_Mapping
            .AddRangeAsync(productAttributeMapping);
 
                    await _context.SaveChangesAsync();

           
            return productAttributeMapping;

        }
        public async Task<ProductAttributeMapping> DeleteAttributeFromProduct(ProductAttributeMapping productAttributeMapping)
        {
            _context.Product_Attribute_Mapping
            .Remove(productAttributeMapping);
 
                    await _context.SaveChangesAsync();
  
           
            return productAttributeMapping;
        }
    }
}