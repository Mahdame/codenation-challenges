using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;
        private readonly IMapper _mapper;

        public SubmissionController(ISubmissionService submissionService, IMapper mapper)
        {
            _submissionService = submissionService;
            _mapper = mapper;
        }

        // GET api/submission/higherScore

        [HttpGet("higherScore")]
        public ActionResult<decimal> GetHigherScore(int? challengeId = null)
        {
            if (challengeId.HasValue)
            {
                return Ok(_submissionService.FindHigherScoreByChallengeId(challengeId.Value));
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/submission
        [HttpGet]
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll(int? challengeId = null, int? accelerationId = null)
        {
            if (challengeId.HasValue && accelerationId.HasValue)
            {
                return Ok(_mapper.Map<List<SubmissionDTO>>(_submissionService.FindByChallengeIdAndAccelerationId(challengeId.Value, accelerationId.Value)));
            }
            else
                return NoContent();
        }

        // POST api/submission
        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            return Ok(_mapper.Map<SubmissionDTO>(_submissionService.Save(_mapper.Map<Submission>(value))));
        }
    }
}
