using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Model.DaoAccess.Master.City;
using Location.Model.Service;

namespace Location.Model.DaoAccess.Process.City
{
    public class CityDAO
    {
        readonly string connection = Constants.DBConnection;
        public List<AllCity> GetAllCities() 
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                List<AllCity> AllCityList = new List<AllCity>();
                SqlCommand cmd = new SqlCommand("GetCities", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmd.ExecuteReader();
                AllCity ObjAllCity;

                while (rd.Read())
                {
                    ObjAllCity = new AllCity();

                    ObjAllCity.CityID = rd["CityID"] == DBNull.Value ? "" : rd["CityID"].ToString().Trim();
                    ObjAllCity.Name = rd["Name"] == DBNull.Value ? "" : rd["Name"].ToString().Trim();
                    ObjAllCity.StateID = rd["StateID"] == DBNull.Value ? "" : rd["StateID"].ToString().Trim();
                    ObjAllCity.StateName = rd["StateName"] == DBNull.Value ? "" : rd["StateName"].ToString().Trim();

                    AllCityList.Add(ObjAllCity);
                }
                return AllCityList;
            }
        }
        public List<AllCity> AddCity(AllCity addCityRequest)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                List<AllCity> AllCityList = new List<AllCity>();
                SqlCommand cmd = new SqlCommand("InsertCity", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", addCityRequest.Name);
                cmd.Parameters.AddWithValue("@StateID", Convert.ToInt32(addCityRequest.StateID));
                SqlDataReader rd = cmd.ExecuteReader();
                AllCity ObjAllCity;
                while (rd.Read())
                {
                    ObjAllCity = new AllCity();

                    ObjAllCity.CityID = rd["CityID"] == DBNull.Value ? "" : rd["CityID"].ToString().Trim();
                    ObjAllCity.Name = rd["Name"] == DBNull.Value ? "" : rd["Name"].ToString().Trim();
                    ObjAllCity.StateID = rd["StateID"] == DBNull.Value ? "" : rd["StateID"].ToString().Trim();
                    ObjAllCity.StateName = rd["StateName"] == DBNull.Value ? "" : rd["StateName"].ToString().Trim();
                    AllCityList.Add(ObjAllCity);
                }
                return AllCityList;
            }
        }
        public List<AllCity> UpdateCity(AllCity updateCityRequest)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                List<AllCity> AllCityList = new List<AllCity>();
                SqlCommand cmd = new SqlCommand("UpdateCity", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CityID", updateCityRequest.CityID);
                cmd.Parameters.AddWithValue("@Name", updateCityRequest.Name);
                cmd.Parameters.AddWithValue("@StateID", updateCityRequest.StateID);
                SqlDataReader rd = cmd.ExecuteReader();
                AllCity ObjAllCity;
                while (rd.Read())
                {
                    ObjAllCity = new AllCity();
                    ObjAllCity.CityID = rd["CityID"] == DBNull.Value ? "" : rd["CityID"].ToString().Trim();
                    ObjAllCity.Name = rd["Name"] == DBNull.Value ? "" : rd["Name"].ToString().Trim();
                    ObjAllCity.StateID = rd["StateID"] == DBNull.Value ? "" : rd["StateID"].ToString().Trim();
                    ObjAllCity.StateName = rd["StateName"] == DBNull.Value ? "" : rd["StateName"].ToString().Trim();
                    AllCityList.Add(ObjAllCity);
                }
                return AllCityList;
            }
        }
        public void DeleteCity(string cityId)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteCity", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CityID", cityId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
