using IdentityASP.Models;
using IdentityASP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentityASP.Business
{
    public class CategorySubDAO
    {
        private static ApplicationDbContext identityASPdb = new ApplicationDbContext();

        private static bool result = false;
        

        public static bool AddCategorySub(CategorySubViewModel model, out int categorysubId)
        {
            var categorysub = new CategorySub();
            if (model.Id == 0)
            {
                try
                {
                    categorysub.CategoryId = model.CategoryId;
                    categorysub.Id = model.Id;
                    categorysub.Description = model.Description;
                    identityASPdb.CategorySub.Add(categorysub);
                    identityASPdb.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            categorysubId = categorysub.Id;
            return result;
        }

     
        public static bool DeleteCategorySub(int categorysubId)
        {
            try
            {
                if (categorysubId != 0)
                {
                    CategorySub categorySub = identityASPdb.CategorySub.Where(x => x.Id == categorysubId).FirstOrDefault();

                    categorySub.isDelete = true;                                           //  set flag to true(deleted)
                    identityASPdb.Entry(categorySub).State = EntityState.Modified;
                    identityASPdb.SaveChanges();
                    result = true;

                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }


        public static bool DeleteCategoriesSubByCategoryId(int categoryId)
        {
            try
            {
                if (categoryId != 0)
                {
                    List<CategorySub> categoriesSub = identityASPdb.CategorySub.Where(x => x.Id == categoryId).ToList();
                    foreach (var item in categoriesSub)
                    {
                        item.isDelete = true;                                           //  set flag to true(deleted)
                        identityASPdb.Entry(item).State = EntityState.Modified;
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


        public static bool EditCategorySub(CategorySubViewModel model)
        {
            if (model.Id > 0)
            {
                try
                {
                    IQueryable<CategorySub> categorysub = identityASPdb.CategorySub.Where(x => x.Id == model.Id);
                    if (categorysub != null)
                    {
                        foreach (var item in categorysub)
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


        public static List<CategorySubViewModel> GetCategoriesSubByCategoryId(int categoryId)
        {
            List<CategorySub> categoriesSub = identityASPdb.CategorySub.Where(x => x.isDelete != true && x.CategoryId == categoryId).ToList();
            var categoriesSubList = new List<CategorySubViewModel>();
            foreach (var item in categoriesSub)
            {
                var categorySub = new CategorySubViewModel();
                categorySub.Id = item.Id;
                categorySub.Description = item.Description;
                categoriesSubList.Add(categorySub);
            }

            return categoriesSubList;
        }

        public static CategorySubViewModel GetCategorySubByCategorySubIdAndCategoryId(int categorysubId,int categoryId)
        {
            CategorySub categorySub = identityASPdb.CategorySub.Where(x => x.isDelete != true && x.Id == categorysubId && x.CategoryId == categoryId).FirstOrDefault();

            var model = new CategorySubViewModel();
            model.Id = categorySub.Id;
            model.Description = categorySub.Description;
            model.CategoryId = categorySub.CategoryId;
            return model;
        }
     

    }
}