using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Superluminal.Models.ViewModels
{
    public class Parent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Parent()
        {
            this.Addresses = new HashSet<Address>();
            this.Children = new HashSet<Child>();
            this.Events = new HashSet<Event>();
        }

        [Required(ErrorMessage = "Id is required")]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PostCode { get; set; }

        [Display(Name = "Tel")]
        public long? Phone { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                if (!string.IsNullOrEmpty(MiddleName))
                {
                    return FirstName + " " + MiddleName + " " + LastName;
                }
                else
                {
                    return FirstName + " " + LastName;
                }

            }
        }

        public virtual ICollection<Address> Addresses { get; set; }        
        public virtual ICollection<Child> Children { get; set; }       
        public virtual ICollection<Event> Events { get; set; }
    }
}