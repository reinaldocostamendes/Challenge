using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Models
{
    public class DiagonalSum
    {
        public Guid Id { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }

        public DateTime Date { get; set; }
    }
}
