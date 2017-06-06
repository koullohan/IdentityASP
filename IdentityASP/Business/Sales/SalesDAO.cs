using IdentityASP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityASP.Business
{
    public class SalesDAO
    {
        public static List<SalesViewModel> GetSales(int salesYear)
        {
            SalesViewModel viewmodel = new SalesViewModel();
            List<SalesViewModel> ad = new List<SalesViewModel>();
            if (salesYear == 2017)

            {
                viewmodel.SalesName = "John";
                viewmodel.SalesAmount = 100000000;
                viewmodel.SalesYear = 2017;
                ad.Add(viewmodel);


                viewmodel = new SalesViewModel();
                viewmodel.SalesName = "Train";
                viewmodel.SalesAmount = 200000000;
                viewmodel.SalesYear = 2016;
                ad.Add(viewmodel);


                viewmodel = new SalesViewModel();
                viewmodel.SalesName = "AD";
                viewmodel.SalesAmount = 800000000;
                viewmodel.SalesYear = 2015;
                ad.Add(viewmodel);
            }
            return ad;
        }

        public string hei()
        {
            return "sadsa";
        }
    }
}