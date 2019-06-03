using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class ClassRoomEntity : EntityBase
    {
        public ClassRoomEntity(int id) 
            : base(id)
        {}

        public string Name { get; set; }
        public string Half { get; set; }
        public DateTime DataInicial { get; set; }

        public CampusEntity Campus { get; set; }
        public int? IdCampus { get; set; }
        public ProgramEntity Program { get; set; }
        public int IdProgram { get; set; }
        public EmployeeEntity Employee { get; set; }
        public int IdEmployee { get; set; }
        public PeriodEntity Period { get; set; }
        public int IdPeriod { get; set; }

        public ICollection<ClassRoomStudentEntity> ClassRoomStudent { get; set; } = new List<ClassRoomStudentEntity>();
        public ICollection<PaymentEntity> Payment { get; set; } = new List<PaymentEntity>();
        public ICollection<DegreeEntity> Degree { get; set; } = new List<DegreeEntity>();


    }
}
