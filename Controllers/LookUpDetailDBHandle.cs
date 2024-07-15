using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace HrmsWeb.Models
{
    public class LookUpDetailDBHandle
    {
        private SqlConnection con;
        private void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);
        }
        public List<LookUpDetailModel> List()
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
        public List<LookUpDetailModel> ListForMasterId(int id)
        {
            Connection();
            List<LookUpDetailModel> lst = new List<LookUpDetailModel>();
            SqlCommand cmd = new SqlCommand("Select * from LookUpDetail where LookUpMasterId="+id, con);
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


        public List<LookUpDetailModel> Edit(int id)
        {
            Connection();
            List<LookUpDetailModel> lst = new List<LookUpDetailModel>();
            SqlCommand cmd = new SqlCommand("Select * from LookUpDetail where LookUpDetailId=" + id, con);
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


    }
}