using Business;
using Entities;
using IdentityASP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityASP.Controllers
{
    //Category  
    [Authorize(Roles = "Admin")]

    public class CategoryController : Controller
    {

        private bool result = false;
        private int categoryId = 0;

        [HttpGet]
        public ActionResult Index()
        {

            Category model = new Category();
            model.CategoryList = CategoryBusiness.GetCategories();
            return View(model);
        }


        public ActionResult AddCategory()
        {         
            return PartialView("AddCategory", new CategoryViewModel());
        }
 

        public ActionResult DeleteCategory(int categoryId)
        {

            if (ModelState.IsValid)
            {
                result = CategoryBusiness.DeleteCategory(categoryId);

                if (result)
                {
                    return Json(new { success = result});
                }
            }

            return Json(new { success = result });
        }


        public ActionResult EditCategory(int id)
        {
                var model = new Category();
                model = CategoryBusiness.GetCategoryByCategoryId(id);
                return PartialView("EditCategory", model);
        }

        [HttpPost]
        public ActionResult SaveCategory(Category viewmodel)
        {
            if (ModelState.IsValid)
            {
                if (viewmodel.Id == 0)
                {
                    
                    result = CategoryBusiness.AddCategory(viewmodel, out categoryId);
                    viewmodel.Id = categoryId;
                    if (result)
                    {
                        return Json(new { data = viewmodel, success = result + "Add", JsonRequestBehavior.AllowGet });
                    }
                }
                else if (viewmodel.Id != 0)
                {
                    result = CategoryBusiness.EditCategory(viewmodel);
                    if (result)
                    {
                        return Json(new { data = viewmodel, success = result + "Edit", JsonRequestBehavior.AllowGet });
                    }
                }
            }

            return Json(new { success = result }, JsonRequestBehavior.AllowGet);
        }
    }
}