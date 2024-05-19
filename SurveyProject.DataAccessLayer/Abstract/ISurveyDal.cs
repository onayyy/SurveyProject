using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SurveyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.DataAccessLayer.Abstract
{
    public interface ISurveyDal : IGenericDal<Survey>
    {
        int GetSurveyCount();
        Task<Survey> GetSurveyById(int id);
        Task<List<Survey>> GetSurveyWithOptionsAsync();
        Task<Survey> GetSurveyWithOptionsByIdAsync(int surveyId);
        Task<List<Option>> GetVotesBySurveyId(int surveyId);
    }
}
