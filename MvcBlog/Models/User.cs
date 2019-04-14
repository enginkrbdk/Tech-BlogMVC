using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBlog.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string PhotoUrl { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int U_Authorization { get; set; }


        public virtual List<Comment> Comments { get; set; }
        public virtual List<Article> Articles { get; set; }
    }
}