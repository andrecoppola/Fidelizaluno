using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Repository.ReadOnly
{
    public interface IClassRoomReadOnlyRepository : IReadOnlyRepository<ClassRoomEntity>
    {
        IEnumerable<ClassRoomEntity> GetClassRoomByProgram(int idProgram);
        IEnumerable<ClassRoomEntity> GetAll(int? IdCampus);
    }
}
