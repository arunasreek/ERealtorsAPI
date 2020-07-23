using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERealtors.Model
{
    public class MembersModel
    {
         public string Name { get; set; }
         public int RefId { get; set; }
         public int plot_sqyds { get; set; }
         public int no_of_plots { get; set; }
         public int rate_per_plot { get; set; }
         public string address { get; set; }
         public string Country { get; set; }
         public string First_Name { get; set; }
         public string Surname { get; set; }
         public string Username { get; set; }
         public string Email_Address { get; set; }
         public DateTime Date_of_Joining { get; set; }
         public DateTime Date_of_Birth { get; set; }
         public string perks { get; set; }
         public string Password { get; set; }
         public string Confirm_Password { get; set; }
         public int Sponsor { get; set; }
         public string Name_of_Nominee { get; set; }
         public string Mobile_Number { get; set; }
         public string Pan_Card_Number { get; set; }
         public string Aadhaar_Number { get; set; }
         public string Bank_Name { get; set; }
         public string IFSC_Code { get; set; }
         public string Bank_Account_Number { get; set; }
         public int IsOptingforStar1Autopool { get; set; }
         public int UpgradeAmountPaid { get; set; }

    }
}
