using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERealtors.BAL;
using ERealtors.Model;
using System.Web;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace ERealtors.API.Controllers
{
    [RoutePrefix("api/ERealtors/Member")]
    public class MemberController : ApiController
    {
        [HttpGet]
        [Route("GetMemberList/{actionTaken}/{memberId}")]
        public HttpResponseMessage GetMemberList(string actionTaken,int? memberId)
        {
            var result = MemberService.GetMemberList(actionTaken, memberId);
            return Request.CreateResponse(HttpStatusCode.OK, new ApplicationResultModel { Success = true, Result = result.Result });
        }

        [HttpPost]
        [Route("PostMemberData")]
        public HttpResponseMessage PostMemberData(MembersModel membersModel)
        {
            var response = MemberService.SetMemberData(membersModel);
            string fromaddress = System.Configuration.ConfigurationManager.AppSettings["fromaddress"];
            //string toaddrss = System.Configuration.ConfigurationManager.AppSettings["toaddress"];
           
            if(membersModel.ActionTaken == "Insert")
            {
                string password = System.Configuration.ConfigurationManager.AppSettings["password"];
                string FilePath = HttpContext.Current.Server.MapPath("~/Email_Template/Welcome.html");
                StreamReader str = new StreamReader(FilePath);
                string MailText = str.ReadToEnd();
                str.Close();

                //Repalce [newusername] = signup user name   
                MailText = MailText.Replace("[newusername]", membersModel.First_Name + " " + membersModel.Surname);
                MailText = MailText.Replace("[RHPL]", response.Result.ToString());


                string subject = "Welcome to RajadhaniHousingProjects";

                //Base class for sending email  
                MailMessage _mailmsg = new MailMessage();

                //Make TRUE because our body text is html  
                _mailmsg.IsBodyHtml = true;

                //Set From Email ID  
                _mailmsg.From = new MailAddress(fromaddress);

                //Set To Email ID  
                _mailmsg.To.Add(membersModel.Email_Address.ToString());

                //Set Subject  
                _mailmsg.Subject = subject;

                //Set Body Text of Email   
                _mailmsg.Body = MailText;


                //Now set your SMTP   
                SmtpClient _smtp = new SmtpClient();

                //Set HOST server SMTP detail  
                _smtp.Host = "relay-hosting.secureserver.net";

                //Set PORT number of SMTP  
                _smtp.Port = 25;

                //Set SSL --> True / False  
                _smtp.EnableSsl = false;

                _smtp.UseDefaultCredentials = false;

                //Set Sender UserEmailID, Password  
                NetworkCredential networkCredential = new NetworkCredential(fromaddress, password);
                _smtp.Credentials = networkCredential;

                //Send Method will send your MailMessage create above.  
                _smtp.Send(_mailmsg);
                return Request.CreateResponse(HttpStatusCode.OK, new ApplicationResultModel { Success = true, Result = response });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new ApplicationResultModel { Success = true, Result = "Success" });
        }

        [HttpGet]
        [Route("GetSponserList")]
        public HttpResponseMessage GetSponserList()
        {
            var result = MemberService.GetSponserList();
            return Request.CreateResponse(HttpStatusCode.OK, new ApplicationResultModel { Success = true, Result = result.Result });
        }

        [HttpGet]
        [Route("GetMemberData/{memberId}/{MonYear}")]
        public HttpResponseMessage GetMemberDetailsById(int memberId,string MonYear)
        {
            var response = MemberService.GetMemberById(memberId, MonYear);
            return Request.CreateResponse(HttpStatusCode.OK, new ApplicationResultModel { Success = true, Result = response.Result });
        }

        [HttpPost]
        [Route("PostMember/MemberImage")]
        public HttpResponseMessage PostMemberImage()
        {
            var postedFile = HttpContext.Current.Request.Files[0];
            string postedFileName="";
            if (postedFile != null && postedFile.ContentLength > 0)
            {
                List<string> allowedExtensions = new List<string>() { ".jpg", ".jpeg", ".png" };
                var extension = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.')).ToLower();

                if (!allowedExtensions.Contains(extension))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "File Extensions Not Allowed");
                }
                else
                {
                    postedFileName = DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss") + Path.GetFileName(postedFile.FileName).Replace(" ", "_");
                    var filePath = HttpContext.Current.Server.MapPath("~/MemberImage/" +  postedFileName);
                    postedFile.SaveAs(filePath);
                }
            }
            return Request.CreateResponse(HttpStatusCode.Created, postedFileName);
        }
    
        [HttpGet]
        [Route("GetBusinessTransactions")]
        public HttpResponseMessage GetBusinessTransactions()
        {
            var result = MemberService.GetBusinessTransactions();
            return Request.CreateResponse(HttpStatusCode.OK, new ApplicationResultModel { Success = true, Result = result.Result});
        }

        [HttpGet]
        [Route("GetMemberRanks")]
        public HttpResponseMessage GetMemberRanks()
        {
            var result = MemberService.GetMemberRanks();
            return Request.CreateResponse(HttpStatusCode.OK, new ApplicationResultModel { Success = true, Result = result.Result });
        }

    }
}
