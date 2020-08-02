using ERealtors.BAL;
using ERealtors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ERealtors.Model.BaseInfo;

namespace ERealtors.API.Controllers
{
    [RoutePrefix("api/ERealtors/Setting")]
    public class SettingController : ApiController
    {
        [HttpGet]
        [Route("GetSettingList")]
        public HttpResponseMessage GetSettingList()
        {
            var result = SettingService.GetSettingList();
            return Request.CreateResponse(HttpStatusCode.OK, new ApplicationResultModel { Success = true, Result = result.Result });
        }

        [HttpPost]
        [Route("PostSetting")]
        public HttpResponseMessage PostSetting(SettingList setting)
        {
            var result = SettingService.PostSetting(setting);
            return Request.CreateResponse(HttpStatusCode.OK, new ApplicationResultModel { Success = true, Result = result.Result });
        }

        [HttpPost]
        [Route("PostAutoSetting")]
        public HttpResponseMessage PostAutoSetting(PostAutoSettingModel postAutoSettingModel)
        {
            var result = SettingService.PostAutoSetting(postAutoSettingModel);
            return Request.CreateResponse(HttpStatusCode.OK, new ApplicationResultModel { Success = true, Result = result.Result });
        }
    }
}
