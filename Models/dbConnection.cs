using System.Configuration;
using System.Web;

namespace TheAgency.Models
{
    public class DbConnection
    {
        private string conn = (HttpContext.Current.Request.IsLocal) ? ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString : ConfigurationManager.ConnectionStrings["liveConnection"].ConnectionString;
        public DataClasses1DataContext Linqcon()
        {
            DataClasses1DataContext taol2s = new DataClasses1DataContext(conn);
            return taol2s;
        }
    }
}