using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Presence
{
    public class AbsentViewModel : IEquatable<AbsentViewModel>
    {
        public int IdStudent { get; set; }
        public string Name { get; set; }
        public int RA { get; set; }
        public decimal Frequency { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }

        public bool Equals(AbsentViewModel other)
        {
            if (Object.ReferenceEquals(other, null)) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return IdStudent.Equals(other.IdStudent);
        }

        public override int GetHashCode()
        {
            return IdStudent.GetHashCode();
        }
    }
}
