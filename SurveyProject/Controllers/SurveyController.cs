using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SurveyProject.BusinessLayer.Abstract;
using SurveyProject.DataAccessLayer.Context;
using SurveyProject.EntityLayer.Concrete;
using SurveyProject.WebApi.Models.Request;

namespace SurveyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet]
        public async Task<IActionResult> Survey()
        {
            var values = await _surveyService.TGetSurveyWithOptionsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Survey(int id)
        {
            var survey = await _surveyService.GetSurveyById(id);

            if (survey == null)
            {
                return NotFound();
            }

            return Ok(survey);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SurveyCreateRequest request)
        {
            var options = request.Options.Select(x => new Option
            {
                Description = x.Description,
                Type = x.Type,
                Order = x.Order
            }).ToList();

            var survey = new Survey
            {
                CreatedBy = request.CreatedBy,
                Options = options,
                Question = request.Question,
                CreatedDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(1),
                Setting = request.Settings
            };

            await _surveyService.TInsert(survey);
            return Ok("Anket Başarıyla Oluşturuldu.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _surveyService.TDelete(id);
            return Ok("Anket Başarıyla Silindi."); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] SurveyUpdateRequest request, int id)
        {
            var survey = await _surveyService.TGetSurveyWithOptionsByIdAsync(id);
            if (survey == null)
            {
                return NotFound();
            }

            if (request.Options != null && request.Options.Count > 0)
            {
                var options = request.Options.Select(x => new Option
                {
                    Id = x.Id,
                    Description = x.Description,
                    Type = x.Type,
                    Order = x.Order
                }).ToList();

                survey.Options = options;
            }

            if (!string.IsNullOrEmpty(request.Question))
            {
                survey.Question = request.Question;
            }

            await _surveyService.TUpdate(survey);
            return Ok("Anket Başarıyla Güncellendi");
        }

    }
}
