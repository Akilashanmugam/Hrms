using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace HrmsWeb.Models
{
    public class LookUpMasterDBHandle
    {
        private SqlConnection con;
        private void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);
        }

        public List<LookUpMasterModel> List()
        {
            Connection();
            List<LookUpMasterModel> lst = new List<LookUpMasterModel>();
            SqlCommand cmd = new SqlCommand("Select * from LookUpMaster order by LookUpMasterId", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(
                    new LookUpMasterModel
                    {
                        LookUpMasterId = Convert.ToInt32(dr["LookUpMasterId"]),
                        LookUpMasterName = Convert.ToString(dr["LookUpMasterName"]),
                       

                    });
            }
            return lst;
        }

        public List<LookUpDetailModel> LookUpDetailListAll()
        {
            Connection();
            List<LookUpDetailModel> lst = new List<LookUpDetailModel>();
            SqlCommand cmd = new SqlCommand("Select * from LookUpDetail", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(
                    new LookUpDetailModel
                    {
                        LookUpMasterId = Convert.ToInt32(dr["LookUpMasterId"]),
                        LookUpDetailId = Convert.ToInt32(dr["LookUpDetailId"]),
                        LookUpDetailName = Convert.ToString(dr["LookUpDetailName"]),


                    });
            }
            return lst;
        }

        public List<LookUpDetailModel> LookUpDetailList(int ID)
        {
            Connection();
            List<LookUpDetailModel> lst = new List<LookUpDetailModel>();
            SqlCommand cmd = new SqlCommand("Select * from LookUpDetail where LookUpMasterId="+ID, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(
                    new LookUpDetailModel
                    {
                        LookUpMasterId = Convert.ToInt32(dr["LookUpMasterId"]),
                        LookUpDetailId = Convert.ToInt32(dr["LookUpDetailId"]),
                        LookUpDetailName = Convert.ToString(dr["LookUpDetailName"]),


                    });
            }
            return lst;
        }

        public bool Add(LookUpDetailModel ldmodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("LookUpDetailAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LookUpMasterId", ldmodel.LookUpMasterId);
            cmd.Parameters.AddWithValue("@LookUpDetailId", 0);
            cmd.Parameters.AddWithValue("@LookUpDetailName", ldmodel.LookUpDetailName);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 1);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today );
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public bool Update(LookUpDetailModel ldmodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("LookUpDetailEdit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LookUpDetailId", ldmodel.LookUpDetailId);
            cmd.Parameters.AddWithValue("@LookUpDetailName", ldmodel.LookUpDetailName);
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

      
        public bool Delete(int ID)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("LookUpDetailDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LookUpDetailId", ID);
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