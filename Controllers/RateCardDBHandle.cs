using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HrmsWeb.Models;
using Hrmsweb.Models;

namespace HrmsWeb.Controllers
{
    public class RateCardDBHandle
    {
        private SqlConnection con;
        private DateTime stdt;
        private DateTime endt; 
        private DateTime RCDate; 
        private DateTime RCLDate;
        private DateTime dt3;
        private DateTime dt6;
        private void Connection()

        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);

        }

        public List<RateCardModel> List()
        {
            Connection();
            List<RateCardModel> Rclist = new List<RateCardModel>();

            SqlCommand cmd = new SqlCommand("RateCardList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {

                if (rdr.IsNull("EffectiveStartDate"))
                    stdt = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["EffectiveStartDate"].ToString(), out stdt) == false)
                        stdt = DateTime.MinValue;
                }

                if (rdr.IsNull("EffectiveEndDate"))
                    endt = DateTime.MinValue;


                else
                {
                    if (DateTime.TryParse(rdr["EffectiveEndDate"].ToString(), out endt) == false)
                        endt = DateTime.MinValue;
                }
                if (rdr.IsNull("RateCardDate"))
                    RCDate = DateTime.MinValue;


                else
                {
                    if (DateTime.TryParse(rdr["RateCardDate"].ToString(), out RCDate) == false)
                        RCDate = DateTime.MinValue;
                }
                if (rdr.IsNull("LastUpdatedDate"))
                    RCLDate = DateTime.MinValue;


                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate"].ToString(), out RCLDate) == false)
                        RCLDate = DateTime.MinValue;
                }

                Rclist.Add(
                    new RateCardModel
                    {
                        RateCardId = (int)(rdr["RateCardId"]),
                        ClientId = (int)(rdr["ClientId"]),
                        ProjectId = (int)(rdr["ProjectId"]),
                        RateCardCode = (string)(rdr["RateCardCode"]),
                        EffectiveStartDate = stdt,
                        EffectiveEndDate = endt,
                        RateCardDate=RCDate,
                        RateCardName = (string)(rdr["RateCardName"]),
                        RateCardTypeId = (int)(rdr["RateCardTypeId"]),
                        BilableRate = (decimal)(rdr["BilableRate"]),
                        CurrencyId = (int)(rdr["CurrencyId"]),
                        LocationId = (int)(rdr["LocationId"]),
                        StatusId = (int)(rdr["StatusId"]),
                        LastUpdatedBy = (int)(rdr["LastUpdatedBy"]),
                        LastUpdatedDate = RCLDate,
                        UserName = rdr["UserName"].ToString(),
                        ClientName = rdr["ClientName"].ToString(),
                        ProjectName = rdr["ProjectName"].ToString(),
                        LocationName = rdr["LocationName"].ToString(),
                        CurrencyName = rdr["CurrencyName"].ToString(),
                        RateCardType = rdr["RateCardType"].ToString(),
                        StatusName = rdr["StatusName"].ToString(),
                    });
            }
            return Rclist;
        }
        public bool Add(RateCardModel RCDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("RateCardAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientId", RCDB.ClientId);
            cmd.Parameters.AddWithValue("@ProjectId", RCDB.ProjectId);
            cmd.Parameters.AddWithValue("@RateCardCode", RCDB.RateCardCode);
            cmd.Parameters.AddWithValue("@RateCardName", RCDB.RateCardName);
            cmd.Parameters.AddWithValue("@RateCardTypeId", RCDB.RateCardTypeId);
            cmd.Parameters.AddWithValue("@BilableRate", RCDB.BilableRate);
            cmd.Parameters.AddWithValue("@CurrencyId", RCDB.CurrencyId);
            cmd.Parameters.AddWithValue("@LocationId", RCDB.LocationId);
            cmd.Parameters.AddWithValue("@StatusId", RCDB.StatusId);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 3);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);

            if (RCDB.EffectiveStartDate == null)
            {
                cmd.Parameters.AddWithValue("@EffectiveStartDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EffectiveStartDate", RCDB.EffectiveStartDate);
            }
            if (RCDB.EffectiveEndDate == null)
            {
                cmd.Parameters.AddWithValue("@EffectiveEndDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EffectiveEndDate", RCDB.EffectiveEndDate);
            }
            if (RCDB.RateCardDate == null)
            {
                cmd.Parameters.AddWithValue("@RateCardDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@RateCardDate", RCDB.RateCardDate);
            }

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Update(RateCardModel RCDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("RateCardUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RateCardId", RCDB.RateCardId);
            cmd.Parameters.AddWithValue("@ClientId", RCDB.ClientId);
            cmd.Parameters.AddWithValue("@ProjectId", RCDB.ProjectId);
            cmd.Parameters.AddWithValue("@RateCardCode", RCDB.RateCardCode);
            cmd.Parameters.AddWithValue("@RateCardName", RCDB.RateCardName);
            cmd.Parameters.AddWithValue("@RateCardTypeId", RCDB.RateCardTypeId);
            cmd.Parameters.AddWithValue("@BilableRate", RCDB.BilableRate);
            cmd.Parameters.AddWithValue("@CurrencyId", RCDB.CurrencyId);
            cmd.Parameters.AddWithValue("@LocationId", RCDB.LocationId);
            cmd.Parameters.AddWithValue("@StatusId", RCDB.StatusId);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 4);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);

            if (RCDB.EffectiveStartDate == null)
            {
                cmd.Parameters.AddWithValue("@EffectiveStartDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EffectiveStartDate", RCDB.EffectiveStartDate);
            }
            if (RCDB.EffectiveEndDate == null)
            {
                cmd.Parameters.AddWithValue("@EffectiveEndDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EffectiveEndDate", RCDB.EffectiveEndDate);
            }
            if (RCDB.RateCardDate == null)
            {
                cmd.Parameters.AddWithValue("@RateCardDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@RateCardDate", RCDB.RateCardDate);
            }

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //-------------Deleted VAlidation---------------//
        public bool Delete(int RateCardId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("RateCardDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RateCardId", RateCardId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        public int CheckChildTableCount(int rateCardId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM RateCardDetail WHERE RateCardId = @RateCardId", con);
            cmd.Parameters.AddWithValue("@RateCardId", rateCardId);
            con.Open();
            int childCount = (int)cmd.ExecuteScalar();
            con.Close();
            return childCount;
        }

        //----------------------------DropDowns------------------//
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
        public List<VendorModel> Status()
        {
            Connection();
            List<VendorModel> elist = new List<VendorModel>();

            SqlCommand cmd = new SqlCommand("Select * from QryStatus", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            elist.Add(
                  new VendorModel
                  {
                      StatusId = 0,
                      StatusName = "-----Select-----",
                  });

            foreach (DataRow rdr in dt.Rows)
            {
                elist.Add(
                    new VendorModel
                    {
                        StatusId = (int)(rdr["StatusId"]),
                        StatusName = (string)(rdr["StatusName"]),

                    });
            }
            return elist;
        }
        public List<RateCardModel> RateCardType()
        {
            Connection();
            List<RateCardModel> elist = new List<RateCardModel>();

            SqlCommand cmd = new SqlCommand("Select * from RateCardType", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            elist.Add(
                  new RateCardModel
                  {
                      RateCardTypeId = 0,
                      RateCardType = "-----Select-----",
                  });

            foreach (DataRow rdr in dt.Rows)
            {
                elist.Add(
                    new RateCardModel
                    {
                        RateCardTypeId = (int)(rdr["RateCardTypeId"]),
                        RateCardType = (string)(rdr["RateCardType"]),

                    });
            }
            return elist;
        }

        //-----------------RateCard Detail---------------------//
        public List<RateCardModel> RCDList(int id)
        {
            Connection();
            List<RateCardModel> RCDlist = new List<RateCardModel>();

            SqlCommand cmd = new SqlCommand("RateCardDetailList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RateCardId", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
                
                if (rdr.IsNull("LastUpdatedDate1"))
                    dt3 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate1"].ToString(), out dt3) == false)
                        dt3 = DateTime.MinValue;
                }
                RCDlist.Add(
                    new RateCardModel
                    {
                        RateCardId = (int)(rdr["RateCardId"]),
                        RateCardDetailId = (int)(rdr["RateCardDetailId"]),
                        RateCardDescription = (string)(rdr["RateCardDescription"]),
                        BilableRate1 = (decimal)(rdr["BilableRate1"]),
                        CurrencyId1 = (int)(rdr["CurrencyId1"]),
                        LastUpdatedBy1 = (int)(rdr["LastUpdatedBy1"]),
                        UserName = rdr["UserName"].ToString(),
                        CurrencyName = rdr["CurrencyName"].ToString(),
                        LastUpdatedDate1 = dt3,


                    });
            }
            return RCDlist;
        }
        public bool AddRCD(RateCardModel RCDDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("RateCardDetailAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RateCardId", RCDDB.RateCardId);
            cmd.Parameters.AddWithValue("@RateCardDescription", RCDDB.RateCardDescription);
            cmd.Parameters.AddWithValue("@BilableRate1", RCDDB.BilableRate1);
            cmd.Parameters.AddWithValue("@CurrencyId1", RCDDB.CurrencyId1);
            cmd.Parameters.AddWithValue("@LastUpdatedBy1", 1);
            cmd.Parameters.AddWithValue("@LastUpdatedDate1", DateTime.Today);
           
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;


        }
        public List<RateCardModel> getbyIDRCD(int id)
        {
            Connection();
            List<RateCardModel> RCDlist = new List<RateCardModel>();

            SqlCommand cmd = new SqlCommand("select * from RateCardDetail where RateCardDetailId=" + id, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr.IsNull("LastUpdatedDate1"))
                    dt6 = DateTime.MinValue;


                else
                {
                    if (DateTime.TryParse(dr["LastUpdatedDate1"].ToString(), out dt6) == false)
                        dt6 = DateTime.MinValue;
                }

                RCDlist.Add(
                    new RateCardModel
                    {
                        RateCardId = (int)(dr["RateCardId"]),
                        RateCardDetailId = (int)(dr["RateCardDetailId"]),
                        RateCardDescription = (string)(dr["RateCardDescription"]),
                        BilableRate1 = (decimal)(dr["BilableRate1"]),
                        CurrencyId1 = (int)(dr["CurrencyId1"]),
                        LastUpdatedBy1 = (int)(dr["LastUpdatedBy1"]),
                        LastUpdatedDate1 = dt6,
                  

                    });
            }
            return RCDlist;
        }

        public bool UpdateRCD(RateCardModel RCDDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("RateCardDetailUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RateCardDetailId", RCDDB.RateCardDetailId);
            cmd.Parameters.AddWithValue("@RateCardDescription", RCDDB.RateCardDescription);
            cmd.Parameters.AddWithValue("@BilableRate1", RCDDB.BilableRate1);
            cmd.Parameters.AddWithValue("@CurrencyId1", RCDDB.CurrencyId1);
            cmd.Parameters.AddWithValue("@LastUpdatedBy1", 3);
            cmd.Parameters.AddWithValue("@LastUpdatedDate1", DateTime.Today);
           
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool DeleteRCD(int RateCardDetailId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("RateCardDetailDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RateCardDetailId", RateCardDetailId);
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