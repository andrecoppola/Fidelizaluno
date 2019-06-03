using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FCNuvem.FidelizaAluno.Infraestructure.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cep = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Region = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Number = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    City = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    State = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Latitude = table.Column<decimal>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Time = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    PersonId = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Data = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Title = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reason",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Template",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Template = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institution",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    TradingName = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Cnpj = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Telephone = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Email = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Media = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    IdAddress = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institution_Address_IdAddress",
                        column: x => x.IdAddress,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Email = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    TelephoneCelular = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    TelephoneResidencial = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    RA = table.Column<int>(nullable: true),
                    Genre = table.Column<string>(nullable: false),
                    Overdue = table.Column<bool>(nullable: true),
                    UrlPicture = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    ReasonEvasao = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    IdAddress = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Address_IdAddress",
                        column: x => x.IdAddress,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdPerfil = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Login_Perfil_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReasonHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdReason = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReasonHistory_Reason_IdReason",
                        column: x => x.IdReason,
                        principalTable: "Reason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wanted",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Name = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    IdReason = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wanted", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wanted_Reason_IdReason",
                        column: x => x.IdReason,
                        principalTable: "Reason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alert",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdReason = table.Column<int>(nullable: false),
                    Email = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    IdTemplate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alert_Reason_IdReason",
                        column: x => x.IdReason,
                        principalTable: "Reason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alert_Template_IdTemplate",
                        column: x => x.IdTemplate,
                        principalTable: "Template",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Campus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Cnpj = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Telephone = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Email = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    CampusType = table.Column<int>(nullable: false),
                    IdInstitution = table.Column<int>(nullable: true),
                    IdInstituition = table.Column<int>(nullable: false),
                    IdAddress = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campus_Address_IdAddress",
                        column: x => x.IdAddress,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campus_Institution_IdInstitution",
                        column: x => x.IdInstitution,
                        principalTable: "Institution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RA = table.Column<int>(nullable: false),
                    EvasionChance = table.Column<decimal>(nullable: false),
                    PaymentDay = table.Column<int>(nullable: false),
                    LastPaymentDate = table.Column<DateTime>(nullable: false),
                    AmountPaymentPendent = table.Column<int>(nullable: false),
                    Distance = table.Column<decimal>(nullable: false),
                    MediaScore = table.Column<decimal>(nullable: false),
                    IdPerson = table.Column<int>(nullable: false),
                    ReasonEvasion = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdRole = table.Column<int>(nullable: false),
                    IdLogin = table.Column<int>(nullable: false),
                    IdPerson = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Login_IdLogin",
                        column: x => x.IdLogin,
                        principalTable: "Login",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Role_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvasionHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdStudent = table.Column<int>(nullable: false),
                    Percentual = table.Column<decimal>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvasionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvasionHistory_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCourse = table.Column<int>(nullable: false),
                    IdStudent = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Half = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Score_Course_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Score_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCampus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEmployee = table.Column<int>(nullable: false),
                    IdCampus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCampus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCampus_Campus_IdCampus",
                        column: x => x.IdCampus,
                        principalTable: "Campus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeCampus_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCourse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEmployee = table.Column<int>(nullable: false),
                    IdCourse = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCourse_Course_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeCourse_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Load = table.Column<int>(nullable: false),
                    IdCoordinator = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Program_Employee_IdCoordinator",
                        column: x => x.IdCoordinator,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisplayName = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Email = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Password = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    IdEmployee = table.Column<int>(nullable: false),
                    IdPerfil = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Perfil_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReasonEvasion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdReason = table.Column<int>(nullable: false),
                    IdEvasionHistory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonEvasion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReasonEvasion_EvasionHistory_IdEvasionHistory",
                        column: x => x.IdEvasionHistory,
                        principalTable: "EvasionHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReasonEvasion_Reason_IdReason",
                        column: x => x.IdReason,
                        principalTable: "Reason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampusProgram",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCampus = table.Column<int>(nullable: false),
                    IdProgram = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampusProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampusProgram_Campus_IdCampus",
                        column: x => x.IdCampus,
                        principalTable: "Campus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampusProgram_Program_IdProgram",
                        column: x => x.IdProgram,
                        principalTable: "Program",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassRoom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Half = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    DataInicial = table.Column<DateTime>(nullable: false),
                    IdProgram = table.Column<int>(nullable: false),
                    IdEmployee = table.Column<int>(nullable: false),
                    IdPeriod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassRoom_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassRoom_Period_IdPeriod",
                        column: x => x.IdPeriod,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassRoom_Program_IdProgram",
                        column: x => x.IdProgram,
                        principalTable: "Program",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassRoomStudent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdStudent = table.Column<int>(nullable: false),
                    IdClassRoom = table.Column<int>(nullable: false),
                    ProgramEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoomStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassRoomStudent_ClassRoom_IdClassRoom",
                        column: x => x.IdClassRoom,
                        principalTable: "ClassRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassRoomStudent_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassRoomStudent_Program_ProgramEntityId",
                        column: x => x.ProgramEntityId,
                        principalTable: "Program",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCourse = table.Column<int>(nullable: false),
                    IdClassRoom = table.Column<int>(nullable: true),
                    IdClass = table.Column<int>(nullable: false),
                    IdEmployee = table.Column<int>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    Load = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Degree_ClassRoom_IdClassRoom",
                        column: x => x.IdClassRoom,
                        principalTable: "ClassRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Degree_Course_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Degree_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<decimal>(nullable: false),
                    IdClassRoom = table.Column<int>(nullable: true),
                    IdClass = table.Column<int>(nullable: false),
                    IdStudent = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_ClassRoom_IdClassRoom",
                        column: x => x.IdClassRoom,
                        principalTable: "ClassRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdGrade = table.Column<int>(nullable: false),
                    GradeId = table.Column<int>(nullable: true),
                    ClassDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<TimeSpan>(nullable: false),
                    EndDate = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_Degree_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Degree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Presence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdClassRoom = table.Column<int>(nullable: true),
                    IdClass = table.Column<int>(nullable: false),
                    IdDegree = table.Column<int>(nullable: false),
                    IdStudent = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Presence = table.Column<bool>(nullable: false),
                    Period = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presence_ClassRoom_IdClassRoom",
                        column: x => x.IdClassRoom,
                        principalTable: "ClassRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Presence_Degree_IdDegree",
                        column: x => x.IdDegree,
                        principalTable: "Degree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Presence_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassDiary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdClass = table.Column<int>(nullable: false),
                    IdEmployee = table.Column<int>(nullable: false),
                    IdStudent = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Observation = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    CourseEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassDiary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassDiary_Course_CourseEntityId",
                        column: x => x.CourseEntityId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassDiary_Class_IdClass",
                        column: x => x.IdClass,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassDiary_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassDiary_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PersonType",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Aluno" });

            migrationBuilder.InsertData(
                table: "PersonType",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Professor" });

            migrationBuilder.CreateIndex(
                name: "IX_IdReason",
                table: "Alert",
                column: "IdReason");

            migrationBuilder.CreateIndex(
                name: "IX_IdTemplate",
                table: "Alert",
                column: "IdTemplate");

            migrationBuilder.CreateIndex(
                name: "IX_IdAddress",
                table: "Campus",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_IdInstitution",
                table: "Campus",
                column: "IdInstitution");

            migrationBuilder.CreateIndex(
                name: "IX_IdCampus",
                table: "CampusProgram",
                column: "IdCampus");

            migrationBuilder.CreateIndex(
                name: "IX_IdProgram",
                table: "CampusProgram",
                column: "IdProgram");

            migrationBuilder.CreateIndex(
                name: "IX_GradeId",
                table: "Class",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEntityId",
                table: "ClassDiary",
                column: "CourseEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdClass",
                table: "ClassDiary",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_IdEmployee",
                table: "ClassDiary",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_IdStudent",
                table: "ClassDiary",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_IdEmployee",
                table: "ClassRoom",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_IdPeriod",
                table: "ClassRoom",
                column: "IdPeriod");

            migrationBuilder.CreateIndex(
                name: "IX_IdProgram",
                table: "ClassRoom",
                column: "IdProgram");

            migrationBuilder.CreateIndex(
                name: "IX_IdClassRoom",
                table: "ClassRoomStudent",
                column: "IdClassRoom");

            migrationBuilder.CreateIndex(
                name: "IX_IdStudent",
                table: "ClassRoomStudent",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramEntityId",
                table: "ClassRoomStudent",
                column: "ProgramEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdClassRoom",
                table: "Degree",
                column: "IdClassRoom");

            migrationBuilder.CreateIndex(
                name: "IX_IdCourse",
                table: "Degree",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_IdEmployee",
                table: "Degree",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_IdLogin",
                table: "Employee",
                column: "IdLogin");

            migrationBuilder.CreateIndex(
                name: "IX_IdPerson",
                table: "Employee",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_IdRole",
                table: "Employee",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_IdCampus",
                table: "EmployeeCampus",
                column: "IdCampus");

            migrationBuilder.CreateIndex(
                name: "IX_IdEmployee",
                table: "EmployeeCampus",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_IdCourse",
                table: "EmployeeCourse",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_IdEmployee",
                table: "EmployeeCourse",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_IdStudent",
                table: "EvasionHistory",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_IdAddress",
                table: "Institution",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_IdPerfil",
                table: "Login",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_IdClassRoom",
                table: "Payment",
                column: "IdClassRoom");

            migrationBuilder.CreateIndex(
                name: "IX_IdStudent",
                table: "Payment",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_IdAddress",
                table: "Person",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_IdClassRoom",
                table: "Presence",
                column: "IdClassRoom");

            migrationBuilder.CreateIndex(
                name: "IX_IdDegree",
                table: "Presence",
                column: "IdDegree");

            migrationBuilder.CreateIndex(
                name: "IX_IdStudent",
                table: "Presence",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_IdCoordinator",
                table: "Program",
                column: "IdCoordinator");

            migrationBuilder.CreateIndex(
                name: "IX_IdEvasionHistory",
                table: "ReasonEvasion",
                column: "IdEvasionHistory");

            migrationBuilder.CreateIndex(
                name: "IX_IdReason",
                table: "ReasonEvasion",
                column: "IdReason");

            migrationBuilder.CreateIndex(
                name: "IX_IdReason",
                table: "ReasonHistory",
                column: "IdReason");

            migrationBuilder.CreateIndex(
                name: "IX_IdCourse",
                table: "Score",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_IdStudent",
                table: "Score",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_IdPerson",
                table: "Student",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_IdEmployee",
                table: "User",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_IdPerfil",
                table: "User",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_IdReason",
                table: "Wanted",
                column: "IdReason");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alert");

            migrationBuilder.DropTable(
                name: "CampusProgram");

            migrationBuilder.DropTable(
                name: "ClassDiary");

            migrationBuilder.DropTable(
                name: "ClassRoomStudent");

            migrationBuilder.DropTable(
                name: "EmployeeCampus");

            migrationBuilder.DropTable(
                name: "EmployeeCourse");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PersonType");

            migrationBuilder.DropTable(
                name: "Presence");

            migrationBuilder.DropTable(
                name: "ReasonEvasion");

            migrationBuilder.DropTable(
                name: "ReasonHistory");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Wanted");

            migrationBuilder.DropTable(
                name: "Template");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Campus");

            migrationBuilder.DropTable(
                name: "EvasionHistory");

            migrationBuilder.DropTable(
                name: "Reason");

            migrationBuilder.DropTable(
                name: "Degree");

            migrationBuilder.DropTable(
                name: "Institution");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "ClassRoom");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
