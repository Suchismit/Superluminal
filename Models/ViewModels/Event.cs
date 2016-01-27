using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Superluminal.Models.ViewModels
{
    public class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            this.Payments = new HashSet<Payment>();
        }

        public long Id { get; set; }
        public long? FkEntityId { get; set; }
        public string Type { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Location { get; set; }
        public Nullable<byte> RowStatus { get; set; }

        public virtual Parent Parent { get; set; }
       
        public virtual ICollection<Payment> Payments { get; set; }
    }
}