using Db4objects.Db4o;
using Db4objects.Db4o.Internal.Slots;
using Db4objects.Db4o.Linq;
using Db4objects.Db4o.Query;
using PriceList.Classes;
using Sharpen.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PriceList
{
    internal class DataBase
    {

        /// <summary>
        /// сделать все возможные выводу QueryBeExample+
        /// Native(Query)+
        /// Soda+
        /// Linq+
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
        public List<Model> getModels()
        {
            List<Model> list = db.Query<Model>().ToList<Model>();
            return list;
        }
        public List<Model> getModels(string title)
        {
            List<Model> list = db.Query<Model>(mdl => mdl.Title.Contains(title)).ToList<Model>();
            return list;
        }

        public void updateModel(Model model)
        {
            IEnumerable<Model> result = from Model mdl in db.Cast<Model>()
                                        where mdl.id == model.id
                                        select mdl;
            var modl = result.First();
            modl.Title = model.Title;
            db.Store(modl);

        }
        public void deleteModel(string id)
        {

            try
            {
                Product product = db.Query<Product>(prd => prd.model.id == id)[0];
                db.Delete(product);
            }
            catch (Exception ex)
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
            IQuery query = db.Query();
            query.Constrain(typeof(Monufacturer));
            IObjectSet result = query.Execute();
            var monufacturers = new List<Monufacturer>();
            foreach(var item in result)
            {
                monufacturers.Add(item as Monufacturer);
            }
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
        #region Работа с ценами
        public void addPrice(Price priceList)
        {
            db.Store(priceList);
        }
        public List<Price> getPrice()
        {
            return db.Query<Price>().ToList<Price>();
        }
        internal void deletePrice(string id)
        {
            var price = db.Query<Price>(prc => prc.id == id)[0];
            db.Delete(price);
        }
        internal void updatePrice(Price price)
        {
            var pattern = new Price();
            pattern.id = price.id;
            pattern.saler = null;
            pattern.product = null;
            pattern.price = 0;
            var found = db.QueryByExample(pattern).Next() as Price;
            found.price = price.price;
            db.Store(found);
        }
        public bool isPriceClone(int price, Saler saler, Product product)
        {
            var priceList = new Price();
            priceList.id = null;
            priceList.price = 0;
            priceList.saler = saler;
            priceList.product = product;
            var found = db.QueryByExample(priceList).Count;
            if (found > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Price> getPrice(Price price)
        {
            IEnumerable<Price> priceList = from Price prc in db.Cast<Price>()
                                           where prc.product.id == price.product?.id
                                            && prc.saler.id == price.saler?.id
                                            select prc;
            var list = priceList.ToList();
            return list;
        }
        public List<Product> getPriceProduct()
        {
            var list = db.Query<Price>().ToList<Price>();
            var ans = new List<Product>();
            foreach (var p in list)
            {
                ans.Add(p.product);
            }
            ans.Distinct().ToList();
            return new HashSet<Product>(ans).ToList();
        }
        public List<Saler> getPriceSaler()
        {
            var list = db.Query<Price>().ToList<Price>();
            var ans = new List<Saler>();
            foreach (var p in list)
            {
                ans.Add(p.saler);
            }
            return new HashSet<Saler>(ans).ToList();
        }
        public List<Product> getPriceProduct(string id)
        {
            var list = db.Query<Price>(prs => prs.saler.id == id).ToList<Price>();
            var ans = new List<Product>();
            foreach(var p in list)
            {
                ans.Add(p.product);
            }
            return new HashSet<Product>(ans).ToList(); ;
        }
        public List<Saler> getPriceSaler(string id)
        {
            var list = db.Query<Price>(prs => prs.product.id == id).ToList<Price>();
            var ans = new List<Saler>();
            foreach (var p in list)
            {
                ans.Add(p.saler);
            }
            return new HashSet<Saler>(ans).ToList(); ;
        }
        public double getAvarangePrice(Saler saler, Product product)
        {
            var ans = (from Price prc in db.Cast<Price>()
                      where prc.saler == saler
                      && prc.product == product
                      select prc.price).Average();
            return ans;
        }
        #endregion
        #region Работа с продуктом
        public void addProduct(Product product)
        {
            db.Store(product);
        }
        public List<Product> GetProducts()
        {
            return db.Query<Product>().ToList<Product>();
        }
        public List<Product> GetProducts(string id)
        {
            return db.Query<Product>(prd => prd.id == id).ToList<Product>();
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
        public List<Saler> GetSaler(string salerId)
        {
            return db.Query<Saler>(slr => slr.id == salerId).ToList<Saler>();
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
