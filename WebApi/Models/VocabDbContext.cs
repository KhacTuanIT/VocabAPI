using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class VocabDbContext : DbContext
    {
        public VocabDbContext() : base("VocabAPI")
        {

        }

        public System.Data.Entity.DbSet<WebApi.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<WebApi.Models.Level> Levels { get; set; }

        public System.Data.Entity.DbSet<WebApi.Models.Package> Packages { get; set; }

        public System.Data.Entity.DbSet<WebApi.Models.MyPackage> MyPackages { get; set; }

        public System.Data.Entity.DbSet<WebApi.Models.Word> Words { get; set; }

        public System.Data.Entity.DbSet<WebApi.Models.WordGroup> WordGroups { get; set; }

        public System.Data.Entity.DbSet<WebApi.Models.WordMemorize> WordMemorizes { get; set; }
    }
}