using APIProjectBackend.Entities;

namespace APIProjectBackend.Service.Contracts
{
    public interface IAuthService : IBaseService<User>
    {
        public User? Login(string correo, string password);
        public string GenerateJwtToken(User user);
    }
}
