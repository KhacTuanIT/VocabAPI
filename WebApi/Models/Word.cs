using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Word
    {
        public string Id { get; set; }
        public string WordGroupId { get; set; }
        public string W { get; set; }
        public string Explain { get; set; }
        public string Example { get; set; }
        public string Synomymous { get; set; }
        public string Image { get; set; }
        public string Audio { get; set; }
        public string ExampleAudio { get; set; }

        public virtual WordGroup WordGroup { get; set; }
    }
}