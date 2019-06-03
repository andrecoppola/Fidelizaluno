using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Repository.ReadOnly
{
    public interface IStudentReadOnlyRepository : IReadOnlyRepository<StudentEntity>
    {
        IEnumerable<StudentEntity> GetAll(EvasionFilter evasaoFilter);
        int GetCountByEvasion(EvasionFilter evasaoFilter);
        IEnumerable<StudentEntity> Search(PersonFilter PersonFilter);
        IEnumerable<StudentEntity> GetAllByClassRoom(int idClassRoom);
        IEnumerable<StudentEntity> GetAllByClassRoom(EvasionFilter evasionFilter);
        IEnumerable<StudentEntity> GetAllByClass(int IdClass);
    }
}
