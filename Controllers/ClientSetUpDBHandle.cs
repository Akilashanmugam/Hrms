using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HrmsWeb.Models;
using Hrmsweb.Models;

namespace HrmsWeb.Controllers
{
    public class ClientSetUpDBHandle
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

        //--------------- Main Table ClientSetUp -----------------//
        public List<ClientBillingModel> MainTableList()
        {
            Connection();
            List<ClientBillingModel> cbdlist = new List<ClientBillingModel>();

            SqlCommand cmd = new SqlCommand("MainTableClientSetUpList", con);
            cmd.CommandType = CommandType.StoredProcedure;
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

                cbdlist.Add(
                    new ClientBillingModel
                    {
                        ClientSetUpId = (int)(rdr["ClientSetUpId"]),
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
                        LastUpdatedDate = ldate,
                    });
            }
            return cbdlist;
        }
       
        public bool MainTableAdd(ClientBillingModel CSUDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("MainTableClientSetUpAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProjectId", CSUDB.ProjectId);
            cmd.Parameters.AddWithValue("@LocationId", CSUDB.LocationId);
            cmd.Parameters.AddWithValue("@MaximumBillableDays", CSUDB.MaximumBillableDays);
            cmd.Parameters.AddWithValue("@BillingPeriodFrom", CSUDB.BillingPeriodFrom);
            cmd.Parameters.AddWithValue("@BillingPeriodTo", CSUDB.BillingPeriodTo);
            cmd.Parameters.AddWithValue("@LeavesAllowedPerMonth", CSUDB.LeavesAllowedPerMonth);
            cmd.Parameters.AddWithValue("@PanNo", CSUDB.PanNo);
            cmd.Parameters.AddWithValue("@GSTIN", CSUDB.GSTIN);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 1);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);

            if (CSUDB.ValidFrom == null)
            {
                cmd.Parameters.AddWithValue("@ValidFrom", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ValidFrom", CSUDB.ValidFrom);
            }
            if (CSUDB.ValidTo == null)
            {
                cmd.Parameters.AddWithValue("@ValidTo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ValidTo", CSUDB.ValidTo);
            }

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //---------------ClientSetUp -----------------//
        public List<ClientBillingModel> List(int id)
        {
            Connection();
            List<ClientBillingModel> cbdlist = new List<ClientBillingModel>();

            SqlCommand cmd = new SqlCommand("ClientSetUpList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientId", id);
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

                cbdlist.Add(
                    new ClientBillingModel
                    {
                        ClientSetUpId = (int)(rdr["ClientSetUpId"]),
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
                        LastUpdatedDate = ldate,
                    });
            }
            return cbdlist;
        }
        public bool Add(ClientBillingModel CSUDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("ClientSetUpAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientId", CSUDB.ClientId);
            cmd.Parameters.AddWithValue("@ProjectId", CSUDB.ProjectId);
            cmd.Parameters.AddWithValue("@LocationId", CSUDB.LocationId);
            cmd.Parameters.AddWithValue("@MaximumBillableDays", CSUDB.MaximumBillableDays);
            cmd.Parameters.AddWithValue("@BillingPeriodFrom", CSUDB.BillingPeriodFrom);
            cmd.Parameters.AddWithValue("@BillingPeriodTo", CSUDB.BillingPeriodTo);
            cmd.Parameters.AddWithValue("@LeavesAllowedPerMonth", CSUDB.LeavesAllowedPerMonth);
            cmd.Parameters.AddWithValue("@PanNo", CSUDB.PanNo);
            cmd.Parameters.AddWithValue("@GSTIN", CSUDB.GSTIN);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 1);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);

            if (CSUDB.ValidFrom == null)
            {
                cmd.Parameters.AddWithValue("@ValidFrom", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ValidFrom", CSUDB.ValidFrom);
            }
            if (CSUDB.ValidTo == null)
            {
                cmd.Parameters.AddWithValue("@ValidTo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ValidTo", CSUDB.ValidTo);
            }

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public List<ClientBillingModel> ClientSetUpGetById(int id)
        {
            Connection();
            List<ClientBillingModel> cbdlist = new List<ClientBillingModel>();

            SqlCommand cmd = new SqlCommand("select * from ClientSetUp where ClientSetUpId=" + id, con);
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

                cbdlist.Add(
                    new ClientBillingModel
                    {
                        ClientSetUpId = (int)(rdr["ClientSetUpId"]),
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
                    });
            }
            return cbdlist;
        }
        public bool Update(ClientBillingModel CSUDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("ClientSetUpUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientSetUpId", CSUDB.ClientSetUpId);
            cmd.Parameters.AddWithValue("@ProjectId", CSUDB.ProjectId);
            cmd.Parameters.AddWithValue("@LocationId", CSUDB.LocationId);
            cmd.Parameters.AddWithValue("@MaximumBillableDays", CSUDB.MaximumBillableDays);
            cmd.Parameters.AddWithValue("@BillingPeriodFrom", CSUDB.BillingPeriodFrom);
            cmd.Parameters.AddWithValue("@BillingPeriodTo", CSUDB.BillingPeriodTo);
            cmd.Parameters.AddWithValue("@LeavesAllowedPerMonth", CSUDB.LeavesAllowedPerMonth);
            cmd.Parameters.AddWithValue("@PanNo", CSUDB.PanNo);
            cmd.Parameters.AddWithValue("@GSTIN", CSUDB.GSTIN);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 4);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);

            if (CSUDB.ValidFrom == null)
            {
                cmd.Parameters.AddWithValue("@ValidFrom", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ValidFrom", CSUDB.ValidFrom);
            }
            if (CSUDB.ValidTo == null)
            {
                cmd.Parameters.AddWithValue("@ValidTo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ValidTo", CSUDB.ValidTo);
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
            SqlCommand cmd = new SqlCommand("ClientSetUpDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientSetUpId", Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
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