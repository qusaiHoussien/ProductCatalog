namespace ProductCatalog.Server.IRepository
{
    public interface IAuthRepository
    {
        public Task<User> Register(User user,string password);
        public Task<User> Login(string userName,string password);
        public Task<bool> UserExists(string userName);
    }
}