using CSharpAngular.Api.Entities;

namespace CSharpAngular.Api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
