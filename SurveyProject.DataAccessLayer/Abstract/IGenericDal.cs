using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.DataAccessLayer.Abstract
{
    public interface IGenericDal <T> where T : class
    {
        Task Insert(T entity);

        Task Update(T entity);

        Task Delete(int id);

        List<T> GetListAll();

        T GetById(int id);
    }
}
