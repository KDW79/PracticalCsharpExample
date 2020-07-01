using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch15_LINQ
{
    public class Book
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int PublishedYear { get; set; }
        public override string ToString()
        {
            return $"발행연도:{PublishedYear}, 분야: {CategoryId}, 가격: {Price}, 제목: {Title} ";
        }
    }
}
