using Superluminal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Superluminal.Models
{
    public class SuperluminalContext :DbContext
    {
        public SuperluminalContext()
            : base("name=SuperluminalContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
    }
}