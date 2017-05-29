using System.Data.Common;
using Abp.Zero.EntityFramework;
using RIA.Train.Authorization.Roles;
using RIA.Train.MultiTenancy;
using RIA.Train.Users;
using System.Data.Entity;

namespace RIA.Train.EntityFramework
{
    public class TrainDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        public IDbSet<Entities.T_Item> T_Item { get; set; }

        public IDbSet<Entities.T_KPoint> T_KPoint { get; set; }

        public IDbSet<Entities.T_HClass> T_HClass { get; set; }

        public IDbSet<Entities.T_Group> T_Group { get; set; }

        public IDbSet<Entities.T_Grade> T_Grade { get; set; }

        public IDbSet<Entities.T_Estimate_Detail> T_Estimate_Detail { get; set; }

        public IDbSet<Entities.T_Estimate> T_Estimate { get; set; }

        public IDbSet<Entities.T_Dep> T_Dep { get; set; }

        public IDbSet<Entities.T_Content> T_Content { get; set; }

        public IDbSet<Entities.T_Class> T_Class { get; set; }

        public IDbSet<Entities.T_CInfo> T_CInfo { get; set; }

        public IDbSet<Entities.T_Require> T_Require { get; set; }

        public IDbSet<Entities.T_Staff> T_Staff { get; set; }

       public IDbSet<Entities.T_User> T_User { get; set; }


        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public TrainDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in TrainDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of TrainDbContext since ABP automatically handles it.
         */
        public TrainDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public TrainDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public TrainDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
