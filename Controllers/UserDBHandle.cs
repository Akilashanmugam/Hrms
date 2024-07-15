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
    public class UserDBHandle
    {
        private SqlConnection con;
        private DateTime dt1;
        private DateTime dt2;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);
        }
        // ********** VIEW User DETAILS ********************
        public List<UserModel> List()
        {
            connection();
            List<UserModel> slist = new List<UserModel>();

            SqlCommand cmd = new SqlCommand("Select * from Users", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {

                if (dr.IsNull("StartDate"))
                    dt1 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(dr["StartDate"].ToString(), out dt1) == false)
                        dt1 = DateTime.MinValue;
                }
                if (dr.IsNull("EndDate"))
                    dt2 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(dr["EndDate"].ToString(), out dt2) == false)
                        dt2 = DateTime.MinValue;
                }

                slist.Add(
                    new UserModel
                    {
                        UserId = Convert.ToInt32(dr["UserId"]),
                        UserName = Convert.ToString(dr["UserName"]),
                        StartDate = dt1,
                        EndDate = dt2,
                        LastUpdatedBy = Convert.ToInt32(dr["LastUpdatedBy"]),
                        LastUpdatedDate = Convert.ToDateTime(dr["LastUpdatedDate"]),
                        LoginPassword = Convert.ToString(dr["LoginPassword"])

                    });
            }
            return slist;
        }

        //internal bool AddUser(UserModel umodel)
        //{
        //    throw new NotImplementedException();
        //}


        // **************** ADD NEW USER *********************
        public bool Add(UserModel umodel)
        {

            connection();
            SqlCommand cmd = new SqlCommand("UserAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", umodel.UserName);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 1);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);
            cmd.Parameters.AddWithValue("@LoginPassword", umodel.LoginPassword);
            if (umodel.StartDate == null)
            {
                cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@StartDate", umodel.StartDate);
            }
            if (umodel.EndDate == null)
            {
                cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EndDate", umodel.EndDate);
            }


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ***************** UPDATE USER DETAILS *********************
        public bool Update(UserModel umodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UserUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", umodel.UserId);
            cmd.Parameters.AddWithValue("@UserName", umodel.UserName);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 3);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);
            cmd.Parameters.AddWithValue("@LoginPassword", umodel.LoginPassword);

            if (umodel.StartDate == null)
            {
                cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@StartDate", umodel.StartDate);
            }
            if (umodel.EndDate == null)
            {
                cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EndDate", umodel.EndDate);
            }

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE USER DETAILS *******************
        public bool Delete(int UserId)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UserDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", UserId);
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