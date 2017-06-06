using IdentityASP.Models;
using IdentityASP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentityASP.Business
{
    public class ProductDAO
    {
        private static ApplicationDbContext identityASPdb = new ApplicationDbContext();

        private static bool result = false;


        public static bool AddProduct(ProductViewModel model, out int productId)
        {
            var product = new Product();
            if (model.Id == 0)
            {
                try
                {
                    //ProductId is set to autoincrement in Product table.       
                    product.ManufacturerId = model.ManufacturerId;
                    product.CategoryId = model.CategoryId;
                    product.Name = model.Name;
                    product.Description = model.Description;
                    product.Model = model.Model;
                    product.ReleasedDate = model.ReleasedDate;
                    product.ReleasedYear = model.ReleasedYear;
                    identityASPdb.Product.Add(product);
                    identityASPdb.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            productId = product.Id;
            return result;
        }


        public static bool DeleteProduct(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    Product product = identityASPdb.Product.Where(x => x.Id == Id).FirstOrDefault();
                    if (product.Id != 0)
                    {
                        product.isDelete = true;
                        identityASPdb.Entry(product).State = EntityState.Modified;
                        identityASPdb.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }


        public static bool EditProduct(ProductViewModel model)
        {
            if (model.Id > 0)
            {
                try
                {
                    Product product = identityASPdb.Product.Where(x => x.Id == model.Id).FirstOrDefault();
                    if (product != null)
                    {
                        product.ManufacturerId = model.ManufacturerId;
                        product.CategoryId = model.CategoryId;
                        product.Name = model.Name;
                        product.Description = model.Description;
                        product.Model = model.Model;
                        product.ReleasedDate = model.ReleasedDate;
                        product.ReleasedYear = model.ReleasedYear;
                        identityASPdb.Entry(product).State = EntityState.Modified;
                    }
                    identityASPdb.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return result;
        }

        
        public static List<ProductViewModel> GetProducts()
        {           
            List<Product> products = identityASPdb.Product.Where(x=>x.isDelete != true).ToList();
            var productsList = new List<ProductViewModel>();
            foreach (var item in products)
            {
                var product = new ProductViewModel();
                product.Id = item.Id;
                product.CategoryId = item.CategoryId;
                product.CategoryDescription = CategoryDAO.GetCategoryDescriptionByCategoryId(item.CategoryId);
                product.ManufacturerId = item.ManufacturerId;
                product.ManufacturerName = ManufacturerDAO.GetManufacturerNameByManufacturerId(item.ManufacturerId);
                product.Name = item.Name;
                product.Description = item.Description;
                product.Model = item.Model;
                product.ReleasedDate= item.ReleasedDate;
                product.ReleasedYear = item.ReleasedYear;
                productsList.Add(product);
            }

            return productsList;
        }
            

    }
}