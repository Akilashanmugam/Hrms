using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HrmsWeb.Models;

namespace HrmsWeb.Controllers
{
    public class LeaveTypeDBHandle
    {

        private SqlConnection con;
        private DateTime dt1;
        //private DateTime dt2;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);
        }
        // ********** VIEW User DETAILS ********************
        public List<LeaveTypeModel> List()
        {
            connection();
            List<LeaveTypeModel> slist = new List<LeaveTypeModel>();

            SqlCommand cmd = new SqlCommand("LeaveTypeList",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr.IsNull("LastUpdatedDate"))
                    dt1 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(dr["LastUpdatedDate"].ToString(), out dt1) == false)
                        dt1 = DateTime.MinValue;
                }



                slist.Add(
                    new LeaveTypeModel
                    {
                        LeaveTypeId = Convert.ToInt32(dr["LeaveTypeId"]),
                        LeaveTypeName = Convert.ToString(dr["LeaveTypeName"]),
                        LeaveTypeShortName = Convert.ToString(dr["LeaveTypeShortName"]),
                        LastUpdatedBy = Convert.ToInt32(dr["LastUpdatedBy"]),
                        LastUpdatedByName = Convert.ToString(dr["LastUpdatedByName"]),
                        LastUpdatedDate = dt1

                    }) ; 
            }
            return slist;
        }
        // **************** ADD NEW USER *********************
        public bool Add(LeaveTypeModel lmodel)
        {

            connection();
            SqlCommand cmd = new SqlCommand("LeaveTypeAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LeaveTypeName", lmodel.LeaveTypeName);
            cmd.Parameters.AddWithValue("@LeaveTypeShortName", lmodel.LeaveTypeShortName);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 1);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);
      



            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        // ***************** UPDATE USER DETAILS *********************
        public bool Update(LeaveTypeModel lmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("LeaveTypeUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LeaveTypeId", lmodel.LeaveTypeId);
            cmd.Parameters.AddWithValue("@LeaveTypeName", lmodel.LeaveTypeName);
            cmd.Parameters.AddWithValue("@LeaveTypeShortName", lmodel.LeaveTypeShortName);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 1);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE LEAVETYPE DETAILS *******************
        public bool Delete(int LeaveId)
        {
            connection();
            SqlCommand cmd = new SqlCommand("LeaveTypeDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LeaveTypeId", LeaveId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

    }
}