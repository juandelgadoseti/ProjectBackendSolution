using APIProjectBackend.Entities;

namespace APIProjectBackend.Service.Contracts
{
    public interface IAuthService 
    {
        public User? Login(string correo, string password);
        public string GenerateJwtToken(User user);
    }
}
