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
    public class ManufacturerBusiness
    {
        private static ApplicationDbContext identityASPdb = new ApplicationDbContext();

        private static bool result = false;


        public static bool AddManufacturer(Manufacturer model, out int manufacturerId)
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


        public static bool EditManufacturer(Manufacturer model)
        {
            if (model.Id > 0)
            {
                try
                {
                    identityASPdb.Entry(model).State = EntityState.Modified;
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

        public static List<Manufacturer> GetManufacturers()
        {
            List<Manufacturer> manufacturers = identityASPdb.Manufacturer.Where(x => x.isDelete != true).ToList();
            var manufacturersList = new List<Manufacturer>();
            foreach (var item in manufacturers)
            {
                var manufacturer = new Manufacturer();
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
