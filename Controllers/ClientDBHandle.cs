using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace HrmsWeb.Models
{
    public class ClientDBHandle
    {
        //declare connection string
        private SqlConnection con;

        private DateTime dt1;
        private DateTime dt2;
        private DateTime dt3;
        private DateTime stdt;
        private DateTime endt;
        private DateTime lubydate;
        private string MobileNo;
        private string PhoneNo;
        private string EmailId;
        private string Department;
        private string Designation;

       

        private void connection()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(cs);
        }

        // ********** VIEW Client DETAILS ********************
        public List<ClientModel> List()
                 {

            connection();

            List<ClientModel> clist = new List<ClientModel>();

            SqlCommand cmd = new SqlCommand("ClientList", con);

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
                if (rdr.IsNull("LastUpdatedDate"))
                    lubydate = DateTime.MinValue;


                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate"].ToString(), out lubydate) == false)
                        lubydate = DateTime.MinValue;
                }

                clist.Add(

                    new ClientModel

                    {
                        ClientId = Convert.ToInt32(rdr["ClientId"]),
                        ClientName = Convert.ToString(rdr["ClientName"]),
                        ClientShortName = rdr["ClientShortName"].ToString(),
                        StartDate =stdt,
                        EndDate = endt,
                        LastUpdatedByName = rdr["LastUpdatedByName"].ToString(),
                        LastUpdatedDate = lubydate,
                    });

            }

            return clist;

        }

        // **************** ADD NEW CLIENT *********************
        public bool Add(ClientModel cmodel)
        {

            connection();
            SqlCommand cmd = new SqlCommand("ClientAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("  @ClientId ", cmodel.ClientId);
            cmd.Parameters.AddWithValue("@ClientName", cmodel.ClientName);
            cmd.Parameters.AddWithValue("@ClientShortName", cmodel.ClientShortName);
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
            cmd.Parameters.AddWithValue("@LastUpdatedDate",DateTime.Today);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ***************** UPDATE CLIENT DETAILS *********************
        public bool Update(ClientModel cmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("ClientUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientId", cmodel.ClientId);
            cmd.Parameters.AddWithValue("@ClientName", cmodel.ClientName);
            cmd.Parameters.AddWithValue("@ClientShortName", cmodel.ClientShortName);
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

        // ********************** DELETE CLIENT DETAILS *******************
        public bool Delete(int Id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("ClientDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientId", Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW Client Contact DETAILS ********************
        public List<ClientContactModel> ContactList(int id)
        {

            connection();
            List<ClientContactModel> contactlist = new List<ClientContactModel>();
            SqlCommand cmd = new SqlCommand("ClientContactList", con);
            cmd.Parameters.AddWithValue("@ClientId", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow rdr in dt.Rows)
            {
                if (rdr.IsNull("MobileNo")) { MobileNo = ""; } else { MobileNo = Convert.ToString(rdr["MobileNo"]); }
                if (rdr.IsNull("PhoneNo")) { PhoneNo = ""; } else { PhoneNo = Convert.ToString(rdr["PhoneNo"]); }
                if (rdr.IsNull("EmailId")) { EmailId = ""; } else { EmailId = Convert.ToString(rdr["EmailId"]); }
                if (rdr.IsNull("Department")) { Department = ""; } else { Department = Convert.ToString(rdr["Department"]); }
                if (rdr.IsNull("Designation")) { Designation = ""; } else { Designation = Convert.ToString(rdr["Designation"]); }
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
                if (rdr.IsNull("LastUpdatedDate"))
                    lubydate = DateTime.MinValue;


                else
                {
                    if (DateTime.TryParse(rdr["EndDate"].ToString(), out lubydate) == false)
                        lubydate = DateTime.MinValue;
                }

                contactlist.Add(
   new ClientContactModel
   {
       ContactId = Convert.ToInt32(rdr["ContactId"]),
       ClientId = Convert.ToInt32(rdr["ClientId"]),
       ContactName = Convert.ToString(rdr["ContactName"]),
       MobileNo= MobileNo,
       PhoneNo = PhoneNo,
       EmailId = EmailId,
       Department = Department,
       Designation = Designation,
       StartDate = stdt,
       EndDate = endt,
       LastUpdatedByName = rdr["LastUpdatedByName"].ToString(),
       LastUpdatedDate = lubydate,
   });


            }

            return contactlist;

        }
        // ********** VIEW Client Contact DETAILS ********************
        public List<ClientContactModel> ContactEditList(int id)
        {

            connection();
            List<ClientContactModel> clist = new List<ClientContactModel>();
            SqlCommand cmd = new SqlCommand("Select * from ClientContact where ContactId=" + id, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {

                if (rdr.IsNull("MobileNo")) { MobileNo = ""; } else { MobileNo = Convert.ToString(rdr["MobileNo"]); }
                if (rdr.IsNull("PhoneNo")) { PhoneNo = ""; } else { PhoneNo = Convert.ToString(rdr["PhoneNo"]); }
                if (rdr.IsNull("EmailId")) { EmailId = ""; } else { EmailId = Convert.ToString(rdr["EmailId"]); }
                if (rdr.IsNull("Department")) { Department = ""; } else { Department = Convert.ToString(rdr["Department"]); }
                if (rdr.IsNull("Designation")) { Designation = ""; } else { Designation = Convert.ToString(rdr["Designation"]); }
              
                if (rdr.IsNull("StartDate"))
                    dt1 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["StartDate"].ToString(), out dt1) == false)
                        dt1 = DateTime.MinValue;
                }
                if (rdr.IsNull("EndDate"))
                    dt2= DateTime.MinValue;
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
                new ClientContactModel
                {
                    ContactId = Convert.ToInt32(rdr["ContactId"]),
                    ClientId = Convert.ToInt32(rdr["ClientId"]),
                    ContactName = Convert.ToString(rdr["ContactName"]),
                    MobileNo = MobileNo,
                    PhoneNo = PhoneNo,
                    EmailId = EmailId,
                    Department = Department,
                    Designation = Designation,
                    StartDate = dt1,
                    EndDate = dt2,
                    LastUpdatedBy = Convert.ToInt32(rdr["LastUpdatedBy"]),
                    LastUpdatedDate = dt3
                });

            }

            return clist;

        }



        // **************** ADD NEW CLIENT Contact*********************
        public bool ContactAdd(ClientContactModel cmodel)
        {

            connection();
            SqlCommand cmd = new SqlCommand("ClientContactAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientId ", cmodel.ClientId);
            cmd.Parameters.AddWithValue("@ContactName", cmodel.ContactName);
            if (cmodel.MobileNo == null)
            {
                cmd.Parameters.AddWithValue("@MobileNo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@MobileNo", cmodel.MobileNo);
            }


            if (cmodel.PhoneNo == null)
            {
                cmd.Parameters.AddWithValue("@PhoneNo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PhoneNo", cmodel.PhoneNo);
            }


            if (cmodel.EmailId == null)
            {
                cmd.Parameters.AddWithValue("@EmailId", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EmailId", cmodel.EmailId);
            }
            if (cmodel.Department == null)
            {
                cmd.Parameters.AddWithValue("@Department", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Department", cmodel.Department);
            }
            if (cmodel.Designation == null)
            {
                cmd.Parameters.AddWithValue("@Designation", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Designation", cmodel.Designation);
            }
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
        // ***************** UPDATE CLIENT CONTACT DETAILS *********************
        public bool ContactUpdate(ClientContactModel cmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("ClientContactUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@ContactId", cmodel.ContactId);
            cmd.Parameters.AddWithValue("@ContactName", cmodel.ContactName);
            if (cmodel.MobileNo == null)
            {
                cmd.Parameters.AddWithValue("@MobileNo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@MobileNo", cmodel.MobileNo);
            }


            if (cmodel.PhoneNo == null)
            {
                cmd.Parameters.AddWithValue("@PhoneNo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PhoneNo", cmodel.PhoneNo);
            }


            if (cmodel.EmailId == null)
            {
                cmd.Parameters.AddWithValue("@EmailId", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EmailId", cmodel.EmailId);
            }
            if (cmodel.Department == null)
            {
                cmd.Parameters.AddWithValue("@Department", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Department", cmodel.Department);
            }
            if (cmodel.Designation == null)
            {
                cmd.Parameters.AddWithValue("@Designation", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Designation", cmodel.Designation);
            }
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
        // ********************** DELETE CLIENT CONTACT DETAILS *******************
        public bool ContactDelete(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("ClientContactDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContactId", id);
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