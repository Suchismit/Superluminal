using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Superluminal.Models.ViewModels
{
    public class ParentSearch
    {
        public long? Id { get; set; }
        public long? Phone { get; set; }
        public string Name { get; set; }       
        public string PostCode { get; set; }

    }
}