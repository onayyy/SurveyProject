using SurveyProject.EntityLayer.Concrete;

namespace SurveyProject.WebApi.Models.Request
{
    public class SurveyUpdateRequest
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string CreatedBy { get; set; }
        public List<OptionDto>? Options { get; set; }
        public Setting? Settings { get; set; }
    }
}
