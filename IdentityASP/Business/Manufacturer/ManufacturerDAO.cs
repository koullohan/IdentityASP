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
    public class ManufacturerDAO
    {
        private static ApplicationDbContext identityASPdb = new ApplicationDbContext();

        private static bool result = false;


        public static bool AddManufacturer(ManufacturerViewModel model, out int manufacturerId)
        {
            var manufacturer = new Manufacturer();
            if (model.Id == 0)
            {
                try
                {
                    //ManufacturerId is set to autoincrement in Manufacturer table.       
                    manufacturer.Id = model.Id;
                    manufacturer.Name = model.Name;
                    manufacturer.Location = model.Location;
                    manufacturer.Manager = model.Manager;
                    manufacturer.Telephone = model.Telephone;
                    manufacturer.Fax = model.Fax;
                    manufacturer.Email = model.Email;
                    manufacturer.Mobile = model.Mobile;
                    identityASPdb.Manufacturer.Add(manufacturer);
                    identityASPdb.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {
                    throw;
                }

            }

            manufacturerId = manufacturer.Id;
            return result;
        }


        public static bool DeleteManufacturer(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    //var productId = identityASPdb.Products.Where(x => x.Id == Id).Select(x => x.Id).FirstOrDefault();
                    Manufacturer manufacturer = identityASPdb.Manufacturer.Where(x => x.Id == Id).FirstOrDefault();
                    if (manufacturer.Id != 0)
                    {
                        manufacturer.isDelete = true;
                        identityASPdb.Entry(manufacturer).State = EntityState.Modified;
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


        public static bool EditManufacturer(ManufacturerViewModel model)
        {
            if (model.Id > 0)
            {
                try
                {
                    IQueryable<Manufacturer> manufacturer = identityASPdb.Manufacturer.Where(x => x.Id == model.Id);
                    if (manufacturer != null)
                    {
                        foreach (var item in manufacturer)
                        {
                            item.Id = model.Id;
                            item.Name = model.Name;
                            item.Location = model.Location;
                            item.Manager = model.Manager;
                            item.Telephone = model.Telephone;
                            item.Fax = model.Fax;
                            item.Email = model.Email;
                            item.Mobile = model.Mobile;
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
    

        public static string GetManufacturerNameByManufacturerId(int id)
        {
            var manufacturer = identityASPdb.Manufacturer.Where(x => x.isDelete != true && x.Id == id).FirstOrDefault();

            return manufacturer.Name;
        }


        public static List<SelectListItem> GetManufacturersSelectList()
        {
            List<Manufacturer> manufacturers = identityASPdb.Manufacturer.Where(x => x.isDelete != true).ToList();
            var manufacturersSelectList = new List<SelectListItem>();
            foreach (var model in manufacturers)
            {
                var item = new SelectListItem();
                item.Value = model.Id.ToString();
                item.Text = model.Name;
                manufacturersSelectList.Add(item);
            }

            return manufacturersSelectList;
        }

        public static List<ManufacturerViewModel> GetManufacturers()
        {
            List<Manufacturer> manufacturers = identityASPdb.Manufacturer.Where(x => x.isDelete != true).ToList();
            var manufacturersList = new List<ManufacturerViewModel>();
            foreach (var item in manufacturers)
            {
                var manufacturer = new ManufacturerViewModel();
                manufacturer.Id = item.Id;
                manufacturer.Name = item.Name;
                manufacturer.Location = item.Location;
                manufacturer.Manager = item.Manager;
                manufacturer.Telephone = item.Telephone;
                manufacturer.Fax = item.Fax;
                manufacturer.Email = item.Email;
                manufacturer.Mobile = item.Mobile;
                manufacturersList.Add(manufacturer);
            }

            return manufacturersList;
        }
   

    }
}