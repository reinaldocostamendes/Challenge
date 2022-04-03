using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Models
{
    public class RatioElements
    {
        public System.Guid Id { get; set; }
        public string Input{ get; set; }
        public string NegativesRatio { get; set; }
        public string PositivesRatio { get; set; }
        public string ZerosRatio { get; set; }
       
        [NotMapped]
        public List<int> InputRequest { get; set; }
    }
}
