using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcBlog.Models
{
    public class BlogContext:DbContext
    {
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User>  Users {get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

    }
}