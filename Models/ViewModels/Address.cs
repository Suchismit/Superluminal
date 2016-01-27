using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Superluminal.Models.ViewModels
{
    public class Address
    {
        public long Id { get; set; }
        public long? FkEnitityId { get; set; }
        public string Address1 { get; set; }
        public byte[] Address2 { get; set; }
        public byte? RowStatus { get; set; }

        public virtual Parent Parent { get; set; }
    }
}