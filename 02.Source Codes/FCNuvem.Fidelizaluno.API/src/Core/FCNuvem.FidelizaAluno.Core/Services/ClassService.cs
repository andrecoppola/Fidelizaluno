using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class ClassRoomService : ServiceBase
    {
        public ClassRoomService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IClassRoomRepository ClassRoomRepository => GetService<IClassRoomRepository>();
        private IClassRoomReadOnlyRepository ClassRoomReadOnlyRepository => GetService<IClassRoomReadOnlyRepository>();


        public void Save(ClassRoomEntity alunoEntity)
        {
            ClassRoomRepository.Save(alunoEntity);
        }
    }
}
