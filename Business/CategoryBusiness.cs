using Entities;
using IdentityASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Business
{
    public class CategoryBusiness
    {

        private static ApplicationDbContext identityASPdb = new ApplicationDbContext();

        private static bool result = false;


        public static bool AddCategory(Category category, out int categoryId)
        {

            if (category.Id == 0)
            {
                try
                {      
                    identityASPdb.Category.Add(category);
                    identityASPdb.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    throw ex;
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
                    Category category = identityASPdb.Category.Where(x => x.Id == categoryId && x.isDelete!=true).FirstOrDefault();
                    if (category.Id != 0)
                    {
                        category.isDelete = true;                                            //  set flag to true(deleted)
                        identityASPdb.Entry(category).State = EntityState.Modified;
                        identityASPdb.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public static bool EditCategory(Category model)
        {

            if (model.Id > 0)
            {
                try
                {
                    IQueryable<Category> category = identityASPdb.Category.Where(x => x.Id == model.Id && x.isDelete != true);
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
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;

        }


        public static List<SelectListItem> GetCategoriesSelectList()
        {

            try
            {
                return identityASPdb.Category.Where(x => x.isDelete != true).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Description }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static List<Category> GetCategories()
        {

            try
            {
                return identityASPdb.Category.Where(x => x.isDelete != true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static Category GetCategoryByCategoryId(int categoryId)
        {

            try
            {
                return identityASPdb.Category.Where(x => x.isDelete != true && x.Id == categoryId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static string GetCategoryDescriptionByCategoryId(int categoryId)
        {
   
            try
            {

               var categoryDescription = (from category in identityASPdb.Category
                                           where (category.Id == categoryId && category.isDelete != true)
                                           select category.Description).Single();
                return categoryDescription;

            }
            catch(Exception ex)
            {
                throw ex;
            }
         
        }

    }
}
