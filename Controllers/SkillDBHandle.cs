using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HrmsWeb.Models;

namespace HrmsWeb.Controllers
{
    public class SkillDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);
        }

        // ********** VIEW SKILL DETAILS ********************
        public List<SkillModel> List()
        {
            connection();
            List<SkillModel> slist = new List<SkillModel>();

            SqlCommand cmd = new SqlCommand("SkillList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                slist.Add(
                    new SkillModel
                    {
                        SkillId = Convert.ToInt32(dr["SkillId"]),
                        SkillName = Convert.ToString(dr["SkillName"]),
                        LastUpdatedBy = Convert.ToInt32(dr["LastUpdatedBy"]),
                        LastUpdatedDate = Convert.ToDateTime(dr["LastUpdatedDate"]),
                        LastUpdatedByName = Convert.ToString(dr["LastUpdatedByName"])
                    });
            }
            return slist;
        }

        // **************** ADD NEW Skill *********************
        public bool Add(SkillModel smodel)
        {

            connection();
            SqlCommand cmd = new SqlCommand("SkillAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SkillName", smodel.SkillName);
            cmd.Parameters.AddWithValue("@LastUpdatedBy",1 );
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);
         
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Delete(int Id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("SkillDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SkillId", Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }


        public bool Update(SkillModel smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("SkillUpdate",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SkillId",smodel.SkillId);
            cmd.Parameters.AddWithValue("@SkillName",smodel.SkillName);
            cmd.Parameters.AddWithValue("@LastUpdatedBy",3);
            cmd.Parameters.AddWithValue("@LastUpdatedDate",DateTime.Today);
            


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