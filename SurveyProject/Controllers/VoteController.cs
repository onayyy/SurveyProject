using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyProject.BusinessLayer.Abstract;
using SurveyProject.EntityLayer.Concrete;
using SurveyProject.WebApi.Models.Request;
using SurveyProject.WebApi.Models.Response;

namespace SurveyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public VoteController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost]
        public async Task<IActionResult> Vote([FromBody] VoteDtoRequest request)
        {
            var survey = await _surveyService.TGetSurveyWithOptionsByIdAsync(request.SurveyId);
            if (survey == null)
            {
                return NotFound();
            }

            var selectedOptions = survey.Options.Where(x => request.OptionIds.Contains(x.Id)).ToList();
            if (selectedOptions == null || selectedOptions.Count == 0)
            {
                return ValidationProblem("Gönderilen oyların ankette bir karşılığı yok.");
            }

            var vote = new Vote
            {
                SurveyId = request.SurveyId,
                User = request.User,
                Options = selectedOptions
            };

            if (survey.Votes == null)
            {
                survey.Votes = new List<Vote>();
            }

            survey.Votes.Add(vote);

            await _surveyService.TUpdate(survey);
            return Ok("Oy başarıyla Kullanıldı.");
        }

        [HttpGet("{surveyId}")]
        public async Task<IActionResult> VoteGetBySurveyId(int surveyId)
        {
            var votedOptions = await _surveyService.TGetVotesBySurveyId(surveyId);
            if (votedOptions == null) return NotFound();

            var response = new VoteResponse();
            response.Votes = votedOptions.SelectMany(x => x.Votes).GroupBy(v => v.Id).Select(g => g.First()).ToList();
            //response.Votes = votedOptions.SelectMany(x => x.Votes).ToList();
            response.TotalVoteCount = votedOptions.Sum(x => x.Votes.Count);

            return Ok(response);
        }
    }
}
