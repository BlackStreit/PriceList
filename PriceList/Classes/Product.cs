using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceList.Classes
{
    internal class Product
    {
        [DisplayName("id")]
        public string id { get; set; }
        [DisplayName("Производитель")]
        public Monufacturer monufacturer { get; set; }
        [DisplayName("Модель")]
        public Model model { get; set; }
        [DisplayName("Название")]
        public string title { get; set; }
        public Product()
        {
            id = Guid.NewGuid().ToString();
        }

        public Product(Monufacturer monufacturer, Model model, string title)
        {
            id = Guid.NewGuid().ToString();
            this.monufacturer = monufacturer;
            this.model = model;
            this.title = title;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            if(id == (obj as Product).id && model.Equals((obj as Product).model)
                && monufacturer.Equals((obj as Product).monufacturer)
                && title == (obj as Product).title)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
