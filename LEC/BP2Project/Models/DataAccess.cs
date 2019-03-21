using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BP2Project.Models
{
    public class DataAccess
    {
        private static LECDBEntities entities = null;

        private DataAccess() { }

        public static LECDBEntities DbAccess
        {
            get
            {
                if (entities == null)
                    entities = new LECDBEntities();
                return entities;
            }
        }

        public static void RefreshDB()
        {
            entities.Dispose();
            entities = new LECDBEntities();
        }
    }
}