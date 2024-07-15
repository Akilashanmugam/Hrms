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
    public class LeaveAllotmentDBHandle 
    {
        // GET: LeaveAllotmentDBHandle
        private SqlConnection con;
       
        private void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);
        }

        public List<LeaveAllotmentModel> List()
        {
            Connection();
            List<LeaveAllotmentModel> list = new List<LeaveAllotmentModel>();
            SqlCommand cmd = new SqlCommand("Select * from Client", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow rdr in dt.Rows)
            {
                list.Add(
                    new LeaveAllotmentModel
                    {
                        ClientId = (int)(rdr["ClientId"]),
                        ClientName = (string)(rdr["ClientName"]),

                    });
            }
            return list;
        }
        public List<LeaveAllotmentModel> LeaveAllotmentList123(int id)
        {
            Connection();
            List<LeaveAllotmentModel> leaveAllotments = new List<LeaveAllotmentModel>();

            SqlCommand cmd = new SqlCommand("LeaveAllotmentList123", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientId", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
                var leaveAllotment = new LeaveAllotmentModel
                {
                    ClientId = (int)rdr["ClientId"],
                    LeaveTypeId = (int)rdr["LeaveTypeId"],
                    LeaveTypeName1 = (string)rdr["LeaveTypeName1"],
                    LastUpdatedBy = (int)rdr["LastUpdatedBy"],
                    LastUpdatedByName = rdr["LastUpdatedByName"].ToString(),
                    LastUpdatedDate = rdr.IsNull("LastUpdatedDate") ? DateTime.MinValue : Convert.ToDateTime(rdr["LastUpdatedDate"])
                };

                foreach (var column in dt.Columns.Cast<DataColumn>().Where(c => c.ColumnName.EndsWith("Leave")))
                {
                    typeof(LeaveAllotmentModel).GetProperty(column.ColumnName)?.SetValue(leaveAllotment, rdr[column]);
                }

                leaveAllotments.Add(leaveAllotment);
            }
            return leaveAllotments;
        }


    }

}
