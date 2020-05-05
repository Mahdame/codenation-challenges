using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CodenationContext _context;

        public CompanyService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            return _context.Accelerations
                .Where(x => x.Id == accelerationId)
                .SelectMany(y => y.Candidates)
                .Select(c => c.Company)
                .Distinct()
                .ToList();
        }

        public Company FindById(int id)
        {
            return _context.Companies
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public IList<Company> FindByUserId(int userId)
        {
            return _context.Users
                .Where(x => x.Id == userId)
                .SelectMany(y => y.Candidates)
                .Select(c => c.Company)
                .Distinct()
                .ToList();
        }

        public Company Save(Company company)
        {
            if (_context.Companies.Any(x => x == company))
            {
                _context.Update(company);
            }
            else
            {
                _context.Add(company);
            }
            _context.SaveChanges();
            return company;
        }
    }
}