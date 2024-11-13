using Microsoft.AspNetCore.Identity;

namespace NEZWalksAPI.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
