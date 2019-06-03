using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class ClassRoomStudentService : ServiceBase
    {
        public ClassRoomStudentService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IClassRoomStudentRepository ClassRoomStudentRepository => GetService<IClassRoomStudentRepository>();
        private IClassRoomStudentReadOnlyRepository ClassRoomStudentReadOnlyRepository => GetService<IClassRoomStudentReadOnlyRepository>();


        public void Save(ClassRoomStudentEntity alunoEntity)
        {
            ClassRoomStudentRepository.Save(alunoEntity);
        }
    }
}
