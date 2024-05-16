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
    public class EfOptionDal : GenericRepository<Option>, IOptionDal
    {
        public EfOptionDal(SurveyContext context) : base(context)
        {
        }
    }
}
