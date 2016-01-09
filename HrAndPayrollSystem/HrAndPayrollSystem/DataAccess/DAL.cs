using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HrAndPayrollSystem.DataAccess
{
    public class DAL
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["HrAndPayroll"].ToString());

        public static bool UserIsValid(string username, string password)
        {
            bool authenticated = false;

            string query = string.Format("SELECT * FROM [UserRegisters] WHERE Username = '{0}' AND Password = '{1}'", username, password);

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                authenticated = sdr.HasRows;

                if (sdr.Read())
                {
                    HttpContext context = HttpContext.Current;
                    context.Session["syscode"]   = sdr.GetValue(3).ToString();

                    context.Session["DpCreate"] = sdr.GetBoolean(5);
                    context.Session["DpEdit"] = sdr.GetBoolean(6);
                    context.Session["DpDetail"] = sdr.GetBoolean(7);
                    context.Session["DpDelete"] = sdr.GetBoolean(8);

                    context.Session["DgCreate"] = sdr.GetBoolean(9);
                    context.Session["DgEdit"] = sdr.GetBoolean(10);
                    context.Session["DgDetail"] = sdr.GetBoolean(11);
                    context.Session["DgDelete"] = sdr.GetBoolean(12);

                    context.Session["PmCreate"] = sdr.GetBoolean(13);
                    context.Session["PmEdit"] = sdr.GetBoolean(14);
                    context.Session["PmDetail"] = sdr.GetBoolean(15);
                    context.Session["PmDelete"] = sdr.GetBoolean(16);

                    context.Session["LcCreate"] = sdr.GetBoolean(17);
                    context.Session["LcEdit"] = sdr.GetBoolean(18);
                    context.Session["LcDetail"] = sdr.GetBoolean(19);
                    context.Session["LcDelete"] = sdr.GetBoolean(20);


                }
            }
            conn.Close();

            return (authenticated);
        }
    }
}