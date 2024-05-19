using Microsoft.EntityFrameworkCore;
using SurveyProject.BusinessLayer.Abstract;
using SurveyProject.DataAccessLayer.Abstract;
using SurveyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.BusinessLayer.Concrete
{
    public class SurveyManager : ISurveyService
    {
        private readonly ISurveyDal _surveyDal;

        public SurveyManager(ISurveyDal surveyDal)
        {
            _surveyDal = surveyDal;
        }

        public Task<List<Survey>> TGetSurveyWithOptionsAsync()
        {
            return _surveyDal.GetSurveyWithOptionsAsync();
        }
        public Task<Survey> TGetSurveyWithOptionsByIdAsync(int surveyId)
        {
            return _surveyDal.GetSurveyWithOptionsByIdAsync(surveyId);
        }

        public async Task TDelete(int id)
        {
            await _surveyDal.Delete(id);
        }

        public Survey TGetById(int id)
        {
            return _surveyDal.GetById(id);
        }

        public List<Survey> TGetListAll()
        {
            return _surveyDal.GetListAll();
        }

        public int TGetSurveyCount()
        {
            return _surveyDal.GetSurveyCount();
        }

        public async Task TInsert(Survey entity)
        {
            await _surveyDal.Insert(entity);
        }

        public async Task TUpdate(Survey entity)
        {
            await _surveyDal.Update(entity);
        }

        public async Task<List<Option>> TGetVotesBySurveyId(int surveyId)
        {
            return await _surveyDal.GetVotesBySurveyId(surveyId);
        }

        public async Task<Survey> GetSurveyById(int id)
        {
            return await _surveyDal.GetSurveyById(id);
        }
    }
}
