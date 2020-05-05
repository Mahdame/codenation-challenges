using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private readonly CodenationContext _context;

        public AccelerationService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            return _context.Candidates
                .Where(c => c.Company.Id == companyId)
                .Select(a => a.Acceleration)
                .Distinct()
                .ToList();
        }

        public Acceleration FindById(int id)
        {
            return _context.Accelerations
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public Acceleration Save(Acceleration acceleration)
        {
            if (_context.Accelerations.Any(x => x == acceleration))
            {
                _context.Update(acceleration);
            }
            else
            {
                _context.Add(acceleration);
            }
            _context.SaveChanges();
            return acceleration;
        }
    }
}
