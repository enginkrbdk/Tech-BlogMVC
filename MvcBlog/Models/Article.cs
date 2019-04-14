using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBlog.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string A_Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public virtual Category Category { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual User User { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }




}