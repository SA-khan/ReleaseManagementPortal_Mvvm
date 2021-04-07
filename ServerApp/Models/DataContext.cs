using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServerApp.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }
        public DbSet<Api> Apis { get; set; }
        public DbSet<AppArchitype> AppArchitypes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<ClientBrowserSupport> ClientBrowserSupport { get; set; }
        public DbSet<ClientBrowser> ClientBrowsers { get; set; }
        public DbSet<Database> Databases { get; set; }
        public DbSet<DatabaseVendor> DatabaseVendors { get; set; }
        public DbSet<DataLogFile> DataLogFiles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Environment> Environments { get; set; }
        public DbSet<EnvironmentType> EnvironmentTypes { get; set; }
        public DbSet<CompanyFinancial> Financials { get; set; }
        public DbSet<HealthCheck> HealthChecks { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<OperatingSystemSupport> OperatingSystemSupport { get; set; }
        public DbSet<OperatingSystem> OperatingSystems { get; set; }
        public DbSet<ParentProduct> ParentProducts { get; set; }
        public DbSet<PasswordPolicy> PasswordPolicies { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPrerequisite> ProductPrerequisites { get; set; }
        public DbSet<QualityAssurance> QualityAssurances { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<ServerType> ServerTypes { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TechnicalVendor> TechnicalVendors { get; set; }
        public DbSet<TechnicalVendorSupport> TechnicalVendorSupport { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WebServer> WebBrowsers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Companies>.
        //}

    }

    

}
