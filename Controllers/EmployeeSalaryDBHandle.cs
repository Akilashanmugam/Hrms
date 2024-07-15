using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HrmsWeb.Models;
using Hrmsweb.Models;

namespace HrmsWeb.Controllers
{
    public class EmployeeSalaryDBHandle
    {
        private SqlConnection con;
        private DateTime stdt;
        private DateTime endt;
        private DateTime LUD;

        // GET: EmployeeSalaryDBHandle
        private void Connection()

        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);

        }

        public List<EmployeeSalaryModel> List(EmployeeSalaryModel Emodel)
        {
            Connection();
            List<EmployeeSalaryModel> plist = new List<EmployeeSalaryModel>();

            SqlCommand cmd = new SqlCommand("EmployeeSalaryList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientId", Emodel.srClientId);
            cmd.Parameters.AddWithValue("@EmployeeId", Emodel.srEmployeeId);
            cmd.Parameters.AddWithValue("@StackId", Emodel.srStackId);
            cmd.Parameters.AddWithValue("@DesignationId", Emodel.srDesignationId);
            cmd.Parameters.AddWithValue("@ReligionId", Emodel.srReligionId);
            cmd.Parameters.AddWithValue("@GenderId", Emodel.srGenderId);
            cmd.Parameters.AddWithValue("@NationalityId", Emodel.srNationalityId);
            cmd.Parameters.AddWithValue("@DepartmentId", Emodel.srDepartmentId);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {

                if (rdr.IsNull("WEFrom"))
                    stdt = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["WEFrom"].ToString(), out stdt) == false)
                        stdt = DateTime.MinValue;
                }

                if (rdr.IsNull("WETo"))
                    endt = DateTime.MinValue;


                else
                {
                    if (DateTime.TryParse(rdr["WETo"].ToString(), out endt) == false)
                        endt = DateTime.MinValue;
                }
                if (rdr.IsNull("LastUpdatedDate"))
                    LUD = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate"].ToString(), out LUD) == false)
                        LUD = DateTime.MinValue;
                }


                plist.Add(
                    new EmployeeSalaryModel
                    {
                        EmployeeSalaryId = (int)(rdr["EmployeeSalaryId"]),
                        EmployeeName = rdr["EmployeeName"].ToString(),
                        StackDetailName = rdr["StackDetailName"].ToString(),
                        DepartmentName = rdr["DepartmentName"].ToString(),
                        DesignationName = rdr["DesignationName"].ToString(),
                        ReligionName = rdr["ReligionName"].ToString(),
                        ClientName = rdr["ClientName"].ToString(),
                        GenderName = rdr["GenderName"].ToString(),
                        NationalityName = rdr["NationalityName"].ToString(),
                        WEFrom = stdt,
                        WETo = endt,
                        CTC_Month = (decimal)(rdr["CTC_Month"]),
                        CTC_PA = (decimal)(rdr["CTC_PA"]),
                        BDA = (decimal)(rdr["BDA"]),
                        HRA = (decimal)(rdr["HRA"]),
                        TA = (decimal)(rdr["TA"]),
                        MA = (decimal)(rdr["MA"]),
                        Bonus = (decimal)(rdr["Bonus"]),
                        SA = (decimal)(rdr["SA"]),
                        OA = (decimal)(rdr["OA"]),
                        Gross = (decimal)(rdr["Gross"]),
                        EPF = (decimal)(rdr["EPF"]),
                        EESI = (decimal)(rdr["EESI"]),
                        OB = (decimal)(rdr["OB"]),
                        ESI = (decimal)(rdr["ESI"]),
                        PF = (decimal)(rdr["PF"]),
                        VPF_Percentage = (decimal)(rdr["VPF_Percentage"]),
                        VPF_Amount = (decimal)(rdr["VPF_Amount"]),
                        TDS = (decimal)(rdr["TDS"]),
                        PT = (decimal)(rdr["PT"]),
                        OD = (decimal)(rdr["OD"]),
                        TotBen = (decimal)(rdr["TotBen"]),
                        TotDed = (decimal)(rdr["TotDed"]),
                        NetPay = (decimal)(rdr["NetPay"]),
                        Increment = (int)(rdr["Increment"]),
                        LastUpdatedByName = rdr["LastUpdatedByName"].ToString(),
                        LastUpdatedDate = LUD,
                        Remarks = (string)(rdr["Remarks"]),


                    });
            }
               return plist;
        }

        public List<EmployeeSalaryModel> ListGetById(int id)
        {
            Connection();
            List<EmployeeSalaryModel> eList = new List<EmployeeSalaryModel>();

            SqlCommand cmd = new SqlCommand("select * from QryEmployeeSalary where EmployeeSalaryId=" + id, con);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {

                if (rdr.IsNull("WEFrom"))
                    stdt = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["WEFrom"].ToString(), out stdt) == false)
                        stdt = DateTime.MinValue;
                }

                if (rdr.IsNull("WETo"))
                    endt = DateTime.MinValue;


                else
                {
                    if (DateTime.TryParse(rdr["WETo"].ToString(), out endt) == false)
                        endt = DateTime.MinValue;
                }
                if (rdr.IsNull("LastUpdatedDate"))
                    LUD = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate"].ToString(), out LUD) == false)
                        LUD = DateTime.MinValue;
                }

                eList.Add(
                    new EmployeeSalaryModel
                    {
                        EmployeeSalaryId = (int)(rdr["EmployeeSalaryId"]),
                        EmployeeId = (int)(rdr["EmployeeId"]),
                        StackId = (int)(rdr["StackId"]),
                        EmployeeName = rdr["EmployeeName"].ToString(),
                        StackDetailName = rdr["StackDetailName"].ToString(),
                        DepartmentName = rdr["DepartmentName"].ToString(),
                        DesignationName = rdr["DesignationName"].ToString(),
                        ReligionName = rdr["ReligionName"].ToString(),
                        ClientName = rdr["ClientName"].ToString(),
                        GenderName = rdr["GenderName"].ToString(),
                        NationalityName = rdr["NationalityName"].ToString(),
                        WEFrom = stdt,
                        WETo = endt,
                        CTC_Month = (decimal)(rdr["CTC_Month"]),
                        CTC_PA = (decimal)(rdr["CTC_PA"]),
                        BDA = (decimal)(rdr["BDA"]),
                        HRA = (decimal)(rdr["HRA"]),
                        TA = (decimal)(rdr["TA"]),
                        MA = (decimal)(rdr["MA"]),
                        Bonus = (decimal)(rdr["Bonus"]),
                        SA = (decimal)(rdr["SA"]),
                        OA = (decimal)(rdr["OA"]),
                        Gross = (decimal)(rdr["Gross"]),
                        EPF = (decimal)(rdr["EPF"]),
                        EESI = (decimal)(rdr["EESI"]),
                        OB = (decimal)(rdr["OB"]),
                        ESI = (decimal)(rdr["ESI"]),
                        PF = (decimal)(rdr["PF"]),
                        VPF_Percentage = (decimal)(rdr["VPF_Percentage"]),
                        VPF_Amount = (decimal)(rdr["VPF_Amount"]),
                        TDS = (decimal)(rdr["TDS"]),
                        PT = (decimal)(rdr["PT"]),
                        OD = (decimal)(rdr["OD"]),
                        TotBen = (decimal)(rdr["TotBen"]),
                        TotDed = (decimal)(rdr["TotDed"]),
                        NetPay = (decimal)(rdr["NetPay"]),
                        Increment = (int)(rdr["Increment"]),
                        LastUpdatedBy=(int)(rdr["LastUpdatedBy"]),
                        LastUpdatedByName = rdr["LastUpdatedByName"].ToString(),
                        LastUpdatedDate = LUD,
                        Remarks = (string)(rdr["Remarks"]),

                    });
            }
            return eList;
        }

        //dropdowns
        public List<EmployeeModel> Employee()
        {
            Connection();
            List<EmployeeModel> elist = new List<EmployeeModel>();

            SqlCommand cmd = new SqlCommand("Select * from QryEmployee", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            elist.Add(
                  new EmployeeModel
                  {
                      EmployeeId = 0,
                      EmployeeName = "-----Select-----",
                  });

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
       
        public List<StackDetailModel> StackList()
        {
            Connection();
            List<StackDetailModel> elist = new List<StackDetailModel>();

            SqlCommand cmd = new SqlCommand("select * from QrySalaryStack", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            elist.Add(
                 new StackDetailModel
                 {
                     StackId = 0,
                     StackDetailName = "-----Select-----",
                 });

            foreach (DataRow rdr in dt.Rows)
            {
                elist.Add(
                    new StackDetailModel
                    {
                        StackId = (int)(rdr["StackId"]),
                        StackDetailName = (string)(rdr["StackDetailName"]),

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
        public bool Add(EmployeeSalaryModel Emodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("EmployeeSalaryAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", Emodel.EmployeeId);
            cmd.Parameters.AddWithValue("@StackId", Emodel.StackId);
            cmd.Parameters.AddWithValue("@CTC_Month", Emodel.CTC_Month);
            cmd.Parameters.AddWithValue("@CTC_PA", Emodel.CTC_PA);
            cmd.Parameters.AddWithValue("@BDA", Emodel.BDA);
            cmd.Parameters.AddWithValue("@HRA", Emodel.HRA);
            cmd.Parameters.AddWithValue("@TA", Emodel.TA);
            cmd.Parameters.AddWithValue("@MA", Emodel.MA);
            cmd.Parameters.AddWithValue("@Bonus", Emodel.Bonus);
            cmd.Parameters.AddWithValue("@SA", Emodel.SA);
            cmd.Parameters.AddWithValue("@OA", Emodel.OA);
            cmd.Parameters.AddWithValue("@Gross", Emodel.Gross);
            cmd.Parameters.AddWithValue("@EPF", Emodel.EPF);
            cmd.Parameters.AddWithValue("@EESI", Emodel.EESI);
            cmd.Parameters.AddWithValue("@OB", Emodel.OB);
            cmd.Parameters.AddWithValue("@ESI", Emodel.ESI);
            cmd.Parameters.AddWithValue("@PF", Emodel.PF);
            cmd.Parameters.AddWithValue("@VPF_Percentage", Emodel.VPF_Percentage);
            cmd.Parameters.AddWithValue("@VPF_Amount", Emodel.VPF_Amount);
            cmd.Parameters.AddWithValue("@PT", Emodel.PT);
            cmd.Parameters.AddWithValue("@TDS", Emodel.TDS);
            cmd.Parameters.AddWithValue("@OD", Emodel.OD);
            cmd.Parameters.AddWithValue("@TotBen", Emodel.TotBen);
            cmd.Parameters.AddWithValue("@TotDed", Emodel.TotDed);
            cmd.Parameters.AddWithValue("@NetPay", Emodel.NetPay);
            cmd.Parameters.AddWithValue("@Increment", Emodel.Increment);
            cmd.Parameters.AddWithValue("@Remarks", Emodel.Remarks);

            if (Emodel.WEFrom == null)
            {
                cmd.Parameters.AddWithValue("@WEFrom", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@WEFrom", Emodel.WEFrom);
            }
            if (Emodel.WETo == null)
            {
                cmd.Parameters.AddWithValue("@WETo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@WETo", Emodel.WETo);
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

        public bool Update(EmployeeSalaryModel Emodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("EmployeeSalaryUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeSalaryId", Emodel.EmployeeSalaryId);
            cmd.Parameters.AddWithValue("@EmployeeId", Emodel.EmployeeId);
            cmd.Parameters.AddWithValue("@StackId", Emodel.StackId);
            cmd.Parameters.AddWithValue("@CTC_Month", Emodel.CTC_Month);
            cmd.Parameters.AddWithValue("@CTC_PA", Emodel.CTC_PA);
            cmd.Parameters.AddWithValue("@BDA", Emodel.BDA);
            cmd.Parameters.AddWithValue("@HRA", Emodel.HRA);
            cmd.Parameters.AddWithValue("@TA", Emodel.TA);
            cmd.Parameters.AddWithValue("@MA", Emodel.MA);
            cmd.Parameters.AddWithValue("@Bonus", Emodel.Bonus);
            cmd.Parameters.AddWithValue("@SA", Emodel.SA);
            cmd.Parameters.AddWithValue("@OA", Emodel.OA);
            cmd.Parameters.AddWithValue("@Gross", Emodel.Gross);
            cmd.Parameters.AddWithValue("@EPF", Emodel.EPF);
            cmd.Parameters.AddWithValue("@EESI", Emodel.EESI);
            cmd.Parameters.AddWithValue("@OB", Emodel.OB);
            cmd.Parameters.AddWithValue("@ESI", Emodel.ESI);
            cmd.Parameters.AddWithValue("@PF", Emodel.PF);
            cmd.Parameters.AddWithValue("@VPF_Percentage", Emodel.VPF_Percentage);
            cmd.Parameters.AddWithValue("@VPF_Amount", Emodel.VPF_Amount);
            cmd.Parameters.AddWithValue("@PT", Emodel.PT);
            cmd.Parameters.AddWithValue("@TDS", Emodel.TDS);
            cmd.Parameters.AddWithValue("@OD", Emodel.OD);
            cmd.Parameters.AddWithValue("@TotBen", Emodel.TotBen);
            cmd.Parameters.AddWithValue("@TotDed", Emodel.TotDed);
            cmd.Parameters.AddWithValue("@NetPay", Emodel.NetPay);
            cmd.Parameters.AddWithValue("@Increment", Emodel.Increment);
            cmd.Parameters.AddWithValue("@Remarks", Emodel.Remarks);

            if (Emodel.WEFrom == null)
            {
                cmd.Parameters.AddWithValue("@WEFrom", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@WEFrom", Emodel.WEFrom);
            }
            if (Emodel.WETo == null)
            {
                cmd.Parameters.AddWithValue("@WETo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@WETo", Emodel.WETo);
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

        public bool Delete(int EmployeeSalaryId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("EmployeeSalaryDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeSalaryId", EmployeeSalaryId);
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
