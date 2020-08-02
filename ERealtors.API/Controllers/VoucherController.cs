using ERealtors.BAL;
using ERealtors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERealtors.API.Controllers
{
    [RoutePrefix("api/ERealtors/Voucher")]
    public class VoucherController : ApiController
    {
        [HttpPost]
        [Route("GetReceiptVList")]
        public HttpResponseMessage GetReceiptVList(ReceiptPostModel receiptPostModel)
        {
            var result = VoucherService.GetReceiptVList(receiptPostModel);
            return Request.CreateResponse(HttpStatusCode.OK, new ApplicationResultModel { Success = true, Result = result.Result });
        }
    }
}
