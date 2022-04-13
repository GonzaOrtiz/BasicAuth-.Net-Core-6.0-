using System.Threading.Tasks;

namespace BasicAuthentication_.NET_6._0.Services
{
    public interface IUserService
    {
        public bool isUser(string email, string password);
    }
}
