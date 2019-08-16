﻿using BlogApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApi.Domain.Entities
{
    public class PostImage
    {
        public PostImage()
        {
        }
        public int Id { get; set; }
        public string Imagebase64 { get; set; }
        public string Caption { get; set; }
        public virtual Post Post { get; set; }
    }
}
