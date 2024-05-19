
using SurveyProject.EntityLayer.Concrete;

namespace SurveyProject.WebApi.Models.Request
{
    public class VoteDtoRequest
    {

        public int SurveyId { get; set; }

        public string User { get; set; }
        public List<int> OptionIds { get; set; }

        //public List<VoteOptionDto> Options { get; set; }

    }
}
