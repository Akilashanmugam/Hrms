using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HrmsWeb.Models;
using Hrmsweb.Models;

namespace HrmsWeb.Controllers
{
    public class InvoiceDBHandle
    {
        private SqlConnection con;
       
        private DateTime PoDate;
        private DateTime AssignmentStartDate;
        private DateTime AssignmentEndDate;
        string Skills;

        private void Connection()

        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);

        }
        public List<InvoiceModel> List(InvoiceModel IDB)
        {
            Connection();
            List<InvoiceModel> Ilist = new List<InvoiceModel>();

            SqlCommand cmd = new SqlCommand("InvoiceList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientId", IDB.SrClientId);
            cmd.Parameters.AddWithValue("@ProjectId", IDB.SrProjectId);
            cmd.Parameters.AddWithValue("@InvoiceType", IDB.SrInvoiceType);
            cmd.Parameters.AddWithValue("@LocationId", IDB.SrLocationId);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
                DateTime stdt = rdr.IsNull("InvoiceDate") ? DateTime.MinValue : DateTime.Parse(rdr["InvoiceDate"].ToString());
                DateTime endt = rdr.IsNull("SubmitDate") ? DateTime.MinValue : DateTime.Parse(rdr["SubmitDate"].ToString());
                DateTime ldate = rdr.IsNull("BillingMonth") ? DateTime.MinValue : DateTime.Parse(rdr["BillingMonth"].ToString());
                DateTime ApproveDate = rdr.IsNull("ApproveDate") ? DateTime.MinValue : DateTime.Parse(rdr["ApproveDate"].ToString());
                DateTime LastUpdatedDate = rdr.IsNull("LastUpdatedDate") ? DateTime.MinValue : DateTime.Parse(rdr["LastUpdatedDate"].ToString());

                string PrInvoiceNo = rdr.IsNull("PrInvoiceNo") ? "" : rdr["PrInvoiceNo"].ToString();
                string Remarks = rdr.IsNull("Remarks") ? "" : rdr["Remarks"].ToString();
                string KindAttn = rdr.IsNull("KindAttn") ? "" : rdr["KindAttn"].ToString();
                string UserName = rdr["UserName"].ToString();
                string StatusName = rdr["StatusName"].ToString();
                string ClientName = rdr["ClientName"].ToString();
                string ProjectName = rdr["ProjectName"].ToString();
                string LocationName = rdr["LocationName"].ToString();
                string PoTypeName = rdr["PoTypeName"].ToString();
                string BillingAddressName = rdr["BillingAddressName"].ToString();
                string ShippingAddressName = rdr["ShippingAddressName"].ToString();

                int InvoiceId = Convert.ToInt32(rdr["InvoiceId"]);
                int ProjectId = Convert.ToInt32(rdr["ProjectId"]);
                int LocationId = Convert.ToInt32(rdr["LocationId"]);
                int LastUpdatedBy = Convert.ToInt32(rdr["LastUpdatedBy"]);

                decimal Amount = rdr.IsNull("Amount") ? 0 : Convert.ToDecimal(rdr["Amount"]);
                decimal Discount = rdr.IsNull("Discount") ? 0 : Convert.ToDecimal(rdr["Discount"]);
                decimal TotalAmount = rdr.IsNull("TotalAmount") ? 0 : Convert.ToDecimal(rdr["TotalAmount"]);
                decimal TaxAmount = rdr.IsNull("TaxAmount") ? 0 : Convert.ToDecimal(rdr["TaxAmount"]);
                decimal NetAmount = rdr.IsNull("NetAmount") ? 0 : Convert.ToDecimal(rdr["NetAmount"]);

                int ShippingAddress = rdr.IsNull("ShippingAddress") ? 0 : Convert.ToInt32(rdr["ShippingAddress"]);
                int BillingAddress = rdr.IsNull("BillingAddress") ? 0 : Convert.ToInt32(rdr["BillingAddress"]);
                int StatusId = rdr.IsNull("StatusId") ? 0 : Convert.ToInt32(rdr["StatusId"]);

                Ilist.Add(new InvoiceModel
                {
                    InvoiceId = InvoiceId,
                    InvoiceNo = rdr["InvoiceNo"].ToString(),
                    InvoiceDate = stdt,
                    PrInvoiceNo = PrInvoiceNo,
                    BillingMonth = ldate,
                    ClientId = (int)(rdr["ClientId"]),
                    ProjectId = ProjectId,
                    InvoiceType = (int)(rdr["InvoiceType"]),
                    LocationId = LocationId,
                    Remarks = Remarks,
                    KindAttn = KindAttn,
                    Amount = Amount,
                    Discount = Discount,
                    TotalAmount = TotalAmount,
                    TaxAmount = TaxAmount,
                    NetAmount = NetAmount,
                    SubmitDate = endt,
                    ApproveDate = ApproveDate,
                    ShippingAddress = ShippingAddress,
                    BillingAddress = BillingAddress,
                    StatusId = StatusId,
                    LastUpdatedBy = LastUpdatedBy,
                    LastUpdatedDate = LastUpdatedDate,
                    UserName = UserName,
                    StatusName = StatusName,
                    ClientName = ClientName,
                    ProjectName = ProjectName,
                    LocationName = LocationName,
                    PoTypeName = PoTypeName,
                    BillingAddressName = BillingAddressName,
                    ShippingAddressName = ShippingAddressName
                });
            }
            return Ilist;
        }

        public List<InvoiceModel> ListGetById(int id)
        {
            Connection();
            List<InvoiceModel> Ilist = new List<InvoiceModel>();

            SqlCommand cmd = new SqlCommand("select * from QryInvoice where InvoiceId=" + id, con);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
                DateTime stdt = rdr.IsNull("InvoiceDate") ? DateTime.MinValue : DateTime.Parse(rdr["InvoiceDate"].ToString());
                DateTime endt = rdr.IsNull("SubmitDate") ? DateTime.MinValue : DateTime.Parse(rdr["SubmitDate"].ToString());
                DateTime ldate = rdr.IsNull("BillingMonth") ? DateTime.MinValue : DateTime.Parse(rdr["BillingMonth"].ToString());
                DateTime ApproveDate = rdr.IsNull("ApproveDate") ? DateTime.MinValue : DateTime.Parse(rdr["ApproveDate"].ToString());
                DateTime LastUpdatedDate = rdr.IsNull("LastUpdatedDate") ? DateTime.MinValue : DateTime.Parse(rdr["LastUpdatedDate"].ToString());

                string PrInvoiceNo = rdr.IsNull("PrInvoiceNo") ? "" : rdr["PrInvoiceNo"].ToString();
                string Remarks = rdr.IsNull("Remarks") ? "" : rdr["Remarks"].ToString();
                string KindAttn = rdr.IsNull("KindAttn") ? "" : rdr["KindAttn"].ToString();
                string UserName = rdr["UserName"].ToString();
                string StatusName = rdr["StatusName"].ToString();
                string ClientName = rdr["ClientName"].ToString();
                string ProjectName = rdr["ProjectName"].ToString();
                string LocationName = rdr["LocationName"].ToString();
                string PoTypeName = rdr["PoTypeName"].ToString();
                string BillingAddressName = rdr["BillingAddressName"].ToString();
                string ShippingAddressName = rdr["ShippingAddressName"].ToString();

                int InvoiceId = Convert.ToInt32(rdr["InvoiceId"]);
                int ProjectId = Convert.ToInt32(rdr["ProjectId"]);
                int LocationId = Convert.ToInt32(rdr["LocationId"]);
                int LastUpdatedBy = Convert.ToInt32(rdr["LastUpdatedBy"]);

                decimal Amount = rdr.IsNull("Amount") ? 0 : Convert.ToDecimal(rdr["Amount"]);
                decimal Discount = rdr.IsNull("Discount") ? 0 : Convert.ToDecimal(rdr["Discount"]);
                decimal TotalAmount = rdr.IsNull("TotalAmount") ? 0 : Convert.ToDecimal(rdr["TotalAmount"]);
                decimal TaxAmount = rdr.IsNull("TaxAmount") ? 0 : Convert.ToDecimal(rdr["TaxAmount"]);
                decimal NetAmount = rdr.IsNull("NetAmount") ? 0 : Convert.ToDecimal(rdr["NetAmount"]);

                int ShippingAddress = rdr.IsNull("ShippingAddress") ? 0 : Convert.ToInt32(rdr["ShippingAddress"]);
                int BillingAddress = rdr.IsNull("BillingAddress") ? 0 : Convert.ToInt32(rdr["BillingAddress"]);
                int StatusId = rdr.IsNull("StatusId") ? 0 : Convert.ToInt32(rdr["StatusId"]);

                Ilist.Add(new InvoiceModel
                {
                    InvoiceId = InvoiceId,
                    InvoiceNo = rdr["InvoiceNo"].ToString(),
                    InvoiceDate = stdt,
                    PrInvoiceNo = PrInvoiceNo,
                    BillingMonth = ldate,
                    ClientId = (int)(rdr["ClientId"]),
                    ProjectId = ProjectId,
                    InvoiceType =(int)(rdr["InvoiceType"]),
                    LocationId = LocationId,
                    Remarks = Remarks,
                    KindAttn = KindAttn,
                    Amount = Amount,
                    Discount = Discount,
                    TotalAmount = TotalAmount,
                    TaxAmount = TaxAmount,
                    NetAmount = NetAmount,
                    SubmitDate = endt,
                    ApproveDate = ApproveDate,
                    ShippingAddress = ShippingAddress,
                    BillingAddress = BillingAddress,
                    StatusId = StatusId,
                    LastUpdatedBy = LastUpdatedBy,
                    LastUpdatedDate = LastUpdatedDate,
                    UserName = UserName,
                    StatusName = StatusName,
                    ClientName = ClientName,
                    ProjectName = ProjectName,
                    LocationName = LocationName,
                    PoTypeName = PoTypeName,
                    BillingAddressName = BillingAddressName,
                    ShippingAddressName = ShippingAddressName
                });
            }
            return Ilist;
        }

        public bool Add(InvoiceModel IDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("InvoiceAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InvoiceNo", IDB.InvoiceNo);
            cmd.Parameters.AddWithValue("@ClientId", IDB.ClientId);
            cmd.Parameters.AddWithValue("@InvoiceType", IDB.InvoiceType);
            if (IDB.PrInvoiceNo == null)
            {
                cmd.Parameters.AddWithValue("@PrInvoiceNo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PrInvoiceNo", IDB.PrInvoiceNo);
            }
            if (IDB.ProjectId == null)
            {
                cmd.Parameters.AddWithValue("@ProjectId", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ProjectId", IDB.ProjectId);
            }
            if (IDB.LocationId == null)
            {
                cmd.Parameters.AddWithValue("@LocationId", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@LocationId", IDB.LocationId);
            }
            if (IDB.Remarks == null)
            {
                cmd.Parameters.AddWithValue("@Remarks", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Remarks", IDB.Remarks);
            }
            if (IDB.KindAttn == null)
            {
                cmd.Parameters.AddWithValue("@KindAttn", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@KindAttn", IDB.KindAttn);
            }
            if (IDB.Amount == null)
            {
                cmd.Parameters.AddWithValue("@Amount", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Amount", IDB.Amount);
            }
            if (IDB.Discount == null)
            {
                cmd.Parameters.AddWithValue("@Discount", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Discount", IDB.Discount);
            }
            if (IDB.TotalAmount == null)
            {
                cmd.Parameters.AddWithValue("@TotalAmount", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@TotalAmount", IDB.TotalAmount);
            }
            if (IDB.TaxAmount == null)
            {
                cmd.Parameters.AddWithValue("@TaxAmount", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@TaxAmount", IDB.TaxAmount);
            }
            if (IDB.NetAmount == null)
            {
                cmd.Parameters.AddWithValue("@NetAmount", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@NetAmount", IDB.NetAmount);
            }
            if (IDB.ShippingAddress == null)
            {
                cmd.Parameters.AddWithValue("@ShippingAddress", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ShippingAddress", IDB.ShippingAddress);
            }
            if (IDB.BillingAddress == null)
            {
                cmd.Parameters.AddWithValue("@BillingAddress", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@BillingAddress", IDB.BillingAddress);
            }
            if (IDB.StatusId == null)
            {
                cmd.Parameters.AddWithValue("@StatusId", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@StatusId", IDB.StatusId);
            }
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 1);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);

            if (IDB.InvoiceDate == null)
            {
                cmd.Parameters.AddWithValue("@InvoiceDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@InvoiceDate", IDB.InvoiceDate);
            }

            if (IDB.BillingMonth == null)
            {
                cmd.Parameters.AddWithValue("@BillingMonth", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@BillingMonth", IDB.BillingMonth);
            }

            if (IDB.SubmitDate == null)
            {
                cmd.Parameters.AddWithValue("@SubmitDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@SubmitDate", IDB.SubmitDate);
            }

            if (IDB.ApproveDate == null)
            {
                cmd.Parameters.AddWithValue("@ApproveDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ApproveDate", IDB.ApproveDate);
            }
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update(InvoiceModel IDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("InvoiceUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InvoiceId", IDB.InvoiceId);
            cmd.Parameters.AddWithValue("@InvoiceNo", IDB.InvoiceNo);
            cmd.Parameters.AddWithValue("@ClientId", IDB.ClientId);
            cmd.Parameters.AddWithValue("@InvoiceType", IDB.InvoiceType);
            if (IDB.PrInvoiceNo == null)
            {
                cmd.Parameters.AddWithValue("@PrInvoiceNo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PrInvoiceNo", IDB.PrInvoiceNo);
            }
            if (IDB.ProjectId == null)
            {
                cmd.Parameters.AddWithValue("@ProjectId", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ProjectId", IDB.ProjectId);
            }
            if (IDB.LocationId == null)
            {
                cmd.Parameters.AddWithValue("@LocationId", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@LocationId", IDB.LocationId);
            }
            if (IDB.Remarks == null)
            {
                cmd.Parameters.AddWithValue("@Remarks", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Remarks", IDB.Remarks);
            }
            if (IDB.KindAttn == null)
            {
                cmd.Parameters.AddWithValue("@KindAttn", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@KindAttn", IDB.KindAttn);
            }
            if (IDB.Amount == null)
            {
                cmd.Parameters.AddWithValue("@Amount", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Amount", IDB.Amount);
            }
            if (IDB.Discount == null)
            {
                cmd.Parameters.AddWithValue("@Discount", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Discount", IDB.Discount);
            }
            if (IDB.TotalAmount == null)
            {
                cmd.Parameters.AddWithValue("@TotalAmount", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@TotalAmount", IDB.TotalAmount);
            }
            if (IDB.TaxAmount == null)
            {
                cmd.Parameters.AddWithValue("@TaxAmount", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@TaxAmount", IDB.TaxAmount);
            }
            if (IDB.NetAmount == null)
            {
                cmd.Parameters.AddWithValue("@NetAmount", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@NetAmount", IDB.NetAmount);
            }
            if (IDB.ShippingAddress == null)
            {
                cmd.Parameters.AddWithValue("@ShippingAddress", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ShippingAddress", IDB.ShippingAddress);
            }
            if (IDB.BillingAddress == null)
            {
                cmd.Parameters.AddWithValue("@BillingAddress", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@BillingAddress", IDB.BillingAddress);
            }
            if (IDB.StatusId == null)
            {
                cmd.Parameters.AddWithValue("@StatusId", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@StatusId", IDB.StatusId);
            }
            cmd.Parameters.AddWithValue("@LastUpdatedBy", 3);
            cmd.Parameters.AddWithValue("@LastUpdatedDate", DateTime.Today);

            if (IDB.InvoiceDate == null)
            {
                cmd.Parameters.AddWithValue("@InvoiceDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@InvoiceDate", IDB.InvoiceDate);
            }

            if (IDB.BillingMonth == null)
            {
                cmd.Parameters.AddWithValue("@BillingMonth", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@BillingMonth", IDB.BillingMonth);
            }

            if (IDB.SubmitDate == null)
            {
                cmd.Parameters.AddWithValue("@SubmitDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@SubmitDate", IDB.SubmitDate);
            }

            if (IDB.ApproveDate == null)
            {
                cmd.Parameters.AddWithValue("@ApproveDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ApproveDate", IDB.ApproveDate);
            }
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Delete(int InvoiceId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("InvoiceDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InvoiceId", InvoiceId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }
        //------------dropdowns ----------------------//
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
        public List<ProjectModel> Project()
        {
            Connection();
            List<ProjectModel> elist = new List<ProjectModel>();

            SqlCommand cmd = new SqlCommand("Select * from Project", con);
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
        public List<POManagementModel> billingAddress()
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

        public List<POManagementModel> shippingAddress()
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

        public List<VendorModel> Status()
        {
            Connection();
            List<VendorModel> elist = new List<VendorModel>();

            SqlCommand cmd = new SqlCommand("Select * from Status", con);
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

        //-------Invoice Milestone-----------------//

        public List<InvoiceMilestoneModel> InvoiceMilestoneList()
        {
            Connection();
            List<InvoiceMilestoneModel> IMlist = new List<InvoiceMilestoneModel>();

            SqlCommand cmd = new SqlCommand("InvoiceMilestonesList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {


                IMlist.Add(
                new InvoiceMilestoneModel
                {
                    MilestoneId = Convert.ToInt32(rdr["MilestoneId"]),
                    PoId = Convert.ToInt32(rdr["PoId"]),
                    PoValue = Convert.ToDecimal(rdr["PoValue"]),
                    ItemDescription = rdr["ItemDescription"].ToString(),
                    ItemName = rdr["ItemName"].ToString(),
                    ItemNo = Convert.ToInt32(rdr["ItemNo"]),
                    PoName = rdr["PoName"].ToString(),
                    PoCode = rdr["PoCode"].ToString(),


                });

            }
            return IMlist;

        }
        public List<InvoiceMilestoneModel> InvoiceMilestoneItemList(int id)
        {
            Connection();
            List<InvoiceMilestoneModel> mlist = new List<InvoiceMilestoneModel>();

            SqlCommand cmd = new SqlCommand("InvoiceMilestoneItemList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InvoiceId", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {

                mlist.Add(
                    new InvoiceMilestoneModel
                    {
                        InvoiceMilestoneItemId = (int)(rdr["InvoiceMilestoneItemId"]),
                        MilestoneId = (int)(rdr["MilestoneId"]),
                        PoId = (int)(rdr["PoId"]),
                        PoCode = (string)(rdr["PoCode"]),
                        PoName = (string)(rdr["PoName"]),
                        ItemNo = (int)(rdr["ItemNo"]),
                        ItemName = (string)(rdr["ItemName"]),
                        ItemDescription = (string)(rdr["ItemDescription"]),
                        BalanceQuantity = (decimal)(rdr["BalanceQuantity"]),
                        Price = (decimal)(rdr["Price"]),
                        Amount1 = (decimal)(rdr["Amount1"]),



                    });
            }
            return mlist;
        }

        public void AddInvoiceMilestoneItem(InvoiceMilestoneModel item)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("InvoiceMilestoneItemAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PoId", item.PoId);
            cmd.Parameters.AddWithValue("@PoCode", item.PoCode);
            cmd.Parameters.AddWithValue("@PoName", item.PoName);
            cmd.Parameters.AddWithValue("@MilestoneId", item.MilestoneId);
            cmd.Parameters.AddWithValue("@ItemNo", item.ItemNo);
            cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
            cmd.Parameters.AddWithValue("@ItemDescription", item.ItemDescription);
            cmd.Parameters.AddWithValue("@BalanceQuantity", item.BalanceQuantity);
            cmd.Parameters.AddWithValue("@Price", item.Price);
            cmd.Parameters.AddWithValue("@Amount1", item.Amount1);
            cmd.Parameters.AddWithValue("@InvoiceId", item.InvoiceId);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public bool DeleteMilestoneItem(int milestone)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("InvoiceMilestoneItemDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InvoiceMilestoneItemId", milestone);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<InvoiceMilestoneModel> InvoiceMilestoneEdit(int id)
        {
            Connection();
            List<InvoiceMilestoneModel> Mlist = new List<InvoiceMilestoneModel>();

            SqlCommand cmd = new SqlCommand("select * from InvoiceMilestoneItem where InvoiceMilestoneItemId=" + id, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {

                Mlist.Add(
                    new InvoiceMilestoneModel
                    {
                        InvoiceId = (int)(rdr["InvoiceId"]),
                        InvoiceMilestoneItemId = (int)(rdr["InvoiceMilestoneItemId"]),
                        PoId = (int)(rdr["PoId"]),
                        MilestoneId = (int)(rdr["MilestoneId"]),
                        ItemNo = (int)(rdr["ItemNo"]),
                        ItemName = (string)(rdr["ItemName"]),
                        ItemDescription = (string)(rdr["ItemDescription"]),
                        PoCode = (string)(rdr["PoCode"]),
                        PoName = (string)(rdr["PoName"]),
                        BalanceQuantity = (decimal)(rdr["BalanceQuantity"]),
                        Price = (decimal)(rdr["Price"]),
                        Amount1 = (decimal)(rdr["Amount1"]),

                    });
            }
            return Mlist;
        }

        public bool UpdateInvoiceMilestone(InvoiceMilestoneModel milestone)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("InvoiceMilestoneItemUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InvoiceMilestoneItemId", milestone.InvoiceMilestoneItemId);
            cmd.Parameters.AddWithValue("@PoId", milestone.PoId);
            cmd.Parameters.AddWithValue("@PoCode", milestone.PoCode);
            cmd.Parameters.AddWithValue("@PoName", milestone.PoName);
            cmd.Parameters.AddWithValue("@MilestoneId", milestone.MilestoneId);
            cmd.Parameters.AddWithValue("@ItemNo", milestone.ItemNo);
            cmd.Parameters.AddWithValue("@ItemName", milestone.ItemName);
            cmd.Parameters.AddWithValue("@ItemDescription", milestone.ItemDescription);
            cmd.Parameters.AddWithValue("@BalanceQuantity", milestone.BalanceQuantity);
            cmd.Parameters.AddWithValue("@Price", milestone.Price);
            cmd.Parameters.AddWithValue("@Amount1", milestone.Amount1);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //-------Invoice placement-----------------//

        public List<InvoicePlacementModel> InvoicePlacementList()
        {
            Connection();
            List<InvoicePlacementModel> IMlist = new List<InvoicePlacementModel>();

            SqlCommand cmd = new SqlCommand("InvoicePlacementList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
               

                IMlist.Add(
                new InvoicePlacementModel
                {
                    InvoicePlacementId = Convert.ToInt32(rdr["InvoicePlacementId"]),
                    PoId = Convert.ToInt32(rdr["PoId"]),
                    PoCode = Convert.ToString(rdr["PoCode"]),
                    PEId = Convert.ToInt32(rdr["PEId"]),
                    MonthlyCTC = Convert.ToDecimal(rdr["MonthlyCTC"]),
                    PlacementCalculationTypeId = Convert.ToInt32(rdr["PlacementCalculationTypeId"]),
                    CurrencyId = Convert.ToInt32(rdr["CurrencyId"]),
                    CalculationValue = Convert.ToDecimal(rdr["CalculationValue"]),
                    BillingAmount = Convert.ToDecimal(rdr["BillingAmount"]),


                });

            }
            return IMlist;

        }

        public List<InvoicePlacementModel> InvoicePlacementItemList(int id)
        {
            Connection();
            List<InvoicePlacementModel> mlist = new List<InvoicePlacementModel>();

            SqlCommand cmd = new SqlCommand("InvoicePlacementItemList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InvoiceId", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
                if (rdr.IsNull("PoDate"))
                    PoDate = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["PoDate"].ToString(), out PoDate) == false)
                        PoDate = DateTime.MinValue;
                }

              

                if (rdr.IsNull("Skills"))
                {
                    Skills = null; 
                }
                else
                {
                    Skills = rdr["Skills"].ToString();
                }

                mlist.Add(
                    new InvoicePlacementModel
                    {
                        InvoicePlacementItemId = (int)(rdr["InvoicePlacementItemId"]),
                        PEId = (int)(rdr["PEId"]),
                        PoId = (int)(rdr["PoId"]),
                        PoCode = (string)(rdr["PoCode"]),
                        EmployeeId = (int)(rdr["EmployeeId"]),
                        Skills = Skills,
                        PlacementCalculationTypeId = (int)(rdr["PlacementCalculationTypeId"]),
                        CalculationValue = (decimal)(rdr["CalculationValue"]),
                        MonthlyCTC = (decimal)(rdr["MonthlyCTC"]),
                        BillingAmount = (decimal)(rdr["BillingAmount"]),
                        CurrencyId = (int)(rdr["CurrencyId"]),
                        PoDate = PoDate,
                        EmployeeName = rdr["EmployeeName"].ToString(),
                        PlacementCalculationType = rdr["PlacementCalculationType"].ToString(),
                        CurrencyName = rdr["CurrencyName"].ToString(),

                    });
            }
            return mlist;
        }

        public void AddInvoicePlacementItem(InvoicePlacementModel item)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("InvoicePlacementItemAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PoId", item.PoId);
            cmd.Parameters.AddWithValue("@PoCode", item.PoCode);
            cmd.Parameters.AddWithValue("@PEId", item.PEId);
            cmd.Parameters.AddWithValue("@MonthlyCTC", item.MonthlyCTC);
            cmd.Parameters.AddWithValue("@PlacementCalculationTypeId", item.PlacementCalculationTypeId);
            cmd.Parameters.AddWithValue("@CalculationValue", item.CalculationValue);
            cmd.Parameters.AddWithValue("@BillingAmount", item.BillingAmount);
            cmd.Parameters.AddWithValue("@EmployeeId", item.EmployeeId);
            cmd.Parameters.AddWithValue("@CurrencyId", item.CurrencyId);
            cmd.Parameters.AddWithValue("@InvoiceId", item.InvoiceId);
            if (item.PoDate == null)
            {
                cmd.Parameters.AddWithValue("@PoDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PoDate", item.PoDate);
            }
            if (item.Skills == null)
            {
                cmd.Parameters.AddWithValue("@Skills", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Skills", item.Skills);
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<InvoicePlacementModel> InvoicePlacementEdit(int id)
        {
            Connection();
            List<InvoicePlacementModel> Mlist = new List<InvoicePlacementModel>();

            SqlCommand cmd = new SqlCommand("select * from InvoicePlacementItem where InvoicePlacementItemId=" + id, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
                if (rdr.IsNull("PoDate"))
                    PoDate = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["PoDate"].ToString(), out PoDate) == false)
                        PoDate = DateTime.MinValue;
                }



                if (rdr.IsNull("Skills"))
                {
                    Skills = null;
                }
                else
                {
                    Skills = rdr["Skills"].ToString();
                }

                Mlist.Add(
                    new InvoicePlacementModel
                    {
                        InvoicePlacementItemId = (int)(rdr["InvoicePlacementItemId"]),
                        PEId = (int)(rdr["PEId"]),
                        PoId = (int)(rdr["PoId"]),
                        PoCode = (string)(rdr["PoCode"]),
                        EmployeeId = (int)(rdr["EmployeeId"]),
                        Skills = Skills,
                        PlacementCalculationTypeId = (int)(rdr["PlacementCalculationTypeId"]),
                        CalculationValue = (decimal)(rdr["CalculationValue"]),
                        MonthlyCTC = (decimal)(rdr["MonthlyCTC"]),
                        BillingAmount = (decimal)(rdr["BillingAmount"]),
                        CurrencyId = (int)(rdr["CurrencyId"]),
                        PoDate = PoDate,

                    });
            }
            return Mlist;
        }

        public bool UpdateInvoicePlacement(InvoicePlacementModel item)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("InvoicePlacementItemUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InvoicePlacementItemId", item.InvoicePlacementItemId);
            cmd.Parameters.AddWithValue("@PoId", item.PoId);
            cmd.Parameters.AddWithValue("@PoCode", item.PoCode);
            cmd.Parameters.AddWithValue("@PEId", item.PEId);
            cmd.Parameters.AddWithValue("@MonthlyCTC", item.MonthlyCTC);
            cmd.Parameters.AddWithValue("@PlacementCalculationTypeId", item.PlacementCalculationTypeId);
            cmd.Parameters.AddWithValue("@CalculationValue", item.CalculationValue);
            cmd.Parameters.AddWithValue("@BillingAmount", item.BillingAmount);
            cmd.Parameters.AddWithValue("@EmployeeId", item.EmployeeId);
            cmd.Parameters.AddWithValue("@CurrencyId", item.CurrencyId);
            if (item.PoDate == null)
            {
                cmd.Parameters.AddWithValue("@PoDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PoDate", item.PoDate);
            }
            if (item.Skills == null)
            {
                cmd.Parameters.AddWithValue("@Skills", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Skills", item.Skills);
            }
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool DeletePlacementItem(int placement)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("InvoicePlacementItemDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InvoicePlacementItemId", placement);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
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


        //-------Invoice Managed Service-----------------//

        public List<InvoiceManagedServiceModel> InvoiceManagedServiceList()
        {
            Connection();
            List<InvoiceManagedServiceModel> IMlist = new List<InvoiceManagedServiceModel>();

            SqlCommand cmd = new SqlCommand("InvoiceManagedServiceList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
                if (rdr.IsNull("PoDate"))
                    PoDate = DateTime.MinValue;

                else
                {
                    if (DateTime.TryParse(rdr["PoDate"].ToString(), out PoDate) == false)
                        PoDate = DateTime.MinValue;
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


                IMlist.Add(
                new InvoiceManagedServiceModel
                {
                    InvoiceManagedServiceId = Convert.ToInt32(rdr["InvoiceManagedServiceId"]),
                    PoId = Convert.ToInt32(rdr["PoId"]),
                    PoCode = Convert.ToString(rdr["PoCode"]),
                    ProjectId = Convert.ToInt32(rdr["ProjectId"]),
                    PoEmployeeId = Convert.ToInt32(rdr["PoEmployeeId"]),
                    PoDate = PoDate,
                    PoName = Convert.ToInt32(rdr["PoName"]),
                    CurrencyId = Convert.ToInt32(rdr["CurrencyId"]),
                    EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                    AssignmentStartDate = AssignmentStartDate,
                    AssignmentEndDate=AssignmentEndDate,
                    PoRateType = Convert.ToInt32(rdr["PoRateType"]),
                    PoRate = Convert.ToDecimal(rdr["PoRate"]),
                });

            }
            return IMlist;

        }

        public List<InvoiceManagedServiceModel> InvoiceManagedServiceItemList(int id)
        {
            Connection();
            List<InvoiceManagedServiceModel> mlist = new List<InvoiceManagedServiceModel>();

            SqlCommand cmd = new SqlCommand("InvoiceManagedServiceItemList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InvoiceId3", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
                
                mlist.Add(
                    new InvoiceManagedServiceModel
                    {
                        InvoiceManagedServiceItemId = (int)(rdr["InvoiceManagedServiceItemId"]),
                        InvoiceId3 = (int)(rdr["InvoiceId3"]),
                        ProjectId3 = (int)(rdr["ProjectId3"]),
                        PoEmployeeId = (int)(rdr["PoEmployeeId"]),
                        EmployeeId3 = (int)(rdr["EmployeeId3"]),
                        PoRateType = (int)(rdr["PoRateType"]),
                        PoRate = (decimal)(rdr["PoRate"]),
                        BillableDays = (int)(rdr["BillableDays"]),
                        BillableHours = (decimal)(rdr["BillableHours"]),
                        CurrencyId3 = (int)(rdr["CurrencyId3"]),
                        BillableAmount = (decimal)(rdr["BillableAmount"]),
                        EmployeeName = rdr["EmployeeName"].ToString(),
                        ProjectName = rdr["ProjectName"].ToString(),
                        CurrencyName = rdr["CurrencyName"].ToString(),
                        PoRateTypeName = rdr["PoRateTypeName"].ToString(),

                    });
            }
            return mlist;
        }
        public void AddInvoiceManagedServiceItem(InvoiceManagedServiceModel item)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("InvoiceManagedServiceItemAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PoEmployeeId", item.PoEmployeeId);
            cmd.Parameters.AddWithValue("@ProjectId3", item.ProjectId3);
            cmd.Parameters.AddWithValue("@EmployeeId3", item.EmployeeId3);
            cmd.Parameters.AddWithValue("@PoRate", item.PoRate);
            cmd.Parameters.AddWithValue("@PoRateType", item.PoRateType);
            cmd.Parameters.AddWithValue("@BillableDays", item.BillableDays);
            cmd.Parameters.AddWithValue("@BillableHours", item.BillableHours);
            cmd.Parameters.AddWithValue("@InvoiceId3", item.InvoiceId3);
            cmd.Parameters.AddWithValue("@CurrencyId3", item.CurrencyId3);
            cmd.Parameters.AddWithValue("@BillableAmount", item.BillableAmount);
          
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<InvoiceManagedServiceModel> InvoiceManagedServiceEdit(int id)
        {
            Connection();
            List<InvoiceManagedServiceModel> Mlist = new List<InvoiceManagedServiceModel>();

            SqlCommand cmd = new SqlCommand("select * from InvoiceManagedServiceItem where InvoiceManagedServiceItemId=" + id, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
               
               
                Mlist.Add(
                    new InvoiceManagedServiceModel
                    {
                        InvoiceManagedServiceItemId = (int)(rdr["InvoiceManagedServiceItemId"]),
                        ProjectId3 = (int)(rdr["ProjectId3"]),
                        EmployeeId3 = (int)(rdr["EmployeeId3"]),
                        InvoiceId3 = (int)(rdr["InvoiceId3"]),
                        PoRate = (decimal)(rdr["PoRate"]),
                        CurrencyId3 = (int)(rdr["CurrencyId3"]),
                        PoRateType = (int)(rdr["PoRateType"]),
                        BillableDays = (int)(rdr["BillableDays"]),
                        BillableHours = (decimal)(rdr["BillableHours"]),
                        PoEmployeeId = (int)(rdr["PoEmployeeId"]),
                        BillableAmount = (decimal)(rdr["BillableAmount"]),
                    });
            }
            return Mlist;
        }

        public bool UpdateInvoiceManagedService(InvoiceManagedServiceModel item)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("InvoiceManagedServiceItemUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InvoiceManagedServiceItemId", item.InvoiceManagedServiceItemId);
            cmd.Parameters.AddWithValue("@PoEmployeeId", item.PoEmployeeId);
            cmd.Parameters.AddWithValue("@ProjectId3", item.ProjectId3);
            cmd.Parameters.AddWithValue("@EmployeeId3", item.EmployeeId3);
            cmd.Parameters.AddWithValue("@PoRate", item.PoRate);
            cmd.Parameters.AddWithValue("@PoRateType", item.PoRateType);
            cmd.Parameters.AddWithValue("@BillableDays", item.BillableDays);
            cmd.Parameters.AddWithValue("@BillableHours", item.BillableHours);
            cmd.Parameters.AddWithValue("@InvoiceId3", item.InvoiceId3);
            cmd.Parameters.AddWithValue("@CurrencyId3", item.CurrencyId3);
            cmd.Parameters.AddWithValue("@BillableAmount", item.BillableAmount);
           
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool DeleteManagedServiceItem(int ManagedService)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("InvoiceManagedServiceItemDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InvoiceManagedServiceItemId", ManagedService);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<InvoiceManagedServiceModel> PoRateType()
        {
            Connection();
            List<InvoiceManagedServiceModel> elist = new List<InvoiceManagedServiceModel>();

            SqlCommand cmd = new SqlCommand("Select * from RateType", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            elist.Add(
                  new InvoiceManagedServiceModel
                  {
                      PoRateTypeId = 0,
                      PoRateTypeName = "-----Select-----",
                  });

            foreach (DataRow rdr in dt.Rows)
            {
                elist.Add(
                    new InvoiceManagedServiceModel
                    {
                        PoRateTypeId = (int)(rdr["PoRateTypeId"]),
                        PoRateTypeName = (string)(rdr["PoRateTypeName"]),

                    });
            }
            return elist;
        }

    }
}