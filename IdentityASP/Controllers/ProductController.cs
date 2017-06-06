using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityASP.Models;
using Business;
using IdentityASP.Models.ViewModel;
using Entities;

namespace IdentityASP.Controllers
{

    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {

        private bool result = false;
        private int productId = 0;

        [HttpGet]
        public ActionResult Index()
        {

            var viewmodel = new ProductViewModel();                     
            viewmodel.ProductList = new List<ProductViewModel>();

            var productList = ProductBusiness.GetProducts();


            foreach (var item in productList)
            {
                var product = new ProductViewModel();
                product.Id = item.Id;
                product.CategoryId = item.CategoryId;
                product.CategoryDescription = item.CategoryDescription;
                product.ManufacturerId = item.ManufacturerId;
                product.ManufacturerName = 
                product.Name = item.Name;
                product.Description = item.Description;
                product.Model = item.Model;
                product.ReleasedDate = item.ReleasedDate;
                product.ReleasedYear = item.ReleasedYear;
                viewmodel.ProductList.Add(product);
        
            }

            return View(viewmodel);
        }

        public PartialViewResult AddProduct()
        {

            ViewBag.Categories = CategoryBusiness.GetCategoriesSelectList();
            ViewBag.Manufacturers = ManufacturerBusiness.GetManufacturersSelectList();

            return PartialView("AddProduct", new Product());
        }

        public PartialViewResult EditProduct(int id)
        {
           
            ViewBag.Categories = CategoryBusiness.GetCategoriesSelectList();
            ViewBag.Manufacturers = ManufacturerBusiness.GetManufacturersSelectList();
            var product = ProductBusiness.GetProductByProductId(id);
            return PartialView("AddProduct", product);
        }



        [HttpPost]
        public ActionResult Create(Product product)
        {

            if (ModelState.IsValid)
            {
                if(product.Id == 0)
                {
                    result = ProductBusiness.AddProduct(product, out productId);
                    if (result)
                    {
                        ProductViewModel viewmodel = new ProductViewModel();
                        viewmodel.Id = productId;                       
                        viewmodel.CategoryDescription = Request.Form["CategoryDescription"];
                        viewmodel.ManufacturerName = Request.Form["ManufacturerName"];
                        viewmodel.Name = product.Name;
                        viewmodel.Description = product.Description;
                        viewmodel.Model = product.Model;
                        viewmodel.ReleasedDate = product.ReleasedDate;
                        viewmodel.ReleasedYear = product.ReleasedYear;
                        return Json(new { data = viewmodel, success = result + "Add", JsonRequestBehavior.AllowGet });
                    }
                }
                else if(product.Id != 0)
                {
                    var x = Request.Form["CategoryDescription"];
                    var y = Request.Form["ManufacturerName"];
                    result = ProductBusiness.EditProduct(product);
                    if (result)
                    {
                        ProductViewModel viewmodel = new ProductViewModel();
                        viewmodel.Id = product.Id;
                        viewmodel.CategoryDescription = x;
                        viewmodel.ManufacturerName = y;
                        viewmodel.Name = product.Name;
                        viewmodel.Description = product.Description;
                        viewmodel.Model = product.Model;
                        viewmodel.ReleasedDate = product.ReleasedDate;
                        viewmodel.ReleasedYear = product.ReleasedYear;
                        return Json(new { data = viewmodel, success = result+"Edit", JsonRequestBehavior.AllowGet });
                    }
                }             
            }

            return Json(new { success = result }, JsonRequestBehavior.AllowGet);              
        }

        [HttpPost]     
        public ActionResult Delete(int productId)
        {
        
            if (ModelState.IsValid)
            {
                result = ProductBusiness.DeleteProduct(productId);

                if (result)
                {
                    return Json(new { success = result});
                }
            }

            return Json(new { success = result });
        }

    }
}