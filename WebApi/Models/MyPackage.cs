using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class MyPackage
    {
        public int Id { get; set; }
        public string PackageId { get; set; }
        public string UserId { get; set; }

        public virtual Package Package { get; set; }
        public virtual User User { get; set; }
    }
}