﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VimeoVHX
{
    class ListCostumerParams
    {
        public string Product { get; set; }
        public string Email { get; set; }
        public string Query { get; set; }
        public Sort Sort { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }

    }
}
