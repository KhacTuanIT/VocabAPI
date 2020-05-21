using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Package
    {
        public string Id { get; set; }
        public string NamePackage { get; set; }

        public virtual ICollection<WordGroup> WordGroups { get; set; }
    }
}