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
    }
}
