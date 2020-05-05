using Codenation.Challenge.Models;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Services
{
    public class PasswordValidatorService : IResourceOwnerPasswordValidator
    {
        private CodenationContext _dbContext;

        public PasswordValidatorService(CodenationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            context.Result = new GrantValidationResult(
                TokenRequestErrors.InvalidGrant, "Invalid username or password");

            if (_dbContext.Users.Any(x => x.Email == context.UserName && x.Password == context.Password))
            {
                var user = _dbContext.Users.FirstOrDefault(x => x.Email == context.UserName);

                context.Result = new GrantValidationResult(subject: user.Id.ToString(),
                    authenticationMethod: "custom",
                    claims: UserProfileService.GetUserClaims(user));
            }
            return Task.CompletedTask;
        }
    }
}