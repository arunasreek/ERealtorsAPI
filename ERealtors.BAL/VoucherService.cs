using ERealtors.DAL;
using ERealtors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERealtors.BAL
{
    public class VoucherService
    {
        public static ApplicationResultModel GetReceiptVList(ReceiptPostModel receiptPostModel)
        {
            var result = VoucherData.GetReceiptVList(receiptPostModel);
            return new ApplicationResultModel() { Success = true, Result = result.Result };
        }
    }
}
