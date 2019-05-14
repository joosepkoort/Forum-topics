using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Helpers;
using Domain;
using Interfaces;

namespace DAL
{
    public class AppDbContext : DbContext, IAppDataContext  
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ForumTopic> ForumTopics { get; set; }

        public AppDbContext() : base(nameOrConnectionString: "name = DemoConnectionString")
        {
            Database.SetInitializer(strategy: new DbInitializator());

#if DEBUG
            Database.Log = s => Trace.Write(message: s.Contains(value: "SELECT") ? s : "");
#else
            Database.Log = s => Console.WriteLine(s.Contains("SELECT") ? s : "");
#endif


        }

    }
}
