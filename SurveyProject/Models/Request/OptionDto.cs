namespace SurveyProject.WebApi.Models.Request
{
    public class OptionDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
    }
}
