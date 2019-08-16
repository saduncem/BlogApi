using BlogApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApi.Data.Entities
{
    public class Comments
    {
        public Comments()
        {

        }

        [Key]
        public int Id { get; set; }

        public string CommentContent { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public Post Post { get; set; }

    }
}
