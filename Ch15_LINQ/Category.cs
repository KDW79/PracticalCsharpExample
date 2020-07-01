using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch15_LINQ
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() { return $"Id:{Id}, 분야 이름:{Name}"; }
    }
}
