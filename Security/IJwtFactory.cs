using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;

namespace Basics.Security
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity, IEnumerable<Claim> appClaims);
        ClaimsIdentity GenerateClaimsIdentity(string email, int id);
    }
}