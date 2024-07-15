using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HrmsWeb.Models;
using Hrmsweb.Models;

namespace HrmsWeb.Controllers
{
    public class ClientAddressDBHandle
    {
        private SqlConnection con;
        private DateTime stdt;
        private DateTime endt;


        private void Connection()

        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);

        }

        public List<ClientAddressModel> List()
        {
            Connection();
            List<ClientAddressModel> clist = new List<ClientAddressModel>();

            SqlCommand cmd = new SqlCommand("ClientAddressList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {

                if (rdr.IsNull("StartDate"))
                    stdt = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["StartDate"].ToString(), out stdt) == false)
                        stdt = DateTime.MinValue;
                }

                if (rdr.IsNull("EndDate"))
                    endt = DateTime.MinValue;


                else
                {
                    if (DateTime.TryParse(rdr["EndDate"].ToString(), out endt) == false)
                        endt = DateTime.MinValue;
                }


                clist.Add(
                    new ClientAddressModel
                    {
                        AddressId = (int)(rdr["AddressId"]),
                        ClientId = (int)(rdr["ClientId"]),
                        AddressTypeId = (int)(rdr["AddressTypeId"]),
                        Floor = (string)(rdr["Floor"]),
                        StartDate = stdt,
                        EndDate = endt,
                        BuildingName = (string)(rdr["BuildingName"]),
                        Road = (string)(rdr["Road"]),
                        Area = (string)(rdr["Area"]),
                        CityId = (int)(rdr["CityId"]),
                        StateId = (int)(rdr["StateId"]),
                        PinCode = (string)(rdr["PinCode"]),
                        CountryId = (int)(rdr["CountryId"]),
                        PhoneNo = (string)(rdr["PhoneNo"]),
                        MobileNo = (string)(rdr["MobileNo"]),
                        Fax = (string)(rdr["Fax"]),
                        EmailId = (string)(rdr["EmailId"]),
                        GSTIN = (string)(rdr["GSTIN"]),
                        CityName = rdr["CityName"].ToString(),
                        StateName = rdr["StateName"].ToString(),
                        CountryName = rdr["CountryName"].ToString(),
                        ClientName = rdr["ClientName"].ToString(),
                        AddressTypeName = rdr["AddressTypeName"].ToString(),
                    });
            }
            return clist;
        }

        public bool Add(ClientAddressModel camodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("ClientAddressAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@AddressTypeId", camodel.AddressTypeId);
            cmd.Parameters.AddWithValue("@Floor", camodel.Floor);
            cmd.Parameters.AddWithValue("@BuildingName", camodel.BuildingName);
            cmd.Parameters.AddWithValue("@ClientId", camodel.ClientId);
            cmd.Parameters.AddWithValue("@Road", camodel.Road);
            cmd.Parameters.AddWithValue("@Area", camodel.Area);
            cmd.Parameters.AddWithValue("@CityId", camodel.CityId);
            cmd.Parameters.AddWithValue("@StateId", camodel.StateId);
            cmd.Parameters.AddWithValue("@PinCode", camodel.PinCode);
            cmd.Parameters.AddWithValue("@CountryId", camodel.CountryId);
            cmd.Parameters.AddWithValue("@PhoneNo", camodel.PhoneNo);
            cmd.Parameters.AddWithValue("@MobileNo", camodel.MobileNo);
            cmd.Parameters.AddWithValue("@Fax", camodel.Fax);
            cmd.Parameters.AddWithValue("@EmailId", camodel.EmailId);
            cmd.Parameters.AddWithValue("@GSTIN", camodel.GSTIN);
            if (camodel.StartDate == null)
            {
                cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@StartDate", camodel.StartDate);
            }
            if (camodel.EndDate == null)
            {
                cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EndDate", camodel.EndDate);
            }

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update(ClientAddressModel camodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("ClientAddressUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AddressId", camodel.AddressId);
            cmd.Parameters.AddWithValue("@AddressTypeId", camodel.AddressTypeId);
            cmd.Parameters.AddWithValue("@Floor", camodel.Floor);
            cmd.Parameters.AddWithValue("@BuildingName", camodel.BuildingName);
            cmd.Parameters.AddWithValue("@ClientId", camodel.ClientId);
            cmd.Parameters.AddWithValue("@Road", camodel.Road);
            cmd.Parameters.AddWithValue("@Area", camodel.Area);
            cmd.Parameters.AddWithValue("@CityId", camodel.CityId);
            cmd.Parameters.AddWithValue("@StateId", camodel.StateId);
            cmd.Parameters.AddWithValue("@PinCode", camodel.PinCode);
            cmd.Parameters.AddWithValue("@CountryId", camodel.CountryId);
            cmd.Parameters.AddWithValue("@PhoneNo", camodel.PhoneNo);
            cmd.Parameters.AddWithValue("@MobileNo", camodel.MobileNo);
            cmd.Parameters.AddWithValue("@Fax", camodel.Fax);
            cmd.Parameters.AddWithValue("@EmailId", camodel.EmailId);
            cmd.Parameters.AddWithValue("@GSTIN", camodel.GSTIN);
            if (camodel.StartDate == null)
            {
                cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@StartDate", camodel.StartDate);
            }
            if (camodel.EndDate == null)
            {
                cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EndDate", camodel.EndDate);
            }

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Delete(int ClientAddressId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("ClientAddressDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AddressId", ClientAddressId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
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



    }
}