using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.EntityLayer.Concrete
{
    public class Setting
    {
        public int Id { get; set; }

        public int MinChoice { get; set; }

        public int MaxChoice { get; set; }

        public bool MultipleChoice { get; set; }

    }
}
