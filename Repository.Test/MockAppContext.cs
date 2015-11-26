using Domain.Models;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Repository.Test
{
    public class MockAppContext : DbContext
    {
        public MockAppContext() 
            : base("Name=MockAppContext") 
        {

        }
        public MockAppContext(bool enableLazyLoading, bool enableProxyCreation) 
            : base("Name=MockAppContext") 
        {
            Configuration.ProxyCreationEnabled = enableProxyCreation;
            Configuration.LazyLoadingEnabled = enableLazyLoading;
        }
        public MockAppContext(DbConnection connection) 
            : base(connection, true) 
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Suppress code first model migration check           
            Database.SetInitializer<MockAppContext>(new AlwaysCreateInitializer());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public void Seed(MockAppContext Context)
        {
            var usuarios = new List<Usuario>()
            {
                new Usuario ( "Renan", "renan", "renan.augusto18@gmail.com", "123456" ),
                new Usuario ( "Renan2", "renan2", "renan.augusto218@gmail.com", "123456" ),
                new Usuario ( "Renan3", "renan3", "renan.augusto318@gmail.com", "123456" ),
                new Usuario ( "Renan4", "renan4", "renan.augusto418@gmail.com", "123456" ),
            }.AsQueryable();

            Context.Usuarios.AddRange(usuarios);
            Context.SaveChanges();
        }

        public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<MockAppContext>
        {
            protected override void Seed(MockAppContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class CreateInitializer : CreateDatabaseIfNotExists<MockAppContext>
        {
            protected override void Seed(MockAppContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class AlwaysCreateInitializer : DropCreateDatabaseAlways<MockAppContext>
        {
            protected override void Seed(MockAppContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }


    }
}
