using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class WordGroup
    {
        public string Id { get; set; }
        public string PackageId { get; set; }
        public string GroupName { get; set; }

        public virtual Package Package{ get; set; }
        public virtual ICollection<Word> Words { get; set; }
    }
}