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
         public string perks { get; set; }

    }
}
