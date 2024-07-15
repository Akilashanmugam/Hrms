using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Ajax.Utilities;

namespace HrmsWeb.Models
{
    public class EmployeeDBHandle
    {
        private SqlConnection con;
       
        private DateTime dt1;
        private DateTime dt2;
        private DateTime dt3;

        private void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW Employee *********************
        public bool Add(EmployeeModel emodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("EmployeeAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@EmployeeName", emodel.EmployeeName);
            cmd.Parameters.AddWithValue("@DepartmentId", emodel.DepartmentId);
            if (emodel.DOB == null)
            {
                cmd.Parameters.AddWithValue("@DOB", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DOB", emodel.DOB);
            }

            if (emodel.DOJ == null)
            {
                cmd.Parameters.AddWithValue("@DOJ", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DOJ", emodel.DOJ);
            }
            if (emodel.DOL == null)
            {
                cmd.Parameters.AddWithValue("@DOL", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DOL", emodel.DOL);
            }
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW Employee DETAILS ********************

        public List<EmployeeModel> List()
        {
            Connection();
            List<EmployeeModel> elist = new List<EmployeeModel>();

            SqlCommand cmd = new SqlCommand("EmployeeList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

           

            foreach (DataRow dr in dt.Rows)
            {

                if (dr.IsNull("DOB"))
                    dt1 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(dr["DOB"].ToString(), out dt1) == false)
                        dt1 = DateTime.MinValue;
                }

                if (dr.IsNull("DOJ"))
                    dt2 = DateTime.MinValue;


                else
                {
                    if (DateTime.TryParse(dr["DOJ"].ToString(), out dt2) == false)
                        dt2 = DateTime.MinValue;
                }
                if (dr.IsNull("DOL"))
                    dt3 = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(dr["DOL"].ToString(), out dt3) == false)
                        dt3 = DateTime.MinValue;
                }




                elist.Add(
                    new EmployeeModel
                    {
                        EmployeeId = (int)(dr["EmployeeId"]),
                        EmployeeName = (string)(dr["EmployeeName"]),
                        DepartmentId = (int)dr["DepartmentId"],
                        DepartmentName = (string)dr["LookUpDetailName"],
                        DOB = dt1,
                        DOJ = dt2,
                        DOL = dt3,
                    }); ;
            }
            return elist;
        }

        //GetterSetter departmentlist from Lopopkupdetails for department dropdown
        public List<LookUpDetailModel> DepartmentList()
        {
            Connection();
            List<LookUpDetailModel> DeptList = new List<LookUpDetailModel>();

            SqlCommand cmd = new SqlCommand("GetDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                DeptList.Add(
                    new LookUpDetailModel
                    {
                        LookUpDetailId = (int)(dr["LookUpDetailId"]),
                        LookUpDetailName = (string)(dr["LookUpDetailName"]),
                      

                    });
            }
            return DeptList;
        }

      

        public bool Update(EmployeeModel emodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("EmployeeEdit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", emodel.EmployeeId);
            cmd.Parameters.AddWithValue("@EmployeeName", emodel.EmployeeName);
            cmd.Parameters.AddWithValue("@DepartmentId", emodel.DepartmentId);
            if (emodel.DOB == null)
            {
                cmd.Parameters.AddWithValue("@DOB", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DOB", emodel.DOB);
            }
         
            if  (emodel.DOJ == null){
                cmd.Parameters.AddWithValue("@DOJ", DBNull.Value);
            }
            else {
                cmd.Parameters.AddWithValue("@DOJ", emodel.DOJ);
            }
            if (emodel.DOL == null)
            {
                cmd.Parameters.AddWithValue("@DOL", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DOL", emodel.DOL);
            }
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE Employee DETAILS *******************
        public bool Delete(int EmployeeId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("EmployeeDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
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