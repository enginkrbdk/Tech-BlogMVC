using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBlog.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public virtual List<Article> Articles { get; set; }
    }
}