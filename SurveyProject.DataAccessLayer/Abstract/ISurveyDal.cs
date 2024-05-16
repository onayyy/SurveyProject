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
        Task<List<Survey>> GetSurveyWithOptionsAsync();
    }
}
