using HrmsWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HrmsWeb.Models
{
    public class LeaveSetUpDBHandle : Controller
    {
        private SqlConnection con;
        private DateTime dt1;
        private DateTime dt2;
        private DateTime dt3;
        private DateTime dt4;
        private DateTime dt5;
        private DateTime dt6;

        private void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);
        }

        public List<LeaveSetUpModel> List()
        {
            Connection();
            List<LeaveSetUpModel> list = new List<LeaveSetUpModel>();
            SqlCommand cmd = new SqlCommand("Select * from Client", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow rdr in dt.Rows)
            {
                list.Add(
                    new LeaveSetUpModel
                    {
                        ClientId = (int)(rdr["ClientId"]),
                        ClientName =(string)(rdr["ClientName"]),

                    });
            }
            return list;
        }

        public List<LeaveSetUpModel> LeaveSetUpDetailList(int id)
        {
            Connection();
            List<LeaveSetUpModel> clist = new List<LeaveSetUpModel>();
            SqlCommand cmd = new SqlCommand("LeaveSetUpDetailList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientId", id); 
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {


                if (rdr.IsNull("StartDate"))
                    dt1 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["StartDate"].ToString(), out dt1) == false)
                        dt1 = DateTime.MinValue;
                }
                if (rdr.IsNull("EndDate"))
                    dt2 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["EndDate"].ToString(), out dt2) == false)
                        dt2 = DateTime.MinValue;
                }
                if (rdr.IsNull("LastUpdatedDate"))
                    dt3 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate"].ToString(), out dt3) == false)
                        dt3 = DateTime.MinValue;
                }
                clist.Add(
                    new LeaveSetUpModel
                    {
                        ClientId = (int)(rdr["ClientId"]),
                        LeaveTypeId = (int)(rdr["LeaveTypeId"]),
                        LeaveTypeDetailId = (int)(rdr["LeaveTypeDetailId"]),                       
                        LastupdatedBy = (int)(rdr["LastUpdatedBy"]),
                        LastUpdatedByName = rdr["LastUpdatedByName"].ToString(),
                        LeaveTypeName = rdr["LeaveTypeName"].ToString(),
                        StartDate = dt1,
                        EndDate = dt2,
                        LastUpdatedDate = dt3,


                    });
            }
            return clist;
        }
        

        public bool Add(LeaveSetUpModel cmodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("LeaveSetUpDetailAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientId", cmodel.ClientId);

            cmd.Parameters.AddWithValue("@LeaveTypeId", cmodel.LeaveTypeId);
            if (cmodel.StartDate == null)
            {
                cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@StartDate", cmodel.StartDate);
            }
            if (cmodel.EndDate == null)
            {
                cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EndDate", cmodel.EndDate);
            }
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
        public List<LeaveSetUpModel>getbyID(int ID)
        {
            Connection();
            List<LeaveSetUpModel> cclist = new List<LeaveSetUpModel>();

            SqlCommand cmd = new SqlCommand("select * from LeaveSetUpDetail where LeaveTypeDetailId=" + ID, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr.IsNull("StartDate"))
                    dt4 = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(dr["StartDate"].ToString(), out dt4) == false)
                        dt4 = DateTime.MinValue;
                }
                if (dr.IsNull("EndDate"))
                    dt5 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(dr["EndDate"].ToString(), out dt5) == false)
                        dt5 = DateTime.MinValue;
                }
                if (dr.IsNull("LastUpdatedDate"))
                    dt6 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(dr["LastUpdatedDate"].ToString(), out dt6) == false)
                        dt6 = DateTime.MinValue;
                }
               

                cclist.Add(
                    new LeaveSetUpModel
                    {
                        ClientId = (int)(dr["ClientId"]),
                        LeaveTypeDetailId = (int)(dr["LeaveTypeDetailId"]),
                        LeaveTypeId = (int)(dr["LeaveTypeId"]),
                        
                        LastupdatedBy = (int)(dr["LastUpdatedBy"]),
                        LastUpdatedDate = dt6,
                        StartDate = dt4,
                        EndDate = dt5,

                    });
            }
            return cclist;
        }

        public bool Update(LeaveSetUpModel cmodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("LeaveSetUpDetailUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;           
            cmd.Parameters.AddWithValue("@LeaveTypeDetailId", cmodel.LeaveTypeDetailId);
            cmd.Parameters.AddWithValue("@LeaveTypeId", cmodel.LeaveTypeId);
         
            if (cmodel.StartDate == null)
            {
                cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@StartDate", cmodel.StartDate);
            }
            if (cmodel.EndDate == null)
            {
                cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EndDate", cmodel.EndDate);
            }
           
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 3);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Delete(int LeaveTypeDetailId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("LeaveSetUpDetailDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LeaveTypeDetailId", LeaveTypeDetailId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }
        
        //dropdown
        public List<LeaveTypeModel> Leaves()
        {
            Connection();
            List<LeaveTypeModel> clist = new List<LeaveTypeModel>();

            SqlCommand cmd = new SqlCommand("LeaveSetUpDropdown", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow rdr in dt.Rows)
            { 
                clist.Add(
                    new LeaveTypeModel
                    {
                        LeaveTypeId = (int)(rdr["LeaveTypeId"]),
                        LeaveTypeName = (string)(rdr["LeaveTypeName"]),
                        

                    });
            }
            return clist;
        }


    }
}

