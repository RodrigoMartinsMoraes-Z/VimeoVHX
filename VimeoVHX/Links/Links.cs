﻿using System;
using System.Collections.Generic;
using System.Text;
using VimeoVHX.Products;

namespace VimeoVHX.Links
{
    public class Links
    {
        public Link Self { get; set; }
        public Link Watchlist { get; set; }
        public Link Watching { get; set; }
        public Link First { get; set; }
        public Link Prev { get; set; }
        public Link Next { get; set; }
        public Link Last { get; set; }
    }
}