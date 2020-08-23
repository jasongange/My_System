using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
  public  class AppDomainContextInitializer: IDatabaseInitializer<AppDomainContext>
    {
        public void InitializeDatabase(AppDomainContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("context");
            }
            if (context.Database.Exists())
            {
                throw new ArgumentException("Database does not exist.");
            }
        }

    }
}
