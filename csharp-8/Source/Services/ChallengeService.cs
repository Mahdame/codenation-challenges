using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly CodenationContext _context;

        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            return _context.Candidates
                .Where(i => i.AccelerationId == accelerationId && i.UserId == userId)
                .Select(c => c.Acceleration.Challenge)
                .Distinct()
                .ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (_context.Challenges.Any(x => x == challenge))
            {
                _context.Update(challenge);
            }
            else
            {
                _context.Add(challenge);
            }
            _context.SaveChanges();
            return challenge;
        }
    }
}