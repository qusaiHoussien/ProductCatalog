namespace ProductCatalog.Server.IRepository
{
    public interface IPictureRepository
    {
        public Task<Picture> Add(Picture picture);
        public Task<Picture> Delete(Picture picture);
    }
}