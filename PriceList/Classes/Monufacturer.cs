using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceList.Classes
{
    internal class Monufacturer
    {
        [DisplayName("id")]
        public string id { get; set; }
        [DisplayName("Название")]
        public string title { get; set; }
        [DisplayName("Страна")]
        public string country { get; set; }
        [DisplayName("Сайт")]
        public string site { get; set; }

        public Monufacturer()
        {
            id = Guid.NewGuid().ToString();
        }
        public Monufacturer(string title, string country, string site)
        {
            id = Guid.NewGuid().ToString();
            this.title = title;
            this.country = country;
            this.site = site;
        }
    }
}
