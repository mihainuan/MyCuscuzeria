using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MyCuscuzeria.API.Security
{
    public class SigningConfigurations
    {
        private const string SECRET_KEY = "ea4da858-5bb7-4810-aa0a-5f847ef1a33f";

        public SigningCredentials SigningCredentials { get; }
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

        public SigningConfigurations()
        {
            SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
        }
    }
}