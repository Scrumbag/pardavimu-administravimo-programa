using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pardavimu_administravimas
{
    class TestTrips
    {
        public string City { get; set; }
        public string date { get; set; }
        public double price { get; set; }
        
        public TestTrips(string ct, string dt, double pr)
        {
            City = ct;
            date = dt;
            price = pr;
        }
        //public override string ToString()
        //{
        //    string line;
        //    line = string.Format("{0, -10}   {1, -7}   {2, -13}",
        //        City, date, price);
        //    return line;
        //}


    }
}
