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

        /// <summary>
        /// сделать все возможные выводу QuertBeExample, Query, 
        /// </summary>
        const String filename = @"pricelist.yap";
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
        #region Работа с продуктом
        public void addProduct(Product product)
        {
            db.Store(product);
        }
        public List<Product> GetProducts()
        {
            return db.Query<Product>().ToList<Product>();
        }
        internal void deleteProduct(string id)
        {
            try
            {
                var price = db.Query<Price>(prs => prs.product.id == id)[0];
                db.Delete(price);
            }
            catch { }
            var product = db.Query<Product>(prd => prd.id == id)[0];
            db.Delete(product);
        }
        public bool isProductClone(Model model, Monufacturer monufacturer)
        {
            var product = new Product();
            product.id = null;
            product.title = null;
            product.model = model;
            product.monufacturer = monufacturer;
            var found = db.QueryByExample(product).Count;
            if (found > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void updateProduct(Product product)
        {
            var found = db.Query<Product>(prd => prd.id == product.id)[0];
            found.title = product.title;
            found.model = product.model;
            found.monufacturer = product.monufacturer;
            db.Store(found);
        }
        #endregion
        #region Работа с Продавцами
        public void addSaler(Saler saler)
        {
            db.Store(saler);
        }
        public List<Saler> GetSaler()
        {
            return db.Query<Saler>().ToList<Saler>();
        }
        public void deleteSaler(string id)
        {
            try
            {
                Price product = db.Query<Price>(prd => prd.saler.id == id)[0];
                db.Delete(product);
            }
            catch (Exception ex)
            {

            }
            var saler = db.Query<Saler>(slr => slr.id == id)[0];
            db.Delete(saler);
        }

        internal void updateSaler(Saler saler)
        {
            var found = db.Query<Saler>(slr => slr.id == saler.id)[0];
            found.title = saler.title;
            found.address = saler.address;
            found.phone = saler.phone;
            found.site = saler.site;
            db.Store(found);

        }


        #endregion
    }
}
