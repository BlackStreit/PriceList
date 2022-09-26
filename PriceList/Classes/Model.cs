using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceList.Classes
{
    internal class Model
    {
        [DisplayName("id")]
        public string id { get; set; }
        private string _title;
        [DisplayName("Название")]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }



        public Model()
        {
            id = Guid.NewGuid().ToString();
        }

        public Model(string title)
        {
            id = Guid.NewGuid().ToString();
            this._title = title;
        }

        public string getInfo()
        {
            var info = $"id: {id}\nНазвание: {_title}";
            return info;
        }

        public override string ToString()
        {
            return _title;
        }
    }
}
