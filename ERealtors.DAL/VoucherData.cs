using ERealtors.Model;
using Microsoft.ApplicationBlocks.Data;
using NevaCloud.FalconConverters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERealtors.DAL
{
    public class VoucherData
    {
        static string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public static ApplicationResultModel GetReceiptVList(ReceiptPostModel receiptPostModel)
        {
            try
            {
                List<SqlParameter> objParamInfo = new List<SqlParameter>
                {
                    new SqlParameter("@Action", receiptPostModel.Action),
                    new SqlParameter("@Id", receiptPostModel.Id ==null?null:receiptPostModel.Id),
                    new SqlParameter("@payment", receiptPostModel.Payment==null? null:  receiptPostModel.Payment),
                    new SqlParameter("@TransactionDate", DateTime.Now),
                    new SqlParameter("@TransactionDetails", string.IsNullOrEmpty(receiptPostModel.TransactionDetails)?null:receiptPostModel.TransactionDetails)
                };
                var lstreceiptListModel = new List<ReceiptListModel>();
                if(receiptPostModel.Action == "Insert")
                {
                    using (SqlDataReader dr = SqlHelper.ExecuteReader(str, CommandType.StoredProcedure, receiptPostModel.SpName, objParamInfo.ToArray()))
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        dr.Close();
                    }
                    return new ApplicationResultModel() { Success = true, Result = "Success" };
                } 
                else if(receiptPostModel.Action == "View")
                {
                    using (SqlDataReader dr = SqlHelper.ExecuteReader(str, CommandType.StoredProcedure, receiptPostModel.SpName, objParamInfo.ToArray()))
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        foreach (DataRow row in dt.Rows)
                        {
                            lstreceiptListModel.Add(new ReceiptListModel
                            {
                                Id = DataBase.Turn<string>(row["Id"]),
                                GUID = DataBase.Turn<string>(row["GUID"]),
                                ReceivedFrom = receiptPostModel.SpName== "usp_IU_Payment"? DataBase.Turn<string>(row["PaidTo"]) : DataBase.Turn<string>(row["ReceivedFrom"]),
                                TransactionDetails = DataBase.Turn<string>(row["TransactionDetails"]),
                                Amount = DataBase.Turn<string>(row["Amount"]),
                                TransactionDate = DataBase.Turn<string>(row["TransactionDate"])
                            });
                        }
                        dr.Close();
                    }
                    return new ApplicationResultModel() { Success = true, Result = lstreceiptListModel };
                }
                else
                {
                    var receiptCustomerDue = new ReceiptCustomerDue();

                    using (SqlDataReader dr = SqlHelper.ExecuteReader(str, CommandType.StoredProcedure, receiptPostModel.SpName, objParamInfo.ToArray()))
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        foreach (DataRow row in dt.Rows)
                        {
                            receiptCustomerDue.TotalDue = DataBase.Turn<float>(row["TotalDue"]);
                            receiptCustomerDue.AmountReceived = DataBase.Turn<float>(row["AmountReceived"]);
                            receiptCustomerDue.BalanceDue = DataBase.Turn<int>(row["BalanceDue"]);
                        }
                        dr.Close();
                        return new ApplicationResultModel() { Success = true, Result = receiptCustomerDue };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
