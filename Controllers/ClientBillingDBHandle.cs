using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HrmsWeb.Models;
using Hrmsweb.Models;

namespace HrmsWeb.Controllers
{
    public class ClientBillingDBHandle
    {
        private SqlConnection con;
        private DateTime stdt;
        private DateTime endt;

        private DateTime ldate;
        private void Connection()

        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);

        }
        public List<ClientBillingModel> List(ClientBillingModel CBDB)
        {
            Connection();
            List<ClientBillingModel> CBlist = new List<ClientBillingModel>();

            SqlCommand cmd = new SqlCommand("ClientBillingList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientId", CBDB.srClientId);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {

                if (rdr.IsNull("ValidFrom"))
                    stdt = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["ValidFrom"].ToString(), out stdt) == false)
                        stdt = DateTime.MinValue;
                }

                if (rdr.IsNull("ValidTo"))
                    endt = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["ValidTo"].ToString(), out endt) == false)
                        endt = DateTime.MinValue;
                }

                if (rdr.IsNull("LastUpdatedDate"))
                    ldate = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate"].ToString(), out ldate) == false)
                        ldate = DateTime.MinValue;
                }

                CBlist.Add(
                    new ClientBillingModel
                    {
                        CBId = (int)(rdr["CBId"]),
                        ClientId = (int)(rdr["ClientId"]),
                        ProjectId = (int)(rdr["ProjectId"]),
                        LocationId = (int)(rdr["LocationId"]),
                        MaximumBillableDays = (int)(rdr["MaximumBillableDays"]),
                        BillingPeriodFrom = (int)(rdr["BillingPeriodFrom"]),
                        BillingPeriodTo = (int)(rdr["BillingPeriodTo"]),
                        LeavesAllowedPerMonth = (int)(rdr["LeavesAllowedPerMonth"]),
                        PanNo = (string)(rdr["PanNo"]),
                        GSTIN = (string)(rdr["GSTIN"]),
                        ValidFrom = stdt,
                        ValidTo = endt,
                        LastUpdatedBy = (int)(rdr["LastUpdatedBy"]),
                        UserName = rdr["UserName"].ToString(),
                        ProjectName = rdr["ProjectName"].ToString(),
                        LocationName = rdr["LocationName"].ToString(),
                        ClientName = rdr["ClientName"].ToString(),
                        LastUpdatedDate = ldate,
                    });
            }
            return CBlist;
        }
        public List<ClientBillingModel> ListGetById(int id)
        {
            Connection();
            List<ClientBillingModel> CBlist = new List<ClientBillingModel>();

            SqlCommand cmd = new SqlCommand("select * from QryClientBilling where CBId=" + id, con);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {

                if (rdr.IsNull("ValidFrom"))
                    stdt = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["ValidFrom"].ToString(), out stdt) == false)
                        stdt = DateTime.MinValue;
                }

                if (rdr.IsNull("ValidTo"))
                    endt = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["ValidTo"].ToString(), out endt) == false)
                        endt = DateTime.MinValue;
                }

                if (rdr.IsNull("LastUpdatedDate"))
                    ldate = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate"].ToString(), out ldate) == false)
                        ldate = DateTime.MinValue;
                }

                CBlist.Add(
                    new ClientBillingModel
                    {
                        CBId = (int)(rdr["CBId"]),
                        ClientId = (int)(rdr["ClientId"]),
                        ProjectId = (int)(rdr["ProjectId"]),
                        LocationId = (int)(rdr["LocationId"]),
                        MaximumBillableDays = (int)(rdr["MaximumBillableDays"]),
                        BillingPeriodFrom = (int)(rdr["BillingPeriodFrom"]),
                        BillingPeriodTo = (int)(rdr["BillingPeriodTo"]),
                        LeavesAllowedPerMonth = (int)(rdr["LeavesAllowedPerMonth"]),
                        PanNo = (string)(rdr["PanNo"]),
                        GSTIN = (string)(rdr["GSTIN"]),
                        ValidFrom = stdt,
                        ValidTo = endt,
                        LastUpdatedBy = (int)(rdr["LastUpdatedBy"]),
                        UserName = rdr["UserName"].ToString(),
                        ProjectName = rdr["ProjectName"].ToString(),
                        LocationName = rdr["LocationName"].ToString(),
                        ClientName = rdr["ClientName"].ToString(),
                        LastUpdatedDate = ldate,
                    });
            }
            return CBlist;

        }
        public bool Add(ClientBillingModel CBDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("ClientBillingAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientId", CBDB.ClientId);
            cmd.Parameters.AddWithValue("@ProjectId", CBDB.ProjectId);
            cmd.Parameters.AddWithValue("@LocationId", CBDB.LocationId);
            cmd.Parameters.AddWithValue("@MaximumBillableDays", CBDB.MaximumBillableDays);
            cmd.Parameters.AddWithValue("@BillingPeriodFrom", CBDB.BillingPeriodFrom);
            cmd.Parameters.AddWithValue("@BillingPeriodTo", CBDB.BillingPeriodTo);
            cmd.Parameters.AddWithValue("@LeavesAllowedPerMonth", CBDB.LeavesAllowedPerMonth);
            cmd.Parameters.AddWithValue("@PanNo", CBDB.PanNo);
            cmd.Parameters.AddWithValue("@GSTIN", CBDB.GSTIN);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 1);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);

            if (CBDB.ValidFrom == null)
            {
                cmd.Parameters.AddWithValue("@ValidFrom", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ValidFrom", CBDB.ValidFrom);
            }
            if (CBDB.ValidTo == null)
            {
                cmd.Parameters.AddWithValue("@ValidTo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ValidTo", CBDB.ValidTo);
            }

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update(ClientBillingModel CBDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("ClientBillingUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CBId", CBDB.CBId);
            cmd.Parameters.AddWithValue("@ClientId", CBDB.ClientId);
            cmd.Parameters.AddWithValue("@ProjectId", CBDB.ProjectId);
            cmd.Parameters.AddWithValue("@LocationId", CBDB.LocationId);
            cmd.Parameters.AddWithValue("@MaximumBillableDays", CBDB.MaximumBillableDays);
            cmd.Parameters.AddWithValue("@BillingPeriodFrom", CBDB.BillingPeriodFrom);
            cmd.Parameters.AddWithValue("@BillingPeriodTo", CBDB.BillingPeriodTo);
            cmd.Parameters.AddWithValue("@LeavesAllowedPerMonth", CBDB.LeavesAllowedPerMonth);
            cmd.Parameters.AddWithValue("@PanNo", CBDB.PanNo);
            cmd.Parameters.AddWithValue("@GSTIN", CBDB.GSTIN);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 4);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);

            if (CBDB.ValidFrom == null)
            {
                cmd.Parameters.AddWithValue("@ValidFrom", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ValidFrom", CBDB.ValidFrom);
            }
            if (CBDB.ValidTo == null)
            {
                cmd.Parameters.AddWithValue("@ValidTo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ValidTo", CBDB.ValidTo);
            }

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
            Connection();
            SqlCommand cmd = new SqlCommand("ClientBillingDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CBId", Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        //------Automatic selection project dropdown--------//
        public List<ProjectModel> GetProjectsByClientId(int clientId)
        {
            Connection();
            List<ProjectModel> projectList = new List<ProjectModel>();

            SqlCommand cmd = new SqlCommand("GetProjectsByClientId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientId", clientId);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
                projectList.Add(new ProjectModel
                {
                    ProjectId = Convert.ToInt32(rdr["ProjectId"]),
                    ProjectName = rdr["ProjectName"].ToString()
                });
            }
            return projectList;
        }

        //-----------------dropdowns--------------------//
        public List<ClientModel> Client()
        {
            Connection();
            List<ClientModel> elist = new List<ClientModel>();

            SqlCommand cmd = new SqlCommand("Select * from QryClient", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            elist.Add(
                  new ClientModel
                  {
                      ClientId = 0,
                      ClientName = "-----Select-----",
                  });

            foreach (DataRow rdr in dt.Rows)
            {
                elist.Add(
                    new ClientModel
                    {
                        ClientId = (int)(rdr["ClientId"]),
                        ClientName = (string)(rdr["ClientName"]),

                    });
            }
            return elist;
        }
        public List<ProjectModel> Project()
        {
            Connection();
            List<ProjectModel> elist = new List<ProjectModel>();

            SqlCommand cmd = new SqlCommand("Select * from QryProject", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            elist.Add(
                  new ProjectModel
                  {
                      ProjectId = 0,
                      ProjectName = "-----Select-----",
                  });

            foreach (DataRow rdr in dt.Rows)
            {
                elist.Add(
                    new ProjectModel
                    {
                        ProjectId = (int)(rdr["ProjectId"]),
                        ProjectName = (string)(rdr["ProjectName"]),

                    });
            }
            return elist;
        }

        public List<LookUpDetailModel> LookUpDetailList(string sql1)
        {
            Connection();
            List<LookUpDetailModel> ddlist = new List<LookUpDetailModel>();
            SqlCommand cmd = new SqlCommand(sql1, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            ddlist.Add(
                   new LookUpDetailModel
                   {
                       LookUpDetailId = 0,
                       LookUpDetailName = "-----Select-----",
                   });

            foreach (DataRow dr in dt.Rows)
            {
                ddlist.Add(
                    new LookUpDetailModel
                    {
                        LookUpDetailId = Convert.ToInt32(dr["LookUpDetailId"]),
                        LookUpDetailName = Convert.ToString(dr["LookUpDetailName"]),
                    });
            }
            return ddlist;
        }


      
    }
}
