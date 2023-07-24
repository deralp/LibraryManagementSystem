using System.Security.Claims;

namespace LibraryManagementSystem.Infrastructure.Token
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(List<Claim> claims);
    }
}
