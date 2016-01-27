using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Superluminal.Models.ViewModels
{
    public class Child
    {
        public long Id { get; set; }
        public long? FkParentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }

        public virtual Parent Parent { get; set; }
    }
}