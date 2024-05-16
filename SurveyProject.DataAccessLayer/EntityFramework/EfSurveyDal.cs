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
    }
}
