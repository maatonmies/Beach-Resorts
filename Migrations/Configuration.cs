using System.Collections.Generic;
using HoidayResorts.Data_Entities;
using HoidayResorts.Models;

namespace HoidayResorts.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HoidayResorts.DataContexts.HolidayResortsDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
            ContextKey = "HoidayResorts.DataContexts.HolidayResortsDb";
        }

        protected override void Seed(HoidayResorts.DataContexts.HolidayResortsDb context)
        {
           
        }
    }
}
