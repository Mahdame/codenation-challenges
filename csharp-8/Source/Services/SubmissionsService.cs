using Codenation.Challenge.Models;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly CodenationContext _context;

        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return (from s in _context.Submissions
                    join u in _context.Users on s.UserId equals u.Id
                    join c in _context.Candidates on u.Id equals c.UserId
                    where s.ChallengeId == challengeId && c.AccelerationId == accelerationId
                    select s)
                    .Distinct()
                    .ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return _context.Submissions
                .Where(c => c.ChallengeId == challengeId)
                .Max(s => s.Score);
        }

        public Submission Save(Submission submission)
        {
            Submission submissionResult = _context.Submissions
                .FirstOrDefault(s => s.UserId == submission.UserId && s.ChallengeId == submission.ChallengeId);

            if (submissionResult == null)
            {
                _context.Add(submission);
                submissionResult = submission;
            }
            else
            {
                submissionResult.Score = submission.Score;
                submissionResult.CreatedAt = submission.CreatedAt;
            }
            _context.SaveChanges();
            return submission;
        }
    }
}
