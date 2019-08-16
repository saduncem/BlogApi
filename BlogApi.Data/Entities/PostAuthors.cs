using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApi.Data.Entities
{
    public class PostAuthors
    {
        public int id { get; set; }
        public long PostId { get; set; }
        public long AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Post Post { get; set; }
    }
}
