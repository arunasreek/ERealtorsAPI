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
    public class SettingData
    {
        static string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public static ApplicationResultModel GetSettingList()
        {
            try
            {
                List<SettingList> lstSponser = new List<SettingList>();
                using (SqlDataReader dr = SqlHelper.ExecuteReader(str, CommandType.StoredProcedure, "usp_Settings_List"))
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    foreach (DataRow row in dt.Rows)
                    {
                        lstSponser.Add(new SettingList
                        {
                            Id = DataBase.Turn<int>(row["Id"]),
                            Cadre = DataBase.Turn<string>(row["Cadre"]),
                            Target_Units = DataBase.Turn<int>(row["Target_Units"]),
                            Downline_Members = DataBase.Turn<int>(row["Downline_Members"]),
                            Plots_SQYDS = DataBase.Turn<int>(row["Plots_SQYDS"]),
                            Rate_per_Plot = DataBase.Turn<float>(row["Rate_per_Plot"]),
                            Incentive_Maximum_Amount = DataBase.Turn<float>(row["Incentive_Maximum_Amount"]),
                            Incentive_Percentage = DataBase.Turn<float>(row["Incentive_Percentage"]),
                            MFA_Minimum_Amount = DataBase.Turn<float>(row["MFA_Minimum_Amount"]),
                            MFA_Percentage = DataBase.Turn<float>(row["MFA_Percentage"]),
                            Bonanza_Maximum_Amount = DataBase.Turn<float>(row["Bonanza_Maximum_Amount"]),
                            Bonanza_Percentage = DataBase.Turn<float>(row["Bonanza_Percentage"]),
                            Perk1 = DataBase.Turn<string>(row["Perk1"]),
                            Perk2 = DataBase.Turn<string>(row["Perk2"]),
                        });
                    }
                    dr.Close();
                }
                return new ApplicationResultModel() { Success = true, Result = lstSponser };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ApplicationResultModel PostSetting(SettingList setting)
        {
            try
            {
                List<SqlParameter> objParamInfo = new List<SqlParameter>
            {
                    new SqlParameter("@Action", setting.Action),
                    new SqlParameter("@Cadre", setting.Cadre),
                    new SqlParameter("@Target_Units", setting.Target_Units),
                    new SqlParameter("@Downline_Members", setting.Downline_Members),
                    new SqlParameter("@Plots_SQYDS", setting.Plots_SQYDS),
                    new SqlParameter("@Rate_per_plot", setting.Rate_per_Plot),
                    new SqlParameter("@Incentive_Maximum_Amount", setting.Incentive_Maximum_Amount),
                    new SqlParameter("@Incentive_Percentage", setting.Incentive_Percentage),
                    new SqlParameter("@MFA_Minimum_Amount", setting.MFA_Minimum_Amount),
                    new SqlParameter("@MFA_Percentage", setting.MFA_Percentage),
                    new SqlParameter("@Bonanza_Maximum_Amount", setting.Bonanza_Maximum_Amount),
                    new SqlParameter("@Bonanza_Percentage", setting.Bonanza_Percentage),
                    new SqlParameter("@Perk1", setting.Perk1),
                    new SqlParameter("@Perk2", setting.Perk2)
             };
                using (SqlDataReader dr = SqlHelper.ExecuteReader(str, CommandType.StoredProcedure, "usp_Add_Cadre_Settings", objParamInfo.ToArray()))
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dr.Close();
                }
            }
            catch(Exception ce)
            {

            }

            return new ApplicationResultModel() { Success = true, Result = "Success" };
        }

        public static ApplicationResultModel PostAutoPoolSetting(PostAutoSettingModel postAutoSettingModel)
        {
            try
            {
                List<SqlParameter> objParamInfo = new List<SqlParameter>
               {
                    new SqlParameter("@Autopool_Level", postAutoSettingModel.Autopool_Level),
                    new SqlParameter("@Autopool_Star_Level", postAutoSettingModel.Autopool_Star_Level),
                    new SqlParameter("@Downline_Members", postAutoSettingModel.Downline_Members),
                    new SqlParameter("@Upgrade_Amount", postAutoSettingModel.Upgrade_Amount)
               };
                using (SqlDataReader dr = SqlHelper.ExecuteReader(str, CommandType.StoredProcedure, "usp_Add_Autopool_Settings", objParamInfo.ToArray()))
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dr.Close();
                }
            }
            catch (Exception ce)
            {

            }

            return new ApplicationResultModel() { Success = true, Result = "Success" };
        }
    }
}
