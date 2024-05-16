using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.EntityLayer.Concrete
{
    public class Survey
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public Setting Setting { get; set; }

        public List<Option> Options { get; set; }
        public virtual List<Vote> Votes { get; set; }
   
    }
}
