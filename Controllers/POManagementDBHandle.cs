using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HrmsWeb.Models;
using Hrmsweb.Models;

namespace HrmsWeb.Controllers
{
    public class POManagementDBHandle
    {
        private SqlConnection con;
        private DateTime stdt;
        private DateTime endt;
        private DateTime podate;
        private DateTime Clientdate;
        private DateTime ldate;
        private DateTime dt3;
        private DateTime dt4;
        private DateTime dt6;
        private DateTime startdate;
        private DateTime enddate;
        private DateTime AssignmentStartDate;
        private DateTime AssignmentEndDate;
        private DateTime LastUpdatedDate2;
        private DateTime DOJ;
        private DateTime DOL;
        private void Connection()

        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);

        }

        public List<POManagementModel> List(POManagementModel pommodel)
        {
            Connection();
            List<POManagementModel> pomlist = new List<POManagementModel>();

            SqlCommand cmd = new SqlCommand("POManagementList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientId", pommodel.srClientId);
            cmd.Parameters.AddWithValue("@ProjectId", pommodel.srProjectId);
            cmd.Parameters.AddWithValue("@PoTypeId", pommodel.srPoTypeId);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {

                if (rdr.IsNull("PoStartDate"))
                    stdt = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["PoStartDate"].ToString(), out stdt) == false)
                        stdt = DateTime.MinValue;
                }

                if (rdr.IsNull("PoEndDate"))
                    endt = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["PoEndDate"].ToString(), out endt) == false)
                        endt = DateTime.MinValue;
                }

                if (rdr.IsNull("PoDate"))
                    podate = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["PoDate"].ToString(), out podate) == false)
                        podate = DateTime.MinValue;
                }

                if (rdr.IsNull("ClientPoDate"))
                    Clientdate = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["ClientPoDate"].ToString(), out Clientdate) == false)
                        Clientdate = DateTime.MinValue;
                }

                if (rdr.IsNull("LastUpdatedDate"))
                    ldate = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate"].ToString(), out ldate) == false)
                        ldate = DateTime.MinValue;
                }

                pomlist.Add(
                    new POManagementModel
                    {
                        PoId = (int)(rdr["PoId"]),
                        PoCode = (string)(rdr["PoCode"]),
                        PoName = (string)(rdr["PoName"]),
                        PoTypeId = (int)(rdr["PoTypeId"]),
                        PoDate=podate,
                        ClientId = (int)(rdr["ClientId"]),
                        ProjectId = (int)(rdr["ProjectId"]),
                        PaymentTerms = (string)(rdr["PaymentTerms"]),
                        PoValue = (decimal)(rdr["PoValue"]),
                        CurrencyId = (int)(rdr["CurrencyId"]),
                        ClientPoNo = (string)(rdr["ClientPoNo"]),
                        ClientPoDate = Clientdate,
                        PoStartDate = stdt,
                        PoEndDate = endt,
                        PoBillingAddressId = (int)(rdr["PoBillingAddressId"]),
                        PoShippingAddressId = (int)(rdr["PoShippingAddressId"]),
                        PoContactPerson = (string)(rdr["PoContactPerson"]),
                        PoMobileNo = (string)(rdr["PoMobileNo"]),
                        PoEmailId = (string)(rdr["PoEmailId"]),
                        Remarks = (string)(rdr["Remarks"]),
                        LastUpdatedBy=(int)(rdr["LastUpdatedBy"]),
                        UserName = rdr["UserName"].ToString(),
                        CurrencyName = rdr["CurrencyName"].ToString(),
                        ShippingAddressName = rdr["ShippingAddressName"].ToString(),
                        BillingAddressName = rdr["BillingAddressName"].ToString(),
                        PTName = rdr["PTName"].ToString(),
                        ClientName1 = rdr["ClientName1"].ToString(),
                        ProjectName1 = rdr["ProjectName1"].ToString(),
                        LastUpdatedDate = ldate,
                    });
            }
            return pomlist;
        }

        public List<POManagementModel> ListGetById(int id)
        {
            Connection();
            List<POManagementModel> pomList = new List<POManagementModel>();

            SqlCommand cmd = new SqlCommand("select * from QryPOManagement where PoId=" + id, con);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {

                if (rdr.IsNull("PoStartDate"))
                    stdt = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["PoStartDate"].ToString(), out stdt) == false)
                        stdt = DateTime.MinValue;
                }

                if (rdr.IsNull("PoEndDate"))
                    endt = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["PoEndDate"].ToString(), out endt) == false)
                        endt = DateTime.MinValue;
                }

                if (rdr.IsNull("PoDate"))
                    podate = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["PoDate"].ToString(), out podate) == false)
                        podate = DateTime.MinValue;
                }

                if (rdr.IsNull("ClientPoDate"))
                    Clientdate = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["ClientPoDate"].ToString(), out Clientdate) == false)
                        Clientdate = DateTime.MinValue;
                }

                if (rdr.IsNull("LastUpdatedDate"))
                    ldate = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate"].ToString(), out ldate) == false)
                        ldate = DateTime.MinValue;
                }

                pomList.Add(
                    new POManagementModel
                    {
                        PoId = (int)(rdr["PoId"]),
                        PoCode = (string)(rdr["PoCode"]),
                        PoName = (string)(rdr["PoName"]),
                        PoTypeId = (int)(rdr["PoTypeId"]),
                        PoDate = podate,
                        ClientId = (int)(rdr["ClientId"]),
                        ProjectId = (int)(rdr["ProjectId"]),
                        PaymentTerms = (string)(rdr["PaymentTerms"]),
                        PoValue = (decimal)(rdr["PoValue"]),
                        CurrencyId = (int)(rdr["CurrencyId"]),
                        ClientPoNo = (string)(rdr["ClientPoNo"]),
                        ClientPoDate = Clientdate,
                        PoStartDate = stdt,
                        PoEndDate = endt,
                        PoBillingAddressId = (int)(rdr["PoBillingAddressId"]),
                        PoShippingAddressId = (int)(rdr["PoShippingAddressId"]),
                        PoContactPerson = (string)(rdr["PoContactPerson"]),
                        PoMobileNo = (string)(rdr["PoMobileNo"]),
                        PoEmailId = (string)(rdr["PoEmailId"]),
                        Remarks = (string)(rdr["Remarks"]),
                        LastUpdatedBy = (int)(rdr["LastUpdatedBy"]),
                        UserName = rdr["UserName"].ToString(),
                        CurrencyName = rdr["CurrencyName"].ToString(),
                        ShippingAddressName = rdr["ShippingAddressName"].ToString(),
                        BillingAddressName = rdr["BillingAddressName"].ToString(),
                        PTName = rdr["PTName"].ToString(),
                        ClientName1 = rdr["ClientName1"].ToString(),
                        ProjectName1 = rdr["ProjectName1"].ToString(),
                        LastUpdatedDate = ldate,
                    });
            }
            return pomList;
           
        }
        public bool Add(POManagementModel pommodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("POManagementAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PoCode", pommodel.PoCode);
            cmd.Parameters.AddWithValue("@PoName", pommodel.PoName);
            cmd.Parameters.AddWithValue("@PoTypeId", pommodel.PoTypeId);
            
            cmd.Parameters.AddWithValue("@ClientId", pommodel.ClientId);
            cmd.Parameters.AddWithValue("@ProjectId", pommodel.ProjectId);
            cmd.Parameters.AddWithValue("@PaymentTerms", pommodel.PaymentTerms);
            cmd.Parameters.AddWithValue("@PoValue", pommodel.PoValue);
            cmd.Parameters.AddWithValue("@CurrencyId", pommodel.CurrencyId);
            cmd.Parameters.AddWithValue("@ClientPoNo", pommodel.ClientPoNo);
            
            cmd.Parameters.AddWithValue("@PoBillingAddressId", pommodel.PoBillingAddressId);
            cmd.Parameters.AddWithValue("@PoShippingAddressId", pommodel.PoShippingAddressId);
            cmd.Parameters.AddWithValue("@PoContactPerson", pommodel.PoContactPerson);
            cmd.Parameters.AddWithValue("@PoMobileNo", pommodel.PoMobileNo);
            cmd.Parameters.AddWithValue("@PoEmailId", pommodel.PoEmailId);
            cmd.Parameters.AddWithValue("@Remarks", pommodel.Remarks);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 2);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);
            if (pommodel.PoStartDate == null)
            {
                cmd.Parameters.AddWithValue("@PoStartDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PoStartDate", pommodel.PoStartDate);
            }
            if (pommodel.PoEndDate == null)
            {
                cmd.Parameters.AddWithValue("@PoEndDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PoEndDate", pommodel.PoEndDate);
            }
            if (pommodel.PoDate == null)
            {
                cmd.Parameters.AddWithValue("@PoDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PoDate", pommodel.PoDate);
            }
            if (pommodel.ClientPoDate == null)
            {
                cmd.Parameters.AddWithValue("@ClientPoDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ClientPoDate", pommodel.ClientPoDate);
            }

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update(POManagementModel pommodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("POManagementUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PoId", pommodel.PoId);
            cmd.Parameters.AddWithValue("@PoCode", pommodel.PoCode);
            cmd.Parameters.AddWithValue("@PoName", pommodel.PoName);
            //cmd.Parameters.AddWithValue("@PoTypeId", pommodel.PoTypeId);

            cmd.Parameters.AddWithValue("@ClientId", pommodel.ClientId);
            cmd.Parameters.AddWithValue("@ProjectId", pommodel.ProjectId);
            cmd.Parameters.AddWithValue("@PaymentTerms", pommodel.PaymentTerms);
            cmd.Parameters.AddWithValue("@PoValue", pommodel.PoValue);
            cmd.Parameters.AddWithValue("@CurrencyId", pommodel.CurrencyId);
            cmd.Parameters.AddWithValue("@ClientPoNo", pommodel.ClientPoNo);

            cmd.Parameters.AddWithValue("@PoBillingAddressId", pommodel.PoBillingAddressId);
            cmd.Parameters.AddWithValue("@PoShippingAddressId", pommodel.PoShippingAddressId);
            cmd.Parameters.AddWithValue("@PoContactPerson", pommodel.PoContactPerson);
            cmd.Parameters.AddWithValue("@PoMobileNo", pommodel.PoMobileNo);
            cmd.Parameters.AddWithValue("@PoEmailId", pommodel.PoEmailId);
            cmd.Parameters.AddWithValue("@Remarks", pommodel.Remarks);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 2);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);
            if (pommodel.PoStartDate == null)
            {
                cmd.Parameters.AddWithValue("@PoStartDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PoStartDate", pommodel.PoStartDate);
            }
            if (pommodel.PoEndDate == null)
            {
                cmd.Parameters.AddWithValue("@PoEndDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PoEndDate", pommodel.PoEndDate);
            }
            if (pommodel.PoDate == null)
            {
                cmd.Parameters.AddWithValue("@PoDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PoDate", pommodel.PoDate);
            }
            if (pommodel.ClientPoDate == null)
            {
                cmd.Parameters.AddWithValue("@ClientPoDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ClientPoDate", pommodel.ClientPoDate);
            }

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Delete(int PoId, int PoTypeId)
        {
            Connection(); 
            SqlCommand cmd = new SqlCommand("POManagementDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PoId", PoId);
            cmd.Parameters.AddWithValue("@PoTypeId", PoTypeId);
            con.Open();
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return result == 1;
        }


        //------------dropdowns-------------//
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

        public List<POManagementModel> POType()
        {
            Connection();
            List<POManagementModel> elist = new List<POManagementModel>();

            SqlCommand cmd = new SqlCommand("Select * from QryPOType", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            elist.Add(
                  new POManagementModel
                  {
                      PoTypeId = 0,
                      PoTypeName = "-----Select-----",
                  });

            foreach (DataRow rdr in dt.Rows)
            {
                elist.Add(
                    new POManagementModel
                    {
                        PoTypeId = (int)(rdr["PoTypeId"]),
                        PoTypeName = (string)(rdr["PoTypeName"]),

                    });
            }
            return elist;
        }

        public List<POManagementModel> BillingAddress()
        {
            Connection();
            List<POManagementModel> elist = new List<POManagementModel>();

            SqlCommand cmd = new SqlCommand("Select * from QryBillingAddress", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            elist.Add(
                  new POManagementModel
                  {
                      BillingAddressId = 0,
                      BillingAddressName = "-----Select-----",
                  });

            foreach (DataRow rdr in dt.Rows)
            {
                elist.Add(
                    new POManagementModel
                    {
                        BillingAddressId = (int)(rdr["BillingAddressId"]),
                        BillingAddressName = (string)(rdr["BillingAddressName"]),

                    });
            }
            return elist;
        }

        public List<POManagementModel> ShippingAddress()
        {
            Connection();
            List<POManagementModel> elist = new List<POManagementModel>();

            SqlCommand cmd = new SqlCommand("Select * from QryShippingAddress", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            elist.Add(
                  new POManagementModel
                  {
                      ShippingAddressId = 0,
                      ShippingAddressName = "-----Select-----",
                  });

            foreach (DataRow rdr in dt.Rows)
            {
                elist.Add(
                    new POManagementModel
                    {
                        ShippingAddressId = (int)(rdr["ShippingAddressId"]),
                        ShippingAddressName = (string)(rdr["ShippingAddressName"]),

                    });
            }
            return elist;
        }

        //----------------Po Placement Employee-------------------//
        public List<POManagementModel> POPEList(int id)
        {
            Connection();
            List<POManagementModel> popelist = new List<POManagementModel>();

            SqlCommand cmd = new SqlCommand("POPlacementEmployeeList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PoId", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
                if (rdr.IsNull("LastUpdatedDate"))
                    dt3 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate"].ToString(), out dt3) == false)
                        dt3 = DateTime.MinValue;
                }
                popelist.Add(
                    new POManagementModel
                    {
                        PEId = (int)(rdr["PEId"]),
                        EmployeeId = (int)(rdr["EmployeeId"]),
                        DateofJoin = (DateTime)(rdr["DateofJoin"]),
                        Skills = (string)(rdr["Skills"]),
                        MonthlyCTC = (decimal)(rdr["MonthlyCTC"]),
                        AnnualCTC = (decimal)(rdr["AnnualCTC"]),
                        PlacementCalculationTypeId = (int)(rdr["PlacementCalculationTypeId"]),
                        CalculationValue = (decimal)(rdr["CalculationValue"]),
                        BillingAmount = (decimal)(rdr["BillingAmount"]),
                        BillableDays = (int)(rdr["BillableDays"]),
                        Taxable = (int)(rdr["Taxable"]),
                        SubVendorId = (int)(rdr["SubVendorId"]),
                        EmployeeAddress = (string)(rdr["EmployeeAddress"]),
                        MobileNo = (string)(rdr["MobileNo"]),
                        EmailId = (string)(rdr["EmailId"]),
                        StatusId = (int)(rdr["StatusId"]),
                        Remarks1 = (string)(rdr["Remarks1"]),
                        LastUpdatedBy = (int)(rdr["LastUpdatedBy"]),
                        UserName = rdr["UserName"].ToString(),
                        VendorName = rdr["VendorName"].ToString(),
                        StatusName = rdr["StatusName"].ToString(),
                        PlacementCalculationType = rdr["PlacementCalculationType"].ToString(),
                        EmployeeName = rdr["EmployeeName"].ToString(),
                        TaxType = rdr["TaxType"].ToString(),
                        LastUpdatedDate = dt3,


                    });
            }
            return popelist;
        }

        public bool AddPOPE(POManagementModel popemodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("POPlacementEmployeeAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PoId", popemodel.PoId);
            cmd.Parameters.AddWithValue("@EmployeeId", popemodel.EmployeeId);
            cmd.Parameters.AddWithValue("@DateofJoin", popemodel.DateofJoin);
            cmd.Parameters.AddWithValue("@Skills", popemodel.Skills);
            cmd.Parameters.AddWithValue("@MonthlyCTC", popemodel.MonthlyCTC);
            cmd.Parameters.AddWithValue("@AnnualCTC", popemodel.AnnualCTC);
            cmd.Parameters.AddWithValue("@PlacementCalculationTypeId", popemodel.PlacementCalculationTypeId);
            cmd.Parameters.AddWithValue("@CalculationValue", popemodel.CalculationValue);
            cmd.Parameters.AddWithValue("@BillingAmount", popemodel.BillingAmount);
            cmd.Parameters.AddWithValue("@BillableDays", popemodel.BillableDays);
            cmd.Parameters.AddWithValue("@Taxable", popemodel.Taxable);
            cmd.Parameters.AddWithValue("@SubVendorId", popemodel.SubVendorId);
            cmd.Parameters.AddWithValue("@EmployeeAddress", popemodel.EmployeeAddress);
            cmd.Parameters.AddWithValue("@MobileNo", popemodel.MobileNo);
            cmd.Parameters.AddWithValue("@EmailId", popemodel.EmailId);
            cmd.Parameters.AddWithValue("@StatusId", popemodel.StatusId);
            cmd.Parameters.AddWithValue("@Remarks1", popemodel.Remarks1);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 3);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);
           
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;


        }

        public List<POManagementModel> POPEEdit(int id)
        {
            Connection();
            List<POManagementModel> popelist = new List<POManagementModel>();

            SqlCommand cmd = new SqlCommand("select * from POPlacementEmployee where PEId=" + id, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr.IsNull("DateofJoin"))
                    dt4 = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(dr["DateofJoin"].ToString(), out dt4) == false)
                        dt4 = DateTime.MinValue;
                }
              
                if (dr.IsNull("LastUpdatedDate"))
                    dt6 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(dr["LastUpdatedDate"].ToString(), out dt6) == false)
                        dt6 = DateTime.MinValue;
                }

                popelist.Add(
                    new POManagementModel
                    {
                        PoId = (int)(dr["PoId"]),
                        PEId = (int)(dr["PEId"]),
                        EmployeeId = (int)(dr["EmployeeId"]),
                        Skills = (string)(dr["Skills"]),
                        MonthlyCTC = (decimal)(dr["MonthlyCTC"]),
                        AnnualCTC = (decimal)(dr["AnnualCTC"]),
                        PlacementCalculationTypeId = (int)(dr["PlacementCalculationTypeId"]),
                        CalculationValue = (decimal)(dr["CalculationValue"]),
                        BillingAmount = (decimal)(dr["BillingAmount"]),
                        BillableDays = (int)(dr["BillableDays"]),
                        Taxable = (int)(dr["Taxable"]),
                        SubVendorId = (int)(dr["SubVendorId"]),
                        EmployeeAddress = (string)(dr["EmployeeAddress"]),
                        MobileNo = (string)(dr["MobileNo"]),
                        EmailId = (string)(dr["EmailId"]),
                        StatusId = (int)(dr["StatusId"]),
                        Remarks1 = (string)(dr["Remarks1"]),
                        LastUpdatedBy = (int)(dr["LastUpdatedBy"]),
                        LastUpdatedDate = dt6,
                        DateofJoin = dt4,
                        

                    });
            }
            return popelist;
        }

        public bool UpdatePOPE(POManagementModel popemodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("POPlacementEmployeeUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PEId", popemodel.PEId);
            cmd.Parameters.AddWithValue("@EmployeeId", popemodel.EmployeeId);
            cmd.Parameters.AddWithValue("@Skills", popemodel.Skills);
            cmd.Parameters.AddWithValue("@MonthlyCTC", popemodel.MonthlyCTC);
            cmd.Parameters.AddWithValue("@AnnualCTC", popemodel.AnnualCTC);
            cmd.Parameters.AddWithValue("@PlacementCalculationTypeId", popemodel.PlacementCalculationTypeId);
            cmd.Parameters.AddWithValue("@CalculationValue", popemodel.CalculationValue);
            cmd.Parameters.AddWithValue("@BillingAmount", popemodel.BillingAmount);
            cmd.Parameters.AddWithValue("@BillableDays", popemodel.BillableDays);
            cmd.Parameters.AddWithValue("@Taxable", popemodel.Taxable);
            cmd.Parameters.AddWithValue("@SubVendorId", popemodel.SubVendorId);
            cmd.Parameters.AddWithValue("@EmployeeAddress", popemodel.EmployeeAddress);
            cmd.Parameters.AddWithValue("@MobileNo", popemodel.MobileNo);
            cmd.Parameters.AddWithValue("@EmailId", popemodel.EmailId);
            cmd.Parameters.AddWithValue("@StatusId", popemodel.StatusId);
            cmd.Parameters.AddWithValue("@Remarks1", popemodel.Remarks1);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 4);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);
           
            if (popemodel.DateofJoin == null)
            {
                cmd.Parameters.AddWithValue("@DateofJoin", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DateofJoin", popemodel.DateofJoin);
            }
           
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool DeletePOPE(int PEId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("POPlacementEmployeeDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PEId", PEId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        //-------------------dropdowns----------------------------//
        public List<VendorModel> Vendor()
        {
            Connection();
            List<VendorModel> elist = new List<VendorModel>();

            SqlCommand cmd = new SqlCommand("Select * from QryVendor", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            elist.Add(
                  new VendorModel
                  {
                      VendorId = 0,
                      VendorName = "-----Select-----",
                  });

            foreach (DataRow rdr in dt.Rows)
            {
                elist.Add(
                    new VendorModel
                    {
                        VendorId = (int)(rdr["VendorId"]),
                        VendorName = (string)(rdr["VendorName"]),

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

        public List<POManagementModel> PlacementCalculation()
        {
            Connection();
            List<POManagementModel> elist = new List<POManagementModel>();

            SqlCommand cmd = new SqlCommand("Select * from QryPlacementCalculationType", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            elist.Add(
                  new POManagementModel
                  {
                      PlacementCalculationTypeId = 0,
                      PlacementCalculationType = "-----Select-----",
                  });

            foreach (DataRow rdr in dt.Rows)
            {
                elist.Add(
                    new POManagementModel
                    {
                        PlacementCalculationTypeId = (int)(rdr["PlacementCalculationTypeId"]),
                        PlacementCalculationType = (string)(rdr["PlacementCalculationType"]),

                    });
            }
            return elist;
        }

        public List<POManagementModel> Taxable()
        {
            Connection();
            List<POManagementModel> tlist = new List<POManagementModel>();

            SqlCommand cmd = new SqlCommand("Select * from QryTaxable", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            tlist.Add(
                  new POManagementModel
                  {
                      TaxId = 0,
                      TaxType = "-----Select-----",
                  });

            foreach (DataRow rdr in dt.Rows)
            {
                tlist.Add(
                    new POManagementModel
                    {
                        TaxId = (int)(rdr["TaxId"]),
                        TaxType = (string)(rdr["TaxType"]),

                    });
            }
            return tlist;
        }

        //---------------PO Milestone------------------//
        public List<MilestoneModel> MilestoneList(int id)
        {
            Connection();
            List<MilestoneModel> mlist = new List<MilestoneModel>();

            SqlCommand cmd = new SqlCommand("POMilestoneList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PoId", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
                if (rdr.IsNull("LastUpdatedDate"))
                    dt3 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate"].ToString(), out dt3) == false)
                        dt3 = DateTime.MinValue;
                }
                if (rdr.IsNull("EffectiveStartDate"))
                    startdate = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["EffectiveStartDate"].ToString(), out startdate) == false)
                        startdate = DateTime.MinValue;
                }
                if (rdr.IsNull("EffectiveEndDate"))
                    enddate = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["EffectiveEndDate"].ToString(), out enddate) == false)
                        enddate = DateTime.MinValue;
                }
                mlist.Add(
                    new MilestoneModel
                    {
                        MilestoneId = (int)(rdr["MilestoneId"]),
                        ItemNo = (int)(rdr["ItemNo"]),
                        ItemName = (string)(rdr["ItemName"]),
                        ItemDescription = (string)(rdr["ItemDescription"]),
                        CurrencyId1 = (int)(rdr["CurrencyId1"]),
                        PricePerUnit = (decimal)(rdr["PricePerUnit"]),
                        Quantity = (decimal)(rdr["Quantity"]),
                        Amount = (decimal)(rdr["Amount"]),
                        EffectiveStartDate = startdate,
                        EffectiveEndDate = enddate,
                        StatusId1 = (int)(rdr["StatusId1"]),
                        LastUpdatedBy = (int)(rdr["LastUpdatedBy"]),
                        UserName = rdr["UserName"].ToString(),
                        CurrencyName = rdr["CurrencyName"].ToString(),
                        StatusName = rdr["StatusName"].ToString(),
                        LastUpdatedDate = dt3,


                    });
            }
            return mlist;
        }

        public bool AddMilestone(MilestoneModel milestone)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("POMilestoneAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PoId", milestone.PoId);
            cmd.Parameters.AddWithValue("@ItemNo", milestone.ItemNo);
            cmd.Parameters.AddWithValue("@ItemName", milestone.ItemName);
            cmd.Parameters.AddWithValue("@ItemDescription", milestone.ItemDescription);
            cmd.Parameters.AddWithValue("@CurrencyId1", milestone.CurrencyId1);
            cmd.Parameters.AddWithValue("@PricePerUnit", milestone.PricePerUnit);
            cmd.Parameters.AddWithValue("@Quantity", milestone.Quantity);
            cmd.Parameters.AddWithValue("@Amount", milestone.Amount);
            cmd.Parameters.AddWithValue("@StatusId1", milestone.StatusId1);
            cmd.Parameters.AddWithValue("@EffectiveStartDate", milestone.EffectiveStartDate);
            cmd.Parameters.AddWithValue("@EffectiveEndDate", milestone.EffectiveEndDate);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 3);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;


        }

        public List<MilestoneModel> MilestoneEdit(int id)
        {
            Connection();
            List<MilestoneModel> Mlist = new List<MilestoneModel>();

            SqlCommand cmd = new SqlCommand("select * from POMilestone where MilestoneId=" + id, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
                if (rdr.IsNull("LastUpdatedDate"))
                    dt3 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate"].ToString(), out dt3) == false)
                        dt3 = DateTime.MinValue;
                }
                if (rdr.IsNull("EffectiveStartDate"))
                    startdate = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["EffectiveStartDate"].ToString(), out startdate) == false)
                        startdate = DateTime.MinValue;
                }
                if (rdr.IsNull("EffectiveEndDate"))
                    enddate = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["EffectiveEndDate"].ToString(), out enddate) == false)
                        enddate = DateTime.MinValue;
                }
                Mlist.Add(
                    new MilestoneModel
                    {
                        PoId = (int)(rdr["PoId"]),
                        MilestoneId = (int)(rdr["MilestoneId"]),
                        ItemNo = (int)(rdr["ItemNo"]),
                        ItemName = (string)(rdr["ItemName"]),
                        ItemDescription = (string)(rdr["ItemDescription"]),
                        CurrencyId1 = (int)(rdr["CurrencyId1"]),
                        PricePerUnit = (decimal)(rdr["PricePerUnit"]),
                        Quantity = (decimal)(rdr["Quantity"]),
                        Amount = (decimal)(rdr["Amount"]),
                        EffectiveStartDate = startdate,
                        EffectiveEndDate = enddate,
                        StatusId1 = (int)(rdr["StatusId1"]),
                        LastUpdatedBy = (int)(rdr["LastUpdatedBy"]),
                        LastUpdatedDate = dt3,


                    });
            }
            return Mlist;
        }

        public bool UpdateMilestone(MilestoneModel milestone)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("POMilestoneUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MilestoneId", milestone.MilestoneId);
            cmd.Parameters.AddWithValue("@ItemNo", milestone.ItemNo);
            cmd.Parameters.AddWithValue("@ItemName", milestone.ItemName);
            cmd.Parameters.AddWithValue("@ItemDescription", milestone.ItemDescription);
            cmd.Parameters.AddWithValue("@CurrencyId1", milestone.CurrencyId1);
            cmd.Parameters.AddWithValue("@PricePerUnit", milestone.PricePerUnit);
            cmd.Parameters.AddWithValue("@Quantity", milestone.Quantity);
            cmd.Parameters.AddWithValue("@Amount", milestone.Amount);
            cmd.Parameters.AddWithValue("@StatusId1", milestone.StatusId1);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 4);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);
            cmd.Parameters.AddWithValue("@EffectiveStartDate", milestone.EffectiveStartDate);
            cmd.Parameters.AddWithValue("@EffectiveEndDate", milestone.EffectiveEndDate);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool DeleteMilestone(int milestone)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("POMilestoneDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MilestoneId", milestone);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        //---------------PO Managed Services------------------//
        public List<POManagedServiceModel> RateCard()
        {
            Connection();
            List<POManagedServiceModel> elist = new List<POManagedServiceModel>();

            SqlCommand cmd = new SqlCommand("Select * from QryRateCard", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            elist.Add(
                  new POManagedServiceModel
                  {
                      RateCardId = 0,
                      RateCardName = "-----Select-----",
                  });

            foreach (DataRow rdr in dt.Rows)
            {
                elist.Add(
                    new POManagedServiceModel
                    {
                        RateCardId = (int)(rdr["RateCardId"]),
                        RateCardName = (string)(rdr["RateCardName"]),

                    });
            }
            return elist;
        }
        public List<POManagedServiceModel> POManagedList(int id)
        {
            Connection();
            List<POManagedServiceModel> PoManagedlist = new List<POManagedServiceModel>();

            SqlCommand cmd = new SqlCommand("POManagedServiceList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PoId", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
                if (rdr.IsNull("LastUpdatedDate"))
                    LastUpdatedDate2 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate"].ToString(), out LastUpdatedDate2) == false)
                        LastUpdatedDate2 = DateTime.MinValue;
                }
                if (rdr.IsNull("AssignmentStartDate"))
                    AssignmentStartDate = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["AssignmentStartDate"].ToString(), out AssignmentStartDate) == false)
                        AssignmentStartDate = DateTime.MinValue;
                }
                if (rdr.IsNull("AssignmentEndDate"))
                    AssignmentEndDate = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["AssignmentEndDate"].ToString(), out AssignmentEndDate) == false)
                        AssignmentEndDate = DateTime.MinValue;
                }
                PoManagedlist.Add(
                    new POManagedServiceModel
                    {
                        PoEmployeeId = (int)(rdr["PoEmployeeId"]),
                        ClientId2 = (int)(rdr["ClientId2"]),
                        ProjectId2 = (int)(rdr["ProjectId2"]),
                        EmployeeId2 = (int)(rdr["EmployeeId2"]),
                        AssignmentStartDate = AssignmentStartDate,
                        AssignmentEndDate = AssignmentEndDate,
                        Remarks2 = (string)(rdr["Remarks2"]),
                        PoRate = (decimal)(rdr["PoRate"]),
                        CurrencyId2 = (int)(rdr["CurrencyId2"]),
                        RateCardId = (int)(rdr["RateCardId"]),
                        LastUpdatedBy = (int)(rdr["LastUpdatedBy"]),
                        ClientName = rdr["ClientName"].ToString(),
                        ProjectName = rdr["ProjectName"].ToString(),
                        EmployeeName = rdr["EmployeeName"].ToString(),
                        UserName = rdr["UserName"].ToString(),
                        CurrencyName = rdr["CurrencyName"].ToString(),
                        RateCardName = rdr["RateCardName"].ToString(),
                        LastUpdatedDate = LastUpdatedDate2,


                    });
            }
            return PoManagedlist;
        }
        public bool AddPOManaged(POManagedServiceModel POM)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("POManagedServiceAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PoId", POM.PoId);
            cmd.Parameters.AddWithValue("@EmployeeId2", POM.EmployeeId2);
            cmd.Parameters.AddWithValue("@AssignmentStartDate", POM.AssignmentStartDate);
            cmd.Parameters.AddWithValue("@AssignmentEndDate", POM.AssignmentEndDate);
            cmd.Parameters.AddWithValue("@RateCardId", POM.RateCardId);
            cmd.Parameters.AddWithValue("@CurrencyId2", POM.CurrencyId2);
            cmd.Parameters.AddWithValue("@PoRate", POM.PoRate);
            cmd.Parameters.AddWithValue("@Remarks2", POM.Remarks2);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 3);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;


        }
        public List<POManagedServiceModel> POManagedEdit(int id)
        {
            Connection();
            List<POManagedServiceModel> Mlist = new List<POManagedServiceModel>();

            SqlCommand cmd = new SqlCommand("select * from POManagedService where PoEmployeeId=" + id, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
                if (rdr.IsNull("LastUpdatedDate"))
                    LastUpdatedDate2 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["LastUpdatedDate"].ToString(), out LastUpdatedDate2) == false)
                        LastUpdatedDate2 = DateTime.MinValue;
                }
                if (rdr.IsNull("AssignmentStartDate"))
                    AssignmentStartDate = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["AssignmentStartDate"].ToString(), out AssignmentStartDate) == false)
                        AssignmentStartDate = DateTime.MinValue;
                }
                if (rdr.IsNull("AssignmentEndDate"))
                    AssignmentEndDate = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["AssignmentEndDate"].ToString(), out AssignmentEndDate) == false)
                        AssignmentEndDate = DateTime.MinValue;
                }
                Mlist.Add(
                    new POManagedServiceModel
                    {
                        PoId = (int)(rdr["PoId"]),
                        PoEmployeeId = (int)(rdr["PoEmployeeId"]),
                        ClientId2 = (int)(rdr["ClientId2"]),
                        ProjectId2 = (int)(rdr["ProjectId2"]),
                        EmployeeId2 = (int)(rdr["EmployeeId2"]),
                        RateCardId = (int)(rdr["RateCardId"]),
                        CurrencyId2 = (int)(rdr["CurrencyId2"]),
                        PoRate = (decimal)(rdr["PoRate"]),
                        Remarks2 = (string)(rdr["Remarks2"]),
                        AssignmentStartDate = AssignmentStartDate,
                        AssignmentEndDate = AssignmentEndDate,
                        LastUpdatedBy = (int)(rdr["LastUpdatedBy"]),
                        LastUpdatedDate = LastUpdatedDate2,


                    });
            }
            return Mlist;
        }
        public bool UpdatePOManaged(POManagedServiceModel POM)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("POManagedServiceUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PoEmployeeId", POM.PoEmployeeId);
            cmd.Parameters.AddWithValue("@RateCardId", POM.RateCardId);
            cmd.Parameters.AddWithValue("@CurrencyId2", POM.CurrencyId2);
            cmd.Parameters.AddWithValue("@PoRate", POM.PoRate);
            cmd.Parameters.AddWithValue("@Remarks2", POM.Remarks2);
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 4);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);
            cmd.Parameters.AddWithValue("@AssignmentStartDate", POM.AssignmentStartDate);
            cmd.Parameters.AddWithValue("@AssignmentEndDate", POM.AssignmentEndDate);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool DeletePOManaged(int POM)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("POManagedServiceDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PoEmployeeId", POM);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        //---------------EmployeeMAster ------------------//
        public List<EmployeeMasterModel> GetActiveEmployeesList()
        {
            Connection();
            List<EmployeeMasterModel> Emlist = new List<EmployeeMasterModel>();

            SqlCommand cmd = new SqlCommand("GetActiveEmployeesList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr.IsNull("DOJ"))
                    DOJ = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(dr["DOJ"].ToString(), out DOJ) == false)
                        DOJ = DateTime.MinValue;
                }

                if (dr.IsNull("DOL"))
                    DOL = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(dr["DOL"].ToString(), out DOL) == false)
                        DOL = DateTime.MinValue;
                }

                Emlist.Add(
                new EmployeeMasterModel
                {
                    EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                    EmployeeName = Convert.ToString(dr["EmployeeName"]),
                    DOJ = DOJ,
                    DOL = DOL,
                    ClientName = Convert.ToString(dr["ClientName"]),
                    ProjectName = Convert.ToString(dr["ProjectName"]),
                    Department = Convert.ToString(dr["Department"]),
                    Designation = Convert.ToString(dr["Designation"]),



                });

            }
            return Emlist;

        }
      
    }
}