using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HrmsWeb.Models;
using Hrmsweb.Models;

namespace HrmsWeb.Controllers
{
    public class ProjectDBHandle
    {
        private SqlConnection con;
        private DateTime stdt;
        private DateTime endt;
        

        private void Connection()

        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);

        }

        public List<ProjectModel> List()
        {
            Connection();
            List<ProjectModel> clist = new List<ProjectModel>();

            SqlCommand cmd = new SqlCommand("ProjectList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {

                if (rdr.IsNull("ProjectStartDate"))
                    stdt = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["ProjectStartDate"].ToString(), out stdt) == false)
                        stdt = DateTime.MinValue;
                }

                if (rdr.IsNull("ProjectEndDate"))
                    endt = DateTime.MinValue;


                else
                {
                    if (DateTime.TryParse(rdr["ProjectEndDate"].ToString(), out endt) == false)
                        endt = DateTime.MinValue;
                }
                

                clist.Add(
                    new ProjectModel
                    {
                        ProjectId = (int)(rdr["ProjectId"]),
                        ProjectCode = (string)(rdr["ProjectCode"]),
                        Description = (string)(rdr["Description"]),
                        ProjectName = (string)(rdr["ProjectName"]),
                        ProjectStartDate = stdt,
                        ProjectEndDate = endt,
                        CompanyId = (int)(rdr["CompanyId"]),
                        ClientId = (int)(rdr["ClientId"]),
                        ProjectTypeId = (int)(rdr["ProjectTypeId"]),
                        ProjectManagerId = (int)(rdr["ProjectManagerId"]),
                        BillingCurrencyId = (int)(rdr["BillingCurrencyId"]),
                        MasterStatusId = (int)(rdr["MasterStatusId"]),
                        Comments = (string)(rdr["Comments"]),
                        CompanyName = rdr["CompanyName"].ToString(),
                        ClientName = rdr["ClientName"].ToString(),
                        EmployeeName = rdr["EmployeeName"].ToString(),
                        CurrencyName = rdr["CurrencyName"].ToString(),
                        StatusName = rdr["StatusName"].ToString(),
                        ProjectTypeName = rdr["ProjectTypeName"].ToString(),

                    });
            }
            return clist;
        }
        public bool Add(ProjectModel cmodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("ProjectAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProjectCode", cmodel.ProjectCode);
            cmd.Parameters.AddWithValue("@Description", cmodel.Description);
            cmd.Parameters.AddWithValue("@ProjectName", cmodel.ProjectName);
            cmd.Parameters.AddWithValue("@CompanyId", cmodel.CompanyId);
            cmd.Parameters.AddWithValue("@ClientId", cmodel.ClientId);
            cmd.Parameters.AddWithValue("@ProjectTypeId", cmodel.ProjectTypeId);
            cmd.Parameters.AddWithValue("@ProjectManagerId", cmodel.ProjectManagerId);
            cmd.Parameters.AddWithValue("@BillingCurrencyId", cmodel.BillingCurrencyId);
            cmd.Parameters.AddWithValue("@MasterStatusId", cmodel.MasterStatusId);
            cmd.Parameters.AddWithValue("@Comments", cmodel.Comments);
            if (cmodel.ProjectStartDate == null)
            {
                cmd.Parameters.AddWithValue("@ProjectStartDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ProjectStartDate", cmodel.ProjectStartDate);
            }
            if (cmodel.ProjectEndDate == null)
            {
                cmd.Parameters.AddWithValue("@ProjectEndDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ProjectEndDate", cmodel.ProjectEndDate);
            }
            
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Update(ProjectModel cmodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("ProjectUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProjectId", cmodel.ProjectId);
            cmd.Parameters.AddWithValue("@ProjectCode", cmodel.ProjectCode);
            cmd.Parameters.AddWithValue("@Description", cmodel.Description);
            cmd.Parameters.AddWithValue("@ProjectName", cmodel.ProjectName);
            cmd.Parameters.AddWithValue("@CompanyId", cmodel.CompanyId);
            cmd.Parameters.AddWithValue("@ClientId", cmodel.ClientId);
            cmd.Parameters.AddWithValue("@ProjectTypeId", cmodel.ProjectTypeId);
            cmd.Parameters.AddWithValue("@ProjectManagerId", cmodel.ProjectManagerId);
            cmd.Parameters.AddWithValue("@BillingCurrencyId", cmodel.BillingCurrencyId);
            cmd.Parameters.AddWithValue("@MasterStatusId", cmodel.MasterStatusId);
            cmd.Parameters.AddWithValue("@Comments", cmodel.Comments);
            if (cmodel.ProjectStartDate == null)
            {
                cmd.Parameters.AddWithValue("@ProjectStartDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ProjectStartDate", cmodel.ProjectStartDate);
            }
            if (cmodel.ProjectEndDate == null)
            {
                cmd.Parameters.AddWithValue("@ProjectEndDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ProjectEndDate", cmodel.ProjectEndDate);
            }
           
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Delete(int ProjectId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("ProjectDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }
      
        //dropdown
        public List<CompanyModel> Leaves()
        {
            Connection();
            List<CompanyModel> clist = new List<CompanyModel>();

            SqlCommand cmd = new SqlCommand("CompanyProjectDropdown", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
          
            clist.Add(
            new CompanyModel
            {
                CompanyName = "~~~~~Select~~~~~~",
                CompanyId = 0

            });
            foreach (DataRow rdr in dt.Rows)
            {
                clist.Add(
                    new CompanyModel
                    {
                        CompanyName = (string)(rdr["CompanyName"]),
                        CompanyId = (int)(rdr["CompanyId"]),


                    });
            }
            return clist;
        }
        public List<ClientModel> client()
        {
            Connection();
            List<ClientModel> clist = new List<ClientModel>();

            SqlCommand cmd = new SqlCommand("ClientProjectDropdown", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow rdr in dt.Rows)
            {
                clist.Add(
                    new ClientModel
                    {
                        ClientName = (string)(rdr["ClientName"]),
                        ClientId = (int)(rdr["ClientId"]),

                    });
            }
            return clist;
        }
        public List<ProjectModel> Project()
        {
            Connection();
            List<ProjectModel> clist = new List<ProjectModel>();

            SqlCommand cmd = new SqlCommand("ProjectTypeDropdown", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow rdr in dt.Rows)
            {
                clist.Add(
                    new ProjectModel
                    {
                        ProjectTypeId = (int)(rdr["ProjectTypeId"]),
                        ProjectTypeName = (string)(rdr["ProjectTypeName"]),

                    });
            }
            return clist;
        }
        public List<EmployeeModel> Employee()
        {
            Connection();
            List<EmployeeModel> elist = new List<EmployeeModel>();

            SqlCommand cmd = new SqlCommand("EmployeeProjectDropdown", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow rdr in dt.Rows)
            {
                elist.Add(
                    new EmployeeModel
                    {
                        EmployeeId = (int)(rdr["EmployeeId"]),
                        EmployeeName = (string)(rdr["EmployeeName"]),

                    });
            }
            return elist;
        }
        public List<LookUpDetailModel> Lookupdetail()
        {
            Connection();
            List<LookUpDetailModel> clist = new List<LookUpDetailModel>();

            SqlCommand cmd = new SqlCommand("lookUpProjectDropdown", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow rdr in dt.Rows)
            {
                clist.Add(
                    new LookUpDetailModel
                    {
                        LookUpDetailId = (int)(rdr["LookUpDetailId"]),
                        LookUpDetailName = (string)(rdr["LookUpDetailName"]),

                    });
            }
            return clist;
        }
        public List<LookUpDetailModel> MasterLook()
        {
            Connection();
            List<LookUpDetailModel> clist = new List<LookUpDetailModel>();

            SqlCommand cmd = new SqlCommand("MasterLookProjectDropdown", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow rdr in dt.Rows)
            {
                clist.Add(
                    new LookUpDetailModel
                    {
                        LookUpDetailId = (int)(rdr["LookUpDetailId"]),
                        LookUpDetailName = (string)(rdr["LookUpDetailName"]),

                    });
            }
            return clist;
        }
    }
}
