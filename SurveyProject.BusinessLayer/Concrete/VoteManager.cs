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
    public class VoteManager : IVoteService
    {
        private readonly IVoteDal _voteDal;

        public VoteManager(IVoteDal voteDal)
        {
            _voteDal = voteDal;
        }

        public async Task TDelete(int id)
        {
            await _voteDal.Delete(id);
        }

        public Vote TGetById(int id)
        {
            return _voteDal.GetById(id);
        }

        public List<Vote> TGetListAll()
        {
            return _voteDal.GetListAll();
        }

        public async Task TInsert(Vote entity)
        {
            await _voteDal.Insert(entity);
        }

        public async Task TUpdate(Vote entity)
        {
            await _voteDal.Update(entity);
        }
    }
}
