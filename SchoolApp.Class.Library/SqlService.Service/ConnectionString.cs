using System.Configuration;

namespace SqlServer.Service
{
    public static class ConnectionString
    {
        public static string ConnectionStrings
        {
            get { return ConfigurationManager.ConnectionStrings["DatabaseConnect"].ConnectionString; }            
        }
    }
}
