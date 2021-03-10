using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pardavimu_administravimas
{
    class TestClient
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string phoneNumber { get; set; }
        public string birthDay { get; set; }

        public TestClient(string em, string nm, string sr, string pN, string bD)
        {
            Email = em;
            Name = nm;
            Surname = sr;
            phoneNumber = pN;
            birthDay = bD;
        }
        //public override string ToString()
        //{
        //    string line;
        //    line = string.Format("{0, -10}   {1, -7}   {2, -13}   {3, 8}   {4, 15}",
        //        Email, Name, Surname, phoneNumber, birthDay);
        //    return line;
        //}
    }
}
