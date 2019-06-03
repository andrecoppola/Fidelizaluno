using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Framework.ValueObjects
{
    public interface IEnumeration
    {
        string Value { get; }

        string DisplayName { get; }
    }
}
