using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories
{
    internal class StudentRepository : RepositoryBase<StudentEntity>, IStudentRepository
    {
        public StudentRepository(IServiceProvider serviceProvider)
            : base(serviceProvider)
        { }

        public override StudentEntity Get(int id)
        {
            return DbContext.Student
                .Include(l => l.Presence)
                .Include(l => l.Person)
                    .ThenInclude(l => l.Address)
                .Include(u => u.EvasionHistory)
                    .ThenInclude(u => u.ReasonEvasion)
                        .ThenInclude(u => u.Reason)
                .Where(l => l.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<StudentEntity> Search(PersonFilter personFilter)
        {
            var query = DbContext.Student
                .Include(l => l.Presence)
                .Include(l => l.Person)
                .Include(l => l.ClassRoomStudent)
                    .ThenInclude(c => c.ClassRoom)
                .AsQueryable();

            if (!String.IsNullOrEmpty(personFilter.Name))
                query = query.Where(l => l.Person.Name.Contains(personFilter.Name));

            if (personFilter.IdClassRoom.HasValue)
                query = query.Where(l => l.ClassRoomStudent.Any(u => u.IdClassRoom == personFilter.IdClassRoom));

            if (personFilter.IdProgram.HasValue)
                query = query.Where(l => l.ClassRoomStudent.Any(x => x.ClassRoom.IdProgram == personFilter.IdProgram));

            if (personFilter.RA.HasValue)
                query = query.Where(l => l.RA == personFilter.RA);

            if (personFilter.IdCampus.HasValue)
                query = query.Where(l => l.ClassRoomStudent.Any(c => c.ClassRoom.IdCampus == personFilter.IdCampus));

            return query;
        }

        public IEnumerable<StudentEntity> GetAllByClassRoom(int idClassRoom)
        {
            var query = DbContext.Student
                .Include(l => l.Person)
                .Include(q => q.ClassRoomStudent)
                    .ThenInclude(StudentClass => StudentClass.ClassRoom)
                        .ThenInclude(Class => Class.Program)
                .Include(Person => Person.Presence)
                .Include(u => u.EvasionHistory)
                    .ThenInclude(u => u.ReasonEvasion)
                        .ThenInclude(u => u.Reason)
                .AsQueryable();

            return query.Where(l => l.ClassRoomStudent.Any(q => q.IdClassRoom == idClassRoom)).OrderBy(l => l.Person.Name);
        }

        public IEnumerable<StudentEntity> GetAllByClassRoom(EvasionFilter evasionFilter)
        {
            var query = DbContext.Student
                .Include(l => l.Person)
                .Include(q => q.ClassRoomStudent)
                    .ThenInclude(StudentClass => StudentClass.ClassRoom)
                        .ThenInclude(Class => Class.Program)
                .Include(Person => Person.Presence)
                .Include(u => u.EvasionHistory)
                    .ThenInclude(u => u.ReasonEvasion)
                        .ThenInclude(u => u.Reason)
                .Where(l => (l.EvasionScore >= evasionFilter.IntervalMin && l.EvasionScore < evasionFilter.IntervalMax))
                .AsQueryable();

            if (evasionFilter.IdClassRoom.HasValue)
            {
                query = query.Where(l => l.ClassRoomStudent.Any(c => (c.IdClassRoom == evasionFilter.IdClassRoom)));
            }

            return query.OrderBy(l => l.Person.Name);
        }

        public IEnumerable<StudentEntity> GetAll(EvasionFilter evasionFilter)
        {
            var query = DbContext.Student
                .Include(Student => Student.Person)
                .Include(Student => Student.ClassRoomStudent)
                .Include(Student => Student.Presence)
                .Where(s => s.EvasionScore >= evasionFilter.IntervalMin && s.EvasionScore < evasionFilter.IntervalMax)
                .AsQueryable();

            if (evasionFilter.IdClassRoom != null)
                query = query.Where(s => s.ClassRoomStudent.Any(i => i.IdClassRoom == evasionFilter.IdClassRoom));

            return query;
        }

        public int GetCountByEvasion(EvasionFilter evasionFilter)
        {
            var query = DbContext.Student
                                .Where(s => s.EvasionScore >= evasionFilter.IntervalMin && s.EvasionScore < evasionFilter.IntervalMax)
                                .AsQueryable();

            if (evasionFilter.IdCampus.HasValue)
            {
                query = query.Include(s => s.ClassRoomStudent)
                                .ThenInclude(c => c.ClassRoom);

                if (evasionFilter.IdClassRoom.HasValue)
                {
                    query = query.Where(s => s.ClassRoomStudent.Any(i => (i.ClassRoom.IdCampus == evasionFilter.IdCampus) && (i.IdClassRoom == evasionFilter.IdClassRoom)));
                }
                else
                {
                    query = query.Where(s => s.ClassRoomStudent.Any(i => i.ClassRoom.IdCampus == evasionFilter.IdCampus));
                }
            }
            else
            {
                query = query.Include(s => s.ClassRoomStudent);

                if (evasionFilter.IdClassRoom.HasValue)
                {
                    query = query.Where(s => s.ClassRoomStudent.Any(i => i.IdClassRoom == evasionFilter.IdClassRoom));
                }
                else
                {
                    query = query.Where(s => s.ClassRoomStudent.Any());
                }
            }

            return query.Count();
        }

        public IEnumerable<StudentEntity> GetAllByClass(int idClass)
        {
            return DbContext.Student
                    .Include(s => s.Person)
                    .Include(s => s.Presence)
                    .Include(l => l.ClassRoomStudent)
                        .ThenInclude(st => st.ClassRoom)
                            .ThenInclude(c => c.Degree)
                            .ThenInclude(c => c.Class)
                            .Where(u => u.ClassRoomStudent.Any(
                                q => q.ClassRoom.Degree.Any(
                                    j => j.Class.Any(
                                        i => i.Id == idClass))));
        }
    }
}
