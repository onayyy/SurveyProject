using SurveyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.BusinessLayer.Abstract
{
    public interface ISurveyService : IGenericService<Survey>
    {
        int TGetSurveyCount();
        Task<Survey> GetSurveyById(int id);
        Task<List<Survey>> TGetSurveyWithOptionsAsync();
        Task<Survey> TGetSurveyWithOptionsByIdAsync(int surveyId);
        Task<List<Option>> TGetVotesBySurveyId(int surveyId);
    }
}
