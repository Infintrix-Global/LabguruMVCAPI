using LabGuru.BAL;
using LabGuru.BAL.Component;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.DAL.DataContext
{
  public  class LabGuruDbContext : DbContext
    {
        public LabGuruDbContext()
        {
            //Add-Migration Menu_initiated -context LabGuruDbContext -o "DataContext\dbMigrations"
            //update-database -context LabGuruDbContext
        }
        public LabGuruDbContext(DbContextOptions<LabGuruDbContext> options) : base(options)
        {

        }
        public DbSet<DoctorBySpeciality> DoctorBySpecialities { get; set; }
        public DbSet<DoctorDegree> DoctorDegrees { get; set; }
        public DbSet<DoctorDetails> DoctorDetails { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuRight> MenuRights { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductShade> ProductShades { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ToothNoMaster> ToothNoMasters { get; set; }
        public DbSet<DoctorClinic> DoctorClinics { get; set; }
        public DbSet<Laboratory> Laboratories { get; set; }
        public DbSet<ProcessMaster> ProcessMasters { get; set; }
        public DbSet<OrderStatus> orderStatuses { get; set; }
        public DbSet<DoctorLabMapping> DoctorLabMappings { get; set; }
        public DbSet<ProductSetting> ProductSettings { get; set; }
        public DbSet<OrderStatusMaster> OrderStatusMasters { get; set; }
        public DbSet<DoctorStatusSetting> DoctorStatusSettings { get; set; }
        public DbSet<LabAssignment> LabAssignments { get; set; }
        public DbSet<OrderProcess> OrderProcesses { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<LabEmployee> LabEmployees { get; set; }
        public DbSet<ProductProcessEmployee> ProductProcessEmployees { get; set; }

        public DbSet<SubProcessMaster> SubProcessMasters { get; set; }

        public DbSet<SubProcessEmployee> SubProcessEmployees { get; set; }
        public DbSet<OrderImpression> OrderImpressions { get; set; }

        public DbSet<ProcessStatus> ProcessStatuses { get; set; }

        public DbSet<OrderDetailsByEmployeeProcess> OrderDetailsByEmployeeProcess { get; set; }

        //Might use in future
        //public DbSet<ProcessEmployeeDetail> ProcessEmployeeDetails { get; set; }
        //Might use in future        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=3.7.190.98; user=labguru; database=labguru; password=9LahzjFYfsFfC869; port=3306");
            }
        }
      
    }
}
