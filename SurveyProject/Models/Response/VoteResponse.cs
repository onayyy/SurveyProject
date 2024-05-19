using SurveyProject.EntityLayer.Concrete;

namespace SurveyProject.WebApi.Models.Response
{
    public class VoteResponse
    {
        public List<Vote> Votes { get; set; }
        public int TotalVoteCount { get; set; }
    }
}
