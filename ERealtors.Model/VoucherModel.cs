using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERealtors.Model
{
    public class VoucherModel
    {
      
    }

    public class ReceiptPostModel
    {
        public string SpName { get; set; }

        public string Action { get; set; }
        public int? Id { get; set; }
        public float? Payment { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionDetails { get; set; }
    }

    public class ReceiptListModel
    {
        public string Id { get; set; }
        public string GUID { get; set; }
        public string ReceivedFrom { get; set; }
        public string TransactionDetails { get; set; }
        public string Amount { get; set; }
        public string TransactionDate { get; set; }

    }

    public class ReceiptCustomerDue
    {
        public float TotalDue { get; set; }
        public float AmountReceived { get; set; }
        public float BalanceDue { get; set; }
    }
}
