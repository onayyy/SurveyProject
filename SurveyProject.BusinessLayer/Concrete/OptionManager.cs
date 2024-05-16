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
    public class OptionManager : IOptionService
    {
        private readonly IOptionDal _optionDal;

        public OptionManager(IOptionDal optionDal)
        {
            _optionDal = optionDal;
        }

        public async Task TDelete(int id)
        {
            await _optionDal.Delete(id);
        }

        public Option TGetById(int id)
        {
            return _optionDal.GetById(id);
        }

        public List<Option> TGetListAll()
        {
            return _optionDal.GetListAll();
        }

        public async Task TInsert(Option entity)
        {
            await _optionDal.Insert(entity);
        }

        public async Task TUpdate(Option entity)
        {
            await _optionDal.Update(entity);
        }
    }
}
