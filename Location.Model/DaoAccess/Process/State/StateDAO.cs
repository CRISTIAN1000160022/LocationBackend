using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Model.DaoAccess.Master.State;
using Location.Model.Service;

namespace Location.Model.DaoAccess.Process.State
{
    public class StateDAO
    {
        readonly string connection = Constants.DBConnection;
        public List<AllState> GetAllStates()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                List<AllState> AllStateList = new List<AllState>();
                SqlCommand cmd = new SqlCommand("GetStates", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmd.ExecuteReader();
                AllState ObjAllState;
                while (rd.Read())
                {
                    ObjAllState = new AllState();
                    ObjAllState.StateID = rd["StateID"] == DBNull.Value ? "" : rd["StateID"].ToString().Trim();
                    ObjAllState.Name = rd["Name"] == DBNull.Value ? "" : rd["Name"].ToString().Trim();
                    ObjAllState.CountryID = rd["CountryID"] == DBNull.Value ? "" : rd["CountryID"].ToString().Trim();
                    ObjAllState.CountryName = rd["CountryName"] == DBNull.Value ? "" : rd["CountryName"].ToString().Trim();
                    AllStateList.Add(ObjAllState);
                }
                return AllStateList;
            }
        }
        public List<AllState> AddState(AllState addStateRequest)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                List<AllState> AllStateList = new List<AllState>();
                SqlCommand cmd = new SqlCommand("InsertState", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", addStateRequest.Name);
                cmd.Parameters.AddWithValue("@CountryID", Convert.ToInt32(addStateRequest.CountryID));
                SqlDataReader rd = cmd.ExecuteReader();
                AllState ObjAllState;
                while (rd.Read())
                {
                    ObjAllState = new AllState();
                    ObjAllState.StateID = rd["StateID"] == DBNull.Value ? "" : rd["StateID"].ToString().Trim();
                    ObjAllState.Name = rd["Name"] == DBNull.Value ? "" : rd["Name"].ToString().Trim();
                    ObjAllState.CountryID = rd["CountryID"] == DBNull.Value ? "" : rd["CountryID"].ToString().Trim();
                    ObjAllState.CountryName = rd["CountryName"] == DBNull.Value ? "" : rd["CountryName"].ToString().Trim();
                    AllStateList.Add(ObjAllState);
                }
                return AllStateList;
            }
        }
        public List<AllState> UpdateState(AllState updateStateRequest)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                List<AllState> AllStateList = new List<AllState>();
                SqlCommand cmd = new SqlCommand("UpdateState", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateID", updateStateRequest.StateID);
                cmd.Parameters.AddWithValue("@Name", updateStateRequest.Name);
                cmd.Parameters.AddWithValue("@CountryID", updateStateRequest.CountryID);
                SqlDataReader rd = cmd.ExecuteReader();
                AllState ObjAllState;
                while (rd.Read())
                {
                    ObjAllState = new AllState();
                    ObjAllState.StateID = rd["StateID"] == DBNull.Value ? "" : rd["StateID"].ToString().Trim();
                    ObjAllState.Name = rd["Name"] == DBNull.Value ? "" : rd["Name"].ToString().Trim();
                    ObjAllState.CountryID = rd["CountryID"] == DBNull.Value ? "" : rd["CountryID"].ToString().Trim();
                    ObjAllState.CountryName = rd["CountryName"] == DBNull.Value ? "" : rd["CountryName"].ToString().Trim();
                    AllStateList.Add(ObjAllState);
                }
                return AllStateList;
            }
        }
        public void DeleteState(string stateId)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteState", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateID", stateId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
