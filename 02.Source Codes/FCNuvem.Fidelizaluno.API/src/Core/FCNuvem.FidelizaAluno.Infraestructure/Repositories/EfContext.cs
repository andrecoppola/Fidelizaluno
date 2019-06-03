using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories
{
    internal partial class EfContext : DbContext
    {
        public EfContext(DbContextOptions<EfContext> options)
            : base(options)
        {
        }

        public DbSet<PersonEntity> Person { get; set; }
        public DbSet<ProgramEntity> Program { get; set; }
        public DbSet<StudentEntity> Student { get; set; }
        public DbSet<EmployeeEntity> Employee { get; set; }
        public DbSet<EmployeeCourseEntity> EmployeeCourse { get; set; }
        public DbSet<EmployeeCampusEntity> EmployeeCampus { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<PeriodEntity> Period { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<PerfilEntity> Perfil { get; set; }
        public DbSet<ReasonHistoryEntity> ReasonHistory { get; set; }
        public DbSet<ClassDiaryEntity> ClassDiary { get; set; }
        public DbSet<CourseEntity> Course { get; set; }
        public DbSet<DegreeEntity> Degree { get; set; }
        public DbSet<InstitutionEntity> Institution { get; set; }
        public DbSet<PaymentEntity> Payment { get; set; }
        public DbSet<ScoreEntity> Score { get; set; }
        public DbSet<PresenceEntity> Presence { get; set; }
        public DbSet<ClassRoomEntity> ClassRoom { get; set; }
        public DbSet<ClassEntity> Class { get; set; }
        public DbSet<CampusEntity> Campus { get; set; }
        public DbSet<ClassRoomStudentEntity> StudentClass { get; set; }
        public DbSet<AlertEntity> Alert { get; set; }
        public DbSet<TemplateEntity> Template { get; set; }
        public DbSet<ReasonEntity> Reason { get; set; }
        public DbSet<NotificationEntity> Notification { get; set; }
        public DbSet<WantedEntity> Wanted { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var mapTypes = from t in GetType().Assembly.GetTypes()
                           where t.BaseType != null &&
                                 t.BaseType.IsGenericType &&
                                 !t.IsGenericTypeDefinition &&
                                 (t.BaseType.GetGenericTypeDefinition() == typeof(EntityMapConfiguration<>) ||
                                  t.BaseType.GetGenericTypeDefinition() == typeof(EntityMapConfiguration<,>))
                           select t;

            //Adicionando os mapeamentos
            foreach (var mapType in mapTypes)
            {
                var map = Activator.CreateInstance(mapType) as EntityMapConfiguration;
                map?.Mapping(modelBuilder);
            }

            //Alterando o tipo nvarchar par varchar
            foreach (var prop in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties()))
            {
                var sqlProp = prop.SqlServer();

                if (prop.ClrType == typeof(string) && sqlProp.ColumnType == null)
                {
                    sqlProp.ColumnType = $"varchar({prop.GetMaxLength()?.ToString() ?? "MAX"})";
                }
            }

            //Padronizando os nomes das PKs
            foreach (var key in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetKeys()))
            {
                key.SqlServer().Name = key.SqlServer().Name.Replace("Entity", string.Empty);
            }

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                //Criar index para FK
                var properties = relationship.Properties.Select(p => p.Name).ToArray();

                if (!relationship.DeclaringEntityType.ClrType.Name.EndsWith("OwnedType"))
                    modelBuilder.Entity(relationship.DeclaringEntityType.ClrType)
                        .HasIndex(properties)
                        .HasName($"IX_{string.Join("_", properties)}");
            }
        }

    }
}
