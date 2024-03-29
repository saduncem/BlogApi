﻿using BlogApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApi.Domain.Entities
{
    public class PostTag
    {
        public PostTag()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Post Post { get; set; }
    }
}
