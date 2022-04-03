using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Models
{
    public class VeryBigSum
    {
        public Guid Id { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        [NotMapped]
        public List<int> InputRequest { get; set; }

        public DateTime Date { get; set; }



    }
}
