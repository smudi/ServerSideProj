using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository
{
	public class DataSource
	{
        static public string getConnectionString(string name)
        {
            return System.Web.Configuration.WebConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}