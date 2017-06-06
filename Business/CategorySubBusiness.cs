using Entities;
using IdentityASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CategorySubBusiness
    {

        private static ApplicationDbContext identityASPdb = new ApplicationDbContext();

        private static bool result = false;


        public static bool AddCategorySub(CategorySub model, out int categorysubId)
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
                    CategorySub categorySub = identityASPdb.CategorySub.Where(x => x.Id == categorysubId && x.isDelete != true).FirstOrDefault();

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
                    List<CategorySub> categoriesSub = identityASPdb.CategorySub.Where(x => x.Id == categoryId && x.isDelete!= true).ToList();
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


        public static bool EditCategorySub(CategorySub model)
        {
            if (model.Id > 0)
            {
                try
                {
                    IQueryable<CategorySub> categorysub = identityASPdb.CategorySub.Where(x => x.Id == model.Id && x.isDelete !=true);
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


        public static List<CategorySub> GetCategoriesSubByCategoryId(int categoryId)
        {
            List<CategorySub> categoriesSub = identityASPdb.CategorySub.Where(x => x.CategoryId == categoryId && x.isDelete != true).ToList();        
            return categoriesSub;
        }

        public static CategorySub GetCategorySubByCategorySubIdAndCategoryId(int categorysubId, int categoryId)
        {
            CategorySub categorySub = identityASPdb.CategorySub.Where(x => x.Id == categorysubId && x.CategoryId == categoryId && x.isDelete != true).FirstOrDefault();
            return categorySub;
        }

    }
}
