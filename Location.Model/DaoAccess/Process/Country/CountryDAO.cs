using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Model.Service;
using Location.Model.DaoAccess.Master.Country;

namespace Location.Model.DaoAccess.Process.Country
{
    public class CountryDAO
    {
        readonly string connection = Constants.DBConnection;
        public List<AllCountry> GetAllCountries()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                List<AllCountry> AllCountryList = new List<AllCountry>();
                SqlCommand cmd = new SqlCommand("GetCountries", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmd.ExecuteReader();
                AllCountry ObjAllCountry;

                while (rd.Read())
                {
                    ObjAllCountry = new AllCountry();

                    ObjAllCountry.CountryID = rd["CountryID"] == DBNull.Value ? "" : rd["CountryID"].ToString().Trim();
                    ObjAllCountry.Name = rd["Name"] == DBNull.Value ? "" : rd["Name"].ToString().Trim();
                    ObjAllCountry.Code = rd["Code"] == DBNull.Value ? "" : rd["Code"].ToString().Trim();

                    AllCountryList.Add(ObjAllCountry);
                }
                return AllCountryList;
            }
        }
        public List<AllCountry> AddCountry(AllCountry addCountryRequest)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                List<AllCountry> AllCountryList = new List<AllCountry>();
                SqlCommand cmd = new SqlCommand("InsertCountry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", addCountryRequest.Name);
                cmd.Parameters.AddWithValue("@Code", addCountryRequest.Code);
                SqlDataReader rd = cmd.ExecuteReader();
                AllCountry ObjAllCountry;

                while (rd.Read())
                {
                    ObjAllCountry = new AllCountry();

                    ObjAllCountry.CountryID = rd["CountryID"] == DBNull.Value ? "" : rd["CountryID"].ToString().Trim();
                    ObjAllCountry.Name = rd["Name"] == DBNull.Value ? "" : rd["Name"].ToString().Trim();
                    ObjAllCountry.Code = rd["Code"] == DBNull.Value ? "" : rd["Code"].ToString().Trim();

                    AllCountryList.Add(ObjAllCountry);
                }


                return AllCountryList;
            }
        }
        public List<AllCountry> UpdateCountry(AllCountry updateCountryRequest)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                List<AllCountry> AllCountryList = new List<AllCountry>();
                SqlCommand cmd = new SqlCommand("UpdateCountry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CountryID", Convert.ToInt32(updateCountryRequest.CountryID));
                cmd.Parameters.AddWithValue("@Name", updateCountryRequest.Name);
                cmd.Parameters.AddWithValue("@Code", updateCountryRequest.Code);
                SqlDataReader rd = cmd.ExecuteReader();
                AllCountry ObjAllCountry;
                while (rd.Read())
                {
                    ObjAllCountry = new AllCountry();
                    ObjAllCountry.CountryID = rd["CountryID"] == DBNull.Value ? "" : rd["CountryID"].ToString().Trim();
                    ObjAllCountry.Name = rd["Name"] == DBNull.Value ? "" : rd["Name"].ToString().Trim();
                    ObjAllCountry.Code = rd["Code"] == DBNull.Value ? "" : rd["Code"].ToString().Trim();
                    AllCountryList.Add(ObjAllCountry);
                }
                return AllCountryList;
            }
        }
        public void DeleteCountry(string countryId)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                List<AllCountry> AllCountryList = new List<AllCountry>();
                SqlCommand cmd = new SqlCommand("DeleteCountry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CountryID", Convert.ToInt32(countryId));
                SqlDataReader rd = cmd.ExecuteReader();
            }
        }
    }
}
