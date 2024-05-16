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
        Task<List<Survey>> TGetSurveyWithOptionsAsync();
    }
}
