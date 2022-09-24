using ProductCatalog.Server.IRepository;
using ProductCatalog.Server.Data;



namespace ProductCatalog.Server.Repository
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly DataContext _context;
        public AttributeRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<ProductAttribute> Add(ProductAttribute attribute)
        {
            await _context.Product_Attributes.AddAsync(attribute);
            
                    await _context.SaveChangesAsync();

            return attribute;
        }

        public async Task<ProductAttribute> Delete(ProductAttribute attribute)
        {

            _context.Product_Attributes.Remove(attribute);
            
                    await _context.SaveChangesAsync();
 
            return attribute;
        }

        public async Task<bool> AttributeExists(string name)
        {
            if (await _context.Product_Attributes.AnyAsync(x => x.Name == name))
                return true;

            return false;
        }

    }
}