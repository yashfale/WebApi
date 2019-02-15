using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HackMeWebApi.Models
{
    public class DbHelper : DbContext
    {
        public DbHelper(): base()
        {
            // Inititialise if required.
        }

        public virtual List<T> ExecuteSql<T>(string query, params object[] paramters)
        {
            var dataList = this.Database.SqlQuery<T>(query, paramters).ToList();
            return dataList;
        }

        public int ExecuteSqlCommand(string query, params object[] paramters)
        {
            int resonse = this.Database.ExecuteSqlCommand(query, paramters);

            return resonse;
        }

    }
}