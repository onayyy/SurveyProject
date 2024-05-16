using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.EntityLayer.Concrete
{
    public class Vote
    {
        public int Id { get; set; }

        public int SurveyId { get; set; }

        public string User { get; set; }

        public virtual List<Option> Options { get; set; }

        public virtual Survey Survey { get; set; }
    }
}
