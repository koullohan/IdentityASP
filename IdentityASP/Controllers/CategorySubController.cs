using Business;
using Entities;
using Entities.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityASP.Controllers
{

    [Authorize(Roles = "Admin")]
    public class CategorySubController : Controller
    {

        private int categorysubId = 0;

        private bool result = false;
        

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult AddCategorySub(int categoryId)
        {
            var categorySub = new CategorySub();
            categorySub.CategoryId = categoryId;
            return PartialView("AddCategorySub", categorySub);
        }      

        [HttpPost]
        public ActionResult Delete(int categorysubId)
        {
           
            if (ModelState.IsValid)
            {
               
                result = CategorySubBusiness.DeleteCategorySub(categorysubId);
                if (result)
                {
                    return Json(new { success = result });
                }
            }

            return Json(new { success = result });
        }

        [HttpPost]
        public ActionResult DeleteAllCategorySub(int categoryId)
        {
            
            if (ModelState.IsValid)
            {
                result = CategorySubBusiness.DeleteCategoriesSubByCategoryId(categoryId);
                if (result)
                {
                    return Json(new { success = result });
                }
            }

            return Json(new { success = result });
        }


        public PartialViewResult EditCategorySub(int categorysubId, int categoryId)
        {
            var model = new CategorySub();
            model = CategorySubBusiness.GetCategorySubByCategorySubIdAndCategoryId(categorysubId, categoryId);
            return PartialView("EditCategorySub", model);
        }


        public ActionResult GetCategoriesSub(int categoryId)
        {

            var model = new CategorySubViewModel();
            model.CategorySubList = CategorySubBusiness.GetCategoriesSubByCategoryId(categoryId);

            return Json(new { data = model.CategorySubList, success = "true", JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult SaveCategorySub(CategorySubViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    result = CategorySubBusiness.AddCategorySub(model, out categorysubId);
                    model.Id = categorysubId;
                    if (result)
                    {
                        return Json(new { data = model, success = result + "Add", JsonRequestBehavior.AllowGet });
                    }
                }
                else if (model.Id != 0)
                {
                    result = CategorySubBusiness.EditCategorySub(model);
                    if (result)
                    {
                        return Json(new { data = model, success = result + "Edit", JsonRequestBehavior.AllowGet });
                    }
                }
            }

            return Json(new { success = result }, JsonRequestBehavior.AllowGet);
        }
    }
}