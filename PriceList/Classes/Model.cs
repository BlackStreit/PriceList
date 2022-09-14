using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceList
{
    internal class Model
    {
        [DisplayName("id")]
        public string id { get; set; }
        [DisplayName("Название")]
        public string title { get; set; }

        public Model()
        {
            id = Guid.NewGuid().ToString();
        }
        public Model(string title)
        {
            id = Guid.NewGuid().ToString();
            this.title = title;
        }
    }
}
