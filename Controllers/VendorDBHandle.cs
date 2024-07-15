using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HrmsWeb.Models;
using Hrmsweb.Models;

namespace HrmsWeb.Controllers
{
    public class VendorDBHandle
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
        public List<VendorModel> List()
        {
            Connection();
            List<VendorModel> vlist = new List<VendorModel>();

            SqlCommand cmd = new SqlCommand("VendorList", con);
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

                if (rdr.IsNull("LastUpdatedDate"))
                    ldate = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate"].ToString(), out ldate) == false)
                        ldate = DateTime.MinValue;
                }

                vlist.Add(
                    new VendorModel
                    {
                        VendorId = (int)(rdr["VendorId"]),
                        ClientId = (int)(rdr["ClientId"]),
                        Code = (string)(rdr["Code"]),
                        VendorShortName = (string)(rdr["VendorShortName"]),
                        VendorName = (string)(rdr["VendorName"]),
                        VendorAddress = (string)(rdr["VendorAddress"]),
                        SpecialInstructions = (string)(rdr["SpecialInstructions"]),
                        ContactName = (string)(rdr["ContactName"]),
                        EmailId = (string)(rdr["EmailId"]),
                        ContactNo = (string)(rdr["ContactNo"]),
                        VendorGST = (string)(rdr["VendorGST"]),
                        EffectiveStartDate = stdt,
                        EffectiveEndDate = endt,
                        MasterStatusId = (int)(rdr["MasterStatusId"]),
                        LastUpdatedBy = (int)(rdr["LastUpdatedBy"]),
                        UserName = rdr["UserName"].ToString(),
                        StatusName = rdr["StatusName"].ToString(),
                        ClientName = rdr["ClientName"].ToString(),
                        LastUpdatedDate = ldate,
                    });
            }
            return vlist;
        }

        public bool Add(VendorModel vmodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("VendorAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VendorId", vmodel.VendorId);
            cmd.Parameters.AddWithValue("@ClientId", vmodel.ClientId);
            cmd.Parameters.AddWithValue("@Code", vmodel.Code);
            cmd.Parameters.AddWithValue("@VendorName", vmodel.VendorName);
            cmd.Parameters.AddWithValue("@VendorShortName", vmodel.VendorShortName);
            cmd.Parameters.AddWithValue("@VendorAddress", vmodel.VendorAddress);
            cmd.Parameters.AddWithValue("@SpecialInstructions", vmodel.SpecialInstructions);
            cmd.Parameters.AddWithValue("@ContactName", vmodel.ContactName);
            cmd.Parameters.AddWithValue("@EmailId", vmodel.EmailId);
            cmd.Parameters.AddWithValue("@ContactNo", vmodel.ContactNo);
            cmd.Parameters.AddWithValue("@VendorGST", vmodel.VendorGST);
            cmd.Parameters.AddWithValue("@MasterStatusId", vmodel.MasterStatusId);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 1);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);

            if (vmodel.EffectiveStartDate == null)
            {
                cmd.Parameters.AddWithValue("@EffectiveStartDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EffectiveStartDate", vmodel.EffectiveStartDate);
            }
            if (vmodel.EffectiveEndDate == null)
            {
                cmd.Parameters.AddWithValue("@EffectiveEndDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EffectiveEndDate", vmodel.EffectiveEndDate);
            }

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update(VendorModel vmodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("VendorUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VendorId", vmodel.VendorId);
            cmd.Parameters.AddWithValue("@ClientId", vmodel.ClientId);
            cmd.Parameters.AddWithValue("@Code", vmodel.Code);
            cmd.Parameters.AddWithValue("@VendorName", vmodel.VendorName);
            cmd.Parameters.AddWithValue("@VendorShortName", vmodel.VendorShortName);
            cmd.Parameters.AddWithValue("@VendorAddress", vmodel.VendorAddress);
            cmd.Parameters.AddWithValue("@SpecialInstructions", vmodel.SpecialInstructions);
            cmd.Parameters.AddWithValue("@ContactName", vmodel.ContactName);
            cmd.Parameters.AddWithValue("@EmailId", vmodel.EmailId);
            cmd.Parameters.AddWithValue("@ContactNo", vmodel.ContactNo);
            cmd.Parameters.AddWithValue("@VendorGST", vmodel.VendorGST);
            cmd.Parameters.AddWithValue("@MasterStatusId", vmodel.MasterStatusId);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 4);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);

            if (vmodel.EffectiveStartDate == null)
            {
                cmd.Parameters.AddWithValue("@EffectiveStartDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EffectiveStartDate", vmodel.EffectiveStartDate);
            }
            if (vmodel.EffectiveEndDate == null)
            {
                cmd.Parameters.AddWithValue("@EffectiveEndDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EffectiveEndDate", vmodel.EffectiveEndDate);
            }

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Delete(int VId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("VendorDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VendorId", VId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<VendorModel> Vendor()
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
        public List<ClientModel> Client()
        {
            Connection();
            List<ClientModel> elist = new List<ClientModel>();

            SqlCommand cmd = new SqlCommand("Select * from Client", con);
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
    }
}
