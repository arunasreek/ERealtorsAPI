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
        public static ApplicationResultModel GetMemberList(string Action, int? Id)
        {
            try
            {
                List<MembersModel> lstEdu = new List<MembersModel>();
                List<SqlParameter> objParamInfo = new List<SqlParameter>();
                objParamInfo.Add(new SqlParameter("@Action", Action));
                objParamInfo.Add(new SqlParameter("@Id", Id));
                using (SqlDataReader dr = SqlHelper.ExecuteReader(str, CommandType.StoredProcedure, "usp_Customers_List", objParamInfo.ToArray()))
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    foreach (DataRow row in dt.Rows)
                    {
                        lstEdu.Add(new MembersModel
                        {
                            Id = DataBase.Turn<int>(row["Id"]),
                            Guid = DataBase.Turn<string>(row["Ftiwp_GUID"]),
                            Member = DataBase.Turn<string>(row["Member"]),
                            Sponser = DataBase.Turn<string>(row["Sponsor_Name"]),
                            Gender = DataBase.Turn<string>(row["Gender"]),
                            Star = DataBase.Turn<int>(row["Star_Level"]),
                            Join_Date = DataBase.Turn<DateTime>(row["Joined_Date"]),
                            AutoPool = DataBase.Turn<int>(row["Autopool_Level"]),
                            Password = DataBase.Turn<string>(row["Password"]),
                            Confirm_Password = DataBase.Turn<string>(row["Confirm_Password"]),
                            no_of_plots = DataBase.Turn<int>(row["No_of_plots"]),
                            rate_per_plot = DataBase.Turn<int>(row["Rate_per_plot"]),
                            plot_sqyds = DataBase.Turn<int>(row["Plot_SQYDS"]),
                            address = DataBase.Turn<string>(row["Address"]),
                            First_Name = DataBase.Turn<string>(row["First_Name"]),
                            Surname =  DataBase.Turn<string>(row["Surname"]),
                            Username = DataBase.Turn<string>(row["Username"]),
                            Email_Address = DataBase.Turn<string>(row["Email_Address"]),
                            Date_of_Joining = DataBase.Turn<DateTime>(row["Date_of_Joining"]),
                            Date_of_Birth = DataBase.Turn<DateTime>(row["Date_of_Birth"]),
                            perks = DataBase.Turn<string>(row["Perks"]),
                            Sponsor = DataBase.Turn<int>(row["Sponsor"]),
                            Name_of_Nominee = DataBase.Turn<string>(row["Name_of_Nominee"]),
                            Mobile_Number = DataBase.Turn<string>(row["Mobile_Number"]),
                            Pan_Card_Number = DataBase.Turn<string>(row["Pan_Card_Number"]),
                            Aadhaar_Number = DataBase.Turn<string>(row["Aadhaar_Number"]),
                            Bank_Name = DataBase.Turn<string>(row["Bank_Name"]),
                            IFSC_Code = DataBase.Turn<string>(row["IFSC_Code"]),
                            Bank_Account_Number = DataBase.Turn<string>(row["Bank_Account_Number"]),
                            IsOptingforStar1Autopool = DataBase.Turn<int>(row["IsOptingforStar1Autopool"]),
                            UpgradeAmountPaid = DataBase.Turn<int>(row["UpgradeAmountPaid"]),
                            ImageUrl = DataBase.Turn<string>(row["image"]),
                            IsAdmin = DataBase.Turn<int>(row["IsAdmin"]),

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

        public static ApplicationResultModel GetMemberById(int memberId, string MonYear)
        {
            try
            {
                List<SqlParameter> objParamInfo = new List<SqlParameter>();
                objParamInfo.Add(new SqlParameter("@Id", memberId));
                objParamInfo.Add(new SqlParameter("@MonYear", MonYear));
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
                            Net_Eligibility_Amt = DataBase.Turn<string>(row["Net_Eligibility_Amount"]),
                            Image = DataBase.Turn<string>(row["Image"]),
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
            try
            {
                List<SqlParameter> objParamInfo = new List<SqlParameter>
            {
                new SqlParameter("@Action", setErealtors.ActionTaken),
                new SqlParameter("@Id", setErealtors.Id),
                new SqlParameter("@First_Name", setErealtors.First_Name),
                new SqlParameter("@Gender", setErealtors.Gender),
                new SqlParameter("@Surname", setErealtors.Surname),
                new SqlParameter("@Username", setErealtors.Username),
                new SqlParameter("@Email_Address", setErealtors.Email_Address),
                new SqlParameter("@Date_of_Joining", setErealtors.Date_of_Joining),
                new SqlParameter("@Date_of_Birth", setErealtors.Date_of_Birth),
                new SqlParameter("@Plot_SQYDS", setErealtors.plot_sqyds),
                new SqlParameter("@No_of_plots", setErealtors.no_of_plots),
                new SqlParameter("@Rate_per_plot", setErealtors.rate_per_plot),
                new SqlParameter("@Perks", setErealtors.perks),
                new SqlParameter("@Password", setErealtors.Password),
                new SqlParameter("@Confirm_Password", setErealtors.Confirm_Password),
                new SqlParameter("@Sponsor", setErealtors.Sponsor),
                new SqlParameter("@Name_of_Nominee", setErealtors.Name_of_Nominee),
                new SqlParameter("@Mobile_Number", setErealtors.Mobile_Number),
                new SqlParameter("@Address", setErealtors.address),
                new SqlParameter("@Pan_Card_Number", setErealtors.Pan_Card_Number),
                new SqlParameter("@Aadhaar_Number", setErealtors.Aadhaar_Number),
                new SqlParameter("@Bank_Name", setErealtors.Bank_Name),
                new SqlParameter("@IFSC_Code", setErealtors.IFSC_Code),
                new SqlParameter("@Bank_Account_Number", setErealtors.Bank_Account_Number),
                new SqlParameter("@IsOptingforStar1Autopool", setErealtors.IsOptingforStar1Autopool),
                new SqlParameter("@UpgradeAmountPaid", setErealtors.UpgradeAmountPaid),
                new SqlParameter("@Image", setErealtors.ImageUrl),
                new SqlParameter("@IsAdmin", setErealtors.IsAdmin)
            };
                string RHID = "";

                using (SqlDataReader dr = SqlHelper.ExecuteReader(str, CommandType.StoredProcedure, "usp_IU_Ftiwp_Customer", objParamInfo.ToArray()))
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                        foreach (DataRow row in dt.Rows)
                        {
                            if (setErealtors.ActionTaken == "Insert")
                            {
                                RHID = DataBase.Turn<string>(row["GUID"]);
                            }
                        }
                    dr.Close();
                }

                 return new ApplicationResultModel() { Success = true,Result= RHID };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    
    
        public static ApplicationResultModel GetSponserList()
        {
            try
            {
                List<RealtorsSponserList> lstSponser = new List<RealtorsSponserList>();
                using (SqlDataReader dr = SqlHelper.ExecuteReader(str, CommandType.StoredProcedure, "usp_Id_as_GUID"))
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    foreach (DataRow row in dt.Rows)
                    {
                        lstSponser.Add(new RealtorsSponserList
                        {
                            SponserId = DataBase.Turn<int>(row["id"]),
                            SponserValue = DataBase.Turn<string>(row["Ftiwp_GUID"])
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

        public static ApplicationResultModel GetBusinessTransactions()
        {
            try
            {
                List<BusinessTransactions> businessTransactions = new List<BusinessTransactions>();
                using (SqlDataReader dr = SqlHelper.ExecuteReader(str, CommandType.StoredProcedure, "usp_business_transactions"))
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    foreach (DataRow row in dt.Rows)
                    {
                        businessTransactions.Add(new BusinessTransactions
                        {
                            Category = DataBase.Turn<string>(row["Category"]),
                            Member = DataBase.Turn<string>(row["Member"]),
                            SponsorName = DataBase.Turn<string>(row["SponsorName"]),
                            Amount = DataBase.Turn<int>(row["Amount"]),
                            TransactionDate = DataBase.Turn<DateTime>(row["TransactionDate"])
                        });
                    }
                    dr.Close();
                }
                return new ApplicationResultModel() { Success = true, Result = businessTransactions };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ApplicationResultModel GetMemberRanks()
        {
            try
            {
                List<MemberRank> memberRanks = new List<MemberRank>();
                using (SqlDataReader dr = SqlHelper.ExecuteReader(str, CommandType.StoredProcedure, "usp_Members_Rank"))
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    foreach (DataRow row in dt.Rows)
                    {
                        memberRanks.Add(new MemberRank
                        {
                            MemberName = DataBase.Turn<string>(row["MemberName"]),
                            Month = DataBase.Turn<string>(row["Month"]),
                            Year = DataBase.Turn<string>(row["Year"]),
                            Sponsor_Name = DataBase.Turn<string>(row["Sponsor_Name"]),
                            MemberCadre = DataBase.Turn<int>(row["MemberCadre"]),
                            MemberAutopoolLevel = DataBase.Turn<int>(row["MemberAutopoolLevel"]),
                            Sponsor_Cadre = DataBase.Turn<int>(row["Sponsor_Cadre"]),
                            Sponsor_Autopool_Level = DataBase.Turn<int>(row["Sponsor_Autopool_Level"])
                        });
                    }
                    dr.Close();
                }
                return new ApplicationResultModel() { Success = true, Result = memberRanks };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
