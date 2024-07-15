using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HrmsWeb.Models;
using Hrmsweb.Models;
using System.Linq;

namespace HrmsWeb.Controllers
{
    public class DashboardDBHandle
    {
        private SqlConnection con;
        private DateTime stdt;
        private DateTime endt;
        private void Connection()

        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);

        }

        public List<EmployeeModel> GetEmployeeData()
        {
            Connection();
            List<EmployeeModel> employees = new List<EmployeeModel>();

            SqlCommand cmd = new SqlCommand(@"
            SELECT 
                ld.LookUpDetailName AS DepartmentName, 
                COUNT(e.EmployeeId) AS EmployeeCount
            FROM 
                Employee e
            JOIN 
                LookUpDetail ld ON e.DepartmentId = ld.LookUpDetailId
            GROUP BY 
                ld.LookUpDetailName", con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                employees.Add(new EmployeeModel
                {
                    DepartmentName = rdr["DepartmentName"].ToString(),
                    EmployeeCount = Convert.ToInt32(rdr["EmployeeCount"])
                });
            }
            con.Close();
            return employees;
        }
        //public List<ClientModel> GetClients()
        //{
        //    Connection();
        //    List<ClientModel> clients = new List<ClientModel>();

        //    SqlCommand cmd = new SqlCommand("SELECT ClientName, ClientShortName FROM Client", con);
        //    con.Open();
        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    while (rdr.Read())
        //    {
        //        clients.Add(new ClientModel
        //        {
        //            ClientName = rdr["ClientName"].ToString(),
        //            ClientShortName = rdr["ClientShortName"].ToString()
        //        });
        //    }
        //    con.Close();
        //    return clients;
        //}

        //public List<DeshboardModel> GetActiveEmployeesCountByClient()
        //{
        //    Connection();
        //    List<DeshboardModel> clients = new List<DeshboardModel>();

        //    SqlCommand cmd = new SqlCommand("GetClientActiveEmployeeCount", con)
        //    {
        //        CommandType = CommandType.StoredProcedure
        //    };
        //    con.Open();
        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    while (rdr.Read())
        //    {
        //        clients.Add(new DeshboardModel
        //        {
        //            ClientName = rdr["ClientName"].ToString(),
        //            ActiveEmployeeCount = Convert.ToInt32(rdr["ActiveEmployeeCount"])
        //        });
        //    }
        //    con.Close();
        //    return clients;
        //}

        public List<DashboardModel> GetCombinedClientData()
        {
            Connection();
            List<DashboardModel> combinedData = new List<DashboardModel>();

            SqlCommand clientCmd = new SqlCommand("SELECT ClientName FROM Client", con);
            con.Open();
            SqlDataReader clientRdr = clientCmd.ExecuteReader();
            List<string> clientNames = new List<string>();
            while (clientRdr.Read())
            {
                clientNames.Add(clientRdr["ClientName"].ToString());
            }
            con.Close();

            SqlCommand employeeCmd = new SqlCommand("GetClientActiveEmployeeCount", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            con.Open();
            SqlDataReader employeeRdr = employeeCmd.ExecuteReader();
            Dictionary<string, int> activeEmployeeCounts = new Dictionary<string, int>();
            while (employeeRdr.Read())
            {
                activeEmployeeCounts[employeeRdr["ClientName"].ToString()] = Convert.ToInt32(employeeRdr["ActiveEmployeeCount"]);
            }
            con.Close();

            foreach (var clientName in clientNames)
            {
                combinedData.Add(new DeshboardModel
                {
                    ClientName = clientName,
                    ActiveEmployeeCount = activeEmployeeCounts.ContainsKey(clientName) ? activeEmployeeCounts[clientName] : 0
                });
            }

            return combinedData;
        }

        public List<DashboardModel> List()
        {
            Connection();
            List<DashboardModel> clist = new List<DashboardModel>();

            SqlCommand cmd = new SqlCommand("DashboardEmployeeList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {

                if (rdr.IsNull("ClientDOJ"))
                    stdt = DateTime.MinValue;
                else
                {
                    if (DateTime.TryParse(rdr["ClientDOJ"].ToString(), out stdt) == false)
                        stdt = DateTime.MinValue;
                }



                clist.Add(
                  new DashboardModel
                   {
                        EmployeeId = rdr["EmployeeId"] != DBNull.Value ? Convert.ToInt32(rdr["EmployeeId"]) : 0,
                        ClientDOJ = rdr["ClientDOJ"] != DBNull.Value ? Convert.ToDateTime(rdr["ClientDOJ"]) : DateTime.MinValue,
                        ClientId = rdr["ClientId"] != DBNull.Value ? Convert.ToInt32(rdr["ClientId"]) : 0,
                        DesignationId = rdr["DesignationId"] != DBNull.Value ? Convert.ToInt32(rdr["DesignationId"]) : 0,
                        Gross = rdr["Gross"] != DBNull.Value ? Convert.ToDecimal(rdr["Gross"]) : 0,
                        NetPay = rdr["NetPay"] != DBNull.Value ? Convert.ToDecimal(rdr["NetPay"]) : 0,
                        EmployeeName = rdr["EmployeeName"] != DBNull.Value ? rdr["EmployeeName"].ToString() : string.Empty,
                        ClientName = rdr["ClientName"] != DBNull.Value ? rdr["ClientName"].ToString() : string.Empty,
                        DesignationName = rdr["DesignationName"] != DBNull.Value ? rdr["DesignationName"].ToString() : string.Empty,
                 });
            }
            return clist;
        }

    }
}