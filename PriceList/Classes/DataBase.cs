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
        String filename = @"pricelist.data";
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
        #region Работа с моделями
        public void addModel(Model model)
        {
            db.Store(model);
        }
        public List<Model> getModels(string title)
        {
            List<Model> list = db.Query<Model>(mdl => mdl.title.Contains(title)).ToList<Model>();
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
            try
            {
                Product product = db.Query<Product>(prd => prd.model.id == id)[0];
                db.Delete(product);
            }
            catch(Exception ex)
            {

            }
            Model model = db.Query<Model>(mdl => mdl.id == id)[0];
            db.Delete(model);
        }
        #endregion
        #region Работа с производителем
        public void addMonufacturer(Monufacturer monufacturer)
        {
            db.Store(monufacturer);
        }
        public List<Monufacturer> GetMonufacturers()
        {
            List<Monufacturer> monufacturers = db.Query<Monufacturer>().ToList<Monufacturer>();
            return monufacturers;
        }
        public void deleteMonufacturer(string id)
        {
            try
            {
                Product product = db.Query<Product>(prd => prd.monufacturer.id == id)[0];
                db.Delete(product);
            }
            catch(Exception ex)
            {

            }
            var Monufacturer = db.Query<Monufacturer>(mdl => mdl.id == id)[0];
            db.Delete(Monufacturer);
        }
        public void updateMonufacturer(Monufacturer monufacturer)
        {
            var foundMon = db.Query<Monufacturer>(mnf => mnf.id == monufacturer.id)[0];
            foundMon.title = monufacturer.title;
            foundMon.country = monufacturer.country;
            foundMon.site = monufacturer.site;
            db.Store(foundMon);
        }
        #endregion
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
