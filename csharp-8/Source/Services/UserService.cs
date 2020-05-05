using Codenation.Challenge.Models;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private readonly CodenationContext _context;

        public UserService(CodenationContext context)
        {
            _context = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            return _context.Accelerations
                .Where(x => x.Name == name)
                .SelectMany(y => y.Candidates)
                .Select(c => c.User)
                .Distinct()
                .ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            return _context.Companies
                .Where(x => x.Id == companyId)
                .SelectMany(y => y.Candidates)
                .Select(c => c.User)
                .Distinct()
                .ToList();
        }

        public User FindById(int id)
        {
            return _context.Users
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public User Save(User user)
        {
            if (_context.Users.Any(x => x == user))
            {
                _context.Update(user);
            }
            else
            {
                _context.Add(user);
            }
            _context.SaveChanges();
            return user;
        }
    }
}
