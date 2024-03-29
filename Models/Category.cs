﻿using System;
using System.Collections.Generic;

namespace BackendAPI.Models
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public virtual Post? Post { get; set; }
    }
}
