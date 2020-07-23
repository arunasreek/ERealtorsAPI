using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERealtors.BAL;
using ERealtors.Model;

namespace ERealtors.API.Controllers
{
    [RoutePrefix("api/ERealtors/Member")]
    public class MemberController : ApiController
    {
        [HttpGet]
        [Route("GetMemberList")]
        public HttpResponseMessage GetUsersList()
        {
            var result = MemberService.GetMemberList();
            return Request.CreateResponse(HttpStatusCode.OK, new ApplicationResultModel { Success = true, Result = result.Result });
        }

        [HttpPost]
        [Route("PostMemberData")]
        public HttpResponseMessage PostMemberData(MembersModel membersModel)
        {
            var response = MemberService.SetMemberData(membersModel);
            return Request.CreateResponse(HttpStatusCode.OK, new ApplicationResultModel { Success = true,Result= response });
        }

        [HttpGet]
        [Route("GetSponserList")]
        public HttpResponseMessage GetSponserList()
        {
            var result = MemberService.GetSponserList();
            return Request.CreateResponse(HttpStatusCode.OK, new ApplicationResultModel { Success = true, Result = result.Result });
        }

        [HttpGet]
        [Route("GetMemberData/{memberId}")]
        public HttpResponseMessage GetMemberDetailsById(int memberId)
        {
            var response = MemberService.GetMemberById(memberId);
            return Request.CreateResponse(HttpStatusCode.OK, new ApplicationResultModel { Success = true, Result = response.Result });
        }
    }
}
