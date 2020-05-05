using Codenation.Challenge.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Codenation.Challenge.Services
{
    public class UserProfileService : IProfileService
    {
        private readonly CodenationContext _dbContext;

        public UserProfileService(CodenationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var request = context.ValidatedRequest as ValidatedTokenRequest;

            if (request != null)
            {
                int.TryParse(request.Subject.FindFirst("sub").Value, out var idUser);
                var user = _dbContext.Users.FirstOrDefault(x => x.Id == idUser);
                context.IssuedClaims = GetUserClaims(user).ToList();
            }
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }

        public static Claim[] GetUserClaims(User user)
        {
            return new[]
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.Role, "User")
            };
        }

    }
}