using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERealtors.DAL;
using ERealtors.Model;

namespace ERealtors.BAL
{
    public class MemberService
    {
        public static ApplicationResultModel GetMemberList(string Action, int? Id)
        {
            var result = MemberData.GetMemberList(Action, Id);
            return new ApplicationResultModel() { Success = true, Result = result.Result };
        }

        public static ApplicationResultModel GetMemberById(int memberId, string MonYear)
        {
            var result = MemberData.GetMemberById(memberId, MonYear);
            return new ApplicationResultModel() { Success = true, Result = result.Result };
        }

        public static ApplicationResultModel GetSponserList()
        {
            var result = MemberData.GetSponserList();
            return new ApplicationResultModel() { Success = true, Result = result.Result };
        }

        public static ApplicationResultModel SetMemberData(MembersModel membersModel)
        {
            var result = MemberData.SetMemberData(membersModel);
            return new ApplicationResultModel() { Success = true, Result= result.Result };
        }

        public static ApplicationResultModel GetBusinessTransactions()
        {
            var result = MemberData.GetBusinessTransactions();
            return new ApplicationResultModel() { Success = true, Result = result.Result };
        }

        public static ApplicationResultModel GetMemberRanks()
        {
            var result = MemberData.GetMemberRanks();
            return new ApplicationResultModel() { Success = true, Result = result.Result };
        }
    }
}
