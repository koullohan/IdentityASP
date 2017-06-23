using Business;
using Entities;
using IdentityASP.Models;
using IdentityASP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityASP.Controllers
{

    [Authorize(Roles = "Admin")]
    public class ManufacturerController : Controller
    {

        private bool result = false;
        private int manufacturerId = 0;

        [HttpGet]
        public ActionResult Index()
        {

            ManufacturerViewModel viewmodel = new ManufacturerViewModel();
            viewmodel.ManufacturerList = new List<ManufacturerViewModel>();
            var manufacturers = ManufacturerBusiness.GetManufacturers();

            foreach (var item in manufacturers)
            {
                var manufacturer = new ManufacturerViewModel();
                manufacturer.Id = item.Id;
                manufacturer.Name = item.Name;
                manufacturer.Location = item.Location;
                manufacturer.Manager = item.Manager;
                manufacturer.Telephone = item.Telephone;
                manufacturer.Email = item.Email;
                manufacturer.Fax = item.Fax;
               
                viewmodel.ManufacturerList.Add(manufacturer);

            }

            return View(viewmodel);
        }


        [HttpPost]
        public ActionResult Create(Manufacturer viewmodel)
        {
                                
            if (ModelState.IsValid)
            {
                if (viewmodel.Id == 0)
                {
                    result = ManufacturerBusiness.AddManufacturer(viewmodel, out manufacturerId);

                    viewmodel.Id = manufacturerId;
                    if (result)
                    {
                        return Json(new { data = viewmodel, success = result + "Add", JsonRequestBehavior.AllowGet });
                    }
                }
                else if (viewmodel.Id != 0)
                {
                    result = ManufacturerBusiness.EditManufacturer(viewmodel);

                    if (result)
                    {
                        return Json(new { data = viewmodel, success = result + "Edit", JsonRequestBehavior.AllowGet });
                    }
                }
            }

            return Json(new { success = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int manufacturerId)
        {
            bool result = false;

            if (ModelState.IsValid)
            {
                result = ManufacturerBusiness.DeleteManufacturer(manufacturerId);

                if (result)
                {
                    return Json(new { success = result });
                }
            }

            return Json(new { success = result });
        }
    }
}