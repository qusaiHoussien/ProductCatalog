using ProductCatalog.Server.IRepository;
using ProductCatalog.Server.Data;
namespace ProductCatalog.Server.Repository
{
    public class PictureRepository : IPictureRepository
    {
        private readonly DataContext _context;
        public PictureRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<Picture> Add(Picture picture)
        {
            await _context.Pictures.AddAsync(picture);
            
                    await _context.SaveChangesAsync();
 
           
            return picture;
        }
        public async Task<Picture> Delete(Picture picture)
        {

            _context.Pictures.Remove(picture);
            
                    await _context.SaveChangesAsync();
     
           
            return picture;
        }

    }
}