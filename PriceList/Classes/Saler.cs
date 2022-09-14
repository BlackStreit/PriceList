using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceList.Classes
{
    internal class Saler
    {
        [DisplayName("id")]
        public string id { get; set; }
        [DisplayName("Название")]
        public string title { get; set; }
        [DisplayName("Адрес")]
        public string address { get; set; }
        [DisplayName("Телефон")]
        public string phone { get; set; }
        [DisplayName("Сайт")]
        public string site { get; set; }
        public Saler()
        {
            id = Guid.NewGuid().ToString();
        }
        public Saler(string title, string address, string phone, string site)
        {
            id = Guid.NewGuid().ToString();
            this.title = title;
            this.address = address;
            this.phone = phone;
            this.site = site;
        }
    }
}
