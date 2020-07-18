using ERealtors.Model;
using Microsoft.ApplicationBlocks.Data;
using NevaCloud.FalconConverters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ERealtors.Model.BaseInfo;

namespace ERealtors.DAL
{
    public class MemberData
    {
        static string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public static string GetMemberList()
        {
            return "Hi";
        }

        public static ApplicationResultModel GetMemberById(int memberId)
        {
            try
            {
                List<SqlParameter> objParamInfo = new List<SqlParameter>();
                objParamInfo.Add(new SqlParameter("@Id", memberId));
                List<RealtorsMemberData> lstEdu = new List<RealtorsMemberData>();
                using (SqlDataReader dr = SqlHelper.ExecuteReader(str, CommandType.StoredProcedure, "usp_Customers_Report", objParamInfo.ToArray()))
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    foreach (DataRow row in dt.Rows)
                    {
                        lstEdu.Add(new RealtorsMemberData
                        {
                            Payout_Number = DataBase.Turn<string>(row["Payout_Number"]),
                            Payout_Period = DataBase.Turn<string>(row["Payout_Period"]),
                            Name = DataBase.Turn<string>(row["Name"]),
                            Rank = DataBase.Turn<string>(row["Rank"]),
                            Id_Number = DataBase.Turn<string>(row["Id_Number"]),
                            Address = DataBase.Turn<string>(row["Address"]),
                            Direct_Coll = DataBase.Turn<string>(row["Direct_Collection"]),
                            Team_Coll = DataBase.Turn<string>(row["Team_Collection"]),
                            DownLine_In = DataBase.Turn<string>(row["Downline_upgrade_incentive"]),
                            MFA = DataBase.Turn<string>(row["MFA"]),
                            Eligibility = DataBase.Turn<string>(row["Eligibility"]),
                            first_Level = DataBase.Turn<string>(row["first_Level"]),
                            Eligibility1 = DataBase.Turn<string>(row["Eligibility1"]),
                            Upgrade_Amount = DataBase.Turn<string>(row["Upgrade_Amount"]),
                            TDSANDSC = DataBase.Turn<string>(row["TDSANDSC"]),
                            Total_Ded = DataBase.Turn<string>(row["Total_Deduction"]),
                            Total = DataBase.Turn<string>(row["Total"]),
                            Deduction = DataBase.Turn<string>(row["Deduction"]),
                            Total_Income = DataBase.Turn<string>(row["Total_Income"]),
                            Net_Eligibility_Amt = DataBase.Turn<string>(row["Net_Eligibility_Amount"])
                        });
                    }
                    dr.Close();
                }
                return new ApplicationResultModel() { Success = true, Result = lstEdu };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ApplicationResultModel SetMemberData(MembersModel setErealtors)
        {
            List<SqlParameter> objParamInfo = new List<SqlParameter>
            {
                new SqlParameter("@Name", setErealtors.Name),
                new SqlParameter("@RefId", setErealtors.RefId),
                new SqlParameter("@plot_sqyds", setErealtors.plot_sqyds),
                new SqlParameter("@no_of_plots", setErealtors.no_of_plots),
                new SqlParameter("@rate_per_plot", setErealtors.rate_per_plot),
                new SqlParameter("@address", setErealtors.address),
                new SqlParameter("@perks", setErealtors.perks),
            };

            using (SqlDataReader dr = SqlHelper.ExecuteReader(str, CommandType.StoredProcedure, "usp_Add_Customer", objParamInfo.ToArray()))
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
            }

            return new ApplicationResultModel() { Success = true};
        }
    }
}
