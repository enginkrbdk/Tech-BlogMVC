using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string C_Content { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public virtual User User { get; set; }
        public virtual Article Article { get; set; }
    }
}