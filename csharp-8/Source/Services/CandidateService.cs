using Codenation.Challenge.Models;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly CodenationContext _context;

        public CandidateService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            return _context.Candidates
                .Where(x => x.AccelerationId == accelerationId)
                .Distinct()
                .ToList();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            return _context.Candidates
                .Where(c => c.CompanyId == companyId)
                .Distinct()
                .ToList();
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            return _context.Candidates
                .Where(u => u.UserId == userId && u.AccelerationId == accelerationId && u.CompanyId == companyId)
                .FirstOrDefault();
        }

        public Candidate Save(Candidate candidate)
        {
            Candidate candidateResult = FindById(candidate.UserId, candidate.AccelerationId, candidate.CompanyId);

            if (candidateResult == null)
            {
                _context.Add(candidate);
                candidateResult = candidate;
            }
            else
            {
                candidateResult.Status = candidate.Status;
                candidateResult.CreatedAt = candidate.CreatedAt;
            }
            _context.SaveChanges();
            return candidate;
        }
    }
}
