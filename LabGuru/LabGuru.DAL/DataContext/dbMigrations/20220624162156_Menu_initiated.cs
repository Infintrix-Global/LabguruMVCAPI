using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class Menu_initiated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorBySpecialities",
                columns: table => new
                {
                    DoctorBySpecialityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    SpecialityID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorBySpecialities", x => x.DoctorBySpecialityID);
                });

            migrationBuilder.CreateTable(
                name: "DoctorDetails",
                columns: table => new
                {
                    DoctorDetailsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DoctorTypeID = table.Column<int>(type: "int", nullable: false),
                    ClinicID = table.Column<int>(type: "int", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    BloodGroup = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Mobile1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Mobile2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Residential_Address = table.Column<string>(type: "text", nullable: true),
                    Line1 = table.Column<string>(type: "text", nullable: true),
                    Line2 = table.Column<string>(type: "text", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: true),
                    StateID = table.Column<int>(type: "int", nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OTP = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AreaPin = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegistrationNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PanCardNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PanCardImageUrl = table.Column<string>(type: "text", nullable: true),
                    AdharCardNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    AdharCardImageUrl = table.Column<string>(type: "text", nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "text", nullable: true),
                    RegistrationImageUrl = table.Column<string>(type: "text", nullable: true),
                    IdentityPolicyNo = table.Column<string>(type: "text", nullable: true),
                    IdentityPolicyImageUrl = table.Column<string>(type: "text", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    InTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    OutTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsExistUser = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    isTermAccept = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDetails", x => x.DoctorDetailsID);
                });

            migrationBuilder.CreateTable(
                name: "Laboratories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LabName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LabAddress = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MenuName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Path = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    orderno = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MenuIcon = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuID);
                });

            migrationBuilder.CreateTable(
                name: "ProductMaterials",
                columns: table => new
                {
                    ProductMaterialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductMatrialName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatorIP = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UpdatorIP = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMaterials", x => x.ProductMaterialID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductTypeID = table.Column<int>(type: "int", nullable: false),
                    ProductMaterialID = table.Column<int>(type: "int", nullable: false),
                    ProductSizeID = table.Column<int>(type: "int", nullable: false),
                    ProductShadeID = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ProductCode = table.Column<int>(type: "int", nullable: false),
                    ProductImagePath = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CGST = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SGST = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatorIP = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UpdatorIP = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "ProductShades",
                columns: table => new
                {
                    ProductShadeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductShadeName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatorIP = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UpdatorIP = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShades", x => x.ProductShadeID);
                });

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    ProductSizeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductSizeName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatorIP = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UpdatorIP = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => x.ProductSizeID);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductTypeName = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    ProductTypeImagePath = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatorIP = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    UpdatorIP = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    isImpressionMindatory = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "ToothNoMasters",
                columns: table => new
                {
                    toothID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    toothNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToothNoMasters", x => x.toothID);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserTypeName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "DoctorDegrees",
                columns: table => new
                {
                    DegreeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DegreeName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDegrees", x => x.DegreeID);
                    table.ForeignKey(
                        name: "FK_DoctorDegrees_DoctorDetails_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "DoctorDetails",
                        principalColumn: "DoctorDetailsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorLabMappings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    LabID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    isDefault = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorLabMappings", x => x.id);
                    table.ForeignKey(
                        name: "FK_DoctorLabMappings_DoctorDetails_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "DoctorDetails",
                        principalColumn: "DoctorDetailsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorLabMappings_Laboratories_LabID",
                        column: x => x.LabID,
                        principalTable: "Laboratories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabEmployees",
                columns: table => new
                {
                    LabEmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LabID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabEmployees", x => x.LabEmployeeID);
                    table.ForeignKey(
                        name: "FK_LabEmployees_Laboratories_LabID",
                        column: x => x.LabID,
                        principalTable: "Laboratories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatusMasters",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LaboratoryID = table.Column<int>(type: "int", nullable: false),
                    StatusText = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    DispalyOrder = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatusMasters", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderStatusMasters_Laboratories_LaboratoryID",
                        column: x => x.LaboratoryID,
                        principalTable: "Laboratories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessMasters",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProcessName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessMasters", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProcessMasters_ProductTypes_ProductID",
                        column: x => x.ProductID,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSettings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    DeliveryDays = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSettings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductSettings_ProductTypes_ProductID",
                        column: x => x.ProductID,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RoleID = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    isActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ReferanceID = table.Column<int>(type: "int", nullable: false),
                    IMEI = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Logins_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuRights",
                columns: table => new
                {
                    MenuRightID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Page_Add = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Page_Edit = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Page_Delete = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Page_View = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRights", x => x.MenuRightID);
                    table.ForeignKey(
                        name: "FK_MenuRights_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorStatusSettings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LaboratoryID = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    StatusMasterID = table.Column<int>(type: "int", nullable: false),
                    Include = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ShowToDoctor = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorStatusSettings", x => x.id);
                    table.ForeignKey(
                        name: "FK_DoctorStatusSettings_DoctorDetails_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "DoctorDetails",
                        principalColumn: "DoctorDetailsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorStatusSettings_Laboratories_LaboratoryID",
                        column: x => x.LaboratoryID,
                        principalTable: "Laboratories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorStatusSettings_OrderStatusMasters_StatusMasterID",
                        column: x => x.StatusMasterID,
                        principalTable: "OrderStatusMasters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProcessEmployees",
                columns: table => new
                {
                    ProductProcessEmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductTypeID = table.Column<int>(type: "int", nullable: false),
                    ProcessID = table.Column<int>(type: "int", nullable: false),
                    LabID = table.Column<int>(type: "int", nullable: false),
                    LabEmployeeID = table.Column<int>(type: "int", nullable: false),
                    LabEmployee = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProcessEmployees", x => x.ProductProcessEmployeeID);
                    table.ForeignKey(
                        name: "FK_ProductProcessEmployees_LabEmployees_LabEmployee",
                        column: x => x.LabEmployee,
                        principalTable: "LabEmployees",
                        principalColumn: "LabEmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductProcessEmployees_Laboratories_LabID",
                        column: x => x.LabID,
                        principalTable: "Laboratories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProcessEmployees_ProcessMasters_ProcessID",
                        column: x => x.ProcessID,
                        principalTable: "ProcessMasters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProcessEmployees_ProductTypes_ProductTypeID",
                        column: x => x.ProductTypeID,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubProcessMasters",
                columns: table => new
                {
                    SubProcessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProcessID = table.Column<int>(type: "int", nullable: false),
                    SubProcessName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProcessMasters", x => x.SubProcessID);
                    table.ForeignKey(
                        name: "FK_SubProcessMasters_ProcessMasters_ProcessID",
                        column: x => x.ProcessID,
                        principalTable: "ProcessMasters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorClinics",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ClinicName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ClinicMobileNo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    ClinicAddress = table.Column<string>(type: "text", nullable: true),
                    ClinicPincode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ClinicDist = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ClinicState = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    isDefault = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorClinics", x => x.id);
                    table.ForeignKey(
                        name: "FK_DoctorClinics_Logins_UserID",
                        column: x => x.UserID,
                        principalTable: "Logins",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubProcessEmployees",
                columns: table => new
                {
                    SubProcessEmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SubProcessID = table.Column<int>(type: "int", nullable: false),
                    LabEmployeeID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProcessEmployees", x => x.SubProcessEmployeeID);
                    table.ForeignKey(
                        name: "FK_SubProcessEmployees_LabEmployees_LabEmployeeID",
                        column: x => x.LabEmployeeID,
                        principalTable: "LabEmployees",
                        principalColumn: "LabEmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubProcessEmployees_SubProcessMasters_SubProcessID",
                        column: x => x.SubProcessID,
                        principalTable: "SubProcessMasters",
                        principalColumn: "SubProcessID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PatientName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PatientGender = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PatientAge = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatorIP = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UpdatorIP = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ClinicID = table.Column<int>(type: "int", nullable: true),
                    LaboratiryID = table.Column<int>(type: "int", nullable: true),
                    ProcessID = table.Column<int>(type: "int", nullable: false),
                    CurrentOrderStatusID = table.Column<int>(type: "int", nullable: false),
                    isAccepted = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_DoctorClinics_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "DoctorClinics",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Laboratories_LaboratiryID",
                        column: x => x.LaboratiryID,
                        principalTable: "Laboratories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Logins_UserID",
                        column: x => x.UserID,
                        principalTable: "Logins",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderStatusMasters_CurrentOrderStatusID",
                        column: x => x.CurrentOrderStatusID,
                        principalTable: "OrderStatusMasters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_ProcessMasters_ProcessID",
                        column: x => x.ProcessID,
                        principalTable: "ProcessMasters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabAssignments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ParentLabID = table.Column<int>(type: "int", nullable: false),
                    ChildLabID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabAssignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_LabAssignments_Laboratories_ChildLabID",
                        column: x => x.ChildLabID,
                        principalTable: "Laboratories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabAssignments_Laboratories_ParentLabID",
                        column: x => x.ParentLabID,
                        principalTable: "Laboratories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabAssignments_OrderDetails_OrderID",
                        column: x => x.OrderID,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderImpressions",
                columns: table => new
                {
                    OrderImpressionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderImpressions", x => x.OrderImpressionID);
                    table.ForeignKey(
                        name: "FK_OrderImpressions_OrderDetails_OrderID",
                        column: x => x.OrderID,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProcesses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProcessMasterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProcesses", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderProcesses_OrderDetails_OrderID",
                        column: x => x.OrderID,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProcesses_ProcessMasters_ProcessMasterID",
                        column: x => x.ProcessMasterID,
                        principalTable: "ProcessMasters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderStatuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    OrderStatusMasterID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderStatuses", x => x.id);
                    table.ForeignKey(
                        name: "FK_orderStatuses_OrderDetails_OrderID",
                        column: x => x.OrderID,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderStatuses_OrderStatusMasters_OrderStatusMasterID",
                        column: x => x.OrderStatusMasterID,
                        principalTable: "OrderStatusMasters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    ProductOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ProductTypeID = table.Column<int>(type: "int", nullable: false),
                    ProductMaterialID = table.Column<int>(type: "int", nullable: true),
                    ProductShadeID = table.Column<int>(type: "int", nullable: true),
                    ToothSelection = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CGST = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SGST = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatorIP = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UpdatorIP = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Field1 = table.Column<string>(type: "text", nullable: true),
                    Field2 = table.Column<string>(type: "text", nullable: true),
                    Field3 = table.Column<string>(type: "text", nullable: true),
                    Field4 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => x.ProductOrderID);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Logins_UserID",
                        column: x => x.UserID,
                        principalTable: "Logins",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrders_OrderDetails_OrderID",
                        column: x => x.OrderID,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrders_ProductMaterials_ProductMaterialID",
                        column: x => x.ProductMaterialID,
                        principalTable: "ProductMaterials",
                        principalColumn: "ProductMaterialID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOrders_ProductShades_ProductShadeID",
                        column: x => x.ProductShadeID,
                        principalTable: "ProductShades",
                        principalColumn: "ProductShadeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOrders_ProductTypes_ProductTypeID",
                        column: x => x.ProductTypeID,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorClinics_UserID",
                table: "DoctorClinics",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDegrees_DoctorID",
                table: "DoctorDegrees",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorLabMappings_DoctorID",
                table: "DoctorLabMappings",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorLabMappings_LabID",
                table: "DoctorLabMappings",
                column: "LabID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorStatusSettings_DoctorID",
                table: "DoctorStatusSettings",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorStatusSettings_LaboratoryID",
                table: "DoctorStatusSettings",
                column: "LaboratoryID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorStatusSettings_StatusMasterID",
                table: "DoctorStatusSettings",
                column: "StatusMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_LabAssignments_ChildLabID",
                table: "LabAssignments",
                column: "ChildLabID");

            migrationBuilder.CreateIndex(
                name: "IX_LabAssignments_OrderID",
                table: "LabAssignments",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_LabAssignments_ParentLabID",
                table: "LabAssignments",
                column: "ParentLabID");

            migrationBuilder.CreateIndex(
                name: "IX_LabEmployees_LabID",
                table: "LabEmployees",
                column: "LabID");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_RoleID",
                table: "Logins",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRights_RoleID",
                table: "MenuRights",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ClinicID",
                table: "OrderDetails",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CurrentOrderStatusID",
                table: "OrderDetails",
                column: "CurrentOrderStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LaboratiryID",
                table: "OrderDetails",
                column: "LaboratiryID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProcessID",
                table: "OrderDetails",
                column: "ProcessID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UserID",
                table: "OrderDetails",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderImpressions_OrderID",
                table: "OrderImpressions",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProcesses_OrderID",
                table: "OrderProcesses",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProcesses_ProcessMasterID",
                table: "OrderProcesses",
                column: "ProcessMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_orderStatuses_OrderID",
                table: "orderStatuses",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_orderStatuses_OrderStatusMasterID",
                table: "orderStatuses",
                column: "OrderStatusMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatusMasters_LaboratoryID",
                table: "OrderStatusMasters",
                column: "LaboratoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessMasters_ProductID",
                table: "ProcessMasters",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_OrderID",
                table: "ProductOrders",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ProductMaterialID",
                table: "ProductOrders",
                column: "ProductMaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ProductShadeID",
                table: "ProductOrders",
                column: "ProductShadeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ProductTypeID",
                table: "ProductOrders",
                column: "ProductTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_UserID",
                table: "ProductOrders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProcessEmployees_LabEmployee",
                table: "ProductProcessEmployees",
                column: "LabEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProcessEmployees_LabID",
                table: "ProductProcessEmployees",
                column: "LabID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProcessEmployees_ProcessID",
                table: "ProductProcessEmployees",
                column: "ProcessID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProcessEmployees_ProductTypeID",
                table: "ProductProcessEmployees",
                column: "ProductTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSettings_ProductID",
                table: "ProductSettings",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SubProcessEmployees_LabEmployeeID",
                table: "SubProcessEmployees",
                column: "LabEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_SubProcessEmployees_SubProcessID",
                table: "SubProcessEmployees",
                column: "SubProcessID");

            migrationBuilder.CreateIndex(
                name: "IX_SubProcessMasters_ProcessID",
                table: "SubProcessMasters",
                column: "ProcessID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorBySpecialities");

            migrationBuilder.DropTable(
                name: "DoctorDegrees");

            migrationBuilder.DropTable(
                name: "DoctorLabMappings");

            migrationBuilder.DropTable(
                name: "DoctorStatusSettings");

            migrationBuilder.DropTable(
                name: "LabAssignments");

            migrationBuilder.DropTable(
                name: "MenuRights");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "OrderImpressions");

            migrationBuilder.DropTable(
                name: "OrderProcesses");

            migrationBuilder.DropTable(
                name: "orderStatuses");

            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "ProductProcessEmployees");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductSettings");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropTable(
                name: "SubProcessEmployees");

            migrationBuilder.DropTable(
                name: "ToothNoMasters");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "DoctorDetails");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductMaterials");

            migrationBuilder.DropTable(
                name: "ProductShades");

            migrationBuilder.DropTable(
                name: "LabEmployees");

            migrationBuilder.DropTable(
                name: "SubProcessMasters");

            migrationBuilder.DropTable(
                name: "DoctorClinics");

            migrationBuilder.DropTable(
                name: "OrderStatusMasters");

            migrationBuilder.DropTable(
                name: "ProcessMasters");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Laboratories");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
