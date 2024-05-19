using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SurveyProject.EntityLayer.Concrete
{
    public class Option
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        [JsonIgnore]
        public virtual Survey Survey { get; set; }
        [JsonIgnore]
        public virtual List<Vote> Votes { get; set; }
    }
}
