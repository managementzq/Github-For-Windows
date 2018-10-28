using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Provider.EntityFramework.BaseClass
{
    public class TianyueDbContext : DbContext
    {
        //public TianyueDbContext()
        //{
        //    string strDatabaseConnection = System.Configuration.ConfigurationManager.ConnectionStrings["Tianyue"].ConnectionString;
        //    base.Database.Connection.ConnectionString = strDatabaseConnection;
        //}
        
        static TianyueDbContext()
        {
            System.Data.Entity.Database.SetInitializer<TianyueDbContext>(null);
        }

        public TianyueDbContext() : base("Name=Tianyue")
        {
        }


        //public virtual DbSet<UserView> WOs { get; set; }
        public new IDbSet<Generic> Set<Generic>() where Generic : class
        {
            return base.Set<Generic>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //程序集筛选条件
            string mapSuffix = "." + "SqlServer";//ConvertProviderNameToSuffix(defaultConnectStr.ProviderName);

            ////获取包含当前执行的代码的程序集(Tianyue.Provider.EntityFramework.Tianyue)
            //var all = Assembly.GetExecutingAssembly().GetTypes();

            //获取命名空间下的所有程序集（（Mapping信息））
            Type[] typeNamespaceAssembly = Assembly.Load("Tianyue.Mapping").GetTypes();
            //var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            var typesToRegister = typeNamespaceAssembly
                .Where(type => type.Namespace != null)
                .Where(type => type.Namespace.EndsWith(mapSuffix, StringComparison.OrdinalIgnoreCase))
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                    && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            //根据Mapping实例化数据
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
