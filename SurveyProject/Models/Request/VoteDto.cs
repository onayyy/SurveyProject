namespace SurveyProject.WebApi.Models.Request
{
    public class VoteDto
    {
        public int Id { get; set; }

        public int SurveyId { get; set; }

        public string User { get; set; }
    }
}
