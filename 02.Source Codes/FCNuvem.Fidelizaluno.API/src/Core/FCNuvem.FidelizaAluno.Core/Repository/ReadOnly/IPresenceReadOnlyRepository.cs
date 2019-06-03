using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Repository.ReadOnly
{
    public interface IPresenceReadOnlyRepository : IReadOnlyRepository<PresenceEntity>
    {
        IEnumerable<PresenceEntity> GetByClass(int IdClass, DateTime? date = null);
        IEnumerable<PresenceEntity> GetAbsent(DateTime date, int? idPeriod, int? idProgram = null, int? IdClassRoom = null, int? idCampus = null);
        PresenceEntity Get(int idStudent, int idClass);
    }
}
