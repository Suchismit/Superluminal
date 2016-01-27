using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Superluminal.Models.ViewModels
{
    public class Payment
    {
        public long Id { get; set; }
        public long? FkEventId { get; set; }
        public string Type { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? GivenDate { get; set; }
        public byte? RowStatus { get; set; }

        public virtual Event Event { get; set; }
    }
}