using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UserIdentity.Models;

namespace UserIdentity.Identity
{
    public class IdentityDataContext:IdentityDbContext<ApplicationUser>    
    {
        public IdentityDataContext():base("IdentityConnection")
        {

        }
        public DbSet<Basvuru> Basvurus { get; set; }
        public DbSet<Deneme> Denemes { get; set; }
        public DbSet<Tercih> Tercihs { get; set; }
    }
}