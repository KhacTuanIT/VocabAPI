using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Job { get; set; }
        public string Livein { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<MyPackage> MyPackages { get; set; }
    }
}