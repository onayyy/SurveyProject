using Microsoft.EntityFrameworkCore;
using SurveyProject.DataAccessLayer.Abstract;
using SurveyProject.DataAccessLayer.Context;
using SurveyProject.DataAccessLayer.Repositories;
using SurveyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.DataAccessLayer.EntityFramework
{
    public class EfSurveyDal : GenericRepository<Survey>, ISurveyDal
    {
        public EfSurveyDal(SurveyContext context) : base(context)
        {
        }

        public async Task<Survey> GetSurveyById(int id)
        {
            await using var context = new SurveyContext();
            return await context.Surveys.Where(x => x.Id == id).Include(x => x.Options).FirstOrDefaultAsync();
        }

        public int GetSurveyCount()
        {
            var context = new SurveyContext();
            var surveyCount = context.Surveys.Count();
            return surveyCount;
        }

        public async Task<List<Survey>> GetSurveyWithOptionsAsync()
        {
            await using var context = new SurveyContext();
            return context.Surveys.Include(x => x.Options).ToList();
        }

        public async Task<Survey> GetSurveyWithOptionsByIdAsync(int surveyId)
        {
            await using var context = new SurveyContext();
            return context.Surveys.Where(x => x.Id == surveyId).Include(x => x.Options).Include(x=>x.Votes).FirstOrDefault();
        }

        public async Task<List<Option>> GetVotesBySurveyId(int surveyId)
        {
            await using var context = new SurveyContext();
            return context.Options.Where(x => x.Survey.Id == surveyId).Include(x => x.Votes).ToList();
        }
    }
}
