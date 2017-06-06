using Entities;
using Entities.VM;
using IdentityASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductBusiness
    {
        private static ApplicationDbContext identityASPdb = new ApplicationDbContext();

        private static bool result = false;


        public static bool AddProduct(Product model, out int productId)
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
                catch (Exception ex)
                {
                    throw ex;
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


        public static bool EditProduct(Product model)
        {
            if (model.Id > 0)
            {
                try
                {
                    var product = new Product();
                    var queryResult = identityASPdb.Product.Where(x => x.Id == model.Id).FirstOrDefault();
                    if (queryResult != null)
                    {
                        queryResult.Id = model.Id;
                        queryResult.ManufacturerId = model.ManufacturerId;
                        queryResult.CategoryId = model.CategoryId;
                        queryResult.Name = model.Name;
                        queryResult.Description = model.Description;
                        queryResult.Model = model.Model;
                        queryResult.ReleasedDate = model.ReleasedDate;
                        queryResult.ReleasedYear = model.ReleasedYear;
                        identityASPdb.Entry(queryResult).State = EntityState.Modified;
                        identityASPdb.SaveChanges();
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }


        public static List<ProductViewModel> GetProducts()
        {
          
            try
            {
               var products = identityASPdb.Product
                .Join(identityASPdb.Category, p => p.CategoryId, pc => pc.Id, (p, pc) => new { p, pc })
                .Join(identityASPdb.Manufacturer, ppc => ppc.p.ManufacturerId, c => c.Id, (ppc, c) => new { ppc, c })
                .Where(x => x.ppc.p.isDelete != true)
                .Select(m => new ProductViewModel {
                    Id = m.ppc.p.Id,
                    CategoryId = m.ppc.pc.Id,
                    CategoryDescription = m.ppc.pc.Description,
                    ManufacturerId = m.ppc.p.ManufacturerId,
                    ManufacturerName = m.c.Name,
                    Name = m.ppc.pc.Description,
                    Description = m.ppc.p.Description,
                    Model = m.ppc.p.Model,
                    ReleasedDate = m.ppc.p.ReleasedDate,
                    ReleasedYear = m.ppc.p.ReleasedYear
                }).ToList();

                return products;
            }
            catch (Exception)
            {
                throw;
            } 
                                        
        }

        public static Product GetProductByProductId(int productId)
        {
            try
            {
                var product = identityASPdb.Product.Where(x => x.isDelete != true && x.Id == productId).FirstOrDefault();
                return product;
            }
            catch (Exception)
            {
                throw;
            }

            
        }

    }
}
