using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERealtors.Model
{
    public class BaseInfo
    {
        public class RealtorsMemberData
        {
            public string Payout_Number { get; set; }
            public string Payout_Period { get; set; }
            public string Name { get; set; }
            public string Rank { get; set; }
            public string Id_Number { get; set; }
            public string Address { get; set; }
            public string Direct_Coll { get; set; }
            public string Team_Coll { get; set; }
            public string DownLine_In { get; set; }
            public string MFA { get; set; }
            public string Eligibility { get; set; }
            public string first_Level { get; set; }
            public string Eligibility1 { get; set; }

            public string Upgrade_Amount { get; set; }
            public string TDSANDSC { get; set; }
            public string Total_Ded { get; set; }
            public string Total { get; set; }
            public string Deduction { get; set; }
            public string Total_Income { get; set; }
            public string Net_Eligibility_Amt { get; set; }
            public string Image { get; set; }
        }

        public class RealtorsSponserList
        {
            public int SponserId { get; set; }
            public string SponserValue { get; set; }

        }
        
        public class RealtorsMemberBasicData
        {
            public int Id { get; set; }
            public string Guid { get; set; }
            public string Member { get; set; }
            public int Star { get; set; }
            public string Sponser { get; set; }
            public DateTime Join_Date { get; set; }
            public int AutoPool { get; set; }
        }

        public class SettingList
        {
            public string Action { get; set; }
            public int Id { get; set; }
            public string Cadre { get; set; }
            public int Target_Units { get; set; }
            public int Downline_Members { get; set; }
            public int Plots_SQYDS { get; set; }
            public float Rate_per_Plot { get; set; }
            public float Incentive_Maximum_Amount { get; set; }
            public float Incentive_Percentage { get; set; }
            public float MFA_Minimum_Amount { get; set; }
            public float MFA_Percentage { get; set; }
            public float Bonanza_Maximum_Amount { get; set; }
            public float Bonanza_Percentage { get; set; }
            public string Perk1 { get; set; }
            public string Perk2 { get; set; }

        }

        public class PostAutoSettingModel
        {
            public string Autopool_Star_Level { get; set; }
            public string Autopool_Level { get; set; }
            public float Upgrade_Amount { get; set; }
            public int Downline_Members { get; set; }
        }
   
        public class BusinessTransactions
        {
            public string Category { get; set; }
            public string Member { get; set; }
            public string SponsorName { get; set; }
            public int Amount { get; set; }
            public DateTime TransactionDate { get; set; }
        }

        public class MemberRank
        {
            public string MemberName { get; set; }
            public string Month { get; set; }
            public string Year { get; set; }
            public int MemberCadre { get; set; }
            public int MemberAutopoolLevel { get; set; }
            public string Sponsor_Name { get; set; }
            public int Sponsor_Cadre { get; set; }
            public int Sponsor_Autopool_Level { get; set; }
        }
    }
}
