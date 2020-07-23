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
        public static ApplicationResultModel GetMemberList()
        {
            var result = MemberData.GetMemberList();
            return new ApplicationResultModel() { Success = true, Result = result.Result };
        }

        public static ApplicationResultModel GetMemberById(int memberId)
        {
            var result = MemberData.GetMemberById(memberId);
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
            return new ApplicationResultModel() { Success = true };
        }
    }
}
