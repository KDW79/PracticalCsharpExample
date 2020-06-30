﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Ch12_Serialization
{
    public class Novel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Published { get; set; }
        public override string ToString()
        {
            return string.Format("[Title={0}, Author={1}, Published={2}",
                Title, Author, Published);
        }

    }
}
