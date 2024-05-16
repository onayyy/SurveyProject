using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyProject.BusinessLayer.Abstract;

namespace SurveyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;

        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }
    }
}
