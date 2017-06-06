using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SalesBusiness
    {

        public static List<Sales> GetSales(int salesYear)
        {
            Sales model = new Sales();
            List<Sales> ad = new List<Sales>();
            if (salesYear == 2017)

            {
                model.SalesName = "John";
                model.SalesAmount = 100000000;
                model.SalesYear = 2017;
                ad.Add(model);


                model = new Sales();
                model.SalesName = "Train";
                model.SalesAmount = 200000000;
                model.SalesYear = 2016;
                ad.Add(model);


                model = new Sales();
                model.SalesName = "AD";
                model.SalesAmount = 800000000;
                model.SalesYear = 2015;
                ad.Add(model);
            }
            return ad;
        }

        public string hei()
        {
            return "sadsa";
        }

    }
}
