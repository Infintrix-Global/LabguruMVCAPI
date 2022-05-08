﻿// <auto-generated />
using System;
using LabGuru.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    [DbContext(typeof(LabGuruDbContext))]
    [Migration("20220424103634_OrderStatus_Modify")]
    partial class OrderStatus_Modify
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("LabGuru.BAL.DoctorBySpeciality", b =>
                {
                    b.Property<int>("DoctorBySpecialityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<string>("ModifedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("SpecialityID")
                        .HasColumnType("int");

                    b.HasKey("DoctorBySpecialityID");

                    b.ToTable("DoctorBySpecialities");
                });

            modelBuilder.Entity("LabGuru.BAL.DoctorClinic", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClinicAddress")
                        .HasColumnType("text");

                    b.Property<string>("ClinicDist")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ClinicMobileNo")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("ClinicName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ClinicPincode")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ClinicState")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<bool>("isDefault")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("id");

                    b.HasIndex("UserID");

                    b.ToTable("DoctorClinics");
                });

            modelBuilder.Entity("LabGuru.BAL.DoctorDegree", b =>
                {
                    b.Property<int>("DegreeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DegreeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.HasKey("DegreeID");

                    b.HasIndex("DoctorID");

                    b.ToTable("DoctorDegrees");
                });

            modelBuilder.Entity("LabGuru.BAL.DoctorDetails", b =>
                {
                    b.Property<int>("DoctorDetailsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdharCardImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("AdharCardNo")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AreaPin")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("BloodGroup")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<int>("ClinicID")
                        .HasColumnType("int");

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime");

                    b.Property<int>("DoctorTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("IdentityPolicyImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("IdentityPolicyNo")
                        .HasColumnType("text");

                    b.Property<TimeSpan>("InTime")
                        .HasColumnType("time");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsExistUser")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Line1")
                        .HasColumnType("text");

                    b.Property<string>("Line2")
                        .HasColumnType("text");

                    b.Property<int?>("LocationID")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Mobile1")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Mobile2")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("OTP")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<TimeSpan>("OutTime")
                        .HasColumnType("time");

                    b.Property<string>("PanCardImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("PanCardNo")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RegDate")
                        .HasColumnType("datetime");

                    b.Property<string>("RegistrationImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("RegistrationNo")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Residential_Address")
                        .HasColumnType("text");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int?>("StateID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("isTermAccept")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("DoctorDetailsID");

                    b.ToTable("DoctorDetails");
                });

            modelBuilder.Entity("LabGuru.BAL.DoctorLabMapping", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<int>("LabID")
                        .HasColumnType("int");

                    b.Property<bool>("isDefault")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("id");

                    b.HasIndex("DoctorID");

                    b.HasIndex("LabID");

                    b.ToTable("DoctorLabMappings");
                });

            modelBuilder.Entity("LabGuru.BAL.DoctorStatusSetting", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<bool>("Include")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LaboratoryID")
                        .HasColumnType("int");

                    b.Property<bool>("ShowToDoctor")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("StatusMasterID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("DoctorID");

                    b.HasIndex("LaboratoryID");

                    b.HasIndex("StatusMasterID");

                    b.ToTable("DoctorStatusSettings");
                });

            modelBuilder.Entity("LabGuru.BAL.LabAssitant", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LabAddress")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LabName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("id");

                    b.ToTable("Laboratories");
                });

            modelBuilder.Entity("LabGuru.BAL.Login", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("IMEI")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ReferanceID")
                        .HasColumnType("int");

                    b.Property<int>("ReferanceType")
                        .HasColumnType("int");

                    b.Property<string>("RoleID")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("UserID");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("LabGuru.BAL.Menu", b =>
                {
                    b.Property<int>("MenuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MenuIcon")
                        .HasColumnType("text");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("orderno")
                        .HasColumnType("int");

                    b.HasKey("MenuID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("LabGuru.BAL.MenuRight", b =>
                {
                    b.Property<int>("MenuRightID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MenuID")
                        .HasColumnType("int");

                    b.Property<bool>("Page_Add")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Page_Delete")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Page_Edit")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Page_View")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RoleID")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("MenuRightID");

                    b.ToTable("MenuRights");
                });

            modelBuilder.Entity("LabGuru.BAL.OrderDetails", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ClinicID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatorIP")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("CurrentOrderStatusID")
                        .HasColumnType("int");

                    b.Property<int?>("LaboratiryID")
                        .HasColumnType("int");

                    b.Property<string>("OrderNumber")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("PatientAge")
                        .HasColumnType("int");

                    b.Property<string>("PatientGender")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PatientName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ProcessID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatorIP")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("ClinicID");

                    b.HasIndex("CurrentOrderStatusID");

                    b.HasIndex("LaboratiryID");

                    b.HasIndex("ProcessID");

                    b.HasIndex("UserID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("LabGuru.BAL.ProcessMaster", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ProcessName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("id");

                    b.ToTable("ProcessMasters");
                });

            modelBuilder.Entity("LabGuru.BAL.OrderStatus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("OrderStatusMasterID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("OrderID");

                    b.HasIndex("OrderStatusMasterID");

                    b.ToTable("orderStatuses");
                });

            modelBuilder.Entity("LabGuru.BAL.OrderStatusMaster", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int>("DispalyOrder")
                        .HasColumnType("int");

                    b.Property<int>("LaboratoryID")
                        .HasColumnType("int");

                    b.Property<string>("StatusText")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("id");

                    b.HasIndex("LaboratoryID");

                    b.ToTable("OrderStatusMasters");
                });

            modelBuilder.Entity("LabGuru.BAL.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("CGST")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatorIP")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ProductCode")
                        .HasColumnType("int");

                    b.Property<string>("ProductImagePath")
                        .HasColumnType("text");

                    b.Property<int>("ProductMaterialID")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ProductShadeID")
                        .HasColumnType("int");

                    b.Property<int>("ProductSizeID")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeID")
                        .HasColumnType("int");

                    b.Property<decimal>("SGST")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatorIP")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("LabGuru.BAL.ProductMaterial", b =>
                {
                    b.Property<int>("ProductMaterialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatorIP")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProductMatrialName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatorIP")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ProductMaterialID");

                    b.ToTable("ProductMaterials");
                });

            modelBuilder.Entity("LabGuru.BAL.ProductOrder", b =>
                {
                    b.Property<int>("ProductOrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("CGST")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatorIP")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Field1")
                        .HasColumnType("text");

                    b.Property<string>("Field2")
                        .HasColumnType("text");

                    b.Property<string>("Field3")
                        .HasColumnType("text");

                    b.Property<string>("Field4")
                        .HasColumnType("text");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("ProductMaterialID")
                        .HasColumnType("int");

                    b.Property<int?>("ProductShadeID")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SGST")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ToothSelection")
                        .HasColumnType("text");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatorIP")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ProductOrderID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductMaterialID");

                    b.HasIndex("ProductShadeID");

                    b.HasIndex("ProductTypeID");

                    b.HasIndex("UserID");

                    b.ToTable("ProductOrders");
                });

            modelBuilder.Entity("LabGuru.BAL.ProductSetting", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DeliveryDays")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductSettings");
                });

            modelBuilder.Entity("LabGuru.BAL.ProductShade", b =>
                {
                    b.Property<int>("ProductShadeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatorIP")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProductShadeName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatorIP")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ProductShadeID");

                    b.ToTable("ProductShades");
                });

            modelBuilder.Entity("LabGuru.BAL.ProductSize", b =>
                {
                    b.Property<int>("ProductSizeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatorIP")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProductSizeName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatorIP")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ProductSizeID");

                    b.ToTable("ProductSizes");
                });

            modelBuilder.Entity("LabGuru.BAL.ProductType", b =>
                {
                    b.Property<int>("ProductTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatorIP")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("ProductTypeImagePath")
                        .HasColumnType("text");

                    b.Property<string>("ProductTypeName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatorIP")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<bool>("isImpressionMindatory")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ProductTypeID");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("LabGuru.BAL.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("LabGuru.BAL.ToothNoMaster", b =>
                {
                    b.Property<int>("toothID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("toothNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("toothID");

                    b.ToTable("ToothNoMasters");
                });

            modelBuilder.Entity("LabGuru.BAL.DoctorClinic", b =>
                {
                    b.HasOne("LabGuru.BAL.Login", "loginuser")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("loginuser");
                });

            modelBuilder.Entity("LabGuru.BAL.DoctorDegree", b =>
                {
                    b.HasOne("LabGuru.BAL.DoctorDetails", "DoctorDetails")
                        .WithMany("DoctorDegrees")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoctorDetails");
                });

            modelBuilder.Entity("LabGuru.BAL.DoctorLabMapping", b =>
                {
                    b.HasOne("LabGuru.BAL.DoctorDetails", "doctorDetails")
                        .WithMany()
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabGuru.BAL.LabAssitant", "laboratory")
                        .WithMany()
                        .HasForeignKey("LabID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doctorDetails");

                    b.Navigation("laboratory");
                });

            modelBuilder.Entity("LabGuru.BAL.DoctorStatusSetting", b =>
                {
                    b.HasOne("LabGuru.BAL.DoctorDetails", "doctorDetails")
                        .WithMany()
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabGuru.BAL.LabAssitant", "laboratory")
                        .WithMany()
                        .HasForeignKey("LaboratoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabGuru.BAL.OrderStatusMaster", "StatusMaster")
                        .WithMany()
                        .HasForeignKey("StatusMasterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doctorDetails");

                    b.Navigation("laboratory");

                    b.Navigation("StatusMaster");
                });

            modelBuilder.Entity("LabGuru.BAL.OrderDetails", b =>
                {
                    b.HasOne("LabGuru.BAL.DoctorClinic", "doctorClinic")
                        .WithMany()
                        .HasForeignKey("ClinicID");

                    b.HasOne("LabGuru.BAL.OrderStatusMaster", "OrderStatusMast")
                        .WithMany()
                        .HasForeignKey("CurrentOrderStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabGuru.BAL.LabAssitant", "laboratory")
                        .WithMany()
                        .HasForeignKey("LaboratiryID");

                    b.HasOne("LabGuru.BAL.ProcessMaster", "orderProcessMaster")
                        .WithMany()
                        .HasForeignKey("ProcessID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabGuru.BAL.Login", "loginuser")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doctorClinic");

                    b.Navigation("laboratory");

                    b.Navigation("loginuser");

                    b.Navigation("orderProcessMaster");

                    b.Navigation("OrderStatusMast");
                });

            modelBuilder.Entity("LabGuru.BAL.OrderStatus", b =>
                {
                    b.HasOne("LabGuru.BAL.OrderDetails", "orderDetails")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabGuru.BAL.OrderStatusMaster", "statusMaster")
                        .WithMany()
                        .HasForeignKey("OrderStatusMasterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("orderDetails");

                    b.Navigation("statusMaster");
                });

            modelBuilder.Entity("LabGuru.BAL.OrderStatusMaster", b =>
                {
                    b.HasOne("LabGuru.BAL.LabAssitant", "laboratory")
                        .WithMany()
                        .HasForeignKey("LaboratoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("laboratory");
                });

            modelBuilder.Entity("LabGuru.BAL.ProductOrder", b =>
                {
                    b.HasOne("LabGuru.BAL.OrderDetails", "orderDetails")
                        .WithMany("ProductOrders")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabGuru.BAL.ProductMaterial", "productMaterial")
                        .WithMany()
                        .HasForeignKey("ProductMaterialID");

                    b.HasOne("LabGuru.BAL.ProductShade", "productShade")
                        .WithMany()
                        .HasForeignKey("ProductShadeID");

                    b.HasOne("LabGuru.BAL.ProductType", "productType")
                        .WithMany()
                        .HasForeignKey("ProductTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabGuru.BAL.Login", "login")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("login");

                    b.Navigation("orderDetails");

                    b.Navigation("productMaterial");

                    b.Navigation("productShade");

                    b.Navigation("productType");
                });

            modelBuilder.Entity("LabGuru.BAL.ProductSetting", b =>
                {
                    b.HasOne("LabGuru.BAL.ProductType", "productType")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("productType");
                });

            modelBuilder.Entity("LabGuru.BAL.DoctorDetails", b =>
                {
                    b.Navigation("DoctorDegrees");
                });

            modelBuilder.Entity("LabGuru.BAL.OrderDetails", b =>
                {
                    b.Navigation("ProductOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
