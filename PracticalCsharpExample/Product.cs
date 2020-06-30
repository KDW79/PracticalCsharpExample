using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalCsharpExample
{
    public class Product
    {
        // 상품 코드
        public int Code { get; private set; }
        // 상품 이름
        public string Name { get; private set; }
        // 상품 가격 (세금이 붙지 않은 가격)
        public int Price { get; private set; }

        // 생성자
        public Product (int code, string name, int price)
        {
            this.Code = code;
            this.Name = name;
            this.Price = price;
        }

        // 소비세를 구한다. (소비세율은 8%)
        public int GetTax()
        {
            return (int)(Price * 0.08);
        }

        // 세금을 포함한 가격을 구한다
        public int GetPriceIncludingTax()
        {
            return Price + GetTax();
        }
    }
}
