using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HrmsWeb.Models;
using Hrmsweb.Models;

namespace HrmsWeb.Models
{
    public class CompanyDBHandle
    {
        private SqlConnection con;
        private DateTime dt1;
        private DateTime dt2;
        private DateTime dt3;
        private DateTime dt4;
        private DateTime dt5;
        private DateTime dt6;
        private DateTime stdt;
        private DateTime endt;
        private DateTime lubydate;
        private string MobileNo;
        private string PhoneNo;
        private string EmailId;
        private string Department;
        private string Designation;


        private void Connection()

        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);
            
        }

        public List<CompanyModel> List()
        {
            Connection();
            List<CompanyModel> clist = new List<CompanyModel>();

            SqlCommand cmd = new SqlCommand("CompanyList",con);
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
                    new CompanyModel
                    {
                        CompanyId = (int)(rdr["CompanyId"]),
                        CompanyName = (string)(rdr["CompanyName"]),
                        CompanyShortName = rdr["CompanyShortName"].ToString(),
                        StartDate = stdt,
                        EndDate = endt,
                        LastUpdatedByName = rdr["LastUpdatedByName"].ToString(),
                        LastUpdatedDate = lubydate,
                    });
            }
            return clist;
        }


        public bool Add(CompanyModel cmodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("CompanyAdd",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyName", cmodel.CompanyName);
            cmd.Parameters.AddWithValue("@CompanyShortName", cmodel.CompanyShortName);
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

        public bool Update(CompanyModel cmodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("CompanyUpdate",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyId", cmodel.CompanyId);
            cmd.Parameters.AddWithValue("@CompanyName", cmodel.CompanyName);
            cmd.Parameters.AddWithValue("@CompanyShortName", cmodel.CompanyShortName);
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

        public bool Delete(int CompanyId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("CompanyDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        
        //....................company contact..............

        public List<CompanyContactModel> CompanyContactList(int id)
        {
            Connection();
            List<CompanyContactModel> cclist = new List<CompanyContactModel>();

            SqlCommand cmd = new SqlCommand("CompanyContactList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyId", id);
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

                if (rdr.IsNull("ContactStartDate"))
                    dt1 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["ContactStartDate"].ToString(), out dt1) == false)
                        dt1 = DateTime.MinValue;
                }
                if (rdr.IsNull("ContactEndDate"))
                    dt2 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["ContactEndDate"].ToString(), out dt2) == false)
                        dt2 = DateTime.MinValue;
                }
                if (rdr.IsNull("LastUpdatedDate"))
                    dt3 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate"].ToString(), out dt3) == false)
                        dt3 = DateTime.MinValue;
                }
                cclist.Add(
                    new CompanyContactModel
                    {
                        CompanyId = (int)(rdr["CompanyId"]),
                        ContactId = (int)(rdr["ContactId"]),
                        ContactName = (string)(rdr["ContactName"]),
                        MobileNo = MobileNo,
                        PhoneNo = PhoneNo,
                        EmailId = EmailId,
                        Department =Department,
                        Designation = Designation,
                        LastUpdatedBy = (int)(rdr["LastUpdatedBy"]),
                        LastUpdatedByName = rdr["LastUpdatedByName"].ToString(),
                        ContactStartDate = dt1,
                        ContactEndDate = dt2,
                        LastUpdatedDate = dt3,


                    });
            }
            return cclist;
        }
        public List<CompanyContactModel> CompanyContactListEdit(int id)
        {
            Connection();
            List<CompanyContactModel> cclist = new List<CompanyContactModel>();

            SqlCommand cmd = new SqlCommand("select * from CompanyContact where ContactId=" + id, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr.IsNull("ContactStartDate"))
                    dt4 = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(dr["ContactStartDate"].ToString(), out dt4) == false)
                        dt4 = DateTime.MinValue;
                }
                if (dr.IsNull("ContactEndDate"))
                    dt5 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(dr["ContactEndDate"].ToString(), out dt5) == false)
                        dt5 = DateTime.MinValue;
                }
                if (dr.IsNull("LastUpdatedDate"))
                    dt6 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(dr["LastUpdatedDate"].ToString(), out dt6) == false)
                        dt6 = DateTime.MinValue;
                }
                if (dr.IsNull("MobileNo")) { MobileNo = ""; } else { MobileNo = Convert.ToString(dr["MobileNo"]); }
                if (dr.IsNull("PhoneNo")) { PhoneNo = ""; } else { PhoneNo = Convert.ToString(dr["PhoneNo"]); }
                if (dr.IsNull("EmailId")) { EmailId = ""; } else { EmailId = Convert.ToString(dr["EmailId"]); }
                if (dr.IsNull("Department")) { Department = ""; } else { Department = Convert.ToString(dr["Department"]); }
                if (dr.IsNull("Designation")) { Designation = ""; } else { Designation = Convert.ToString(dr["Designation"]); }


                cclist.Add(
                    new CompanyContactModel
                    {
                        CompanyId = (int)(dr["CompanyId"]),
                        ContactId = (int)(dr["ContactId"]),
                        ContactName = (string)(dr["ContactName"]),
                        MobileNo = MobileNo,
                        PhoneNo = PhoneNo,
                        EmailId = EmailId,
                        Department = Department,
                        Designation = Designation,
                        LastUpdatedBy = (int)(dr["LastUpdatedBy"]),
                        LastUpdatedDate = dt6,
                        ContactStartDate = dt4,
                        ContactEndDate = dt5,

                    });
            }
            return cclist;
        }

        public bool AddCompanyContact(CompanyContactModel ccmodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("CompanyContactAdd",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyId",ccmodel.CompanyId);
            cmd.Parameters.AddWithValue("@ContactName", ccmodel.ContactName);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 1);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);
            if (ccmodel.MobileNo == null)
            {
                cmd.Parameters.AddWithValue("@MobileNo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@MobileNo", ccmodel.MobileNo);
            }


            if (ccmodel.PhoneNo == null)
            {
                cmd.Parameters.AddWithValue("@PhoneNo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PhoneNo", ccmodel.PhoneNo);
            }


            if (ccmodel.EmailId == null)
            {
                cmd.Parameters.AddWithValue("@EmailId", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EmailId", ccmodel.EmailId);
            }
            if (ccmodel.Department == null)
            {
                cmd.Parameters.AddWithValue("@Department", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Department", ccmodel.Department);
            }
            if (ccmodel.Designation == null)
            {
                cmd.Parameters.AddWithValue("@Designation", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Designation", ccmodel.Designation);
            }
            
            if (ccmodel.ContactStartDate == null)
            {
                cmd.Parameters.AddWithValue("@ContactStartdate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ContactStartDate", ccmodel.ContactStartDate);
            }
            if (ccmodel.ContactEndDate == null)
            {
                cmd.Parameters.AddWithValue("@ContactEndDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ContactEndDate", ccmodel.ContactEndDate);
            }
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;

           
        }
        public bool UpdateCompanyContact(CompanyContactModel ccmodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("CompanyContactUpdate",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContactId", ccmodel.ContactId);
            cmd.Parameters.AddWithValue("@ContactName", ccmodel.ContactName);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 1);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);
            if (ccmodel.MobileNo == null)
            {
                cmd.Parameters.AddWithValue("@MobileNo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@MobileNo", ccmodel.MobileNo);
            }


            if (ccmodel.PhoneNo == null)
            {
                cmd.Parameters.AddWithValue("@PhoneNo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PhoneNo", ccmodel.PhoneNo);
            }


            if (ccmodel.EmailId == null)
            {
                cmd.Parameters.AddWithValue("@EmailId", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@EmailId", ccmodel.EmailId);
            }
            if (ccmodel.Department == null)
            {
                cmd.Parameters.AddWithValue("@Department", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Department", ccmodel.Department);
            }
            if (ccmodel.Designation == null)
            {
                cmd.Parameters.AddWithValue("@Designation", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Designation", ccmodel.Designation);
            }

            
            if (ccmodel.ContactStartDate == null)
            {
                cmd.Parameters.AddWithValue("@ContactStartDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ContactStartDate", ccmodel.ContactStartDate);
            }
            if (ccmodel.ContactEndDate == null)
            {
                cmd.Parameters.AddWithValue("@ContactEndDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ContactEndDate", ccmodel.ContactEndDate);
            }
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool DeleteCompanyContact(int ContactId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("CompanyContactDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContactId", ContactId);
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





