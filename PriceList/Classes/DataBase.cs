using Db4objects.Db4o;
using PriceList.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceList
{
    internal class DataBase
    {
        String filename = @"C:\Users\Администратор\source\repos\PriceList\pricelist.data";
        IObjectContainer db;
        public void dbConnect()
        {
            db = Db4oFactory.OpenFile(filename);
            db.Ext().Configure().ObjectClass(typeof(Price)).CascadeOnActivate(true);
            db.Ext().Configure().ObjectClass(typeof(Product)).CascadeOnActivate(true);
        }
        public void dbClose()
        {
            db.Close();
        }
        //Work with models
        public void addModel(Model model)
        {
            db.Store(model);
        }
        public List<Model> getModels()
        {
            List<Model> list = db.Query<Model>().ToList<Model>();
            return list;
        }

        public void updateModel(Model model)
        {
            Model fModel = db.Query<Model>(mdl => mdl.id == model.id)[0];
            fModel.title = model.title;
            db.Store(fModel);

        }
        public void deleteModel(string id)
        {

            Product product = db.Query<Product>(prd => prd.model.id == id)[0];
            db.Delete(product);
            Model model = db.Query<Model>(mdl => mdl.id == id)[0];
            db.Delete(model);
        }
        //Work with Monufacturer
        public void addMonufacturer(Monufacturer monufacturer)
        {
            db.Store(monufacturer);
        }
        public List<Monufacturer> GetMonufacturers()
        {
            List<Monufacturer> monufacturers = db.Query<Monufacturer>().ToList<Monufacturer>();
            return monufacturers;
        }
        //Work with PriceList
        public void addPrice(Price priceList)
        {
            db.Store(priceList);
        }
        public List<Price> getPrice()
        {
            return db.Query<Price>().ToList<Price>();
        }
        //Work with Product
        public void addProduct(Product product)
        {
            db.Store(product);
        }
        public List<Product> GetProducts()
        {
            return db.Query<Product>().ToList<Product>();
        }
        //Work with Saler
        public void addSaler(Saler saler)
        {
            db.Store(saler);
        }
        public List<Saler> GetSaler()
        {
            return db.Query<Saler>().ToList<Saler>();
        }
    }
}
