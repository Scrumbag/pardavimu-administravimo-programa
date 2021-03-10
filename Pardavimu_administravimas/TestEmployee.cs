using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pardavimu_administravimas
{
    class TestEmployee
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string phoneNumber { get; set; }
        public string birthDay { get; set; }
        public int sellCount { get; set; }
        public double moneyMade { get; set; }

        public TestEmployee(string email, string name, string surname,
            string pNumber, string birthD, int sellC, double mMade)
        {
            Email = email;
            Name = name;
            Surname = surname;
            phoneNumber = pNumber;
            birthDay = birthD;
            sellCount = sellC;
            moneyMade = mMade;
        }
        //public override string ToString()
        //{
        //    string line;
        //    line = string.Format("{0, -10}   {1, -7}   {2, -13}   {3, 8}   {4, 15}   {5, 4}   {5, 2}",
        //        Email, Name, Surname, phoneNumber, birthDay, sellCount, moneyMade);
        //    return line;
        //}
    }
}
