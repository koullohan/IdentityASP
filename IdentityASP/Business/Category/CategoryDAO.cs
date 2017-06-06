using IdentityASP.Models;
using IdentityASP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityASP.Business
{
    public class CategoryDAO
    {
        private static ApplicationDbContext identityASPdb = new ApplicationDbContext();

        private static bool result = false;
    

        public static bool AddCategory(CategoryViewModel model, out int categoryId)
        {
            var category = new Category();
            if (model.Id == 0)
            {
                try
                {
                    category.Id = model.Id;
                    category.Description = model.Description;
                    identityASPdb.Category.Add(category);
                    identityASPdb.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            categoryId = category.Id;
            return result;
        }


        public static bool DeleteCategory(int categoryId)                                    //  Delete
        {
            try
            {
                if (categoryId != 0)
                {
                    //var productId = identityASPdb.Products.Where(x => x.Id == Id).Select(x => x.Id).FirstOrDefault();
                    Category category = identityASPdb.Category.Where(x => x.Id == categoryId).FirstOrDefault();
                    if (category.Id != 0)
                    {
                        category.isDelete = true;                                            //  set flag to true(deleted)
                        identityASPdb.Entry(category).State = EntityState.Modified;
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

        
        public static bool EditCategory(CategoryViewModel model)
        {
            if (model.Id > 0)
            {
                try
                {
                    IQueryable<Category> category = identityASPdb.Category.Where(x => x.Id == model.Id);
                    if (category != null)
                    {
                        foreach (var item in category)
                        {
                            item.Id = model.Id;
                            item.Description = model.Description;
                            identityASPdb.Entry(item).State = EntityState.Modified;
                        }
                        identityASPdb.SaveChanges();
                        result = true;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return result;
        }


        public static List<SelectListItem> GetCategoriesSelectList()
        {
            List<Category> categories = identityASPdb.Category.Where(x => x.isDelete != true).ToList();
            var categoriesSelectList = new List<SelectListItem>();
            foreach (var model in categories)
            {
                var item = new SelectListItem();
                item.Value = model.Id.ToString();
                item.Text = model.Description;
                categoriesSelectList.Add(item);
            }

            return categoriesSelectList;
        }

        public static List<CategoryViewModel> GetCategories()
        {
            List<Category> categories = identityASPdb.Category.Where(x => x.isDelete != true).ToList();
            var categoriesList = new List<CategoryViewModel>();
            foreach (var item in categories)
            {
                var model = new CategoryViewModel();
                model.Id = item.Id;
                model.Description = item.Description;
                categoriesList.Add(model);
            }

            return categoriesList;
        }


        public static CategoryViewModel GetCategoryByCategoryId(int categoryId)
        {
            Category category = identityASPdb.Category.Where(x => x.isDelete != true && x.Id == categoryId).FirstOrDefault();
            var model = new CategoryViewModel();
            model.Id = category.Id;
            model.Description = category.Description;
            return model;
        }


        public static string GetCategoryDescriptionByCategoryId(int categoryId)
        {
            Category category = identityASPdb.Category.Where(x => x.isDelete != true && x.Id == categoryId).FirstOrDefault();
            var model = new CategoryViewModel();
            return model.Description;
        }  


    }
}