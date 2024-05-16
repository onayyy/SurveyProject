using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task TInsert(T entity);

        Task TUpdate(T entity);

        Task TDelete(int id);

        List<T> TGetListAll();

        T TGetById(int id);
    }
}
