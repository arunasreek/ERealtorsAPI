using ERealtors.DAL;
using ERealtors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ERealtors.Model.BaseInfo;

namespace ERealtors.BAL
{
    public class SettingService
    {
        public static ApplicationResultModel GetSettingList()
        {
            var result = SettingData.GetSettingList();
            return new ApplicationResultModel() { Success = true, Result = result.Result };
        }

        public static ApplicationResultModel PostSetting(SettingList setting)
        {
            var result = SettingData.PostSetting(setting);
            return new ApplicationResultModel() { Success = true, Result = result.Result };
        }

        public static ApplicationResultModel PostAutoSetting(PostAutoSettingModel postAutoSettingModel)
        {
            var result = SettingData.PostAutoPoolSetting(postAutoSettingModel);
            return new ApplicationResultModel() { Success = true, Result = result.Result };
        }
    }
}
