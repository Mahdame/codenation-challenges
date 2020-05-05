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
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateService candidateService, IMapper mapper)
        {
            _candidateService = candidateService;
            _mapper = mapper;
        }

        // GET api/candidate
        [HttpGet]
        public ActionResult<IEnumerable<CandidateDTO>> GetAll(int? accelerationId = null, int? companyId = null)
        {
            if (companyId.HasValue && !accelerationId.HasValue)
            {
                return Ok(_mapper.Map<List<CandidateDTO>>(_candidateService.FindByCompanyId(companyId.Value)));
            }
            else if (accelerationId.HasValue && !companyId.HasValue)
            {
                return Ok(_mapper.Map<List<CandidateDTO>>(_candidateService.FindByAccelerationId(accelerationId.Value)));
            }
            else
                return NoContent();
        }

        // GET api/candidate/{userId}/{accelerationId}/{companyId}
        [HttpGet("{userId}/{accelerationId}/{companyId}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyId)
        {
            return Ok(_mapper.Map<CandidateDTO>(_candidateService.FindById(userId, accelerationId, companyId)));
        }

        // POST api/candidate
        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            return Ok(_mapper.Map<CandidateDTO>(_candidateService.Save(_mapper.Map<Candidate>(value))));
        }
    }
}
