using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class WordMemorize
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string WordId { get; set; }
        public bool Learned { get; set; }
        public bool Memorize { get; set; }
        public bool Pin { get; set; }
        public bool Remind { get; set; }

        public virtual User User { get; set; }
        public virtual Word Word { get; set; }
    }
}