﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Common
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
    }
}
