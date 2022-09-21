using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceList.Classes
{
    internal class Price
    {
        [DisplayName("id")]
        public string id { get; set; }
        [DisplayName("Продавец")]
        public Saler saler { get; set; }
        [DisplayName("Продукт")]
        public Product product { get; set; }
        [DisplayName("Цена")]
        public int price { get; set; }
        public DateTime dateTime { get; set; }
        public Price()
        {
            id = Guid.NewGuid().ToString();
            this.dateTime = DateTime.Now;
        }
        
        public Price(Saler saler, Product product, int price)
        {
            id = Guid.NewGuid().ToString();
            this.saler = saler;
            this.product = product;
            this.price = price;
            this.dateTime = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            return obj is Price price &&
                   id == price.id &&
                   (obj as Price).saler.Equals(saler) &&
                   (obj as Price).product.Equals(product) &&
                   this.price == price.price;
        }
    }

    public class DataTime
    {
    }
}
