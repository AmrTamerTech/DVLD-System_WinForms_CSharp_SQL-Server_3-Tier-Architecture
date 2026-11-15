using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsCountry
    {
        public int CountryID {  get; set; }
        public string CountryName { get; set; }

        public clsCountry()
        {
            CountryID = -1;
            CountryName = "";
        }

        private clsCountry(int countryID, string countryName)
        {
            this.CountryID = countryID;
            this.CountryName = countryName;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }

        public static clsCountry Find(string CountryName)
        {
            int ID = -1;

            if (clsCountryData.GetCountryInfoByName(CountryName, ref ID))
                return new clsCountry(ID, CountryName);
            else return null;

        }

        public static clsCountry Find(int CountryID)
        {
            string CountryName = "";

            if (clsCountryData.GetCountryInfoByID(CountryID, ref CountryName))
                return new clsCountry(CountryID, CountryName);
            else return null;

        }

    }
}
