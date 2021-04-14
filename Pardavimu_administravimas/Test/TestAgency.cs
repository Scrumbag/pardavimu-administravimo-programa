using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pardavimu_administravimas
{
    class TestAgency
    {
        public string AgencyName { get; set; }
        public int AgencyCode { get; set; }
        public string phoneNr { get; set; }
        public string adress { get; set; }
        public string Country { get; set; }

        public TestAgency(string AN, int AC, string pN, string adr, string ct)
        {
            AgencyName = AN;
            AgencyCode = AC;
            phoneNr = pN;
            adress = adr;
            Country = ct;
        }
    }
}
