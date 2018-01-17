using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TheAgency.Interfaces
{
    interface IHome
    {
        string I_Am { get; set; }
        string Looking_For { get; set; }
        string Location { get; set; }
        IEnumerable<SelectListItem> I_Am_List { get; set; }
        IEnumerable<SelectListItem> Looking_For_List { get; set; }
    }
}
